using Microsoft.Extensions.Logging;
using SupremaSDK.Libs;
using System.Runtime.InteropServices;
using static SupremaSDK.Libs.API;

namespace SupremaSDK.Managements
{
    public class ZoneControlManagement
    {
        private readonly ILogger<ZoneControlManagement> logger;
        private readonly nint Context;

        public ZoneControlManagement(ILogger<ZoneControlManagement> logger, ConnectionManager connectionManager)
        {
            this.logger = logger;
            Context = connectionManager.Context;
        }

        public ICollection<BS2ScheduledLockUnlockZone> GetScheduledLockUnlockZone(uint deviceID)
        {
            ICollection<BS2ScheduledLockUnlockZone> scheduledLockUnlockZoneList = [];

            BS2ErrorCode result = (BS2ErrorCode)BS2_GetAllScheduledLockUnlockZone(Context, deviceID, out nint zoneObj, out uint numZone);

             if (numZone > 0)
            {
                nint curZoneObj = zoneObj;
                int structSize = Marshal.SizeOf(typeof(BS2ScheduledLockUnlockZone));

                for (int idx = 0; idx < numZone; ++idx)
                {
                    BS2ScheduledLockUnlockZone item = (BS2ScheduledLockUnlockZone)Marshal.PtrToStructure(curZoneObj, typeof(BS2ScheduledLockUnlockZone));
                    scheduledLockUnlockZoneList.Add(item);
                    curZoneObj = (nint)((long)curZoneObj + structSize);
                }

                BS2_ReleaseObject(zoneObj);
            }

            return scheduledLockUnlockZoneList;
        }

        public BS2ErrorCode SetScheduledLockUnlockZone(uint deviceID, ICollection<BS2ScheduledLockUnlockZone> scheduledLockUnlockZoneList)
        {
            int structSize = Marshal.SizeOf(typeof(BS2ScheduledLockUnlockZone));
            nint slulListObj = Marshal.AllocHGlobal(structSize * scheduledLockUnlockZoneList.Count);
            nint curSlulListObj = slulListObj;
            foreach (BS2ScheduledLockUnlockZone item in scheduledLockUnlockZoneList)
            {
                Marshal.StructureToPtr(item, curSlulListObj, false);
                curSlulListObj = (nint)((long)curSlulListObj + structSize);
            }

            BS2ErrorCode result = (BS2ErrorCode)BS2_SetScheduledLockUnlockZone(Context, deviceID, slulListObj, (uint)scheduledLockUnlockZoneList.Count);

            logger.LogInformation("{result}", result);

            Marshal.FreeHGlobal(slulListObj);

            return result;
        }

        public BS2ErrorCode RemoveScheduledLockUnlockZone(uint deviceID, ICollection<uint> scheduledLockUnlockZoneIDList)
        {
            nint zoneIDObj = Marshal.AllocHGlobal(4 * scheduledLockUnlockZoneIDList.Count);
            IntPtr curZoneIDObj = zoneIDObj;
            foreach (UInt32 item in scheduledLockUnlockZoneIDList)
            {
                Marshal.WriteInt32(curZoneIDObj, (Int32)item);
                curZoneIDObj = (IntPtr)((long)curZoneIDObj + 4);
            }

            BS2ErrorCode result = (BS2ErrorCode)API.BS2_RemoveScheduledLockUnlockZone(Context, deviceID, zoneIDObj, 1);

            logger.LogInformation("{result}", result);

            Marshal.FreeHGlobal(zoneIDObj);
            
            return result;
        }
    }
}
