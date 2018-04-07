using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using WindowsFormsTest.FormControl;


namespace WindowsFormsTest
{
    public partial class TestWindowsForms : System.Windows.Forms.Form
    {
        ListBinding listBinding;
        int listIndex = 0;

        public TestWindowsForms()
        {
            InitializeComponent();
        }

        private void TestWindowsForms_Load(object sender, EventArgs e)
        {
            SetPreferenceReset();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            GetData(listIndex);
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            SetPreferenceReset();
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if (HistManageGrid.CurrentRow != null)
            {
                MessageBox.Show("적용되었습니다.");
                SetPreferenceReset();
            }
            else
            {
                MessageBox.Show("적용할 데이터를 선택해 주세요.");
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("프로그램이 종료됩니다.");
            Application.Exit();
        }

        private void GetData(int listIndex)
        {
            HistManageGrid.Rows.Clear();
            try
            {
                DataTable tableDt = new DataTable();
                listBinding = new ListBinding();

                switch (listIndex)
                {
                    case 0:
                        tableDt = listBinding.TableHistDataBind(tableDt);
                        break;
                    case 1:
                        tableDt = listBinding.LogFileDataBind(tableDt);
                        break;
                    default:
                        break;
                }
                foreach (DataRow row in tableDt.Rows)
                {
                    int n = HistManageGrid.Rows.Add();
                    HistManageGrid.Rows[n].Cells[1].Value = row["name"].ToString();
                }
                HistManageGrid.CurrentCell = null;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private void cmb_HistoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            listIndex = cmb_HistoryList.SelectedIndex;

            //switch (listIndex)
            //{
            //    case 0:
            //        SetTableHistListSetting();
            //        break;
            //    default:
            //        SetLogFileListSetting();
            //        break;
            //}
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PreferenceForm preferenceForm = new PreferenceForm();
            preferenceForm.Show();
        }

        private void SetPreferenceReset()
        {
            cmb_HistoryList.SelectedIndex = 0;
            cmb_ManageList.SelectedIndex = 0;
            startDateTime.Value = DateTime.Now;
            endDateTime.Value = DateTime.Now;
            this.HistManageGrid.ClearSelection();
            this.HistManageGrid.Rows.Clear();
        }

        //private void SetTableHistListSetting()
        //{
        //    startDateTime.Format = DateTimePickerFormat.Custom;
        //    endDateTime.Format = DateTimePickerFormat.Custom;
        //    startDateTime.ShowUpDown = true;
        //    endDateTime.ShowUpDown = true;
        //}

        //private void SetLogFileListSetting()
        //{
        //    startDateTime.Format = DateTimePickerFormat.Short;
        //    endDateTime.Format = DateTimePickerFormat.Short;
        //    startDateTime.ShowUpDown = false;
        //    endDateTime.ShowUpDown = false;
        //}

        private void HistManageGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool selectValue = (bool)HistManageGrid.Rows[e.RowIndex].Cells["SelectColumn"].EditedFormattedValue;
            HistManageGrid.CurrentCell = null;

            if (selectValue)
                HistManageGrid.Rows[e.RowIndex].Cells["NewName"].ReadOnly = false;
            else
                HistManageGrid.Rows[e.RowIndex].Cells["NewName"].ReadOnly = true;
        }
    }
}
