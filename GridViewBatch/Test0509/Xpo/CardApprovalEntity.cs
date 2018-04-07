using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Xpo;

namespace Test0509.Xpo
{
    [Persistent("tbl_intf_hrinfo")]
    class CardApprovalEntity : XPLiteObject
    {
        int seq_;      
        string print_emp_nm_;
        string print_emp_enm_;
        string print_comp_nm_;
        string print_dept_nm_;
        string print_posi_nm_;

        public CardApprovalEntity(Session session)
            : base(session) { }

        [Key(true)]
        [Persistent("seq")]
        public int Seq
        {
            get { return seq_; }
            set { seq_ = value; }
        }
        [Persistent("print_emp_nm")]
        public string Print_emp_nm
        {
            get { return print_emp_nm_; }
            set { print_emp_nm_ = value; }
        }
        [Persistent("print_emp_enm")]
        public string Print_emp_enm
        {
            get { return print_emp_enm_; }
            set { print_emp_enm_ = value; }
        }

        [Persistent("print_comp_nm")]
        public string Print_comp_nm
        {
            get { return print_comp_nm_; }
            set { print_comp_nm_ = value; }
        }

        [Persistent("print_dept_nm")]
        public string Print_dept_nm
        {
            get { return print_dept_nm_; }
            set { print_dept_nm_ = value; }
        }

        [Persistent("print_posi_nm")]
        public string Print_posi_nm
        {
            get { return print_posi_nm_; }
            set { print_posi_nm_ = value; }
        }
    }
}
