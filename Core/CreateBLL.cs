using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using CJ_DBOperater;

/*
 * 陈杰
 * 2009-11-9
 * 创建业务层实体 
 */
namespace Core
{
    public class CreateBLL
    {
        public string BuildBLL(string path, string dbname)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                //找到库中所有的表,生成实体类和Hbm配置文件
                DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindAllTables, dbname));
                StringBuilder IBLLcsproj = new StringBuilder();//插入到csproj
                IBLLcsproj.AppendLine();
                StringBuilder BLLcsproj = new StringBuilder();//插入到csproj
                BLLcsproj.AppendLine();
                string IBLL_str = FileOperator.ReadFile(".\\WebBasic\\I{tablename}Mgr.cs");
                string BLL_str = FileOperator.ReadFile(".\\WebBasic\\{tablename}Mgr.cs");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tablename = dt.Rows[i]["TableName"].ToString();
                    IBLLcsproj.AppendLine(string.Format("\t" + Cmds.CSproj, "I" + tablename.ToLower() + "Mgr"));
                    BLLcsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Mgr"));
                    FileOperator.WriteFile(path + "IBLL\\" + "I" + tablename.ToLower() + "Mgr.cs", IBLL_str.Replace("{tablename}", tablename.ToLower()));
                    FileOperator.WriteFile(path + "BLL\\" + tablename.ToLower() + "Mgr.cs", BLL_str.Replace("{tablename}", tablename.ToLower()));
                }
                FileOperator.WriteFile(path + "IBLL\\IBLL.csproj", FileOperator.ReadFile(path + "IBLL\\IBLL.csproj").Replace("{IBLLInsertPoint}", IBLLcsproj.ToString()));
                FileOperator.WriteFile(path + "BLL\\BLL.csproj", FileOperator.ReadFile(path + "BLL\\BLL.csproj").Replace("{BLLInsertPoint}", BLLcsproj.ToString()));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        //开发助理页面，重载
        public string BuildBLL(string path,ArrayList tablelist)
        {
            try
            {
                string IBLL_str = FileOperator.ReadFile(".\\WebBasic\\I{tablename}Mgr.cs");
                string BLL_str = FileOperator.ReadFile(".\\WebBasic\\{tablename}Mgr.cs");
                StringBuilder IBLLcsproj = new StringBuilder();//插入到csproj
                IBLLcsproj.AppendLine();
                StringBuilder BLLcsproj = new StringBuilder();//插入到csproj
                BLLcsproj.AppendLine();
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    IBLLcsproj.AppendLine(string.Format("\t" + Cmds.CSproj, "I" + tablename.ToLower() + "Mgr"));
                    BLLcsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Mgr"));
                    FileOperator.WriteFile(path + "\\IBLL\\I" + tablename.ToLower() + "Mgr.cs", IBLL_str.Replace("{tablename}", tablename.ToLower()));
                    FileOperator.WriteFile(path + "\\BLL\\" + tablename.ToLower() + "Mgr.cs", BLL_str.Replace("{tablename}", tablename.ToLower()));
                }
                FileOperator.WriteFile(path + "\\IBLL\\IBLL.csproj", FileOperator.ReadFile(path + "\\IBLL\\IBLL.csproj").Replace("<!--DHELPERIBLL-->", IBLLcsproj.ToString()+"<!--DHELPERIBLL-->"));
                FileOperator.WriteFile(path + "\\BLL\\BLL.csproj", FileOperator.ReadFile(path + "\\BLL\\BLL.csproj").Replace("<!--DHELPERBLL-->", BLLcsproj.ToString()+"<!--DHELPERBLL-->"));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //后台速成
        public string BuildBLL(ArrayList tablelist,string path)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                //找到库中所有的表,生成实体类和Hbm配置文件
                StringBuilder IBLLcsproj = new StringBuilder();//插入到csproj
                IBLLcsproj.AppendLine();
                StringBuilder BLLcsproj = new StringBuilder();//插入到csproj
                BLLcsproj.AppendLine();
                string IBLL_str = FileOperator.ReadFile(".\\WebBasic\\I{tablename}Mgr.cs");
                string BLL_str = FileOperator.ReadFile(".\\WebBasic\\{tablename}Mgr.cs");
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    IBLLcsproj.AppendLine(string.Format("\t" + Cmds.CSproj, "I" + tablename.ToLower() + "Mgr"));
                    BLLcsproj.AppendLine(string.Format("\t" + Cmds.CSproj, tablename.ToLower() + "Mgr"));
                    FileOperator.WriteFile(path + "IBLL\\" + "I" + tablename.ToLower() + "Mgr.cs", IBLL_str.Replace("{tablename}", tablename.ToLower()));
                    FileOperator.WriteFile(path + "BLL\\" + tablename.ToLower() + "Mgr.cs", BLL_str.Replace("{tablename}", tablename.ToLower()));
                }

                FileOperator.WriteFile(path + "IBLL\\IBLL.csproj", FileOperator.ReadFile(path + "IBLL\\IBLL.csproj").Replace("{IBLLInsertPoint}", IBLLcsproj.ToString()));
                FileOperator.WriteFile(path + "BLL\\BLL.csproj", FileOperator.ReadFile(path + "BLL\\BLL.csproj").Replace("{BLLInsertPoint}", BLLcsproj.ToString()));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

    }
}
