using BookCafe.Domain.BusinessExceptions;
using BookCafe.Domain.Enums;

namespace BookCafe.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string message = null;
            int code;
            try
            {
                await _next(context);
            }
            catch (BusinessExceptions ex)
            {

                if (!ErrorMessages.GetMessage(ex.Error,out message))
                {
                    ex.Error = BusinessErrorCode.Unknown;
                    var n = ErrorMessages.GetMessage(ex.Error, out message);
                }
                await context.Response.WriteAsJsonAsync(new
                {
                    code = (int)ex.Error,
                    message = message,
                    traceId = context.TraceIdentifier,
                    StatusCode = GetStatusCode(ex.Error)
                });

            }
        }
        private static int GetStatusCode(BusinessErrorCode code) => code switch
        {
            BusinessErrorCode.AuthorNotFound => StatusCodes.Status401Unauthorized,
            BusinessErrorCode.BookNotFound => StatusCodes.Status403Forbidden,

           
            _ => StatusCodes.Status400BadRequest
        };
    }
}
