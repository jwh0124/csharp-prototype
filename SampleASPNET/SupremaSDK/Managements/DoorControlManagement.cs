using Microsoft.Extensions.Logging;
using SupremaSDK.Libs;
using System.Runtime.InteropServices;
using static SupremaSDK.Libs.API;

namespace SupremaSDK.Managements
{
    public class DoorControlManagement
    {
        private readonly ILogger<DoorControlManagement> logger;
        private readonly nint Context;

        public DoorControlManagement(ILogger<DoorControlManagement> logger, ConnectionManager connectionManager)
        {
            this.logger = logger;
            Context = connectionManager.Context;
        }

        public ICollection<BS2Door> GetAllDoor(uint deviceID)
        {
            ICollection<BS2Door> doorList = [];

            BS2ErrorCode result = (BS2ErrorCode)BS2_GetAllDoor(Context, deviceID, out nint doorObj, out uint numDoor);

            if (result.Equals(BS2ErrorCode.BS_SDK_SUCCESS))
            {
                if (numDoor > 0)
                {

                    nint curDoorObj = doorObj;
                    int structSize = Marshal.SizeOf(typeof(BS2Door));

                    for (int idx = 0; idx < numDoor; ++idx)
                    {
                        BS2Door item = (BS2Door)Marshal.PtrToStructure(curDoorObj, typeof(BS2Door));
                        doorList.Add(item);
                        curDoorObj = (nint)((long)curDoorObj + structSize);
                    }

                    BS2_ReleaseObject(doorObj);
                }
            }

            return doorList;
        }

        public BS2ErrorCode SetDoor(uint deviceID, ICollection<BS2Door> doorList)
        {
            int structSize = Marshal.SizeOf(typeof(BS2Door));
            nint doorListObj = Marshal.AllocHGlobal(structSize * doorList.Count);
            nint curDoorListObj = doorListObj;
            foreach (BS2Door item in doorList)
            {
                Marshal.StructureToPtr(item, curDoorListObj, false);
                curDoorListObj = (nint)((long)curDoorListObj + structSize);
            }

            BS2ErrorCode result = (BS2ErrorCode)BS2_SetDoor(Context, deviceID, doorListObj, (uint)doorList.Count);

            logger.LogInformation("{result}", result);

            Marshal.FreeHGlobal(doorListObj);

            return result;
        }

        public BS2ErrorCode RemoveDoor(uint deviceID, ICollection<uint> doorIDList)
        {
            nint doorIDObj = Marshal.AllocHGlobal(4 * doorIDList.Count);
            nint curDoorIDObj = doorIDObj;
            foreach (uint item in doorIDList)
            {
                Marshal.WriteInt32(curDoorIDObj, (int)item);
                curDoorIDObj = (nint)((long)curDoorIDObj + 4);
            }

            BS2ErrorCode result = (BS2ErrorCode)BS2_RemoveDoor(Context, deviceID, doorIDObj, (uint)doorIDList.Count);

            logger.LogInformation("{result}", result);

            Marshal.FreeHGlobal(doorIDObj);

            return result;
        }

        public ICollection<BS2DoorStatus> GetDoorStatus(uint deviceID, ICollection<uint> doorIDList)
        {
            ICollection<BS2DoorStatus> doorStatusList = [];
            nint doorIDObj = Marshal.AllocHGlobal(4 * doorIDList.Count);
            nint curDoorIDObj = doorIDObj;
            foreach (uint item in doorIDList)
            {
                Marshal.WriteInt32(curDoorIDObj, (int)item);
                curDoorIDObj = (nint)((long)curDoorIDObj + 4);
            }

            BS2ErrorCode result = (BS2ErrorCode)BS2_GetDoorStatus(Context, deviceID, doorIDObj, (uint)doorIDList.Count, out nint doorStatusObj, out uint numDoorStatus);
            if (numDoorStatus > 0)
            {
                nint curDoorStatusObj = doorStatusObj;
                int structSize = Marshal.SizeOf(typeof(BS2DoorStatus));

                for (int idx = 0; idx < numDoorStatus; ++idx)
                {
                    BS2DoorStatus item = (BS2DoorStatus)Marshal.PtrToStructure(curDoorStatusObj, typeof(BS2DoorStatus));
                    doorStatusList.Add(item);
                    curDoorStatusObj = (nint)((long)curDoorStatusObj + structSize);
                }

                BS2_ReleaseObject(doorStatusObj);
            }

            Marshal.FreeHGlobal(doorIDObj);

            return doorStatusList;
        }

        public BS2ErrorCode LockDoor(uint deviceID, byte doorFlag, nint doorIDObj, uint numDoor)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_LockDoor(Context, deviceID, doorFlag, doorIDObj, numDoor);
            
            Marshal.FreeHGlobal(doorIDObj);

            logger.LogInformation("{result}", result);

            return result;
        }

        public BS2ErrorCode UnLockDoor(uint deviceID, byte doorFlag, nint doorIDObj, uint numDoor)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_UnlockDoor(Context, deviceID, doorFlag, doorIDObj, numDoor);

            Marshal.FreeHGlobal(doorIDObj);

            logger.LogInformation("{result}", result);

            return result;
        }

        public BS2ErrorCode ReleaseDoor(uint deviceID, byte doorFlag, nint doorIDObj, uint numDoor)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_ReleaseDoor(Context, deviceID, doorFlag, doorIDObj, numDoor);

            Marshal.FreeHGlobal(doorIDObj);

            logger.LogInformation("{result}", result);

            return result;
        }
    }
}
