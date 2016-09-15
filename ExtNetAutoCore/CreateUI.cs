using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Collections;
using System.Data;
using CJ_DBOperater;
using System.IO;

namespace ExtNetAutoCore
{
    public class CreateUI
    {
        public string CreatePages(string path, ArrayList Menulist, string dbname)
        {
            try
            {
                string webprojpath = path + "\\WebMisDeveloper\\";
                path = path + "\\WebMisDeveloper\\Web\\View\\";
                StringBuilder webcsprojContent = new StringBuilder();
                webcsprojContent.AppendLine();
                StringBuilder WebCsproj = new StringBuilder();
                WebCsproj.AppendLine();
                StringBuilder MenuIcons = new StringBuilder();
                MenuIcons.AppendLine();

                for (int i = 0; i < Menulist.Count; i++)
                {
                    string tablename = Menulist[i].ToString().ToString();
                    //首先将添加到webcsrpoj
                    WebCsproj.AppendLine(string.Format(Cmds.WebCSProj, tablename));
                    webcsprojContent.AppendLine(string.Format(Cmds.WCSproj, tablename));
                    //添加菜单图片
                    MenuIcons.AppendLine(Cmds.MenuIcon.Replace("{0}",tablename));

                    //找到该表的结构
                    string sql = string.Format(Cmds.FindTableInfo, tablename, dbname);
                    DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindTableInfo, tablename, dbname));
                    int a = dt.Rows.Count;
                    //列试图
                    StringBuilder ColumnView = new StringBuilder();
                    ColumnView.AppendLine();
                    //Store的reader
                    StringBuilder Reader = new StringBuilder();
                    Reader.AppendLine();

                    string AutoID = "";
                    //赋值给窗体
                    StringBuilder SetWinValue = new StringBuilder();
                    SetWinValue.AppendLine();
                    //窗体的文本框，奇数偶数行
                    StringBuilder WinColumnJS = new StringBuilder();
                    WinColumnJS.AppendLine();
                    StringBuilder WinColumnOS = new StringBuilder();
                    WinColumnOS.AppendLine();
                    StringBuilder ColumnFilters = new StringBuilder();
                    ColumnFilters.AppendLine();
                    StringBuilder Designer = new StringBuilder();
                    Designer.AppendLine();
                    StringBuilder GetValue = new StringBuilder();
                    GetValue.AppendLine();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string cname = dt.Rows[j]["FieldName"].ToString().ToLower();
                        string cdesc = dt.Rows[j]["FieldDesc"].ToString();
                        string ctype = dt.Rows[j]["FieldType"].ToString();
                        Reader.AppendLine("\t\t\t\t\t" + string.Format(Cmds.StoreReader, cname));
                        if (j == 0)
                        {
                            AutoID = cname;
                        }
                        else
                        {
                            if (ctype == "int" || ctype == "number")
                            {
                                if (j % 2 == 0)
                                    WinColumnOS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.NumberField, "TxtNum" + cname, cdesc));
                                else
                                    WinColumnJS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.NumberField, "TxtNum" + cname, cdesc));
                                SetWinValue.AppendLine("\t\t\t"+string.Format(Cmds.WinSetValue, "TxtNum" + cname, tablename, cname));
                                Designer.AppendLine("\t\tprotected global::Ext.Net.NumberField TxtNum" + cname + ";");
                                GetValue.AppendLine("\t\t\t_" + tablename + "." + cname + " = int.Parse(TxtNum" + cname + ".Text.Trim());");
                            }
                            else if (ctype == "DateTime")
                            {
                                if (j % 2 == 0)
                                    WinColumnOS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.DateField, "TxtDate" + cname, cdesc));
                                else
                                    WinColumnJS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.DateField, "TxtDate" + cname, cdesc));
                                SetWinValue.AppendLine("\t\t\t" + string.Format(Cmds.WinSetValue, "TxtDate" + cname, tablename, cname));
                                Designer.AppendLine("\t\tprotected global::Ext.Net.DateField TxtDate" + cname + ";");
                                GetValue.AppendLine("\t\t\t_" + tablename + "." + cname + " = TxtDate" + cname + ".Text.Trim();");
                            }
                            else
                            {
                                if (j % 2 == 0)
                                    WinColumnOS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.TxtFields, "Txt" + cname, cdesc));
                                else
                                    WinColumnJS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.TxtFields, "Txt" + cname, cdesc));
                                SetWinValue.AppendLine("\t\t\t" + string.Format(Cmds.WinSetValue, "Txt" + cname, tablename, cname));
                                ColumnFilters.AppendLine("\t\t\t\t\t\t\t\t" + string.Format(Cmds.Filter, cname));
                                Designer.AppendLine("\t\tprotected global::Ext.Net.TextField Txt" + cname + ";");
                                GetValue.AppendLine("\t\t\t_" + tablename + "." + cname + " = Txt" + cname + ".Text.Trim();");
                            }
                            ColumnView.AppendLine("\t\t\t\t\t\t\t\t" + string.Format(Cmds.Columns, cdesc, cname));
                        }
                    }
                    if (!Directory.Exists(path + tablename + "Menu")) Directory.CreateDirectory(path + tablename + "Menu");

                    FileOperator.WriteFile(path + tablename + "Menu\\Default.aspx", FileOperator.ReadFile(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx")
                        .Replace("{title}", tablename)
                        .Replace("{tablename}", tablename)
                        .Replace("{PRIMARYKEY}", AutoID)
                        .Replace("{SETWINDATAFORSHOW}", SetWinValue.ToString())
                        .Replace("{STOREREADER}", Reader.ToString())
                        .Replace("{GRIDCLOLUMNS}", ColumnView.ToString())
                        .Replace("{GRIDFILTERS}", ColumnFilters.ToString())
                        .Replace("{JSTEXTBOX}", WinColumnJS.ToString())
                        .Replace("{OSTEXTBOX}", WinColumnOS.ToString())
                        .Replace("{HEIGHT}",((a/2+(a%2==0?0:1))*30).ToString()));
                    FileOperator.WriteFile(path + tablename + "Menu\\Default.aspx.cs", FileOperator.ReadFile(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx.cs")
                        .Replace("{tablename}", tablename)
                        .Replace("{PRIMARYKEY}", AutoID)
                        .Replace("{GATVALUE}", GetValue.ToString()));

                    FileOperator.WriteFile(path + tablename + "Menu\\Default.aspx.designer.cs", FileOperator.ReadFile(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx.designer.cs")
                        .Replace("{tablename}", tablename)
                        .Replace("{DESIGNERInserPoint}", Designer.ToString()));
                }
                FileOperator.WriteFile(path + "\\images\\Icons\\icon.css", FileOperator.ReadFile(path + "\\images\\Icons\\icon.css").Replace("/*ICONInsertPoint*/", MenuIcons + "\r\n/*ICONInsertPoint*/"));
                FileOperator.WriteFile(webprojpath + "\\Web\\Web.csproj", FileOperator.ReadFile(webprojpath + "\\Web\\Web.csproj").Replace("{WebInsertPoint}", WebCsproj.ToString()).Replace("{WebContent}",webcsprojContent.ToString()));
                return "OK";
            }
            catch (Exception err)
            {
                return err.Message.ToString();
            }
        }
        //二次开发，生成Extjs文件
        public string CreatePage(string path, ArrayList tablelist, string dbtype)
        {
            try
            {
                string webprojpath = path + "\\";
                path = path + "\\Web\\View\\";
                StringBuilder webcsprojContent = new StringBuilder();
                webcsprojContent.AppendLine();
                StringBuilder WebCsproj = new StringBuilder();
                WebCsproj.AppendLine();
                StringBuilder MenuIcons = new StringBuilder();
                MenuIcons.AppendLine();

                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString().ToLower();
                    //首先将添加到webcsrpoj
                    WebCsproj.AppendLine(string.Format(Cmds.WebCSProj, tablename));
                    webcsprojContent.AppendLine(string.Format(Cmds.WCSproj, tablename));
                    //添加菜单图片
                    MenuIcons.AppendLine(Cmds.MenuIcon.Replace("{0}", tablename));

                    //找到该表的结构
                    DataTable dt = null;
                    if (dbtype == "SQLServer2005")
                        dt = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindTableStructs, tablename));
                    else if (dbtype == "Oracle")
                        dt = CJ.Oracle_ReturnDataTable(string.Format(Cmds.OracleFindTalbeStructs, tablename.ToUpper()));
                    int a = dt.Rows.Count;
                    //列试图
                    StringBuilder ColumnView = new StringBuilder();
                    ColumnView.AppendLine();
                    //Store的reader
                    StringBuilder Reader = new StringBuilder();
                    Reader.AppendLine();

                    string AutoID = "";
                    //赋值给窗体
                    StringBuilder SetWinValue = new StringBuilder();
                    SetWinValue.AppendLine();
                    //窗体的文本框，奇数偶数行
                    StringBuilder WinColumnJS = new StringBuilder();
                    WinColumnJS.AppendLine();
                    StringBuilder WinColumnOS = new StringBuilder();
                    WinColumnOS.AppendLine();
                    StringBuilder ColumnFilters = new StringBuilder();
                    ColumnFilters.AppendLine();
                    StringBuilder Designer = new StringBuilder();
                    Designer.AppendLine();
                    StringBuilder GetValue = new StringBuilder();
                    GetValue.AppendLine();
                     
                    if (dbtype == "SQLServer2005")
                    {
                        DataTable dtautoid = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindAutoID, tablename));
                        if (dtautoid.Rows.Count > 0)
                            AutoID = dtautoid.Rows[0][0].ToString();
                        else AutoID = dt.Rows[0]["FieldName"].ToString();
                    }
                    else
                        AutoID = dt.Rows[0]["FieldName"].ToString();

                    
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string cname = dt.Rows[j]["FieldName"].ToString().ToLower();
                        string cdesc = dt.Rows[j]["FieldDesc"].ToString();
                        string ctype = dt.Rows[j]["FieldType"].ToString();
                        Reader.AppendLine("\t\t\t\t\t" + string.Format(Cmds.StoreReader, cname));
                        if (j == 0)
                        {
                            AutoID = cname;
                        }
                        else
                        {
                            if (ctype == "int" || ctype == "number")
                            {
                                if (j % 2 == 0)
                                    WinColumnOS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.NumberField, "TxtNum" + cname, cdesc));
                                else
                                    WinColumnJS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.NumberField, "TxtNum" + cname, cdesc));
                                SetWinValue.AppendLine("\t\t\t" + string.Format(Cmds.WinSetValue, "TxtNum" + cname, tablename, cname));
                                Designer.AppendLine("\t\tprotected global::Ext.Net.NumberField TxtNum" + cname + ";");
                                GetValue.AppendLine("\t\t\t_" + tablename + "." + cname + " = int.Parse(TxtNum" + cname + ".Text.Trim());");
                            }
                            else if (ctype == "DateTime")
                            {
                                if (j % 2 == 0)
                                    WinColumnOS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.DateField, "TxtDate" + cname, cdesc));
                                else
                                    WinColumnJS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.DateField, "TxtDate" + cname, cdesc));
                                SetWinValue.AppendLine("\t\t\t" + string.Format(Cmds.WinSetValue, "TxtDate" + cname, tablename, cname));
                                Designer.AppendLine("\t\tprotected global::Ext.Net.DateField TxtDate" + cname + ";");
                                GetValue.AppendLine("\t\t\t_" + tablename + "." + cname + " = TxtDate" + cname + ".Text.Trim();");
                            }
                            else
                            {
                                if (j % 2 == 0)
                                    WinColumnOS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.TxtFields, "Txt" + cname, cdesc));
                                else
                                    WinColumnJS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.TxtFields, "Txt" + cname, cdesc));
                                SetWinValue.AppendLine("\t\t\t" + string.Format(Cmds.WinSetValue, "Txt" + cname, tablename, cname));
                                ColumnFilters.AppendLine("\t\t\t\t\t\t\t\t" + string.Format(Cmds.Filter, cname));
                                Designer.AppendLine("\t\tprotected global::Ext.Net.TextField Txt" + cname + ";");
                                GetValue.AppendLine("\t\t\t_" + tablename + "." + cname + " = Txt" + cname + ".Text.Trim();");
                            }
                            ColumnView.AppendLine("\t\t\t\t\t\t\t\t" + string.Format(Cmds.Columns, cdesc, cname));
                        }
                    }
                    if (!Directory.Exists(path + tablename + "Menu")) Directory.CreateDirectory(path + tablename + "Menu");

                    FileOperator.WriteFile(path + tablename + "Menu\\Default.aspx", FileOperator.ReadFile(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx")
                        .Replace("{title}", tablename)
                        .Replace("{tablename}", tablename)
                        .Replace("{PRIMARYKEY}", AutoID)
                        .Replace("{SETWINDATAFORSHOW}", SetWinValue.ToString())
                        .Replace("{STOREREADER}", Reader.ToString())
                        .Replace("{GRIDCLOLUMNS}", ColumnView.ToString())
                        .Replace("{GRIDFILTERS}", ColumnFilters.ToString())
                        .Replace("{JSTEXTBOX}", WinColumnJS.ToString())
                        .Replace("{OSTEXTBOX}", WinColumnOS.ToString())
                        .Replace("{HEIGHT}", ((a / 2 + (a % 2 == 0 ? 0 : 1)) * 30).ToString()));
                    FileOperator.WriteFile(path + tablename + "Menu\\Default.aspx.cs", FileOperator.ReadFile(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx.cs")
                        .Replace("{tablename}", tablename)
                        .Replace("{PRIMARYKEY}", AutoID)
                        .Replace("{GATVALUE}", GetValue.ToString()));

                    FileOperator.WriteFile(path + tablename + "Menu\\Default.aspx.designer.cs", FileOperator.ReadFile(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx.designer.cs")
                        .Replace("{tablename}", tablename)
                        .Replace("{DESIGNERInserPoint}", Designer.ToString()));
                }
                FileOperator.WriteFile(path + "\\images\\Icons\\icon.css", FileOperator.ReadFile(path + "\\images\\Icons\\icon.css").Replace("/*ICONInsertPoint*/", MenuIcons + "\r\n/*ICONInsertPoint*/"));
                FileOperator.WriteFile(webprojpath + "\\Web\\Web.csproj", FileOperator.ReadFile(webprojpath + "\\Web\\Web.csproj").Replace("<!--DHELPERWEB-->", WebCsproj.ToString()+"<!--DHELPERWEB-->").Replace("<!--WebContent-->", webcsprojContent.ToString() + "<!--WebContent-->"));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //后台速成
        public string CreatePages(ArrayList tablelist, string path, string dbtype)
        {
            try
            {
                string webprojpath = path + "\\WebMisDeveloper\\";
                path = path + "\\WebMisDeveloper\\Web\\View\\";
                StringBuilder webcsprojContent = new StringBuilder();
                webcsprojContent.AppendLine();
                StringBuilder WebCsproj = new StringBuilder();
                WebCsproj.AppendLine();
                StringBuilder MenuIcons = new StringBuilder();
                MenuIcons.AppendLine();
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString().ToLower();

                    //首先将添加到webcsrpoj
                    WebCsproj.AppendLine(string.Format(Cmds.WebCSProj, tablename));
                    webcsprojContent.AppendLine(string.Format(Cmds.WCSproj, tablename));
                    //添加菜单图片
                    MenuIcons.AppendLine(Cmds.MenuIcon.Replace("{0}", tablename));

                    //找到该表的结构
                    DataTable dt = null;
                    if (dbtype == "SQLServer2005")
                        dt = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindTableStructs, tablename));
                    else if (dbtype == "Oracle")
                        dt = CJ.Oracle_ReturnDataTable(string.Format(Cmds.OracleFindTalbeStructs, tablename.ToUpper()));

                    int a = dt.Rows.Count;
                    //列试图
                    StringBuilder ColumnView = new StringBuilder();
                    ColumnView.AppendLine();
                    //Store的reader
                    StringBuilder Reader = new StringBuilder();
                    Reader.AppendLine();

                    string AutoID = "";
                    //赋值给窗体
                    StringBuilder SetWinValue = new StringBuilder();
                    SetWinValue.AppendLine();
                    //窗体的文本框，奇数偶数行
                    StringBuilder WinColumnJS = new StringBuilder();
                    WinColumnJS.AppendLine();
                    StringBuilder WinColumnOS = new StringBuilder();
                    WinColumnOS.AppendLine();
                    StringBuilder ColumnFilters = new StringBuilder();
                    ColumnFilters.AppendLine();
                    StringBuilder Designer = new StringBuilder();
                    Designer.AppendLine();
                    StringBuilder GetValue = new StringBuilder();
                    GetValue.AppendLine();
                     
                    if (dbtype == "SQLServer2005")
                    {
                        DataTable dtautoid = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindAutoID, tablename));
                        if (dtautoid.Rows.Count > 0)
                            AutoID = dtautoid.Rows[0][0].ToString();
                        else AutoID = dt.Rows[0]["FieldName"].ToString();
                    }
                    else
                        AutoID = dt.Rows[0]["FieldName"].ToString();

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string cname = dt.Rows[j]["FieldName"].ToString().ToLower();
                        string cdesc = dt.Rows[j]["FieldDesc"].ToString();
                        string ctype = dt.Rows[j]["FieldType"].ToString();
                        Reader.AppendLine("\t\t\t\t\t" + string.Format(Cmds.StoreReader, cname));
                        if (j == 0)
                        {
                            AutoID = cname;
                        }
                        else
                        {
                            if (ctype == "int" || ctype == "number")
                            {
                                if (j % 2 == 0)
                                    WinColumnOS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.NumberField, "TxtNum" + cname, cdesc));
                                else
                                    WinColumnJS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.NumberField, "TxtNum" + cname, cdesc));
                                SetWinValue.AppendLine("\t\t\t" + string.Format(Cmds.WinSetValue, "TxtNum" + cname, tablename, cname));
                                Designer.AppendLine("\t\tprotected global::Ext.Net.NumberField TxtNum" + cname + ";");
                                GetValue.AppendLine("\t\t\t_" + tablename + "." + cname + " = int.Parse(TxtNum" + cname + ".Text.Trim());");
                            }
                            else if (ctype == "DateTime")
                            {
                                if (j % 2 == 0)
                                    WinColumnOS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.DateField, "TxtDate" + cname, cdesc));
                                else
                                    WinColumnJS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.DateField, "TxtDate" + cname, cdesc));
                                SetWinValue.AppendLine("\t\t\t" + string.Format(Cmds.WinSetValue, "TxtDate" + cname, tablename, cname));
                                Designer.AppendLine("\t\tprotected global::Ext.Net.DateField TxtDate" + cname + ";");
                                GetValue.AppendLine("\t\t\t_" + tablename + "." + cname + " = TxtDate" + cname + ".Text.Trim();");
                            }
                            else
                            {
                                if (j % 2 == 0)
                                    WinColumnOS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.TxtFields, "Txt" + cname, cdesc));
                                else
                                    WinColumnJS.AppendLine("\t\t\t\t\t\t\t" + string.Format(Cmds.TxtFields, "Txt" + cname, cdesc));
                                SetWinValue.AppendLine("\t\t\t" + string.Format(Cmds.WinSetValue, "Txt" + cname, tablename, cname));
                                ColumnFilters.AppendLine("\t\t\t\t\t\t\t\t" + string.Format(Cmds.Filter, cname));
                                Designer.AppendLine("\t\tprotected global::Ext.Net.TextField Txt" + cname + ";");
                                GetValue.AppendLine("\t\t\t_" + tablename + "." + cname + " = Txt" + cname + ".Text.Trim();");
                            }
                            ColumnView.AppendLine("\t\t\t\t\t\t\t\t" + string.Format(Cmds.Columns, cdesc, cname));
                        }
                    }
                    if (!Directory.Exists(path + tablename + "Menu")) Directory.CreateDirectory(path + tablename + "Menu");

                    FileOperator.WriteFile(path + tablename + "Menu\\Default.aspx", FileOperator.ReadFile(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx")
                        .Replace("{title}", tablename)
                        .Replace("{tablename}", tablename)
                        .Replace("{PRIMARYKEY}", AutoID)
                        .Replace("{SETWINDATAFORSHOW}", SetWinValue.ToString())
                        .Replace("{STOREREADER}", Reader.ToString())
                        .Replace("{GRIDCLOLUMNS}", ColumnView.ToString())
                        .Replace("{GRIDFILTERS}", ColumnFilters.ToString())
                        .Replace("{JSTEXTBOX}", WinColumnJS.ToString())
                        .Replace("{OSTEXTBOX}", WinColumnOS.ToString())
                        .Replace("{HEIGHT}", ((a / 2 + (a % 2 == 0 ? 0 : 1)) * 30).ToString()));
                    FileOperator.WriteFile(path + tablename + "Menu\\Default.aspx.cs", FileOperator.ReadFile(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx.cs")
                        .Replace("{tablename}", tablename)
                        .Replace("{PRIMARYKEY}", AutoID)
                        .Replace("{GATVALUE}", GetValue.ToString()));

                    FileOperator.WriteFile(path + tablename + "Menu\\Default.aspx.designer.cs", FileOperator.ReadFile(".\\WebBasic\\EF\\{tablename}Menu\\Default.aspx.designer.cs")
                        .Replace("{tablename}", tablename)
                        .Replace("{DESIGNERInserPoint}", Designer.ToString()));
                }
                FileOperator.WriteFile(path + "\\images\\Icons\\icon.css", FileOperator.ReadFile(path + "\\images\\Icons\\icon.css").Replace("/*ICONInsertPoint*/", MenuIcons + "\r\n/*ICONInsertPoint*/"));
                FileOperator.WriteFile(webprojpath + "\\Web\\Web.csproj", FileOperator.ReadFile(webprojpath + "\\Web\\Web.csproj").Replace("{WebInsertPoint}", WebCsproj.ToString()).Replace("{WebContent}", webcsprojContent.ToString()));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

    }
}
