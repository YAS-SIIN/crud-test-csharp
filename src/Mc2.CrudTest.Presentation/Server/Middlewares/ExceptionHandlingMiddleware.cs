using Mc2.CrudTest.Domain.DTOs;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Presentation.Shared.Exceptions;
using System.Text.Json;

namespace Mc2.CrudTest.Presentation.Server.Middlewares
{
    internal sealed class ExceptionHandlingMiddleware : IMiddleware
    {
       
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            { 

                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            ErrorException errorException = new ErrorException(0, "");
            try
            {
                errorException = (ErrorException)exception;
            } catch (Exception) {}

            ErrorDto response = new ErrorDto
            {
                StatusCode = statusCode,
                ErrorDescription = errorException.ErrorDescription,
                ErrorDetail = errorException.Message,
                ErrorCode = errorException.ErrorCode
            };
            var errorData = ResultDto<ErrorDto>.ReturnData(statusCode, response);

            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorData));
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            { 
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status400BadRequest,
                ErrorException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

        private static IDictionary<string, string[]> GetErrors(Exception exception)
        {
            IDictionary<string, string[]> errors = null;

            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors;
            }

            return errors;
        }
    }
}
