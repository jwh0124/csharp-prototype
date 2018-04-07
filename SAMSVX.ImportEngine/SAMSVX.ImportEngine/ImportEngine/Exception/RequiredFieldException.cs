using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMSVX.ImportEngine
{
    /// <summary>
    /// 필수 항목이 입력되지 않았을 때 발생하는 예외입니다.
    /// </summary>
    public class RequiredFieldException : Exception
    {
        int row;
        int column;

        public RequiredFieldException(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public override string Message
        {
            get { return "Did not ented the required fields."; }
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
