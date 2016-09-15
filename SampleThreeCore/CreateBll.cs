using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CJ_DBOperater;
using Core;
using System.Collections;

namespace SampleThreeCore
{
    public class CreateBll
    {
        public string BuildBLL(string path, string dbname)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindAllTables, dbname));
                StringBuilder BLLcsproj = new StringBuilder();//插入到csproj
                BLLcsproj.AppendLine();
                string BLL_str = FileOperator.ReadFile(".\\WebBasic\\{S_tablename}Mgr.cs");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tablename = dt.Rows[i]["TableName"].ToString();
                    BLLcsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Mgr"));
                    FileOperator.WriteFile(path + "BLL\\" + tablename.ToLower() + "Mgr.cs", BLL_str.Replace("{tablename}", tablename.ToLower()));
                }
                FileOperator.WriteFile(path + "BLL\\BLL.csproj", FileOperator.ReadFile(path + "BLL\\BLL.csproj").Replace("{BLLInsertPoint}", BLLcsproj.ToString()));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        //后台速成
        public string BuildBLL(ArrayList tablelist, string path)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                StringBuilder BLLcsproj = new StringBuilder();//插入到csproj
                BLLcsproj.AppendLine();
                string BLL_str = FileOperator.ReadFile(".\\WebBasic\\{S_tablename}Mgr.cs");
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    BLLcsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Mgr"));
                    FileOperator.WriteFile(path + "BLL\\" + tablename.ToLower() + "Mgr.cs", BLL_str.Replace("{tablename}", tablename.ToLower()));
                }
                FileOperator.WriteFile(path + "BLL\\BLL.csproj", FileOperator.ReadFile(path + "BLL\\BLL.csproj").Replace("{BLLInsertPoint}", BLLcsproj.ToString()));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        //开发助理页面，重载
        public string BuildBLL(string path, ArrayList tablelist)
        {
            try
            {
                string BLL_str = FileOperator.ReadFile(".\\WebBasic\\{S_tablename}Mgr.cs");
                StringBuilder BLLcsproj = new StringBuilder();//插入到csproj
                BLLcsproj.AppendLine();
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    BLLcsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Mgr"));
                    FileOperator.WriteFile(path + "\\BLL\\" + tablename.ToLower() + "Mgr.cs", BLL_str.Replace("{tablename}", tablename.ToLower()));
                }
                FileOperator.WriteFile(path + "\\BLL\\BLL.csproj", FileOperator.ReadFile(path + "\\BLL\\BLL.csproj").Replace("<!--DHELPERBLL-->", BLLcsproj.ToString() + "<!--DHELPERBLL-->"));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
