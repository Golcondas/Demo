using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJ_DBOperater;
using Core;
using SampleThreeCore;
using System.Threading;

namespace WebMisDeveloper
{
    public partial class Leader : Form
    {
        public Leader()
        {
            InitializeComponent();
        }
        public string CurrentDBName = "";
        public ArrayList MenuList = new ArrayList();//功能菜单树
        public ArrayList MenuCanClickList = new ArrayList();
        public string DatabaseType = "";//数据库类型
        //退出向导
        private void MainWizard_CloseFromCancel(object sender, CancelEventArgs e)
        {
            //删除已经添加的数据库和表
            if (MessageBox.Show("您确定退出自动生成向导吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }
        //页面加载事件
        private void Leader_Load(object sender, EventArgs e)
        {
            WizardPage_CfgDB_NewDBType.SelectedIndex = 0;
            CJ.oleDbconn_str = Cmds.AccessConnString;
        }

        #region 第一步配置数据库
        //加载已有模板库
        private void WizardPage_CfgDB_RBtn_OldDBConn_CheckedChanged(object sender, EventArgs e)
        {
            WizardPage_CfgDB_GroupBoxTemplate.Enabled = WizardPage_CfgDB_RBtn_TempDBConn.Checked;
            if (WizardPage_CfgDB_RBtn_TempDBConn.Checked == true)
            {
                WizardPage_CfgDB_TempAllDB.Items.Clear();
                DataTable dt = CJ.OtherDB_ReturnDataTable(Cmds.FindAllTemplate);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    WizardPage_CfgDB_TempAllDB.Items.Add(dt.Rows[i]["DBName"].ToString());
                }
            }
        }
        //新建数据库连接
        private void WizardPage_CfgDB_RBtn_NewDBConn_CheckedChanged(object sender, EventArgs e)
        {
            WizardPage_CfgDB_GroupBoxNew.Enabled = WizardPage_CfgDB_RBtn_NewDBConn.Checked;
        }
        //数据库类型更改时
        private void WizardPage_CfgDB_NewDBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WizardPage_CfgDB_NewDBType.SelectedIndex == 0)
            {
                //SQLServer
                WizardPage_CfgDB_NewDBConnString.Text = Cmds.SQLServerString;
            }
            if (WizardPage_CfgDB_NewDBType.SelectedIndex == 1)
            {
                //Oracle
                WizardPage_CfgDB_NewDBConnString.Text = Cmds.OracleString;
            }
            if (WizardPage_CfgDB_NewDBType.SelectedIndex == 2)
            {
                //Access
                WizardPage_CfgDB_NewDBConnString.Text = Cmds.AccessString;
            }
        }
        //测试连接
        private void WizardPage_CfgDB_NewBtnTryConn_Click(object sender, EventArgs e)
        {
            string connstr = WizardPage_CfgDB_NewDBConnString.Text.Trim();
            if (connstr.Length <= 0)
            {
                MessageBox.Show("请先输入连接串！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DBConnTest dtest = new DBConnTest();
            dtest.DBConnTry(WizardPage_CfgDB_NewDBType.Text, connstr);
        }


        //用户选择模板库时
        private void WizardPage_CfgDB_TempAllDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = CJ.OtherDB_ReturnDataTable(String.Format(Cmds.FindTemplateDetails, WizardPage_CfgDB_TempAllDB.Text));
            WizardPage_CfgDB_TempDBType.Text = dt.Rows[0]["DBType"].ToString();
            WizardPage_CfgDB_TempDBConnStrig.Text = dt.Rows[0]["DBConnString"].ToString();
            //当重新选择了数据库，要加载功能菜单树和保存
            isLoadTree = true;
        }
        //已有模板数据库测试连接
        private void WizardPage_CfgDB_TempTryConn_Click(object sender, EventArgs e)
        {
            string connstr = WizardPage_CfgDB_TempDBConnStrig.Text.Trim();
            if (connstr.Length <= 0)
            {
                MessageBox.Show("请先输入连接串！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DBConnTest dtest = new DBConnTest();
            dtest.DBConnTry(WizardPage_CfgDB_TempDBType.Text, connstr);
            SaveConnect();
        }
        //删除模板
        private void WizardPage_CfgDB_TempDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定删除该模板库吗？删除后其对应表也将一起删除", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                CJ.OtherDB_ExevuteNonQuery(string.Format(Cmds.DelDBTemplate, WizardPage_CfgDB_TempAllDB.Text));
                CJ.OtherDB_ExevuteNonQuery(string.Format(Cmds.DelTableInfo, WizardPage_CfgDB_TempAllDB.Text));
                WizardPage_CfgDB_TempAllDB.Items.Remove(WizardPage_CfgDB_TempAllDB.SelectedItem);
                MessageBox.Show("删除模板成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

            }
        }
        //保存修改模板
        private void SaveConnect()
        {
            CJ.OtherDB_ExevuteNonQuery(string.Format(Cmds.UpdateDBTemplate, WizardPage_CfgDB_TempDBConnStrig.Text.Trim(), WizardPage_CfgDB_TempDBType.Text, WizardPage_CfgDB_TempAllDB.Text));
        }

        //下一步，存为模板
        private void WizardPage_CfgDB_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            CJ.oleDbconn_str = Cmds.AccessConnString;
            //此处遗漏Oracle
            //TODO
            if (WizardPage_CfgDB_RBtn_NewDBConn.Checked == true)
            {
                if (WizardPage_CfgDB_NewDBName.Text.Trim().Length <= 0 || WizardPage_CfgDB_NewDBConnString.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("您的信息不完整，请检查！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    e.Page = WizardPage_CfgDB;
                    return;
                }
                CurrentDBName = WizardPage_CfgDB_NewDBName.Text.Trim();
                DatabaseType = WizardPage_CfgDB_NewDBType.Text;
                DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindTemplateDetails, CurrentDBName));
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("该数据库已经存在于模板库中，请改用其他数据库名称！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    e.Page = WizardPage_CfgDB;
                    return;
                }
                else
                {
                    CJ.OtherDB_ExevuteNonQuery(string.Format(Cmds.AddNewDBTemplate, WizardPage_CfgDB_NewDBName.Text.Trim(), WizardPage_CfgDB_NewDBConnString.Text.Trim(), WizardPage_CfgDB_NewDBType.Text));
                    //当重新选择了数据库，要加载功能菜单树和保存
                    isLoadTree = true;
                }
            }
            else if (WizardPage_CfgDB_RBtn_TempDBConn.Checked == true)
            {
                if (WizardPage_CfgDB_TempDBConnStrig.Text.Trim().Length <= 0 || WizardPage_CfgDB_TempAllDB.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("您的信息不完整，请检查！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    e.Page = WizardPage_CfgDB;
                    return;
                }
                else
                {
                    CurrentDBName = WizardPage_CfgDB_TempAllDB.Text;
                    DatabaseType = WizardPage_CfgDB_TempDBType.Text;
                }
            }
            DataTable dttables = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindDBTables, CurrentDBName));
            WizardPage_Table_DGV.DataSource = dttables;
            WizardPage_Table_CurrentDBName.Text = CurrentDBName + "数据库已存在表 共:" + dttables.Rows.Count.ToString() + "张";

        }

