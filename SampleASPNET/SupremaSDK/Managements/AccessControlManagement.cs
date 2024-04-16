using Microsoft.Extensions.Logging;
using SupremaSDK.Libs;
using System.Runtime.InteropServices;
using static SupremaSDK.Libs.API;

namespace SupremaSDK.Managements
{
    public class AccessControlManagement
    {
        private readonly ILogger<AccessControlManagement> logger;
        private readonly nint Context;

        public AccessControlManagement(ILogger<AccessControlManagement> logger, ConnectionManager connectionManager)
        {
            this.logger = logger;
            Context = connectionManager.Context;
        }

        #region Access Group

        public ICollection<BS2AccessGroup> GetAllAccessGroup(uint deviceID)
        {
            ICollection<BS2AccessGroup> accessGroups = [];
            BS2ErrorCode result = (BS2ErrorCode)BS2_GetAllAccessGroup(Context, deviceID, out nint accessGroupObj, out uint numAccessGroup);

            if (result.Equals(BS2ErrorCode.BS_SDK_SUCCESS))
            {
                if(numAccessGroup > 0)
                {
                    nint curAccessGroupObj = accessGroupObj;
                    int structSize = Marshal.SizeOf(typeof(BS2AccessGroup));

                    for (int idx = 0; idx < numAccessGroup; ++idx)
                    {
                        BS2AccessGroup item = (BS2AccessGroup)Marshal.PtrToStructure(curAccessGroupObj, typeof(BS2AccessGroup));
                        accessGroups.Add(item);
                        curAccessGroupObj = (nint)((long)curAccessGroupObj + structSize);
                    }

                    BS2_ReleaseObject(accessGroupObj);
                }
            }

            return accessGroups;
        }

        public BS2ErrorCode SetAccessGroup(uint deviceID, ICollection<BS2AccessGroup> accessGroupList)
        {
            int structSize = Marshal.SizeOf(typeof(BS2AccessGroup));
            nint accessGroupListObj = Marshal.AllocHGlobal(structSize * accessGroupList.Count);
            nint curAccessGroupListObj = accessGroupListObj;
            foreach (BS2AccessGroup item in accessGroupList)
            {
                Marshal.StructureToPtr(item, curAccessGroupListObj, false);
                curAccessGroupListObj = (nint)((long)curAccessGroupListObj + structSize);
            }

            BS2ErrorCode result = (BS2ErrorCode)BS2_SetAccessGroup(Context, deviceID, accessGroupListObj, (uint)accessGroupList.Count);

            logger.LogInformation("{result}", result);

            Marshal.FreeHGlobal(accessGroupListObj);

            return result;
        }

        public BS2ErrorCode RemoveAccessGroup(uint deviceID, ICollection<uint> accessGroupIDList)
        {
            nint accessGroupIDObj = Marshal.AllocHGlobal(4 * accessGroupIDList.Count);
            nint curAccessGroupIDObj = accessGroupIDObj;
            foreach (uint item in accessGroupIDList)
            {
                Marshal.WriteInt32(curAccessGroupIDObj, (int)item);
                curAccessGroupIDObj = (nint)((long)curAccessGroupIDObj + 4);
            }

            BS2ErrorCode result = (BS2ErrorCode)BS2_RemoveAccessGroup(Context, deviceID, accessGroupIDObj, (uint)accessGroupIDList.Count);
            
            logger.LogInformation("{result}", result);

            Marshal.FreeHGlobal(accessGroupIDObj);

            return result;
        }

        #endregion

        #region Access Level

