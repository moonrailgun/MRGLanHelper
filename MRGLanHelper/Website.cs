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
using System.Net;
using System.Threading;

namespace MRGLanHelper
{
    public partial class Website : Skin_Mac
    {
        public Website()
        {
            InitializeComponent();
        }

        public static HttpListener listener = new HttpListener();
        private Thread ThreadListener = null;
        public static string WebPath = Application.StartupPath + "\\web\\";

        private void Start(object sender, EventArgs e)
        {

        }

        private void Stop(object sender, EventArgs e)
        {

        }

        private void ShowLog(object sender, EventArgs e)
        {

        }
    }
}
