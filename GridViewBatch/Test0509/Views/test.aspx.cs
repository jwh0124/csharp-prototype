using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test0509.Xpo;
using DevExpress.Web.ASPxGridView;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Test0509.Views
{
    public partial class test : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString_Test"].ConnectionString;
        DevExpress.Xpo.Session XpoSession;
        protected void Page_Init(object sender, EventArgs e)
        {
            XpoSession = XpoHelper.GetNewSessionINTF();
            XpoDataSource1.Session = XpoSession;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ASPxGridView1_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            e.Handled = true;

            foreach (var updateValue in e.UpdateValues)
            {
                int index = grid.FindVisibleIndexByKeyValue(updateValue.Keys["Seq"]);
                int seq = (int)grid.GetRowValues(index, "Seq");
                string emp_nm = updateValue.NewValues.Contains("Print_emp_nm") ? Convert.ToString(updateValue.NewValues["Print_emp_nm"]) : Convert.ToString(updateValue.OldValues["Print_emp_nm"]);
                string emp_enm = updateValue.NewValues.Contains("Print_emp_enm") ? Convert.ToString(updateValue.NewValues["Print_emp_enm"]) : Convert.ToString(updateValue.OldValues["Print_emp_enm"]);
                string comp_nm = updateValue.NewValues.Contains("Print_comp_nm") ? Convert.ToString(updateValue.NewValues["Print_comp_nm"]) : Convert.ToString(updateValue.OldValues["Print_comp_nm"]);
                string dept_nm = updateValue.NewValues.Contains("Print_dept_nm") ? Convert.ToString(updateValue.NewValues["Print_dept_nm"]) : Convert.ToString(updateValue.OldValues["Print_dept_nm"]);
                string posi_nm = updateValue.NewValues.Contains("Print_posi_nm") ? Convert.ToString(updateValue.NewValues["Print_posi_nm"]) : Convert.ToString(updateValue.OldValues["Print_posi_nm"]);

                using (UnitOfWork uow = XpoHelper.GetNewUnitOfWorkINTF())
                {
                    CriteriaOperator op = CriteriaOperator.Parse("Seq=?", seq);
                    CardApprovalEntity Xpo = uow.FindObject<CardApprovalEntity>(op);

                    
                    Xpo.Print_emp_nm = emp_nm;
                    Xpo.Print_emp_enm = emp_enm;
                    Xpo.Print_comp_nm = comp_nm;
                    Xpo.Print_dept_nm = dept_nm;
                    Xpo.Print_posi_nm = posi_nm;
                    Xpo.Seq = seq;

                    Xpo.Save();
                    uow.CommitChanges();
                }           
            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                SqlTransaction trans = new SqlTransaction();

                cmd.Connection = conn;
                cmd.Transaction = trans;

                cmd.CommandText = "INSERT INTO tbl_transTest (id,update) VALUES ('jwh',getdate())";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                trans.Commit();
            }
        }
    }
}