using EntityFramework.Exceptions.Common;
using iSecureGateway_Suprema.Commons.Http.Request;
using iSecureGateway_Suprema.Commons.Http.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
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
                httpContext.Request.EnableBuffering();
                var httpRequest = httpContext.Request;
                var serviceName = httpRequest.RouteValues["action"];

                if (serviceName != null)
                {
                    if (IncludeLegacyService(serviceName))
                    {
                        var rawRequestBody = await GetRawBodyAsync(httpRequest);
                        var entity = JObject.Parse(rawRequestBody);
                        var requestInfo = entity["info"];

                        if (requestInfo != null)
                        {
                            var requestInfoEntity = JsonConvert.DeserializeObject<RequestInfoDto>(requestInfo.ToString());

                            httpContext.Response.OnStarting(FinishHttpRequest, httpContext);

                            logger.LogInformation(requestInfoEntity!.Id.ToString());

                            logger.LogInformation(requestInfoEntity!.Operator.ToString());

                            logger.LogInformation(GetLegacyServiceName(serviceName).ToString());

                            logger.LogInformation(ProcessStatus.ENROLL.ToString());

                            logger.LogInformation(ProcessStatus.PROGRESS.ToString());
                        }
                    }
                }

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

            var exceptionResult = JsonConvert.SerializeObject(new ApiResponseBody<object>(responseEnum));
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

        public (RequestInfoDto, ServiceEventType) GetRequestInfoData()
        {
            RequestInfoDto requestInfoDto = new RequestInfoDto { Id = Guid.NewGuid(), Operator = "test" };
            return (requestInfoDto, ServiceEventType.AddAccessGroup);
        }

        public async Task<string> GetRawBodyAsync(HttpRequest request, Encoding? encoding = null)
        {
            if (!request.Body.CanSeek)
            {
                // We only do this if the stream isn't *already* seekable,
                // as EnableBuffering will create a new stream instance
                // each time it's called
                request.EnableBuffering();
            }

            request.Body.Position = 0;

            var reader = new StreamReader(request.Body, encoding ?? Encoding.UTF8);

            var body = await reader.ReadToEndAsync().ConfigureAwait(false);

            request.Body.Position = 0;

            return body;
        }
    }
}
