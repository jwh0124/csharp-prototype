using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsTest.FormControl
{
    public partial class PreferenceForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string programPath = ConfigurationManager.AppSettings.Get("ProgramPath");
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);


        public PreferenceForm()
        {
            InitializeComponent();
        }

        private void PreferenceForm_Load(object sender, EventArgs e)
        {
            try
            {
                string[] connectionStringInfo = connectionString.Split(';');
                string[] connectionServerInfo = connectionStringInfo[0].Split('=');
                string[] connectionIdInfo = connectionStringInfo[1].Split('=');
                string[] connectionPasswordInfo = connectionStringInfo[2].Split('=');
                string[] connectionDataBase = connectionStringInfo[3].Split('=');
                string serverInfo = connectionServerInfo[1];
                string dataBaseInfo = connectionDataBase[1];
                string idInfo = connectionIdInfo[1];
                string passwordInfo = connectionPasswordInfo[1];

                txt_Server.Text = serverInfo;
                txt_DataBase.Text = dataBaseInfo;
                txt_Id.Text = idInfo;
                txt_Password.Text = passwordInfo;
                txt_ProgramPath.Text = programPath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                string newConnectionString = string.Format(@"SERVER={0};UID={1};PWD={2};DATABASE={3}"
                                                            , txt_Server.Text, txt_Id.Text, txt_Password.Text, txt_DataBase.Text);
                string newProgramPath = txt_ProgramPath.Text;

                config.ConnectionStrings.ConnectionStrings["ConnectionString"].ConnectionString = newConnectionString;
                config.AppSettings.Settings["ProgramPath"].Value = newProgramPath;
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("appSettings");
                ConfigurationManager.RefreshSection("connectionStrings");

                MessageBox.Show("저장되었습니다");
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("저장에 실패했습니다. \n 실패 : {0}"),ex.Message);
            }
            
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
