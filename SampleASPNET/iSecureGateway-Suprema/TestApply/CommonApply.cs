public class CommonApply
{
    public delegate bool DeviceApplyAction(int deviceId, ICollection<int> b);
    
    private readonly ILogger<CommonApply> logger;

    public CommonApply(ILogger<CommonApply> logger)
    {
        this.logger = logger;
    }

    public Task<ICollection<int>> DeviceApply(DeviceApplyAction deviceAction, ICollection<int> b)
    {
        int[] deviceIdList = { 1, 2, 3, 4, 5, 6 };

        ICollection<int> successDevice = [];

        Parallel.ForEach(deviceIdList, (deviceId) => {
            var result = deviceAction(deviceId , b);
            if(result){
                successDevice.Add(deviceId);
            }
        });

        logger.LogInformation("{successDevice}", successDevice);

        return Task.FromResult( successDevice);
    }
}