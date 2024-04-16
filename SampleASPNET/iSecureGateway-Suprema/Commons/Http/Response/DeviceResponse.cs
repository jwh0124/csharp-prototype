using System.ComponentModel;

namespace iSecureGateway_Suprema.Commons.Http.Response
{
    public enum DeviceResponse
    {
        #region [Category Success]

        [Category("D001")]
        [Description("Success")]
        SDK_SUCCESS = 1,

        [Category("D001")]
        [Description("Duress Success")]
        DURESS_SUCCESS = 2,

        [Category("D001")]
        [Description("First Auth Success")]
        FIRST_AUTH_SUCCESS = 3,

        [Category("D001")]
        [Description("Second Auth Success")]
        SECOND_AUTH_SUCCESS = 4,

        [Category("D001")]
        [Description("Dual Auth Success")]
        DUAL_AUTH_SUCCESS = 5,

        [Category("D001")]
        [Description("Wiegand ByPass Success")]
        WIEGAND_BYPASS_SUCCESS = 11,

        [Category("D001")]
        [Description("Anonymous Success")]
        ANONYMOUS_SUCCESS = 12,

        #endregion

        #region [Category Driver]

        [Category("D002")]
        [Description("From device driver")]
        ERROR_FROM_DEVICE_DRIVER = -1,

        #endregion

        #region [Category Communication]
        [Category("D003")]
        [Description("Cannot open socket")]
        ERROR_CANNOT_OPEN_SOCKET = -101,

        [Category("D003")]
        [Description("Cannot connect socket")]
        ERROR_CANNOT_CONNECT_SOCKET = -102,

        [Category("D003")]
        [Description("Cannot listen socket")]
        ERROR_CANNOT_LISTEN_SOCKET = -103,

        [Category("D003")]
        [Description("Cannot accept socket")]
        ERROR_CANNOT_ACCEPT_SOCKET = -104,

        [Category("D003")]
        [Description("Cannot read socket")]
        ERROR_CANNOT_READ_SOCKET = -105,

        [Category("D003")]
        [Description("Cannot write socket")]
        ERROR_CANNOT_WRITE_SOCKET = -106,

        [Category("D003")]
        [Description("Socket is not connected")]
        ERROR_SOCKET_IS_NOT_CONNECTED = -107,

        [Category("D003")]
        [Description("Socket is not open")]
        ERROR_SOCKET_IS_NOT_OPEN = -108,

        [Category("D003")]
        [Description("Socket is not listened")]
        ERROR_SOCKET_IS_NOT_LISTENED = -109,

        [Category("D003")]
        [Description("Socket in progress")]
        ERROR_SOCKET_IN_PROGRESS = -110,

        //=> [IPv6]
        [Category("D003")]
        [Description("IPv4 is noe enable")]
        ERROR_IPV4_IS_NOT_ENABLE = -111,

        [Category("D003")]
        [Description("IPv6 is not enable")]
        ERROR_IPV6_IS_NOT_ENABLE = -112,

        [Category("D003")]
        [Description("Not supported specified device info")]
        ERROR_NOT_SUPPORTED_SPECIFIED_DEVICE_INFO = -113,

        [Category("D003")]
        [Description("Not enough buffer")]
        ERROR_NOT_ENOUGTH_BUFFER = -114,

        [Category("D003")]
        [Description("Not supported IPv6")]
        ERROR_NOT_SUPPORTED_IPV6 = -115,

        [Category("D003")]
        [Description("Invalid address")]
        ERROR_INVALID_ADDRESS = -116,

        #endregion

        #region [Category Packet]

        [Category("D004")]
        [Description("Invalid param")]
        ERROR_INVALID_PARAM = -200,

        [Category("D004")]
        [Description("Invalid packet")]
        ERROR_INVALID_PACKET = -201,

        [Category("D004")]
        [Description("Invalid device id")]
        ERROR_INVALID_DEVICE_ID = -202,

        [Category("D004")]
        [Description("Invalid device type")]
        ERROR_INVALID_DEVICE_TYPE = -203,

        [Category("D004")]
        [Description("Packet checksum")]
        ERROR_PACKET_CHECKSUM = -204,

        [Category("D004")]
        [Description("Packet index")]
        ERROR_PACKET_INDEX = -205,

        [Category("D004")]
        [Description("Packet command")]
        ERROR_PACKET_COMMAND = -206,

        [Category("D004")]
        [Description("Packet sequence")]
        ERROR_PACKET_SEQUENCE = -207,

        [Category("D004")]
        [Description("No packet")]
        ERROR_NO_PACKET = -209,

        [Category("D004")]
        [Description("Invalid code sign")]
        ERROR_INVALID_CODE_SIGN = -210,

        #endregion

        #region [Category Fingerprint]
        [Category("D005")]
        [Description("Extraction fail")]
        ERROR_EXTRACTION_FAIL = -300,

        [Category("D005")]
        [Description("Invalid code sign")]
        ERROR_VERIFY_FAIL = -301,

        [Category("D005")]
        [Description("Identify fail")]
        ERROR_IDENTIFY_FAIL = -302,

        [Category("D005")]
        [Description("Identify timeout")]
        ERROR_IDENTIFY_TIMEOUT = -303,

        [Category("D005")]
        [Description("Fingerprint capture fail")]
        ERROR_FINGERPRINT_CAPTURE_FAIL = -304,

