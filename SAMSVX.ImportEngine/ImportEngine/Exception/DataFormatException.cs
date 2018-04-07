using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMSVX.ImportEngine
{
    /// <summary>
    /// 잘못 된 형식의 데이터를 입력하였을 때 발생하는 예외입니다.
    /// </summary>
    public class DataFormatException : Exception
    {
        private int row;
        private int column;

        public DataFormatException(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public override string Message
        {
            get
            {
                return "The data has been entered in the wrong format.";
            }
        }

        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }
        public int Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
            }
        }
    }
}
