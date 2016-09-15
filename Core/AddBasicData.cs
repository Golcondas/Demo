using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using CJ_DBOperater;

/*
 * 陈杰
 * 2009-11-9
 * 添加基础数据
 */
namespace Core
{
    public class AddBasicData
    {
        public string InsertBasicData(ArrayList list, string dbname)
        {
            try
            {
                string DBType = "";
                CJ.oleDbconn_str = Cmds.AccessConnString;
                DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindDBConn, dbname));
                if (dt.Rows.Count > 0)
                {
                    DBType = dt.Rows[0]["DBType"].ToString();
                }
                if (DBType == "SQLServer2005")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        CJ.SQL_ExecuteNonQuery(list[i].ToString());
                    }
                    //执行基础数据插入
                    CJ.SQL_ExecuteNonQuery(Cmds.SQLBaiscUserInfo);
                }
                if (DBType == "Oracle")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        CJ.Oracle_ExecuteNonQuery(list[i].ToString());
                    }
                    //执行基础数据插入
                    CJ.Oracle_ExecuteNonQuery(Cmds.OracleBasicData);
                }
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //后台速成
        public string InsertBasicData(string dbtype, ArrayList list)
        {
            try
            {
                if (dbtype == "SQLServer2005")
                {
                    CJ.SQL_ExecuteNonQuery(Cmds.BasicData_MSSQLServer);
                    for (int i = 0; i < list.Count; i++)
                        CJ.SQL_ExecuteNonQuery(string.Format(Cmds.AutoMenu, "3" + i.ToString(), list[i].ToString().ToLower(), list[i].ToString()));
                    CJ.SQL_ExecuteNonQuery(Cmds.SQLBaiscUserInfo);
                }
                else if (dbtype == "Oracle")
                {
                    CJ.Oracle_ExecuteNonQuery("BEGIN "+Cmds.BasicData_MSSQLServer+" END;");
                    for (int i = 0; i < list.Count; i++)
                        CJ.Oracle_ExecuteNonQuery(string.Format(Cmds.AutoMenu, "3" + i.ToString(), list[i].ToString().ToLower(), list[i].ToString()));
                    CJ.Oracle_ExecuteNonQuery(Cmds.OracleBasicData);
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
