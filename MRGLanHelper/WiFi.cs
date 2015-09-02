using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace MRGLanHelper
{
    /// <summary>
    /// 需要管理员权限否则无法正常运行
    /// 暂时不可用
    /// </summary>
    public partial class WiFi : Skin_Mac
    {
        public WiFi()
        {
            InitializeComponent();
        }

        private void CMD(string str)
        {
            //process用于调用外部程序
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            //调用cmd.exe
            p.StartInfo.FileName = "cmd.exe";
            //是否指定操作系统外壳进程启动程序
            p.StartInfo.UseShellExecute = false;
            //可能接受来自调用程序的输入信息
            //重定向标准输入
            p.StartInfo.RedirectStandardInput = true;
            //重定向标准输出
            p.StartInfo.RedirectStandardOutput = true;
            //重定向错误输出
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            //启动程序
            p.Start();
            //睡眠1s。
            System.Threading.Thread.Sleep(1000);
            //输入命令
            p.StandardInput.WriteLine(str);
            skinTextBox1.Text += p.StandardOutput.ReadToEnd() + "\r\n";
            //一定要关闭。
            p.StandardInput.WriteLine("exit");
        }

        private void CloseWiFi(object sender, EventArgs e)
        {
            string str = "netsh wlan stop hostednetwork";
            CMD(str);
            MessageBox.Show("已经关闭了热点", "关闭热点", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateWiFi(object sender, EventArgs e)
        {
            string username = skinWaterTextBox1.Text;
            string password = skinWaterTextBox2.Text;

            if (password.Length >= 8 && username != null)
            {
                // 命令行输入命令，用来新建wifi 
                string str = "netsh wlan set hostednetwork mode=allow ssid=" + username + " key=" + password;//创建热点
                CMD(str);
                MessageBox.Show("新建了wifi热点", "新建成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                str = "netsh wlan start hostednetwork";//开启热点
                CMD(str);
            }
            else
            {
                MessageBox.Show("你的账号为空或你的密码长度小于8", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}