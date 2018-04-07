using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using System.Configuration;
using TestWebService.Common;

namespace TestWebService
{
    /// <summary>
    /// WebService1의 요약 설명입니다.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // ASP.NET AJAX를 사용하여 스크립트에서 이 웹 서비스를 호출하려면 다음 줄의 주석 처리를 제거합니다. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["IOMS_ConnectionString"].ConnectionString;
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<UserInfo> GetCardtoEmpNo(string card_no)
        {
            string query = string.Format("SELECT emp_no,emp_nm,company_cd,department_cd,position_cd FROM vw_cards WHERE card_no='{0}'", card_no);
            DataTable dt = DBHandler.GetDataTable(query, connectionString);
            List<UserInfo> userInfo = new List<UserInfo>();
            foreach (DataRow row in dt.Rows)
            {
                userInfo.Add(new UserInfo
                {
                    emp_no = row["emp_no"].ToString(),
                    emp_nm = row["emp_nm"].ToString(),
                    comp_cd = row["company_cd"].ToString(),
                    dept_cd = row["department_cd"].ToString(),
                    posi_cd = row["position_cd"].ToString()
                });
            }
            return userInfo;
        }

        public class UserInfo
        {
            public string emp_no;
            public string emp_nm;
            public string comp_cd;
            public string dept_cd;
            public string posi_cd;
        }
    }
}
