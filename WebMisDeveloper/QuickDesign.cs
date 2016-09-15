using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJ_DBOperater;

namespace WebMisDeveloper
{
    public partial class QuickDesign : Form
    {
        public QuickDesign()
        {
            InitializeComponent();
        }

        private void QuickDesign_Load(object sender, EventArgs e)
        {

        }

        private void RBtnTemp_CheckedChanged(object sender, EventArgs e)
        {
            this.CboxDbs.Enabled = RBtnTemp.Checked;
            this.TxtConn.Enabled = RBtnNew.Checked;
            this.Cbo_DBType.Enabled = RBtnNew.Checked;
            this.BtnTryConn.Enabled = RBtnNew.Checked;
        }

        private void wizard1_Load(object sender, EventArgs e)
        {
            CJ.oleDbconn_str = Cmds.AccessConnString;
            DataTable dt = CJ.OtherDB_ReturnDataTable(Cmds.FindAllTemplate);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.CboxDbs.Items.Add(dt.Rows[i]["DBName"].ToString());
            }
            CboxDbs.SelectedIndex = 0;
            Cbo_DBType.SelectedIndex = 0;
        }
        //下一步
        private void wizardPage1_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            cBoxTables.Items.Clear();
            DataTable dttables = new DataTable();
            try
            {
                if (RBtnNew.Checked)
                {
                    //验证连接串
                    if (Cbo_DBType.SelectedIndex == 0 || Cbo_DBType.SelectedIndex == 1)
                    {
                        CJ.sqlconn_str = TxtConn.Text.Trim();
                        dttables = CJ.SQL_ReturnDataTable(Cmds.MSSQLFindAllTable);
                    }
                    else
                    {
                        CJ.oracleconn_str = TxtConn.Text.Trim();
                        dttables = CJ.Oracle_ReturnDataTable(Cmds.OracleFindALlTable);
                    }

                }
                else
                {
                    dttables = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindALLTables, CboxDbs.Text));
                }
            }
            catch { }
            if (dttables.Rows.Count <= 0)
            {
                e.Page = wizardPage1;
                MessageBox.Show("数据库中找不到表，请您检查后重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            for (int i = 0; i < dttables.Rows.Count; i++)
            {
                cBoxTables.Items.Add(dttables.Rows[i][0].ToString());
            }
            CJ.OtherDB_ExevuteNonQuery(string.Format(Cmds.SaveQuickDesignConStr, TxtConn.Text.Trim(), Cbo_DBType.Text));
            cBoxTables.SelectedIndex = 0;
        }
        //获得代码
        private void wizardPage3_ShowFromNext(object sender, EventArgs e)
        {
            DataTable dtcolumns = new DataTable();
            if (RBtnTemp.Checked)
            {
                dtcolumns = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.GetTableColumns, cBoxTables.Text, CboxDbs.Text));
            }
            if (RBtnNew.Checked)
            {
                if (Cbo_DBType.SelectedIndex == 0)
                    dtcolumns = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindTableStructs2000, cBoxTables.Text));
                else if (Cbo_DBType.SelectedIndex == 1)
                    dtcolumns = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindTableStructs2005, cBoxTables.Text));
                else
                    dtcolumns = CJ.SQL_ReturnDataTable(string.Format(Cmds.OracleFindTalbeStructs, cBoxTables.Text));
            }
            if (dtcolumns.Rows.Count <= 0)
                return;
            string str = "";
            if (this.cbjstk.Checked)
            {
                Tools.JSCheck js = new Tools.JSCheck();
                str = js.JSCheckNull(dtcolumns);
                str += "\r\n\r\n\r\n\r\n";
            }
            if (this.cbjswb.Checked)
            {
                Tools.JSCheck js = new Tools.JSCheck();
                str = js.JSCheckNullToSpan(dtcolumns);
                str += "\r\n\r\n\r\n\r\n";
            }
            if (cbui.Checked)
            {
                Tools.AspxPage page = new Tools.AspxPage();
                if (cbjstk.Checked)
                    str += page.CreateTextBox(dtcolumns);
                if (cbjswb.Checked)
                    str += page.CreateTextBoxAndSpan(dtcolumns);
                str += "\r\n\r\n\r\n\r\n";
            }
            if (cbuilb.Checked)
            {
                Tools.AspxPage page = new Tools.AspxPage();
                str += page.CreateLabel(dtcolumns);
                str += "\r\n\r\n\r\n\r\n";
            }
            Tools.ValueGetSet vgs = new Tools.ValueGetSet();
            if (cbget.Checked)
            {
                str += vgs.ValueGet(dtcolumns, cBoxTables.Text.ToLower());
                str += "\r\n\r\n\r\n\r\n";
            }
            if (cbvset.Checked)
            {
                if(cbuilb.Checked)
                    str += vgs.ValueSetLabel(dtcolumns, cBoxTables.Text.ToLower());
                if(cbui.Checked)
                    str += vgs.ValueSet(dtcolumns, cBoxTables.Text.ToLower());
                str += "\r\n\r\n\r\n\r\n";
            }
            if (cbRepeater.Checked)
            {
                Tools.AspxRepeater repeater = new Tools.AspxRepeater();
                str += repeater.CreateAjaxRepeater(dtcolumns, cBoxTables.Text.ToLower());
            }
            RTbcode.Text = str;
            this.WindowState = FormWindowState.Maximized;
        }

        private void cbuilb_CheckedChanged(object sender, EventArgs e)
        {
            this.cbget.Checked = !cbuilb.Checked;
            this.cbget.Enabled = !cbuilb.Checked;
        }

        private void wizardPage3_CloseFromBack(object sender, Gui.Wizard.PageEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void wizardPage3_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void Cbo_DBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.GetQuickDesignConStr, Cbo_DBType.Text));
            if (dt.Rows.Count > 0)
                TxtConn.Text = dt.Rows[0]["DBconstring"].ToString();
        }
        //测试连接
        private void BtnTryConn_Click(object sender, EventArgs e)
        {
            DBConnTest dtest = new DBConnTest();
            dtest.DBConnTry(Cbo_DBType.Text, this.TxtConn.Text);
        }

        private void wizardPage3_ShowFromBack(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void wizard1_CloseFromCancel(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("您确定退出Asp.net页面元素生成向导吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

    }
}