        [Category("D005")]
        [Description("Fingerprint scan timeout")]
        ERROR_FINGERPRINT_SCAN_TIMEOUT = -305,

        [Category("D005")]
        [Description("Fingerprint scan cancelled")]
        ERROR_FINGERPRINT_SCAN_CANCELLED = -306,

        [Category("D005")]
        [Description("Not same fingerprint")]
        ERROR_NOT_SAME_FINGERPRINT = -307,

        [Category("D005")]
        [Description("Extraction row quality")]
        ERROR_EXTRACTION_LOW_QUALITY = -308,

        [Category("D005")]
        [Description("Capture row quality")]
        ERROR_CAPTURE_LOW_QUALITY = -309,

        [Category("D005")]
        [Description("Cannot find fingerprint")]
        ERROR_CANNOT_FIND_FINGERPRINT = -310,

        [Category("D005")]
        [Description("No finger detected")]
        ERROR_NO_FINGER_DETECTED = ERROR_FINGERPRINT_CAPTURE_FAIL,

        [Category("D005")]
        [Description("Fake finger detected")]
        ERROR_FAKE_FINGER_DETECTED = -311,

        [Category("D005")]
        [Description("Fake finger try again")]
        ERROR_FAKE_FINGER_TRY_AGAIN = -312,

        [Category("D005")]
        [Description("Fake finger sensor error")]
        ERROR_FAKE_FINGER_SENSOR_ERROR = -313,

        #endregion

        #region [Category Face]

        [Category("D006")]
        [Description("Cannot find face")]
        ERROR_CANNOT_FIND_FACE = -314,

        [Category("D006")]
        [Description("Face capture fail")]
        ERROR_FACE_CAPTURE_FAIL = -315,

        [Category("D006")]
        [Description("Face scan timeout")]
        ERROR_FACE_SCAN_TIMEOUT = -316,

        [Category("D006")]
        [Description("Face scan cancelled")]
        ERROR_FACE_SCAN_CANCELLED = -317,

        [Category("D006")]
        [Description("Face scan failed")]
        ERROR_FACE_SCAN_FAILED = -318,

        [Category("D006")]
        [Description("No face detected")]
        ERROR_NO_FACE_DETECTED = ERROR_FACE_CAPTURE_FAIL,

        [Category("D006")]
        [Description("Unmasked face detected")]
        ERROR_UNMASKED_FACE_DETECTED = -319,

        [Category("D006")]
        [Description("Fake face detected")]
        ERROR_FAKE_FACE_DETECTED = -320,

        [Category("D006")]
        [Description("Cannot estimate")]
        ERROR_CANNOT_ESTIMATE = -321,

        [Category("D006")]
        [Description("Normalize face")]
        ERROR_NORMALIZE_FACE = -322,

        [Category("D006")]
        [Description("Small detection")]
        ERROR_SMALL_DETECTION = -323,

        [Category("D006")]
        [Description("Large detection")]
        ERROR_LARGE_DETECTION = -324,

        [Category("D006")]
        [Description("Biased detection")]
        ERROR_BIASED_DETECTION = -325,

        [Category("D006")]
        [Description("Rotated face")]
        ERROR_ROTATED_FACE = -326,

        [Category("D006")]
        [Description("Overlapped face")]
        ERROR_OVERLAPPED_FACE = -327,

        [Category("D006")]
        [Description("Unopened eyes")]
        ERROR_UNOPENED_EYES = -328,

        [Category("D006")]
        [Description("Not looking front")]
        ERROR_NOT_LOOKING_FRONT = -329,

        [Category("D006")]
        [Description("Occluded mouth")]
        ERROR_OCCLUDED_MOUTH = -330,

        [Category("D006")]
        [Description("Match fail")]
        ERROR_MATCH_FAIL = -331,

        [Category("D006")]
        [Description("Incompatible face")]
        ERROR_INCOMPATIBLE_FACE = -332,     // [+V2.8.3]

        #endregion

        #region [Category File I/O]

        //File I/O errors
        [Category("D007")]
        [Description("Cannot open dir")]
        ERROR_CANNOT_OPEN_DIR = -400,

        [Category("D007")]
        [Description("Cannot open file")]
        ERROR_CANNOT_OPEN_FILE = -401,

        [Category("D007")]
        [Description("Cannot write file")]
        ERROR_CANNOT_WRITE_FILE = -402,

        [Category("D007")]
        [Description("Cannot seek file")]
        ERROR_CANNOT_SEEK_FILE = -403,

        [Category("D007")]
        [Description("Cannot read file")]
        ERROR_CANNOT_READ_FILE = -404,

        [Category("D007")]
        [Description("Cannot get stat")]
        ERROR_CANNOT_GET_STAT = -405,

        [Category("D007")]
        [Description("Cannot get system info")]
        ERROR_CANNOT_GET_SYSINFO = -406,

        [Category("D007")]
        [Description("Data mismatch")]
        ERROR_DATA_MISMATCH = -407,

        [Category("D007")]
        [Description("Already open dir")]
        ERROR_ALREADY_OPEN_DIR = -408,

        #endregion

        #region [Category I/O]

        [Category("D008")]
        [Description("Invalid relay")]
        ERROR_INVALID_RELAY = -500,

