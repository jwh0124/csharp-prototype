using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class CHrinfo
    {
        int _seq;
        string _emp_no;
        string _emp_nm;
        string _phone_no;
        string _sex;
        string _remarks;

        public int Seq
        {
            get { return _seq; }
            set { _seq = value; }
        }

        public string Emp_no
        {
            get { return _emp_no; }
            set { _emp_no = value; }
        }

        public string Emp_nm
        {
            get { return _emp_nm; }
            set { _emp_nm = value; }
        }

        public string Phone_no
        {
            get { return _phone_no; }
            set { _phone_no = value; }
        }

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
    }
}
