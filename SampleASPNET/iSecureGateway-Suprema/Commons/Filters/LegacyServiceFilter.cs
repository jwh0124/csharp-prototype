using iSecureGateway_Suprema.Commons.Enums;
using System;
using System.ComponentModel;

namespace iSecureGateway_Suprema.Commons.Filters
{
    public static class LegacyServiceFilter
    {
        public static bool IncludeLegacyService(object serviceName)
        {    
            return Enum.IsDefined(typeof(ServiceEventType), serviceName);
        }

        public static ServiceEventType GetLegacyServiceName(object serviceName)
        {
            if (!Enum.IsDefined(typeof(ServiceEventType), serviceName))
                return ServiceEventType.UnknownService;

            return (ServiceEventType)Enum.Parse(typeof(ServiceEventType), (string)serviceName);
        }

        public enum ServiceEventType
        {
            UnknownService,
            AddAccessGroup, DeleteAccessGroup, UpdateAccessGroup, SyncAccessGroup,
            AddAccessLevel, DeleteAccessLevel, UpdateAccessLevel, SyncAccessLevel,
            AddScheduleGroup, DeleteScheduleGroup, UpdateScheduleGroup, SyncScheduleGroup,
            AddDoorSchedule, DeleteDoorSchedule, UpdateDoorSchedule, SyncDoorSchedule,
            AddHrinfo, DeleteHrinfo, UpdateHrinfo, SyncHrinfo,
            AddCard, DeleteCard, UpdateCard,
            OneDoorOpen, OneDoorClose, OneDoorLockDown, OneDoorUnLockDown,
            AllDoorOpen, AllDoorClose, AllDoorLockDown, AllDoorUnLockDown,
            DeviceDoorOpen, DeviceDoorClose, DeviceDoorLockDown, DeviceDoorUnLockDown,
        }

        public enum ProcessStatus
        {
            [Description("Enroll")]
            ENROLL = 0,

            [Description("Progress")]
            PROGRESS = 1,

            [Description("Finish")]
            FINISH = 2,
        }
    }
}
