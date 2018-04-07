namespace GreyhoundGame
{
    partial class frmGreyhound
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAl = new System.Windows.Forms.Label();
            this.lblBob = new System.Windows.Forms.Label();
            this.lblJoe = new System.Windows.Forms.Label();
            this.numDogNo = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numBucks = new System.Windows.Forms.NumericUpDown();
            this.lblGuyName = new System.Windows.Forms.Label();
            this.btnBets = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.rdbAl = new System.Windows.Forms.RadioButton();
            this.rdbBob = new System.Windows.Forms.RadioButton();
            this.rdbJoe = new System.Windows.Forms.RadioButton();
            this.lbl베팅정보 = new System.Windows.Forms.Label();
            this.pBoxDog1 = new System.Windows.Forms.PictureBox();
            this.pBoxRaceTrack = new System.Windows.Forms.PictureBox();
            this.pBoxDog2 = new System.Windows.Forms.PictureBox();
            this.pBoxDog3 = new System.Windows.Forms.PictureBox();
            this.pBoxDog4 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDogNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBucks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxDog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRaceTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxDog2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxDog3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxDog4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAl);
            this.groupBox1.Controls.Add(this.lblBob);
            this.groupBox1.Controls.Add(this.lblJoe);
            this.groupBox1.Controls.Add(this.numDogNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numBucks);
            this.groupBox1.Controls.Add(this.lblGuyName);
            this.groupBox1.Controls.Add(this.btnBets);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.rdbAl);
            this.groupBox1.Controls.Add(this.rdbBob);
            this.groupBox1.Controls.Add(this.rdbJoe);
            this.groupBox1.Controls.Add(this.lbl베팅정보);
            this.groupBox1.Location = new System.Drawing.Point(12, 346);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(961, 213);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "배팅 화면";
            // 
            // lblAl
            // 
            this.lblAl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAl.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAl.Location = new System.Drawing.Point(634, 135);
            this.lblAl.Name = "lblAl";
            this.lblAl.Size = new System.Drawing.Size(321, 23);
            this.lblAl.TabIndex = 14;
            this.lblAl.Text = "Al 배팅";
            // 
            // lblBob
            // 
            this.lblBob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBob.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBob.Location = new System.Drawing.Point(634, 98);
            this.lblBob.Name = "lblBob";
            this.lblBob.Size = new System.Drawing.Size(321, 23);
            this.lblBob.TabIndex = 13;
            this.lblBob.Text = "Bob 배팅";
            // 
            // lblJoe
            // 
            this.lblJoe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJoe.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblJoe.Location = new System.Drawing.Point(634, 62);
            this.lblJoe.Name = "lblJoe";
            this.lblJoe.Size = new System.Drawing.Size(321, 23);
            this.lblJoe.TabIndex = 12;
            this.lblJoe.Text = "Joe 배팅";
            // 
            // numDogNo
            // 
            this.numDogNo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.numDogNo.Location = new System.Drawing.Point(522, 174);
            this.numDogNo.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numDogNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDogNo.Name = "numDogNo";
            this.numDogNo.Size = new System.Drawing.Size(82, 26);
            this.numDogNo.TabIndex = 11;
            this.numDogNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(417, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "경주견 선택";
            // 
            // numBucks
            // 
            this.numBucks.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.numBucks.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numBucks.Location = new System.Drawing.Point(250, 174);
            this.numBucks.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numBucks.Name = "numBucks";
            this.numBucks.Size = new System.Drawing.Size(82, 26);
            this.numBucks.TabIndex = 9;
            // 
            // lblGuyName
            // 
            this.lblGuyName.AutoSize = true;
            this.lblGuyName.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGuyName.Location = new System.Drawing.Point(48, 179);
            this.lblGuyName.Name = "lblGuyName";
            this.lblGuyName.Size = new System.Drawing.Size(87, 16);
            this.lblGuyName.TabIndex = 8;
            this.lblGuyName.Text = "Bet Name";
            // 
            // btnBets
            // 
            this.btnBets.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBets.Location = new System.Drawing.Point(153, 172);
            this.btnBets.Name = "btnBets";
            this.btnBets.Size = new System.Drawing.Size(78, 29);
            this.btnBets.TabIndex = 7;
            this.btnBets.Text = "Bets";
            this.btnBets.UseVisualStyleBackColor = true;
            this.btnBets.Click += new System.EventHandler(this.btnBets_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(861, 173);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 29);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(631, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bets";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStart.Location = new System.Drawing.Point(767, 172);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(78, 29);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "시 작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // rdbAl
            // 
            this.rdbAl.AutoSize = true;
            this.rdbAl.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdbAl.Location = new System.Drawing.Point(28, 134);
            this.rdbAl.Name = "rdbAl";
            this.rdbAl.Size = new System.Drawing.Size(41, 20);
            this.rdbAl.TabIndex = 3;
            this.rdbAl.TabStop = true;
            this.rdbAl.Text = "Al";
            this.rdbAl.UseVisualStyleBackColor = true;
            this.rdbAl.CheckedChanged += new System.EventHandler(this.rdbAl_CheckedChanged);
            // 
            // rdbBob
            // 
            this.rdbBob.AutoSize = true;
            this.rdbBob.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdbBob.Location = new System.Drawing.Point(28, 97);
            this.rdbBob.Name = "rdbBob";
            this.rdbBob.Size = new System.Drawing.Size(58, 20);
            this.rdbBob.TabIndex = 2;
            this.rdbBob.TabStop = true;
            this.rdbBob.Text = "Bob";
            this.rdbBob.UseVisualStyleBackColor = true;
            this.rdbBob.CheckedChanged += new System.EventHandler(this.rdbBob_CheckedChanged);
            // 
            // rdbJoe
            // 
            this.rdbJoe.AutoSize = true;
            this.rdbJoe.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdbJoe.Location = new System.Drawing.Point(28, 61);
            this.rdbJoe.Name = "rdbJoe";
            this.rdbJoe.Size = new System.Drawing.Size(54, 20);
            this.rdbJoe.TabIndex = 1;
            this.rdbJoe.TabStop = true;
            this.rdbJoe.Text = "Joe";
            this.rdbJoe.UseVisualStyleBackColor = true;
            this.rdbJoe.CheckedChanged += new System.EventHandler(this.rdbJoe_CheckedChanged);
            // 
            // lbl베팅정보
            // 
            this.lbl베팅정보.AutoSize = true;
            this.lbl베팅정보.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl베팅정보.Location = new System.Drawing.Point(25, 32);
            this.lbl베팅정보.Name = "lbl베팅정보";
            this.lbl베팅정보.Size = new System.Drawing.Size(134, 16);
            this.lbl베팅정보.TabIndex = 0;
            this.lbl베팅정보.Text = "최소배팅 금액 : ";
            // 
            // pBoxDog1
            // 
            this.pBoxDog1.Image = global::GreyhoundGame.Properties.Resources.dog;
            this.pBoxDog1.Location = new System.Drawing.Point(40, 23);
            this.pBoxDog1.Name = "pBoxDog1";
            this.pBoxDog1.Size = new System.Drawing.Size(119, 37);
            this.pBoxDog1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxDog1.TabIndex = 2;
            this.pBoxDog1.TabStop = false;
            // 
            // pBoxRaceTrack
            // 
            this.pBoxRaceTrack.Image = global::GreyhoundGame.Properties.Resources.racetrack;
            this.pBoxRaceTrack.Location = new System.Drawing.Point(12, 12);
            this.pBoxRaceTrack.Name = "pBoxRaceTrack";
            this.pBoxRaceTrack.Size = new System.Drawing.Size(961, 317);
            this.pBoxRaceTrack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxRaceTrack.TabIndex = 0;
            this.pBoxRaceTrack.TabStop = false;
            // 
            // pBoxDog2
            // 
            this.pBoxDog2.Image = global::GreyhoundGame.Properties.Resources.dog;
            this.pBoxDog2.Location = new System.Drawing.Point(40, 103);
            this.pBoxDog2.Name = "pBoxDog2";
            this.pBoxDog2.Size = new System.Drawing.Size(119, 37);
            this.pBoxDog2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxDog2.TabIndex = 3;
            this.pBoxDog2.TabStop = false;
            // 
            // pBoxDog3
            // 
            this.pBoxDog3.Image = global::GreyhoundGame.Properties.Resources.dog;
            this.pBoxDog3.Location = new System.Drawing.Point(40, 189);
            this.pBoxDog3.Name = "pBoxDog3";
            this.pBoxDog3.Size = new System.Drawing.Size(119, 37);
            this.pBoxDog3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxDog3.TabIndex = 4;
            this.pBoxDog3.TabStop = false;
            // 
            // pBoxDog4
            // 
            this.pBoxDog4.Image = global::GreyhoundGame.Properties.Resources.dog;
            this.pBoxDog4.Location = new System.Drawing.Point(40, 266);
            this.pBoxDog4.Name = "pBoxDog4";
            this.pBoxDog4.Size = new System.Drawing.Size(119, 37);
            this.pBoxDog4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxDog4.TabIndex = 5;
            this.pBoxDog4.TabStop = false;
            // 
            // frmGreyhound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 571);
            this.Controls.Add(this.pBoxDog4);
            this.Controls.Add(this.pBoxDog3);
            this.Controls.Add(this.pBoxDog2);
            this.Controls.Add(this.pBoxDog1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pBoxRaceTrack);
            this.MaximizeBox = false;
            this.Name = "frmGreyhound";
            this.Text = "멍멍이 경주 게임";
            this.Load += new System.EventHandler(this.frmGreyhound_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDogNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBucks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxDog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRaceTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxDog2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxDog3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxDog4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxRaceTrack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl베팅정보;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton rdbAl;
        private System.Windows.Forms.RadioButton rdbBob;
        private System.Windows.Forms.RadioButton rdbJoe;
        private System.Windows.Forms.PictureBox pBoxDog1;
        private System.Windows.Forms.PictureBox pBoxDog2;
        private System.Windows.Forms.PictureBox pBoxDog3;
        private System.Windows.Forms.PictureBox pBoxDog4;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numDogNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numBucks;
        private System.Windows.Forms.Label lblGuyName;
        private System.Windows.Forms.Button btnBets;
        private System.Windows.Forms.Label lblJoe;
        private System.Windows.Forms.Label lblAl;
        private System.Windows.Forms.Label lblBob;
    }
}

