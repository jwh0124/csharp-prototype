using EntityFramework.Exceptions.Common;
using iSecureGateway_Suprema.Commons.Http.Response;
using Newtonsoft.Json;
using System.Net;
using static iSecureGateway_Suprema.Commons.Filters.LegacyServiceFilter;

namespace iSecureGateway_Union.Commons.Middleware
{
    public class HttpMiddleware
    {
        private readonly ILogger<HttpMiddleware> logger;
        private readonly RequestDelegate next;

        public HttpMiddleware(ILogger<HttpMiddleware> logger ,RequestDelegate next)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            { 
                await next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext,exception);
            }
        }

        private Task FinishHttpRequest(object context)
        {
            logger.LogInformation(ProcessStatus.FINISH.ToString());

            return Task.FromResult(0);
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var(code, responseEnum) = GetExceptionCodes(exception);

            var exceptionResult = JsonConvert.SerializeObject(new ApiResponseBody<object>(responseEnum, exception.Message));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            await context.Response.WriteAsync(exceptionResult);
        }

        private static (HttpStatusCode code, Enum responseEnum) GetExceptionCodes(Exception exception)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError;
            Enum responseEnum = ApiResponse.SYSTEM_ERROR;

            if (exception is UniqueConstraintException)
            {
                code = HttpStatusCode.BadRequest;
                responseEnum = ApiResponse.DUPLICATE_KEY;
            }

            return (code, responseEnum);
        }
    }
}
