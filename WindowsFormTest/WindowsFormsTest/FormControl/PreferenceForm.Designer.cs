namespace WindowsFormsTest.FormControl
{
    partial class PreferenceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Server = new System.Windows.Forms.TextBox();
            this.txt_DataBase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_HistDB = new System.Windows.Forms.TabPage();
            this.tab_LogFile = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ProgramPath = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tab_HistDB.SuspendLayout();
            this.tab_LogFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(216, 236);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 25);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.Text = "저장";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(296, 236);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 25);
            this.btn_Cancel.TabIndex = 14;
            this.btn_Cancel.Text = "취소";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "IP주소";
            // 
            // txt_Server
            // 
            this.txt_Server.Location = new System.Drawing.Point(145, 100);
            this.txt_Server.MaxLength = 100;
            this.txt_Server.Name = "txt_Server";
            this.txt_Server.Size = new System.Drawing.Size(160, 21);
            this.txt_Server.TabIndex = 16;
            // 
            // txt_DataBase
            // 
            this.txt_DataBase.Location = new System.Drawing.Point(145, 131);
            this.txt_DataBase.MaxLength = 100;
            this.txt_DataBase.Name = "txt_DataBase";
            this.txt_DataBase.Size = new System.Drawing.Size(160, 21);
            this.txt_DataBase.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "데이터베이스명";
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(145, 68);
            this.txt_Password.MaxLength = 100;
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(160, 21);
            this.txt_Password.TabIndex = 22;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "Password";
            // 
            // txt_Id
            // 
            this.txt_Id.Location = new System.Drawing.Point(145, 37);
            this.txt_Id.MaxLength = 100;
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.Size = new System.Drawing.Size(160, 21);
            this.txt_Id.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "ID";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_HistDB);
            this.tabControl1.Controls.Add(this.tab_LogFile);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(361, 218);
            this.tabControl1.TabIndex = 23;
            // 
            // tab_HistDB
            // 
            this.tab_HistDB.Controls.Add(this.label4);
            this.tab_HistDB.Controls.Add(this.txt_Password);
            this.tab_HistDB.Controls.Add(this.label1);
            this.tab_HistDB.Controls.Add(this.label3);
            this.tab_HistDB.Controls.Add(this.txt_Server);
            this.tab_HistDB.Controls.Add(this.txt_Id);
            this.tab_HistDB.Controls.Add(this.label2);
            this.tab_HistDB.Controls.Add(this.txt_DataBase);
            this.tab_HistDB.Location = new System.Drawing.Point(4, 22);
            this.tab_HistDB.Name = "tab_HistDB";
            this.tab_HistDB.Padding = new System.Windows.Forms.Padding(3);
            this.tab_HistDB.Size = new System.Drawing.Size(353, 192);
            this.tab_HistDB.TabIndex = 0;
            this.tab_HistDB.Text = "이력 데이터";
            this.tab_HistDB.UseVisualStyleBackColor = true;
            // 
            // tab_LogFile
            // 
            this.tab_LogFile.Controls.Add(this.txt_ProgramPath);
            this.tab_LogFile.Controls.Add(this.label5);
            this.tab_LogFile.Location = new System.Drawing.Point(4, 22);
            this.tab_LogFile.Name = "tab_LogFile";
            this.tab_LogFile.Padding = new System.Windows.Forms.Padding(3);
            this.tab_LogFile.Size = new System.Drawing.Size(353, 192);
            this.tab_LogFile.TabIndex = 1;
            this.tab_LogFile.Text = "Log 파일";
            this.tab_LogFile.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "프로그램 설치 경로";
            // 
            // txt_ProgramPath
            // 
            this.txt_ProgramPath.Location = new System.Drawing.Point(155, 84);
            this.txt_ProgramPath.Name = "txt_ProgramPath";
            this.txt_ProgramPath.Size = new System.Drawing.Size(160, 21);
            this.txt_ProgramPath.TabIndex = 1;
            // 
            // PreferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 274);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Name = "PreferenceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "환경설정";
            this.Load += new System.EventHandler(this.PreferenceForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_HistDB.ResumeLayout(false);
            this.tab_HistDB.PerformLayout();
            this.tab_LogFile.ResumeLayout(false);
            this.tab_LogFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Server;
        private System.Windows.Forms.TextBox txt_DataBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_HistDB;
        private System.Windows.Forms.TabPage tab_LogFile;
        private System.Windows.Forms.TextBox txt_ProgramPath;
        private System.Windows.Forms.Label label5;
    }
}