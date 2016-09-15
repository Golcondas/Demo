using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Core;
using CJ_DBOperater;
using System.Collections;

namespace SampleThreeCore
{
    public class CreateDao
    {
        public string BuildDaos(string path, string dbname)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindAllTables, dbname));
                StringBuilder Daocsproj = new StringBuilder();//插入到csproj
                Daocsproj.AppendLine();
                string Dao_str = FileOperator.ReadFile(".\\WebBasic\\{S_tablename}Dao.cs");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tablename = dt.Rows[i]["TableName"].ToString();
                    Daocsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Dao"));
                    FileOperator.WriteFile(path + "DAO\\" + tablename.ToLower() + "Dao.cs", Dao_str.Replace("{tablename}", tablename.ToLower()));
                }
                FileOperator.WriteFile(path + "DAO\\DAO.csproj", FileOperator.ReadFile(path + "DAO\\DAO.csproj").Replace("{DAOInsertPoint}", Daocsproj.ToString()));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        //后台速成
        public string BuildDaos(ArrayList tablelist, string path, string dbtype)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                StringBuilder Daocsproj = new StringBuilder();//插入到csproj
                Daocsproj.AppendLine();
                string Dao_str = FileOperator.ReadFile(".\\WebBasic\\{S_tablename}Dao.cs");
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    Daocsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Dao"));
                    FileOperator.WriteFile(path + "DAO\\" + tablename.ToLower() + "Dao.cs", Dao_str.Replace("{tablename}", tablename.ToLower()));
                }
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
        public string BuildDaos(string path, ArrayList tablelist, string dbtype)
        {
            try
            {
                string Dao_str = FileOperator.ReadFile(".\\WebBasic\\{S_tablename}Dao.cs");
                StringBuilder Daocsproj = new StringBuilder();//插入到csproj
                Daocsproj.AppendLine();
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    Daocsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Dao"));
                    FileOperator.WriteFile(path + "\\DAO\\" + tablename.ToLower() + "Dao.cs", Dao_str.Replace("{tablename}", tablename.ToLower()));
                }
                FileOperator.WriteFile(path + "\\DAO\\DAO.csproj", FileOperator.ReadFile(path + "\\DAO\\DAO.csproj").Replace("<!--DHELPERDAO-->", Daocsproj.ToString() + "<!--DHELPERDAO-->"));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