        [Category("D008")]
        [Description("Cannot write IO packet")]
        ERROR_CANNOT_WRITE_IO_PACKET = -501,

        [Category("D008")]
        [Description("Cannot read IO packet")]
        ERROR_CANNOT_READ_IO_PACKET = -502,

        [Category("D008")]
        [Description("Cannot read input")]
        ERROR_CANNOT_READ_INPUT = -503,

        [Category("D008")]
        [Description("Read input timeout")]
        ERROR_READ_INPUT_TIMEOUT = -504,

        [Category("D008")]
        [Description("Cannot enable input")]
        ERROR_CANNOT_ENABLE_INPUT = -505,

        [Category("D008")]
        [Description("Cannot set input duration")]
        ERROR_CANNOT_SET_INPUT_DURATION = -506,

        [Category("D008")]
        [Description("Invalid port")]
        ERROR_INVALID_PORT = -507,

        [Category("D008")]
        [Description("Invalid interphone type")]
        ERROR_INVALID_INTERPHONE_TYPE = -508,

        [Category("D008")]
        [Description("Invalid lcd param")]
        ERROR_INVALID_LCD_PARAM = -510,

        [Category("D008")]
        [Description("Cannot write lcd packet")]
        ERROR_CANNOT_WRITE_LCD_PACKET = -511,

        [Category("D008")]
        [Description("Cannot read lcd packet")]
        ERROR_CANNOT_READ_LCD_PACKET = -512,

        [Category("D008")]
        [Description("Invalid lcd packet")]
        ERROR_INVALID_LCD_PACKET = -513,

        [Category("D008")]
        [Description("Input queue full")]
        ERROR_INPUT_QUEUE_FULL = -520,

        [Category("D008")]
        [Description("Wiegand queue full")]
        ERROR_WIEGAND_QUEUE_FULL = -521,

        [Category("D008")]
        [Description("Misc input queue full")]
        ERROR_MISC_INPUT_QUEUE_FULL = -522,

        [Category("D008")]
        [Description("Wiegand data queue full")]
        ERROR_WIEGAND_DATA_QUEUE_FULL = -523,

        [Category("D008")]
        [Description("Wiegand data queue empty")]
        ERROR_WIEGAND_DATA_QUEUE_EMPTY = -524,

        #endregion

        #region [Category Util]

        [Category("D009")]
        [Description("Not supported")]
        ERROR_NOT_SUPPORTED = -600,

        [Category("D009")]
        [Description("Timeout")]
        ERROR_TIMEOUT = -601,

        [Category("D009")]
        [Description("Cannot set time")]
        ERROR_CANNOT_SET_TIME = -602,

        #endregion

        #region [Category Database]

        [Category("D010")]
        [Description("Invalid data file")]
        ERROR_INVALID_DATA_FILE = -700,

        [Category("D010")]
        [Description("Too large data for slot")]
        ERROR_TOO_LARGE_DATA_FOR_SLOT = -701,

        [Category("D010")]
        [Description("Invalid slot no")]
        ERROR_INVALID_SLOT_NO = -702,

        [Category("D010")]
        [Description("Invalid slot data")]
        ERROR_INVALID_SLOT_DATA = -703,

        [Category("D010")]
        [Description("Cannot init database")]
        ERROR_CANNOT_INIT_DB = -704,

        [Category("D010")]
        [Description("Duplicate ID")]
        ERROR_DUPLICATE_ID = -705,

        [Category("D010")]
        [Description("User full")]
        ERROR_USER_FULL = -706,

        [Category("D010")]
        [Description("Duplicate template")]
        ERROR_DUPLICATE_TEMPLATE = -707,

        [Category("D010")]
        [Description("Fingerprint full")]
        ERROR_FINGERPRINT_FULL = -708,

        [Category("D010")]
        [Description("Duplicate card")]
        ERROR_DUPLICATE_CARD = -709,

        [Category("D010")]
        [Description("Card full")]
        ERROR_CARD_FULL = -710,

        [Category("D010")]
        [Description("No valid hdr file")]
        ERROR_NO_VALID_HDR_FILE = -711,

        [Category("D010")]
        [Description("Invalid log file")]
        ERROR_INVALID_LOG_FILE = -712,

        [Category("D010")]
        [Description("Cannot find user")]
        ERROR_CANNOT_FIND_USER = -714,

        [Category("D010")]
        [Description("Access level full")]
        ERROR_ACCESS_LEVEL_FULL = -715,

        [Category("D010")]
        [Description("Invalid user id")]
        ERROR_INVALID_USER_ID = -716,

        [Category("D010")]
        [Description("Blacklist full")]
        ERROR_BLACKLIST_FULL = -717,

        [Category("D010")]
        [Description("User name full")]
        ERROR_USER_NAME_FULL = -718,

        [Category("D010")]
        [Description("User image full")]
        ERROR_USER_IMAGE_FULL = -719,

        [Category("D010")]
        [Description("User image size too big")]
        ERROR_USER_IMAGE_SIZE_TOO_BIG = -720,

        [Category("D010")]
        [Description("Slot data checksum")]
        ERROR_SLOT_DATA_CHECKSUM = -721,

        [Category("D010")]
        [Description("Cannot update fingerprint")]
        ERROR_CANNOT_UPDATE_FINGERPRINT = -722,

