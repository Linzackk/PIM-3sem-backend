using PIM_3sem_backend.Exceptions.BadRequest;
using PIM_3sem_backend.Exceptions.NotFound;

namespace PIM_3sem_backend.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
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
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            int statusCode = StatusCodes.Status500InternalServerError;
            string message = "Erro interno do Servidor";

            if (ex is NotFoundException)
            {
                statusCode = StatusCodes.Status404NotFound;
                message = ex.Message;
            }
            else if (ex is BadRequestException)
            {
                statusCode = StatusCodes.Status400BadRequest;
                message = ex.Message;
            }

            context.Response.StatusCode = statusCode;

            var result = System.Text.Json.JsonSerializer.Serialize(new
            {
                error = message,
                status = statusCode,
            });

            return context.Response.WriteAsync(result);
        }
    }
}
