using System.Net;
using StudentManagementApi.Exceptions;//Includes your custom exceptions zaay  NotFoundException w BadRequestException

namespace StudentManagementApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        //RequestDelegate is a built in represents a function that can process an HTTP request in the middleware pipeline.
        //_next: This represents the next middleware in the pipeline.
      
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        //Used to log errors (built-in logging).
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task Invoke(HttpContext context)//required method for middleware weee HttpContext context contains information about the HTTP request and response
        {
            try
            {
                await _next(context);// Let the request continue to the next middleware/controller
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Not Found Error");// Logs the error message and stack trace
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;// 404
                await context.Response.WriteAsJsonAsync(new { message = ex.Message });// Return error to client as JSON
            }
            catch (BadRequestException ex)
            {
                _logger.LogError(ex, "Bad Request Error");
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Error");// Logs unknown errors
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;// 500
                await context.Response.WriteAsJsonAsync(new { message = "Something went wrong" });// Generic error
            }
        }
    }
}
