using Microsoft.Extensions.Logging;
using SupremaSDK.Libs;
using System.Runtime.InteropServices;
using static SupremaSDK.Libs.API;

namespace SupremaSDK.Managements
{
    public class ConfigureManagement
    {
        private readonly ILogger<ConfigureManagement> logger;
        private readonly nint Context;

        public ConfigureManagement(ILogger<ConfigureManagement> logger, ConnectionManager connectionManager)
        {
            this.logger = logger;
            Context = connectionManager.Context;
        }

        public string GetVersion()
        {
            nint versionPtr = BS2_Version();
            string? result = null;
            if(versionPtr != IntPtr.Zero)
            {
                result = Marshal.PtrToStringAnsi(versionPtr);
            }

            return result != null ? result.Trim() : "";
        }

        public byte[] MakePinCode(string pin)
        {
            byte[] makePin = new byte[BS2Environment.BS2_PIN_HASH_SIZE];
            nint ptrChar = Marshal.StringToHGlobalAnsi(pin);
            nint pinCode = Marshal.AllocHGlobal(BS2Environment.BS2_PIN_HASH_SIZE);

            BS2ErrorCode makePinResult = (BS2ErrorCode)BS2_MakePinCode(Context, ptrChar, pinCode);

            logger.LogInformation("{result}", makePinResult);

            Marshal.Copy(pinCode, makePin, 0, BS2Environment.BS2_PIN_HASH_SIZE);
            Marshal.FreeHGlobal(ptrChar);
            Marshal.FreeHGlobal(pinCode);

            return makePin;
        }

        public BS2SystemConfig GetSystemConfig(uint deviceID)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_GetSystemConfig(Context, deviceID, out BS2SystemConfig systemConfig);

            logger.LogInformation("{result}", result);

            return systemConfig;
        }

        public BS2ErrorCode ResetConfig(uint deviceID, bool includingDB)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_ResetConfig(Context, deviceID, includingDB);

            logger.LogInformation("{result}", result);

            return result;
        }
    }
}
