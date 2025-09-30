using EcommerceV4.Application.Common.Abstractions.Responses;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            ApiResponse apiResponse;

            switch (ex)
            {
                case ArgumentException argEx:
                    apiResponse = ApiResponse.BadRequest(new List<string> { argEx.Message});
                    break;

                case UnauthorizedAccessException:
                    apiResponse = ApiResponse.Unauthorized(new List<string> { "Bạn không có quyền thực hiện hành động này" });
                    break;

                case KeyNotFoundException:
                    apiResponse = ApiResponse.NotFound(new List<string> { "Không tìm thấy dữ liệu" });
                    break;

                case FormatException fmEx:
                    apiResponse = ApiResponse.FormatException(new List<string> { fmEx.Message });
                    break;

                case InvalidOperationException ioe:
                    apiResponse = ApiResponse.InvalidOperationException(new List<string> { ioe.Message });
                    break;

                default:
                    apiResponse = ApiResponse.Fail(new List<string> { "Có lỗi xảy ra trong hệ thống" });
                    break;
            }

            await response.WriteAsJsonAsync(apiResponse);
        }
    }
}