        public ICollection<BS2AccessLevel> GetAllAccessLevel(uint deviceID)
        {
            ICollection<BS2AccessLevel> accessLevels = [];
            BS2ErrorCode result = (BS2ErrorCode)BS2_GetAllAccessLevel(Context, deviceID, out nint accessLevelObj, out uint numAccessLevel);

            if (result.Equals(BS2ErrorCode.BS_SDK_SUCCESS))
            {
                if (numAccessLevel > 0)
                {
                    nint curAccessLevelObj = accessLevelObj;
                    int structSize = Marshal.SizeOf(typeof(BS2AccessLevel));

                    for (int idx = 0; idx < numAccessLevel; ++idx)
                    {
                        BS2AccessLevel item = (BS2AccessLevel)Marshal.PtrToStructure(curAccessLevelObj, typeof(BS2AccessLevel));
                        accessLevels.Add(item);
                        curAccessLevelObj = (nint)((long)curAccessLevelObj + structSize);
                    }

                    BS2_ReleaseObject(accessLevelObj);
                }
            }

            return accessLevels;
        }

        public BS2ErrorCode SetAccessLevel(uint deviceID, ICollection<BS2AccessLevel> accessLevelList)
        {
            int structSize = Marshal.SizeOf(typeof(BS2AccessLevel));
            nint accessLevelListObj = Marshal.AllocHGlobal(structSize * accessLevelList.Count);
            nint curAccessLevelListObj = accessLevelListObj;
            foreach (BS2AccessLevel item in accessLevelList)
            {
                Marshal.StructureToPtr(item, curAccessLevelListObj, false);
                curAccessLevelListObj = (nint)((long)curAccessLevelListObj + structSize);
            }
            
            BS2ErrorCode result = (BS2ErrorCode)BS2_SetAccessLevel(Context, deviceID, accessLevelListObj, (uint)accessLevelList.Count);

            logger.LogInformation("{result}", result);

            Marshal.FreeHGlobal(accessLevelListObj);

            return result;
        }

        public BS2ErrorCode RemoveAccessLevel(uint deviceID, ICollection<uint> accessLevelIDList)
        {
            nint accessLevelIDObj = Marshal.AllocHGlobal(4 * accessLevelIDList.Count);
            nint curAccessLevelIDObj = accessLevelIDObj;
            foreach (uint item in accessLevelIDList)
            {
                Marshal.WriteInt32(curAccessLevelIDObj, (int)item);
                curAccessLevelIDObj = (nint)((long)curAccessLevelIDObj + 4);
            }

            BS2ErrorCode result = (BS2ErrorCode)BS2_RemoveAccessLevel(Context, deviceID, accessLevelIDObj, (uint)accessLevelIDList.Count);

            logger.LogInformation("{result}", result);

            Marshal.FreeHGlobal(accessLevelIDObj);

            return result;
        }

        #endregion

        #region Access Schedule
        public ICollection<CSP_BS2Schedule> GetAllAccessSchedule(uint deviceID)
        {
            ICollection<CSP_BS2Schedule> schedules = [];
            BS2ErrorCode result = CSP_BS2_GetAllAccessSchedule(Context, deviceID, out CSP_BS2Schedule[] accessScheduleObj, out uint numAccessSchedule);

            if (result.Equals(BS2ErrorCode.BS_SDK_SUCCESS))
            {
                if (numAccessSchedule > 0)
                {
                    for (int idx = 0; idx < numAccessSchedule; ++idx)
                    {
                        schedules.Add(accessScheduleObj[idx]);
                    }
                }
            }

            return schedules;
        }

        public BS2ErrorCode SetAccessSchedule(uint deviceID, ICollection<CSP_BS2Schedule> accessScheduleList)
        {
            int structSize = Marshal.SizeOf(typeof(CSP_BS2Schedule));
            nint accessScheduleListObj = Marshal.AllocHGlobal(structSize * accessScheduleList.Count);
            nint curAccessScheduleListObj = accessScheduleListObj;
            foreach (CSP_BS2Schedule item in accessScheduleList)
            {
                Marshal.StructureToPtr(item, curAccessScheduleListObj, false);
                curAccessScheduleListObj = (nint)((long)curAccessScheduleListObj + structSize);
            }

            BS2ErrorCode result = (BS2ErrorCode)BS2_SetAccessSchedule(Context, deviceID, accessScheduleListObj, (uint)accessScheduleList.Count);

            logger.LogInformation("{result}", result);

            Marshal.FreeHGlobal(accessScheduleListObj);

            return result;
        }

