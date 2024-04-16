namespace iSecureGateway_Suprema.Commons.Config
{
    public class ApplicationSettings
    {
        public required Dictionary<string, string> Authentication { get; set; }

        public required Dictionary<string, string> MQTT {  get; set; }

        public required Dictionary<string, string> AutoConnect { get; set; }

        public required Dictionary<string, int> RetryCount { get; set; }
    }
}
