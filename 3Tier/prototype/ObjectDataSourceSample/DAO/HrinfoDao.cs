using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using Domain;

namespace DAO
{
    public class HrinfoDao : IHrinfoDao
    {
        #region 연결정보
        private string connectionString = @"SERVER=.\SAMSVX;UID=sa;PWD=3919;DATABASE=TmpDB"; 
        #endregion

        #region 데이터 검색 파트
        public List<CHrinfo> getHrinfoList(Int32 startRecord, Int32 maxRecords, String sortColumns)
        {
            VerifySortColumns(sortColumns);
            String sqlColumns = "[seq], [emp_no], [emp_nm], [phone_no], [sex], [remarks]";
            String sqlTable = "[tbl_hrinfo]";
            String sqlSortColumn = "[seq]";

            if (!String.IsNullOrEmpty(sortColumns))
                sqlSortColumn = sortColumns;

            String sqlCommand = String.Format(
               "SELECT * FROM (" +
               "    SELECT ROW_NUMBER() OVER (ORDER BY {0}) AS rownumber," +
               "        {1}" +
               "    FROM {2}" +
               ") AS foo " +
               "WHERE rownumber >= {3} AND rownumber <= {4}",
               sqlSortColumn,
               sqlColumns,
               sqlTable,
               startRecord + 1, startRecord + maxRecords
            );
            List<CHrinfo> result = getList(sqlCommand);

            return result;
        } 
        #endregion

        #region 데이터 삽입 파트
        public void SetHrinfoList(CHrinfo hrinfo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = string.Format(
                    @"
                        INSERT INTO tbl_hrinfo (emp_no, emp_nm, phone_no, sex, remarks)
                        VALUES('{0}', '{1}', '{2}', '{3}', '{4}')
                    ", hrinfo.Emp_no, hrinfo.Emp_nm, hrinfo.Phone_no, hrinfo.Sex, hrinfo.Remarks);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;

                int cnt = cmd.ExecuteNonQuery();
            }

        } 
        #endregion

        #region 데이터 삭제 파트
        public void DelHrinfoList(CHrinfo hrinfo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = string.Format(
                    @"
                      DELETE FROM [tbl_hrinfo] WHERE Seq ='{0}' ", hrinfo.Seq);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;

                int cnt = cmd.ExecuteNonQuery();
            }
        } 
        #endregion

        #region 데이터 수정 파트
        public void UpHrinfoList(CHrinfo hrinfo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string query = string.Format(
                    @"
                        UPDATE [tbl_hrinfo]
                        SET [Emp_no] = '{0}',
                            [Emp_nm] = '{1}',
                            [Phone_no] = '{2}',
                            [Sex] = '{3}',
                            [Remarks] = '{4}'
                        WHERE Seq = '{5}' 
                    ", hrinfo.Emp_no, hrinfo.Emp_nm, hrinfo.Phone_no, hrinfo.Sex, hrinfo.Remarks, hrinfo.Seq);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;

                int cnt = cmd.ExecuteNonQuery();
            }
        } 
        #endregion

        #region 데이터 정렬 파트
        private static void VerifySortColumns(string sortColumns)
        {
            sortColumns = sortColumns.ToLowerInvariant().Replace(" asc", String.Empty).Replace(" desc", String.Empty);
            String[] columnNames = sortColumns.Split(',');

            foreach (String columnName in columnNames)
            {
                switch (columnName.Trim().ToLowerInvariant())
                {
                    case "seq":
                    case "emp_no":
                    case "emp_nm":
                    case "phone_no":
                    case "sex":
                    case "remarks":
                    case "":
                        break;
                    default:
                        throw new ArgumentException("SortColumns contains an invalid column name.");
                }
            }
        } 
        #endregion

        #region 레코드 수 구하는 파트
        public Int32 GetListCount()
        {

            string sqlCommand = "SELECT COUNT ([seq]) FROM [tbl_hrinfo]";

            SqlConnection conn = new SqlConnection(connectionString);

            SqlDataAdapter adt = new SqlDataAdapter(sqlCommand, conn);

            SqlCommand command = new SqlCommand(sqlCommand, conn);
            Int32 result = 0;

            try
            {
                conn.Open();
                result = (Int32)command.ExecuteScalar();
            }
            catch (SqlException)
            {
                // Handle exception.
            }
            finally
            {
                conn.Close();
            }

            return result;

            //SqlDataAdapter da = new SqlDataAdapter(sqlCommand, conn);
        } 
        #endregion

        #region 데이터를 바인딩 파트
        private List<CHrinfo> getList(string sqlCommand)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adt = new SqlDataAdapter(sqlCommand, conn))
                {
                    adt.Fill(dt);
                }
            }

            List<CHrinfo> result = new List<CHrinfo>();
            foreach (DataRow row in dt.Rows)
            {
                CHrinfo hrinfo = new CHrinfo()
                {
                    Seq = int.Parse(row["seq"].ToString()),
                    Emp_no = row["emp_no"].ToString(),
                    Emp_nm = row["emp_nm"].ToString(),
                    Phone_no = row["phone_no"].ToString(),
                    Sex = row["sex"].ToString(),
                    Remarks = row["remarks"].ToString()
                };

                result.Add(hrinfo);
            }

            return result;
        }
        
        #endregion
        }
    }

