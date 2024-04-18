public class CommonApply
{
    public delegate bool DeviceApplyAction(int deviceId);
    private readonly ILogger<CommonApply> logger;
    private readonly PostApply postApply;

    public CommonApply(ILogger<CommonApply> logger, PostApply postApply)
    {
        this.logger = logger;
        this.postApply = postApply;
    }

    public Task<ICollection<int>> DeviceApply(DeviceApplyAction deviceAction){
        int[] deviceIdList = { 1, 2, 3, 4, 5, 6 };

        ICollection<int> successDevice = [];

        Parallel.ForEach(deviceIdList, (deviceId) => {
            var result = deviceAction(deviceId);
            if(result){
                successDevice.Add(deviceId);
            }
        });

        logger.LogInformation("{successDevice}", successDevice);

        return Task.FromResult( successDevice);
    }
}