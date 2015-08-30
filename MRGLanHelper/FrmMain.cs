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

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.UpdateLanList();
        }
    }
}
