using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace iSecureGateway_Suprema.Commons.Config.Auth
{
    public class HttpAuthentication : IAuthorizationFilter
    {
        private const string ApiKeyHeader = "X-Api-Key";
        private readonly string? ExpectedApiKey;

        public HttpAuthentication(IConfiguration configuration)
        {
            ExpectedApiKey = configuration.GetValue<string>("Authentication:ApiKey");
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeader, out var apiKeyValue))
            {
                context.Result = new UnauthorizedObjectResult("API Key not found");
                return;
            }

            if (!apiKeyValue.Equals(ExpectedApiKey))
            {
                context.Result = new UnauthorizedObjectResult("Invalid API Key");
            }
        }
    }
}