        #endregion

        # region 第二步为数据库配置表
        //添加表
        private void WizardPage_Table_BtnAdd_Click(object sender, EventArgs e)
        {
            TableInfo t = new TableInfo(DatabaseType, CurrentDBName, "", this.WizardPage_Table_DGV, WizardPage_Table_CurrentDBName);
            t.MdiParent = this.MdiParent;
            t.Show();
        }
        //修改
        private void WizardPage_Table_BtnChange_Click(object sender, EventArgs e)
        {
            try
            {
                TableInfo t = new TableInfo(DatabaseType, CurrentDBName, WizardPage_Table_DGV.CurrentRow.Cells[1].Value.ToString(), this.WizardPage_Table_DGV, WizardPage_Table_CurrentDBName);
                t.MdiParent = this.MdiParent;
                t.Show();
            }
            catch
            {
                MessageBox.Show("请先选择要修改的表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //删除
        private void WizardPage_Table_BtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("您确定删除“" + WizardPage_Table_DGV.CurrentRow.Cells[1].Value.ToString() + "”表吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
                {
                    CJ.OtherDB_ExevuteNonQuery(string.Format(Cmds.DelTableColumn, WizardPage_Table_DGV.CurrentRow.Cells[1].Value.ToString(),CurrentDBName));
                    WizardPage_Table_DGV.Rows.Remove(WizardPage_Table_DGV.CurrentRow);
                    WizardPage_Table_CurrentDBName.Text = CurrentDBName + "数据库已存在表 共:" + WizardPage_Table_DGV.Rows.Count.ToString() + "张";
                    MessageBox.Show("删除成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("无法找到您要删除的表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //编辑数据库表，用户单击表，填充编辑表窗体
        private void WizardPage_Table_DGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                TableInfo t = new TableInfo(DatabaseType, CurrentDBName, WizardPage_Table_DGV.CurrentRow.Cells[1].Value.ToString(), this.WizardPage_Table_DGV, WizardPage_Table_CurrentDBName);
                t.MdiParent = this.MdiParent;
                t.Show();
            }
            catch
            {
                MessageBox.Show("请先选择要修改的表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //显示序号
        private void WizardPage_Table_DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            WizardPage_Table_DGV.RowHeadersWidth = 50;
            WizardPage_Table_DGV.TopLeftHeaderCell.Value = "序号";
            int r = WizardPage_Table_DGV.Rows.Count;
            for (int i = 1; i <= r; i++)
                WizardPage_Table_DGV.Rows[i - 1].HeaderCell.Value = i.ToString();
        }
        #endregion

        #region 第三步配置功能菜单树

        //拖动树节点
        private void WizardPage_CfgMenu_Tree_DragDrop(object sender, DragEventArgs e)
        {
            //获得拖放中的节点
            TreeNode moveNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            //根据鼠标坐标确定要移动到的目标节点
            Point pt;
            TreeNode targeNode;
            pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
            targeNode = this.WizardPage_CfgMenu_Tree.GetNodeAt(pt);
            //如果目标节点无子节点则添加为同级节点,反之添加到下级节点的未端
            TreeNode NewMoveNode = (TreeNode)moveNode.Clone();
            if (targeNode.Nodes.Count == 0)
            {
                targeNode.Parent.Nodes.Insert(targeNode.Index, NewMoveNode);
            }
            else
            {
                targeNode.Nodes.Insert(targeNode.Nodes.Count, NewMoveNode);
            }
            //更新当前拖动的节点选择
            WizardPage_CfgMenu_Tree.SelectedNode = NewMoveNode;
            //展开目标节点,便于显示拖放效果
            targeNode.Expand();
            //移除拖放的节点
            moveNode.Remove();
            MenuChange = true;
        }

        private void WizardPage_CfgMenu_Tree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void WizardPage_CfgMenu_Tree_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode"))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void WizardPage_CfgMenu_BtnUP_Click(object sender, EventArgs e)
        {
            TreeNode Node = WizardPage_CfgMenu_Tree.SelectedNode;
            TreeNode PrevNode = Node.PrevNode;
            if (PrevNode != null)
            {
                TreeNode NewNode = (TreeNode)Node.Clone();
                if (Node.Parent == null)
                {
                    WizardPage_CfgMenu_Tree.Nodes.Insert(PrevNode.Index, NewNode);
                }
                else
                {
                    Node.Parent.Nodes.Insert(PrevNode.Index, NewNode);
                }
                Node.Remove();
                WizardPage_CfgMenu_Tree.SelectedNode = NewNode;
                MenuChange = true;
            }

        }

        private void WizardPage_CfgMenu_BtnDown_Click(object sender, EventArgs e)
        {
            TreeNode Node = WizardPage_CfgMenu_Tree.SelectedNode;
            TreeNode NextNode = Node.NextNode;
            if (NextNode != null)
            {
                TreeNode NewNode = (TreeNode)Node.Clone();
                if (Node.Parent == null)
                {
                    WizardPage_CfgMenu_Tree.Nodes.Insert(NextNode.Index + 1, NewNode);
                }
                else
                {
                    Node.Parent.Nodes.Insert(NextNode.Index + 1, NewNode);
                }
                Node.Remove();
                WizardPage_CfgMenu_Tree.SelectedNode = NewNode;
                MenuChange = true;
            }
        }


        //当树形配置页面显示时
        private bool isLoadTree = true;//显示功能菜单树时候是否要从数据库加载
        private void WizardPage_CfgMenu_ShowFromNext(object sender, EventArgs e)
        {
            WizardPage_CfgMenu_CbTable.Items.Clear();
            DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindDBTables, CurrentDBName));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WizardPage_CfgMenu_CbTable.Items.Add(dt.Rows[i][1].ToString());
            }
            WizardPage_CfgMenu_CbTable.Items.Add("无");
            if (isLoadTree)
                GetMenu();//加载功能菜单树
        }
        //加载功能菜单树
        private void GetMenu()
        {
            DataTable MenuDt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindMenu, CurrentDBName));
            if (MenuDt.Rows.Count <= 0)
                MenuDt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindMenu, "Null"));
            DataRow[] FatherMenuRow = MenuDt.Select("fatherid=0");
            TreeNode root = WizardPage_CfgMenu_Tree.Nodes[0];
            root.Nodes.Clear();
            getNBMenu(root,FatherMenuRow, MenuDt);
           
        }
        private void getNBMenu(TreeNode root,DataRow[] FatherMenuRow, DataTable ChildrenMenuRow)
        {
            for (int i = 0; i < FatherMenuRow.Count();i++)
            {
                TreeNode node = new TreeNode();
                node.Text = FatherMenuRow[i]["funname"].ToString();
                node.Name = FatherMenuRow[i]["funno"].ToString();
                DataRow[] leafRow=ChildrenMenuRow.Select("fatherid=" + FatherMenuRow[i]["funid"].ToString() + "");
                if (leafRow.Count() > 0)
                {
                    node.Tag = "无";
                    node.SelectedImageIndex = 2;
                    node.ImageIndex = 1;
                    getNBMenu(node,leafRow, ChildrenMenuRow);
                }
                else
                {
                    string tag = FatherMenuRow[i]["funno"].ToString();
                    if (tag.Contains("Menu"))
                        node.Tag = tag.Substring(0, tag.LastIndexOf("M"));
                    else
                        node.Tag = "无";
                    node.SelectedImageIndex = 3;
                    node.ImageIndex = 3;
                }
                root.Nodes.Add(node);
            }
            isLoadTree = false;
        }
        //选中树节点时
        private void WizardPage_CfgMenu_Tree_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = WizardPage_CfgMenu_Tree.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                WizardPage_CfgMenu_TxtNodeID.Text = node.Name;
                WizardPage_CfgMenu_TxtNodeName.Text = node.Text;
                if (node.Tag != null)
                {
                    WizardPage_CfgMenu_CbTable.Text = node.Tag.ToString();
                }
                else
                {
                    WizardPage_CfgMenu_CbTable.Text = "无";
                }
            }
        }
        //修改节点
        private bool MenuChange = false;
        private void WizardPage_CfgMenu_BtnSave_Click(object sender, EventArgs e)
        {
            TreeNode node = this.WizardPage_CfgMenu_Tree.SelectedNode;
            if (node != null)
            {
                if (WizardPage_CfgMenu_TxtNodeID.Text.Trim().Length > 0 && WizardPage_CfgMenu_TxtNodeName.Text.Trim().Length > 0)
                {
                    if (WizardPage_CfgMenu_CbTable.Text != "无")
                        node.Name = WizardPage_CfgMenu_CbTable.Text.ToLower() + "Menu";
                    else
                        node.Name = WizardPage_CfgMenu_TxtNodeID.Text.Trim();
                    node.Text = WizardPage_CfgMenu_TxtNodeName.Text.Trim();
                    node.Tag = WizardPage_CfgMenu_CbTable.Text;
                    MenuChange = true;
                }
            }
        }
        //添加新节点
        private void WizardPage_CfgMenu_BtnAdd_Click(object sender, EventArgs e)
        {
            TreeNode node = this.WizardPage_CfgMenu_Tree.SelectedNode;
            if (node != null)
            {
                if (WizardPage_CfgMenu_TxtNodeID.Text.Trim().Length > 0 && WizardPage_CfgMenu_TxtNodeName.Text.Trim().Length > 0)
                {
                    TreeNode t = new TreeNode();
                    if (WizardPage_CfgMenu_CbTable.Text != "无")
                        t.Name = WizardPage_CfgMenu_CbTable.Text.ToLower() + "Menu";
                    else
                    {
                        if (WizardPage_CfgMenu_TxtNodeID.Text.Trim() == "TreeRoot" || WizardPage_CfgMenu_TxtNodeID.Text.Trim().Contains("menu"))
                        {
                            MessageBox.Show("节点ID命名非法，节点ID不能包含TreeRoot和Menu！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        t.Name = WizardPage_CfgMenu_TxtNodeID.Text.Trim();

                    }
                    t.Text = WizardPage_CfgMenu_TxtNodeName.Text.Trim();
                    t.Tag = WizardPage_CfgMenu_CbTable.Text;
                    t.SelectedImageIndex = 3;
                    t.ImageIndex = 3;
                    if (node.Name.ToString() != "TreeRoot")
                    {//重新编辑节点图表
                        node.SelectedImageIndex = 2;
                        node.ImageIndex = 1;
                    }
                    node.Nodes.Add(t);
                    MenuChange = true;
                }
            }
        }

        private void WizardPage_CfgMenu_BtnDel_Click(object sender, EventArgs e)
        {
            if (WizardPage_CfgMenu_Tree.SelectedNode.Name == "sysMgr" || WizardPage_CfgMenu_Tree.SelectedNode.Name == "newsMgr" || WizardPage_CfgMenu_Tree.SelectedNode.Name == "TreeRoot" || WizardPage_CfgMenu_Tree.SelectedNode.Parent.Name == "newsMgr" || WizardPage_CfgMenu_Tree.SelectedNode.Parent.Name == "sysMgr")
            {
                MessageBox.Show("很抱歉，基础数据节点不允许删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            WizardPage_CfgMenu_Tree.Nodes.Remove(WizardPage_CfgMenu_Tree.SelectedNode);
            MenuChange = true;
        }
        //下拉框状态改变
        private void WizardPage_CfgMenu_CbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WizardPage_CfgMenu_CbTable.Text != "无")
            {
                WizardPage_CfgMenu_TxtNodeID.Text = WizardPage_CfgMenu_CbTable.Text.ToLower() + "Menu";
            }
        }
        //递归遍历树
        private void AutoCreateFunMenu()
        {
            TreeNodeCollection nodes = WizardPage_CfgMenu_Tree.Nodes;
            foreach (TreeNode n in nodes)
            {
                GetAllMenu(n);
            }
        }
        //递归遍历树，获得对应的表结构的树
        private void GetAllMenu(TreeNode node)
        {
            string owner = "0";
            string funid = "";
            //当前Node号
            if (node.Parent != null)
            {
                funid = node.Level.ToString() + (node.Parent.Index + 1).ToString() + (node.Index + 1).ToString();
                if (node.Parent.Parent != null)
                    owner = node.Parent.Level.ToString() + (node.Parent.Parent.Index + 1).ToString() + (node.Parent.Index + 1).ToString();
                MenuList.Add(string.Format(Cmds.InsertIntoUserFun, funid, node.Name, node.Text, owner));
                if (node.Tag.ToString() != "无")
                    MenuCanClickList.Add(node.Tag.ToString());
            }
            foreach (TreeNode tn in node.Nodes)
            {
                GetAllMenu(tn);
            }
        }

        //菜单配置完了，进入下一步
        private void WizardPage_CfgMenu_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            MenuCanClickList.Clear();
            MenuList.Clear();
            AutoCreateFunMenu();
            if (MenuChange == true)
                SaveMenu();
            this.WizardPage_CfgPath_LbWarnning.Text = "警告：请确保您当前数据库服务器中没有与" + CurrentDBName + "重名的数据库，自动生成将删除重名数据库";
        }
        //保存用户的功能菜单树
        private void SaveMenu()
        {
            CJ.OtherDB_ExevuteNonQuery(string.Format(Cmds.DelFunMenu, CurrentDBName));//首先清空原始菜单
            for (int i = 0; i < MenuList.Count; i++)
            {
                CJ.OtherDB_ExevuteNonQuery(MenuList[i].ToString().Replace(")", ",'" + CurrentDBName + "')").Replace("values", "(funid,funno,funname,fatherid,DBName) values"));
            }
            MenuChange = false;
        }

        #endregion

        #region 第四步配置生成路径

        private void WizardPage_CfgPath_BtnView_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (f.SelectedPath.Contains("桌面"))
                { MessageBox.Show("生成位置不能为桌面！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                this.WizardPage_CfgPath_TxtPath.Text = f.SelectedPath;
            }
        }

        private void WizardPage_CfgPath_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            if (this.WizardPage_CfgPath_TxtPath.Text.Trim().Length <= 0)
            {
                MessageBox.Show("请先配置生成位置！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Page = WizardPage_CfgPath;
            }
            else
            {
                e.Page = WizardPage_AutoCreate;
            }
        }

        #endregion

        #region 第五步自动生成开始
        public delegate void SetPrint(string ipos);//设置一个线程代理
        public delegate void SetPBar(int n);
        private void WizardPage_AutoCreate_ShowFromNext(object sender, EventArgs e)
        {
            //线程
            WizardPage_AutoCreate_TxtDetail.Text = "CJ> 准备就绪，开始生成...\r\n\r\n";
            if (RBtnFrame_MVC.Checked)
            {
                Thread threadcore = new Thread(new ThreadStart(AutoCreate));//定义一个线程
                threadcore.Start();//启动一个线程
            }
            else if (RBtnFrame_SampleThree.Checked)
            {
                Thread threadcore = new Thread(new ThreadStart(SampleThreeAutoCreate));//定义一个线程
                threadcore.Start();//启动一个线程
            }
            else if (RBtnFrame_ExtNet.Checked)
            {
                Thread threadcore = new Thread(new ThreadStart(ExtNetAutoCreate));//定义一个线程
                threadcore.Start();//启动一个线程
            }
            MainWizard.BackEnabled = false;
            MainWizard.NextEnabled = false;
            MainWizard.CancelEnabled = false;
        }

        /// <summary>
        /// Ext.net+三层架构 自动生成线程
        /// </summary>
        private void ExtNetAutoCreate()
        {
            string Msg = "";
            pBar(5);
            if (DatabaseType == "SQLServer2005")
            {
                PrintLine("正在创建数据库...");
                CreateDB createdb = new CreateDB();
                pBar(10);

                Msg = createdb.CreateDataBase(CurrentDBName);
                if (Msg == "OK")
                    PrintLine("数据库创建成功！");
                else
                {
                    PrintLine("很抱歉，数据库创建失败！WebMis无法继续生成，请您重试！\r\nERROR:" + Msg);
                    return;
                }
                pBar(20);
            }
            PrintLine("正在创建表...");
            CreateTables createtables = new CreateTables();
            Msg = createtables.AddTables(CurrentDBName);
            if (Msg == "OK")
                PrintLine("所有表创建成功！");
            else
            {
                PrintLine("很抱歉，部分表创建失败！WebMis无法继续生成，请您检查表结构是否正确，再重试！\r\nERROR:" + Msg);
                return;
            }
            pBar(35);
            PrintLine("正在创建基础数据...");
            AddBasicData data = new AddBasicData();
            Msg = data.InsertBasicData(MenuList, CurrentDBName);
            if (Msg == "OK")
                PrintLine("基础数据创建成功！");
            else
            {
                PrintLine("很抱歉，基础数据创建失败！WebMis无法继续生成，请您检查树结构是否正确，再重试！\r\nERROR:" + Msg);
                return;
            }
            pBar(50);
            PrintLine("正在准备框架，这个过程可能会花费很长时间，请您耐心等待...");
            ExtNetAutoCore.CreateFiles cf = new ExtNetAutoCore.CreateFiles();
            Msg = cf.BuildFrame(WizardPage_CfgPath_TxtPath.Text, DatabaseType);
            if (Msg == "OK")
                PrintLine("框架准备就绪...");
            else
            {
                PrintLine("框架部署失败，WebMis无法继续生成！\r\nERROR:" + Msg);
                return;
            }
            pBar(65);
            PrintLine("正在为数据库表生成映射文件...");
            ExtNetAutoCore.CreateModel cm = new ExtNetAutoCore.CreateModel();
            Msg = cm.BuildModels(WizardPage_CfgPath_TxtPath.Text, CurrentDBName);
            if (Msg == "OK")
                PrintLine("映射文件生成成功！");
            else
                PrintLine("映射文件生成失败！\r\nERROR:" + Msg);
            pBar(68);
            PrintLine("正在生成数据操作层...");
            ExtNetAutoCore.CreateDao cdao = new ExtNetAutoCore.CreateDao();
            Msg = cdao.BuildDaos(WizardPage_CfgPath_TxtPath.Text, CurrentDBName);
            if (Msg == "OK")
                PrintLine("数据操作层生成成功！");
            else
                PrintLine("数据操作层生成失败！\r\nERROR:" + Msg);
            pBar(74);
            PrintLine("正在生成业务逻辑层...");
            ExtNetAutoCore.CreateBll cbll = new ExtNetAutoCore.CreateBll();
            Msg = cbll.BuildBLL(WizardPage_CfgPath_TxtPath.Text, CurrentDBName);
            if (Msg == "OK")
                PrintLine("业务逻辑层生成成功！");
            else
                PrintLine("业务逻辑层生成失败！\r\nERROR:" + Msg);
            pBar(78);
            PrintLine("正在生成UI文件...");
            ExtNetAutoCore.CreateUI createui = new ExtNetAutoCore.CreateUI();
            Msg = createui.CreatePages(WizardPage_CfgPath_TxtPath.Text, MenuCanClickList, CurrentDBName);
            pBar(85);
            if (Msg == "OK")
                PrintLine("UI文件生成成功！");
            else
                PrintLine("UI文件生成失败！\r\nERROR:" + Msg);
            pBar(95);
            PrintLine("正在为各层间建立关系...");
            ExtNetAutoCore.CreateRelation crelation = new ExtNetAutoCore.CreateRelation();
            Msg = crelation.BuildRelationShip(WizardPage_CfgPath_TxtPath.Text, CurrentDBName);
            if (Msg == "OK")
                PrintLine("层间关系建立成功！");
            else
                PrintLine("层间关系建立失败！\r\nERROR:" + Msg);
            pBar(99);
            PrintLine("恭喜您，WebMis生成成功,默认用户名：admin，密码：123456");
            pBar(100);
        }

        /// <summary>
        /// 简单三层架构自动生成线程
        /// </summary>
        private void SampleThreeAutoCreate()
        {
            string Msg = "";
            pBar(5);
            if (DatabaseType == "SQLServer2005")
            {
                PrintLine("正在创建数据库...");
                CreateDB createdb = new CreateDB();
                pBar(10);

                Msg = createdb.CreateDataBase(CurrentDBName);
                if (Msg == "OK")
                    PrintLine("数据库创建成功！");
                else
                {
                    PrintLine("很抱歉，数据库创建失败！WebMis无法继续生成，请您重试！\r\nERROR:" + Msg);
                    return;
                }
                pBar(20);
            }
            PrintLine("正在创建表...");
            CreateTables createtables = new CreateTables();
            Msg = createtables.AddTables(CurrentDBName);
            if (Msg == "OK")
                PrintLine("所有表创建成功！");
            else
            {
                PrintLine("很抱歉，部分表创建失败！WebMis无法继续生成，请您检查表结构是否正确，再重试！\r\nERROR:" + Msg);
                return;
            }
            pBar(35);
            PrintLine("正在创建基础数据...");
            AddBasicData data = new AddBasicData();
            Msg = data.InsertBasicData(MenuList, CurrentDBName);
            if (Msg == "OK")
                PrintLine("基础数据创建成功！");
            else
            {
                PrintLine("很抱歉，基础数据创建失败！WebMis无法继续生成，请您检查树结构是否正确，再重试！\r\nERROR:" + Msg);
                return;
            }
            pBar(50);
            PrintLine("正在准备框架，这个过程可能会花费很长时间，请您耐心等待...");
            SampleThreeCore.CreateFiles cf = new SampleThreeCore.CreateFiles();
            Msg = cf.BuildFrame(WizardPage_CfgPath_TxtPath.Text, DatabaseType);
            if (Msg == "OK")
                PrintLine("框架准备就绪...");
            else
            {
                PrintLine("框架部署失败，WebMis无法继续生成！\r\nERROR:" + Msg);
                return;
            }
            pBar(65);
            PrintLine("正在为数据库表生成映射文件...");
            SampleThreeCore.CreateModel cm = new SampleThreeCore.CreateModel();
            Msg = cm.BuildModels(WizardPage_CfgPath_TxtPath.Text, CurrentDBName);
            if (Msg == "OK")
                PrintLine("映射文件生成成功！");
            else
                PrintLine("映射文件生成失败！\r\nERROR:" + Msg);
            pBar(68);
            PrintLine("正在生成数据操作层...");
            SampleThreeCore.CreateDao cdao = new SampleThreeCore.CreateDao();
            Msg = cdao.BuildDaos(WizardPage_CfgPath_TxtPath.Text, CurrentDBName);
            if (Msg == "OK")
                PrintLine("数据操作层生成成功！");
            else
                PrintLine("数据操作层生成失败！\r\nERROR:" + Msg);
            pBar(74);
            PrintLine("正在生成业务逻辑层...");
            SampleThreeCore.CreateBll cbll = new SampleThreeCore.CreateBll();
            Msg = cbll.BuildBLL(WizardPage_CfgPath_TxtPath.Text, CurrentDBName);
            if (Msg == "OK")
                PrintLine("业务逻辑层生成成功！");
            else
                PrintLine("业务逻辑层生成失败！\r\nERROR:" + Msg);
            pBar(78);
            PrintLine("正在生成控制层...");
            SampleThreeCore.CreateControllers ccontroler = new SampleThreeCore.CreateControllers();
            Msg = ccontroler.BuildController(WizardPage_CfgPath_TxtPath.Text, CurrentDBName);
            if (Msg == "OK")
                PrintLine("控制层生成成功！");
            else
                PrintLine("控制层生成失败！\r\nERROR:" + Msg);
            pBar(85);
            PrintLine("正在生成UI文件...");
            CreateExtjs cextjs = new CreateExtjs();
            Msg = cextjs.BuildExtjs(WizardPage_CfgPath_TxtPath.Text, MenuCanClickList, CurrentDBName);
            if (Msg == "OK")
                PrintLine("UI文件生成成功！");
            else
                PrintLine("UI文件生成失败！\r\nERROR:" + Msg);
            pBar(95);
            PrintLine("正在为各层间建立关系...");
            SampleThreeCore.CreateRelation crelation = new SampleThreeCore.CreateRelation();
            Msg = crelation.BuildRelationShip(WizardPage_CfgPath_TxtPath.Text, CurrentDBName);
            if (Msg == "OK")
                PrintLine("层间关系建立成功！");
            else
                PrintLine("层间关系建立失败！\r\nERROR:" + Msg);
            pBar(99);
            PrintLine("恭喜您，WebMis生成成功,默认用户名：admin，密码：123456");
            pBar(100);
        }

        /// <summary>
        /// MVC架构自动生成线程
        /// </summary>
        private void AutoCreate()
        {
            string Msg = "";
            pBar(5);
            if (DatabaseType == "SQLServer2005")
            {
                PrintLine("正在创建数据库...");
                CreateDB createdb = new CreateDB();
                pBar(10);

                Msg = createdb.CreateDataBase(CurrentDBName);
                if (Msg == "OK")
                    PrintLine("数据库创建成功！");
                else
                {
                    PrintLine("很抱歉，数据库创建失败！WebMis无法继续生成，请您重试！\r\nERROR:" + Msg);
                    return;
                }
                pBar(20);
            }
            PrintLine("正在创建表...");
            CreateTables createtables = new CreateTables();
            Msg = createtables.AddTables(CurrentDBName);
            if (Msg == "OK")
                PrintLine("所有表创建成功！");
            else
            {
                PrintLine("很抱歉，部分表创建失败！WebMis无法继续生成，请您检查表结构是否正确，再重试！\r\nERROR:" + Msg);
                return;
            }
            pBar(35);
            PrintLine("正在创建基础数据...");
            AddBasicData data = new AddBasicData();
            Msg = data.InsertBasicData(MenuList, CurrentDBName);
            if (Msg == "OK")
                PrintLine("基础数据创建成功！");
            else
            {
                PrintLine("很抱歉，基础数据创建失败！WebMis无法继续生成，请您检查树结构是否正确，再重试！\r\nERROR:" + Msg);
                return;
            }
            pBar(50);
            PrintLine("正在准备框架，这个过程可能会花费很长时间，请您耐心等待...");
            Core.CreateFiles cf = new Core.CreateFiles();
            Msg = cf.BuildFrame(WizardPage_CfgPath_TxtPath.Text, DatabaseType);
            if (Msg == "OK")
                PrintLine("框架准备就绪...");
            else
            {
                PrintLine("框架部署失败，WebMis无法继续生成！\r\nERROR:" + Msg);
                return;
            }
            pBar(65);
            PrintLine("正在为数据库表生成映射文件...");
            Core.CreateModel cm = new Core.CreateModel();
            Msg = cm.TableModel(WizardPage_CfgPath_TxtPath.Text, CurrentDBName);
            if (Msg == "OK")
                PrintLine("映射文件生成成功！");
            else
                PrintLine("映射文件生成失败！\r\nERROR:" + Msg);
            pBar(68);
            PrintLine("正在生成数据操作层...");
            Core.CreateDao cdao = new Core.CreateDao();
            Msg = cdao.BuildDaoAndInterface(WizardPage_CfgPath_TxtPath.Text, CurrentDBName);
            if (Msg == "OK")
                PrintLine("数据操作层生成成功！");
            else
                PrintLine("数据操作层生成失败！\r\nERROR:" + Msg);
            pBar(74);
            PrintLine("正在生成业务逻辑层...");
            Core.CreateBLL cbll = new Core.CreateBLL();
            Msg = cbll.BuildBLL(WizardPage_CfgPath_TxtPath.Text, CurrentDBName);
            if (Msg == "OK")
                PrintLine("业务逻辑层生成成功！");
            else
                PrintLine("业务逻辑层生成失败！\r\nERROR:" + Msg);
            pBar(78);
            PrintLine("正在生成控制层...");
            Core.CreateController ccontroler = new Core.CreateController();
            Msg = ccontroler.BuildController(WizardPage_CfgPath_TxtPath.Text, CurrentDBName);
            if (Msg == "OK")
                PrintLine("控制层生成成功！");
            else
                PrintLine("控制层生成失败！\r\nERROR:" + Msg);
            pBar(85);
            PrintLine("正在生成UI文件...");
            CreateExtjs cextjs = new CreateExtjs();
            Msg = cextjs.BuildExtjs(WizardPage_CfgPath_TxtPath.Text, MenuCanClickList, CurrentDBName);
            if (Msg == "OK")
                PrintLine("UI文件生成成功！");
            else
                PrintLine("UI文件生成失败！\r\nERROR:" + Msg);
            pBar(95);
            PrintLine("正在为各层间建立关系...");
            Core.CreateRelation crelation = new Core.CreateRelation();
            Msg = crelation.BuildRelationShip(WizardPage_CfgPath_TxtPath.Text, CurrentDBName);
            if (Msg == "OK")
                PrintLine("层间关系建立成功！");
            else
                PrintLine("层间关系建立失败！\r\nERROR:" + Msg);
            pBar(99);
            PrintLine("恭喜您，WebMis生成成功,默认用户名：admin，密码：123456");
            pBar(100);
        }

        public void PrintLine(string msg)
        {
            if (this.InvokeRequired)//这里最关键
            {
                SetPrint setprint = new SetPrint(PrintLine);
                this.Invoke(setprint, new object[] { msg });
            }
            else
            {
                if (msg.Contains("ERROR"))
                    WizardPage_AutoCreate_TxtDetail.SelectionColor = Color.Red;
                else
                    WizardPage_AutoCreate_TxtDetail.SelectionColor = Color.Lime;
                WizardPage_AutoCreate_TxtDetail.AppendText("CJ> " + msg + "\r\n" + "\r\n");
                this.WizardPage_AutoCreate_TxtDetail.Focus();
                if (msg.Contains("WebMis无法继续生成") || msg.Contains("恭喜您"))
                {
                    MainWizard.BackEnabled = true;
                    MainWizard.NextEnabled = true;
                    MainWizard.CancelEnabled = true;
                }
                Application.DoEvents();
            }
        }
        //进度条显示
        private void pBar(int current)
        {
            if (this.InvokeRequired)//这里最关键
            {
                SetPBar setpos = new SetPBar(pBar);
                this.Invoke(setpos, new object[] { current });
            }
            else
            {
                WizardPage_AutoCreate_PBar.Value = current;
                if (current == 100)
                    MainWizard.NextEnabled = true;
            }
        }
        #endregion

        #region 导出数据字典
        private string ToDDicPath = "";
        private void WizardPage_Table_BtnToDDic_Click(object sender, EventArgs e)
        {
            if (WizardPage_Table_DGV.Rows.Count <= 0)
            {
                MessageBox.Show("很抱歉，该项目没有数据库表，无法生成数据字典！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            FolderBrowserDialog F = new FolderBrowserDialog();
            if (F.ShowDialog() == DialogResult.OK)
            {
                ToDDicPath = F.SelectedPath;
                Thread threadcore = new Thread(new ThreadStart(ToDataDictionary));//定义一个线程
                threadcore.Start();//启动一个线程
            }
        }
        private void ToDataDictionary()
        {
            DataTable AllTableDt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindAllTable, CurrentDBName));
            StringBuilder Details = new StringBuilder();
            StringBuilder tablelist = new StringBuilder();
            tablelist.AppendLine("项目数据库名称：<a name='top'>" + CurrentDBName + "</a>   共有数据库表：" + WizardPage_Table_DGV.Rows.Count.ToString() + "张<br /><br /><table width='800px' align='center'><tr><td>");
            for (int i = 0; i < WizardPage_Table_DGV.Rows.Count; i++)
            {
                tablelist.Append("<a href='#" + WizardPage_Table_DGV.Rows[i].Cells[1].Value.ToString() + "'>" + WizardPage_Table_DGV.Rows[i].Cells[1].Value.ToString() + "</a>&nbsp;&nbsp;&nbsp;&nbsp;");
                if ((i + 1) % 10 == 0)
                    tablelist.AppendLine("<br />");
                Details.AppendLine("<a name='" + WizardPage_Table_DGV.Rows[i].Cells[1].Value.ToString() + "'>表名：" + WizardPage_Table_DGV.Rows[i].Cells[1].Value.ToString() + "</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='#top'>Top</a><br><br><table width='800px' align='center'><tr><th>字段名称</th><th>数据类型</th><th>数据长度</th><th>字段描述</th><th>是否主键</th></tr>");
                string Tbody = "<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><tr>";
                DataRow[] TRows = AllTableDt.Select("表名='" + WizardPage_Table_DGV.Rows[i].Cells[1].Value.ToString() + "'");
                for (int j = 0; j < TRows.Count(); j++)
                {
                    Details.AppendLine(string.Format(Tbody, TRows[j]["字段名称"].ToString(), TRows[j]["数据类型"].ToString(), TRows[j]["数据长度"].ToString(), TRows[j]["字段描述"].ToString(), (TRows[j]["是否主键"].ToString().ToLower() == "true" ? "<font color='red'>True</font>" : "")));
                }
                Details.AppendLine("</table><br /><br />");
                ToDDicProsess(((i + 1) * 100 / WizardPage_Table_DGV.Rows.Count).ToString() + "%");
            }
            string Template = CJ.ReadFile(".\\WebBasic\\D.cj");
            Template = Template.Replace("<$$project$$>", CurrentDBName).Replace("<$$details$$>", tablelist.AppendLine("</td></tr></table><br /><br />" + Details.ToString()).ToString());
            CJ.WriteFile(ToDDicPath + "\\" + CurrentDBName + ".html", Template);
            ToDDicProsess("OK");
        }
        public void ToDDicProsess(string msg)
        {
            if (this.InvokeRequired)//这里最关键
            {
                SetPrint setprint = new SetPrint(ToDDicProsess);
                this.Invoke(setprint, new object[] { msg });
            }
            else
            {
                WizardPage_Table_BtnToDDic.Text = "正在导出" + msg + "...";
                if (msg == "OK")
                {
                    WizardPage_Table_BtnToDDic.Text = "导出数据字典";
                    MessageBox.Show("数据字典导出成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        #endregion

    }
}
