using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebMisDeveloper
{
    public partial class QiDian10_WebSite : Form
    {
        public QiDian10_WebSite()
        {
            InitializeComponent();
        }

        private void QiDian10_WebSite_Load(object sender, EventArgs e)
        {
            Uri url = new Uri("http://www.qidian10.com/View/WebMisDeveloper.html");
            webBrowser1.Url = url;
            this.lbpro.Text = "0";
            webBrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser1_ProgressChanged);
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {

            progressBar1.Visible = true;
            if ((e.CurrentProgress > 0) && (e.MaximumProgress > 0))
            {
                progressBar1.Maximum = Convert.ToInt32(e.MaximumProgress);
                progressBar1.Step = Convert.ToInt32(e.CurrentProgress);
                this.lbpro.Text = "正在加载数据，请稍后......";
                progressBar1.PerformStep();
            }
            else if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                progressBar1.Value = 0;
                progressBar1.Visible = false;
                this.lbpro.Visible = false;
            }


        }
    }
}
