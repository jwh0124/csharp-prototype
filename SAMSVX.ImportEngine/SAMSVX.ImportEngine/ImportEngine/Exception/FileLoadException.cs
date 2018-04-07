using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMSVX.ImportEngine
{
    /// <summary>
    /// 잘못 된 경로의 파일을 읽어들일 때 발생하는 예외입니다.
    /// </summary>
    public class FileLoadException : Exception
    {
        public FileLoadException()
            : base() { }

        public FileLoadException(string message)
            : base(message) { }

        public FileLoadException(string message, Exception exception)
            : base(message, exception) { }
    }
}
