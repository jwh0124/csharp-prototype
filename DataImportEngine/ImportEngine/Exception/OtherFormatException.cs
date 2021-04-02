using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMSVX.ImportEngine
{
    /// <summary>
    /// 다른 형식의 파일을 읽어들일 때 발생하는 예외입니다.
    /// </summary>
    public class OtherFormatException : Exception
    {
        public OtherFormatException()
            : base() { }

        public OtherFormatException(string message)
            : base(message) { }

        public OtherFormatException(string message, Exception exception)
            : base(message, exception) { }

        public override string Message
        {
            get
            {
                return "It is not possible to load the files of other formats.";
            }
        }
    }
}
