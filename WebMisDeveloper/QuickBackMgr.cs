using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CJ_DBOperater;
using System.Threading;
using Core;

namespace WebMisDeveloper
{
    public partial class QuickBackMgr : Form
    {
        public QuickBackMgr()
        {
            InitializeComponent();
        }
        private ArrayList list = new ArrayList();//存储用户选择的表
        private delegate void UpdatePBar(int n);  //更新UI的进度条空间
        private delegate void UpdatePrint(string txt); //更新UI的文本框
        private string dbtype = "";//数据库类型
        private void Cbo_DBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.GetQuickBackConStr, Cbo_DBType.Text));
            if (dt.Rows.Count > 0)
                TxtDBConnStr.Text = dt.Rows[0]["DBconstring"].ToString();
        }

        private void QuickBackMgr_Load(object sender, EventArgs e)
        {
            CJ.oleDbconn_str = Cmds.AccessConnString;
            Cbo_DBType.SelectedIndex = 0;
        }

        private void BtnTryConn_Click(object sender, EventArgs e)
        {
            DBConnTest dtest = new DBConnTest();
            dtest.DBConnTry(Cbo_DBType.Text, TxtDBConnStr.Text);
        }
        //数据库配置页面转到下一页触发事件
        private void WizardPage_DBCfg_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            try
            {
                list.Clear();//情况存储表列表
                DataTable dt = new DataTable();
                if (Cbo_DBType.SelectedIndex == 0 || Cbo_DBType.SelectedIndex == 1)
                {
                    CJ.sqlconn_str = TxtDBConnStr.Text;
                    dt = CJ.SQL_ReturnDataTable(Cmds.MSSQLFindAllTable);
                }
                else if (Cbo_DBType.SelectedIndex == 2)
                {
                    CJ.oracleconn_str = TxtDBConnStr.Text;
                    CJ.Oracle_ExecuteNonQuery(Cmds.OracleClearTable);
                    dt = CJ.Oracle_ReturnDataTable(Cmds.OracleFindALlTable);
                }
                if (dt.Rows.Count <= 0)
                {
                    e.Page = WizardPage_DBCfg;
                    MessageBox.Show("该数据库下不存在表，请检查数据库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                        list.Add(dt.Rows[i]["name"].ToString());//添加表list中
                    this.GBoxPath.Text = "共找到" + list.Count.ToString() + "张表，请选择生成位置";
                    CJ.OtherDB_ExevuteNonQuery(string.Format(Cmds.SaveQuickBackConStr, TxtDBConnStr.Text.Trim(), Cbo_DBType.Text));

                    if (Cbo_DBType.SelectedIndex == 0 || Cbo_DBType.SelectedIndex == 1)
                        dbtype = Cbo_DBType.Items[1].ToString();
                    else
                        dbtype = Cbo_DBType.Text;
                }
            }
            catch
            {
                e.Page = WizardPage_DBCfg;
                MessageBox.Show("数据库连接错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void WizardPage_CfgPath_BtnView_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.WizardPage_CfgPath_TxtPath.Text = folderBrowserDialog.SelectedPath.ToString();
            }
        }

        private void WizardPage_CfgPath_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            if (WizardPage_CfgPath_TxtPath.Text.Trim().Length <= 0)
            {
                e.Page = WizardPage_CfgPath;
                MessageBox.Show("请先选存储路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void QB_Wizard_CloseFromCancel(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("您确定退出后台速成吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }
        //自动生成页面 显示的时候
        private void WizardPage_AutoCreate_ShowFromNext(object sender, EventArgs e)
        {
            this.QB_Wizard.NextEnabled = false;
            this.QB_Wizard.CancelEnabled = false;
            Core.Cmds.MSSQLConn = TxtDBConnStr.Text.Trim();
            if (dbtype == "SQLServer2005")
            {
                list.Remove("roles");
                list.Remove("userinfo");
                list.Remove("rolefun");
                list.Remove("userfun");
                list.Remove("newsinfo");
            }
            else if (dbtype == "Oracle")
            {
                list.Remove("ROLES");
                list.Remove("USERINFO");
                list.Remove("ROLEFUN");
                list.Remove("USERFUN");
                list.Remove("NEWSINFO");
            }
            if (MessageBox.Show("系统将会自动删除与roles,userinfo,rolefun,userfun,newsinfo重名的表，是否继续？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (Cbo_DBType.SelectedIndex == 0)
                {
                    Core.Cmds.MSSQLFindTableStructs = Core.Cmds.MSSQLFindTableStructs2000;
                    SampleThreeCore.Cmds.MSSQLFindTableStructs = SampleThreeCore.Cmds.MSSQLFindTableStructs2000;
                    ExtNetAutoCore.Cmds.MSSQLFindTableStructs = ExtNetAutoCore.Cmds.MSSQLFindTableStructs2000;
                }
                else if (Cbo_DBType.SelectedIndex == 1)
                {
                    Core.Cmds.MSSQLFindTableStructs = Core.Cmds.MSSQLFindTableStructs2005;
                    SampleThreeCore.Cmds.MSSQLFindTableStructs = SampleThreeCore.Cmds.MSSQLFindTableStructs2005;
                    ExtNetAutoCore.Cmds.MSSQLFindTableStructs = ExtNetAutoCore.Cmds.MSSQLFindTableStructs2005;
                }
                if (RBtnFrame_MVC.Checked)
                {
                    //MVC架构自动生成
                    Thread autocreate = new Thread(new ThreadStart(AutoCreate));
                    autocreate.Start();
                }
                else if (RBtnFrame_SampleThree.Checked)
                {
                    //简单三层架构自动生成 
                    Thread autocreate = new Thread(new ThreadStart(SampleThreeAutoCreate));
                    autocreate.Start();
                }
                else if (RBtnFrame_ExtNet.Checked)
                {
                    //基于Ext.net 简单三层架构自动生成 
                    Thread autocreate = new Thread(new ThreadStart(ExtNetAutoCreate));
                    autocreate.Start();
                }
            }
            else
                this.Close();
        }

        /// <summary>
        /// Ext.net简单三层架构自动生成
        /// </summary>
        private void ExtNetAutoCreate()
        {
            string Msg = "";
            string path = WizardPage_CfgPath_TxtPath.Text;
            PrintLine("后台速成生成开始，请稍后......");
            PBar(1);
            //构建数据库基本表，添加基础数据
            //生成Model，Dao，BLL层间关系
            PrintLine("正在创建基础表......");
            CreateTables ct = new CreateTables();
            Msg = ct.BuildTables(dbtype);
            if (Msg == "OK")
            {
                PBar(5);
                PrintLine("基础表创建成功");
            }
            else
            {
                PrintLine("基础表创建失败，后台速成无法继续进行！\r\nERROR:" + Msg);
                return;
            }
            PrintLine("正在创建基础数据......");
            AddBasicData add = new AddBasicData();
            Msg = add.InsertBasicData(dbtype, list);
            if (Msg == "OK")
            {
                PBar(10);
                PrintLine("基础数据创建成功");
            }
            else
            {
                PrintLine("基础数据创建失败，后台速成无法继续进行！\r\nERROR:" + Msg);
                return;
            }
            PrintLine("正在准备文件，这个过程需要较长时间，请您耐心等待......");
            ExtNetAutoCore.CreateFiles cf = new ExtNetAutoCore.CreateFiles();
            Msg = cf.BuildFrame(WizardPage_CfgPath_TxtPath.Text, dbtype);//TODO Oracle
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
            PrintLine("开始构造Model层......");
            Msg = cm.BuildModels(list, path, dbtype);
            if (Msg == "OK")
            {
                PBar(45);
                PrintLine("Model层构造成功！");
            }
            else
                PrintLine("Model层构造失败！\r\nERROR:" + Msg);

            ExtNetAutoCore.CreateDao cdao = new ExtNetAutoCore.CreateDao();
            PrintLine("开始构造DAO层......");
            Msg = cdao.BuildDaos(list, path, dbtype);
            if (Msg == "OK")
            {
                PBar(55);
                PrintLine("DAO层构造成功！");
            }
            else
                PrintLine("DAO层构造失败！\r\nERROR:" + Msg);

            ExtNetAutoCore.CreateBll cbll = new ExtNetAutoCore.CreateBll();
            PrintLine("开始构造BLL层......");
            Msg = cbll.BuildBLL(list, path);
            if (Msg == "OK")
            {
                PBar(65);
                PrintLine("BLL层构造成功！");
            }
            else
                PrintLine("Bll层构造失败！\r\nERROR:" + Msg);
            PBar(75);
            ExtNetAutoCore.CreateUI UI = new ExtNetAutoCore.CreateUI(); 
            PrintLine("开始构造UI层......");
            Msg = UI.CreatePages(list, path, dbtype);
            if (Msg == "OK")
            {
                PBar(90);
                PrintLine("UI层构造成功！");
            }
            else
                PrintLine("UI层构造失败！\r\nERROR:" + Msg);
            ExtNetAutoCore.CreateRelation clear = new ExtNetAutoCore.CreateRelation();
            PrintLine("开始建立层间关系......");
            Msg = clear.BuildRelationShip(path);
            if (Msg == "OK")
            {
                PBar(98);
                PrintLine("层间关系建立成功！");
            }
            else
                PrintLine("层间关系建立失败！\r\nERROR:" + Msg);

            PrintLine("恭喜您，后台速成生成成功，用户名：admin，密码：123456");
            PBar(100);
        }
        /// <summary>
        /// 简单三层架构自动生成
        /// </summary>
        private void SampleThreeAutoCreate()
        {
            string Msg = "";
            string path = WizardPage_CfgPath_TxtPath.Text;
            PrintLine("后台速成生成开始，请稍后......");
            PBar(1);
            //构建数据库基本表，添加基础数据
            //生成Model，Dao，BLL，Controller，层间关系
            PrintLine("正在创建基础表......");
            CreateTables ct = new CreateTables();
            Msg = ct.BuildTables(dbtype);
            if (Msg == "OK")
            {
                PBar(5);
                PrintLine("基础表创建成功");
            }
            else
            {
                PrintLine("基础表创建失败，后台速成无法继续进行！\r\nERROR:" + Msg);
                return;
            }
            PrintLine("正在创建基础数据......");
            AddBasicData add = new AddBasicData();
            Msg = add.InsertBasicData(dbtype, list);
            if (Msg == "OK")
            {
                PBar(10);
                PrintLine("基础数据创建成功");
            }
            else
            {
                PrintLine("基础数据创建失败，后台速成无法继续进行！\r\nERROR:" + Msg);
                return;
            }
            PrintLine("正在准备文件，这个过程需要较长时间，请您耐心等待......");
            SampleThreeCore.CreateFiles cf = new SampleThreeCore.CreateFiles();
            Msg = cf.BuildFrame(WizardPage_CfgPath_TxtPath.Text, dbtype);//TODO Oracle
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
            PrintLine("开始构造Model层......");
            Msg = cm.BuildModels(list, path, dbtype);
            if (Msg == "OK")
            {
                PBar(45);
                PrintLine("Model层构造成功！");
            }
            else
                PrintLine("Model层构造失败！\r\nERROR:" + Msg);

            SampleThreeCore.CreateDao cdao = new SampleThreeCore.CreateDao();
            PrintLine("开始构造DAO层......");
            Msg = cdao.BuildDaos(list, path, dbtype);
            if (Msg == "OK")
            {
                PBar(55);
                PrintLine("DAO层构造成功！");
            }
            else
                PrintLine("DAO层构造失败！\r\nERROR:" + Msg);

            SampleThreeCore.CreateBll cbll = new SampleThreeCore.CreateBll();
            PrintLine("开始构造BLL层......");
            Msg = cbll.BuildBLL(list, path);
            if (Msg == "OK")
            {
                PBar(65);
                PrintLine("BLL层构造成功！");
            }
            else
                PrintLine("Bll层构造失败！\r\nERROR:" + Msg);

            SampleThreeCore.CreateControllers cc = new SampleThreeCore.CreateControllers();
            PrintLine("开始构造Controller层......");
            Msg = cc.BuildController(list, path);
            if (Msg == "OK")
            {
                PBar(75);
                PrintLine("Controller层构造成功！");
            }
            else
                PrintLine("Controller层构造失败！\r\nERROR:" + Msg);

            CreateExtjs cextjs = new CreateExtjs();
            PrintLine("开始构造UI层......");
            Msg = cextjs.BuildExtjs(list, path, dbtype);
            if (Msg == "OK")
            {
                PBar(90);
                PrintLine("UI层构造成功！");
            }
            else
                PrintLine("UI层构造失败！\r\nERROR:" + Msg);
            SampleThreeCore.CreateRelation clear = new SampleThreeCore.CreateRelation();
            PrintLine("开始建立层间关系......");
            Msg = clear.BuildRelationShip(path);
            if (Msg == "OK")
            {
                PBar(98);
                PrintLine("层间关系建立成功！");
            }
            else
                PrintLine("层间关系建立失败！\r\nERROR:" + Msg);

            PrintLine("恭喜您，后台速成生成成功，用户名：admin，密码：123456");
            PBar(100);
        }
        /// <summary>
        /// MVC架构自动生成
        /// </summary>
        private void AutoCreate()
        {
            string Msg = "";
            string path = WizardPage_CfgPath_TxtPath.Text;
            PrintLine("后台速成生成开始，请稍后......");
            PBar(1);
            //构建数据库基本表，添加基础数据
            //生成Model，Dao，BLL，Controller，层间关系
            PrintLine("正在创建基础表......");
            CreateTables ct = new CreateTables();
            Msg = ct.BuildTables(dbtype);
            if (Msg == "OK")
            {
                PBar(5);
                PrintLine("基础表创建成功");
            }
            else
            {
                PrintLine("基础表创建失败，后台速成无法继续进行！\r\nERROR:" + Msg);
                return;
            }
            PrintLine("正在创建基础数据......");
            AddBasicData add = new AddBasicData();
            Msg = add.InsertBasicData(dbtype,list);
            if (Msg == "OK")
            {
                PBar(10);
                PrintLine("基础数据创建成功");
            }
            else
            {
                PrintLine("基础数据创建失败，后台速成无法继续进行！\r\nERROR:" + Msg);
                return;
            }
            PrintLine("正在准备文件，这个过程需要较长时间，请您耐心等待......");
            CreateFiles cf = new CreateFiles();
            Msg = cf.BuildFrame(WizardPage_CfgPath_TxtPath.Text, dbtype);//TODO Oracle
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
            PrintLine("开始构造Model层......");
            Msg = cm.BuildModel(list, path, dbtype);
            if (Msg == "OK")
            {
                PBar(45);
                PrintLine("Model层构造成功！");
            }
            else
                PrintLine("Model层构造失败！\r\nERROR:" + Msg);

            CreateDao cdao = new CreateDao();
            PrintLine("开始构造DAO层......");
            Msg = cdao.BuildDaoAndInterface(list, path, dbtype);
            if (Msg == "OK")
            {
                PBar(55);
                PrintLine("DAO层构造成功！");
            }
            else
                PrintLine("DAO层构造失败！\r\nERROR:" + Msg);

            CreateBLL cbll = new CreateBLL();
            PrintLine("开始构造BLL层......");
            Msg = cbll.BuildBLL(list, path);
            if (Msg == "OK")
            {
                PBar(65);
                PrintLine("BLL层构造成功！");
            }
            else
                PrintLine("Bll层构造失败！\r\nERROR:" + Msg);

            CreateController cc = new CreateController();
            PrintLine("开始构造Controller层......");
            Msg = cc.BuildController(list, path);
            if (Msg == "OK")
            {
                PBar(75);
                PrintLine("Controller层构造成功！");
            }
            else
                PrintLine("Controller层构造失败！\r\nERROR:" + Msg);

            CreateExtjs cextjs = new CreateExtjs();
            PrintLine("开始构造UI层......");
            Msg = cextjs.BuildExtjs(list, path, dbtype);
            if (Msg == "OK")
            {
                PBar(90);
                PrintLine("UI层构造成功！");
            }
            else
                PrintLine("UI层构造失败！\r\nERROR:" + Msg);
            CreateRelation clear = new CreateRelation();
            PrintLine("开始建立层间关系......");
            Msg = clear.BuildRelationShip(list, path);
            if (Msg == "OK")
            {
                PBar(98);
                PrintLine("层间关系建立成功！");
            }
            else
                PrintLine("层间关系建立失败！\r\nERROR:" + Msg);

            PrintLine("恭喜您，后台速成生成成功，用户名：admin，密码：123456");
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
                WizardPage_AutoCreate_PBar.Value = n;
                if (n == 100)
                    QB_Wizard.NextEnabled = true;
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
                    WizardPage_AutoCreate_TxtDetail.SelectionColor = Color.Red;
                else
                    WizardPage_AutoCreate_TxtDetail.SelectionColor = Color.Lime;
                WizardPage_AutoCreate_TxtDetail.AppendText("CJ> " + txt + "\r\n" + "\r\n");
                this.WizardPage_AutoCreate_TxtDetail.Focus();
                Application.DoEvents();
            }
        }

    }
}
