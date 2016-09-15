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
    public partial class TableInfo : Form
    {
        string tablename = ""; //表名字
        string dbname = ""; //数据库名字
        DataGridView DGV = null;//获得上级datagridview，更新表
        GroupBox GB = null;//获得上级传来的groupbox，更新表个数
        string dbtype = "";//数据库类型，根据不同数据库加载不同数据类型
        public TableInfo(string dbtype,string dbn, string tn,DataGridView dgv,GroupBox gb)
        {
            InitializeComponent();
            tablename = tn;
            dbname = dbn;
            DGV = dgv;
            GB = gb;
            this.dbtype = dbtype;
        }
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (CheckData() == false)
                return;
            CJ.OtherDB_ExevuteNonQuery(string.Format(Cmds.DelTableColumn, tablename, dbname));//删除旧表
            foreach (DataGridViewRow row in DGV_Table.Rows)
            {
                if (row.IsNewRow == false)//排除最后一行
                {
                        string cname = row.Cells["ColumnName"].Value.ToString();
                        string ctype = row.Cells["ColumnType"].Value.ToString();
                        string csize = "";
                        if (ctype == "int" || ctype == "Text" || ctype == "DateTime" || ctype == "clob" || ctype == "date")
                            csize = "";
                        else
                            csize = row.Cells["ColumnSize"].Value.ToString();
                        if (ctype == "date")
                        { ctype = "varchar2"; csize = "30"; }
                        string cdesc = row.Cells["ColumnDesc"].Value.ToString();
                        string cISPK = row.Cells["ColumnPrimaryKey"].FormattedValue.ToString();
                        CJ.OtherDB_ExevuteNonQuery(string.Format(Cmds.AddNewTableColumn, dbname, tablename.ToLower(), cname.ToLower(), ctype, csize, cdesc, cISPK));
                }
            }
            DGV.DataSource = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindDBTables, dbname));
            GB.Text = dbname + "数据库已存在表 共:" + DGV.Rows.Count.ToString() + "张";
            this.Close();
        }
        //判断是否满足条件
        private bool CheckData()
        {
            tablename = Txt_TName.Text.Trim();
            if (tablename.Length <= 0)
            {
                MessageBox.Show("请您先输入表名！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (DGV_Table.Rows.Count <= 3)
            {
                MessageBox.Show("请确保表字段必须大于3个，并且最好第三个字段能用来分组！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (DGV_Table.Rows.Count > 2)
            {
                //从DataGridView里面读取数据
                foreach (DataGridViewRow row in DGV_Table.Rows)
                {
                    if (row.IsNewRow == false)//排除最后一行
                    {
                        try
                        {
                            if (row.Index == 0 && row.Cells["ColumnType"].Value.ToString() != "int")
                            {
                                MessageBox.Show("第一列必须为int的自动增长字段！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return false;
                            }
                            string cname = row.Cells["ColumnName"].Value.ToString();
                            string ctype = row.Cells["ColumnType"].Value.ToString();
                            string csize = "255";
                            if (ctype == "int" || ctype == "Text" || ctype == "DateTime" || ctype == "clob" || ctype == "date")
                                csize = "";
                            else
                                csize = row.Cells["ColumnSize"].Value.ToString();
                            string cdesc = row.Cells["ColumnDesc"].Value.ToString();
                            string cISPK = row.Cells["ColumnPrimaryKey"].FormattedValue.ToString();
                            if (cname.Length <= 0 || ctype.Length <= 0 || cdesc.Length <= 0)
                            {
                                MessageBox.Show("您的信息不合法，无法存储！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return false;
                            }
                            else
                            {
                                try
                                {
                                    //判断字段大小是否合法
                                    if (ctype == "int" || ctype == "Text" || ctype == "DateTime" || ctype == "clob" || ctype == "date")
                                    {
                                    }
                                    else
                                    {
                                        int size = int.Parse(csize);
                                        if (size <= 0)
                                        {
                                            MessageBox.Show("第" + (row.Index + 1).ToString() + "行，字段大小不合法，无法存储！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            return false;
                                        }
                                        else if (ctype.ToLower() == "char" && size > 2000)
                                        {
                                            MessageBox.Show("第" + (row.Index + 1).ToString() + "行，char字段大小不合法，无法存储！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            return false;
                                        }
                                        else if ((ctype.ToLower() == "nvarchar" || ctype.ToLower() == "varchar2") && size > 4000)
                                        {
                                            MessageBox.Show("第" + (row.Index + 1).ToString() + "行，nvarchar字段大小不合法，无法存储！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            return false;
                                        }
                                        else if (ctype.ToLower() == "varchar" && size > 8000)
                                        {
                                            MessageBox.Show("第" + (row.Index + 1).ToString() + "行，varchar字段大小不合法，无法存储！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            return false;
                                        }
                                    }
                                }
                                catch(Exception error)
                                {
                                    MessageBox.Show((row.Index + 1).ToString() + "行，字段不合法，无法存储！\r\nError:" + error.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return false;
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("您的信息不合法，无法存储！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }
                    }
                }
                this.DialogResult = DialogResult.OK;
                return true;
            }
            else
            {
                MessageBox.Show("找不到记录，无法存储！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }
        //窗体加载时
        private void TableInfo_Load(object sender, EventArgs e)
        {
            if (tablename != "")
            {
                DGV_Table.DataSource = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindTableInfo, tablename, dbname));
                Txt_TName.Text = tablename;
                Txt_TName.Enabled = false;
            }
            if (dbtype == "Oracle")
            {
                DataGridViewComboBoxColumn Fieldtype = DGV_Table.Columns[1] as DataGridViewComboBoxColumn;
                Fieldtype.Items.Clear();
                Fieldtype.Items.Add("int");
                Fieldtype.Items.Add("char");
                Fieldtype.Items.Add("varchar2");
                Fieldtype.Items.Add("clob");
                Fieldtype.Items.Add("date");
            }
            else if (dbtype == "Access")
            {

            }
        }

        //删除选择行
        private void CMenu_Del_Click(object sender, EventArgs e)
        {
            try
            {
                DGV_Table.Rows.Remove(DGV_Table.CurrentRow);
            }
            catch
            {
                MessageBox.Show("请选择要删除的行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DGV_Table_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DGV_Table.RowHeadersWidth = 50;
            DGV_Table.TopLeftHeaderCell.Value = "序号";
            int r = DGV_Table.Rows.Count;
            for (int i = 1; i <= r; i++)
                DGV_Table.Rows[i - 1].HeaderCell.Value = i.ToString();
        }
    }
}
