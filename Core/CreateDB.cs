using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CJ_DBOperater;

/*
 * 陈杰
 * 2009-11-9
 * 创建数据库 
 */
namespace Core
{
   public class CreateDB
    {
        public string CreateDataBase(string dbname)
        {
            try
            {
                string DBType = "",DBConnString="";
                CJ.oleDbconn_str = Cmds.AccessConnString;
                DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindDBConn,dbname));
                if (dt.Rows.Count > 0)
                {
                    DBType = dt.Rows[0]["DBType"].ToString();
                    DBConnString = dt.Rows[0]["DBConnString"].ToString();
                }
                if (DBType == "SQLServer2005")
                {
                    //新建数据库
                    CJ.sqlconn_str = DBConnString + "DataBase=master;";
                    CJ.SQL_ExecuteNonQuery(string.Format(Cmds.CreateDB,dbname));
                }
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
