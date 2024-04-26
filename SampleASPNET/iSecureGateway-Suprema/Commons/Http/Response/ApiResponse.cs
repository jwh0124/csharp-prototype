using System.ComponentModel;

namespace iSecureGateway_Suprema.Commons.Http.Response
{
    public enum ApiResponse
    {
        [Category("A001")]
        [Description("Success")]
        SUCCESS,

        [Category("A002")]
        [Description("Bad request")]
        BAD_REQUEST,

        [Category("A002")]
        [Description("Not found")]
        NOT_FOUND,

        [Category("A002")]
        [Description("Required field error")]
        REQUIRED_FIELD,

        [Category("A002")]
        [Description("Duplicate key")]
        DUPLICATE_KEY,

        [Category("A002")]
        [Description("Not found child value")]
        NOT_FOUND_CHILD_VALUE,

        [Category("A003")]
        [Description("System error")]
        SYSTEM_ERROR
    }
}