        [Category("D010")]
        [Description("Template format mismatch")]
        ERROR_TEMPLATE_FORMAT_MISMATCH = -723,

        [Category("D010")]
        [Description("No admin user")]
        ERROR_NO_ADMIN_USER = -724,

        [Category("D010")]
        [Description("Cannot find log")]
        ERROR_CANNOT_FIND_LOG = -725,

        [Category("D010")]
        [Description("Door schedule full")]
        ERROR_DOOR_SCHEDULE_FULL = -726,

        [Category("D010")]
        [Description("DB slot full")]
        ERROR_DB_SLOT_FULL = -727,

        [Category("D010")]
        [Description("Access group full")]
        ERROR_ACCESS_GROUP_FULL = -728,

        [Category("D010")]
        [Description("Floor level full")]
        ERROR_FLOOR_LEVEL_FULL = -729,

        [Category("D010")]
        [Description("Access schedule full")]
        ERROR_ACCESS_SCHEDULE_FULL = -730,

        [Category("D010")]
        [Description("Holiday group full")]
        ERROR_HOLIDAY_GROUP_FULL = -731,

        [Category("D010")]
        [Description("Holiday full")]
        ERROR_HOLIDAY_FULL = -732,

        [Category("D010")]
        [Description("Time period full")]
        ERROR_TIME_PERIOD_FULL = -733,

        [Category("D010")]
        [Description("No credential")]
        ERROR_NO_CREDENTIAL = -734,

        [Category("D010")]
        [Description("No biometric credential")]
        ERROR_NO_BIOMETRIC_CREDENTIAL = -735,

        [Category("D010")]
        [Description("No card credential")]
        ERROR_NO_CARD_CREDENTIAL = -736,

        [Category("D010")]
        [Description("No pin credential")]
        ERROR_NO_PIN_CREDENTIAL = -737,

        [Category("D010")]
        [Description("No biometric pin credential")]
        ERROR_NO_BIOMETRIC_PIN_CREDENTIAL = -738,

        [Category("D010")]
        [Description("No user name")]
        ERROR_NO_USER_NAME = -739,

        [Category("D010")]
        [Description("No user image")]
        ERROR_NO_USER_IMAGE = -740,

        [Category("D010")]
        [Description("Reader full")]
        ERROR_READER_FULL = -741,

        [Category("D010")]
        [Description("Cache missed")]
        ERROR_CACHE_MISSED = -742,

        [Category("D010")]
        [Description("Operator full")]
        ERROR_OPERATOR_FULL = -743,

        [Category("D010")]
        [Description("Invalid link id")]
        ERROR_INVALID_LINK_ID = -744,

        [Category("D010")]
        [Description("Timer canceled")]
        ERROR_TIMER_CANCELED = -745,

        [Category("D010")]
        [Description("User job full")]
        ERROR_USER_JOB_FULL = -746,

        [Category("D010")]
        [Description("Cannot update face")]
        ERROR_CANNOT_UPDATE_FACE = -747,

        [Category("D010")]
        [Description("Face full")]
        ERROR_FACE_FULL = -748,

        [Category("D010")]
        [Description("Floor schedule full")]
        ERROR_FLOOR_SCHEDULE_FULL = -749,

        [Category("D010")]
        [Description("Cannot find auth group")]
        ERROR_CANNOT_FIND_AUTH_GROUP = -750,

        [Category("D010")]
        [Description("Auth group full")]
        ERROR_AUTH_GROUP_FULL = -751,

        [Category("D010")]
        [Description("User phrase full")]
        ERROR_USER_PHRASE_FULL = -752,

        [Category("D010")]
        [Description("DST schedule full")]
        ERROR_DST_SCHEDULE_FULL = -753,

        [Category("D010")]
        [Description("Cannot find DST schedule")]
        ERROR_CANNOT_FIND_DST_SCHEDULE = -754,

        [Category("D010")]
        [Description("Invalid schedule")]
        ERROR_INVALID_SCHEDULE = -755,

        [Category("D010")]
        [Description("Cannot find operator")]
        ERROR_CANNOT_FIND_OPERATOR = -756,

        [Category("D010")]
        [Description("Duplicate fingerprint")]
        ERROR_DUPLICATE_FINGERPRINT = -757,

        [Category("D010")]
        [Description("Duplicate face")]
        ERROR_DUPLICATE_FACE = -758,

        [Category("D010")]
        [Description("No face credential")]
        ERROR_NO_FACE_CREDENTIAL = -759,

        [Category("D010")]
        [Description("No fingerprint credential")]
        ERROR_NO_FINGERPRINT_CREDENTIAL = -760,

        [Category("D010")]
        [Description("No face pin credential")]
        ERROR_NO_FACE_PIN_CREDENTIAL = -761,

        [Category("D010")]
        [Description("No fingerprint pin credential")]
        ERROR_NO_FINGERPRINT_PIN_CREDENTIAL = -762,

        [Category("D010")]
        [Description("User image ex full")]
        ERROR_USER_IMAGE_EX_FULL = -763,

        #endregion

        #region [Category Config]

        [Category("D011")]
        [Description("Invalid config")]
        ERROR_INVALID_CONFIG = -800,

        [Category("D011")]
        [Description("Cannot open config file")]
        ERROR_CANNOT_OPEN_CONFIG_FILE = -801,

