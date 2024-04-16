using Microsoft.Extensions.Logging;
using SupremaSDK.Libs;
using System.Runtime.InteropServices;
using static SupremaSDK.Libs.API;

namespace SupremaSDK.Managements
{
    public class DeviceManagement
    {
        private readonly ILogger<DeviceManagement> logger;
        private readonly ConnectionManager connectionManager;
        private readonly nint Context;

        public DeviceManagement(ILogger<DeviceManagement> logger, ConnectionManager connectionManager)
        {
            this.logger = logger;
            this.connectionManager = connectionManager;
            Context = connectionManager.Context;
        }
        public BS2ErrorCode SearchDevices()
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_SearchDevices(Context);

            logger.LogInformation("Search to devices : {result}", result);

            return result;
        }

        public BS2ErrorCode ConnectDevice(uint deviceID)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_ConnectDevice(Context, deviceID);

            logger.LogInformation("Connect to device {deviceID} : {result}", deviceID, result);

            return result;
        }

        public ICollection<BS2SimpleDeviceInfo> GetDeviceList()
        {
            ICollection<BS2SimpleDeviceInfo> deviceInfoList = new HashSet<BS2SimpleDeviceInfo>();

            BS2ErrorCode result = (BS2ErrorCode)BS2_GetDevices(Context, out IntPtr deviceListObj, out uint numDevice);

            logger.LogInformation("Get devices : {result}", result.ToString());

            logger.LogInformation("Search device number : {numDevice}", numDevice);
            if (numDevice > 0)
            {
                for (uint idx = 0; idx < numDevice; ++idx)
                {
                    uint deviceID = Convert.ToUInt32(Marshal.ReadInt32(deviceListObj, (int)idx * sizeof(uint)));
                    result = (BS2ErrorCode)BS2_GetDeviceInfo(Context, deviceID, out BS2SimpleDeviceInfo deviceInfo);

                    if (result.Equals(BS2ErrorCode.BS_SDK_SUCCESS))
                    {
                        deviceInfoList.Add(deviceInfo);
                    }
                    else
                    {
                        logger.LogInformation("{result}", result);
                        break;
                    }
                }
            }
            else
            {
                logger.LogInformation("No search device");
            }
            BS2_ReleaseObject(deviceListObj);

            return deviceInfoList;
        }

        public BS2ErrorCode StartMonitoringLog(uint deviceID)
        {
            return connectionManager.StartMonitoringLog(deviceID);
        }

        public BS2ErrorCode SearchDeviceByIPAddress(string hostIP)
        {
            nint hostIPChar = Marshal.StringToHGlobalAnsi(hostIP);

            BS2ErrorCode result = (BS2ErrorCode)BS2_SearchDevicesEx(Context, hostIPChar);

            if (result.Equals(BS2ErrorCode.BS_SDK_SUCCESS))
            {
                result = (BS2ErrorCode)BS2_GetDevices(Context, out IntPtr deviceListObj, out uint numDevice);

                logger.LogInformation("BS2 GetDevices : {result}", result.ToString());

                logger.LogInformation("BS2 numDevice : {result}", numDevice.ToString());
                if (numDevice > 0)
                {
                    logger.LogInformation("{result}", result);
                }
            }

            Marshal.FreeHGlobal(hostIPChar);

            return result;
        }

        public BS2ErrorCode ConnectDeviceViaIP(string hostIP, ushort port)
        {
            nint hostIPChar = Marshal.StringToHGlobalAnsi(hostIP);

            BS2ErrorCode result = (BS2ErrorCode)BS2_ConnectDeviceViaIP(Context, hostIPChar, port, out uint deviceId);

            if (result.Equals(BS2ErrorCode.BS_SDK_SUCCESS))
            {
                logger.LogInformation("Connected Success : {deviceId}", deviceId);
            }

            Marshal.FreeHGlobal(hostIPChar);

            return result;
        }

        public BS2SimpleDeviceInfo GetDeviceInfo(uint deviceID)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_GetDeviceInfo(Context, deviceID, out BS2SimpleDeviceInfo deviceInfo);

            logger.LogInformation("GetDeviceInfo {deviceID} : {result}",deviceID, result);

            return deviceInfo;
        }

        public BS2ErrorCode UnlockDevice(uint deviceID)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_UnlockDevice(Context, deviceID);

            logger.LogInformation("{result}", result);

            return result;
        }

        public BS2ErrorCode LockDevice(uint deviceID)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_LockDevice(Context, deviceID);

            logger.LogInformation("{result}", result);

            return result;
        }

        public DateTime GetDeviceTime(uint deviceID)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_GetDeviceTime(Context, deviceID, out uint deviceTime);

            logger.LogInformation("{result}", result);

            return Util.ConvertFromUnixTimestamp(deviceTime);
        }

        public BS2ErrorCode SetDeviceTime(uint deviceID)
        {
            uint timestamp = Convert.ToUInt32(Util.ConvertToUnixTimestamp(DateTime.Now));

            BS2ErrorCode result = (BS2ErrorCode)BS2_SetDeviceTime(Context, deviceID, timestamp);

            logger.LogInformation("{result}", result);

            return result;
        }

        public BS2ErrorCode FactoryReset(uint deviceID)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_FactoryReset(Context, deviceID);

            logger.LogInformation("{result}", result);

            return result;
        }

        public BS2ErrorCode RebootDevice(uint deviceID)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_RebootDevice(Context, deviceID);

            logger.LogInformation("{result}", result);

            return result;
        }

        public BS2ErrorCode ClearDatabase(uint deviceID)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_ClearDatabase(Context, deviceID);

            logger.LogInformation("{result}", result);

            return result;
        }
    }
}
