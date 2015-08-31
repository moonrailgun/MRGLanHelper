﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinControl;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using MRGLanHelper.Model;

namespace MRGLanHelper
{
    public partial class FrmMain : Skin_Mac
    {
        public string selectedLocalIP = "";
        List<string> onlineIPList = new List<string>();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //获取本机IP
            string hostname = Dns.GetHostName();//得到本机名
            IPHostEntry localhost = Dns.GetHostEntry(hostname);
            IPAddress[] arrIPAddresses = localhost.AddressList;
            foreach (IPAddress ip in arrIPAddresses)
            {
                if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                {
                    //如果是IPv4地址
                    string ipStr = ip.ToString();
                    if (!skinComboBox1.Items.Contains(ipStr))
                    {
                        skinComboBox1.Items.Add(ipStr);
                    }

                    skinComboBox1.Text = ipStr;
                }
            }

            this.UpdateLanList();
        }

        /// <summary>
        /// 刷新局域网列表
        /// </summary>
        private void UpdateLanList()
        {
            //清空原先数据
            skinDataGridView1.Rows.Clear();

            GetLanOnlineIP();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.UpdateLanList();
        }

        private void GetLanOnlineIP()
        {
            //获取网段
            string localIP = this.selectedLocalIP;
            string[] ipStrArray = localIP.Split(new char[] { '.' });
            string ipNetworkSegment = ipStrArray[0] + "." + ipStrArray[1] + "." + ipStrArray[2];

            for (int i = 1; i <= 255; i++)
            {
                Ping myPing = new Ping();
                myPing.PingCompleted += new PingCompletedEventHandler(_onPingCompleted);//添加回调事件
                string pingIP = ipNetworkSegment + "." + i.ToString();
                myPing.SendAsync(pingIP, 1000, null);
            }
        }
        private void _onPingCompleted(object sender, PingCompletedEventArgs e)
        {
            if (e.Reply.Status == IPStatus.Success)
            {
                string ipaddress = e.Reply.Address.ToString();
                onlineIPList.Add(ipaddress);

                AddGridItemInvoke(skinDataGridView1, new IPAddressGridItem(ipaddress,"","","",false,false,"",""));
            }
        }

        #region UI多线程添加到IP列表委托
        private delegate void AddDataGridViewItemDelegate(DataGridView dataGridView, IPAddressGridItem item);
        private void AddDataGridViewItem(DataGridView dataGridView, IPAddressGridItem item)
        {
            dataGridView.Rows.Add(item);
        }

        private void AddGridItemInvoke(DataGridView dataGridView, IPAddressGridItem item)
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new AddDataGridViewItemDelegate(AddDataGridViewItem), dataGridView, item);
            }
            else
            {
                AddDataGridViewItem(dataGridView, item);
            }
        }
        #endregion

        [DllImport("ws2_32.dll")]
        private static extern int inet_addr(string cp);
        [DllImport("IPHLPAPI.dll")]
        private static extern int SendARP(Int32 DestIP, Int32 SrcIP, ref Int64 pMacAddr, ref Int32 PhyAddrLen);
        /// <summary>
        /// 获取远程IP（不能跨网段）的MAC地址
        /// </summary>
        /// <param name="hostip"></param>
        /// <returns></returns>
        private string GetMacAddress(string hostip)
        {
            string Mac = "";
            try
            {
                //将IP地址从 点数格式转换成无符号长整型
                Int32 ldest = inet_addr(hostip);
                Int64 macinfo = new Int64();
                Int32 len = 6;
                SendARP(ldest, 0, ref macinfo, ref len);
                //转换成16进制,注意有些没有十二位
                string TmpMac = Convert.ToString(macinfo, 16).PadLeft(12, '0');
                Mac = TmpMac.Substring(0, 2).ToUpper();
                for (int i = 2; i < TmpMac.Length; i = i + 2)
                {
                    Mac = TmpMac.Substring(i, 2).ToUpper() + "-" + Mac;
                }
            }
            catch (Exception Mye)
            {
                Mac = "获取远程主机的MAC错误：" + Mye.Message;
            }
            return Mac;
        }

        private void skinComboBox1ValueChange(object sender, EventArgs e)
        {
            string comboText = ((ComboBox)sender).Text;
            this.selectedLocalIP = comboText;
            string[] ipStrArray = comboText.Split(new char[] { '.' });
            string ipNetworkSegment = ipStrArray[0] + "." + ipStrArray[1] + "." + ipStrArray[2] + ".*";
            skinLabel3.Text = ipNetworkSegment;
        }
    }
}