        [Category("D011")]
        [Description("Cannot read config file")]
        ERROR_CANNOT_READ_CONFIG_FILE = -802,

        [Category("D011")]
        [Description("Invalid config file")]
        ERROR_INVALID_CONFIG_FILE = -803,

        [Category("D011")]
        [Description("Invalid config data")]
        ERROR_INVALID_CONFIG_DATA = -804,

        [Category("D011")]
        [Description("Cannot write config file")]
        ERROR_CANNOT_WRITE_CONFIG_FILE = -805,

        [Category("D011")]
        [Description("Invalid config index")]
        ERROR_INVALID_CONFIG_INDEX = -806,

        #endregion

        #region [Category Device]

        [Category("D012")]
        [Description("Cannot scan finger")]
        ERROR_CANNOT_SCAN_FINGER = -900,

        [Category("D012")]
        [Description("Cannot scan card")]
        ERROR_CANNOT_SCAN_CARD = -901,

        [Category("D012")]
        [Description("Cannot open rtc")]
        ERROR_CANNOT_OPEN_RTC = -902,

        [Category("D012")]
        [Description("Cannot set rtc")]
        ERROR_CANNOT_SET_RTC = -903,

        [Category("D012")]
        [Description("Cannot get rtc")]
        ERROR_CANNOT_GET_RTC = -904,

        [Category("D012")]
        [Description("Cannot set led")]
        ERROR_CANNOT_SET_LED = -905,

        [Category("D012")]
        [Description("Cannot open device driver")]
        ERROR_CANNOT_OPEN_DEVICE_DRIVER = -906,

        [Category("D012")]
        [Description("Cannot find device")]
        ERROR_CANNOT_FIND_DEVICE = -907,

        [Category("D012")]
        [Description("Cannot scan face")]
        ERROR_CANNOT_SCAN_FACE = -908,

        [Category("D012")]
        [Description("Slave full")]
        ERROR_SLAVE_FULL = -910,

        [Category("D012")]
        [Description("Cannot add device")]
        ERROR_CANNOT_ADD_DEVICE = -911,

        #endregion

        #region [Category Door]

        [Category("D013")]
        [Description("Cannot find door")]
        ERROR_CANNOT_FIND_DOOR = -1000,

        [Category("D013")]
        [Description("Door full")]
        ERROR_DOOR_FULL = -1001,

        [Category("D013")]
        [Description("Cannot lock door")]
        ERROR_CANNOT_LOCK_DOOR = -1002,

        [Category("D013")]
        [Description("Cannot unlock door")]
        ERROR_CANNOT_UNLOCK_DOOR = -1003,

        [Category("D013")]
        [Description("Cannot release door")]
        ERROR_CANNOT_RELEASE_DOOR = -1004,

        [Category("D013")]
        [Description("Cannot find lift")]
        ERROR_CANNOT_FIND_LIFT = -1005,

        [Category("D013")]
        [Description("Lift full")]
        ERROR_LIFT_FULL = -1006,

        #endregion

        #region [Category Access Control]

        [Category("D014")]
        [Description("Access rule violation")]
        ERROR_ACCESS_RULE_VIOLATION = -1100,

        [Category("D014")]
        [Description("Disabled")]
        ERROR_DISABLED = -1101,

        [Category("D014")]
        [Description("Not yet valid")]
        ERROR_NOT_YET_VALID = -1102,

        [Category("D014")]
        [Description("Expired")]
        ERROR_EXPIRED = -1103,

        [Category("D014")]
        [Description("Blacklist")]
        ERROR_BLACKLIST = -1104,

        [Category("D014")]
        [Description("Cannot find access group")]
        ERROR_CANNOT_FIND_ACCESS_GROUP = -1105,

        [Category("D014")]
        [Description("Cannot find access level")]
        ERROR_CANNOT_FIND_ACCESS_LEVEL = -1106,

        [Category("D014")]
        [Description("Cannot find access schedule")]
        ERROR_CANNOT_FIND_ACCESS_SCHEDULE = -1107,

        [Category("D014")]
        [Description("Cannot find holiday group")]
        ERROR_CANNOT_FIND_HOLIDAY_GROUP = -1108,

        [Category("D014")]
        [Description("Cannot find blacklist")]
        ERROR_CANNOT_FIND_BLACKLIST = -1109,

        [Category("D014")]
        [Description("Auth timeout")]
        ERROR_AUTH_TIMEOUT = -1110,

        [Category("D014")]
        [Description("Dual auth timeout")]
        ERROR_DUAL_AUTH_TIMEOUT = -1111,

        [Category("D014")]
        [Description("Invalid auth mode")]
        ERROR_INVALID_AUTH_MODE = -1112,

        [Category("D014")]
        [Description("Auth unexpected user")]
        ERROR_AUTH_UNEXPECTED_USER = -1113,

        [Category("D014")]
        [Description("Auth unexpected credential")]
        ERROR_AUTH_UNEXPECTED_CREDENTIAL = -1114,

        [Category("D014")]
        [Description("Dual auth fail")]
        ERROR_DUAL_AUTH_FAIL = -1115,

        [Category("D014")]
        [Description("Biometric auth required")]
        ERROR_BIOMETRIC_AUTH_REQUIRED = -1116,

        [Category("D014")]
        [Description("Card auth required")]
        ERROR_CARD_AUTH_REQUIRED = -1117,

