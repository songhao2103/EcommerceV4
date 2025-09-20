namespace EcommerceV4.Api.Middlewares
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {

        }
    }
}
