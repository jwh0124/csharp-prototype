using K_Face_XT_Test.Util;
using System;
using System.Windows.Forms;

namespace K_Face_XT_Test
{
    public partial class MainForm : Form
    {
        private readonly MqttUtil MqttUtil;

        public MainForm()
        {
            MqttUtil = new MqttUtil();
            InitializeComponent();
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(Txt_IP.Text))
            {
                try { 
                    string[] ip_port_split = Txt_IP.Text.Split(':');
                    if(MqttUtil.Mqtt_Connect(ip_port_split[0], int.Parse(ip_port_split[1]))){
                        MessageBox.Show("연결 되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("연결 에러.");
                    }
                }
                catch
                {
                    MessageBox.Show("Broker 실행 에러.");
                }
            }
            else
            {
                MessageBox.Show("IP를 입력해주세요.");
            }
                
        }

        private void Btn_Pub_Click(object sender, EventArgs e)
        {
            MqttUtil.Mqtt_Pub(Txt_Topic.Text, Txt_Payload.Text);
        }

        private void Btn_sub_add_topic_Click(object sender, EventArgs e)
        {
            List_sub.Items.Add(Txt_topic_sub.Text);
        }

        private void Btn_sub_clear_Click(object sender, EventArgs e)
        {
            List_sub.Items.Clear();
        }

        private void Btn_subscribe_Click(object sender, EventArgs e)
        {
            MqttUtil.Mqtt_Sub(List_sub.Items);
        }
    }
}