        [Category("D014")]
        [Description("Pin auth required")]
        ERROR_PIN_AUTH_REQUIRED = -1118,

        [Category("D014")]
        [Description("Biometric or pin auth required")]
        ERROR_BIOMETRIC_OR_PIN_AUTH_REQUIRED = -1119,

        [Category("D014")]
        [Description("TNA code required")]
        ERROR_TNA_CODE_REQUIRED = -1120,

        [Category("D014")]
        [Description("Auth server match refusal")]
        ERROR_AUTH_SERVER_MATCH_REFUSAL = -1121,

        [Category("D014")]
        [Description("Cannot find floor level")]
        ERROR_CANNOT_FIND_FLOOR_LEVEL = -1122,

        [Category("D014")]
        [Description("Auth fail")]
        ERROR_AUTH_FAIL = -1123,

        [Category("D014")]
        [Description("Auth group required")]
        ERROR_AUTH_GROUP_REQUIRED = -1124,

        [Category("D014")]
        [Description("Identification required")]
        ERROR_IDENTIFICATION_REQUIRED = -1125,

        [Category("D014")]
        [Description("Anti tailgate violation")]
        ERROR_ANTI_TAILGATE_VIOLATION = -1126,

        [Category("D014")]
        [Description("High temperature violation")]
        ERROR_HIGH_TEMPERATURE_VIOLATION = -1127,

        [Category("D014")]
        [Description("Cannot measure temperature")]
        ERROR_CANNOT_MEASURE_TEMPERATURE = -1128,

        [Category("D014")]
        [Description("Unmasked face violation")]
        ERROR_UNMASKED_FACE_VIOLATION = -1129,

        #endregion

        #region [Category Required (Fingerprint/Face/PIN/Mask/Thermal ...)]

        [Category("D015")]
        [Description("Mask check required")]
        MASK_CHECK_REQUIRED = -1130,

        [Category("D015")]
        [Description("Thermal check required")]
        THERMAL_CHECK_REQUIRED = -1131,

        [Category("D015")]
        [Description("Face auth required")]
        FACE_AUTH_REQUIRED = -1132,

        [Category("D015")]
        [Description("Fingerprint auth required")]
        FINGERPRINT_AUTH_REQUIRED = -1133,

        [Category("D015")]
        [Description("Face or pin auth required")]
        FACE_OR_PIN_AUTH_REQUIRED = -1134,

        [Category("D015")]
        [Description("Fingerprint or pin auth required")]
        FINGERPRINT_OR_PIN_AUTH_REQUIRED = -1135,

        #endregion

        #region [Category Zone]

        [Category("D016")]
        [Description("Cannot find zone")]
        ERROR_CANNOT_FIND_ZONE = -1200,

        [Category("D016")]
        [Description("Zone full")]
        [Obsolete] ERROR_ZONE_FULL = -1201,

        [Category("D016")]
        [Description("Set zone")]
        ERROR_SET_ZONE = -1201,

        [Category("D016")]
        [Description("Hard APB violation")]
        ERROR_HARD_APB_VIOLATION = -1202,

        [Category("D016")]
        [Description("Soft APB Violation")]
        ERROR_SOFT_APB_VIOLATION = -1203,

        [Category("D016")]
        [Description("Hard timed APB violation")]
        ERROR_HARD_TIMED_APB_VIOLATION = -1204,

        [Category("D016")]
        [Description("Soft timed APB violation")]
        ERROR_SOFT_TIMED_APB_VIOLATION = -1205,

        [Category("D016")]
        [Description("Scheduled lock violation")]
        ERROR_SCHEDULED_LOCK_VIOLATION = -1206,

        [Category("D016")]
        [Description("Scheduled unlock violation")]
        [Obsolete] ERROR_SCHEDULED_UNLOCK_VIOLATION = -1207,

        [Category("D016")]
        [Description("Intrusion alarm violation")]
        ERROR_INTRUSION_ALARM_VIOLATION = -1207,

        [Category("D016")]
        [Description("Set fire alarm")]
        [Obsolete] ERROR_SET_FIRE_ALARM = -1208,

        [Category("D016")]
        [Description("APB zone full")]
        ERROR_APB_ZONE_FULL = -1208,

        [Category("D016")]
        [Description("Timed APB zone full")]
        ERROR_TIMED_APB_ZONE_FULL = -1209,

        [Category("D016")]
        [Description("Fire alarm zone full")]
        ERROR_FIRE_ALARM_ZONE_FULL = -1210,

        [Category("D016")]
        [Description("Scheduled lock unlock zone full")]
        ERROR_SCHEDULED_LOCK_UNLOCK_ZONE_FULL = -1211,

        [Category("D016")]
        [Description("Inactive zone")]
        ERROR_INACTIVE_ZONE = -1212,

        [Category("D016")]
        [Description("Intrusion alarm zone full")]
        ERROR_INTRUSION_ALARM_ZONE_FULL = -1213,

        [Category("D016")]
        [Description("Cannot ARM")]
        ERROR_CANNOT_ARM = -1214,

        [Category("D016")]
        [Description("Cannot disARM")]
        ERROR_CANNOT_DISARM = -1215,

        [Category("D016")]
        [Description("Cannot find ARM card")]
        ERROR_CANNOT_FIND_ARM_CARD = -1216,

