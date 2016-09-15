using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using CJ_DBOperater;


/*
 * 陈杰
 * 2009-11-9
 * 创建数据操作层实体 
 */
namespace Core
{
    public class CreateDao
    {
        public string BuildDaoAndInterface(string path, string dbname)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindAllTables, dbname));
                string dbtype = "SQLServer2005";
                if (dt.Rows.Count > 0)
                    dbtype = dt.Rows[0]["DBType"].ToString();
                StringBuilder IDaocsproj = new StringBuilder();//插入到csproj
                IDaocsproj.AppendLine();
                StringBuilder Daocsproj = new StringBuilder();//插入到csproj
                Daocsproj.AppendLine();
                string IDao_str = FileOperator.ReadFile(".\\WebBasic\\I{tablename}Dao.cs");
                string Dao_str ="";
                if(dbtype=="SQLServer2005")
                    Dao_str = FileOperator.ReadFile(".\\WebBasic\\{tablename}Dao.cs");
                else if(dbtype=="Oracle")
                    Dao_str = FileOperator.ReadFile(".\\WebBasic\\oracle{tablename}Dao.cs");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tablename = dt.Rows[i]["TableName"].ToString();
                    string autoID = "";
                    DataTable dtautoID = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindAutoID, tablename, dbname));
                    if (dtautoID.Rows.Count > 0)
                        autoID = dtautoID.Rows[0][0].ToString().ToLower();
                    IDaocsproj.AppendLine(string.Format("\t"+Cmds.CSproj, "I" + tablename.ToLower() + "Dao"));
                    Daocsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Dao"));
                    FileOperator.WriteFile(path + "IDAO\\" + "I" + tablename.ToLower() + "Dao.cs", IDao_str.Replace("{tablename}", tablename.ToLower()));
                    FileOperator.WriteFile(path + "DAO\\" + tablename.ToLower() + "Dao.cs", Dao_str.Replace("{tablename}", tablename.ToLower()).Replace("{tablename_AutoId}", autoID));
                }
                FileOperator.WriteFile(path + "IDAO\\IDAO.csproj", FileOperator.ReadFile(path + "IDAO\\IDAO.csproj").Replace("{IDAOInsertPoint}", IDaocsproj.ToString()));
                FileOperator.WriteFile(path + "DAO\\DAO.csproj", FileOperator.ReadFile(path + "DAO\\DAO.csproj").Replace("{DAOInsertPoint}", Daocsproj.ToString()));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        /// <summary>
        /// 二次开发助理  Dao生成,重载
        /// </summary>
        /// <param name="path">源文件路径</param>
        /// <param name="tablelist">要操作的表</param>
        /// <param name="dbtype">数据库类型</param>
        /// <returns></returns>
        public string BuildDaoAndInterface(string path,ArrayList tablelist, string dbtype)
        {
            try
            {
                string IDao_str = FileOperator.ReadFile(".\\WebBasic\\I{tablename}Dao.cs");
                string Dao_str ="";
                if (dbtype == "SQLServer2005")
                    Dao_str = FileOperator.ReadFile(".\\WebBasic\\{tablename}Dao.cs");
                else if (dbtype == "Oracle")
                    Dao_str = FileOperator.ReadFile(".\\WebBasic\\oracle{tablename}Dao.cs");
                StringBuilder IDaocsproj = new StringBuilder();//插入到csproj
                IDaocsproj.AppendLine();
                StringBuilder Daocsproj = new StringBuilder();//插入到csproj
                Daocsproj.AppendLine();
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    string AutoID = "";
                    if (dbtype == "SQLServer2005")
                    {
                        DataTable dtautoid = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindAutoID, tablename));
                        if (dtautoid.Rows.Count > 0)
                            AutoID = dtautoid.Rows[0][0].ToString();
                        else
                            AutoID = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindTableStructs, tablename)).Rows[0][0].ToString();
                    }
                    else if (dbtype == "Oracle")
                    {
                        AutoID = CJ.Oracle_ReturnDataTable(string.Format(Cmds.OracleFindTalbeStructs, tablename.ToUpper())).Rows[0]["FieldName"].ToString();
                    }
                    IDaocsproj.AppendLine(string.Format("\t" + Cmds.CSproj, "I" + tablename.ToLower() + "Dao"));
                    Daocsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Dao"));
                    FileOperator.WriteFile(path + "\\IDAO\\I" + tablename.ToLower() + "Dao.cs", IDao_str.Replace("{tablename}", tablename.ToLower()));
                    FileOperator.WriteFile(path + "\\DAO\\" + tablename.ToLower() + "Dao.cs", Dao_str.Replace("{tablename}", tablename.ToLower()).Replace("{tablename_AutoId}", AutoID));
                }
                FileOperator.WriteFile(path + "\\IDAO\\IDAO.csproj", FileOperator.ReadFile(path + "\\IDAO\\IDAO.csproj").Replace("<!--DHELPERIDAO-->", IDaocsproj.ToString()+"<!--DHELPERIDAO-->"));
                FileOperator.WriteFile(path + "\\DAO\\DAO.csproj", FileOperator.ReadFile(path + "\\DAO\\DAO.csproj").Replace("<!--DHELPERDAO-->", Daocsproj.ToString()+"<!--DHELPERDAO-->"));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //后台速成
        public string BuildDaoAndInterface(ArrayList tablelist, string path, string dbtype)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                StringBuilder IDaocsproj = new StringBuilder();//插入到csproj
                IDaocsproj.AppendLine();
                StringBuilder Daocsproj = new StringBuilder();//插入到csproj
                Daocsproj.AppendLine();
                string IDao_str = FileOperator.ReadFile(".\\WebBasic\\I{tablename}Dao.cs");
                string Dao_str = "";
                if (dbtype == "SQLServer2005")
                    Dao_str = FileOperator.ReadFile(".\\WebBasic\\{tablename}Dao.cs");
                else if (dbtype == "Oracle")
                    Dao_str = FileOperator.ReadFile(".\\WebBasic\\oracle{tablename}Dao.cs");
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    string AutoID = "";
                    DataTable dtautoid = null;
                    if (dbtype == "SQLServer2005")
                    {
                        dtautoid = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindAutoID, tablename));
                        if (dtautoid.Rows.Count > 0)
                            AutoID = dtautoid.Rows[0][0].ToString();
                        else
                            AutoID = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindTableStructs, tablename)).Rows[0][0].ToString();
                    }
                    else if (dbtype == "Oracle")
                    {
                        AutoID = CJ.Oracle_ReturnDataTable(string.Format(Cmds.OracleFindTalbeStructs, tablename.ToUpper())).Rows[0]["FieldName"].ToString();
                    }
                    
                    IDaocsproj.AppendLine(string.Format("\t" + Cmds.CSproj, "I" + tablename.ToLower() + "Dao"));
                    Daocsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Dao"));
                    FileOperator.WriteFile(path + "IDAO\\" + "I" + tablename.ToLower() + "Dao.cs", IDao_str.Replace("{tablename}", tablename.ToLower()));
                    FileOperator.WriteFile(path + "DAO\\" + tablename.ToLower() + "Dao.cs", Dao_str.Replace("{tablename}", tablename.ToLower()).Replace("{tablename_AutoId}", AutoID));
                }
                FileOperator.WriteFile(path + "IDAO\\IDAO.csproj", FileOperator.ReadFile(path + "IDAO\\IDAO.csproj").Replace("{IDAOInsertPoint}", IDaocsproj.ToString()));
                FileOperator.WriteFile(path + "DAO\\DAO.csproj", FileOperator.ReadFile(path + "DAO\\DAO.csproj").Replace("{DAOInsertPoint}", Daocsproj.ToString()));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
