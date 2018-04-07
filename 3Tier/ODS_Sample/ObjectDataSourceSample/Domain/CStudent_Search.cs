using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class CStudent_Search : CStudent
    {
        int _startRecord;
        int _maxRecords;
        string _sortColumns;
        string _seq_criteria;
        string _stu_no_criteria;
        string _stu_nm_criteria;
        string _phone_no_criteria;
        string _sex_criteria;

        public int StartRecord
        {
            get { return _startRecord; }
            set { _startRecord = value; }
        }
        public int MaxRecords
        {
            get { return _maxRecords; }
            set { _maxRecords = value; }
        }
        public string SortColumns
        {
            get { return _sortColumns; }
            set { _sortColumns = value; }
        }
        public string Seq_criteria
        {
            get { return _seq_criteria; }
            set { _seq_criteria = value; }
        }
        public string Stu_no_criteria
        {
            get { return _stu_no_criteria; }
            set { _stu_no_criteria = value; }
        }
        public string Stu_nm_criteria
        {
            get { return _stu_nm_criteria; }
            set { _stu_nm_criteria = value; }
        }
        public string Phone_no_criteria
        {
            get { return _phone_no_criteria; }
            set { _phone_no_criteria = value; }
        }
        public string Sex_criteria
        {
            get { return _sex_criteria; }
            set { _sex_criteria = value; }
        }
   
                 
    }
}