        [Category("D016")]
        [Description("Hard entrance limit count violation")]
        ERROR_HARD_ENTRANCE_LIMIT_COUNT_VIOLATION = -1217,

        [Category("D016")]
        [Description("Soft entrance limit count violation")]
        ERROR_SOFT_ENTRANCE_LIMIT_COUNT_VIOLATION = -1218,

        [Category("D016")]
        [Description("Hard entrance limit time violation")]
        ERROR_HARD_ENTRANCE_LIMIT_TIME_VIOLATION = -1219,

        [Category("D016")]
        [Description("Soft entrance limit time violation")]
        ERROR_SOFT_ENTRANCE_LIMIT_TIME_VIOLATION = -1220,

        [Category("D016")]
        [Description("Interlock zone door violation")]
        ERROR_INTERLOCK_ZONE_DOOR_VIOLATION = -1221,

        [Category("D016")]
        [Description("Interlock zone input violation")]
        ERROR_INTERLOCK_ZONE_INPUT_VIOLATION = -1222,

        [Category("D016")]
        [Description("Interlock zone full")]
        ERROR_INTERLOCK_ZONE_FULL = -1223,

        [Category("D016")]
        [Description("Auth limit schedule violation")]
        ERROR_AUTH_LIMIT_SCHEDULE_VIOLATION = -1224,

        [Category("D016")]
        [Description("Auth limit count violation")]
        ERROR_AUTH_LIMIT_COUNT_VIOLATION = -1225,

        [Category("D016")]
        [Description("Auth limit user violation")]
        ERROR_AUTH_LIMIT_USER_VIOLATION = -1226,

        [Category("D016")]
        [Description("Soft auth limit violation")]
        ERROR_SOFT_AUTH_LIMIT_VIOLATION = -1227,

        [Category("D016")]
        [Description("Hard auth limit violation")]
        ERROR_HARD_AUTH_LIMIT_VIOLATION = -1228,

        [Category("D016")]
        [Description("Lift lock unlock zone full")]
        ERROR_LIFT_LOCK_UNLOCK_ZONE_FULL = -1229,

        [Category("D016")]
        [Description("Lift lock violation")]
        ERROR_LIFT_LOCK_VIOLATION = -1230,

        #endregion

        #region [Category Card]

        [Category("D017")]
        [Description("Card IO")]
        ERROR_CARD_IO = -1300,

        [Category("D017")]
        [Description("Card init fail")]
        ERROR_CARD_INIT_FAIL = -1301,

        [Category("D017")]
        [Description("Card not activated")]
        ERROR_CARD_NOT_ACTIVATED = -1302,

        [Category("D017")]
        [Description("Card Cannot read data")]
        ERROR_CARD_CANNOT_READ_DATA = -1303,

        [Category("D017")]
        [Description("Card CLS CRC")]
        ERROR_CARD_CIS_CRC = -1304,

        [Category("D017")]
        [Description("Card cannot write data")]
        ERROR_CARD_CANNOT_WRITE_DATA = -1305,

        [Category("D017")]
        [Description("Card read timeout")]
        ERROR_CARD_READ_TIMEOUT = -1306,

        [Category("D017")]
        [Description("Card read cancelled")]
        ERROR_CARD_READ_CANCELLED = -1307,

        [Category("D017")]
        [Description("Card cannot send data")]
        ERROR_CARD_CANNOT_SEND_DATA = -1308,

        [Category("D017")]
        [Description("Card find card")]
        ERROR_CANNOT_FIND_CARD = -1310,

        #endregion

        #region [Category Operation]

        [Category("D018")]
        [Description("Invalid password")]
        ERROR_INVALID_PASSWORD = -1400,

        #endregion

        #region [Category System]

        [Category("D019")]
        [Description("Camera init fail")]
        ERROR_CAMERA_INIT_FAIL = -1500,

        [Category("D019")]
        [Description("JPEG Encoder init fail")]
        ERROR_JPEG_ENCODER_INIT_FAIL = -1501,

        [Category("D019")]
        [Description("Cannot encode JPEG")]
        ERROR_CANNOT_ENCODE_JPEG = -1502,

        [Category("D019")]
        [Description("JPEG Encoder not initialized")]
        ERROR_JPEG_ENCODER_NOT_INITIALIZED = -1503,

        [Category("D019")]
        [Description("JPEG Encoder deinit fail")]
        ERROR_JPEG_ENCODER_DEINIT_FAIL = -1504,

        [Category("D019")]
        [Description("Camera capture fail")]
        ERROR_CAMERA_CAPTURE_FAIL = -1505,

        [Category("D019")]
        [Description("Cannot detect face")]
        ERROR_CANNOT_DETECT_FACE = -1506,

        #endregion

        #region [Category ETC]

        [Category("D020")]
        [Description("File IO")]
        ERROR_FILE_IO = -2000,

        [Category("D020")]
        [Description("Alloc mem")]
        ERROR_ALLOC_MEM = -2002,

        [Category("D020")]
        [Description("Cannot upgrade")]
        ERROR_CANNOT_UPGRADE = -2003,

        [Category("D020")]
        [Description("Device locked")]
        ERROR_DEVICE_LOCKED = -2004,

        [Category("D020")]
        [Description("Cannot send to server")]
        ERROR_CANNOT_SEND_TO_SERVER = -2005,

