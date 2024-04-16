namespace iSecureGateway_Suprema.Commons.Http.Request
{
    public class RequestCommonDto<T>
    {
        public required RequestInfoDto Info { get; set; }

        public T? TData { get; set; }
    }
}