        public BS2ErrorCode RemoveAccessSchedule(uint deviceID, ICollection<uint> accessScheduleIDList)
        {
            nint accessScheduleIDObj = Marshal.AllocHGlobal(4 * accessScheduleIDList.Count);
            nint curAccessScheduleIDObj = accessScheduleIDObj;
            foreach (uint item in accessScheduleIDList)
            {
                Marshal.WriteInt32(curAccessScheduleIDObj, (int)item);
                curAccessScheduleIDObj = (nint)((long)curAccessScheduleIDObj + 4);
            }

            BS2ErrorCode result = (BS2ErrorCode)BS2_RemoveAccessSchedule(Context, deviceID, accessScheduleIDObj, (uint)accessScheduleIDList.Count);

            logger.LogInformation("{result}", result);

            Marshal.FreeHGlobal(accessScheduleIDObj);

            return result;
        }

        #endregion

        #region Holiday Group

        public ICollection<BS2HolidayGroup> GetAllHolidayGroup(uint deviceID)
        {
            ICollection<BS2HolidayGroup> holidayGroups = [];

            BS2ErrorCode result = (BS2ErrorCode)BS2_GetAllHolidayGroup(Context, deviceID, out nint holidayGroupObj, out uint numHolidayGroup);

            if (result.Equals(BS2ErrorCode.BS_SDK_SUCCESS))
            {
                if (numHolidayGroup > 0)
                {
                    nint curHolidayGroupObj = holidayGroupObj;
                    int structSize = Marshal.SizeOf(typeof(BS2HolidayGroup));

                    for (int idx = 0; idx < numHolidayGroup; ++idx)
                    {
                        BS2HolidayGroup item = (BS2HolidayGroup)Marshal.PtrToStructure(curHolidayGroupObj, typeof(BS2HolidayGroup));
                        holidayGroups.Add(item);
                        curHolidayGroupObj = (nint)((long)curHolidayGroupObj + structSize);
                    }

                    BS2_ReleaseObject(holidayGroupObj);
                }
            }

            return holidayGroups;
        }

        public BS2ErrorCode SetHolidayGroup(uint deviceID, ICollection<BS2HolidayGroup> holidayGroupList)
        {

            int structSize = Marshal.SizeOf(typeof(BS2HolidayGroup));
            nint holidayGroupListObj = Marshal.AllocHGlobal(structSize * holidayGroupList.Count);
            nint curHolidayGroupListObj = holidayGroupListObj;
            foreach (BS2HolidayGroup item in holidayGroupList)
            {
                Marshal.StructureToPtr(item, curHolidayGroupListObj, false);
                curHolidayGroupListObj = (nint)((long)curHolidayGroupListObj + structSize);
            }

            BS2ErrorCode result = (BS2ErrorCode)BS2_SetHolidayGroup(Context, deviceID, holidayGroupListObj, (uint)holidayGroupList.Count);

            logger.LogInformation("{result}", result);

            Marshal.FreeHGlobal(holidayGroupListObj);

            return result;
        }

        public BS2ErrorCode RemoveHolidayGroup(uint deviceID, ICollection<uint> holidayGroupIDList)
        {
            nint holidayGroupIDObj = Marshal.AllocHGlobal(4 * holidayGroupIDList.Count);
            nint curHolidayGroupIDObj = holidayGroupIDObj;
            foreach (uint item in holidayGroupIDList)
            {
                Marshal.WriteInt32(curHolidayGroupIDObj, (int)item);
                curHolidayGroupIDObj = (nint)((long)curHolidayGroupIDObj + 4);
            }

            BS2ErrorCode result = (BS2ErrorCode)BS2_RemoveHolidayGroup(Context, deviceID, holidayGroupIDObj, (uint)holidayGroupIDList.Count);

            logger.LogInformation("{result}", result);

            Marshal.FreeHGlobal(holidayGroupIDObj);

            return result;
        }

        #endregion
    }
}
