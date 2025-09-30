using System.Text.Json;
using EcommerceV4.Application.Common.Abstractions.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EcommerceV4.Api.Middlewares
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            if (endpoint == null) { await _next(context); return; }

            var actionDesc = endpoint.Metadata
                .OfType<ControllerActionDescriptor>().FirstOrDefault();
            if (actionDesc == null) { await _next(context); return; }

            // Tìm parameter nào có BindingSource.Body (thường chỉ 1)
            var bodyParam = actionDesc.Parameters
                .FirstOrDefault(p => p.BindingInfo?.BindingSource == BindingSource.Body);

            if (bodyParam == null) { await _next(context); return; }

            // Get validator
            var validatorType = typeof(IValidator<>).MakeGenericType(bodyParam.ParameterType);
            var validator = context.RequestServices.GetService(validatorType) as IValidator;
            if (validator == null) { await _next(context); return; }

            // Read body once
            context.Request.EnableBuffering();
            using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
            var bodyStr = await reader.ReadToEndAsync();
            context.Request.Body.Position = 0;

            if (string.IsNullOrWhiteSpace(bodyStr))
            {
                await _next(context);
                return;
            }

            var model = JsonSerializer.Deserialize(bodyStr, bodyParam.ParameterType,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var result = await validator.ValidateAsync(new ValidationContext<object>(model!));
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                var response = ApiResponse.BadRequest(errors);
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                return;
            }

            await _next(context);
        }

    }
}
