using Microsoft.Extensions.Logging;
using SupremaSDK.Libs;
using System.Runtime.InteropServices;
using static SupremaSDK.Libs.API;

namespace SupremaSDK.Managements
{
    public class SlaveControlManagement
    {
        private readonly ILogger<SlaveControlManagement> logger;
        private readonly nint Context;

        public SlaveControlManagement(ILogger<SlaveControlManagement> logger, ConnectionManager connectionManager)
        {
            this.logger = logger;
            Context = connectionManager.Context;
        }

        public List<BS2Rs485SlaveDevice> GetSlaveDevice(uint deviceID)
        {
            Console.WriteLine("Trying to get the slave devices.");
            List<BS2Rs485SlaveDevice> slaveDeviceList = [];
            BS2ErrorCode result = (BS2ErrorCode)BS2_GetSlaveDevice(Context, deviceID, out nint slaveDeviceObj, out uint slaveDeviceCount);

            if (result != BS2ErrorCode.BS_SDK_SUCCESS)
            {
                Console.WriteLine("Got error({0}).", result);
            }
            else if (slaveDeviceCount > 0)
            {
                nint curSlaveDeviceObj = slaveDeviceObj;
                int structSize = Marshal.SizeOf(typeof(BS2Rs485SlaveDevice));

                for (int idx = 0; idx < slaveDeviceCount; ++idx)
                {
                    BS2Rs485SlaveDevice item = (BS2Rs485SlaveDevice)Marshal.PtrToStructure(curSlaveDeviceObj, typeof(BS2Rs485SlaveDevice));
                    slaveDeviceList.Add(item);
                    curSlaveDeviceObj = (nint)((long)curSlaveDeviceObj + structSize);
                }

                BS2_ReleaseObject(slaveDeviceObj);
            }

            return slaveDeviceList;
        }

        public void SetSlaveDevice(uint deviceID, uint slaveDeviceID)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_GetSlaveDevice(Context, deviceID, out nint slaveDeviceObj, out uint slaveDeviceCount);

            if (result != BS2ErrorCode.BS_SDK_SUCCESS)
            {
                Console.WriteLine("Got error({0}).", result);
            }
            else if (slaveDeviceCount > 0)
            {
                List<BS2Rs485SlaveDevice> slaveDeviceList = new();
                nint curSlaveDeviceObj = slaveDeviceObj;
                int structSize = Marshal.SizeOf(typeof(BS2Rs485SlaveDevice));

                for (int idx = 0; idx < slaveDeviceCount; ++idx)
                {
                    BS2Rs485SlaveDevice item = (BS2Rs485SlaveDevice)Marshal.PtrToStructure(curSlaveDeviceObj, typeof(BS2Rs485SlaveDevice));
                    slaveDeviceList.Add(item);
                    curSlaveDeviceObj = (nint)((long)curSlaveDeviceObj + structSize);
                }

                HashSet<uint> connectSlaveDevice = [slaveDeviceID];


                curSlaveDeviceObj = slaveDeviceObj;
                for (int idx = 0; idx < slaveDeviceCount; ++idx)
                {
                    BS2Rs485SlaveDevice item = (BS2Rs485SlaveDevice)Marshal.PtrToStructure(curSlaveDeviceObj, typeof(BS2Rs485SlaveDevice));

                    if (connectSlaveDevice.Contains(item.deviceID))
                    {
                        if (item.enableOSDP != 1)
                        {
                            item.enableOSDP = 1;
                            Marshal.StructureToPtr(item, curSlaveDeviceObj, false);
                        }
                    }
                    else
                    {
                        if (item.enableOSDP != 0)
                        {
                            item.enableOSDP = 0;
                            Marshal.StructureToPtr(item, curSlaveDeviceObj, false);
                        }
                    }

                    curSlaveDeviceObj = (IntPtr)((long)curSlaveDeviceObj + structSize);
                }

                result = (BS2ErrorCode)BS2_SetSlaveDevice(Context, deviceID, slaveDeviceObj, slaveDeviceCount);

                BS2_ReleaseObject(slaveDeviceObj);

                if (result != BS2ErrorCode.BS_SDK_SUCCESS)
                {
                    Console.WriteLine("Got error({0}).", result);
                }
            }
            else
            {
                Console.WriteLine(">>> There is no slave device in the device.");
            }
        }
    }
}
