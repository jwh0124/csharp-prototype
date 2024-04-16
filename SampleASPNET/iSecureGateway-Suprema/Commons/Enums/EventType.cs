using System.ComponentModel;

namespace iSecureGateway_Suprema.Commons.Enums
{
    public enum AccessEventType
    {
        [Description("Not Management Access Type")]
        NOT_MANAGEMENT_TYPE = 0,

        [Description("Grant access - Card")]
        GRANT_CARD = 1,

        [Description("Grant access - Finger")]
        GRANT_FINGER = 2,

        [Description("Grant access - Finger&PIN")]
        GRANT_FINGER_AND_PIN = 3,

        [Description("Grant access - Face")]
        GRANT_FACE = 4,

        [Description("Grant access - Face&PIN")]
        GRANT_FACE_AND_PIN = 5,

        [Description("Grant access - Card&PIN")]
        GRANT_CARD_AND_PIN = 6,

        [Description("Grant access - Card&Finger")]
        GRANT_CARD_AND_FINGER = 7,

        [Description("Grant access - Card&Finger&PIN")]
        GRANT_CARD_AND_FINGER_AND_PIN = 8,

        [Description("Grant access - Card&Face")]
        GRANT_CARD_AND_FACE = 9,

        [Description("Grant access - Card&Face&PIN")]
        GRANT_CARD_AND_FACE_AND_PIN = 10,

        [Description("Grant access - Duress Card")]
        GRANT_DURESS_CARD = 11,

        [Description("Grant access - Duress Card&PIN")]
        GRANT_DURESS_CARD_AND_PIN = 12,

        [Description("Grant access - Duress Card&Finger")]
        GRANT_DURESS_CARD_AND_FINGER = 13,

        [Description("Grant access - Duress Card&Finger&PIN")]
        GRANT_DURESS_CARD_AND_FINGER_AND_PIN = 14,

        [Description("Grant access - Duress Card&Face")]
        GRANT_DURESS_CARD_AND_FACE = 15,

        [Description("Grant access - Duress Card&Face&PIN")]
        GRANT_DURESS_CARD_AND_FACE_AND_PIN = 16,

        [Description("Grant access - Duress Finger")]
        GRANT_DURESS_FINGER = 17,

        [Description("Grant access - Duress Finger&PIN")]
        GRANT_DURESS_FINGER_AND_PIN = 18,

        [Description("Grant access - Duress Face")]
        GRANT_DURESS_FACE = 19,

        [Description("Grant access - Duress Face&PIN")]
        GRANT_DURESS_FACE_AND_PIN = 20,

        [Description("Deny access - Card/PIN not found")]
        DENY_NOT_FOUND_CARD_AND_PIN = 21,

        [Description("Deny access - Door group/schedule not configured")]
        DENY_NOT_CONFIG_DOOR_GROUP_SCHEDULE = 22,

        [Description("Deny access - Not active")]
        DENY_NOT_ACTIVE = 23,

        [Description("Deny access - Scheduled lock")]
        DENY_SCHEDULED_LOCK = 24,

        [Description("Deny access - Face detection")]
        DENY_FACE_DETECTION = 25,

        [Description("Deny access - Camera capture")]
        DENY_CAMERA_CAPTURE = 26,

        [Description("Deny access - Fake finger")]
        DENY_FAKE_FINGER = 27,

        [Description("Deny access - Finger")]
        DENY_FINGER = 28,

        [Description("Deny access - Face")]
        DENY_FACE = 29,

        [Description("Deny access - Invalid auth mode")]
        DENY_INVALID_AUTH_MODE = 30,

        [Description("Deny access - Invalid credential")]
        DENY_INVALID_CREDENTIAL = 31,

        [Description("Deny access - Timeout")]
        DENY_TIMEOUT = 32,

        [Description("Deny access - Matching refusal")]
        DENY_MATCHING_REFUSAL = 33
    }

    public enum DoorEventType
    {
        [Description("Door status")]
        DOOR_STATUS = 0,

        [Description("Door alarm")]
        DOOR_ALARM = 1,

        [Description("Door schedule")]
        DOOR_SCHEDULE = 2,

        [Description("Door operation")]
        DOOR_OPERATION = 3,

        [Description("Door emergency")]
        DOOR_EMERGENCY = 4
    }
}
