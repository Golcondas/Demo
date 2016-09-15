namespace WebMisDeveloper
{
    partial class QuickDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickDesign));
            this.wizard1 = new Gui.Wizard.Wizard();
            this.wizardPage4 = new Gui.Wizard.WizardPage();
            this.FirstPageOfWizard = new Gui.Wizard.InfoContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.wizardPage5 = new Gui.Wizard.WizardPage();
            this.WizardPage_Success = new Gui.Wizard.InfoContainer();
            this.label11 = new System.Windows.Forms.Label();
            this.wizardPage3 = new Gui.Wizard.WizardPage();
            this.RTbcode = new System.Windows.Forms.RichTextBox();
            this.header3 = new Gui.Wizard.Header();
            this.wizardPage2 = new Gui.Wizard.WizardPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbRepeater = new System.Windows.Forms.CheckBox();
            this.cbuilb = new System.Windows.Forms.CheckBox();
            this.cbjswb = new System.Windows.Forms.CheckBox();
            this.cbjstk = new System.Windows.Forms.CheckBox();
            this.cbget = new System.Windows.Forms.CheckBox();
            this.cbvset = new System.Windows.Forms.CheckBox();
            this.cbui = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxTables = new System.Windows.Forms.ComboBox();
            this.header2 = new Gui.Wizard.Header();
            this.wizardPage1 = new Gui.Wizard.WizardPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnTryConn = new System.Windows.Forms.Button();
            this.Cbo_DBType = new System.Windows.Forms.ComboBox();
            this.TxtConn = new System.Windows.Forms.TextBox();
            this.CboxDbs = new System.Windows.Forms.ComboBox();
            this.RBtnNew = new System.Windows.Forms.RadioButton();
            this.RBtnTemp = new System.Windows.Forms.RadioButton();
            this.header1 = new Gui.Wizard.Header();
            this.wizard1.SuspendLayout();
            this.wizardPage4.SuspendLayout();
            this.FirstPageOfWizard.SuspendLayout();
            this.wizardPage5.SuspendLayout();
            this.WizardPage_Success.SuspendLayout();
            this.wizardPage3.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.wizardPage2);
            this.wizard1.Controls.Add(this.wizardPage1);
            this.wizard1.Controls.Add(this.wizardPage4);
            this.wizard1.Controls.Add(this.wizardPage5);
            this.wizard1.Controls.Add(this.wizardPage3);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizard1.Location = new System.Drawing.Point(0, 0);
            this.wizard1.Name = "wizard1";
            this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.wizardPage4,
            this.wizardPage1,
            this.wizardPage2,
            this.wizardPage3,
            this.wizardPage5});
            this.wizard1.Size = new System.Drawing.Size(565, 374);
            this.wizard1.TabIndex = 0;
            this.wizard1.Load += new System.EventHandler(this.wizard1_Load);
            this.wizard1.CloseFromCancel += new System.ComponentModel.CancelEventHandler(this.wizard1_CloseFromCancel);
            // 
            // wizardPage4
            // 
            this.wizardPage4.Controls.Add(this.FirstPageOfWizard);
            this.wizardPage4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage4.IsFinishPage = false;
            this.wizardPage4.Location = new System.Drawing.Point(0, 0);
            this.wizardPage4.Name = "wizardPage4";
            this.wizardPage4.Size = new System.Drawing.Size(565, 326);
            this.wizardPage4.TabIndex = 4;
            // 
            // FirstPageOfWizard
            // 
            this.FirstPageOfWizard.BackColor = System.Drawing.Color.White;
            this.FirstPageOfWizard.Controls.Add(this.label2);
            this.FirstPageOfWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirstPageOfWizard.ForeColor = System.Drawing.Color.Navy;
            this.FirstPageOfWizard.Image = ((System.Drawing.Image)(resources.GetObject("FirstPageOfWizard.Image")));
            this.FirstPageOfWizard.Location = new System.Drawing.Point(0, 0);
            this.FirstPageOfWizard.Name = "FirstPageOfWizard";
            this.FirstPageOfWizard.PageTitle = "欢迎使用Asp.net页面元素速成向导";
            this.FirstPageOfWizard.Size = new System.Drawing.Size(565, 326);
            this.FirstPageOfWizard.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(216, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 103);
            this.label2.TabIndex = 8;
            this.label2.Text = "       WebMisDeveloper将会根据您的配置，快速生成基于该表\r\n\r\n的Asp.net页面，页面中包括各个字段的文本框、js验证、后\r\n\r\n台赋值" +
                "、界面赋值能代码，您只需要选择代码粘贴到您的项\r\n\r\n目的相应位置即可";
            // 
            // wizardPage5
            // 
            this.wizardPage5.Controls.Add(this.WizardPage_Success);
            this.wizardPage5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage5.IsFinishPage = false;
            this.wizardPage5.Location = new System.Drawing.Point(0, 0);
            this.wizardPage5.Name = "wizardPage5";
            this.wizardPage5.Size = new System.Drawing.Size(565, 326);
            this.wizardPage5.TabIndex = 5;
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
            this.WizardPage_Success.PageTitle = "代码生成完毕，非常感谢您的使用";
            this.WizardPage_Success.Size = new System.Drawing.Size(565, 326);
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
            // wizardPage3
            // 
            this.wizardPage3.Controls.Add(this.RTbcode);
            this.wizardPage3.Controls.Add(this.header3);
            this.wizardPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage3.IsFinishPage = false;
            this.wizardPage3.Location = new System.Drawing.Point(0, 0);
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.Size = new System.Drawing.Size(565, 326);
            this.wizardPage3.TabIndex = 3;
            this.wizardPage3.CloseFromNext += new Gui.Wizard.PageEventHandler(this.wizardPage3_CloseFromNext);
            this.wizardPage3.CloseFromBack += new Gui.Wizard.PageEventHandler(this.wizardPage3_CloseFromBack);
            this.wizardPage3.ShowFromBack += new System.EventHandler(this.wizardPage3_ShowFromBack);
            this.wizardPage3.ShowFromNext += new System.EventHandler(this.wizardPage3_ShowFromNext);
            // 
            // RTbcode
            // 
            this.RTbcode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RTbcode.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RTbcode.Location = new System.Drawing.Point(12, 73);
            this.RTbcode.Name = "RTbcode";
            this.RTbcode.Size = new System.Drawing.Size(541, 240);
            this.RTbcode.TabIndex = 1;
            this.RTbcode.Text = "";
            // 
            // header3
            // 
            this.header3.BackColor = System.Drawing.SystemColors.Control;
            this.header3.CausesValidation = false;
            this.header3.Description = "请手动拷贝代码到您的项目中";
            this.header3.Dock = System.Windows.Forms.DockStyle.Top;
            this.header3.ForeColor = System.Drawing.Color.Navy;
            this.header3.Image = ((System.Drawing.Image)(resources.GetObject("header3.Image")));
            this.header3.Location = new System.Drawing.Point(0, 0);
            this.header3.Name = "header3";
            this.header3.Size = new System.Drawing.Size(565, 64);
            this.header3.TabIndex = 0;
            this.header3.Title = "Asp.net页面元素速成   第三步";
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.groupBox2);
            this.wizardPage2.Controls.Add(this.header2);
            this.wizardPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage2.IsFinishPage = false;
            this.wizardPage2.Location = new System.Drawing.Point(0, 0);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(565, 326);
            this.wizardPage2.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbRepeater);
            this.groupBox2.Controls.Add(this.cbuilb);
            this.groupBox2.Controls.Add(this.cbjswb);
            this.groupBox2.Controls.Add(this.cbjstk);
            this.groupBox2.Controls.Add(this.cbget);
            this.groupBox2.Controls.Add(this.cbvset);
            this.groupBox2.Controls.Add(this.cbui);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cBoxTables);
            this.groupBox2.Location = new System.Drawing.Point(46, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 186);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择表及任务";
            // 
            // cbRepeater
            // 
            this.cbRepeater.AutoSize = true;
            this.cbRepeater.Location = new System.Drawing.Point(63, 147);
            this.cbRepeater.Name = "cbRepeater";
            this.cbRepeater.Size = new System.Drawing.Size(177, 17);
            this.cbRepeater.TabIndex = 13;
            this.cbRepeater.Text = "Repeater数据绑定，Ajax分页";
            this.cbRepeater.UseVisualStyleBackColor = true;
            // 
            // cbuilb
            // 
            this.cbuilb.AutoSize = true;
            this.cbuilb.Location = new System.Drawing.Point(193, 112);
            this.cbuilb.Name = "cbuilb";
            this.cbuilb.Size = new System.Drawing.Size(112, 17);
            this.cbuilb.TabIndex = 12;
            this.cbuilb.Text = "Asp.net标签界面";
            this.cbuilb.UseVisualStyleBackColor = true;
            this.cbuilb.CheckedChanged += new System.EventHandler(this.cbuilb_CheckedChanged);
            // 
            // cbjswb
            // 
            this.cbjswb.AutoSize = true;
            this.cbjswb.Checked = true;
            this.cbjswb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbjswb.Location = new System.Drawing.Point(193, 77);
            this.cbjswb.Name = "cbjswb";
            this.cbjswb.Size = new System.Drawing.Size(82, 17);
            this.cbjswb.TabIndex = 11;
            this.cbjswb.Text = "js文本验证";
            this.cbjswb.UseVisualStyleBackColor = true;
            // 
            // cbjstk
            // 
            this.cbjstk.AutoSize = true;
            this.cbjstk.Location = new System.Drawing.Point(63, 77);
            this.cbjstk.Name = "cbjstk";
            this.cbjstk.Size = new System.Drawing.Size(82, 17);
            this.cbjstk.TabIndex = 10;
            this.cbjstk.Text = "js弹框验证";
            this.cbjstk.UseVisualStyleBackColor = true;
            // 
            // cbget
            // 
            this.cbget.AutoSize = true;
            this.cbget.Checked = true;
            this.cbget.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbget.Location = new System.Drawing.Point(316, 112);
            this.cbget.Name = "cbget";
            this.cbget.Size = new System.Drawing.Size(110, 17);
            this.cbget.TabIndex = 6;
            this.cbget.Text = "后台获得界面值";
            this.cbget.UseVisualStyleBackColor = true;
            // 
            // cbvset
            // 
            this.cbvset.AutoSize = true;
            this.cbvset.Checked = true;
            this.cbvset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbvset.Location = new System.Drawing.Point(316, 77);
            this.cbvset.Name = "cbvset";
            this.cbvset.Size = new System.Drawing.Size(110, 17);
            this.cbvset.TabIndex = 5;
            this.cbvset.Text = "后台给界面赋值";
            this.cbvset.UseVisualStyleBackColor = true;
            // 
            // cbui
            // 
            this.cbui.AutoSize = true;
            this.cbui.Checked = true;
            this.cbui.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbui.Location = new System.Drawing.Point(63, 112);
            this.cbui.Name = "cbui";
            this.cbui.Size = new System.Drawing.Size(124, 17);
            this.cbui.TabIndex = 4;
            this.cbui.Text = "Asp.net文本框界面";
            this.cbui.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "选择表";
            // 
            // cBoxTables
            // 
            this.cBoxTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTables.FormattingEnabled = true;
            this.cBoxTables.Location = new System.Drawing.Point(123, 31);
            this.cBoxTables.Name = "cBoxTables";
            this.cBoxTables.Size = new System.Drawing.Size(270, 21);
            this.cBoxTables.TabIndex = 1;
            // 
            // header2
            // 
            this.header2.BackColor = System.Drawing.SystemColors.Control;
            this.header2.CausesValidation = false;
            this.header2.Description = "选择表对象以及要生成的任务";
            this.header2.Dock = System.Windows.Forms.DockStyle.Top;
            this.header2.ForeColor = System.Drawing.Color.Navy;
            this.header2.Image = ((System.Drawing.Image)(resources.GetObject("header2.Image")));
            this.header2.Location = new System.Drawing.Point(0, 0);
            this.header2.Name = "header2";
            this.header2.Size = new System.Drawing.Size(565, 64);
            this.header2.TabIndex = 0;
            this.header2.Title = "Asp.net页面元素速成   第二步";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.groupBox1);
            this.wizardPage1.Controls.Add(this.header1);
            this.wizardPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage1.IsFinishPage = false;
            this.wizardPage1.Location = new System.Drawing.Point(0, 0);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(565, 326);
            this.wizardPage1.TabIndex = 1;
            this.wizardPage1.CloseFromNext += new Gui.Wizard.PageEventHandler(this.wizardPage1_CloseFromNext);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnTryConn);
            this.groupBox1.Controls.Add(this.Cbo_DBType);
            this.groupBox1.Controls.Add(this.TxtConn);
            this.groupBox1.Controls.Add(this.CboxDbs);
            this.groupBox1.Controls.Add(this.RBtnNew);
            this.groupBox1.Controls.Add(this.RBtnTemp);
            this.groupBox1.Location = new System.Drawing.Point(46, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 168);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置数据源";
            // 
            // BtnTryConn
            // 
            this.BtnTryConn.Enabled = false;
            this.BtnTryConn.Location = new System.Drawing.Point(322, 73);
            this.BtnTryConn.Name = "BtnTryConn";
            this.BtnTryConn.Size = new System.Drawing.Size(85, 23);
            this.BtnTryConn.TabIndex = 5;
            this.BtnTryConn.Text = "测试连接";
            this.BtnTryConn.UseVisualStyleBackColor = true;
            this.BtnTryConn.Click += new System.EventHandler(this.BtnTryConn_Click);
            // 
            // Cbo_DBType
            // 
            this.Cbo_DBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_DBType.Enabled = false;
            this.Cbo_DBType.FormattingEnabled = true;
            this.Cbo_DBType.Items.AddRange(new object[] {
            "SQLServer2000",
            "SQLServer2005",
            "Oracle"});
            this.Cbo_DBType.Location = new System.Drawing.Point(168, 75);
            this.Cbo_DBType.Name = "Cbo_DBType";
            this.Cbo_DBType.Size = new System.Drawing.Size(134, 21);
            this.Cbo_DBType.TabIndex = 4;
            this.Cbo_DBType.SelectedIndexChanged += new System.EventHandler(this.Cbo_DBType_SelectedIndexChanged);
            // 
            // TxtConn
            // 
            this.TxtConn.Enabled = false;
            this.TxtConn.Location = new System.Drawing.Point(65, 104);
            this.TxtConn.Multiline = true;
            this.TxtConn.Name = "TxtConn";
            this.TxtConn.Size = new System.Drawing.Size(342, 46);
            this.TxtConn.TabIndex = 3;
            // 
            // CboxDbs
            // 
            this.CboxDbs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxDbs.FormattingEnabled = true;
            this.CboxDbs.Location = new System.Drawing.Point(168, 36);
            this.CboxDbs.Name = "CboxDbs";
            this.CboxDbs.Size = new System.Drawing.Size(239, 21);
            this.CboxDbs.TabIndex = 2;
            // 
            // RBtnNew
            // 
            this.RBtnNew.AutoSize = true;
            this.RBtnNew.Location = new System.Drawing.Point(65, 76);
            this.RBtnNew.Name = "RBtnNew";
            this.RBtnNew.Size = new System.Drawing.Size(85, 17);
            this.RBtnNew.TabIndex = 1;
            this.RBtnNew.Text = "新建数据源";
            this.RBtnNew.UseVisualStyleBackColor = true;
            // 
            // RBtnTemp
            // 
            this.RBtnTemp.AutoSize = true;
            this.RBtnTemp.Checked = true;
            this.RBtnTemp.Location = new System.Drawing.Point(65, 36);
            this.RBtnTemp.Name = "RBtnTemp";
            this.RBtnTemp.Size = new System.Drawing.Size(61, 17);
            this.RBtnTemp.TabIndex = 0;
            this.RBtnTemp.TabStop = true;
            this.RBtnTemp.Text = "模板库";
            this.RBtnTemp.UseVisualStyleBackColor = true;
            this.RBtnTemp.CheckedChanged += new System.EventHandler(this.RBtnTemp_CheckedChanged);
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.SystemColors.Control;
            this.header1.CausesValidation = false;
            this.header1.Description = "请先配置数据源，选择模板库或者新建数据源";
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.ForeColor = System.Drawing.Color.Navy;
            this.header1.Image = ((System.Drawing.Image)(resources.GetObject("header1.Image")));
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(565, 64);
            this.header1.TabIndex = 0;
            this.header1.Title = "Asp.net页面元素速成   第一步";
            // 
            // QuickDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 374);
            this.Controls.Add(this.wizard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuickDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asp.net页面元素速成";
            this.Load += new System.EventHandler(this.QuickDesign_Load);
            this.wizard1.ResumeLayout(false);
            this.wizardPage4.ResumeLayout(false);
            this.FirstPageOfWizard.ResumeLayout(false);
            this.wizardPage5.ResumeLayout(false);
            this.WizardPage_Success.ResumeLayout(false);
            this.wizardPage3.ResumeLayout(false);
            this.wizardPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.wizardPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard wizard1;
        private Gui.Wizard.WizardPage wizardPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtConn;
        private System.Windows.Forms.ComboBox CboxDbs;
        private System.Windows.Forms.RadioButton RBtnNew;
        private System.Windows.Forms.RadioButton RBtnTemp;
        private Gui.Wizard.Header header1;
        private Gui.Wizard.WizardPage wizardPage2;
        private Gui.Wizard.Header header2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cBoxTables;
        private System.Windows.Forms.CheckBox cbget;
        private System.Windows.Forms.CheckBox cbvset;
        private System.Windows.Forms.CheckBox cbui;
        private System.Windows.Forms.Label label1;
        private Gui.Wizard.WizardPage wizardPage3;
        private Gui.Wizard.Header header3;
        private System.Windows.Forms.RichTextBox RTbcode;
        private Gui.Wizard.WizardPage wizardPage4;
        private Gui.Wizard.WizardPage wizardPage5;
        private Gui.Wizard.InfoContainer FirstPageOfWizard;
        private System.Windows.Forms.Label label2;
        private Gui.Wizard.InfoContainer WizardPage_Success;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbuilb;
        private System.Windows.Forms.CheckBox cbjswb;
        private System.Windows.Forms.CheckBox cbjstk;
        private System.Windows.Forms.ComboBox Cbo_DBType;
        private System.Windows.Forms.Button BtnTryConn;
        private System.Windows.Forms.CheckBox cbRepeater;

    }
}