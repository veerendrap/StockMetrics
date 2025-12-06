using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NSEWebApp.UIHelpers
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
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
                // Log the error details to a text file
                LogErrorToFile(ex);

                if (context.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    // Handle asynchronous requests by returning a generic JSON response
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync("An error occurred while processing your request.");
                }
                else
                {
                    // Handle synchronous requests by redirecting to an error page
                    context.Response.Redirect("/Error");
                }
            }
        }

        private void LogErrorToFile(Exception ex)
        {
            string logFilePath = $"ErrorLog/{DateTime.UtcNow.ToString("yyyyMMdd")}.txt";
            string errorMessage = $"{DateTime.UtcNow}: {ex.Message}\n{ex.StackTrace}\n\n";
            errorMessage += Environment.NewLine + "----------------------------------------------------------------" + Environment.NewLine;
            File.AppendAllText(logFilePath, errorMessage);
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
