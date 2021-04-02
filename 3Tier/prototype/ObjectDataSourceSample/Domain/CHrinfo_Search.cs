using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class CHrinfo_Search : CHrinfo
    {
        int _startRecord;
        int _maxRecords;
        string _sortColumns;
        string _seq_criteria;
        string _emp_no_criteria;
        string _emp_nm_criteria;
        string _phone_no_criteria;
        string _sex_criteria;
        string _remarks_criteria;

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
        public string Emp_no_criteria
        {
            get { return _emp_no_criteria; }
            set { _emp_no_criteria = value; }
        }
        public string Emp_nm_criteria
        {
            get { return _emp_nm_criteria; }
            set { _emp_nm_criteria = value; }
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
        public string Remarks_criteria
        {
            get { return _remarks_criteria; }
            set { _remarks_criteria = value; }
        }            
            
            
            
            
            

            
            


    }   
}
