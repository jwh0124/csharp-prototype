using K_Face_XT_Test.Util;
using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    MessageBox.Show("Broker가 작동하지 않습니다.");
                }
            }
            else
            {
                MessageBox.Show("IP를 입력해주세요.");
            }
                
        }

        private void Btn_Pub_Click(object sender, EventArgs e)
        {
            MqttUtil.Mqtt_Pub();
        }
    }
}
