namespace K_Face_XT_Test
{
    partial class MainForm
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab_main = new System.Windows.Forms.TabControl();
            this.tab_pub = new System.Windows.Forms.TabPage();
            this.Btn_Pub = new System.Windows.Forms.Button();
            this.Txt_Payload = new System.Windows.Forms.TextBox();
            this.Lbl_Payload = new System.Windows.Forms.Label();
            this.Txt_Topic = new System.Windows.Forms.TextBox();
            this.Lbl_Topic = new System.Windows.Forms.Label();
            this.tab_sub = new System.Windows.Forms.TabPage();
            this.Txt_sub = new System.Windows.Forms.TextBox();
            this.tab_connection = new System.Windows.Forms.TabPage();
            this.Btn_Connect = new System.Windows.Forms.Button();
            this.Txt_IP = new System.Windows.Forms.TextBox();
            this.Lbl_ip = new System.Windows.Forms.Label();
            this.Txt_topic_sub = new System.Windows.Forms.TextBox();
            this.Lbl_sub_topic = new System.Windows.Forms.Label();
            this.Btn_sub_add_topic = new System.Windows.Forms.Button();
            this.List_sub = new System.Windows.Forms.ListBox();
            this.Btn_subscribe = new System.Windows.Forms.Button();
            this.Btn_sub_clear = new System.Windows.Forms.Button();
            this.tab_main.SuspendLayout();
            this.tab_pub.SuspendLayout();
            this.tab_sub.SuspendLayout();
            this.tab_connection.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_main
            // 
            this.tab_main.Controls.Add(this.tab_pub);
            this.tab_main.Controls.Add(this.tab_sub);
            this.tab_main.Controls.Add(this.tab_connection);
            this.tab_main.Location = new System.Drawing.Point(12, 12);
            this.tab_main.Name = "tab_main";
            this.tab_main.SelectedIndex = 0;
            this.tab_main.Size = new System.Drawing.Size(776, 426);
            this.tab_main.TabIndex = 0;
            // 
            // tab_pub
            // 
            this.tab_pub.Controls.Add(this.Btn_Pub);
            this.tab_pub.Controls.Add(this.Txt_Payload);
            this.tab_pub.Controls.Add(this.Lbl_Payload);
            this.tab_pub.Controls.Add(this.Txt_Topic);
            this.tab_pub.Controls.Add(this.Lbl_Topic);
            this.tab_pub.Location = new System.Drawing.Point(4, 22);
            this.tab_pub.Name = "tab_pub";
            this.tab_pub.Padding = new System.Windows.Forms.Padding(3);
            this.tab_pub.Size = new System.Drawing.Size(768, 400);
            this.tab_pub.TabIndex = 0;
            this.tab_pub.Text = "Publish";
            this.tab_pub.UseVisualStyleBackColor = true;
            // 
            // Btn_Pub
            // 
            this.Btn_Pub.Location = new System.Drawing.Point(249, 177);
            this.Btn_Pub.Name = "Btn_Pub";
            this.Btn_Pub.Size = new System.Drawing.Size(75, 23);
            this.Btn_Pub.TabIndex = 9;
            this.Btn_Pub.Text = "Publish";
            this.Btn_Pub.UseVisualStyleBackColor = true;
            this.Btn_Pub.Click += new System.EventHandler(this.Btn_Pub_Click);
            // 
            // Txt_Payload
            // 
            this.Txt_Payload.Location = new System.Drawing.Point(80, 60);
            this.Txt_Payload.Multiline = true;
            this.Txt_Payload.Name = "Txt_Payload";
            this.Txt_Payload.Size = new System.Drawing.Size(244, 100);
            this.Txt_Payload.TabIndex = 8;
            // 
            // Lbl_Payload
            // 
            this.Lbl_Payload.AutoSize = true;
            this.Lbl_Payload.Location = new System.Drawing.Point(24, 65);
            this.Lbl_Payload.Name = "Lbl_Payload";
            this.Lbl_Payload.Size = new System.Drawing.Size(51, 12);
            this.Lbl_Payload.TabIndex = 7;
            this.Lbl_Payload.Text = "Payload";
            // 
            // Txt_Topic
            // 
            this.Txt_Topic.Location = new System.Drawing.Point(80, 21);
            this.Txt_Topic.Name = "Txt_Topic";
            this.Txt_Topic.Size = new System.Drawing.Size(100, 21);
            this.Txt_Topic.TabIndex = 6;
            // 
            // Lbl_Topic
            // 
            this.Lbl_Topic.AutoSize = true;
            this.Lbl_Topic.Location = new System.Drawing.Point(24, 26);
            this.Lbl_Topic.Name = "Lbl_Topic";
            this.Lbl_Topic.Size = new System.Drawing.Size(37, 12);
            this.Lbl_Topic.TabIndex = 5;
            this.Lbl_Topic.Text = "Topic";
            // 
            // tab_sub
            // 
            this.tab_sub.Controls.Add(this.Btn_sub_clear);
            this.tab_sub.Controls.Add(this.Btn_subscribe);
            this.tab_sub.Controls.Add(this.List_sub);
            this.tab_sub.Controls.Add(this.Btn_sub_add_topic);
            this.tab_sub.Controls.Add(this.Txt_topic_sub);
            this.tab_sub.Controls.Add(this.Lbl_sub_topic);
            this.tab_sub.Controls.Add(this.Txt_sub);
            this.tab_sub.Location = new System.Drawing.Point(4, 22);
            this.tab_sub.Name = "tab_sub";
            this.tab_sub.Padding = new System.Windows.Forms.Padding(3);
            this.tab_sub.Size = new System.Drawing.Size(768, 400);
            this.tab_sub.TabIndex = 1;
            this.tab_sub.Text = "Subcribe";
            this.tab_sub.UseVisualStyleBackColor = true;
            // 
            // Txt_sub
            // 
            this.Txt_sub.Location = new System.Drawing.Point(315, 5);
            this.Txt_sub.Multiline = true;
            this.Txt_sub.Name = "Txt_sub";
            this.Txt_sub.Size = new System.Drawing.Size(447, 343);
            this.Txt_sub.TabIndex = 10;
            // 
            // tab_connection
            // 
            this.tab_connection.Controls.Add(this.Btn_Connect);
            this.tab_connection.Controls.Add(this.Txt_IP);
            this.tab_connection.Controls.Add(this.Lbl_ip);
            this.tab_connection.Location = new System.Drawing.Point(4, 22);
            this.tab_connection.Name = "tab_connection";
            this.tab_connection.Padding = new System.Windows.Forms.Padding(3);
            this.tab_connection.Size = new System.Drawing.Size(768, 400);
            this.tab_connection.TabIndex = 2;
            this.tab_connection.Text = "Connection";
            this.tab_connection.UseVisualStyleBackColor = true;
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.Location = new System.Drawing.Point(191, 18);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.Size = new System.Drawing.Size(92, 23);
            this.Btn_Connect.TabIndex = 5;
            this.Btn_Connect.Text = "Connection";
            this.Btn_Connect.UseVisualStyleBackColor = true;
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // Txt_IP
            // 
            this.Txt_IP.Location = new System.Drawing.Point(63, 18);
            this.Txt_IP.Name = "Txt_IP";
            this.Txt_IP.Size = new System.Drawing.Size(100, 21);
            this.Txt_IP.TabIndex = 4;
            this.Txt_IP.Text = "localhost:1886";
            // 
            // Lbl_ip
            // 
            this.Lbl_ip.AutoSize = true;
            this.Lbl_ip.Location = new System.Drawing.Point(28, 23);
            this.Lbl_ip.Name = "Lbl_ip";
            this.Lbl_ip.Size = new System.Drawing.Size(16, 12);
            this.Lbl_ip.TabIndex = 3;
            this.Lbl_ip.Text = "IP";
            // 
            // Txt_topic_sub
            // 
            this.Txt_topic_sub.Location = new System.Drawing.Point(62, 15);
            this.Txt_topic_sub.Name = "Txt_topic_sub";
            this.Txt_topic_sub.Size = new System.Drawing.Size(155, 21);
            this.Txt_topic_sub.TabIndex = 13;
            // 
            // Lbl_sub_topic
            // 
            this.Lbl_sub_topic.AutoSize = true;
            this.Lbl_sub_topic.Location = new System.Drawing.Point(10, 20);
            this.Lbl_sub_topic.Name = "Lbl_sub_topic";
            this.Lbl_sub_topic.Size = new System.Drawing.Size(37, 12);
            this.Lbl_sub_topic.TabIndex = 12;
            this.Lbl_sub_topic.Text = "Topic";
            // 
            // Btn_sub_add_topic
            // 
            this.Btn_sub_add_topic.Location = new System.Drawing.Point(223, 15);
            this.Btn_sub_add_topic.Name = "Btn_sub_add_topic";
            this.Btn_sub_add_topic.Size = new System.Drawing.Size(75, 23);
            this.Btn_sub_add_topic.TabIndex = 14;
            this.Btn_sub_add_topic.Text = "Add";
            this.Btn_sub_add_topic.UseVisualStyleBackColor = true;
            this.Btn_sub_add_topic.Click += new System.EventHandler(this.Btn_sub_add_topic_Click);
            // 
            // List_sub
            // 
            this.List_sub.FormattingEnabled = true;
            this.List_sub.ItemHeight = 12;
            this.List_sub.Location = new System.Drawing.Point(12, 80);
            this.List_sub.Name = "List_sub";
            this.List_sub.Size = new System.Drawing.Size(286, 268);
            this.List_sub.TabIndex = 15;
            // 
            // Btn_subscribe
            // 
            this.Btn_subscribe.Location = new System.Drawing.Point(93, 44);
            this.Btn_subscribe.Name = "Btn_subscribe";
            this.Btn_subscribe.Size = new System.Drawing.Size(75, 23);
            this.Btn_subscribe.TabIndex = 16;
            this.Btn_subscribe.Text = "Subscribe";
            this.Btn_subscribe.UseVisualStyleBackColor = true;
            this.Btn_subscribe.Click += new System.EventHandler(this.Btn_subscribe_Click);
            // 
            // Btn_sub_clear
            // 
            this.Btn_sub_clear.Location = new System.Drawing.Point(12, 44);
            this.Btn_sub_clear.Name = "Btn_sub_clear";
            this.Btn_sub_clear.Size = new System.Drawing.Size(75, 23);
            this.Btn_sub_clear.TabIndex = 17;
            this.Btn_sub_clear.Text = "Clear";
            this.Btn_sub_clear.UseVisualStyleBackColor = true;
            this.Btn_sub_clear.Click += new System.EventHandler(this.Btn_sub_clear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tab_main);
            this.Name = "MainForm";
            this.Text = "K-Face XT Test";
            this.tab_main.ResumeLayout(false);
            this.tab_pub.ResumeLayout(false);
            this.tab_pub.PerformLayout();
            this.tab_sub.ResumeLayout(false);
            this.tab_sub.PerformLayout();
            this.tab_connection.ResumeLayout(false);
            this.tab_connection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_main;
        private System.Windows.Forms.TabPage tab_pub;
        private System.Windows.Forms.TabPage tab_sub;
        private System.Windows.Forms.TabPage tab_connection;
        private System.Windows.Forms.Button Btn_Connect;
        private System.Windows.Forms.TextBox Txt_IP;
        private System.Windows.Forms.Label Lbl_ip;
        private System.Windows.Forms.TextBox Txt_Payload;
        private System.Windows.Forms.Label Lbl_Payload;
        private System.Windows.Forms.TextBox Txt_Topic;
        private System.Windows.Forms.Label Lbl_Topic;
        private System.Windows.Forms.Button Btn_Pub;
        private System.Windows.Forms.TextBox Txt_sub;
        private System.Windows.Forms.ListBox List_sub;
        private System.Windows.Forms.Button Btn_sub_add_topic;
        private System.Windows.Forms.TextBox Txt_topic_sub;
        private System.Windows.Forms.Label Lbl_sub_topic;
        private System.Windows.Forms.Button Btn_sub_clear;
        private System.Windows.Forms.Button Btn_subscribe;
    }
}

