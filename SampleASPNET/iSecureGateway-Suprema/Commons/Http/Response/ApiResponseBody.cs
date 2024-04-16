using iSecureGateway_Suprema.Commons.Utils;

namespace iSecureGateway_Suprema.Commons.Http.Response
{
    public class ApiResponseBody<T>
    {
        public ApiResponseBody(Enum responseEnum)
        {
            Code = responseEnum.GetCategory();
            Message = responseEnum.GetDescription();
        }

        public ApiResponseBody(Enum responseEnum, string message)
        {
            Code = responseEnum.GetCategory();
            Message = message;
        }

        public ApiResponseBody(Enum responseEnum, T? tData)
        {
            Code = responseEnum.GetCategory();
            Message = responseEnum.GetDescription();
            TData = tData;
        }

        public string Code { get; set; }

        public string Message { get; set; }

        public T? TData { get; set; }
    }
}
