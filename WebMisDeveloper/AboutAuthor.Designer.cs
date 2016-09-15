namespace WebMisDeveloper
{
    partial class AboutAuthor
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutAuthor));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.llab = new System.Windows.Forms.LinkLabel();
            this.emaillb = new System.Windows.Forms.LinkLabel();
            this.Qlb = new System.Windows.Forms.LinkLabel();
            this.Btn_Thanks = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // llab
            // 
            this.llab.AutoSize = true;
            this.llab.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.llab.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llab.Location = new System.Drawing.Point(190, 14);
            this.llab.Name = "llab";
            this.llab.Size = new System.Drawing.Size(214, 17);
            this.llab.TabIndex = 1;
            this.llab.TabStop = true;
            this.llab.Text = "“起点10”http://www.qidian10.com";
            this.llab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llab_LinkClicked);
            // 
            // emaillb
            // 
            this.emaillb.AutoSize = true;
            this.emaillb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emaillb.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.emaillb.Location = new System.Drawing.Point(190, 67);
            this.emaillb.Name = "emaillb";
            this.emaillb.Size = new System.Drawing.Size(204, 17);
            this.emaillb.TabIndex = 2;
            this.emaillb.TabStop = true;
            this.emaillb.Text = "Email：ovenjackchain@gmail.com";
            // 
            // Qlb
            // 
            this.Qlb.AutoSize = true;
            this.Qlb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Qlb.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.Qlb.Location = new System.Drawing.Point(190, 41);
            this.Qlb.Name = "Qlb";
            this.Qlb.Size = new System.Drawing.Size(103, 17);
            this.Qlb.TabIndex = 3;
            this.Qlb.TabStop = true;
            this.Qlb.Text = "QQ：710782046";
            this.Qlb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Qlb_LinkClicked);
            // 
            // Btn_Thanks
            // 
            this.Btn_Thanks.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Thanks.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Btn_Thanks.ForeColor = System.Drawing.Color.Navy;
            this.Btn_Thanks.Location = new System.Drawing.Point(193, 98);
            this.Btn_Thanks.Name = "Btn_Thanks";
            this.Btn_Thanks.Size = new System.Drawing.Size(252, 25);
            this.Btn_Thanks.TabIndex = 5;
            this.Btn_Thanks.Text = "Thank You！";
            this.Btn_Thanks.UseVisualStyleBackColor = true;
            this.Btn_Thanks.Click += new System.EventHandler(this.Btn_Thanks_Click);
            // 
            // AboutAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 128);
            this.Controls.Add(this.Btn_Thanks);
            this.Controls.Add(this.Qlb);
            this.Controls.Add(this.emaillb);
            this.Controls.Add(this.llab);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutAuthor";
            this.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于作者|非常感谢您的支持^_^";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel llab;
        private System.Windows.Forms.LinkLabel emaillb;
        private System.Windows.Forms.LinkLabel Qlb;
        private System.Windows.Forms.Button Btn_Thanks;

    }
}
