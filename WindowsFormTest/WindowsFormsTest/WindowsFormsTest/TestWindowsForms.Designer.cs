namespace WindowsFormsTest
{
    partial class TestWindowsForms
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.HistManageGrid = new System.Windows.Forms.DataGridView();
            this.SelectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.startDateTime = new System.Windows.Forms.DateTimePicker();
            this.cmb_ManageList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.endDateTime = new System.Windows.Forms.DateTimePicker();
            this.cmb_HistoryList = new System.Windows.Forms.ComboBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.환경설정ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.HistManageGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HistManageGrid
            // 
            this.HistManageGrid.AllowUserToAddRows = false;
            this.HistManageGrid.AllowUserToDeleteRows = false;
            this.HistManageGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.HistManageGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.HistManageGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectColumn,
            this.NameColumn,
            this.NewName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HistManageGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.HistManageGrid.Location = new System.Drawing.Point(10, 20);
            this.HistManageGrid.Name = "HistManageGrid";
            this.HistManageGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.HistManageGrid.RowHeadersVisible = false;
            this.HistManageGrid.RowTemplate.Height = 23;
            this.HistManageGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HistManageGrid.Size = new System.Drawing.Size(461, 249);
            this.HistManageGrid.TabIndex = 0;
            this.HistManageGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.HistManageGrid_CellContentClick);
            // 
            // SelectColumn
            // 
            this.SelectColumn.DataPropertyName = "SelectColumn";
            this.SelectColumn.FalseValue = "0";
            this.SelectColumn.FillWeight = 31.40176F;
            this.SelectColumn.HeaderText = "선택";
            this.SelectColumn.Name = "SelectColumn";
            this.SelectColumn.TrueValue = "1";
            this.SelectColumn.Width = 48;
            // 
            // NameColumn
            // 
            this.NameColumn.FillWeight = 134.0102F;
            this.NameColumn.HeaderText = "명칭";
            this.NameColumn.MaxInputLength = 100;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 205;
            // 
            // NewName
            // 
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.NewName.DefaultCellStyle = dataGridViewCellStyle1;
            this.NewName.FillWeight = 134.5881F;
            this.NewName.HeaderText = "신규 명칭";
            this.NewName.MaxInputLength = 100;
            this.NewName.Name = "NewName";
            this.NewName.ReadOnly = true;
            this.NewName.Width = 205;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 441);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "History 관리";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "관리 항목";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "~";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "적용 일자";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.HistManageGrid);
            this.groupBox3.Location = new System.Drawing.Point(14, 155);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(482, 275);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "리스트";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.startDateTime);
            this.groupBox2.Controls.Add(this.cmb_ManageList);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.endDateTime);
            this.groupBox2.Controls.Add(this.cmb_HistoryList);
            this.groupBox2.Controls.Add(this.btn_Search);
            this.groupBox2.Location = new System.Drawing.Point(14, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "사용자 설정";
            // 
            // startDateTime
            // 
            this.startDateTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.startDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateTime.Location = new System.Drawing.Point(79, 58);
            this.startDateTime.Name = "startDateTime";
            this.startDateTime.Size = new System.Drawing.Size(177, 21);
            this.startDateTime.TabIndex = 5;
            // 
            // cmb_ManageList
            // 
            this.cmb_ManageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ManageList.FormattingEnabled = true;
            this.cmb_ManageList.Items.AddRange(new object[] {
            "데이터 이관",
            "파일 이관",
            "삭제"});
            this.cmb_ManageList.Location = new System.Drawing.Point(346, 25);
            this.cmb_ManageList.Name = "cmb_ManageList";
            this.cmb_ManageList.Size = new System.Drawing.Size(121, 20);
            this.cmb_ManageList.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "관리 명령";
            // 
            // endDateTime
            // 
            this.endDateTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.endDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateTime.Location = new System.Drawing.Point(285, 58);
            this.endDateTime.Name = "endDateTime";
            this.endDateTime.Size = new System.Drawing.Size(182, 21);
            this.endDateTime.TabIndex = 7;
            // 
            // cmb_HistoryList
            // 
            this.cmb_HistoryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_HistoryList.FormattingEnabled = true;
            this.cmb_HistoryList.Items.AddRange(new object[] {
            "이력 데이터",
            "로그 파일"});
            this.cmb_HistoryList.Location = new System.Drawing.Point(78, 25);
            this.cmb_HistoryList.Name = "cmb_HistoryList";
            this.cmb_HistoryList.Size = new System.Drawing.Size(121, 20);
            this.cmb_HistoryList.TabIndex = 3;
            this.cmb_HistoryList.SelectedIndexChanged += new System.EventHandler(this.cmb_HistoryList_SelectedIndexChanged);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(205, 25);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(51, 22);
            this.btn_Search.TabIndex = 12;
            this.btn_Search.Text = "검색";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(230, 481);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(90, 39);
            this.btn_Reset.TabIndex = 1;
            this.btn_Reset.Text = "초기화";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(428, 481);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(90, 39);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.Text = "종료";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Apply
            // 
            this.btn_Apply.Location = new System.Drawing.Point(330, 481);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(90, 39);
            this.btn_Apply.TabIndex = 2;
            this.btn_Apply.Text = "적용";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(531, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.환경설정ToolStripMenuItem1});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.ToolStripMenuItem.Text = "설정";
            // 
            // 환경설정ToolStripMenuItem1
            // 
            this.환경설정ToolStripMenuItem1.Name = "환경설정ToolStripMenuItem1";
            this.환경설정ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.환경설정ToolStripMenuItem1.Text = "환경설정";
            this.환경설정ToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // TestWindowsForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 531);
            this.Controls.Add(this.btn_Apply);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btn_Reset);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TestWindowsForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "History 관리";
            this.Load += new System.EventHandler(this.TestWindowsForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HistManageGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView HistManageGrid;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_HistoryList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker startDateTime;
        private System.Windows.Forms.DateTimePicker endDateTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.ComboBox cmb_ManageList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 환경설정ToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewName;
    }
}

