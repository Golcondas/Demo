using System;
using System.Text;
using System.Data;
using CJ_DBOperater;
using Core;
using System.Collections;

namespace SampleThreeCore
{
    public class CreateControllers
    {
        public string BuildController(string path, string dbname)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindAllTables, dbname));
                StringBuilder Controllercsproj = new StringBuilder();//插入到csproj
                Controllercsproj.AppendLine();
                string Controller_str = FileOperator.ReadFile(".\\WebBasic\\{S_tablename}Controller.cs");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tablename = dt.Rows[i]["TableName"].ToString();
                    Controllercsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Controller"));
                    FileOperator.WriteFile(path + "Controllers\\" + tablename.ToLower() + "Controller.cs", Controller_str.Replace("{tablename}", tablename.ToLower()));
                }
                FileOperator.WriteFile(path + "Controllers\\Controllers.csproj", FileOperator.ReadFile(path + "Controllers\\Controllers.csproj").Replace("{ControllerInsertPoint}", Controllercsproj.ToString()));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //后台速成
        public string BuildController(ArrayList tablelist, string path)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                StringBuilder Controllercsproj = new StringBuilder();//插入到csproj
                Controllercsproj.AppendLine();
                string Controller_str = FileOperator.ReadFile(".\\WebBasic\\{S_tablename}Controller.cs");
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    Controllercsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Controller"));
                    FileOperator.WriteFile(path + "Controllers\\" + tablename.ToLower() + "Controller.cs", Controller_str.Replace("{tablename}", tablename.ToLower()));
                }
                FileOperator.WriteFile(path + "Controllers\\Controllers.csproj", FileOperator.ReadFile(path + "Controllers\\Controllers.csproj").Replace("{ControllerInsertPoint}", Controllercsproj.ToString()));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //二次开发页面 生成controller，重载
        public string BuildController(string path, ArrayList tablelist)
        {
            try
            {
                string Controller_str = FileOperator.ReadFile(".\\WebBasic\\{S_tablename}Controller.cs");
                StringBuilder Controllercsproj = new StringBuilder();//插入到csproj
                Controllercsproj.AppendLine();
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    Controllercsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Controller"));
                    FileOperator.WriteFile(path + "\\Controllers\\" + tablename.ToLower() + "Controller.cs", Controller_str.Replace("{tablename}", tablename.ToLower()));
                }
                FileOperator.WriteFile(path + "\\Controllers\\Controllers.csproj", FileOperator.ReadFile(path + "\\Controllers\\Controllers.csproj").Replace("<!--DHELPERCONTROLLER-->", Controllercsproj.ToString() + "<!--DHELPERCONTROLLER-->"));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
