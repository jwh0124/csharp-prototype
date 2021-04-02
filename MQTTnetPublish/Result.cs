using System;
using System.Collections.Generic;
using System.Text;

namespace MQTTPublishPrototype
{
    public class Result
    {
        public string UserNo { get; set; }

        public string UserName { get; set; }

        public bool authResult { get; set; }

        public int count { get; set; }
    }
}
