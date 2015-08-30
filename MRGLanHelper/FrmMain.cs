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
    public partial class FrmMain : Skin_Mac
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 刷新局域网列表
        /// </summary>
        private void UpdateLanList()
        {
            //清空原先数据
            skinDataGridView1.Rows.Clear();

            DataGridViewTextBoxCell ipAddress = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell upDateTime = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell macAddress = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell macRemarkName = new DataGridViewTextBoxCell();
            DataGridViewCheckBoxCell isRunHelper = new DataGridViewCheckBoxCell();
            DataGridViewCheckBoxCell isRunShare = new DataGridViewCheckBoxCell();
            DataGridViewTextBoxCell osVersion = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell ping = new DataGridViewTextBoxCell();

            DataGridViewRow row = new DataGridViewRow();
            ipAddress.Value = "a";
            upDateTime.Value = "b";
            macAddress.Value = "c";
            macRemarkName.Value = "d";
            isRunHelper.Value = true;
            isRunShare.Value = false;
            osVersion.Value = "e";
            ping.Value = "f";

            row.Cells.Add(ipAddress);
            row.Cells.Add(upDateTime);
            row.Cells.Add(macAddress);
            row.Cells.Add(macRemarkName);
            row.Cells.Add(isRunHelper);
            row.Cells.Add(isRunShare);
            row.Cells.Add(osVersion);
            row.Cells.Add(ping);

            skinDataGridView1.Rows.Add(row);
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.UpdateLanList();
        }
    }
}
