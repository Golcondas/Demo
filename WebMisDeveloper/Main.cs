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
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();
            this.Text = "起点10--WebMisDeveloper V_" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        #region 自动生成
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        #endregion

        //启动生成向导
        private void TSBtn_Start_Click(object sender, EventArgs e)
        {
            Leader l = new Leader();
            l.MdiParent = this;
            l.Show();
        }
        //菜单栏向导
        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Leader l = new Leader();
            l.MdiParent = this;
            l.Show();
        }
        //退出系统
        private void TSBtn_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TSBtn_DeveloperHelper_Click(object sender, EventArgs e)
        {
            DeveloperHelper dh = new DeveloperHelper();
            dh.MdiParent = this;
            dh.Show();
        }

        private void STSBTnDH_Click(object sender, EventArgs e)
        {
            DeveloperHelper dh = new DeveloperHelper();
            dh.MdiParent = this;
            dh.Show();
        }

        private void TSBar_lb_author_Click(object sender, EventArgs e)
        {
            AboutAuthor aa = new AboutAuthor();
            aa.MdiParent = this;
            aa.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs aus = new AboutUs();
            aus.MdiParent = this;
            aus.Show();
        }

        private void TSBtn_QuickBack_Click(object sender, EventArgs e)
        {
            QuickBackMgr qbm = new QuickBackMgr();
            qbm.MdiParent = this;
            qbm.Show();
        }

        private void TSM_QB_Click(object sender, EventArgs e)
        {
            QuickBackMgr qbm = new QuickBackMgr();
            qbm.MdiParent = this;
            qbm.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            RSS website = new RSS();
            website.MdiParent = this;
            website.Show(); 
            //Skin.AddSkinMenu(CTSMenuChangeSkin);
        }

        private void webMisDeveloper说明书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@".\Help\WebMisDeveloperIntroduce.pdf");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void qiDian10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RSS website = new RSS();
            website.MdiParent = this;
            website.Show();
        }

        private void TSquickdesign_Click(object sender, EventArgs e)
        {
            QuickDesign qd = new QuickDesign();
            qd.MdiParent = this;
            qd.Show();
        }
       
    }
}
