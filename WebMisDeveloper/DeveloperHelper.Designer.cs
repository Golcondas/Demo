namespace WebMisDeveloper
{
    partial class DeveloperHelper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeveloperHelper));
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.Wizard_DHelper = new Gui.Wizard.Wizard();
            this.WPath = new Gui.Wizard.WizardPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RBtnFrame_ExtNet = new System.Windows.Forms.RadioButton();
            this.RBtnFrame_MVC = new System.Windows.Forms.RadioButton();
            this.WPath_Btn = new System.Windows.Forms.Button();
            this.RBtnFrame_SampleThree = new System.Windows.Forms.RadioButton();
            this.WPath_Txt = new System.Windows.Forms.TextBox();
            this.WDHHeader3 = new Gui.Wizard.Header();
            this.WCorePage = new Gui.Wizard.WizardPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.WCCLBox = new System.Windows.Forms.CheckedListBox();
            this.WDHHeader = new Gui.Wizard.Header();
            this.WDBPage = new Gui.Wizard.WizardPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WDHBtn = new System.Windows.Forms.Button();
            this.WDHCbo = new System.Windows.Forms.ComboBox();
            this.WDHTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WDBconnPage_Header = new Gui.Wizard.Header();
            this.wizardPage1 = new Gui.Wizard.WizardPage();
            this.FirstPageOfDHWizard = new Gui.Wizard.InfoContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.wizardPage2 = new Gui.Wizard.WizardPage();
            this.WizardPage_Success = new Gui.Wizard.InfoContainer();
            this.label11 = new System.Windows.Forms.Label();
            this.WAutoCreate = new Gui.Wizard.WizardPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.WAutoCreate_TxtDetail = new System.Windows.Forms.RichTextBox();
            this.WAutoCreate_PBar = new System.Windows.Forms.ProgressBar();
            this.WAutoCreate_Header = new Gui.Wizard.Header();
            this.Wizard_DHelper.SuspendLayout();
            this.WPath.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.WCorePage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.WDBPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            this.FirstPageOfDHWizard.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            this.WizardPage_Success.SuspendLayout();
            this.WAutoCreate.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Wizard_DHelper
            // 
            this.Wizard_DHelper.Controls.Add(this.WPath);
            this.Wizard_DHelper.Controls.Add(this.WCorePage);
            this.Wizard_DHelper.Controls.Add(this.WDBPage);
            this.Wizard_DHelper.Controls.Add(this.wizardPage1);
            this.Wizard_DHelper.Controls.Add(this.wizardPage2);
            this.Wizard_DHelper.Controls.Add(this.WAutoCreate);
            this.Wizard_DHelper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wizard_DHelper.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wizard_DHelper.Location = new System.Drawing.Point(0, 0);
            this.Wizard_DHelper.Name = "Wizard_DHelper";
            this.Wizard_DHelper.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.wizardPage1,
            this.WDBPage,
            this.WCorePage,
            this.WPath,
            this.WAutoCreate,
            this.wizardPage2});
            this.Wizard_DHelper.Size = new System.Drawing.Size(575, 384);
            this.Wizard_DHelper.TabIndex = 0;
            this.Wizard_DHelper.CloseFromCancel += new System.ComponentModel.CancelEventHandler(this.Wizard_DHelper_CloseFromCancel);
            // 
            // WPath
            // 
            this.WPath.Controls.Add(this.groupBox4);
            this.WPath.Controls.Add(this.WDHHeader3);
            this.WPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WPath.ForeColor = System.Drawing.Color.Navy;
            this.WPath.IsFinishPage = false;
            this.WPath.Location = new System.Drawing.Point(0, 0);
            this.WPath.Name = "WPath";
            this.WPath.Size = new System.Drawing.Size(575, 336);
            this.WPath.TabIndex = 4;
            this.WPath.CloseFromNext += new Gui.Wizard.PageEventHandler(this.WPath_CloseFromNext);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RBtnFrame_ExtNet);
            this.groupBox4.Controls.Add(this.RBtnFrame_MVC);
            this.groupBox4.Controls.Add(this.WPath_Btn);
            this.groupBox4.Controls.Add(this.RBtnFrame_SampleThree);
            this.groupBox4.Controls.Add(this.WPath_Txt);
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(75, 128);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(425, 120);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "请选择项目源文件夹以及项目架构类型";
            // 
            // RBtnFrame_ExtNet
            // 
            this.RBtnFrame_ExtNet.AutoSize = true;
            this.RBtnFrame_ExtNet.Checked = true;
            this.RBtnFrame_ExtNet.ForeColor = System.Drawing.Color.Red;
            this.RBtnFrame_ExtNet.Location = new System.Drawing.Point(246, 31);
            this.RBtnFrame_ExtNet.Name = "RBtnFrame_ExtNet";
            this.RBtnFrame_ExtNet.Size = new System.Drawing.Size(118, 17);
            this.RBtnFrame_ExtNet.TabIndex = 12;
            this.RBtnFrame_ExtNet.TabStop = true;
            this.RBtnFrame_ExtNet.Text = "三层架构(Ext.Net)";
            this.RBtnFrame_ExtNet.UseVisualStyleBackColor = true;
            // 
            // RBtnFrame_MVC
            // 
            this.RBtnFrame_MVC.AutoSize = true;
            this.RBtnFrame_MVC.Location = new System.Drawing.Point(61, 31);
            this.RBtnFrame_MVC.Name = "RBtnFrame_MVC";
            this.RBtnFrame_MVC.Size = new System.Drawing.Size(70, 17);
            this.RBtnFrame_MVC.TabIndex = 10;
            this.RBtnFrame_MVC.Text = "MVC架构";
            this.RBtnFrame_MVC.UseVisualStyleBackColor = true;
            // 
            // WPath_Btn
            // 
            this.WPath_Btn.Location = new System.Drawing.Point(322, 68);
            this.WPath_Btn.Name = "WPath_Btn";
            this.WPath_Btn.Size = new System.Drawing.Size(59, 23);
            this.WPath_Btn.TabIndex = 1;
            this.WPath_Btn.Text = "浏览...";
            this.WPath_Btn.UseVisualStyleBackColor = true;
            this.WPath_Btn.Click += new System.EventHandler(this.WPath_Btn_Click);
            // 
            // RBtnFrame_SampleThree
            // 
            this.RBtnFrame_SampleThree.AutoSize = true;
            this.RBtnFrame_SampleThree.Location = new System.Drawing.Point(156, 31);
            this.RBtnFrame_SampleThree.Name = "RBtnFrame_SampleThree";
            this.RBtnFrame_SampleThree.Size = new System.Drawing.Size(73, 17);
            this.RBtnFrame_SampleThree.TabIndex = 11;
            this.RBtnFrame_SampleThree.Text = "三层架构";
            this.RBtnFrame_SampleThree.UseVisualStyleBackColor = true;
            // 
            // WPath_Txt
            // 
            this.WPath_Txt.Location = new System.Drawing.Point(43, 69);
            this.WPath_Txt.Name = "WPath_Txt";
            this.WPath_Txt.ReadOnly = true;
            this.WPath_Txt.Size = new System.Drawing.Size(273, 21);
            this.WPath_Txt.TabIndex = 2;
            // 
            // WDHHeader3
            // 
            this.WDHHeader3.BackColor = System.Drawing.SystemColors.Control;
            this.WDHHeader3.CausesValidation = false;
            this.WDHHeader3.Description = "请选择项目源文件夹以及项目架构类型";
            this.WDHHeader3.Dock = System.Windows.Forms.DockStyle.Top;
            this.WDHHeader3.Image = ((System.Drawing.Image)(resources.GetObject("WDHHeader3.Image")));
            this.WDHHeader3.Location = new System.Drawing.Point(0, 0);
            this.WDHHeader3.Name = "WDHHeader3";
            this.WDHHeader3.Size = new System.Drawing.Size(575, 64);
            this.WDHHeader3.TabIndex = 0;
            this.WDHHeader3.Title = "起点10--WebMis开发助理  第三步";
            // 
            // WCorePage
            // 
            this.WCorePage.Controls.Add(this.groupBox3);
            this.WCorePage.Controls.Add(this.groupBox2);
            this.WCorePage.Controls.Add(this.WDHHeader);
            this.WCorePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WCorePage.ForeColor = System.Drawing.Color.Navy;
            this.WCorePage.IsFinishPage = false;
            this.WCorePage.Location = new System.Drawing.Point(0, 0);
            this.WCorePage.Name = "WCorePage";
            this.WCorePage.Size = new System.Drawing.Size(575, 336);
            this.WCorePage.TabIndex = 3;
            this.WCorePage.CloseFromNext += new Gui.Wizard.PageEventHandler(this.WCorePage_CloseFromNext);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(311, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(210, 195);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "温馨提示";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 164);
            this.label3.TabIndex = 0;
            this.label3.Text = "    基于您选择的表，WebMis开发助理将会自动生成基于该表的Bll、Dao、Controllers、Model层，以及对应的表现层JS文件。\r\n\r\n    " +
                "并且程序将会自动将生成的文件配置到您的解决方案的相应位置，免去手动配置的繁琐。\r\n\r\n请注意：自动生成成功后，对该表操作的节点并没有显示在页面中，您需要添加相应" +
                "节点到UserFun表中";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.WCCLBox);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(54, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 195);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "您需要哪些表？";
            // 
            // WCCLBox
            // 
            this.WCCLBox.CheckOnClick = true;
            this.WCCLBox.FormattingEnabled = true;
            this.WCCLBox.Location = new System.Drawing.Point(7, 21);
            this.WCCLBox.Name = "WCCLBox";
            this.WCCLBox.Size = new System.Drawing.Size(197, 164);
            this.WCCLBox.TabIndex = 0;
            // 
            // WDHHeader
            // 
            this.WDHHeader.BackColor = System.Drawing.SystemColors.Control;
            this.WDHHeader.CausesValidation = false;
            this.WDHHeader.Description = "定制您的业务";
            this.WDHHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.WDHHeader.Image = ((System.Drawing.Image)(resources.GetObject("WDHHeader.Image")));
            this.WDHHeader.Location = new System.Drawing.Point(0, 0);
            this.WDHHeader.Name = "WDHHeader";
            this.WDHHeader.Size = new System.Drawing.Size(575, 64);
            this.WDHHeader.TabIndex = 0;
            this.WDHHeader.Title = "起点10--WebMis开发助理  第二步";
            // 
            // WDBPage
            // 
            this.WDBPage.Controls.Add(this.groupBox1);
            this.WDBPage.Controls.Add(this.WDBconnPage_Header);
            this.WDBPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WDBPage.ForeColor = System.Drawing.Color.Navy;
            this.WDBPage.IsFinishPage = false;
            this.WDBPage.Location = new System.Drawing.Point(0, 0);
            this.WDBPage.Name = "WDBPage";
            this.WDBPage.Size = new System.Drawing.Size(575, 336);
            this.WDBPage.TabIndex = 2;
            this.WDBPage.CloseFromNext += new Gui.Wizard.PageEventHandler(this.WDBPage_CloseFromNext);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WDHBtn);
            this.groupBox1.Controls.Add(this.WDHCbo);
            this.groupBox1.Controls.Add(this.WDHTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(81, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 174);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置您的连接串";
            // 
            // WDHBtn
            // 
            this.WDHBtn.Location = new System.Drawing.Point(298, 34);
            this.WDHBtn.Name = "WDHBtn";
            this.WDHBtn.Size = new System.Drawing.Size(85, 23);
            this.WDHBtn.TabIndex = 3;
            this.WDHBtn.Text = "测试连接";
            this.WDHBtn.UseVisualStyleBackColor = true;
            this.WDHBtn.Click += new System.EventHandler(this.WDHBtn_Click);
            // 
            // WDHCbo
            // 
            this.WDHCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WDHCbo.FormattingEnabled = true;
            this.WDHCbo.Items.AddRange(new object[] {
            "SQLServer2000",
            "SQLServer2005",
            "Oracle"});
            this.WDHCbo.Location = new System.Drawing.Point(100, 36);
            this.WDHCbo.Name = "WDHCbo";
            this.WDHCbo.Size = new System.Drawing.Size(126, 21);
            this.WDHCbo.TabIndex = 0;
            this.WDHCbo.SelectedIndexChanged += new System.EventHandler(this.WDHCbo_SelectedIndexChanged);
            // 
            // WDHTxt
            // 
            this.WDHTxt.Location = new System.Drawing.Point(30, 76);
            this.WDHTxt.Multiline = true;
            this.WDHTxt.Name = "WDHTxt";
            this.WDHTxt.Size = new System.Drawing.Size(353, 75);
            this.WDHTxt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据库类型：";
            // 
            // WDBconnPage_Header
            // 
            this.WDBconnPage_Header.BackColor = System.Drawing.SystemColors.Control;
            this.WDBconnPage_Header.CausesValidation = false;
            this.WDBconnPage_Header.Description = "配置您的数据库连接串";
            this.WDBconnPage_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.WDBconnPage_Header.Image = ((System.Drawing.Image)(resources.GetObject("WDBconnPage_Header.Image")));
            this.WDBconnPage_Header.Location = new System.Drawing.Point(0, 0);
            this.WDBconnPage_Header.Name = "WDBconnPage_Header";
            this.WDBconnPage_Header.Size = new System.Drawing.Size(575, 64);
            this.WDBconnPage_Header.TabIndex = 0;
            this.WDBconnPage_Header.Title = "起点10--WebMis开发助理  第一步";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.FirstPageOfDHWizard);
            this.wizardPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage1.IsFinishPage = false;
            this.wizardPage1.Location = new System.Drawing.Point(0, 0);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(575, 336);
            this.wizardPage1.TabIndex = 1;
            // 
            // FirstPageOfDHWizard
            // 
            this.FirstPageOfDHWizard.BackColor = System.Drawing.Color.White;
            this.FirstPageOfDHWizard.Controls.Add(this.label1);
            this.FirstPageOfDHWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirstPageOfDHWizard.ForeColor = System.Drawing.Color.Navy;
            this.FirstPageOfDHWizard.Image = ((System.Drawing.Image)(resources.GetObject("FirstPageOfDHWizard.Image")));
            this.FirstPageOfDHWizard.Location = new System.Drawing.Point(0, 0);
            this.FirstPageOfDHWizard.Name = "FirstPageOfDHWizard";
            this.FirstPageOfDHWizard.PageTitle = "欢迎使用WebMis二次开发助理";
            this.FirstPageOfDHWizard.Size = new System.Drawing.Size(575, 336);
            this.FirstPageOfDHWizard.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(215, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 134);
            this.label1.TabIndex = 8;
            this.label1.Text = "       WebMisDeveloper二次开发助理将会帮助您快速高效\r\n\r\n的完善WebMis。\r\n\r\n      本向导将会根据您的数据库表快速产生与之对" +
                "应的\r\n\r\nModel、 View、 Controller，使得程序员摆脱基础重复的\r\n\r\n代码编写任务，将更多的精力投入的逻辑开发中。";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.WizardPage_Success);
            this.wizardPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage2.IsFinishPage = false;
            this.wizardPage2.Location = new System.Drawing.Point(0, 0);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(575, 336);
            this.wizardPage2.TabIndex = 6;
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
            this.WizardPage_Success.PageTitle = "您的业务生成完毕，非常感谢您的使用";
            this.WizardPage_Success.Size = new System.Drawing.Size(575, 336);
            this.WizardPage_Success.TabIndex = 1;
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
            // WAutoCreate
            // 
            this.WAutoCreate.Controls.Add(this.groupBox5);
            this.WAutoCreate.Controls.Add(this.WAutoCreate_PBar);
            this.WAutoCreate.Controls.Add(this.WAutoCreate_Header);
            this.WAutoCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WAutoCreate.ForeColor = System.Drawing.Color.Navy;
            this.WAutoCreate.IsFinishPage = false;
            this.WAutoCreate.Location = new System.Drawing.Point(0, 0);
            this.WAutoCreate.Name = "WAutoCreate";
            this.WAutoCreate.Size = new System.Drawing.Size(575, 336);
            this.WAutoCreate.TabIndex = 5;
            this.WAutoCreate.ShowFromNext += new System.EventHandler(this.WAutoCreate_ShowFromNext);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.WAutoCreate_TxtDetail);
            this.groupBox5.ForeColor = System.Drawing.Color.Navy;
            this.groupBox5.Location = new System.Drawing.Point(52, 132);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(470, 170);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "生成明细";
            // 
            // WAutoCreate_TxtDetail
            // 
            this.WAutoCreate_TxtDetail.BackColor = System.Drawing.Color.Black;
            this.WAutoCreate_TxtDetail.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WAutoCreate_TxtDetail.ForeColor = System.Drawing.Color.Lime;
            this.WAutoCreate_TxtDetail.Location = new System.Drawing.Point(7, 21);
            this.WAutoCreate_TxtDetail.Name = "WAutoCreate_TxtDetail";
            this.WAutoCreate_TxtDetail.Size = new System.Drawing.Size(457, 143);
            this.WAutoCreate_TxtDetail.TabIndex = 0;
            this.WAutoCreate_TxtDetail.Text = "";
            // 
            // WAutoCreate_PBar
            // 
            this.WAutoCreate_PBar.Location = new System.Drawing.Point(52, 83);
            this.WAutoCreate_PBar.Name = "WAutoCreate_PBar";
            this.WAutoCreate_PBar.Size = new System.Drawing.Size(470, 33);
            this.WAutoCreate_PBar.TabIndex = 2;
            // 
            // WAutoCreate_Header
            // 
            this.WAutoCreate_Header.BackColor = System.Drawing.SystemColors.Control;
            this.WAutoCreate_Header.CausesValidation = false;
            this.WAutoCreate_Header.Description = "自动生成开始，请您稍后......";
            this.WAutoCreate_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.WAutoCreate_Header.Image = ((System.Drawing.Image)(resources.GetObject("WAutoCreate_Header.Image")));
            this.WAutoCreate_Header.Location = new System.Drawing.Point(0, 0);
            this.WAutoCreate_Header.Name = "WAutoCreate_Header";
            this.WAutoCreate_Header.Size = new System.Drawing.Size(575, 64);
            this.WAutoCreate_Header.TabIndex = 0;
            this.WAutoCreate_Header.Title = "起点10--WebMis开发助理  第四步";
            // 
            // DeveloperHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 384);
            this.Controls.Add(this.Wizard_DHelper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeveloperHelper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "起点10--WebMis开发助理";
            this.Load += new System.EventHandler(this.DeveloperHelper_Load);
            this.Wizard_DHelper.ResumeLayout(false);
            this.WPath.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.WCorePage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.WDBPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.wizardPage1.ResumeLayout(false);
            this.FirstPageOfDHWizard.ResumeLayout(false);
            this.wizardPage2.ResumeLayout(false);
            this.WizardPage_Success.ResumeLayout(false);
            this.WAutoCreate.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard Wizard_DHelper;
        private Gui.Wizard.WizardPage wizardPage1;
        private Gui.Wizard.InfoContainer FirstPageOfDHWizard;
        private System.Windows.Forms.Label label1;
        private Gui.Wizard.WizardPage WDBPage;
        private Gui.Wizard.Header WDBconnPage_Header;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox WDHCbo;
        private System.Windows.Forms.Button WDHBtn;
        private System.Windows.Forms.TextBox WDHTxt;
        private System.Windows.Forms.Label label2;
        private Gui.Wizard.WizardPage WCorePage;
        private System.Windows.Forms.GroupBox groupBox2;
        private Gui.Wizard.Header WDHHeader;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox WCCLBox;
        private Gui.Wizard.WizardPage WPath;
        private System.Windows.Forms.TextBox WPath_Txt;
        private System.Windows.Forms.Button WPath_Btn;
        private Gui.Wizard.Header WDHHeader3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private Gui.Wizard.WizardPage WAutoCreate;
        private Gui.Wizard.Header WAutoCreate_Header;
        private System.Windows.Forms.ProgressBar WAutoCreate_PBar;
        private System.Windows.Forms.GroupBox groupBox5;
        private Gui.Wizard.WizardPage wizardPage2;
        private Gui.Wizard.InfoContainer WizardPage_Success;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox WAutoCreate_TxtDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton RBtnFrame_MVC;
        private System.Windows.Forms.RadioButton RBtnFrame_SampleThree;
        private System.Windows.Forms.RadioButton RBtnFrame_ExtNet;
    }
}