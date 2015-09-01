using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRGLanHelper.Model
{
    class IPAddressGridItem : DataGridViewRow
    {
        public DataGridViewTextBoxCell ipAddress = new DataGridViewTextBoxCell();
        public DataGridViewTextBoxCell hostName = new DataGridViewTextBoxCell();
        public DataGridViewTextBoxCell upDateTime = new DataGridViewTextBoxCell();
        public DataGridViewTextBoxCell macAddress = new DataGridViewTextBoxCell();
        public DataGridViewTextBoxCell macRemarkName = new DataGridViewTextBoxCell();
        public DataGridViewCheckBoxCell isRunHelper = new DataGridViewCheckBoxCell();
        public DataGridViewCheckBoxCell isRunShare = new DataGridViewCheckBoxCell();
        public DataGridViewTextBoxCell osVersion = new DataGridViewTextBoxCell();
        public DataGridViewTextBoxCell ping = new DataGridViewTextBoxCell();

        public IPAddressGridItem()
        { }
        public IPAddressGridItem(string ipAddress,string hostName, string updateTime, string macAddress, string macRemarkName, bool isRunHelper, bool isRunShare, string osVersion, string ping)
        {
            this.ipAddress.Value = ipAddress;
            this.hostName.Value = hostName;
            this.upDateTime.Value = updateTime;
            this.macAddress.Value = macAddress;
            this.macRemarkName.Value = macRemarkName;
            this.isRunHelper.Value = isRunHelper;
            this.isRunShare.Value = isRunShare;
            this.osVersion.Value = osVersion;
            this.ping.Value = ping;

            Push();
        }

        /// <summary>
        /// 压入数据
        /// </summary>
        public void Push()
        {
            this.Cells.Add(ipAddress);
            this.Cells.Add(hostName);
            this.Cells.Add(upDateTime);
            this.Cells.Add(macAddress);
            this.Cells.Add(macRemarkName);
            this.Cells.Add(isRunHelper);
            this.Cells.Add(isRunShare);
            this.Cells.Add(osVersion);
            this.Cells.Add(ping);
        }
    }
}
