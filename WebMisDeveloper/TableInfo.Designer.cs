namespace WebMisDeveloper
{
    partial class TableInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableInfo));
            this.DGV_Table = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrimaryKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMenu_Del = new System.Windows.Forms.ToolStripMenuItem();
            this.Txt_TName = new System.Windows.Forms.TextBox();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.header1 = new Gui.Wizard.Header();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Table)).BeginInit();
            this.CMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_Table
            // 
            this.DGV_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnType,
            this.ColumnSize,
            this.ColumnDesc,
            this.ColumnPrimaryKey});
            this.DGV_Table.ContextMenuStrip = this.CMenu;
            this.DGV_Table.Location = new System.Drawing.Point(12, 76);
            this.DGV_Table.MultiSelect = false;
            this.DGV_Table.Name = "DGV_Table";
            this.DGV_Table.RowTemplate.Height = 23;
            this.DGV_Table.Size = new System.Drawing.Size(523, 271);
            this.DGV_Table.TabIndex = 1;
            this.DGV_Table.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DGV_Table_RowsAdded);
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "FieldName";
            this.ColumnName.HeaderText = "列名";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnType
            // 
            this.ColumnType.DataPropertyName = "FieldType";
            this.ColumnType.HeaderText = "类型";
            this.ColumnType.Items.AddRange(new object[] {
            "int",
            "nvarchar",
            "varchar",
            "DateTime",
            "Text"});
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnSize
            // 
            this.ColumnSize.DataPropertyName = "FieldSize";
            this.ColumnSize.HeaderText = "大小";
            this.ColumnSize.Name = "ColumnSize";
            this.ColumnSize.ToolTipText = "0-255";
            this.ColumnSize.Width = 60;
            // 
            // ColumnDesc
            // 
            this.ColumnDesc.DataPropertyName = "FieldDesc";
            this.ColumnDesc.HeaderText = "描述";
            this.ColumnDesc.Name = "ColumnDesc";
            this.ColumnDesc.Width = 120;
            // 
            // ColumnPrimaryKey
            // 
            this.ColumnPrimaryKey.DataPropertyName = "ISPrimaryKey";
            this.ColumnPrimaryKey.FalseValue = "false";
            this.ColumnPrimaryKey.HeaderText = "是否主键";
            this.ColumnPrimaryKey.Name = "ColumnPrimaryKey";
            this.ColumnPrimaryKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrimaryKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnPrimaryKey.TrueValue = "true";
            // 
            // CMenu
            // 
            this.CMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMenu_Del});
            this.CMenu.Name = "CMenu";
            this.CMenu.Size = new System.Drawing.Size(95, 26);
            // 
            // CMenu_Del
            // 
            this.CMenu_Del.Name = "CMenu_Del";
            this.CMenu_Del.Size = new System.Drawing.Size(94, 22);
            this.CMenu_Del.Text = "删除";
            this.CMenu_Del.Click += new System.EventHandler(this.CMenu_Del_Click);
            // 
            // Txt_TName
            // 
            this.Txt_TName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_TName.Location = new System.Drawing.Point(14, 30);
            this.Txt_TName.Name = "Txt_TName";
            this.Txt_TName.Size = new System.Drawing.Size(137, 21);
            this.Txt_TName.TabIndex = 2;
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Save.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Save.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Btn_Save.Location = new System.Drawing.Point(541, 260);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(162, 38);
            this.Btn_Save.TabIndex = 4;
            this.Btn_Save.Text = "保 存";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Cancel.Location = new System.Drawing.Point(541, 309);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(162, 38);
            this.Btn_Cancel.TabIndex = 5;
            this.Btn_Cancel.Text = "取 消";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Txt_TName);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(541, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 178);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请输入表名称";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(14, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 106);
            this.label1.TabIndex = 3;
            this.label1.Text = "    请确保您的表名不同于userfun、roles、rolefun、userinfo，\r\n这四张基本表，系统会自行创建。\r\n    请确保您的表属性名称不是S" +
                "QL的关键字，否则表将创建失败。";
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.SystemColors.Control;
            this.header1.CausesValidation = false;
            this.header1.Description = "注意：表的第一列必须为int的自增字段，表描述字段不能为空，否则Extjs文件将不能识别列。您无需创建 角色表、模块表、角色权限表、信息发布表，这些表系统将自动创" +
                "建";
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Image = ((System.Drawing.Image)(resources.GetObject("header1.Image")));
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(715, 64);
            this.header1.TabIndex = 0;
            this.header1.Title = "新建/修改 表信息";
            // 
            // TableInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 361);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.DGV_Table);
            this.Controls.Add(this.header1);
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TableInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "起点10--WebMis数据库表信息";
            this.Load += new System.EventHandler(this.TableInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Table)).EndInit();
            this.CMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Header header1;
        private System.Windows.Forms.DataGridView DGV_Table;
        private System.Windows.Forms.TextBox Txt_TName;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDesc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnPrimaryKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip CMenu;
        private System.Windows.Forms.ToolStripMenuItem CMenu_Del;
    }
}