using iSecureGateway_Suprema.DTO;

public class PostApply
{
    private readonly ILogger<PostApply> _logger;

    public PostApply(ILogger<PostApply> logger)
    {
        _logger = logger;
    }

     public bool PostDeviceApply(int deviceId, PostDto postDto){
        _logger.LogInformation("Start Device Apply : {deviceId}", deviceId);
        Random random= new Random();
        int a = random.Next(1, 3);
        Thread.Sleep(a * 1000);
        return a % 2 == 1;
    }
}