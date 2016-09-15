using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CJ_DBOperater;
using Core;
using System.IO;

namespace ExtNetAutoCore
{
    public class CreateRelation
    {
        public string BuildRelationShip(string path, string dbname)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                string DBType = "", DBConnection = "";
                DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindAllTables, dbname));
                if (dt.Rows.Count > 0)
                {
                    DBType = dt.Rows[0]["DBType"].ToString();
                    if (DBType == "SQLServer2005")
                        DBConnection = dt.Rows[0]["DBConnString"].ToString() + "DataBase=" + dbname + ";";
                    else if (DBType == "Oracle")
                        DBConnection = dt.Rows[0]["DBConnString"].ToString();
                }
                FileOperator.WriteFile(path + "\\Web\\web.config", FileOperator.ReadFile(path + "\\Web\\web.config").Replace("{DBConnectString}", DBConnection));
                if (Directory.Exists(".\\WebBasic\\EF"))
                {
                    File.Delete(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx.designer.cs");
                    File.Delete(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx.cs");
                    File.Delete(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx");
                    File.Delete(".\\WebBasic\\EF\\{tablename}Dao.cs");
                    File.Delete(".\\WebBasic\\EF\\{tablename}.cs");
                    File.Delete(".\\WebBasic\\EF\\{tablename}Mgr.cs");
                    Directory.Delete(".\\WebBasic\\EF\\{tablename}Menu", true);
                    Directory.Delete(".\\WebBasic\\EF",true);
                }
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //二次开发
        public string DelFiles()
        {
            try
            {
                if (Directory.Exists(".\\WebBasic\\EF"))
                {
                    File.Delete(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx.designer.cs");
                    File.Delete(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx.cs");
                    File.Delete(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx");
                    File.Delete(".\\WebBasic\\EF\\{tablename}Dao.cs");
                    File.Delete(".\\WebBasic\\EF\\{tablename}.cs");
                    File.Delete(".\\WebBasic\\EF\\{tablename}Mgr.cs");
                    Directory.Delete(".\\WebBasic\\EF\\{tablename}Menu", true);
                    Directory.Delete(".\\WebBasic\\EF");
                }
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        //后台速成
        public string BuildRelationShip(string path)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                //开始替换
                FileOperator.WriteFile(path + "\\Web\\web.config", FileOperator.ReadFile(path + "\\Web\\web.config").Replace("{DBConnectString}", Core.Cmds.MSSQLConn));
                if (Directory.Exists(".\\WebBasic\\EF"))
                {
                    File.Delete(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx.designer.cs");
                    File.Delete(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx.cs");
                    File.Delete(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx");
                    File.Delete(".\\WebBasic\\EF\\{tablename}Dao.cs");
                    File.Delete(".\\WebBasic\\EF\\{tablename}.cs");
                    File.Delete(".\\WebBasic\\EF\\{tablename}Mgr.cs");
                    Directory.Delete(".\\WebBasic\\EF\\{tablename}Menu", true);
                    Directory.Delete(".\\WebBasic\\EF");
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
