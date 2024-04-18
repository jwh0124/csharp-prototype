using iSecureGateway_Suprema.DTO;

public class AuthorApply
{
    private readonly ILogger<AuthorApply> _logger;

    public AuthorApply(ILogger<AuthorApply> logger)
    {
        _logger = logger;
    }

     public bool AuthorDeviceApply(AuthorDto authorDto){
        _logger.LogInformation("Start Device Apply : {AuthorName}", authorDto.Name);
        Random random= new Random();
        int a = random.Next(1, 3);
        Thread.Sleep(a * 1000);
        return a % 2 == 1;
    }
}