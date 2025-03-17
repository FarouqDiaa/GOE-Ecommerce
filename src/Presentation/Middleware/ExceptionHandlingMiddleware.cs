using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
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

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (CartNotFoundException ex)
            {
                _logger.LogWarning(ex, "Cart not found exception caught in middleware");
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (ProductNotFoundException ex)
            {
                _logger.LogWarning(ex, "Product not found exception caught in middleware");
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (EmailUsedException ex)
            {
                _logger.LogWarning(ex, "Used email exception caught in middleware");
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogWarning(ex, "User not found exception caught in middleware");
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "An unexpected error occurred");
            }
        }

        private Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var errorResponse = new ErrorResponse
            {
                Errors = new Dictionary<string, string[]>
                {
                    { "Error", new[] { message } }
                }
            };

            return context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
