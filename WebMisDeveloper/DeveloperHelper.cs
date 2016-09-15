using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJ_DBOperater;
using Core;
using System.Threading;

namespace WebMisDeveloper
{
    public partial class DeveloperHelper : Form
    {
        public DeveloperHelper()
        {
            InitializeComponent();
        }
        private ArrayList list = new ArrayList();//存储用户选择的表
        private delegate void UpdatePBar(int n);  //更新UI的进度条空间
        private delegate void UpdatePrint(string txt); //更新UI的文本框
        private string dbtype = "";//数据库类型

        private void DeveloperHelper_Load(object sender, EventArgs e)
        {
            CJ.oleDbconn_str = Cmds.AccessConnString;
            WDHCbo.SelectedIndex = 0;
        }
        //下拉框改变选项时
        private void WDHCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.GetDevHelperConStr, WDHCbo.Text));
            if (dt.Rows.Count > 0)
                WDHTxt.Text = dt.Rows[0]["DBconstring"].ToString();
        }
        //测试连接
        private void WDHBtn_Click(object sender, EventArgs e)
        {
            DBConnTest dtest = new DBConnTest();
            dtest.DBConnTry(WDHCbo.Text, WDHTxt.Text);
        }
        //单击Cancel是
        private void Wizard_DHelper_CloseFromCancel(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("您确定退出开发助理吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }


        //第二步结束的时候，保存用户的业务定制
        private void WCorePage_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            list.Clear();
            for (int i = 0; i < WCCLBox.Items.Count; i++)
            {
                if (WCCLBox.GetItemChecked(i))
                    list.Add(WCCLBox.Items[i].ToString());
            }
            if (list.Count <= 0)
            {
                e.Page = WCorePage;
                MessageBox.Show("请选择要操作的表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        //第二步，进入定制业务之前发生
        private void WDBPage_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                if (WDHCbo.SelectedIndex == 0 || WDHCbo.SelectedIndex == 1)
                {
                    CJ.sqlconn_str = WDHTxt.Text;
                    dt = CJ.SQL_ReturnDataTable(Cmds.MSSQLFindAllTable);
                }
                else if(WDHCbo.SelectedIndex==2)
                {
                    //TODO
                    CJ.oracleconn_str = WDHTxt.Text;
                    dt = CJ.Oracle_ReturnDataTable(Cmds.OracleFindALlTable);
                }
                WCCLBox.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    WCCLBox.Items.Add(dt.Rows[i]["name"].ToString());
                }
                if (WDHCbo.SelectedIndex == 0 || WDHCbo.SelectedIndex == 1)
                    dbtype = WDHCbo.Items[1].ToString();
                else
                    dbtype = WDHCbo.Text;
                CJ.OtherDB_ExevuteNonQuery(string.Format(Cmds.SaveDevHeloperConStr, WDHTxt.Text.Trim(), WDHCbo.Text));
            }
            catch
            {
                e.Page = WDBPage;
                MessageBox.Show("该数据库下不存在表，请检查连接串！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //第三步 选择存储位置
        private void WPath_Btn_Click(object sender, EventArgs e)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                this.WPath_Txt.Text = FolderBrowser.SelectedPath.ToString();
            }
        }
        //路径选择完毕，进入自动生成页面
        private void WPath_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            if (WPath_Txt.Text.Trim().Length <= 0)
            {
                e.Page = WPath;
                MessageBox.Show("请先选存储路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }
        //文件自动生成开始
        private void WAutoCreate_ShowFromNext(object sender, EventArgs e)
        {
            Core.Cmds.MSSQLConn = WDHTxt.Text.Trim();
            if (WDHCbo.SelectedIndex == 0)
            {
                ExtNetAutoCore.Cmds.MSSQLFindTableStructs = ExtNetAutoCore.Cmds.MSSQLFindTableStructs2000;
                Core.Cmds.MSSQLFindTableStructs = Core.Cmds.MSSQLFindTableStructs2000;
                SampleThreeCore.Cmds.MSSQLFindTableStructs = SampleThreeCore.Cmds.MSSQLFindTableStructs2000;
            }
            else if (WDHCbo.SelectedIndex == 1)
            {
                ExtNetAutoCore.Cmds.MSSQLFindTableStructs = ExtNetAutoCore.Cmds.MSSQLFindTableStructs2005;
                Core.Cmds.MSSQLFindTableStructs = Core.Cmds.MSSQLFindTableStructs2005;
                SampleThreeCore.Cmds.MSSQLFindTableStructs = SampleThreeCore.Cmds.MSSQLFindTableStructs2005;
            }
            if (RBtnFrame_MVC.Checked)
            {
                Thread autocreate = new Thread(new ThreadStart(AutoCreate));
                autocreate.Start();
            }
            else if (RBtnFrame_SampleThree.Checked)
            {
                Thread autocreate = new Thread(new ThreadStart(SampleThreeAutoCreate));
                autocreate.Start();
            }
            else if (RBtnFrame_ExtNet.Checked)
            {
                Thread autocreate = new Thread(new ThreadStart(ExtNetAutoCreate));
                autocreate.Start();
            }
            Wizard_DHelper.NextEnabled = false;
            Wizard_DHelper.CancelEnabled = false;
            Wizard_DHelper.BackEnabled = false;
        }

        //简单三层架构自动生成
        private void ExtNetAutoCreate()
        {
            string Msg = "";
            PrintLine("自动生成开始，请稍后......");
            PBar(5);
            PrintLine("正在准备文件......");
            ExtNetAutoCore.CreateFiles cf = new ExtNetAutoCore.CreateFiles();
            Msg = cf.SetFilesReady();
            if (Msg == "OK")
            {
                PBar(25);
                PrintLine("文件准备就绪，开始生成......");
            }
            else
            {
                PrintLine("文件准备失败，自动生成无法进行！\r\nERROR:" + Msg);
                return;//文件准备失败，则取消生成
            }
            ExtNetAutoCore.CreateModel cm = new ExtNetAutoCore.CreateModel();
            PrintLine("开始生成Model......");
            Msg = cm.BuildModels(WPath_Txt.Text, list, dbtype);
            if (Msg == "OK")
            {
                PBar(45);
                PrintLine("Model生成成功！");
            }
            else
                PrintLine("Model生成失败！\r\nERROR:" + Msg);
            ExtNetAutoCore.CreateDao cdao = new ExtNetAutoCore.CreateDao();
            PrintLine("开始生成DAO......");
            Msg = cdao.BuildDaos(WPath_Txt.Text, list, dbtype);
            if (Msg == "OK")
            {
                PBar(55);
                PrintLine("DAO生成成功！");
            }
            else
                PrintLine("DAO生成失败！\r\nERROR:" + Msg);
            ExtNetAutoCore.CreateBll cbll = new ExtNetAutoCore.CreateBll();
            PrintLine("开始生成BLL......");
            Msg = cbll.BuildBLL(WPath_Txt.Text, list);
            if (Msg == "OK")
            {
                PBar(65);
                PrintLine("BLL生成成功！");
            }
            else
                PrintLine("Bll生成失败！\r\nERROR:" + Msg);

            PBar(75);
            ExtNetAutoCore.CreateUI UI = new ExtNetAutoCore.CreateUI();
            PrintLine("开始生成UI文件......");
            Msg = UI.CreatePage(WPath_Txt.Text, list, dbtype);
            if (Msg == "OK")
            {
                PBar(90);
                PrintLine("UI文件生成成功！");
            }
            else
                PrintLine("UI文件生成失败！\r\nERROR:" + Msg);
            PrintLine("删除临时文件......");
            PBar(95);
            ExtNetAutoCore.CreateRelation clear = new ExtNetAutoCore.CreateRelation();
            clear.DelFiles();
            PrintLine("临时文件删除成功！");
            PrintLine("您选择的业务已经生成完毕！");
            PBar(100);
        }
        //简单三层架构自动生成
        private void SampleThreeAutoCreate()
        {
            string Msg = "";
            PrintLine("自动生成开始，请稍后......");
            PBar(5);
            PrintLine("正在准备文件......");
            CreateFiles cf = new CreateFiles();
            Msg = cf.SetFilesReady();
            if (Msg == "OK")
            {
                PBar(25);
                PrintLine("文件准备就绪，开始生成......");
            }
            else
            {
                PrintLine("文件准备失败，自动生成无法进行！\r\nERROR:" + Msg);
                return;//文件准备失败，则取消生成
            }
            SampleThreeCore.CreateModel cm = new SampleThreeCore.CreateModel();
            PrintLine("开始生成Model......");
            Msg = cm.BuildModels(WPath_Txt.Text, list, dbtype);
            if (Msg == "OK")
            {
                PBar(45);
                PrintLine("Model生成成功！");
            }
            else
                PrintLine("Model生成失败！\r\nERROR:" + Msg);
            SampleThreeCore.CreateDao cdao = new SampleThreeCore.CreateDao();
            PrintLine("开始生成DAO......");
            Msg = cdao.BuildDaos(WPath_Txt.Text, list, dbtype);
            if (Msg == "OK")
            {
                PBar(55);
                PrintLine("DAO生成成功！");
            }
            else
                PrintLine("DAO生成失败！\r\nERROR:" + Msg);
            SampleThreeCore.CreateBll cbll = new SampleThreeCore.CreateBll();
            PrintLine("开始生成BLL......");
            Msg = cbll.BuildBLL(WPath_Txt.Text, list);
            if (Msg == "OK")
            {
                PBar(65);
                PrintLine("BLL生成成功！");
            }
            else
                PrintLine("Bll生成失败！\r\nERROR:" + Msg);
            SampleThreeCore.CreateControllers cc = new SampleThreeCore.CreateControllers();
            PrintLine("开始生成Controller......");
            Msg = cc.BuildController(WPath_Txt.Text, list);
            if (Msg == "OK")
            {
                PBar(75);
                PrintLine("Controller生成成功！");
            }
            else
                PrintLine("Controller生成失败！\r\nERROR:" + Msg);
            CreateExtjs cextjs = new CreateExtjs();
            PrintLine("开始生成UI文件......");
            Msg = cextjs.BuildUI(WPath_Txt.Text, list, dbtype);
            if (Msg == "OK")
            {
                PBar(90);
                PrintLine("UI文件生成成功！");
            }
            else
                PrintLine("UI文件生成失败！\r\nERROR:" + Msg);
            PrintLine("删除临时文件......");
            PBar(95);
            CreateRelation clear = new CreateRelation();
            clear.DeleteFiles();
            PrintLine("临时文件删除成功！");
            PrintLine("您选择的业务已经生成完毕！");
            PBar(100);
        }

        //MVC架构自动生成
        private void AutoCreate()
        {
            string Msg = "";
            PrintLine("自动生成开始，请稍后......");
            PBar(5);
            PrintLine("正在准备文件......");
            CreateFiles cf = new CreateFiles();
            Msg = cf.SetFilesReady();
            if (Msg == "OK")
            {
                PBar(25);
                PrintLine("文件准备就绪，开始生成......");
            }
            else
            {
                PrintLine("文件准备失败，自动生成无法进行！\r\nERROR:" + Msg);
                return;//文件准备失败，则取消生成
            }
            CreateModel cm = new CreateModel();
            PrintLine("开始生成Model......");
            Msg = cm.BuildModel(WPath_Txt.Text, list, dbtype);
            if (Msg == "OK")
            {
                PBar(45);
                PrintLine("Model生成成功！");
            }
            else
                PrintLine("Model生成失败！\r\nERROR:" + Msg);
            CreateDao cdao = new CreateDao();
            PrintLine("开始生成DAO......");
            Msg = cdao.BuildDaoAndInterface(WPath_Txt.Text, list, dbtype);
            if (Msg == "OK")
            {
                PBar(55);
                PrintLine("DAO生成成功！");
            }
            else
                PrintLine("DAO生成失败！\r\nERROR:" + Msg);
            CreateBLL cbll = new CreateBLL();
            PrintLine("开始生成BLL......");
            Msg = cbll.BuildBLL(WPath_Txt.Text, list);
            if (Msg == "OK")
            {
                PBar(65);
                PrintLine("BLL生成成功！");
            }
            else
                PrintLine("Bll生成失败！\r\nERROR:" + Msg);
            CreateController cc = new CreateController();
            PrintLine("开始生成Controller......");
            Msg = cc.BuildController(WPath_Txt.Text, list);
            if (Msg == "OK")
            {
                PBar(75);
                PrintLine("Controller生成成功！");
            }
            else
                PrintLine("Controller生成失败！\r\nERROR:" + Msg);
            CreateExtjs cextjs = new CreateExtjs();
            PrintLine("开始生成UI文件......");
            Msg = cextjs.BuildUI(WPath_Txt.Text, list, dbtype);
            if (Msg == "OK")
            {
                PBar(90);
                PrintLine("UI文件生成成功！");
            }
            else
                PrintLine("UI文件生成失败！\r\nERROR:" + Msg);
            CreateRelation clear = new CreateRelation();
            PrintLine("开始建立层间关系......");
            Msg = clear.BuildRelationShip(WPath_Txt.Text, list);
            if (Msg == "OK")
            {
                PBar(98);
                PrintLine("层间关系建立成功！");
            }
            else
                PrintLine("层间关系建立失败！\r\nERROR:" + Msg);
            PrintLine("您选择的业务已经生成完毕！");
            PBar(100);
        }

        //UI线程
        private void PBar(int n)
        {
            if (this.InvokeRequired)//这里最关键
            {
                UpdatePBar upbar = new UpdatePBar(PBar);
                this.Invoke(upbar, new object[] { n });
            }
            else
            {
                WAutoCreate_PBar.Value = n;
                if (n == 100)
                    Wizard_DHelper.NextEnabled = true;
            }
        }
        public void PrintLine(string txt)
        {
            if (this.InvokeRequired)//这里最关键
            {
                UpdatePrint setprint = new UpdatePrint(PrintLine);
                this.Invoke(setprint, new object[] { txt });
            }
            else
            {
                if (txt.Contains("ERROR"))
                    WAutoCreate_TxtDetail.SelectionColor = Color.Red;
                else
                    WAutoCreate_TxtDetail.SelectionColor = Color.Lime;
                WAutoCreate_TxtDetail.AppendText("CJ> " + txt + "\r\n" + "\r\n");
                this.WAutoCreate_TxtDetail.Focus();
                if (txt.Contains("生成完毕") || txt.Contains("文件准备失败"))
                {
                    Wizard_DHelper.NextEnabled = true;
                    Wizard_DHelper.CancelEnabled = true;
                    Wizard_DHelper.BackEnabled = true;
                }
                Application.DoEvents();
            }
        }



    }
}
