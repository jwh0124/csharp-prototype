using Microsoft.Extensions.Logging;
using SupremaSDK.Libs;
using System.Runtime.InteropServices;
using System.Text;
using static SupremaSDK.Libs.API;

namespace SupremaSDK.Managements
{
    public class UserManagement
    {
        private readonly ILogger<UserManagement> logger;
        private readonly nint Context;
        private const int USER_PAGE_SIZE = 1024;

        public UserManagement(ILogger<UserManagement> logger, ConnectionManager connectionManager)
        {
            this.logger = logger;
            Context = connectionManager.Context;
        }

        public ICollection<BS2User> GetUserList(uint deviceID)
        {
            ICollection<BS2User> userList = new HashSet<BS2User>();
            IsAcceptableUserID cbIsAcceptableUserID = null;

            BS2ErrorCode result = (BS2ErrorCode)BS2_GetUserList(Context, deviceID, out IntPtr outUidList, out uint numUserIds, cbIsAcceptableUserID);
            if (result == BS2ErrorCode.BS_SDK_SUCCESS)
            {
                if (numUserIds > 0)
                {
                    nint curUidList = outUidList;
                    BS2UserBlob[] userBlobs = new BS2UserBlob[USER_PAGE_SIZE];

                    for (uint idx = 0; idx < numUserIds;)
                    {
                        uint available = numUserIds - idx;
                        if (available > USER_PAGE_SIZE)
                        {
                            available = USER_PAGE_SIZE;
                        }

                        result = (BS2ErrorCode)BS2_GetUserDatas(Context, deviceID, curUidList, available, userBlobs, (uint)BS2UserMaskEnum.DATA);
                        if (result == BS2ErrorCode.BS_SDK_SUCCESS)
                        {
                            for (uint loop = 0; loop < available; ++loop)
                            {
                                userList.Add(userBlobs[loop].user);
                            }

                            idx += available;
                            curUidList += (int)available * BS2Environment.BS2_USER_ID_SIZE;
                        }
                        else
                        {
                            logger.LogInformation("{result}", result);
                            break;
                        }
                    }

                    BS2_ReleaseObject(outUidList);
                }
            }
            else
            {
                logger.LogInformation("{result}", result);
            }

            return userList;
        }

        public BS2UserBlobEx[] GetUser(uint deviceID, string userID)
        {
            BS2UserBlobEx[] userBlobs = new BS2UserBlobEx[1];

            byte[] uidArray = new byte[BS2Environment.BS2_USER_ID_SIZE];
            byte[] uidByte = Encoding.UTF8.GetBytes(userID);
            nint uid = Marshal.AllocHGlobal(BS2Environment.BS2_USER_ID_SIZE);

            Array.Clear(uidArray, 0, BS2Environment.BS2_USER_ID_SIZE);
            Array.Copy(uidByte, 0, uidArray, 0, uidByte.Length);
            Marshal.Copy(uidArray, 0, uid, uidArray.Length);

            BS2ErrorCode result = (BS2ErrorCode)BS2_GetUserDatasEx(Context, deviceID, uid, 1, userBlobs, (uint)BS2UserMaskEnum.ALL);

            logger.LogInformation("{result}", result);

            Marshal.FreeHGlobal(uid);

            return userBlobs;
        }

        public void RegisterUser(uint deviceID, BS2UserBlobEx[] userBlobs)
        {
            BS2ErrorCode registeredUserResult = (BS2ErrorCode)BS2_EnrollUserEx(Context, deviceID, userBlobs, 1, 1);

            if (userBlobs[0].cardObjs != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(userBlobs[0].cardObjs);
            }
            if (userBlobs[0].faceObjs != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(userBlobs[0].faceObjs);
            }
            if (userBlobs[0].fingerObjs != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(userBlobs[0].fingerObjs);
            }

            logger.LogInformation("{result}", registeredUserResult);
        }

        public void RemoveUser(uint deviceID, string userID)
        {
            byte[] uidArray = new byte[BS2Environment.BS2_USER_ID_SIZE];
            byte[] rawUid = Encoding.UTF8.GetBytes(userID);
            nint uid = Marshal.AllocHGlobal(BS2Environment.BS2_USER_ID_SIZE);

            Array.Clear(uidArray, 0, BS2Environment.BS2_USER_ID_SIZE);
            Array.Copy(rawUid, 0, uidArray, 0, rawUid.Length);
            Marshal.Copy(uidArray, 0, uid, BS2Environment.BS2_USER_ID_SIZE);

            BS2ErrorCode result = (BS2ErrorCode)BS2_RemoveUser(Context, deviceID, uid, 1);

            Marshal.FreeHGlobal(uid);

            logger.LogInformation("{result}",result);
        }

        public void RemoveAllUser(uint deviceID)
        {
            BS2ErrorCode result = (BS2ErrorCode)BS2_RemoveAllUser(Context, deviceID);

            logger.LogInformation("{result}", result);
        }
    }
}
