using Microsoft.Extensions.Logging;
using SupremaSDK.Libs;
using System.Runtime.InteropServices;
using System.Text;
using static SupremaSDK.Libs.API;

namespace SupremaSDK.Managements
{
    public class CardManagement
    {
        private readonly ILogger<CardManagement> logger;
        private readonly nint Context;
        private OnReadyToScan? cbCardOnReadyToScan;

        public CardManagement(ILogger<CardManagement> logger, ConnectionManager connectionManager)
        {
            this.logger = logger;
            Context = connectionManager.Context;
        }

        public BS2Card ScanCard(uint deviceID)
        {
            cbCardOnReadyToScan = new OnReadyToScan(ReadyToScanForCard);
            
            BS2ErrorCode result = (BS2ErrorCode)BS2_ScanCard(Context, deviceID, out BS2Card outCard, cbCardOnReadyToScan);
            
            logger.LogInformation("Scan Card {deviceID} : {result}",deviceID, result);

            cbCardOnReadyToScan = null;

            return outCard;
        }

        public BS2CardModelEnum GetCardModel(uint deviceID)
        {
            BS2ErrorCode getFactoryConfigResult = (BS2ErrorCode)BS2_GetFactoryConfig(Context, deviceID, out BS2FactoryConfig factoryConfig);
            BS2CardModelEnum result = BS2CardModelEnum.ALL;

            if (getFactoryConfigResult.Equals(BS2ErrorCode.BS_SDK_SUCCESS))
            {
                nint ptrModel = Marshal.StringToHGlobalAnsi(Encoding.UTF8.GetString(factoryConfig.modelName).TrimEnd('\0'));
                BS2ErrorCode getCardModelResult = (BS2ErrorCode)BS2_GetCardModel(ptrModel, out ushort outCardModel);

                if (getCardModelResult.Equals(BS2ErrorCode.BS_SDK_SUCCESS))
                {
                    return ((BS2CardModelEnum)outCardModel);
                }
            }
            return result;
        }

        public void GetDeviceCapabilities(uint deviceID)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_GetDeviceCapabilities(Context, deviceID, out BS2DeviceCapabilities info);

            logger.LogInformation("{result}", result);
        }

        void ReadyToScanForCard(uint deviceID, uint sequence)
        {
            logger.LogInformation("ReadyToScanForCard Device : {deviceID}", deviceID);
        }
    }
}
