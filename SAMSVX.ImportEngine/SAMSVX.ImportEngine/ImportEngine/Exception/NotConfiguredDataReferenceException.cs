using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMSVX.ImportEngine
{
    /// <summary>
    /// 구성되지 않은 데이터를 참조할 때 발생하는 예외입니다.
    /// </summary>
    public class NotConfiguredDataReferenceException : Exception
    {
        int row;
        int column;

        public NotConfiguredDataReferenceException(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public override string Message
        {
            get { return "Reference data is not configured."; }
        }

        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        public int Column
        {
            get { return column; }
            set { column = value; }
        }
    }
}
