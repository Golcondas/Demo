using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CJ_DBOperater;
using System.Windows.Forms;

namespace WebMisDeveloper
{
    class DBConnTest
    {
        //测试数据库连接
        public void DBConnTry(string Type, string connstr)
        {
            if (Type == "SQLServer2005" || Type == "SQLServer2000")
            {
                //SQLServer
                CJ.sqlconn_str = connstr;
                try
                {
                    CJ.SqlConnFun();
                    MessageBox.Show("连接成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("连接失败，请检查连接串！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (Type == "Oracle")
            {
                //Oracle
                CJ.oracleconn_str = connstr;
                try
                {
                    CJ.OracleConnFun();
                    MessageBox.Show("连接成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("连接失败，请检查连接串！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (Type == "Access")
            {
                //Access
                CJ.oleDbconn_str = connstr;
                try
                {
                    CJ.AccessConnFun();
                    MessageBox.Show("连接成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("连接失败，请检查连接串！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
