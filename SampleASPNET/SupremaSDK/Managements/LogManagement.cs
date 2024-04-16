using Microsoft.Extensions.Logging;
using SupremaSDK.Libs;
using System.Runtime.InteropServices;
using static SupremaSDK.Libs.API;

namespace SupremaSDK.Managements
{
    public class LogManagement
    {
        private readonly ILogger<LogManagement> logger;
        private readonly nint Context;

        public LogManagement(ILogger<LogManagement> logger, ConnectionManager connectionManager)
        {
            this.logger = logger;
            Context = connectionManager.Context;
        }

        public ICollection<BS2Event> GetLogList(uint deviceID, uint lastEventID)
        {
            ICollection<BS2Event> logList = [];
            uint amount = 100;
            BS2ErrorCode result = (BS2ErrorCode)BS2_GetLog(Context, deviceID, lastEventID, amount, out nint eventLogObjs, out uint outNumEventLogs);
            if (result.Equals(BS2ErrorCode.BS_SDK_SUCCESS))
            {
                if(outNumEventLogs > 0)
                {
                    nint curEventLogObjs = eventLogObjs;
                    int structSize = Marshal.SizeOf(typeof(BS2Event));

                    for (uint idx = 0; idx < outNumEventLogs; idx++)
                    {
                        BS2Event eventLog = (BS2Event)Marshal.PtrToStructure(curEventLogObjs, typeof(BS2Event));

                        logList.Add(eventLog);

                        curEventLogObjs += structSize;
                    }

                    BS2_ReleaseObject(eventLogObjs);
                }
            }

            return logList;
        }

        public BS2ErrorCode ClearLog(uint deviceID)
        {
            BS2ErrorCode result = (BS2ErrorCode)API.BS2_ClearLog(Context, deviceID);

            logger.LogInformation("{result}", result);

            return result;
        }
    }
}