        [Category("D020")]
        [Description("Cannot upgrade memory")]
        ERROR_CANNOT_UPGRADE_MEMORY = -2006,

        [Category("D020")]
        [Description("Upgrade not supported")]
        ERROR_UPGRADE_NOT_SUPPORTED = -2007,

        #endregion

        #region [Category SSL]

        //SSL
        [Category("D021")]
        [Description("SSL init")]
        ERROR_SSL_INIT = -3000,

        [Category("D021")]
        [Description("SSL not supported")]
        ERROR_SSL_NOT_SUPPORTED = -3001,

        [Category("D021")]
        [Description("SSL cannot connect")]
        ERROR_SSL_CANNOT_CONNECT = -3002,

        [Category("D021")]
        [Description("SSL already connected")]
        ERROR_SSL_ALREADY_CONNECTED = -3003,

        [Category("D021")]
        [Description("SSL invalid cert")]
        ERROR_SSL_INVALID_CERT = -3004,

        [Category("D021")]
        [Description("SSL verify cert")]
        ERROR_SSL_VERIFY_CERT = -3005,

        [Category("D021")]
        [Description("SSL invalid key")]
        ERROR_SSL_INVALID_KEY = -3006,

        [Category("D021")]
        [Description("SSL verify key")]
        ERROR_SSL_VERIFY_KEY = -3007,

        #endregion

        #region [Category Mobile access]

        [Category("D022")]
        [Description("Mobile portal")]
        ERROR_MOBILE_PORTAL = -3100,

        #endregion

        #region [Category OSDP]

        [Category("D023")]
        [Description("Not OSDP standard channel")]
        ERROR_NOT_OSDP_STANDARD_CHANNEL = -4001,

        [Category("D023")]
        [Description("Already full slaved")]
        ERROR_ALREADY_FULL_SLAVES = -4002,

        [Category("D023")]
        [Description("Duplicate OSDP id")]
        ERROR_DUPLICATE_OSDP_ID = -4003,

        [Category("D023")]
        [Description("Fail add OSDP device")]
        ERROR_FAIL_ADD_OSDP_DEVICE = -4004,

        [Category("D023")]
        [Description("Fail update OSDP device")]
        ERROR_FAIL_UPDATE_OSDP_DEVICE = -4005,

        [Category("D023")]
        [Description("Invalid OSDP device id")]
        ERROR_INVALID_OSDP_DEVICE_ID = -4006,

        [Category("D023")]
        [Description("Fail master set key")]
        ERROR_FAIL_MASTER_SET_KEY = -4007,

        [Category("D023")]
        [Description("Fail slave set key")]
        ERROR_FAIL_SLAVE_SET_KEY = -4008,

        [Category("D023")]
        [Description("Disconnect slave device")]
        ERROR_DISCONNECT_SLAVE_DEVICE = -4009,

        #endregion

        #region [Category license]

        [Category("D024")]
        [Description("No license")]
        ERROR_NO_LICENSE = -4010,

        [Category("D024")]
        [Description("License CRC")]
        ERROR_LICENSE_CRC = -4011,

        [Category("D024")]
        [Description("License file not valid")]
        ERROR_LICENSE_FILE_NOT_VALID = -4012,

        [Category("D024")]
        [Description("License payload length")]
        ERROR_LICENSE_PAYLOAD_LENGTH = -4013,

        [Category("D024")]
        [Description("License parring json")]
        ERROR_LICENSE_PARRING_JSON = -4014,

        [Category("D024")]
        [Description("License json format")]
        ERROR_LICENSE_JSON_FORMAT = -4015,

        [Category("D024")]
        [Description("License enable partial")]
        ERROR_LICENSE_ENABLE_PARTIAL = -4016,

        [Category("D024")]
        [Description("License no match device")]
        ERROR_LICENSE_NO_MATCH_DEVICE = -4017,

        #endregion

        #region [Category Common]

        [Category("D025")]
        [Description("Null pointer")]
        ERROR_NULL_POINTER = -10000,

        [Category("D025")]
        [Description("Uninitialized")]
        ERROR_UNINITIALIZED = -10001,

        [Category("D025")]
        [Description("Cannot run service")]
        ERROR_CANNOT_RUN_SERVICE = -10002,

        [Category("D025")]
        [Description("Canceled")]
        ERROR_CANCELED = -10003,

        [Category("D025")]
        [Description("Exist")]
        ERROR_EXIST = -10004,

        [Category("D025")]
        [Description("Encrypt")]
        ERROR_ENCRYPT = -10005,

        [Category("D025")]
        [Description("Decrypt")]
        ERROR_DECRYPT = -10006,

        [Category("D025")]
        [Description("Device busy")]
        ERROR_DEVICE_BUSY = -10007,

        [Category("D025")]
        [Description("Internal")]
        ERROR_INTERNAL = -10008,

        [Category("D025")]
        [Description("Invalid file format")]
        ERROR_INVALID_FILE_FORMAT = -10009,

        [Category("D025")]
        [Description("Invalid schedule id")]
        ERROR_INVALID_SCHEDULE_ID = -10010,

        [Category("D025")]
        [Description("Unknown finger template")]
        ERROR_UNKNOWN_FINGER_TEMPLATE = -10011,

        #endregion
    }
}
