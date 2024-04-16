using System.Runtime.InteropServices;

namespace SupremaSDK.Libs
{
    using BS2_CONFIG_MASK = UInt32;
    using BS2_SCHEDULE_ID = UInt32;
    using BS2_USER_MASK = UInt32;

    public static class API
    {
        public static Dictionary<BS2DeviceTypeEnum, string> productNameDictionary = new Dictionary<BS2DeviceTypeEnum, string>()
        {
            {BS2DeviceTypeEnum.UNKNOWN,         "Unknown Device"},
            {BS2DeviceTypeEnum.BIOENTRY_PLUS,   "BioEntry Plus"},
            {BS2DeviceTypeEnum.BIOENTRY_W,      "BioEntry W"},
            {BS2DeviceTypeEnum.BIOLITE_NET,     "BioLite Net"},
            {BS2DeviceTypeEnum.XPASS,           "Xpass"},
            {BS2DeviceTypeEnum.XPASS_S2,        "Xpass S2"},
            {BS2DeviceTypeEnum.SECURE_IO_2,     "Secure IO 2"},
            {BS2DeviceTypeEnum.DOOR_MODULE_20,  "Door module 20"},
            {BS2DeviceTypeEnum.BIOSTATION_2,    "BioStation 2"},
            {BS2DeviceTypeEnum.BIOSTATION_A2,   "BioStation A2"},
            {BS2DeviceTypeEnum.FACESTATION_2,   "FaceStation 2"},
            {BS2DeviceTypeEnum.IO_DEVICE,       "IO device"},
            {BS2DeviceTypeEnum.BIOSTATION_L2,   "BioStation L2"},
            {BS2DeviceTypeEnum.BIOENTRY_W2,     "BioEntry W2"},
            //{BS2DeviceTypeEnum.CORESTATION,     "CoreStation" },		// Deprecated 2.6.0
            {BS2DeviceTypeEnum.CORESTATION_40,  "CoreStation40" },
            {BS2DeviceTypeEnum.OUTPUT_MODULE,   "Output Module"},
            {BS2DeviceTypeEnum.INPUT_MODULE,    "Inout Module"},
            {BS2DeviceTypeEnum.BIOENTRY_P2,     "BioEntry P2"},
            {BS2DeviceTypeEnum.BIOLITE_N2,      "BioLite N2"},
            {BS2DeviceTypeEnum.XPASS2,          "XPass 2"},
            {BS2DeviceTypeEnum.XPASS_S3,        "XPass S3"},
            {BS2DeviceTypeEnum.BIOENTRY_R2,     "BioEntry R2"},
            {BS2DeviceTypeEnum.XPASS_D2,        "XPass D2"},
            {BS2DeviceTypeEnum.DOOR_MODULE_21,  "DoorModule 21"},
            {BS2DeviceTypeEnum.XPASS_D2_KEYPAD, "XPass D2 Keypad"},
            {BS2DeviceTypeEnum.FACELITE,        "FaceLite"},
            {BS2DeviceTypeEnum.XPASS2_KEYPAD,   "XPass 2 Keypad"},
            {BS2DeviceTypeEnum.XPASS_D2_REV,    "XPass D2 Rev"},
            {BS2DeviceTypeEnum.XPASS_D2_KEYPAD_REV, "XPass D2 Keypad Rev"},
            {BS2DeviceTypeEnum.FACESTATION_F2_FP, "FaceStation F2 FP"},     // FSF2 support
            {BS2DeviceTypeEnum.FACESTATION_F2,  "FaceStation F2"},          // FSF2 support
            {BS2DeviceTypeEnum.XSTATION_2_QR,   "X-Station 2 QR"},
            {BS2DeviceTypeEnum.XSTATION_2,      "X-Station 2"},
            {BS2DeviceTypeEnum.IM_120,         "Input Module 120"},
            {BS2DeviceTypeEnum.XSTATION_2_FP,   "X-Station 2 FP"},
            {BS2DeviceTypeEnum.BIOSTATION_3,    "BioStation 3"},
            {BS2DeviceTypeEnum.THIRD_OSDP_DEVICE, "3rd party OSDP"},
            {BS2DeviceTypeEnum.THIRD_OSDP_IO_DEVICE, "3rd party OSDP IO"},
            {BS2DeviceTypeEnum.BIOSTATION_2A,   "BioStation 2A"},
        };

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnDeviceFound(BS2_CONFIG_MASK deviceId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnDeviceAccepted(BS2_CONFIG_MASK deviceId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnDeviceConnected(BS2_CONFIG_MASK deviceId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnDeviceDisconnected(BS2_CONFIG_MASK deviceId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnReadyToScan(BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK sequence);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnProgressChanged(BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK progressPercentage);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnLogReceived(BS2_CONFIG_MASK deviceId, nint log);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnLogReceivedEx(BS2_CONFIG_MASK deviceId, nint log, BS2_CONFIG_MASK temperature);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnAlarmFired(BS2_CONFIG_MASK deviceId, nint log);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnInputDetected(BS2_CONFIG_MASK deviceId, nint log);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnConfigChanged(BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK configMask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnBarcodeScanned(BS2_CONFIG_MASK deviceId, string barcode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnVerifyUser(BS2_CONFIG_MASK deviceId, ushort seq, byte isCard, byte cardType, nint data, BS2_CONFIG_MASK dataLen);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnIdentifyUser(BS2_CONFIG_MASK deviceId, ushort seq, byte format, nint templateData, BS2_CONFIG_MASK templateSize);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnUserPhrase(BS2_CONFIG_MASK deviceId, ushort seq, string userID);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnOsdpStandardDeviceStatusChanged(BS2_CONFIG_MASK deviceId, nint notifyData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int IsAcceptableUserID(string uid);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate BS2_CONFIG_MASK PreferMethod(BS2_CONFIG_MASK deviceID);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        //public delegate string GetRootCaFilePath(UInt32 deviceID);
        public delegate nint GetRootCaFilePath(BS2_CONFIG_MASK deviceID);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        //public delegate string GetServerCaFilePath(UInt32 deviceID);
        public delegate nint GetServerCaFilePath(BS2_CONFIG_MASK deviceID);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        //public delegate string GetServerPrivateKeyFilePath(UInt32 deviceID);
        public delegate nint GetServerPrivateKeyFilePath(BS2_CONFIG_MASK deviceID);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        //public delegate string GetPassword(UInt32 deviceID);
        public delegate nint GetPassword(BS2_CONFIG_MASK deviceID);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnErrorOccured(BS2_CONFIG_MASK deviceID, int errCode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnSendRootCA(int result);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnCheckGlobalAPBViolation(BS2_CONFIG_MASK deviceId, ushort seq, string userID_1, string userID_2, bool isDualAuth);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnCheckGlobalAPBViolationByDoorOpen(BS2_CONFIG_MASK deviceId, ushort seq, string userID_1, string userID_2, bool isDualAuth);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnUpdateGlobalAPBViolationByDoorOpen(BS2_CONFIG_MASK deviceId, ushort seq, string userID_1, string userID_2, bool isDualAuth);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static nint BS2_AllocateContext();

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_Initialize(nint context);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDeviceSearchingTimeout(nint context, BS2_CONFIG_MASK second);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetMaxThreadCount(nint context, BS2_CONFIG_MASK maxThreadCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_IsAutoConnection(nint context, ref int enable);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetAutoConnection(nint context, int enable);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDeviceEventListener(nint context, OnDeviceFound cbOnDeviceFound, OnDeviceAccepted cbOnDeviceAccepted, OnDeviceConnected cbOnDeviceConnected, OnDeviceDisconnected cbOnDeviceDisconnected);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetNotificationListener(nint context, OnAlarmFired cbOnAlarmFired, OnInputDetected cbOnInputDetected, OnConfigChanged cbOnConfigChanged);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetBarcodeScanListener(nint context, OnBarcodeScanned cbOnBarcodeScanned);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static void BS2_ReleaseContext(nint context);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static void BS2_ReleaseObject(nint obj);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetSSLHandler(nint context, PreferMethod cbPreferMethod, GetRootCaFilePath cbGetRootCaFilePath, GetServerCaFilePath cbGetServerCaFilePath, GetServerPrivateKeyFilePath cbGetServerPrivateKeyFilePath, GetPassword cbGetPassword, OnErrorOccured cbOnErrorOccured);

        [DllImport("BS_SDK_V2.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetServerPort(nint context, ushort serverPort);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SearchDevices(nint context);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_SearchDevicesEx(IntPtr context, string hostipAddr);
        extern public static int BS2_SearchDevicesEx(nint context, nint hostipAddr);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDevices(nint context, out nint deviceListObj, out BS2_CONFIG_MASK numDevice);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDeviceInfo(nint context, BS2_CONFIG_MASK deviceId, out BS2SimpleDeviceInfo deviceInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDeviceInfoEx(nint context, BS2_CONFIG_MASK deviceId, out BS2SimpleDeviceInfo deviceInfo, out BS2SimpleDeviceInfoEx deviceInfoEx);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ConnectDevice(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_ConnectDeviceViaIP(IntPtr context, string deviceAddress, UInt16 devicePort, out UInt32 deviceId);
        extern public static int BS2_ConnectDeviceViaIP(nint context, nint deviceAddress, ushort devicePort, out BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_DisconnectDevice(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDeviceTopology(nint context, BS2_CONFIG_MASK deviceId, out nint networkNodeObj, out BS2_CONFIG_MASK numNetworkNode);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDeviceTopology(nint context, BS2_CONFIG_MASK deviceId, nint networkNode, BS2_CONFIG_MASK numNetworkNode);


        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< AccessControl API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAccessGroup(nint context, BS2_CONFIG_MASK deviceId, nint accessGroupIds, BS2_CONFIG_MASK accessGroupIdCount, out nint accessGroupObj, out BS2_CONFIG_MASK numAccessGroup);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllAccessGroup(nint context, BS2_CONFIG_MASK deviceId, out nint accessGroupObj, out BS2_CONFIG_MASK numAccessGroup);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetAccessGroup(nint context, BS2_CONFIG_MASK deviceId, nint accessGroups, BS2_CONFIG_MASK accessGroupCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAccessGroup(nint context, BS2_CONFIG_MASK deviceId, nint accessGroupIds, BS2_CONFIG_MASK accessGroupIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllAccessGroup(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAccessLevel(nint context, BS2_CONFIG_MASK deviceId, nint accessLevelIds, BS2_CONFIG_MASK accessLevelIdCount, out nint accessLevelObj, out BS2_CONFIG_MASK numAccessLevel);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllAccessLevel(nint context, BS2_CONFIG_MASK deviceId, out nint accessLevelObj, out BS2_CONFIG_MASK numAccessLevel);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetAccessLevel(nint context, BS2_CONFIG_MASK deviceId, nint accessLevels, BS2_CONFIG_MASK accessLevelCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAccessLevel(nint context, BS2_CONFIG_MASK deviceId, nint accessLevelIds, BS2_CONFIG_MASK accessLevelIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllAccessLevel(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAccessSchedule(nint context, BS2_CONFIG_MASK deviceId, nint accessScheduleIds, BS2_CONFIG_MASK accessScheduleIdCount, out nint accessScheduleObj, out BS2_CONFIG_MASK numAccessSchedule);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllAccessSchedule(nint context, BS2_CONFIG_MASK deviceId, out nint accessScheduleObj, out BS2_CONFIG_MASK numAccessSchedule);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetAccessSchedule(nint context, BS2_CONFIG_MASK deviceId, nint accessSchedules, BS2_CONFIG_MASK accessScheduleCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAccessSchedule(nint context, BS2_CONFIG_MASK deviceId, nint accessScheduleIds, BS2_CONFIG_MASK accessScheduleIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllAccessSchedule(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetHolidayGroup(nint context, BS2_CONFIG_MASK deviceId, nint holidayGroupIds, BS2_CONFIG_MASK holidayGroupIdCount, out nint holidayGroupObj, out BS2_CONFIG_MASK numHolidayGroup);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllHolidayGroup(nint context, BS2_CONFIG_MASK deviceId, out nint holidayGroupObj, out BS2_CONFIG_MASK numHolidayGroup);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetHolidayGroup(nint context, BS2_CONFIG_MASK deviceId, nint holidayGroups, BS2_CONFIG_MASK holidayGroupCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveHolidayGroup(nint context, BS2_CONFIG_MASK deviceId, nint holidayGroupIds, BS2_CONFIG_MASK holidayGroupIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllHolidayGroup(nint context, BS2_CONFIG_MASK deviceId);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Blacklist API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetBlackList(nint context, BS2_CONFIG_MASK deviceId, nint blacklists, BS2_CONFIG_MASK blacklistCount, out nint blacklistObj, out BS2_CONFIG_MASK numBlacklist);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllBlackList(nint context, BS2_CONFIG_MASK deviceId, out nint blacklistObj, out BS2_CONFIG_MASK numBlacklist);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetBlackList(nint context, BS2_CONFIG_MASK deviceId, nint blacklists, BS2_CONFIG_MASK blacklistCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveBlackList(nint context, BS2_CONFIG_MASK deviceId, nint blacklists, BS2_CONFIG_MASK blacklistCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllBlackList(nint context, BS2_CONFIG_MASK deviceId);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Card API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ScanCard(nint context, BS2_CONFIG_MASK deviceId, out BS2Card card, OnReadyToScan cbReadyToScan);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_WriteCard(nint context, BS2_CONFIG_MASK deviceId, ref BS2SmartCardData smartCard);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_EraseCard(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_WriteQRCode(nint qrText, ref BS2CSNCard card);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Config API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ClearDatabase(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ResetConfig(nint context, BS2_CONFIG_MASK deviceId, [MarshalAs(UnmanagedType.I1)] bool includingDB);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ResetConfigExceptNetInfo(nint context, BS2_CONFIG_MASK deviceId, [MarshalAs(UnmanagedType.I1)] bool includingDB);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2Configs configs);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2Configs configs);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetFactoryConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2FactoryConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetSystemConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2SystemConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetSystemConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2SystemConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAuthConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2AuthConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetAuthConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2AuthConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAuthConfigExt(nint context, BS2_CONFIG_MASK deviceId, out BS2AuthConfigExt config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetAuthConfigExt(nint context, BS2_CONFIG_MASK deviceId, ref BS2AuthConfigExt config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetFaceConfigExt(nint context, BS2_CONFIG_MASK deviceId, out BS2FaceConfigExt config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetFaceConfigExt(nint context, BS2_CONFIG_MASK deviceId, ref BS2FaceConfigExt config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetThermalCameraConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2ThermalCameraConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetThermalCameraConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2ThermalCameraConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetBarcodeConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2BarcodeConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetBarcodeConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2BarcodeConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetInputConfigEx(nint context, BS2_CONFIG_MASK deviceId, out BS2InputConfigEx config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetInputConfigEx(nint context, BS2_CONFIG_MASK deviceId, ref BS2InputConfigEx config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetRelayActionConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2RelayActionConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetRelayActionConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2RelayActionConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetStatusConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2StatusConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetStatusConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2StatusConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDisplayConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2DisplayConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDisplayConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2DisplayConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetIPConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2IpConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetIPConfigExt(nint context, BS2_CONFIG_MASK deviceId, out BS2IpConfigExt config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetIPConfigViaUDP(nint context, BS2_CONFIG_MASK deviceId, out BS2IpConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetIPConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2IpConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetIPConfigExt(nint context, BS2_CONFIG_MASK deviceId, ref BS2IpConfigExt config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetIPConfigViaUDP(nint context, BS2_CONFIG_MASK deviceId, ref BS2IpConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetTNAConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2TNAConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetTNAConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2TNAConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetCardConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2CardConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetCardConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2CardConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetFingerprintConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2FingerprintConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetFingerprintConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2FingerprintConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetRS485Config(nint context, BS2_CONFIG_MASK deviceId, out BS2Rs485Config config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetRS485Config(nint context, BS2_CONFIG_MASK deviceId, ref BS2Rs485Config config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetWiegandConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2WiegandConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetWiegandConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2WiegandConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetWiegandDeviceConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2WiegandDeviceConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetWiegandDeviceConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2WiegandDeviceConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetInputConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2InputConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetInputConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2InputConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetWlanConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2WlanConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetWlanConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2WlanConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetTriggerActionConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2TriggerActionConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetTriggerActionConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2TriggerActionConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetEventConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2EventConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetEventConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2EventConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetWiegandMultiConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2WiegandMultiConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetWiegandMultiConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2WiegandMultiConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetCard1xConfig(nint context, BS2_CONFIG_MASK deviceId, out BS1CardConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetCard1xConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS1CardConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetSystemExtConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2SystemConfigExt config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetSystemExtConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2SystemConfigExt config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetVoipConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2VoipConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetVoipConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2VoipConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetFaceConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2FaceConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetFaceConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2FaceConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetCardConfigEx(nint context, BS2_CONFIG_MASK deviceId, out BS2CardConfigEx config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetCardConfigEx(nint context, BS2_CONFIG_MASK deviceId, ref BS2CardConfigEx config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetCustomCardConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2CustomCardConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetCustomCardConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2CustomCardConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetRS485ConfigEx(nint context, BS2_CONFIG_MASK deviceId, out BS2Rs485ConfigEX config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetRS485ConfigEx(nint context, BS2_CONFIG_MASK deviceId, ref BS2Rs485ConfigEX config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDstConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2DstConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDstConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2DstConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDesFireCardConfigEx(nint context, BS2_CONFIG_MASK deviceId, out BS2DesFireCardConfigEx config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDesFireCardConfigEx(nint context, BS2_CONFIG_MASK deviceId, ref BS2DesFireCardConfigEx config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetVoipConfigExt(nint context, BS2_CONFIG_MASK deviceId, out BS2VoipConfigExt config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetVoipConfigExt(nint context, BS2_CONFIG_MASK deviceId, ref BS2VoipConfigExt config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetRtspConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2RtspConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetRtspConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2RtspConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetOsdpStandardConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2OsdpStandardConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetOsdpStandardConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2OsdpStandardConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetOsdpStandardActionConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2OsdpStandardActionConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetOsdpStandardActionConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2OsdpStandardActionConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLicenseConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2LicenseConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_AddOsdpStandardDevice(nint context, BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK channelIndex, ref BS2OsdpStandardDeviceAdd osdpDevice, out BS2_CONFIG_MASK osdpChannelIndex);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetOsdpStandardDevice(nint context, BS2_CONFIG_MASK osdpDeviceId, out BS2OsdpStandardDevice osdpDevice);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_UpdateOsdpStandardDevice(nint context, BS2_CONFIG_MASK deviceId, nint osdpDevices, BS2_CONFIG_MASK numOfDevice, out nint outResultObj, out BS2_CONFIG_MASK outNumOfResult);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveOsdpStandardDevice(nint context, BS2_CONFIG_MASK deviceId, nint osdpDeviceIds, BS2_CONFIG_MASK numOfDevice, out nint outResultObj, out BS2_CONFIG_MASK outNumOfResult);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetOsdpStandardDeviceCapability(nint context, BS2_CONFIG_MASK osdpDeviceId, out BS2OsdpStandardDeviceCapability capability);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetOsdpStandardDeviceSecurityKey(nint context, BS2_CONFIG_MASK masterOrSlaveId, nint key);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetOsdpStandardDeviceStatusListener(nint context, OnOsdpStandardDeviceStatusChanged ptrOsdpStandardDeviceStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetOsdpStandardAvailableID(nint context, BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK channelIndex, out BS2_CONFIG_MASK osdpDeviceID);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAvailableOsdpStandardDevice(nint context, BS2_CONFIG_MASK deviceId, out BS2OsdpStandardDeviceAvailable osdpDevices);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_EnableDeviceLicense(nint context, BS2_CONFIG_MASK deviceId, ref BS2LicenseBlob licenseBlob, out nint licenseResultObj, out BS2_CONFIG_MASK outNumOfResult);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_DisableDeviceLicense(nint context, BS2_CONFIG_MASK deviceId, ref BS2LicenseBlob licenseBlob, out nint licenseResultObj, out BS2_CONFIG_MASK outNumOfResult);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_QueryDeviceLicense(nint context, BS2_CONFIG_MASK deviceId, ushort licenseType, out nint licenseResultObj, out BS2_CONFIG_MASK outNumOfResult);
        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Door API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDoor(nint context, BS2_CONFIG_MASK deviceId, nint doorIds, BS2_CONFIG_MASK doorIdCount, out nint doorObj, out BS2_CONFIG_MASK numDoor);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllDoor(nint context, BS2_CONFIG_MASK deviceId, out nint doorObj, out BS2_CONFIG_MASK numDoor);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDoorStatus(nint context, BS2_CONFIG_MASK deviceId, nint doorIds, BS2_CONFIG_MASK doorIdCount, out nint doorStatusObj, out BS2_CONFIG_MASK numDoorStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllDoorStatus(nint context, BS2_CONFIG_MASK deviceId, out nint doorStatusObj, out BS2_CONFIG_MASK numDoorStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDoor(nint context, BS2_CONFIG_MASK deviceId, nint doors, BS2_CONFIG_MASK doorCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDoorAlarm(nint context, BS2_CONFIG_MASK deviceId, byte flag, nint doorIds, BS2_CONFIG_MASK doorIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveDoor(nint context, BS2_CONFIG_MASK deviceId, nint doors, BS2_CONFIG_MASK doorCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllDoor(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ReleaseDoor(nint context, BS2_CONFIG_MASK deviceId, byte flag, nint doorIds, BS2_CONFIG_MASK doorIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_LockDoor(nint context, BS2_CONFIG_MASK deviceId, byte flag, nint doorIds, BS2_CONFIG_MASK doorIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_UnlockDoor(nint context, BS2_CONFIG_MASK deviceId, byte flag, nint doorIds, BS2_CONFIG_MASK doorIdCount);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Fingerprint API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLastFingerprintImage(nint context, BS2_CONFIG_MASK deviceId, out nint imageObj, out BS2_CONFIG_MASK imageWidth, out BS2_CONFIG_MASK imageHeight);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ScanFingerprint(nint context, BS2_CONFIG_MASK deviceId, ref BS2Fingerprint finger, BS2_CONFIG_MASK templateIndex, BS2_CONFIG_MASK quality, byte templateFormat, OnReadyToScan cbReadyToScan);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ScanFingerprintEx(nint context, BS2_CONFIG_MASK deviceId, ref BS2Fingerprint finger, BS2_CONFIG_MASK templateIndex, BS2_CONFIG_MASK quality, byte templateFormat, out BS2_CONFIG_MASK outquality, OnReadyToScan cbReadyToScan);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_VerifyFingerprint(nint context, BS2_CONFIG_MASK deviceId, ref BS2Fingerprint finger);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetFingerTemplateQuality(nint templateBuffer, BS2_CONFIG_MASK templateSize, out int score);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Log API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLog(nint context, BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK eventId, BS2_CONFIG_MASK amount, out nint logObjs, out BS2_CONFIG_MASK numLog);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetFilteredLog(nint context, BS2_CONFIG_MASK deviceId, nint uid, ushort eventCode, BS2_CONFIG_MASK start, BS2_CONFIG_MASK end, byte tnakey, out nint logObjs, out BS2_CONFIG_MASK numLog);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetFilteredLogSinceEventId(nint context, BS2_CONFIG_MASK deviceId, nint uid, ushort eventCode, BS2_CONFIG_MASK start, BS2_CONFIG_MASK end, byte tnakey, BS2_CONFIG_MASK lastEventId, BS2_CONFIG_MASK amount, out nint logObjs, out BS2_CONFIG_MASK numLog);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetImageLog(nint context, BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK eventId, out nint imageObj, out BS2_CONFIG_MASK imageSize);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ClearLog(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_StartMonitoringLog(nint context, BS2_CONFIG_MASK deviceId, OnLogReceived cbOnLogReceived);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_StartMonitoringLogEx(nint context, BS2_CONFIG_MASK deviceId, OnLogReceivedEx cbOnLogReceivedEx);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_StopMonitoringLog(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLogBlob(nint context, BS2_CONFIG_MASK deviceId, ushort eventMask, BS2_CONFIG_MASK eventId, BS2_CONFIG_MASK amount, out nint logObjs, out BS2_CONFIG_MASK numLog);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLogSmallBlobEx(nint context, BS2_CONFIG_MASK deviceId, ushort eventMask, BS2_CONFIG_MASK eventId, BS2_CONFIG_MASK amount, out nint logObjs, out BS2_CONFIG_MASK numLog);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< MISC API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_FactoryReset(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RebootDevice(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_LockDevice(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_UnlockDevice(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDeviceTime(nint context, BS2_CONFIG_MASK deviceId, out BS2_CONFIG_MASK gmtTime);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDeviceTime(nint context, BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK gmtTime);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_UpgradeFirmware(nint context, BS2_CONFIG_MASK deviceId, nint firmwareData, BS2_CONFIG_MASK firmwareDataLen, byte keepVerifyingSlaveDevice, OnProgressChanged cbProgressChanged);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_UpdateResource(nint context, BS2_CONFIG_MASK deviceId, ref BS2ResourceElement resourceElement, byte keepVerifyingSlaveDevice, OnProgressChanged cbProgressChanged);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDeviceCapabilities(nint context, BS2_CONFIG_MASK deviceId, out BS2DeviceCapabilities info);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RunAction(nint context, BS2_CONFIG_MASK deviceId, out BS2Action action);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static void BS2_SetKeepAliveTimeout(nint context, long ms);

        [DllImport("BS_SDK_V2.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_MakePinCode(IntPtr context, string salt, [In, Out] IntPtr pinCode);
        extern public static int BS2_MakePinCode(nint context, nint salt, [In, Out] nint pinCode);

        [DllImport("BS_SDK_V2.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_MakePinCodeWithKey(nint context, nint salt, [In, Out] nint pinCode, ref BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ComputeCRC16CCITT(nint data, BS2_CONFIG_MASK dataLen, ref ushort crc);

        [DllImport("BS_SDK_V2.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetCardModel(string modelName, out UInt16 cardModel);
        extern public static int BS2_GetCardModel(nint modelName, out ushort cardModel);

        [DllImport("BS_SDK_V2.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        extern public static nint BS2_Version();

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDataEncryptKey(nint context, BS2_CONFIG_MASK deviceId, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDataEncryptKey(nint context, BS2_CONFIG_MASK deviceId, ref BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveDataEncryptKey(nint context, BS2_CONFIG_MASK deviceId);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Slave Control API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetSlaveDevice(nint context, BS2_CONFIG_MASK deviceId, out nint slaveDeviceObj, out BS2_CONFIG_MASK slaveDeviceCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetSlaveDevice(nint context, BS2_CONFIG_MASK deviceId, nint slaveDeviceObj, BS2_CONFIG_MASK slaveDeviceCount);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Server Matching API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetServerMatchingHandler(nint context, OnVerifyUser cbOnVerifyUser, OnIdentifyUser cbOnIdentifyUser);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_VerifyUser(nint context, BS2_CONFIG_MASK deviceId, ushort seq, int handleResult, ref BS2UserBlob userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_IdentifyUser(nint context, BS2_CONFIG_MASK deviceId, ushort seq, int handleResult, ref BS2UserBlob userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_VerifyUserEx(nint context, BS2_CONFIG_MASK deviceId, ushort seq, int handleResult, ref BS2UserBlobEx userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_IdentifyUserEx(nint context, BS2_CONFIG_MASK deviceId, ushort seq, int handleResult, ref BS2UserBlobEx userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetUserPhraseHandler(nint context, OnUserPhrase cbOnQuery);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ResponseUserPhrase(nint context, BS2_CONFIG_MASK deviceId, ushort seq, int handleResult, nint userPhrase);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< User API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserDatabaseInfo(nint context, BS2_CONFIG_MASK deviceId, out BS2_CONFIG_MASK numUsers, out BS2_CONFIG_MASK numCards, out BS2_CONFIG_MASK numFingers, out BS2_CONFIG_MASK numFaces, IsAcceptableUserID cbIsAcceptableUserID);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserList(nint context, BS2_CONFIG_MASK deviceId, out nint outUidObjs, out BS2_CONFIG_MASK outNumUids, IsAcceptableUserID cbIsAcceptableUserID);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserInfos(nint context, BS2_CONFIG_MASK deviceId, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserBlob[] userBlobs);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserDatas(nint context, BS2_CONFIG_MASK deviceId, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserBlob[] userBlobs, BS2_CONFIG_MASK userMask);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_EnrolUser(nint context, BS2_CONFIG_MASK deviceId, [In, Out] BS2UserBlob[] userBlobs, BS2_CONFIG_MASK uidCount, byte overwrite);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_EnrollUser(nint context, BS2_CONFIG_MASK deviceId, [In, Out] BS2UserBlob[] userBlobs, BS2_CONFIG_MASK uidCount, byte overwrite);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveUser(nint context, BS2_CONFIG_MASK deviceId, nint uids, BS2_CONFIG_MASK uidCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllUser(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserInfosEx(nint context, BS2_CONFIG_MASK deviceId, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserBlobEx[] userBlobs);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserDatasEx(nint context, BS2_CONFIG_MASK deviceId, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserBlobEx[] userBlobs, BS2_CONFIG_MASK userMask);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_EnrolUserEx(nint context, BS2_CONFIG_MASK deviceId, [In, Out] BS2UserBlobEx[] userBlobs, BS2_CONFIG_MASK uidCount, byte overwrite);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_EnrollUserEx(nint context, BS2_CONFIG_MASK deviceId, [In, Out] BS2UserBlobEx[] userBlobs, BS2_CONFIG_MASK uidCount, byte overwrite);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Wiegand Control API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SearchWiegandDevices(nint context, BS2_CONFIG_MASK deviceId, out nint wiegandDeviceObj, out BS2_CONFIG_MASK numWiegandDevice);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetWiegandDevices(nint context, BS2_CONFIG_MASK deviceId, out nint wiegandDeviceObj, out BS2_CONFIG_MASK numWiegandDevice);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_AddWiegandDevices(nint context, BS2_CONFIG_MASK deviceId, nint wiegandDevice, BS2_CONFIG_MASK numWiegandDevice);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveWiegandDevices(nint context, BS2_CONFIG_MASK deviceId, nint wiegandDevice, BS2_CONFIG_MASK numWiegandDevice);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Zone Control API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAntiPassbackZone(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount, out nint zoneObj, out BS2_CONFIG_MASK numZone);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllAntiPassbackZone(nint context, BS2_CONFIG_MASK deviceId, out nint zoneObj, out BS2_CONFIG_MASK numZone);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAntiPassbackZoneStatus(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount, out nint zoneStatusObj, out BS2_CONFIG_MASK numZoneStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllAntiPassbackZoneStatus(nint context, BS2_CONFIG_MASK deviceId, out nint zoneStatusObj, out BS2_CONFIG_MASK numZoneStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetAntiPassbackZone(nint context, BS2_CONFIG_MASK deviceId, nint zones, BS2_CONFIG_MASK zoneCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetAntiPassbackZoneAlarm(nint context, BS2_CONFIG_MASK deviceId, byte alarmed, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAntiPassbackZone(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllAntiPassbackZone(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ClearAntiPassbackZoneStatus(nint context, BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK zoneID, nint uids, BS2_CONFIG_MASK uidCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ClearAllAntiPassbackZoneStatus(nint context, BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK zoneID);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetCheckGlobalAPBViolationHandler(nint context, OnCheckGlobalAPBViolation ptrCheckGlobalAPBViolation);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_CheckGlobalAPBViolation(nint context, BS2_CONFIG_MASK deviceId, ushort seq, int handleResult, BS2_CONFIG_MASK zoneID);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetGlobalAPBViolationByDoorOpenHandler(nint context, OnCheckGlobalAPBViolationByDoorOpen ptrCheck, OnUpdateGlobalAPBViolationByDoorOpen ptrUpdate);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_CheckGlobalAPBViolationByDoorOpen(nint context, BS2_CONFIG_MASK deviceId, ushort seq, int handleResult, BS2_CONFIG_MASK zoneID);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetTimedAntiPassbackZone(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount, out nint zoneObj, out BS2_CONFIG_MASK numZone);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllTimedAntiPassbackZone(nint context, BS2_CONFIG_MASK deviceId, out nint zoneObj, out BS2_CONFIG_MASK numZone);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetTimedAntiPassbackZoneStatus(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount, out nint zoneStatusObj, out BS2_CONFIG_MASK numZoneStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllTimedAntiPassbackZoneStatus(nint context, BS2_CONFIG_MASK deviceId, out nint zoneStatusObj, out BS2_CONFIG_MASK numZoneStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetTimedAntiPassbackZone(nint context, BS2_CONFIG_MASK deviceId, nint zones, BS2_CONFIG_MASK zoneCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetTimedAntiPassbackZoneAlarm(nint context, BS2_CONFIG_MASK deviceId, byte alarmed, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveTimedAntiPassbackZone(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllTimedAntiPassbackZone(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ClearTimedAntiPassbackZoneStatus(nint context, BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK zoneID, nint uids, BS2_CONFIG_MASK uidCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ClearAllTimedAntiPassbackZoneStatus(nint context, BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK zoneID);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetFireAlarmZone(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount, out nint zoneObj, out BS2_CONFIG_MASK numZone);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllFireAlarmZone(nint context, BS2_CONFIG_MASK deviceId, out nint zoneObj, out BS2_CONFIG_MASK numZone);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetFireAlarmZoneStatus(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount, out nint zoneStatusObj, out BS2_CONFIG_MASK numZoneStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllFireAlarmZoneStatus(nint context, BS2_CONFIG_MASK deviceId, out nint zoneStatusObj, out BS2_CONFIG_MASK numZoneStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetFireAlarmZone(nint context, BS2_CONFIG_MASK deviceId, nint zones, BS2_CONFIG_MASK zoneCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetFireAlarmZoneAlarm(nint context, BS2_CONFIG_MASK deviceId, byte alarmed, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveFireAlarmZone(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllFireAlarmZone(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetScheduledLockUnlockZone(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount, out nint zoneObj, out BS2_CONFIG_MASK numZone);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllScheduledLockUnlockZone(nint context, BS2_CONFIG_MASK deviceId, out nint zoneObj, out BS2_CONFIG_MASK numZone);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetScheduledLockUnlockZoneStatus(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount, out nint zoneStatusObj, out BS2_CONFIG_MASK numZoneStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllScheduledLockUnlockZoneStatus(nint context, BS2_CONFIG_MASK deviceId, out nint zoneStatusObj, out BS2_CONFIG_MASK numZoneStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetScheduledLockUnlockZone(nint context, BS2_CONFIG_MASK deviceId, nint zones, BS2_CONFIG_MASK zoneCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetScheduledLockUnlockZoneAlarm(nint context, BS2_CONFIG_MASK deviceId, byte alarmed, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveScheduledLockUnlockZone(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllScheduledLockUnlockZone(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLiftLockUnlockZone(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount, out nint zoneObj, out BS2_CONFIG_MASK numZone);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllLiftLockUnlockZone(nint context, BS2_CONFIG_MASK deviceId, out nint zoneObj, out BS2_CONFIG_MASK numZone);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLiftLockUnlockZoneStatus(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount, out nint zoneStatusObj, out BS2_CONFIG_MASK numZoneStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllLiftLockUnlockZoneStatus(nint context, BS2_CONFIG_MASK deviceId, out nint zoneStatusObj, out BS2_CONFIG_MASK numZoneStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetLiftLockUnlockZone(nint context, BS2_CONFIG_MASK deviceId, nint zones, BS2_CONFIG_MASK zoneCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetLiftLockUnlockZoneAlarm(nint context, BS2_CONFIG_MASK deviceId, byte alarmed, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveLiftLockUnlockZone(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllLiftLockUnlockZone(nint context, BS2_CONFIG_MASK deviceId);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Face API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ScanFace(nint context, BS2_CONFIG_MASK deviceId, [In, Out] BS2Face[] face, byte enrollmentThreshold, OnReadyToScan cbReadyToScan);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ScanFaceEx(nint context, BS2_CONFIG_MASK deviceId, [In, Out] BS2FaceExWarped[] face, byte enrollmentThreshold, OnReadyToScan cbReadyToScan);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ExtractTemplateFaceEx(nint context, BS2_CONFIG_MASK deviceId, nint imageData, BS2_CONFIG_MASK imageDataLen, int isWarped, out BS2TemplateEx templateEx);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetNormalizedImageFaceEx(nint context, BS2_CONFIG_MASK deviceId, nint unwarpedImage, BS2_CONFIG_MASK unwarpedImageLen, nint warpedImage, out BS2_CONFIG_MASK warpedImageLen);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Lift API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLift(nint context, BS2_CONFIG_MASK deviceId, nint LiftIds, BS2_CONFIG_MASK LiftIdCount, out nint LiftObj, out BS2_CONFIG_MASK numLift);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllLift(nint context, BS2_CONFIG_MASK deviceId, out nint LiftObj, out BS2_CONFIG_MASK numLift);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLiftStatus(nint context, BS2_CONFIG_MASK deviceId, nint LiftIds, BS2_CONFIG_MASK LiftIdCount, out nint LiftObj, out BS2_CONFIG_MASK numLift);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllLiftStatus(nint context, BS2_CONFIG_MASK deviceId, out nint LiftObj, out BS2_CONFIG_MASK numLift);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetLift(nint context, BS2_CONFIG_MASK deviceId, nint Lifts, BS2_CONFIG_MASK LiftCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetLiftAlarm(nint context, BS2_CONFIG_MASK deviceId, byte alarmFlag, nint Lifts, BS2_CONFIG_MASK LiftCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveLift(nint context, BS2_CONFIG_MASK deviceId, nint LiftIds, BS2_CONFIG_MASK LiftIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllLift(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ReleaseFloor(nint context, BS2_CONFIG_MASK deviceId, byte floorFlag, BS2_CONFIG_MASK liftID, nint FloorIndexs, byte floorIndexCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ActivateFloor(nint context, BS2_CONFIG_MASK deviceId, byte floorFlag, BS2_CONFIG_MASK liftID, nint FloorIndexs, byte floorIndexCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_DeActivateFloor(nint context, BS2_CONFIG_MASK deviceId, byte floorFlag, BS2_CONFIG_MASK liftID, nint FloorIndexs, byte floorIndexCount);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< SSL API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetSSLServerPort(nint context, ushort sslServerPort);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDeviceSSLEventListener(nint context, OnSendRootCA cbOnSendRootCA);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_DisableSSL(nint context, BS2_CONFIG_MASK deviceId);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< AuthGroup API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAuthGroup(nint context, BS2_CONFIG_MASK deviceId, nint authGroupIds, BS2_CONFIG_MASK authGroupIdCount, out nint authGroupObj, out BS2_CONFIG_MASK numAuthGroup);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllAuthGroup(nint context, BS2_CONFIG_MASK deviceId, out nint authGroupObj, out BS2_CONFIG_MASK numAuthGroup);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetAuthGroup(nint context, BS2_CONFIG_MASK deviceId, nint authGroups, BS2_CONFIG_MASK authGroupCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAuthGroup(nint context, BS2_CONFIG_MASK deviceId, nint authGroupIds, BS2_CONFIG_MASK authGroupIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllAuthGroup(nint context, BS2_CONFIG_MASK deviceId);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Floor Level API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetFloorLevel(nint context, BS2_CONFIG_MASK deviceId, nint floorLevelIds, BS2_CONFIG_MASK floorLevelIdCount, out nint floorLevelObj, out BS2_CONFIG_MASK numFloorLevel);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllFloorLevel(nint context, BS2_CONFIG_MASK deviceId, out nint floorLevelObj, out BS2_CONFIG_MASK numFloorLevel);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetFloorLevel(nint context, BS2_CONFIG_MASK deviceId, nint floorLevels, BS2_CONFIG_MASK floorLevelCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveFloorLevel(nint context, BS2_CONFIG_MASK deviceId, nint floorLevelIds, BS2_CONFIG_MASK floorLevelIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllFloorLevel(nint context, BS2_CONFIG_MASK deviceId);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< USB Exported API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetUserDatabaseInfoFromDir(IntPtr context, string szDir, out UInt32 numUsers, out UInt32 numCards, out UInt32 numFingers, out UInt32 numFaces, IsAcceptableUserID cbIsAcceptableUserID);
        extern public static int BS2_GetUserDatabaseInfoFromDir(nint context, nint szDir, out BS2_CONFIG_MASK numUsers, out BS2_CONFIG_MASK numCards, out BS2_CONFIG_MASK numFingers, out BS2_CONFIG_MASK numFaces, IsAcceptableUserID cbIsAcceptableUserID);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetUserListFromDir(IntPtr context, string szDir, out IntPtr outUidObjs, out UInt32 outNumUids, IsAcceptableUserID cbIsAcceptableUserID);
        extern public static int BS2_GetUserListFromDir(nint context, nint szDir, out nint outUidObjs, out BS2_CONFIG_MASK outNumUids, IsAcceptableUserID cbIsAcceptableUserID);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetUserInfosFromDir(IntPtr context, string szDir, IntPtr uids, UInt32 uidCount, [In, Out] BS2UserBlob[] userBlobs);
        extern public static int BS2_GetUserInfosFromDir(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserBlob[] userBlobs);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetUserDatasFromDir(IntPtr context, string szDir, IntPtr uids, UInt32 uidCount, [In, Out] BS2UserBlob[] userBlobs, UInt32 userMask);
        extern public static int BS2_GetUserDatasFromDir(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserBlob[] userBlobs, BS2_CONFIG_MASK userMask);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetUserInfosExFromDir(IntPtr context, string szDir, IntPtr uids, UInt32 uidCount, [In, Out] BS2UserBlobEx[] userBlobs);
        extern public static int BS2_GetUserInfosExFromDir(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserBlobEx[] userBlobs);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetUserDatasExFromDir(IntPtr context, string szDir, IntPtr uids, UInt32 uidCount, [In, Out] BS2UserBlobEx[] userBlobs, UInt32 userMask);
        extern public static int BS2_GetUserDatasExFromDir(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserBlobEx[] userBlobs, BS2_CONFIG_MASK userMask);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetLogFromDir(IntPtr context, string szDir, UInt32 eventId, UInt32 amount, out IntPtr logObjs, out UInt32 numLog);
        extern public static int BS2_GetLogFromDir(nint context, nint szDir, BS2_CONFIG_MASK eventId, BS2_CONFIG_MASK amount, out nint logObjs, out BS2_CONFIG_MASK numLog);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetFilteredLogFromDir(IntPtr context, string szDir, IntPtr uid, UInt16 eventCode, UInt32 start, UInt32 end, byte tnakey, out IntPtr logObjs, out UInt32 numLog);
        extern public static int BS2_GetFilteredLogFromDir(nint context, nint szDir, nint uid, ushort eventCode, BS2_CONFIG_MASK start, BS2_CONFIG_MASK end, byte tnakey, out nint logObjs, out BS2_CONFIG_MASK numLog);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetLogBlobFromDir(IntPtr context, string szDir, UInt16 eventMask, UInt32 eventId, UInt32 amount, out IntPtr logObjs, out UInt32 numLog);
        extern public static int BS2_GetLogBlobFromDir(nint context, nint szDir, ushort eventMask, BS2_CONFIG_MASK eventId, BS2_CONFIG_MASK amount, out nint logObjs, out BS2_CONFIG_MASK numLog);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLogSmallBlobFromDir(nint context, nint szDir, ushort eventMask, BS2_CONFIG_MASK eventId, BS2_CONFIG_MASK amount, out nint logObjs, out BS2_CONFIG_MASK numLog);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLogSmallBlobExFromDir(nint context, nint szDir, ushort eventMask, BS2_CONFIG_MASK eventId, BS2_CONFIG_MASK amount, out nint logObjs, out BS2_CONFIG_MASK numLog);

        // With key
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserDatabaseInfoFromDirWithKey(nint context, nint szDir, out BS2_CONFIG_MASK numUsers, out BS2_CONFIG_MASK numCards, out BS2_CONFIG_MASK numFingers, out BS2_CONFIG_MASK numFaces, IsAcceptableUserID cbIsAcceptableUserID, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserListFromDirWithKey(nint context, nint szDir, out nint outUidObjs, out BS2_CONFIG_MASK outNumUids, IsAcceptableUserID cbIsAcceptableUserID, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserInfosFromDirWithKey(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserBlob[] userBlobs, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserDatasFromDirWithKey(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserBlob[] userBlobs, BS2_CONFIG_MASK userMask, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserInfosExFromDirWithKey(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserBlobEx[] userBlobs, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserDatasExFromDirWithKey(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserBlobEx[] userBlobs, BS2_CONFIG_MASK userMask, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserSmallInfosFromDirWithKey(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserSmallBlob[] userBlob, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserSmallDatasFromDirWithKey(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserSmallBlob[] userBlob, BS2_USER_MASK userMask, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserSmallInfosExFromDirWithKey(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserSmallBlobEx[] userBlob, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserSmallDatasExFromDirWithKey(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserSmallBlobEx[] userBlob, BS2_USER_MASK userMask, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLogFromDirWithKey(nint context, nint szDir, BS2_CONFIG_MASK eventId, BS2_CONFIG_MASK amount, out nint logObjs, out BS2_CONFIG_MASK numLog, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLogBlobFromDirWithKey(nint context, nint szDir, ushort eventMask, BS2_CONFIG_MASK eventId, BS2_CONFIG_MASK amount, out nint logObjs, out BS2_CONFIG_MASK numLog, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetFilteredLogFromDirWithKey(nint context, nint szDir, nint uid, ushort eventCode, BS2_CONFIG_MASK start, BS2_CONFIG_MASK end, byte tnakey, out nint logObjs, out BS2_CONFIG_MASK numLog, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLogSmallBlobFromDirWithKey(nint context, nint szDir, ushort eventMask, BS2_CONFIG_MASK eventId, BS2_CONFIG_MASK amount, out nint logObjs, out BS2_CONFIG_MASK numLog, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetLogSmallBlobExFromDirWithKey(nint context, nint szDir, ushort eventMask, BS2_CONFIG_MASK eventId, BS2_CONFIG_MASK amount, out nint logObjs, out BS2_CONFIG_MASK numLog, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserInfosFaceExFromDirWithKey(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserFaceExBlob[] userBlob, out BS2EncryptKey keyInfo);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserDatasFaceExFromDirWithKey(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserFaceExBlob[] userBlob, BS2_USER_MASK userMask, out BS2EncryptKey keyInfo);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< WRAPPER >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        public static BS2ErrorCode CSP_BS2_GetAllAccessSchedule(nint context, BS2_CONFIG_MASK deviceId, out CSP_BS2Schedule[] accessScheduleObj, out BS2_CONFIG_MASK numAccessSchedule)
        {
            return Util.CSP_BS2_GetAll<CSP_BS2Schedule, CXX_BS2Schedule>(context, deviceId, out accessScheduleObj, out numAccessSchedule, BS2_GetAllAccessSchedule);
        }

        public static BS2ErrorCode CSP_BS2_GetAccessSchedule(nint context, BS2_CONFIG_MASK deviceId, BS2_SCHEDULE_ID[] accessScheduleIds, BS2_CONFIG_MASK accessScheduleIdCount, out CSP_BS2Schedule[] accessScheduleObj, out BS2_CONFIG_MASK numAccessSchedule)
        {
            return Util.CSP_BS2_GetItems<BS2_SCHEDULE_ID, CSP_BS2Schedule, BS2_SCHEDULE_ID, CXX_BS2Schedule>(context, deviceId, accessScheduleIds, accessScheduleIdCount, out accessScheduleObj, out numAccessSchedule, BS2_GetAccessSchedule);
        }

        public static BS2ErrorCode CSP_BS2_RemoveAccessSchedule(nint context, BS2_CONFIG_MASK deviceId, BS2_SCHEDULE_ID[] accessScheduleIds, BS2_CONFIG_MASK accessScheduleIdCount)
        {
            return Util.CSP_BS2_RemoveItems<BS2_SCHEDULE_ID, BS2_SCHEDULE_ID>(context, deviceId, accessScheduleIds, accessScheduleIdCount, BS2_RemoveAccessSchedule);
        }

        public static BS2ErrorCode CSP_BS2_SetAccessSchedule(nint context, BS2_CONFIG_MASK deviceId, CSP_BS2Schedule[] accessSchedules, BS2_CONFIG_MASK accessScheduleCount)
        {
            return Util.CSP_BS2_SetItems<CSP_BS2Schedule, CXX_BS2Schedule>(context, deviceId, accessSchedules, accessScheduleCount, BS2_SetAccessSchedule);
        }

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< SlaveEx Control API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetSlaveExDevice(nint context, BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK channelport, out nint slaveDeviceObj, out BS2_CONFIG_MASK outchannelport, out BS2_CONFIG_MASK slaveDeviceCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetSlaveExDevice(nint context, BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK channelport, nint slaveDeviceObj, BS2_CONFIG_MASK slaveDeviceCount);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< IntrusionAlarmZone API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetIntrusionAlarmZone(nint context, BS2_CONFIG_MASK deviceId, [In, Out] BS2IntrusionAlarmZoneBlob[] zoneBlobs, out BS2_CONFIG_MASK numZone);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetIntrusionAlarmZoneStatus(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount, out nint zoneStatusObj, out BS2_CONFIG_MASK numZoneStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllIntrusionAlarmZoneStatus(nint context, BS2_CONFIG_MASK deviceId, out nint zoneStatusObj, out BS2_CONFIG_MASK numZoneStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetIntrusionAlarmZone(nint context, BS2_CONFIG_MASK deviceId, [In, Out] BS2IntrusionAlarmZoneBlob[] zoneBlobs, BS2_CONFIG_MASK zoneCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetIntrusionAlarmZoneAlarm(nint context, BS2_CONFIG_MASK deviceId, byte alarmed, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveIntrusionAlarmZone(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllIntrusionAlarmZone(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetIntrusionAlarmZoneArm(nint context, BS2_CONFIG_MASK deviceId, byte alarmed, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        #region DEVICE_ZONE_SUPPORTED
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDeviceZoneMasterConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2DeviceZoneMasterConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDeviceZoneMasterConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2DeviceZoneMasterConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveDeviceZoneMasterConfig(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDeviceZone(nint context, BS2_CONFIG_MASK deviceId, nint Ids, BS2_CONFIG_MASK IdCount, out nint deviceZoneObj, out BS2_CONFIG_MASK numDeviceZone);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllDeviceZone(nint context, BS2_CONFIG_MASK deviceId, out nint deviceZoneObj, out BS2_CONFIG_MASK numDeviceZone);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDeviceZone(nint context, BS2_CONFIG_MASK deviceId, nint deviceZones, BS2_CONFIG_MASK deviceZoneCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveDeviceZone(nint context, BS2_CONFIG_MASK deviceId, nint Ids, BS2_CONFIG_MASK IdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllDeviceZone(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDeviceZoneConfig(nint context, BS2_CONFIG_MASK deviceId, out BS2DeviceZoneConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDeviceZoneConfig(nint context, BS2_CONFIG_MASK deviceId, ref BS2DeviceZoneConfig config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDeviceZoneAlarm(nint context, BS2_CONFIG_MASK deviceId, byte alarmed, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ClearDeviceZoneAccessRecord(nint context, BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK zoneID, nint uids, BS2_CONFIG_MASK uidCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ClearAllDeviceZoneAccessRecord(nint context, BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK zoneID);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDeviceZoneAGEntranceLimit(nint context, BS2_CONFIG_MASK deviceId, /*UInt32[]*/nint Ids, BS2_CONFIG_MASK IdCount, out /*BS2DeviceZoneAGEntranceLimit[]*/nint deviceZoneAGEntranceLimitObj, out BS2_CONFIG_MASK numDeviceZoneAGEntranceLimit);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllDeviceZoneAGEntranceLimit(nint context, BS2_CONFIG_MASK deviceId, out /*BS2DeviceZoneAGEntranceLimit[]*/ nint deviceZoneAGEntranceLimitObj, out BS2_CONFIG_MASK numDeviceZoneAGEntranceLimit);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDeviceZoneAGEntranceLimit(nint context, BS2_CONFIG_MASK deviceId, /*BS2DeviceZoneAGEntranceLimit[]*/nint deviceZoneAGEntranceLimits, BS2_CONFIG_MASK deviceZoneAGEntranceLimitCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveDeviceZoneAGEntranceLimit(nint context, BS2_CONFIG_MASK deviceId, /*UInt32[]*/nint Ids, BS2_CONFIG_MASK IdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllDeviceZoneAGEntranceLimit(nint context, BS2_CONFIG_MASK deviceId);

        #endregion

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetSupportedConfigMask(nint context, BS2_CONFIG_MASK deviceId, out BS2_CONFIG_MASK configMask);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetSupportedUserMask(nint context, BS2_CONFIG_MASK deviceId, out BS2_USER_MASK userMask);

        //Debugging
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CBDebugPrint(string msg);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDebugLevel(CBDebugPrint ptrCBDebugPrint, BS2_CONFIG_MASK debugLevel);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CBDebugExPrint(BS2_CONFIG_MASK level, BS2_CONFIG_MASK module, string msg);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDebugExCallback(CBDebugExPrint ptrCBDebugExPrint, BS2_CONFIG_MASK level, BS2_CONFIG_MASK module);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_SetDebugFileLog(UInt32 level, UInt32 module, string logPath);
        extern public static int BS2_SetDebugFileLog(BS2_CONFIG_MASK level, BS2_CONFIG_MASK module, nint logPath);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDebugFileLogEx(BS2_CONFIG_MASK level, BS2_CONFIG_MASK module, nint logPath, int fileMaxSizeMB);

        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< InterlockZone API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetInterlockZone(nint context, BS2_CONFIG_MASK deviceId, [In, Out] BS2InterlockZoneBlob[] zoneBlob, out BS2_CONFIG_MASK numZone);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetInterlockZoneStatus(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount, out nint zoneStatusObj, out BS2_CONFIG_MASK numZoneStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllInterlockZoneStatus(nint context, BS2_CONFIG_MASK deviceId, out nint zoneStatusObj, out BS2_CONFIG_MASK numZoneStatus);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetInterlockZone(nint context, BS2_CONFIG_MASK deviceId, [In, Out] BS2InterlockZoneBlob[] zoneBlobs, BS2_CONFIG_MASK zoneCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetInterlockZoneAlarm(nint context, BS2_CONFIG_MASK deviceId, byte alarmed, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveInterlockZone(nint context, BS2_CONFIG_MASK deviceId, nint zoneIds, BS2_CONFIG_MASK zoneIdCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllInterlockZone(nint context, BS2_CONFIG_MASK deviceId);

        //=> [IPv6]
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetIPConfigViaUDPEx(IntPtr context, UInt32 deviceId, out BS2IpConfig config, string hostipAddr);
        extern public static int BS2_GetIPConfigViaUDPEx(nint context, BS2_CONFIG_MASK deviceId, out BS2IpConfig config, nint hostipAddr);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_SetIPConfigViaUDPEx(IntPtr context, UInt32 deviceId, ref BS2IpConfig config, string hostipAddr);
        extern public static int BS2_SetIPConfigViaUDPEx(nint context, BS2_CONFIG_MASK deviceId, ref BS2IpConfig config, nint hostipAddr);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetIPV6Config(nint context, BS2_CONFIG_MASK deviceId, out BS2IPV6Config config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetIPV6Config(nint context, BS2_CONFIG_MASK deviceId, ref BS2IPV6Config config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetIPV6ConfigViaUDP(nint context, BS2_CONFIG_MASK deviceId, out BS2IPV6Config config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetIPV6ConfigViaUDP(nint context, BS2_CONFIG_MASK deviceId, ref BS2IPV6Config config);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetIPV6ConfigViaUDPEx(IntPtr context, UInt32 deviceId, out BS2IPV6Config config, string hostipAddr);
        extern public static int BS2_GetIPV6ConfigViaUDPEx(nint context, BS2_CONFIG_MASK deviceId, out BS2IPV6Config config, nint hostipAddr);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_SetIPV6ConfigViaUDPEx(IntPtr context, UInt32 deviceId, ref BS2IPV6Config config, string hostipAddr);
        extern public static int BS2_SetIPV6ConfigViaUDPEx(nint context, BS2_CONFIG_MASK deviceId, ref BS2IPV6Config config, nint hostipAddr);
        //<=

        //=> [IPv6]
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetEnableIPV4(nint context, out int enable);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetEnableIPV4(nint context, int enable);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetEnableIPV6(nint context, out int enable);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetEnableIPV6(nint context, int enable);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetServerPortIPV6(nint context, ushort serverPort);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetServerPortIPV6(nint context, out ushort serverPort);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetSSLServerPortIPV6(nint context, ushort sslServerPort);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetSSLServerPortIPV6(nint context, out ushort sslServerPort);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetSpecifiedDeviceInfo(nint context, BS2_CONFIG_MASK deviceId, BS2_CONFIG_MASK specifiedDeviceInfo, nint pOutDeviceInfo, BS2_CONFIG_MASK nDeviceInfoSize, out BS2_CONFIG_MASK pOutDeviceInfoSize);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_ConnectDeviceIPV6(nint context, BS2_CONFIG_MASK deviceId);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_SearchDevicesCoreStationEx(IntPtr context, string hostipAddr);
        extern public static int BS2_SearchDevicesCoreStationEx(nint context, nint hostipAddr);
        //<=

        //Beta => [Get ServerPort]
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetServerPort(nint context, out ushort serverPort);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetSSLServerPort(nint context, out ushort sslServerPort);
        //Beta <=

        //=> [Admin 1000]
        /* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Auth Operator Level Ex API >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> */
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAuthOperatorLevelEx(nint context, BS2_CONFIG_MASK deviceId, nint userIDs, BS2_CONFIG_MASK userIDCount, out nint operatorlevelObj, out BS2_CONFIG_MASK numOperatorlevel);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetAllAuthOperatorLevelEx(nint context, BS2_CONFIG_MASK deviceId, out nint operatorlevelObj, out BS2_CONFIG_MASK numOperatorlevel);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetAuthOperatorLevelEx(nint context, BS2_CONFIG_MASK deviceId, nint operatorlevels, BS2_CONFIG_MASK operatorlevelCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAuthOperatorLevelEx(nint context, BS2_CONFIG_MASK deviceId, nint userIDs, BS2_CONFIG_MASK userIDCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_RemoveAllAuthOperatorLevelEx(nint context, BS2_CONFIG_MASK deviceId);
        //<=

        //=> [Set/Get default response wait timeout]
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_SetDefaultResponseTimeout(nint context, int ms);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetDefaultResponseTimeout(nint context, out int poMs);
        //<=

        //UserSmall
        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_VerifyUserSmall(nint context, BS2_CONFIG_MASK deviceId, ushort seq, int handleResult, ref BS2UserSmallBlob userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_IdentifyUserSmall(nint context, BS2_CONFIG_MASK deviceId, ushort seq, int handleResult, ref BS2UserSmallBlob userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserSmallInfos(nint context, BS2_CONFIG_MASK deviceId, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserSmallBlob[] userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserSmallDatas(nint context, BS2_CONFIG_MASK deviceId, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserSmallBlob[] userBlob, BS2_USER_MASK userMask);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_EnrollUserSmall(nint context, BS2_CONFIG_MASK deviceId, [In, Out] BS2UserSmallBlob[] userBlob, BS2_CONFIG_MASK userCount, byte overwrite);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_VerifyUserSmallEx(nint context, BS2_CONFIG_MASK deviceId, ushort seq, int handleResult, ref BS2UserSmallBlobEx userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_VerifyUserFaceEx(nint context, BS2_CONFIG_MASK deviceId, ushort seq, int handleResult, ref BS2UserFaceExBlob userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_IdentifyUserSmallEx(nint context, BS2_CONFIG_MASK deviceId, ushort seq, int handleResult, ref BS2UserSmallBlobEx userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserSmallInfosEx(nint context, BS2_CONFIG_MASK deviceId, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserSmallBlobEx[] userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserSmallDatasEx(nint context, BS2_CONFIG_MASK deviceId, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserSmallBlobEx[] userBlob, BS2_USER_MASK userMask);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_EnrollUserSmallEx(nint context, BS2_CONFIG_MASK deviceId, [In, Out] BS2UserSmallBlobEx[] userBlob, BS2_CONFIG_MASK userCount, byte overwrite);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetUserSmallInfosFromDir(IntPtr context, string szDir, IntPtr uids, UInt32 uidCount, [In, Out] BS2UserSmallBlob[] userBlob);
        extern public static int BS2_GetUserSmallInfosFromDir(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserSmallBlob[] userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetUserSmallDatasFromDir(IntPtr context, string szDir, IntPtr uids, UInt32 uidCount, [In, Out] BS2UserSmallBlob[] userBlob, BS2_USER_MASK userMask);
        extern public static int BS2_GetUserSmallDatasFromDir(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserSmallBlob[] userBlob, BS2_USER_MASK userMask);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetUserSmallInfosExFromDir(IntPtr context, string szDir, IntPtr uids, UInt32 uidCount, [In, Out] BS2UserSmallBlobEx[] userBlob);
        extern public static int BS2_GetUserSmallInfosExFromDir(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserSmallBlobEx[] userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetUserSmallDatasExFromDir(IntPtr context, string szDir, IntPtr uids, UInt32 uidCount, [In, Out] BS2UserSmallBlobEx[] userBlob, BS2_USER_MASK userMask);
        extern public static int BS2_GetUserSmallDatasExFromDir(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserSmallBlobEx[] userBlob, BS2_USER_MASK userMask);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_EnrollUserFaceEx(nint context, BS2_CONFIG_MASK deviceId, [In, Out] BS2UserFaceExBlob[] userBlob, BS2_CONFIG_MASK userCount, byte overwrite);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserInfosFaceEx(nint context, BS2_CONFIG_MASK deviceId, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserFaceExBlob[] userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserDatasFaceEx(nint context, BS2_CONFIG_MASK deviceId, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserFaceExBlob[] userBlob, BS2_USER_MASK userMask);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetUserSmallInfosExFromDir(IntPtr context, string szDir, IntPtr uids, UInt32 uidCount, [In, Out] BS2UserSmallBlobEx[] userBlob);
        extern public static int BS2_GetUserInfosFaceExFromDir(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserFaceExBlob[] userBlob);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        //extern public static int BS2_GetUserSmallDatasExFromDir(IntPtr context, string szDir, IntPtr uids, UInt32 uidCount, [In, Out] BS2UserSmallBlobEx[] userBlob, BS2_USER_MASK userMask);
        extern public static int BS2_GetUserDatasFaceExFromDir(nint context, nint szDir, nint uids, BS2_CONFIG_MASK uidCount, [In, Out] BS2UserFaceExBlob[] userBlob, BS2_USER_MASK userMask);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_PartialUpdateUser(nint context, BS2_CONFIG_MASK deviceId, BS2_USER_MASK mask, [In, Out] BS2UserBlob[] userBlob, BS2_CONFIG_MASK userCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_PartialUpdateUserEx(nint context, BS2_CONFIG_MASK deviceId, BS2_USER_MASK mask, [In, Out] BS2UserBlobEx[] userBlob, BS2_CONFIG_MASK userCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_PartialUpdateUserSmall(nint context, BS2_CONFIG_MASK deviceId, BS2_USER_MASK mask, [In, Out] BS2UserSmallBlob[] userBlob, BS2_CONFIG_MASK userCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_PartialUpdateUserSmallEx(nint context, BS2_CONFIG_MASK deviceId, BS2_USER_MASK mask, [In, Out] BS2UserSmallBlobEx[] userBlob, BS2_CONFIG_MASK userCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_PartialUpdateUserFaceEx(nint context, BS2_CONFIG_MASK deviceId, BS2_USER_MASK mask, [In, Out] BS2UserFaceExBlob[] userBlob, BS2_CONFIG_MASK userCount);

        [DllImport("BS_SDK_V2.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int BS2_GetUserStatistic(nint context, BS2_CONFIG_MASK deviceId, out BS2UserStatistic statistic);
    }
}
