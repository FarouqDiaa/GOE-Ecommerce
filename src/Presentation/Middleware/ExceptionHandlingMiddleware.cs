using System.Net;
using System.Text.Json;
using Application.Exceptions.UserExceptions;
using Application.Exceptions.ProductExceptions;
using Application.Exceptions.CartExceptions;
using Application.Responses;

namespace Presentation.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            (HttpStatusCode statusCode, string message) = exception switch
            {
                CartNotFoundException => (HttpStatusCode.NotFound, "Cart not found"),
                ProductNotFoundException => (HttpStatusCode.NotFound, "Product not found"),
                EmailUsedException => (HttpStatusCode.BadRequest, "Email is already in use"),
                UserNotFoundException => (HttpStatusCode.NotFound, "User not found"),
                _ => (HttpStatusCode.InternalServerError, "An unexpected error occurred")
            };

            _logger.LogError(exception, message);
            context.Response.StatusCode = (int)statusCode;

            var errorResponse = new ErrorResponse
            {
                Errors = new Dictionary<string, string[]>
                {
                    { "Error", new[] { message } }
                }
            };

            var json = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            await context.Response.WriteAsync(json);
        }
    }
}
