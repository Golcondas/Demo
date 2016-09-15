namespace WebMisDeveloper
{
    partial class Leader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Leader));
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("用户管理", 3, 3);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("角色管理", 3, 3);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("个人信息", 3, 3);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("修改密码", 3, 3);
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("退出系统", 3, 3);
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("系统管理", 1, 2, new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("新闻维护", 3, 3);
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("信息管理", 1, 2, new System.Windows.Forms.TreeNode[] {
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("主节点", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode17});
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.MainWizard = new Gui.Wizard.Wizard();
            this.WizardPage_FrameType = new Gui.Wizard.WizardPage();
            this.RBtnFrame_ExtNet = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.RBtnFrame_MVC = new System.Windows.Forms.RadioButton();
            this.RBtnFrame_SampleThree = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.header2 = new Gui.Wizard.Header();
            this.WizardPage_CfgPath = new Gui.Wizard.WizardPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.WizardPage_CfgPath_LbWarnning = new System.Windows.Forms.Label();
            this.WizardPage_CfgPath_BtnView = new System.Windows.Forms.Button();
            this.WizardPage_CfgPath_TxtPath = new System.Windows.Forms.TextBox();
            this.WizardPage_CfgPath_Header = new Gui.Wizard.Header();
            this.WizardPage_AutoCreate = new Gui.Wizard.WizardPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.WizardPage_AutoCreate_TxtDetail = new System.Windows.Forms.RichTextBox();
            this.WizardPage_AutoCreate_PBar = new System.Windows.Forms.ProgressBar();
            this.header1 = new Gui.Wizard.Header();
            this.WizardPage_CfgMenu = new Gui.Wizard.WizardPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.WizardPage_CfgMenu_BtnAdd = new System.Windows.Forms.Button();
            this.WizardPage_CfgMenu_TxtNodeID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.WizardPage_CfgMenu_BtnDel = new System.Windows.Forms.Button();
            this.WizardPage_CfgMenu_BtnSave = new System.Windows.Forms.Button();
            this.WizardPage_CfgMenu_CbTable = new System.Windows.Forms.ComboBox();
            this.WizardPage_CfgMenu_TxtNodeName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WizardPage_CfgMenu_BtnDown = new System.Windows.Forms.Button();
            this.WizardPage_CfgMenu_BtnUP = new System.Windows.Forms.Button();
            this.WizardPage_CfgMenu_Tree = new System.Windows.Forms.TreeView();
            this.WizardPage_CfgMenu_Header = new Gui.Wizard.Header();
            this.WizardPage_TableMgr = new Gui.Wizard.WizardPage();
            this.WizardPage_Table_CurrentDBName = new System.Windows.Forms.GroupBox();
            this.WizardPage_Table_BtnToDDic = new System.Windows.Forms.Button();
            this.WizardPage_Table_BtnChange = new System.Windows.Forms.Button();
            this.WizardPage_Table_BtnAdd = new System.Windows.Forms.Button();
            this.WizardPage_Table_BtnDel = new System.Windows.Forms.Button();
            this.WizardPage_Table_DGV = new System.Windows.Forms.DataGridView();
            this.WizardPage_TableMgr_Header = new Gui.Wizard.Header();
            this.WizardPage_CfgDB = new Gui.Wizard.WizardPage();
            this.WizardPage_CfgDB_RBtn_TempDBConn = new System.Windows.Forms.RadioButton();
            this.WizardPage_CfgDB_RBtn_NewDBConn = new System.Windows.Forms.RadioButton();
            this.WizardPage_CfgDB_GroupBoxNew = new System.Windows.Forms.GroupBox();
            this.WizardPage_CfgDB_NewDBName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.WizardPage_CfgDB_NewBtnTryConn = new System.Windows.Forms.Button();
            this.WizardPage_CfgDB_NewDBType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.WizardPage_CfgDB_NewDBConnString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WizardPage_CfgDB_GroupBoxTemplate = new System.Windows.Forms.GroupBox();
            this.WizardPage_CfgDB_TempTryConn = new System.Windows.Forms.Button();
            this.WizardPage_CfgDB_TempDelete = new System.Windows.Forms.Button();
            this.WizardPage_CfgDB_TempDBType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.WizardPage_CfgDB_TempDBConnStrig = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.WizardPage_CfgDB_TempAllDB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.WizardPage_CfgDB_Header = new Gui.Wizard.Header();
            this.wizardPage1 = new Gui.Wizard.WizardPage();
            this.FirstPageOfWizard = new Gui.Wizard.InfoContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.wizardPage2 = new Gui.Wizard.WizardPage();
            this.WizardPage_Success = new Gui.Wizard.InfoContainer();
            this.label11 = new System.Windows.Forms.Label();
            this.MainWizard.SuspendLayout();
            this.WizardPage_FrameType.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.WizardPage_CfgPath.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.WizardPage_AutoCreate.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.WizardPage_CfgMenu.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.WizardPage_TableMgr.SuspendLayout();
            this.WizardPage_Table_CurrentDBName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WizardPage_Table_DGV)).BeginInit();
            this.WizardPage_CfgDB.SuspendLayout();
            this.WizardPage_CfgDB_GroupBoxNew.SuspendLayout();
            this.WizardPage_CfgDB_GroupBoxTemplate.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            this.FirstPageOfWizard.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            this.WizardPage_Success.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "gif-0586.gif");
            this.imageList.Images.SetKeyName(1, "gif-0030.gif");
            this.imageList.Images.SetKeyName(2, "gif-0052.gif");
            this.imageList.Images.SetKeyName(3, "gif-0057.gif");
            // 
            // MainWizard
            // 
            this.MainWizard.Controls.Add(this.WizardPage_FrameType);
            this.MainWizard.Controls.Add(this.WizardPage_CfgMenu);
            this.MainWizard.Controls.Add(this.WizardPage_TableMgr);
            this.MainWizard.Controls.Add(this.WizardPage_CfgDB);
            this.MainWizard.Controls.Add(this.wizardPage1);
            this.MainWizard.Controls.Add(this.wizardPage2);
            this.MainWizard.Controls.Add(this.WizardPage_AutoCreate);
            this.MainWizard.Controls.Add(this.WizardPage_CfgPath);
            this.MainWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainWizard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainWizard.Location = new System.Drawing.Point(0, 0);
            this.MainWizard.Name = "MainWizard";
            this.MainWizard.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.wizardPage1,
            this.WizardPage_CfgDB,
            this.WizardPage_TableMgr,
            this.WizardPage_CfgMenu,
            this.WizardPage_FrameType,
            this.WizardPage_CfgPath,
            this.WizardPage_AutoCreate,
            this.wizardPage2});
            this.MainWizard.Size = new System.Drawing.Size(575, 384);
            this.MainWizard.TabIndex = 0;
            this.MainWizard.CloseFromCancel += new System.ComponentModel.CancelEventHandler(this.MainWizard_CloseFromCancel);
            // 
            // WizardPage_FrameType
            // 
            this.WizardPage_FrameType.Controls.Add(this.RBtnFrame_ExtNet);
            this.WizardPage_FrameType.Controls.Add(this.RBtnFrame_MVC);
            this.WizardPage_FrameType.Controls.Add(this.groupBox8);
            this.WizardPage_FrameType.Controls.Add(this.RBtnFrame_SampleThree);
            this.WizardPage_FrameType.Controls.Add(this.groupBox7);
            this.WizardPage_FrameType.Controls.Add(this.groupBox6);
            this.WizardPage_FrameType.Controls.Add(this.header2);
            this.WizardPage_FrameType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WizardPage_FrameType.ForeColor = System.Drawing.Color.Navy;
            this.WizardPage_FrameType.IsFinishPage = false;
            this.WizardPage_FrameType.Location = new System.Drawing.Point(0, 0);
            this.WizardPage_FrameType.Name = "WizardPage_FrameType";
            this.WizardPage_FrameType.Size = new System.Drawing.Size(575, 336);
            this.WizardPage_FrameType.TabIndex = 8;
            // 
            // RBtnFrame_ExtNet
            // 
            this.RBtnFrame_ExtNet.AutoSize = true;
            this.RBtnFrame_ExtNet.Checked = true;
            this.RBtnFrame_ExtNet.ForeColor = System.Drawing.Color.Red;
            this.RBtnFrame_ExtNet.Location = new System.Drawing.Point(103, 205);
            this.RBtnFrame_ExtNet.Name = "RBtnFrame_ExtNet";
            this.RBtnFrame_ExtNet.Size = new System.Drawing.Size(118, 17);
            this.RBtnFrame_ExtNet.TabIndex = 8;
            this.RBtnFrame_ExtNet.TabStop = true;
            this.RBtnFrame_ExtNet.Text = "三层架构(Ext.Net)";
            this.RBtnFrame_ExtNet.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Location = new System.Drawing.Point(63, 216);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(200, 100);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(6, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(188, 67);
            this.label14.TabIndex = 5;
            this.label14.Text = "框架中采用的技术：\r\n\r\nAsp.net、简单三层架构、Ext.Net\r\n\r\n可视化组件（基于Extjs3.2）";
            // 
            // RBtnFrame_MVC
            // 
            this.RBtnFrame_MVC.AutoSize = true;
            this.RBtnFrame_MVC.Location = new System.Drawing.Point(121, 83);
            this.RBtnFrame_MVC.Name = "RBtnFrame_MVC";
            this.RBtnFrame_MVC.Size = new System.Drawing.Size(70, 17);
            this.RBtnFrame_MVC.TabIndex = 2;
            this.RBtnFrame_MVC.Text = "MVC架构";
            this.RBtnFrame_MVC.UseVisualStyleBackColor = true;
            // 
            // RBtnFrame_SampleThree
            // 
            this.RBtnFrame_SampleThree.AutoSize = true;
            this.RBtnFrame_SampleThree.Location = new System.Drawing.Point(371, 82);
            this.RBtnFrame_SampleThree.Name = "RBtnFrame_SampleThree";
            this.RBtnFrame_SampleThree.Size = new System.Drawing.Size(73, 17);
            this.RBtnFrame_SampleThree.TabIndex = 3;
            this.RBtnFrame_SampleThree.Text = "三层架构";
            this.RBtnFrame_SampleThree.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Location = new System.Drawing.Point(307, 94);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 100);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(6, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(188, 52);
            this.label13.TabIndex = 5;
            this.label13.Text = "框架中采用的技术：\r\n\r\nAsp.net、简单三层架构、ExtJS";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Location = new System.Drawing.Point(63, 94);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 100);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(188, 70);
            this.label12.TabIndex = 4;
            this.label12.Text = "框架中采用的技术：\r\n\r\nAsp.net、Spring.net、Nhibernate、\r\n\r\nMVC、ExtJS";
            // 
            // header2
            // 
            this.header2.BackColor = System.Drawing.SystemColors.Control;
            this.header2.CausesValidation = false;
            this.header2.Description = "请您选择WebMis的架构";
            this.header2.Dock = System.Windows.Forms.DockStyle.Top;
            this.header2.Image = ((System.Drawing.Image)(resources.GetObject("header2.Image")));
            this.header2.Location = new System.Drawing.Point(0, 0);
            this.header2.Name = "header2";
            this.header2.Size = new System.Drawing.Size(575, 64);
            this.header2.TabIndex = 1;
            this.header2.Title = "起点10--WebMis生成向导  第四步";
            // 
            // WizardPage_CfgPath
            // 
            this.WizardPage_CfgPath.Controls.Add(this.groupBox4);
            this.WizardPage_CfgPath.Controls.Add(this.WizardPage_CfgPath_Header);
            this.WizardPage_CfgPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WizardPage_CfgPath.ForeColor = System.Drawing.Color.Navy;
            this.WizardPage_CfgPath.IsFinishPage = false;
            this.WizardPage_CfgPath.Location = new System.Drawing.Point(0, 0);
            this.WizardPage_CfgPath.Name = "WizardPage_CfgPath";
            this.WizardPage_CfgPath.Size = new System.Drawing.Size(575, 336);
            this.WizardPage_CfgPath.TabIndex = 5;
            this.WizardPage_CfgPath.CloseFromNext += new Gui.Wizard.PageEventHandler(this.WizardPage_CfgPath_CloseFromNext);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.WizardPage_CfgPath_LbWarnning);
            this.groupBox4.Controls.Add(this.WizardPage_CfgPath_BtnView);
            this.groupBox4.Controls.Add(this.WizardPage_CfgPath_TxtPath);
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(73, 99);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(428, 166);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "选择WebMis的生成位置";
            // 
            // WizardPage_CfgPath_LbWarnning
            // 
            this.WizardPage_CfgPath_LbWarnning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.WizardPage_CfgPath_LbWarnning.Location = new System.Drawing.Point(16, 119);
            this.WizardPage_CfgPath_LbWarnning.Name = "WizardPage_CfgPath_LbWarnning";
            this.WizardPage_CfgPath_LbWarnning.Size = new System.Drawing.Size(396, 32);
            this.WizardPage_CfgPath_LbWarnning.TabIndex = 2;
            // 
            // WizardPage_CfgPath_BtnView
            // 
            this.WizardPage_CfgPath_BtnView.Location = new System.Drawing.Point(354, 60);
            this.WizardPage_CfgPath_BtnView.Name = "WizardPage_CfgPath_BtnView";
            this.WizardPage_CfgPath_BtnView.Size = new System.Drawing.Size(56, 23);
            this.WizardPage_CfgPath_BtnView.TabIndex = 1;
            this.WizardPage_CfgPath_BtnView.Text = "浏览...";
            this.WizardPage_CfgPath_BtnView.UseVisualStyleBackColor = true;
            this.WizardPage_CfgPath_BtnView.Click += new System.EventHandler(this.WizardPage_CfgPath_BtnView_Click);
            // 
            // WizardPage_CfgPath_TxtPath
            // 
            this.WizardPage_CfgPath_TxtPath.Enabled = false;
            this.WizardPage_CfgPath_TxtPath.Location = new System.Drawing.Point(29, 61);
            this.WizardPage_CfgPath_TxtPath.Name = "WizardPage_CfgPath_TxtPath";
            this.WizardPage_CfgPath_TxtPath.ReadOnly = true;
            this.WizardPage_CfgPath_TxtPath.Size = new System.Drawing.Size(318, 21);
            this.WizardPage_CfgPath_TxtPath.TabIndex = 0;
            // 
            // WizardPage_CfgPath_Header
            // 
            this.WizardPage_CfgPath_Header.BackColor = System.Drawing.SystemColors.Control;
            this.WizardPage_CfgPath_Header.CausesValidation = false;
            this.WizardPage_CfgPath_Header.Description = "请您选择WebMis的生成位置";
            this.WizardPage_CfgPath_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.WizardPage_CfgPath_Header.Image = ((System.Drawing.Image)(resources.GetObject("WizardPage_CfgPath_Header.Image")));
            this.WizardPage_CfgPath_Header.Location = new System.Drawing.Point(0, 0);
            this.WizardPage_CfgPath_Header.Name = "WizardPage_CfgPath_Header";
            this.WizardPage_CfgPath_Header.Size = new System.Drawing.Size(575, 64);
            this.WizardPage_CfgPath_Header.TabIndex = 0;
            this.WizardPage_CfgPath_Header.Title = "起点10--WebMis生成向导  第五步";
            // 
            // WizardPage_AutoCreate
            // 
            this.WizardPage_AutoCreate.Controls.Add(this.groupBox5);
            this.WizardPage_AutoCreate.Controls.Add(this.WizardPage_AutoCreate_PBar);
            this.WizardPage_AutoCreate.Controls.Add(this.header1);
            this.WizardPage_AutoCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WizardPage_AutoCreate.ForeColor = System.Drawing.Color.Navy;
            this.WizardPage_AutoCreate.IsFinishPage = false;
            this.WizardPage_AutoCreate.Location = new System.Drawing.Point(0, 0);
            this.WizardPage_AutoCreate.Name = "WizardPage_AutoCreate";
            this.WizardPage_AutoCreate.Size = new System.Drawing.Size(575, 336);
            this.WizardPage_AutoCreate.TabIndex = 6;
            this.WizardPage_AutoCreate.ShowFromNext += new System.EventHandler(this.WizardPage_AutoCreate_ShowFromNext);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.WizardPage_AutoCreate_TxtDetail);
            this.groupBox5.ForeColor = System.Drawing.Color.Navy;
            this.groupBox5.Location = new System.Drawing.Point(52, 137);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(470, 170);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "生成明细";
            // 
            // WizardPage_AutoCreate_TxtDetail
            // 
            this.WizardPage_AutoCreate_TxtDetail.BackColor = System.Drawing.Color.Black;
            this.WizardPage_AutoCreate_TxtDetail.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WizardPage_AutoCreate_TxtDetail.ForeColor = System.Drawing.Color.Lime;
            this.WizardPage_AutoCreate_TxtDetail.Location = new System.Drawing.Point(7, 20);
            this.WizardPage_AutoCreate_TxtDetail.Name = "WizardPage_AutoCreate_TxtDetail";
            this.WizardPage_AutoCreate_TxtDetail.Size = new System.Drawing.Size(457, 144);
            this.WizardPage_AutoCreate_TxtDetail.TabIndex = 0;
            this.WizardPage_AutoCreate_TxtDetail.Text = "CJ> 很酷的显示";
            // 
            // WizardPage_AutoCreate_PBar
            // 
            this.WizardPage_AutoCreate_PBar.Location = new System.Drawing.Point(52, 86);
            this.WizardPage_AutoCreate_PBar.Name = "WizardPage_AutoCreate_PBar";
            this.WizardPage_AutoCreate_PBar.Size = new System.Drawing.Size(470, 33);
            this.WizardPage_AutoCreate_PBar.TabIndex = 1;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.SystemColors.Control;
            this.header1.CausesValidation = false;
            this.header1.Description = "系统正在根据您的配置生成WebMis，请您稍后......";
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Image = ((System.Drawing.Image)(resources.GetObject("header1.Image")));
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(575, 64);
            this.header1.TabIndex = 0;
            this.header1.Title = "起点10--WebMis生成向导  第六步";
            // 
            // WizardPage_CfgMenu
            // 
            this.WizardPage_CfgMenu.Controls.Add(this.groupBox3);
            this.WizardPage_CfgMenu.Controls.Add(this.groupBox2);
            this.WizardPage_CfgMenu.Controls.Add(this.groupBox1);
            this.WizardPage_CfgMenu.Controls.Add(this.WizardPage_CfgMenu_Header);
            this.WizardPage_CfgMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WizardPage_CfgMenu.ForeColor = System.Drawing.Color.Navy;
            this.WizardPage_CfgMenu.IsFinishPage = false;
            this.WizardPage_CfgMenu.Location = new System.Drawing.Point(0, 0);
            this.WizardPage_CfgMenu.Name = "WizardPage_CfgMenu";
            this.WizardPage_CfgMenu.Size = new System.Drawing.Size(575, 336);
            this.WizardPage_CfgMenu.TabIndex = 4;
            this.WizardPage_CfgMenu.CloseFromNext += new Gui.Wizard.PageEventHandler(this.WizardPage_CfgMenu_CloseFromNext);
            this.WizardPage_CfgMenu.ShowFromNext += new System.EventHandler(this.WizardPage_CfgMenu_ShowFromNext);
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(269, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(294, 135);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "效果图";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(288, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.WizardPage_CfgMenu_BtnAdd);
            this.groupBox2.Controls.Add(this.WizardPage_CfgMenu_TxtNodeID);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.WizardPage_CfgMenu_BtnDel);
            this.groupBox2.Controls.Add(this.WizardPage_CfgMenu_BtnSave);
            this.groupBox2.Controls.Add(this.WizardPage_CfgMenu_CbTable);
            this.groupBox2.Controls.Add(this.WizardPage_CfgMenu_TxtNodeName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(268, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 109);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "添加/修改节点";
            // 
            // WizardPage_CfgMenu_BtnAdd
            // 
            this.WizardPage_CfgMenu_BtnAdd.Location = new System.Drawing.Point(232, 18);
            this.WizardPage_CfgMenu_BtnAdd.Name = "WizardPage_CfgMenu_BtnAdd";
            this.WizardPage_CfgMenu_BtnAdd.Size = new System.Drawing.Size(43, 23);
            this.WizardPage_CfgMenu_BtnAdd.TabIndex = 9;
            this.WizardPage_CfgMenu_BtnAdd.Text = "添加";
            this.WizardPage_CfgMenu_BtnAdd.UseVisualStyleBackColor = true;
            this.WizardPage_CfgMenu_BtnAdd.Click += new System.EventHandler(this.WizardPage_CfgMenu_BtnAdd_Click);
            // 
            // WizardPage_CfgMenu_TxtNodeID
            // 
            this.WizardPage_CfgMenu_TxtNodeID.Location = new System.Drawing.Point(71, 18);
            this.WizardPage_CfgMenu_TxtNodeID.Name = "WizardPage_CfgMenu_TxtNodeID";
            this.WizardPage_CfgMenu_TxtNodeID.Size = new System.Drawing.Size(148, 21);
            this.WizardPage_CfgMenu_TxtNodeID.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "节点ID：";
            // 
            // WizardPage_CfgMenu_BtnDel
            // 
            this.WizardPage_CfgMenu_BtnDel.Location = new System.Drawing.Point(232, 75);
            this.WizardPage_CfgMenu_BtnDel.Name = "WizardPage_CfgMenu_BtnDel";
            this.WizardPage_CfgMenu_BtnDel.Size = new System.Drawing.Size(43, 23);
            this.WizardPage_CfgMenu_BtnDel.TabIndex = 5;
            this.WizardPage_CfgMenu_BtnDel.Text = "删除";
            this.WizardPage_CfgMenu_BtnDel.UseVisualStyleBackColor = true;
            this.WizardPage_CfgMenu_BtnDel.Click += new System.EventHandler(this.WizardPage_CfgMenu_BtnDel_Click);
            // 
            // WizardPage_CfgMenu_BtnSave
            // 
            this.WizardPage_CfgMenu_BtnSave.Location = new System.Drawing.Point(232, 46);
            this.WizardPage_CfgMenu_BtnSave.Name = "WizardPage_CfgMenu_BtnSave";
            this.WizardPage_CfgMenu_BtnSave.Size = new System.Drawing.Size(43, 23);
            this.WizardPage_CfgMenu_BtnSave.TabIndex = 4;
            this.WizardPage_CfgMenu_BtnSave.Text = "保存";
            this.WizardPage_CfgMenu_BtnSave.UseVisualStyleBackColor = true;
            this.WizardPage_CfgMenu_BtnSave.Click += new System.EventHandler(this.WizardPage_CfgMenu_BtnSave_Click);
            // 
            // WizardPage_CfgMenu_CbTable
            // 
            this.WizardPage_CfgMenu_CbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WizardPage_CfgMenu_CbTable.FormattingEnabled = true;
            this.WizardPage_CfgMenu_CbTable.Location = new System.Drawing.Point(71, 77);
            this.WizardPage_CfgMenu_CbTable.Name = "WizardPage_CfgMenu_CbTable";
            this.WizardPage_CfgMenu_CbTable.Size = new System.Drawing.Size(148, 21);
            this.WizardPage_CfgMenu_CbTable.TabIndex = 3;
            this.WizardPage_CfgMenu_CbTable.SelectedIndexChanged += new System.EventHandler(this.WizardPage_CfgMenu_CbTable_SelectedIndexChanged);
            // 
            // WizardPage_CfgMenu_TxtNodeName
            // 
            this.WizardPage_CfgMenu_TxtNodeName.Location = new System.Drawing.Point(71, 48);
            this.WizardPage_CfgMenu_TxtNodeName.Name = "WizardPage_CfgMenu_TxtNodeName";
            this.WizardPage_CfgMenu_TxtNodeName.Size = new System.Drawing.Size(148, 21);
            this.WizardPage_CfgMenu_TxtNodeName.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "对应表：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "节点名称：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WizardPage_CfgMenu_BtnDown);
            this.groupBox1.Controls.Add(this.WizardPage_CfgMenu_BtnUP);
            this.groupBox1.Controls.Add(this.WizardPage_CfgMenu_Tree);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 251);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "WebMis功能菜单树";
            // 
            // WizardPage_CfgMenu_BtnDown
            // 
            this.WizardPage_CfgMenu_BtnDown.Location = new System.Drawing.Point(224, 51);
            this.WizardPage_CfgMenu_BtnDown.Name = "WizardPage_CfgMenu_BtnDown";
            this.WizardPage_CfgMenu_BtnDown.Size = new System.Drawing.Size(20, 23);
            this.WizardPage_CfgMenu_BtnDown.TabIndex = 2;
            this.WizardPage_CfgMenu_BtnDown.Text = "∨";
            this.WizardPage_CfgMenu_BtnDown.UseVisualStyleBackColor = true;
            this.WizardPage_CfgMenu_BtnDown.Click += new System.EventHandler(this.WizardPage_CfgMenu_BtnDown_Click);
            // 
            // WizardPage_CfgMenu_BtnUP
            // 
            this.WizardPage_CfgMenu_BtnUP.Location = new System.Drawing.Point(224, 21);
            this.WizardPage_CfgMenu_BtnUP.Name = "WizardPage_CfgMenu_BtnUP";
            this.WizardPage_CfgMenu_BtnUP.Size = new System.Drawing.Size(20, 23);
            this.WizardPage_CfgMenu_BtnUP.TabIndex = 1;
            this.WizardPage_CfgMenu_BtnUP.Text = "∧";
            this.WizardPage_CfgMenu_BtnUP.UseVisualStyleBackColor = true;
            this.WizardPage_CfgMenu_BtnUP.Click += new System.EventHandler(this.WizardPage_CfgMenu_BtnUP_Click);
            // 
            // WizardPage_CfgMenu_Tree
            // 
            this.WizardPage_CfgMenu_Tree.AllowDrop = true;
            this.WizardPage_CfgMenu_Tree.ForeColor = System.Drawing.Color.Navy;
            this.WizardPage_CfgMenu_Tree.ImageIndex = 0;
            this.WizardPage_CfgMenu_Tree.ImageList = this.imageList;
            this.WizardPage_CfgMenu_Tree.Location = new System.Drawing.Point(6, 21);
            this.WizardPage_CfgMenu_Tree.Name = "WizardPage_CfgMenu_Tree";
            treeNode10.ImageIndex = 3;
            treeNode10.Name = "userMgr";
            treeNode10.SelectedImageIndex = 3;
            treeNode10.Tag = "无";
            treeNode10.Text = "用户管理";
            treeNode10.ToolTipText = "管理网站用户";
            treeNode11.ImageIndex = 3;
            treeNode11.Name = "roleMgr";
            treeNode11.SelectedImageIndex = 3;
            treeNode11.Tag = "无";
            treeNode11.Text = "角色管理";
            treeNode11.ToolTipText = "管理网站角色，分配权限";
            treeNode12.ImageIndex = 3;
            treeNode12.Name = "userInfo";
            treeNode12.SelectedImageIndex = 3;
            treeNode12.Tag = "无";
            treeNode12.Text = "个人信息";
            treeNode12.ToolTipText = "修改当前用户信息";
            treeNode13.ImageIndex = 3;
            treeNode13.Name = "pwdMgr";
            treeNode13.SelectedImageIndex = 3;
            treeNode13.Tag = "无";
            treeNode13.Text = "修改密码";
            treeNode13.ToolTipText = "修改当前用户密码";
            treeNode14.ImageIndex = 3;
            treeNode14.Name = "sysExit";
            treeNode14.SelectedImageIndex = 3;
            treeNode14.Tag = "无";
            treeNode14.Text = "退出系统";
            treeNode14.ToolTipText = "登出网站";
            treeNode15.ImageIndex = 1;
            treeNode15.Name = "sysMgr";
            treeNode15.SelectedImageIndex = 2;
            treeNode15.Tag = "无";
            treeNode15.Text = "系统管理";
            treeNode15.ToolTipText = "请不要删除";
            treeNode16.ImageIndex = 3;
            treeNode16.Name = "publishNews";
            treeNode16.SelectedImageIndex = 3;
            treeNode16.Tag = "无";
            treeNode16.Text = "新闻维护";
            treeNode16.ToolTipText = "管理消息";
            treeNode17.ImageIndex = 1;
            treeNode17.Name = "newsMgr";
            treeNode17.SelectedImageIndex = 2;
            treeNode17.Tag = "无";
            treeNode17.Text = "信息管理";
            treeNode17.ToolTipText = "发布,管理信息";
            treeNode18.Name = "TreeRoot";
            treeNode18.Tag = "无";
            treeNode18.Text = "主节点";
            treeNode18.ToolTipText = "该节点不显示在网站功能树中";
            this.WizardPage_CfgMenu_Tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode18});
            this.WizardPage_CfgMenu_Tree.SelectedImageIndex = 0;
            this.WizardPage_CfgMenu_Tree.ShowNodeToolTips = true;
            this.WizardPage_CfgMenu_Tree.Size = new System.Drawing.Size(213, 224);
            this.WizardPage_CfgMenu_Tree.TabIndex = 0;
            this.WizardPage_CfgMenu_Tree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.WizardPage_CfgMenu_Tree_ItemDrag);
            this.WizardPage_CfgMenu_Tree.DragDrop += new System.Windows.Forms.DragEventHandler(this.WizardPage_CfgMenu_Tree_DragDrop);
            this.WizardPage_CfgMenu_Tree.DragEnter += new System.Windows.Forms.DragEventHandler(this.WizardPage_CfgMenu_Tree_DragEnter);
            this.WizardPage_CfgMenu_Tree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WizardPage_CfgMenu_Tree_MouseDown);
            // 
            // WizardPage_CfgMenu_Header
            // 
            this.WizardPage_CfgMenu_Header.BackColor = System.Drawing.SystemColors.Control;
            this.WizardPage_CfgMenu_Header.CausesValidation = false;
            this.WizardPage_CfgMenu_Header.Description = "请为您的系统配置功能树，这些功能将显示在您的网站上，部分基础功能已经为您产生，请不要修改或删除";
            this.WizardPage_CfgMenu_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.WizardPage_CfgMenu_Header.Image = ((System.Drawing.Image)(resources.GetObject("WizardPage_CfgMenu_Header.Image")));
            this.WizardPage_CfgMenu_Header.Location = new System.Drawing.Point(0, 0);
            this.WizardPage_CfgMenu_Header.Name = "WizardPage_CfgMenu_Header";
            this.WizardPage_CfgMenu_Header.Size = new System.Drawing.Size(575, 64);
            this.WizardPage_CfgMenu_Header.TabIndex = 0;
            this.WizardPage_CfgMenu_Header.Title = "起点10--WebMis生成向导  第三步";
            // 
            // WizardPage_TableMgr
            // 
            this.WizardPage_TableMgr.Controls.Add(this.WizardPage_Table_CurrentDBName);
            this.WizardPage_TableMgr.Controls.Add(this.WizardPage_TableMgr_Header);
            this.WizardPage_TableMgr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WizardPage_TableMgr.ForeColor = System.Drawing.Color.Navy;
            this.WizardPage_TableMgr.IsFinishPage = false;
            this.WizardPage_TableMgr.Location = new System.Drawing.Point(0, 0);
            this.WizardPage_TableMgr.Name = "WizardPage_TableMgr";
            this.WizardPage_TableMgr.Size = new System.Drawing.Size(575, 336);
            this.WizardPage_TableMgr.TabIndex = 3;
            // 
            // WizardPage_Table_CurrentDBName
            // 
            this.WizardPage_Table_CurrentDBName.Controls.Add(this.WizardPage_Table_BtnToDDic);
            this.WizardPage_Table_CurrentDBName.Controls.Add(this.WizardPage_Table_BtnChange);
            this.WizardPage_Table_CurrentDBName.Controls.Add(this.WizardPage_Table_BtnAdd);
            this.WizardPage_Table_CurrentDBName.Controls.Add(this.WizardPage_Table_BtnDel);
            this.WizardPage_Table_CurrentDBName.Controls.Add(this.WizardPage_Table_DGV);
            this.WizardPage_Table_CurrentDBName.ForeColor = System.Drawing.Color.Navy;
            this.WizardPage_Table_CurrentDBName.Location = new System.Drawing.Point(12, 70);
            this.WizardPage_Table_CurrentDBName.Name = "WizardPage_Table_CurrentDBName";
            this.WizardPage_Table_CurrentDBName.Size = new System.Drawing.Size(551, 251);
            this.WizardPage_Table_CurrentDBName.TabIndex = 1;
            this.WizardPage_Table_CurrentDBName.TabStop = false;
            this.WizardPage_Table_CurrentDBName.Text = "当前数据库已存在的表";
            // 
            // WizardPage_Table_BtnToDDic
            // 
            this.WizardPage_Table_BtnToDDic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WizardPage_Table_BtnToDDic.Location = new System.Drawing.Point(315, 12);
            this.WizardPage_Table_BtnToDDic.Name = "WizardPage_Table_BtnToDDic";
            this.WizardPage_Table_BtnToDDic.Size = new System.Drawing.Size(95, 35);
            this.WizardPage_Table_BtnToDDic.TabIndex = 4;
            this.WizardPage_Table_BtnToDDic.Text = "导出数据字典";
            this.WizardPage_Table_BtnToDDic.UseVisualStyleBackColor = true;
            this.WizardPage_Table_BtnToDDic.Click += new System.EventHandler(this.WizardPage_Table_BtnToDDic_Click);
            // 
            // WizardPage_Table_BtnChange
            // 
            this.WizardPage_Table_BtnChange.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("WizardPage_Table_BtnChange.BackgroundImage")));
            this.WizardPage_Table_BtnChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WizardPage_Table_BtnChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WizardPage_Table_BtnChange.Location = new System.Drawing.Point(461, 12);
            this.WizardPage_Table_BtnChange.Name = "WizardPage_Table_BtnChange";
            this.WizardPage_Table_BtnChange.Size = new System.Drawing.Size(39, 35);
            this.WizardPage_Table_BtnChange.TabIndex = 3;
            this.WizardPage_Table_BtnChange.Text = "修改";
            this.WizardPage_Table_BtnChange.UseVisualStyleBackColor = true;
            this.WizardPage_Table_BtnChange.Click += new System.EventHandler(this.WizardPage_Table_BtnChange_Click);
            // 
            // WizardPage_Table_BtnAdd
            // 
            this.WizardPage_Table_BtnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("WizardPage_Table_BtnAdd.BackgroundImage")));
            this.WizardPage_Table_BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WizardPage_Table_BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WizardPage_Table_BtnAdd.Location = new System.Drawing.Point(416, 12);
            this.WizardPage_Table_BtnAdd.Name = "WizardPage_Table_BtnAdd";
            this.WizardPage_Table_BtnAdd.Size = new System.Drawing.Size(39, 35);
            this.WizardPage_Table_BtnAdd.TabIndex = 2;
            this.WizardPage_Table_BtnAdd.Text = "添加";
            this.WizardPage_Table_BtnAdd.UseVisualStyleBackColor = true;
            this.WizardPage_Table_BtnAdd.Click += new System.EventHandler(this.WizardPage_Table_BtnAdd_Click);
            // 
            // WizardPage_Table_BtnDel
            // 
            this.WizardPage_Table_BtnDel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("WizardPage_Table_BtnDel.BackgroundImage")));
            this.WizardPage_Table_BtnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WizardPage_Table_BtnDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WizardPage_Table_BtnDel.Location = new System.Drawing.Point(506, 12);
            this.WizardPage_Table_BtnDel.Name = "WizardPage_Table_BtnDel";
            this.WizardPage_Table_BtnDel.Size = new System.Drawing.Size(39, 35);
            this.WizardPage_Table_BtnDel.TabIndex = 1;
            this.WizardPage_Table_BtnDel.Text = "删除";
            this.WizardPage_Table_BtnDel.UseVisualStyleBackColor = true;
            this.WizardPage_Table_BtnDel.Click += new System.EventHandler(this.WizardPage_Table_BtnDel_Click);
            // 
            // WizardPage_Table_DGV
            // 
            this.WizardPage_Table_DGV.AllowUserToAddRows = false;
            this.WizardPage_Table_DGV.AllowUserToDeleteRows = false;
            this.WizardPage_Table_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WizardPage_Table_DGV.Location = new System.Drawing.Point(6, 53);
            this.WizardPage_Table_DGV.MultiSelect = false;
            this.WizardPage_Table_DGV.Name = "WizardPage_Table_DGV";
            this.WizardPage_Table_DGV.ReadOnly = true;
            this.WizardPage_Table_DGV.RowTemplate.Height = 23;
            this.WizardPage_Table_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WizardPage_Table_DGV.Size = new System.Drawing.Size(539, 192);
            this.WizardPage_Table_DGV.TabIndex = 0;
            this.WizardPage_Table_DGV.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.WizardPage_Table_DGV_CellMouseDoubleClick);
            this.WizardPage_Table_DGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.WizardPage_Table_DGV_DataBindingComplete);
            // 
            // WizardPage_TableMgr_Header
            // 
            this.WizardPage_TableMgr_Header.BackColor = System.Drawing.SystemColors.Control;
            this.WizardPage_TableMgr_Header.CausesValidation = false;
            this.WizardPage_TableMgr_Header.Description = "请为您的系统配置数据库表";
            this.WizardPage_TableMgr_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.WizardPage_TableMgr_Header.Image = ((System.Drawing.Image)(resources.GetObject("WizardPage_TableMgr_Header.Image")));
            this.WizardPage_TableMgr_Header.Location = new System.Drawing.Point(0, 0);
            this.WizardPage_TableMgr_Header.Name = "WizardPage_TableMgr_Header";
            this.WizardPage_TableMgr_Header.Size = new System.Drawing.Size(575, 64);
            this.WizardPage_TableMgr_Header.TabIndex = 0;
            this.WizardPage_TableMgr_Header.Title = "起点10--WebMis生成向导  第二步";
            // 
            // WizardPage_CfgDB
            // 
            this.WizardPage_CfgDB.Controls.Add(this.WizardPage_CfgDB_RBtn_TempDBConn);
            this.WizardPage_CfgDB.Controls.Add(this.WizardPage_CfgDB_RBtn_NewDBConn);
            this.WizardPage_CfgDB.Controls.Add(this.WizardPage_CfgDB_GroupBoxNew);
            this.WizardPage_CfgDB.Controls.Add(this.WizardPage_CfgDB_GroupBoxTemplate);
            this.WizardPage_CfgDB.Controls.Add(this.WizardPage_CfgDB_Header);
            this.WizardPage_CfgDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WizardPage_CfgDB.ForeColor = System.Drawing.Color.Navy;
            this.WizardPage_CfgDB.IsFinishPage = false;
            this.WizardPage_CfgDB.Location = new System.Drawing.Point(0, 0);
            this.WizardPage_CfgDB.Name = "WizardPage_CfgDB";
            this.WizardPage_CfgDB.Size = new System.Drawing.Size(575, 336);
            this.WizardPage_CfgDB.TabIndex = 2;
            this.WizardPage_CfgDB.CloseFromNext += new Gui.Wizard.PageEventHandler(this.WizardPage_CfgDB_CloseFromNext);
            // 
            // WizardPage_CfgDB_RBtn_TempDBConn
            // 
            this.WizardPage_CfgDB_RBtn_TempDBConn.AutoSize = true;
            this.WizardPage_CfgDB_RBtn_TempDBConn.Location = new System.Drawing.Point(307, 66);
            this.WizardPage_CfgDB_RBtn_TempDBConn.Name = "WizardPage_CfgDB_RBtn_TempDBConn";
            this.WizardPage_CfgDB_RBtn_TempDBConn.Size = new System.Drawing.Size(133, 17);
            this.WizardPage_CfgDB_RBtn_TempDBConn.TabIndex = 2;
            this.WizardPage_CfgDB_RBtn_TempDBConn.Text = "加载已有数据库模板";
            this.WizardPage_CfgDB_RBtn_TempDBConn.UseVisualStyleBackColor = true;
            this.WizardPage_CfgDB_RBtn_TempDBConn.CheckedChanged += new System.EventHandler(this.WizardPage_CfgDB_RBtn_OldDBConn_CheckedChanged);
            // 
            // WizardPage_CfgDB_RBtn_NewDBConn
            // 
            this.WizardPage_CfgDB_RBtn_NewDBConn.AutoSize = true;
            this.WizardPage_CfgDB_RBtn_NewDBConn.Checked = true;
            this.WizardPage_CfgDB_RBtn_NewDBConn.Location = new System.Drawing.Point(27, 66);
            this.WizardPage_CfgDB_RBtn_NewDBConn.Name = "WizardPage_CfgDB_RBtn_NewDBConn";
            this.WizardPage_CfgDB_RBtn_NewDBConn.Size = new System.Drawing.Size(85, 17);
            this.WizardPage_CfgDB_RBtn_NewDBConn.TabIndex = 1;
            this.WizardPage_CfgDB_RBtn_NewDBConn.TabStop = true;
            this.WizardPage_CfgDB_RBtn_NewDBConn.Text = "新建数据库";
            this.WizardPage_CfgDB_RBtn_NewDBConn.UseVisualStyleBackColor = true;
            this.WizardPage_CfgDB_RBtn_NewDBConn.CheckedChanged += new System.EventHandler(this.WizardPage_CfgDB_RBtn_NewDBConn_CheckedChanged);
            // 
            // WizardPage_CfgDB_GroupBoxNew
            // 
            this.WizardPage_CfgDB_GroupBoxNew.Controls.Add(this.WizardPage_CfgDB_NewDBName);
            this.WizardPage_CfgDB_GroupBoxNew.Controls.Add(this.label4);
            this.WizardPage_CfgDB_GroupBoxNew.Controls.Add(this.WizardPage_CfgDB_NewBtnTryConn);
            this.WizardPage_CfgDB_GroupBoxNew.Controls.Add(this.WizardPage_CfgDB_NewDBType);
            this.WizardPage_CfgDB_GroupBoxNew.Controls.Add(this.label3);
            this.WizardPage_CfgDB_GroupBoxNew.Controls.Add(this.WizardPage_CfgDB_NewDBConnString);
            this.WizardPage_CfgDB_GroupBoxNew.Controls.Add(this.label2);
            this.WizardPage_CfgDB_GroupBoxNew.Location = new System.Drawing.Point(12, 77);
            this.WizardPage_CfgDB_GroupBoxNew.Name = "WizardPage_CfgDB_GroupBoxNew";
            this.WizardPage_CfgDB_GroupBoxNew.Size = new System.Drawing.Size(270, 244);
            this.WizardPage_CfgDB_GroupBoxNew.TabIndex = 6;
            this.WizardPage_CfgDB_GroupBoxNew.TabStop = false;
            // 
            // WizardPage_CfgDB_NewDBName
            // 
            this.WizardPage_CfgDB_NewDBName.Location = new System.Drawing.Point(70, 171);
            this.WizardPage_CfgDB_NewDBName.Name = "WizardPage_CfgDB_NewDBName";
            this.WizardPage_CfgDB_NewDBName.Size = new System.Drawing.Size(186, 21);
            this.WizardPage_CfgDB_NewDBName.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "库名称：";
            // 
            // WizardPage_CfgDB_NewBtnTryConn
            // 
            this.WizardPage_CfgDB_NewBtnTryConn.Location = new System.Drawing.Point(181, 207);
            this.WizardPage_CfgDB_NewBtnTryConn.Name = "WizardPage_CfgDB_NewBtnTryConn";
            this.WizardPage_CfgDB_NewBtnTryConn.Size = new System.Drawing.Size(75, 23);
            this.WizardPage_CfgDB_NewBtnTryConn.TabIndex = 7;
            this.WizardPage_CfgDB_NewBtnTryConn.Text = "测试连接";
            this.WizardPage_CfgDB_NewBtnTryConn.UseVisualStyleBackColor = true;
            this.WizardPage_CfgDB_NewBtnTryConn.Click += new System.EventHandler(this.WizardPage_CfgDB_NewBtnTryConn_Click);
            // 
            // WizardPage_CfgDB_NewDBType
            // 
            this.WizardPage_CfgDB_NewDBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WizardPage_CfgDB_NewDBType.FormattingEnabled = true;
            this.WizardPage_CfgDB_NewDBType.Items.AddRange(new object[] {
            "SQLServer2005",
            "Oracle"});
            this.WizardPage_CfgDB_NewDBType.Location = new System.Drawing.Point(71, 40);
            this.WizardPage_CfgDB_NewDBType.Name = "WizardPage_CfgDB_NewDBType";
            this.WizardPage_CfgDB_NewDBType.Size = new System.Drawing.Size(185, 21);
            this.WizardPage_CfgDB_NewDBType.TabIndex = 6;
            this.WizardPage_CfgDB_NewDBType.SelectedIndexChanged += new System.EventHandler(this.WizardPage_CfgDB_NewDBType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "库驱动：";
            // 
            // WizardPage_CfgDB_NewDBConnString
            // 
            this.WizardPage_CfgDB_NewDBConnString.Location = new System.Drawing.Point(70, 77);
            this.WizardPage_CfgDB_NewDBConnString.Multiline = true;
            this.WizardPage_CfgDB_NewDBConnString.Name = "WizardPage_CfgDB_NewDBConnString";
            this.WizardPage_CfgDB_NewDBConnString.Size = new System.Drawing.Size(186, 78);
            this.WizardPage_CfgDB_NewDBConnString.TabIndex = 3;
            this.WizardPage_CfgDB_NewDBConnString.Text = "Data Source=localhost;Persist Security Info=True;User ID=sa;Password=ovenjackchai" +
                "n;";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "连接串：";
            // 
            // WizardPage_CfgDB_GroupBoxTemplate
            // 
            this.WizardPage_CfgDB_GroupBoxTemplate.Controls.Add(this.WizardPage_CfgDB_TempTryConn);
            this.WizardPage_CfgDB_GroupBoxTemplate.Controls.Add(this.WizardPage_CfgDB_TempDelete);
            this.WizardPage_CfgDB_GroupBoxTemplate.Controls.Add(this.WizardPage_CfgDB_TempDBType);
            this.WizardPage_CfgDB_GroupBoxTemplate.Controls.Add(this.label6);
            this.WizardPage_CfgDB_GroupBoxTemplate.Controls.Add(this.WizardPage_CfgDB_TempDBConnStrig);
            this.WizardPage_CfgDB_GroupBoxTemplate.Controls.Add(this.label7);
            this.WizardPage_CfgDB_GroupBoxTemplate.Controls.Add(this.WizardPage_CfgDB_TempAllDB);
            this.WizardPage_CfgDB_GroupBoxTemplate.Controls.Add(this.label5);
            this.WizardPage_CfgDB_GroupBoxTemplate.Enabled = false;
            this.WizardPage_CfgDB_GroupBoxTemplate.Location = new System.Drawing.Point(292, 77);
            this.WizardPage_CfgDB_GroupBoxTemplate.Name = "WizardPage_CfgDB_GroupBoxTemplate";
            this.WizardPage_CfgDB_GroupBoxTemplate.Size = new System.Drawing.Size(270, 244);
            this.WizardPage_CfgDB_GroupBoxTemplate.TabIndex = 5;
            this.WizardPage_CfgDB_GroupBoxTemplate.TabStop = false;
            // 
            // WizardPage_CfgDB_TempTryConn
            // 
            this.WizardPage_CfgDB_TempTryConn.Location = new System.Drawing.Point(70, 207);
            this.WizardPage_CfgDB_TempTryConn.Name = "WizardPage_CfgDB_TempTryConn";
            this.WizardPage_CfgDB_TempTryConn.Size = new System.Drawing.Size(75, 23);
            this.WizardPage_CfgDB_TempTryConn.TabIndex = 15;
            this.WizardPage_CfgDB_TempTryConn.Text = "测试连接";
            this.WizardPage_CfgDB_TempTryConn.UseVisualStyleBackColor = true;
            this.WizardPage_CfgDB_TempTryConn.Click += new System.EventHandler(this.WizardPage_CfgDB_TempTryConn_Click);
            // 
            // WizardPage_CfgDB_TempDelete
            // 
            this.WizardPage_CfgDB_TempDelete.Location = new System.Drawing.Point(181, 207);
            this.WizardPage_CfgDB_TempDelete.Name = "WizardPage_CfgDB_TempDelete";
            this.WizardPage_CfgDB_TempDelete.Size = new System.Drawing.Size(75, 23);
            this.WizardPage_CfgDB_TempDelete.TabIndex = 14;
            this.WizardPage_CfgDB_TempDelete.Text = "删除模板";
            this.WizardPage_CfgDB_TempDelete.UseVisualStyleBackColor = true;
            this.WizardPage_CfgDB_TempDelete.Click += new System.EventHandler(this.WizardPage_CfgDB_TempDelete_Click);
            // 
            // WizardPage_CfgDB_TempDBType
            // 
            this.WizardPage_CfgDB_TempDBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WizardPage_CfgDB_TempDBType.FormattingEnabled = true;
            this.WizardPage_CfgDB_TempDBType.Items.AddRange(new object[] {
            "SQLServer2005",
            "Oracle"});
            this.WizardPage_CfgDB_TempDBType.Location = new System.Drawing.Point(71, 77);
            this.WizardPage_CfgDB_TempDBType.Name = "WizardPage_CfgDB_TempDBType";
            this.WizardPage_CfgDB_TempDBType.Size = new System.Drawing.Size(185, 21);
            this.WizardPage_CfgDB_TempDBType.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "库驱动：";
            // 
            // WizardPage_CfgDB_TempDBConnStrig
            // 
            this.WizardPage_CfgDB_TempDBConnStrig.Location = new System.Drawing.Point(70, 114);
            this.WizardPage_CfgDB_TempDBConnStrig.Multiline = true;
            this.WizardPage_CfgDB_TempDBConnStrig.Name = "WizardPage_CfgDB_TempDBConnStrig";
            this.WizardPage_CfgDB_TempDBConnStrig.Size = new System.Drawing.Size(186, 78);
            this.WizardPage_CfgDB_TempDBConnStrig.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "连接串：";
            // 
            // WizardPage_CfgDB_TempAllDB
            // 
            this.WizardPage_CfgDB_TempAllDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WizardPage_CfgDB_TempAllDB.FormattingEnabled = true;
            this.WizardPage_CfgDB_TempAllDB.Location = new System.Drawing.Point(71, 37);
            this.WizardPage_CfgDB_TempAllDB.Name = "WizardPage_CfgDB_TempAllDB";
            this.WizardPage_CfgDB_TempAllDB.Size = new System.Drawing.Size(185, 21);
            this.WizardPage_CfgDB_TempAllDB.TabIndex = 8;
            this.WizardPage_CfgDB_TempAllDB.SelectedIndexChanged += new System.EventHandler(this.WizardPage_CfgDB_TempAllDB_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "已有库：";
            // 
            // WizardPage_CfgDB_Header
            // 
            this.WizardPage_CfgDB_Header.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.WizardPage_CfgDB_Header.BackColor = System.Drawing.SystemColors.Control;
            this.WizardPage_CfgDB_Header.CausesValidation = false;
            this.WizardPage_CfgDB_Header.Description = "请您先配置您的数据库连接";
            this.WizardPage_CfgDB_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.WizardPage_CfgDB_Header.Image = ((System.Drawing.Image)(resources.GetObject("WizardPage_CfgDB_Header.Image")));
            this.WizardPage_CfgDB_Header.Location = new System.Drawing.Point(0, 0);
            this.WizardPage_CfgDB_Header.Name = "WizardPage_CfgDB_Header";
            this.WizardPage_CfgDB_Header.Size = new System.Drawing.Size(575, 62);
            this.WizardPage_CfgDB_Header.TabIndex = 0;
            this.WizardPage_CfgDB_Header.Title = "WebMis生成向导  第一步";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.FirstPageOfWizard);
            this.wizardPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage1.IsFinishPage = false;
            this.wizardPage1.Location = new System.Drawing.Point(0, 0);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(575, 336);
            this.wizardPage1.TabIndex = 1;
            // 
            // FirstPageOfWizard
            // 
            this.FirstPageOfWizard.BackColor = System.Drawing.Color.White;
            this.FirstPageOfWizard.Controls.Add(this.label1);
            this.FirstPageOfWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirstPageOfWizard.ForeColor = System.Drawing.Color.Navy;
            this.FirstPageOfWizard.Image = ((System.Drawing.Image)(resources.GetObject("FirstPageOfWizard.Image")));
            this.FirstPageOfWizard.Location = new System.Drawing.Point(0, 0);
            this.FirstPageOfWizard.Name = "FirstPageOfWizard";
            this.FirstPageOfWizard.PageTitle = "欢迎使用WebMis自动生成向导";
            this.FirstPageOfWizard.Size = new System.Drawing.Size(575, 336);
            this.FirstPageOfWizard.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(216, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 83);
            this.label1.TabIndex = 8;
            this.label1.Text = "       WebMisDeveloper将会根据您的配置，快速的生成一套\r\n\r\n基于B/S架构的信息管理系统，大大减少了程序员的开发时\r\n\r\n间，使程序员的主" +
                "要精力放在后期逻辑开发上";
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.WizardPage_Success);
            this.wizardPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage2.IsFinishPage = false;
            this.wizardPage2.Location = new System.Drawing.Point(0, 0);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(575, 336);
            this.wizardPage2.TabIndex = 7;
            // 
            // WizardPage_Success
            // 
            this.WizardPage_Success.BackColor = System.Drawing.Color.White;
            this.WizardPage_Success.Controls.Add(this.label11);
            this.WizardPage_Success.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WizardPage_Success.ForeColor = System.Drawing.Color.Navy;
            this.WizardPage_Success.Image = ((System.Drawing.Image)(resources.GetObject("WizardPage_Success.Image")));
            this.WizardPage_Success.Location = new System.Drawing.Point(0, 0);
            this.WizardPage_Success.Name = "WizardPage_Success";
            this.WizardPage_Success.PageTitle = "WebMis生成完毕，非常感谢您的使用";
            this.WizardPage_Success.Size = new System.Drawing.Size(575, 336);
            this.WizardPage_Success.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(216, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(280, 109);
            this.label11.TabIndex = 8;
            this.label11.Text = "欢迎您提出宝贵意见\r\n\r\nEmail:ovenjackchain@gmail.com\r\n\r\nBlog:http://www.qidian10.com\r\n\r\nQQ:" +
                "710782046";
            // 
            // Leader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 384);
            this.Controls.Add(this.MainWizard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Leader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "起点10--WebMis生成向导";
            this.Load += new System.EventHandler(this.Leader_Load);
            this.MainWizard.ResumeLayout(false);
            this.WizardPage_FrameType.ResumeLayout(false);
            this.WizardPage_FrameType.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.WizardPage_CfgPath.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.WizardPage_AutoCreate.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.WizardPage_CfgMenu.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.WizardPage_TableMgr.ResumeLayout(false);
            this.WizardPage_Table_CurrentDBName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WizardPage_Table_DGV)).EndInit();
            this.WizardPage_CfgDB.ResumeLayout(false);
            this.WizardPage_CfgDB.PerformLayout();
            this.WizardPage_CfgDB_GroupBoxNew.ResumeLayout(false);
            this.WizardPage_CfgDB_GroupBoxNew.PerformLayout();
            this.WizardPage_CfgDB_GroupBoxTemplate.ResumeLayout(false);
            this.WizardPage_CfgDB_GroupBoxTemplate.PerformLayout();
            this.wizardPage1.ResumeLayout(false);
            this.FirstPageOfWizard.ResumeLayout(false);
            this.wizardPage2.ResumeLayout(false);
            this.WizardPage_Success.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard MainWizard;
        private Gui.Wizard.WizardPage wizardPage1;
        private Gui.Wizard.InfoContainer FirstPageOfWizard;
        private System.Windows.Forms.Label label1;
        private Gui.Wizard.WizardPage WizardPage_CfgDB;
        private Gui.Wizard.Header WizardPage_CfgDB_Header;
        private System.Windows.Forms.GroupBox WizardPage_CfgDB_GroupBoxTemplate;
        private System.Windows.Forms.RadioButton WizardPage_CfgDB_RBtn_TempDBConn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WizardPage_CfgDB_NewDBConnString;
        private System.Windows.Forms.GroupBox WizardPage_CfgDB_GroupBoxNew;
        private System.Windows.Forms.ComboBox WizardPage_CfgDB_NewDBType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox WizardPage_CfgDB_NewDBName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button WizardPage_CfgDB_NewBtnTryConn;
        private System.Windows.Forms.RadioButton WizardPage_CfgDB_RBtn_NewDBConn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox WizardPage_CfgDB_TempDBType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox WizardPage_CfgDB_TempDBConnStrig;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox WizardPage_CfgDB_TempAllDB;
        private Gui.Wizard.Header WizardPage_TableMgr_Header;
        private System.Windows.Forms.GroupBox WizardPage_Table_CurrentDBName;
        private System.Windows.Forms.Button WizardPage_Table_BtnChange;
        private System.Windows.Forms.Button WizardPage_Table_BtnAdd;
        private System.Windows.Forms.Button WizardPage_Table_BtnDel;
        private System.Windows.Forms.Button WizardPage_CfgDB_TempDelete;
        private System.Windows.Forms.Button WizardPage_CfgDB_TempTryConn;
        private Gui.Wizard.WizardPage WizardPage_CfgMenu;
        private Gui.Wizard.Header WizardPage_CfgMenu_Header;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView WizardPage_CfgMenu_Tree;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button WizardPage_CfgMenu_BtnDel;
        private System.Windows.Forms.Button WizardPage_CfgMenu_BtnSave;
        private System.Windows.Forms.ComboBox WizardPage_CfgMenu_CbTable;
        private System.Windows.Forms.TextBox WizardPage_CfgMenu_TxtNodeName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button WizardPage_CfgMenu_BtnDown;
        private System.Windows.Forms.Button WizardPage_CfgMenu_BtnUP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox WizardPage_CfgMenu_TxtNodeID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button WizardPage_CfgMenu_BtnAdd;
        private Gui.Wizard.WizardPage WizardPage_AutoCreate;
        private System.Windows.Forms.ProgressBar WizardPage_AutoCreate_PBar;
        private Gui.Wizard.Header header1;
        private System.Windows.Forms.GroupBox groupBox5;
        private Gui.Wizard.WizardPage wizardPage2;
        private Gui.Wizard.InfoContainer WizardPage_Success;
        private System.Windows.Forms.Label label11;
        private Gui.Wizard.WizardPage WizardPage_TableMgr;
        private System.Windows.Forms.DataGridView WizardPage_Table_DGV;
        private System.Windows.Forms.RichTextBox WizardPage_AutoCreate_TxtDetail;
        private System.Windows.Forms.Button WizardPage_Table_BtnToDDic;
        private Gui.Wizard.WizardPage WizardPage_FrameType;
        private System.Windows.Forms.RadioButton RBtnFrame_SampleThree;
        private System.Windows.Forms.RadioButton RBtnFrame_MVC;
        private Gui.Wizard.Header header2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private Gui.Wizard.WizardPage WizardPage_CfgPath;
        private System.Windows.Forms.GroupBox groupBox4;
        private Gui.Wizard.Header WizardPage_CfgPath_Header;
        private System.Windows.Forms.TextBox WizardPage_CfgPath_TxtPath;
        private System.Windows.Forms.Button WizardPage_CfgPath_BtnView;
        private System.Windows.Forms.Label WizardPage_CfgPath_LbWarnning;
        private System.Windows.Forms.RadioButton RBtnFrame_ExtNet;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label14;
    }
}