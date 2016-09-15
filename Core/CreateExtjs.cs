using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Linq;
using System.Text;
using CJ_DBOperater;


/*
 * 陈杰
 * 2009-11-9
 * 创建Extjs文件 
 */
namespace Core
{
    public class CreateExtjs
    {

        public string BuildExtjs(string path, ArrayList Menulist, string dbname)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                StringBuilder JSLinks = new StringBuilder();
                JSLinks.AppendLine();
                StringBuilder WebCsproj = new StringBuilder();
                WebCsproj.AppendLine();
                StringBuilder MenuCfg = new StringBuilder();
                MenuCfg.AppendLine();
                for (int i = 0; i < Menulist.Count; i++)
                {
                    string tablename = Menulist[i].ToString();
                    JSLinks.AppendLine("\t<script type=\"text/javascript\" src=\"../Content/scripts/backMgr/mainview/" + tablename.ToLower() + "Grid.js\"></script>");
                    JSLinks.AppendLine("\t<script type=\"text/javascript\" src=\"../Content/scripts/backMgr/mainview/" + tablename.ToLower() + "Win.js\"></script>");
                    WebCsproj.AppendLine("\t<Content Include=\"Content\\scripts\\backMgr\\mainview\\" + tablename.ToLower() + "Win.js\" />");
                    WebCsproj.AppendLine("\t<Content Include=\"Content\\scripts\\backMgr\\mainview\\" + tablename.ToLower() + "Grid.js\" />");

                    //菜单
                    MenuCfg.AppendLine("\t\t\telse if(id =='" + tablename.ToLower() + "Menu'){");
                    MenuCfg.AppendLine("\t\t\t\tvar p=this.add(new Swfu.BackMgr." + tablename.ToLower() + "Grid({");
                    MenuCfg.AppendLine("\t\t\t\t   id : id,");
                    MenuCfg.AppendLine("\t\t\t\t   title : title,");
                    MenuCfg.AppendLine("\t\t\t\t   //iconCls : 'icon-'+id,");
                    MenuCfg.AppendLine("\t\t\t\t   closable : true");
                    MenuCfg.AppendLine("\t\t\t}));");
                    MenuCfg.AppendLine("\t\t\t}");

                    //找到该表的结构
                    string sql = string.Format(Cmds.FindTableInfo, tablename, dbname);
                    DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindTableInfo, tablename, dbname));
                    int a = dt.Rows.Count;
                    //TPL
                    string TPL = "'";
                    StringBuilder ColumnView = new StringBuilder();
                    ColumnView.AppendLine();
                    StringBuilder Reader = new StringBuilder();
                    Reader.AppendLine();
                    string GroupName = "";//分组字段
                    GroupName = dt.Rows[2]["FieldName"].ToString().ToLower();//使用第三个字段为分组字段，用户控制
                    string CheckValue = "";
                    string AutoID = "";
                    string AddEditRecord = "";//添加,修改
                    StringBuilder SetWinValue = new StringBuilder();
                    SetWinValue.AppendLine();
                    StringBuilder WinColumn = new StringBuilder();
                    WinColumn.AppendLine();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string cname = dt.Rows[j]["FieldName"].ToString().ToLower();
                        string cdesc = dt.Rows[j]["FieldDesc"].ToString();
                        string ctype = dt.Rows[j]["FieldType"].ToString();
                        string cwidth = ".5";
                        string xtype = "textfield";
                        string otherPro = "anchor : '98%'";
                        if (ctype == "int" || ctype == "number")
                        {
                            xtype = "numberfield";
                        }
                        else if (ctype == "Text" || ctype == "clob")
                        {
                            xtype = "textarea";
                            cwidth = "1";
                            otherPro = "anchor : '99%'";
                        }
                        else if (ctype == "DateTime")
                        {
                            xtype = "datefield";
                            otherPro = "readOnly : true, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\taltFormats: 'Y/m/d', \r\n\t\t\t\t\t\t\t\t\t\t\t\t\tformat : 'Y/m/d',\r\n\t\t\t\t\t\t\t\t\t\t\t\t\tanchor : '98%'";
                        }
                        else
                        {
                            cwidth = ".5";
                            xtype = "textfield";
                        }
                        Reader.AppendLine("\t\t\t\t\t\t{name : '" + cname + "'}");
                        if (j == 0)//第一个自增
                        {
                            Reader.AppendLine("\t\t\t\t\t\t,");
                            AutoID = cname;
                        }
                        else
                        {
                            //从窗体中获得记录
                            AddEditRecord += "'" + cname + "' : Ext.getCmp('" + cname + "').getValue()";

                            //检查值是否为空
                            if (ctype != "DateTime")
                            {
                                if (ctype == "int")
                                    CheckValue += "Ext.getCmp('" + cname + "').getValue().toString().trim().length<=0||";
                                else
                                    CheckValue += "Ext.getCmp('" + cname + "').getValue().trim().length<=0||";
                                SetWinValue.AppendLine("\t\t\tExt.getCmp('" + cname + "').setValue(record.get(\"" + cname + "\"));");
                            }
                            //tpl添加
                            TPL += "<p>" + cdesc + ":{" + cname + "}</p>";
                            //显示列
                            ColumnView.AppendLine("\t\t\t\t{");
                            ColumnView.AppendLine("\t\t\t\t\theader : '" + cdesc + "',");
                            ColumnView.AppendLine("\t\t\t\t\tsortable : true,");
                            ColumnView.AppendLine("\t\t\t\t\thidden : false,");
                            ColumnView.AppendLine("\t\t\t\t\tdataIndex : '" + cname + "'");
                            ColumnView.AppendLine("\t\t\t\t}");

                            //win里的列
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t{");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t columnWidth : " + cwidth + ",");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\tlayout : 'form',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\titems : [{");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tfieldLabel : '" + cdesc + "',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t xtype : '" + xtype + "',");//错误
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tname : '" + cname + "',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tid : '" + cname + "',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tallowBlank : false,");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\temptyText : '该项值不能为空',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tblankText : '该项值不能为空',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t" + otherPro);//如果是时间的话，加上时间格式化
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t}]");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t}");
                            if (j < dt.Rows.Count - 1)
                            {
                                ColumnView.AppendLine("\t\t\t\t,");
                                Reader.AppendLine("\t\t\t\t\t\t,");
                                AddEditRecord += ",\r\n\t\t\t\t\t\t";
                                WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t,");
                            }
                        }
                    }
                    TPL += "',";
                    if (CheckValue.EndsWith("||"))
                        CheckValue = CheckValue.Substring(0, CheckValue.Length - 2);
                    //生成Grid和Win
                    FileOperator.WriteFile(path + "Web\\Content\\scripts\\backMgr\\mainview\\" + tablename.ToString().ToLower() + "Grid.js", FileOperator.ReadFile(".\\WebBasic\\{tablename}Grid.js").Replace("{tplColumnDetail}", TPL).Replace("{tablename}", tablename.ToLower()).Replace("{ColumnDesc}", ColumnView.ToString()).Replace("{Modelreader}", Reader.ToString()).Replace("{ValueNotNull}", CheckValue).Replace("{Add_Records}", AddEditRecord).Replace("{Edit_Records}", AddEditRecord + ",\r\n\t\t\t\t\t\t'" + AutoID + "' : record.get('" + AutoID + "')").Replace("{SetWinValue}", SetWinValue.ToString()).Replace("{GroupColumn}", GroupName));
                    FileOperator.WriteFile(path + "Web\\Content\\scripts\\backMgr\\mainview\\" + tablename.ToString().ToLower() + "Win.js", FileOperator.ReadFile(".\\WebBasic\\{tablename}Win.js").Replace("{tablename}", tablename.ToLower()).Replace("{WinColumn}", WinColumn.ToString()));
                }
                //aspx,tree,csproj
                FileOperator.WriteFile(path + "Web\\Web.csproj", FileOperator.ReadFile(path + "Web\\Web.csproj").Replace("{EXTJSInsertPoint}", WebCsproj.ToString()));
                FileOperator.WriteFile(path + "Web\\Content\\scripts\\backMgr\\backMain.js", FileOperator.ReadFile(path + "Web\\Content\\scripts\\backMgr\\backMain.js").Replace("{BackMainELSEIF}", MenuCfg.ToString()));
                FileOperator.WriteFile(path + "Web\\View\\backMgr.aspx", FileOperator.ReadFile(path + "Web\\View\\backMgr.aspx").Replace("{EXTJS_InsertPoint}", JSLinks.ToString()));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        //二次开发，生成Extjs文件
        public string BuildUI(string path, ArrayList tablelist, string dbtype)
        {
            try
            {
                StringBuilder JSLinks = new StringBuilder();
                JSLinks.AppendLine();
                StringBuilder WebCsproj = new StringBuilder();
                WebCsproj.AppendLine();
                StringBuilder MenuCfg = new StringBuilder();
                MenuCfg.AppendLine();
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    JSLinks.AppendLine("\t<script type=\"text/javascript\" src=\"../Content/scripts/backMgr/mainview/" + tablename.ToLower() + "Grid.js\"></script>");
                    JSLinks.AppendLine("\t<script type=\"text/javascript\" src=\"../Content/scripts/backMgr/mainview/" + tablename.ToLower() + "Win.js\"></script>");
                    WebCsproj.AppendLine("\t<Content Include=\"Content\\scripts\\backMgr\\mainview\\" + tablename.ToLower() + "Win.js\" />");
                    WebCsproj.AppendLine("\t<Content Include=\"Content\\scripts\\backMgr\\mainview\\" + tablename.ToLower() + "Grid.js\" />");
                    //菜单
                    MenuCfg.AppendLine("\t\t\telse if(id =='" + tablename.ToLower() + "Menu'){");
                    MenuCfg.AppendLine("\t\t\t\tvar p=this.add(new Swfu.BackMgr." + tablename.ToLower() + "Grid({");
                    MenuCfg.AppendLine("\t\t\t\t   id : id,");
                    MenuCfg.AppendLine("\t\t\t\t   title : title,");
                    MenuCfg.AppendLine("\t\t\t\t   //iconCls : 'icon-'+id,");
                    MenuCfg.AppendLine("\t\t\t\t   closable : true");
                    MenuCfg.AppendLine("\t\t\t}));");
                    MenuCfg.AppendLine("\t\t\t}");
                    //找到该表的结构
                    DataTable dt = null;
                    if (dbtype == "SQLServer2005")
                        dt = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindTableStructs, tablename));
                    else if (dbtype == "Oracle")
                        dt = CJ.Oracle_ReturnDataTable(string.Format(Cmds.OracleFindTalbeStructs, tablename.ToUpper()));
                    //TPL
                    string TPL = "'";
                    StringBuilder ColumnView = new StringBuilder();
                    ColumnView.AppendLine();
                    StringBuilder Reader = new StringBuilder();
                    Reader.AppendLine();
                    string GroupName = "";//分组字段
                    if (dt.Rows.Count > 2)
                        GroupName = dt.Rows[2]["FieldName"].ToString().ToLower();//使用第三个字段为分组字段，用户控制
                    else
                        GroupName = dt.Rows[1]["FieldName"].ToString().ToLower();
                    string CheckValue = "";

                    string AutoID = "";
                    if (dbtype == "SQLServer2005")
                    {
                        DataTable dtautoid = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindAutoID, tablename));
                        if (dtautoid.Rows.Count > 0)
                            AutoID = dtautoid.Rows[0][0].ToString();
                        else AutoID = dt.Rows[0]["FieldName"].ToString();
                    }
                    else
                        AutoID = dt.Rows[0]["FieldName"].ToString();

                    string AddEditRecord = "";//添加,修改
                    StringBuilder SetWinValue = new StringBuilder();
                    SetWinValue.AppendLine();
                    StringBuilder WinColumn = new StringBuilder();
                    WinColumn.AppendLine();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string cname = dt.Rows[j]["FieldName"].ToString().ToLower();
                        string cdesc = dt.Rows[j]["FieldDesc"].ToString();
                        string ctype = dt.Rows[j]["FieldType"].ToString().ToLower();
                        string cwidth = ".5";
                        string xtype = "textfield";
                        string otherPro = "anchor : '98%'";
                        if (ctype == "int" || ctype == "number")
                        {
                            xtype = "numberfield";
                        }
                        else if (ctype == "text" || ctype == "clob")
                        {
                            xtype = "textarea";
                            cwidth = "1";
                            otherPro = "anchor : '99%'";
                        }
                        else if (ctype == "datetime")
                        {
                            xtype = "datefield";
                            otherPro = "readOnly : true, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\taltFormats: 'Y/m/d', \r\n\t\t\t\t\t\t\t\t\t\t\t\t\tformat : 'Y/m/d',\r\n\t\t\t\t\t\t\t\t\t\t\t\t\tanchor : '98%'";
                        }
                        else
                        {
                            cwidth = ".5";
                            xtype = "textfield";
                        }
                        Reader.AppendLine("\t\t\t\t\t\t{name : '" + cname + "'}");
                        if (j == 0)//第一个自增
                        {
                            Reader.AppendLine("\t\t\t\t\t\t,");
                        }
                        else
                        {
                            //从窗体中获得记录
                            AddEditRecord += "'" + cname + "' : Ext.getCmp('" + cname + "').getValue()";
                            //检查值是否为空
                            if (ctype != "datetime")
                            {
                                if (ctype == "int" || ctype == "number")
                                    CheckValue += "Ext.getCmp('" + cname + "').getValue().toString().trim().length<=0||";
                                else
                                    CheckValue += "Ext.getCmp('" + cname + "').getValue().trim().length<=0||";
                                SetWinValue.AppendLine("\t\t\tExt.getCmp('" + cname + "').setValue(record.get(\"" + cname + "\"));");
                            }
                            //tpl添加
                            TPL += "<p>" + cdesc + ":{" + cname + "}</p>";
                            //显示列
                            ColumnView.AppendLine("\t\t\t\t{");
                            ColumnView.AppendLine("\t\t\t\t\theader : '" + cdesc + "',");
                            ColumnView.AppendLine("\t\t\t\t\tsortable : true,");
                            ColumnView.AppendLine("\t\t\t\t\thidden : false,");
                            ColumnView.AppendLine("\t\t\t\t\tdataIndex : '" + cname + "'");
                            ColumnView.AppendLine("\t\t\t\t}");
                            //win里的列
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t{");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t columnWidth : " + cwidth + ",");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\tlayout : 'form',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\titems : [{");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tfieldLabel : '" + cdesc + "',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t xtype : '" + xtype + "',");//错误
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tname : '" + cname + "',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tid : '" + cname + "',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tallowBlank : false,");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\temptyText : '该项值不能为空',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tblankText : '该项值不能为空',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t" + otherPro);//如果是时间的话，加上时间格式化
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t}]");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t}");
                            if (j < dt.Rows.Count - 1)
                            {
                                ColumnView.AppendLine("\t\t\t\t,");
                                Reader.AppendLine("\t\t\t\t\t\t,");
                                AddEditRecord += ",\r\n\t\t\t\t\t\t";
                                WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t,");
                            }
                        }
                    }
                    TPL += "',";
                    if (CheckValue.EndsWith("||"))
                        CheckValue = CheckValue.Substring(0, CheckValue.Length - 2);
                    //生成Grid和Win
                    FileOperator.WriteFile(path + "\\Web\\Content\\scripts\\backMgr\\mainview\\" + tablename.ToString().ToLower() + "Grid.js", FileOperator.ReadFile(".\\WebBasic\\{tablename}Grid.js").Replace("{tplColumnDetail}", TPL).Replace("{tablename}", tablename.ToLower()).Replace("{ColumnDesc}", ColumnView.ToString()).Replace("{Modelreader}", Reader.ToString()).Replace("{ValueNotNull}", CheckValue).Replace("{Add_Records}", AddEditRecord).Replace("{Edit_Records}", AddEditRecord + ",\r\n\t\t\t\t\t\t'" + AutoID + "' : record.get('" + AutoID + "')").Replace("{SetWinValue}", SetWinValue.ToString()).Replace("{GroupColumn}", GroupName));
                    FileOperator.WriteFile(path + "\\Web\\Content\\scripts\\backMgr\\mainview\\" + tablename.ToString().ToLower() + "Win.js", FileOperator.ReadFile(".\\WebBasic\\{tablename}Win.js").Replace("{tablename}", tablename.ToLower()).Replace("{WinColumn}", WinColumn.ToString()));
                }
                FileOperator.WriteFile(path + "\\Web\\Web.csproj", FileOperator.ReadFile(path + "\\Web\\Web.csproj").Replace("<!--DHELPEREXTJS-->", WebCsproj.ToString() + "<!--DHELPEREXTJS-->"));
                FileOperator.WriteFile(path + "\\Web\\Content\\scripts\\backMgr\\backMain.js", FileOperator.ReadFile(path + "\\Web\\Content\\scripts\\backMgr\\backMain.js").Replace("//Menu", MenuCfg.ToString() + "//Menu"));
                FileOperator.WriteFile(path + "\\Web\\View\\backMgr.aspx", FileOperator.ReadFile(path + "\\Web\\View\\backMgr.aspx").Replace("<!--DHELPERASPX-->", JSLinks.ToString() + "<!--DHELPERASPX-->"));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //后台速成
        public string BuildExtjs(ArrayList tablelist, string path, string dbtype)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                StringBuilder JSLinks = new StringBuilder();
                JSLinks.AppendLine();
                StringBuilder WebCsproj = new StringBuilder();
                WebCsproj.AppendLine();
                StringBuilder MenuCfg = new StringBuilder();
                MenuCfg.AppendLine();
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    JSLinks.AppendLine("\t<script type=\"text/javascript\" src=\"../Content/scripts/backMgr/mainview/" + tablename.ToLower() + "Grid.js\"></script>");
                    JSLinks.AppendLine("\t<script type=\"text/javascript\" src=\"../Content/scripts/backMgr/mainview/" + tablename.ToLower() + "Win.js\"></script>");
                    WebCsproj.AppendLine("\t<Content Include=\"Content\\scripts\\backMgr\\mainview\\" + tablename.ToLower() + "Win.js\" />");
                    WebCsproj.AppendLine("\t<Content Include=\"Content\\scripts\\backMgr\\mainview\\" + tablename.ToLower() + "Grid.js\" />");
                    //菜单
                    MenuCfg.AppendLine("\t\t\telse if(id =='" + tablename.ToLower() + "Menu'){");
                    MenuCfg.AppendLine("\t\t\t\tvar p=this.add(new Swfu.BackMgr." + tablename.ToLower() + "Grid({");
                    MenuCfg.AppendLine("\t\t\t\t   id : id,");
                    MenuCfg.AppendLine("\t\t\t\t   title : title,");
                    MenuCfg.AppendLine("\t\t\t\t   //iconCls : 'icon-'+id,");
                    MenuCfg.AppendLine("\t\t\t\t   closable : true");
                    MenuCfg.AppendLine("\t\t\t}));");
                    MenuCfg.AppendLine("\t\t\t}");

                    //找到该表的结构
                    DataTable dt = null;
                    if (dbtype == "SQLServer2005")
                        dt = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindTableStructs, tablename));
                    else if (dbtype == "Oracle")
                        dt = CJ.Oracle_ReturnDataTable(string.Format(Cmds.OracleFindTalbeStructs, tablename.ToUpper()));

                    //TPL
                    string TPL = "'";
                    StringBuilder ColumnView = new StringBuilder();
                    ColumnView.AppendLine();
                    StringBuilder Reader = new StringBuilder();
                    Reader.AppendLine();
                    string GroupName = "";//分组字段
                    if (dt.Rows.Count > 2)
                        GroupName = dt.Rows[2]["FieldName"].ToString().ToLower();//使用第三个字段为分组字段，用户控制
                    else
                        GroupName = dt.Rows[1]["FieldName"].ToString().ToLower();
                    string CheckValue = "";

                    string AutoID = "";
                    if (dbtype == "SQLServer2005")
                    {
                        DataTable dtautoid = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindAutoID, tablename));
                        if (dtautoid.Rows.Count > 0)
                            AutoID = dtautoid.Rows[0][0].ToString();
                        else AutoID = dt.Rows[0]["FieldName"].ToString();
                    }
                    else
                        AutoID = dt.Rows[0]["FieldName"].ToString();

                    string AddEditRecord = "";//添加,修改
                    StringBuilder SetWinValue = new StringBuilder();
                    SetWinValue.AppendLine();
                    StringBuilder WinColumn = new StringBuilder();
                    WinColumn.AppendLine();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string cname = dt.Rows[j]["FieldName"].ToString().ToLower();
                        string cdesc = dt.Rows[j]["FieldDesc"].ToString();
                        string ctype = dt.Rows[j]["FieldType"].ToString();
                        string cwidth = ".5";
                        string xtype = "textfield";
                        string otherPro = "anchor : '98%'";
                        if (ctype.ToLower() == "int" || ctype.ToLower() == "number")
                        {
                            xtype = "numberfield";
                        }
                        else if (ctype.ToLower() == "text" || ctype.ToLower() == "clob")
                        {
                            xtype = "textarea";
                            cwidth = "1";
                            otherPro = "anchor : '99%'";
                        }
                        else if (ctype.ToLower() == "datetime")
                        {
                            xtype = "datefield";
                            otherPro = "readOnly : true, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\taltFormats: 'Y/m/d', \r\n\t\t\t\t\t\t\t\t\t\t\t\t\tformat : 'Y/m/d',\r\n\t\t\t\t\t\t\t\t\t\t\t\t\tanchor : '98%'";
                        }
                        else
                        {
                            cwidth = ".5";
                            xtype = "textfield";
                        }
                        Reader.AppendLine("\t\t\t\t\t\t{name : '" + cname + "'}");
                        if (j == 0)//第一个自增
                        {
                            Reader.AppendLine("\t\t\t\t\t\t,");
                        }
                        else
                        {
                            //从窗体中获得记录
                            AddEditRecord += "'" + cname + "' : Ext.getCmp('" + cname + "').getValue()";
                            //检查值是否为空
                            if (ctype.ToLower() != "datetime")
                            {
                                if (ctype.ToLower() == "int" || ctype.ToLower() == "number")
                                    CheckValue += "Ext.getCmp('" + cname + "').getValue().toString().trim().length<=0||";
                                else
                                    CheckValue += "Ext.getCmp('" + cname + "').getValue().trim().length<=0||";
                                SetWinValue.AppendLine("\t\t\tExt.getCmp('" + cname + "').setValue(record.get(\"" + cname + "\"));");
                            }
                            //tpl添加
                            TPL += "<p>" + cdesc + ":{" + cname + "}</p>";
                            //显示列
                            ColumnView.AppendLine("\t\t\t\t{");
                            ColumnView.AppendLine("\t\t\t\t\theader : '" + cdesc + "',");
                            ColumnView.AppendLine("\t\t\t\t\tsortable : true,");
                            ColumnView.AppendLine("\t\t\t\t\thidden : false,");
                            ColumnView.AppendLine("\t\t\t\t\tdataIndex : '" + cname + "'");
                            ColumnView.AppendLine("\t\t\t\t}");

                            //win里的列
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t{");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t columnWidth : " + cwidth + ",");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\tlayout : 'form',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\titems : [{");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tfieldLabel : '" + cdesc + "',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t xtype : '" + xtype + "',");//错误
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tname : '" + cname + "',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tid : '" + cname + "',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tallowBlank : false,");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\temptyText : '该项值不能为空',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tblankText : '该项值不能为空',");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t" + otherPro);//如果是时间的话，加上时间格式化
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t}]");
                            WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t}");
                            if (j < dt.Rows.Count - 1)
                            {
                                ColumnView.AppendLine("\t\t\t\t,");
                                Reader.AppendLine("\t\t\t\t\t\t,");
                                AddEditRecord += ",\r\n\t\t\t\t\t\t";
                                WinColumn.AppendLine("\t\t\t\t\t\t\t\t\t\t\t,");
                            }
                        }
                    }
                    TPL += "',";
                    if (CheckValue.EndsWith("||"))
                        CheckValue = CheckValue.Substring(0, CheckValue.Length - 2);
                    //生成Grid和Win
                    FileOperator.WriteFile(path + "Web\\Content\\scripts\\backMgr\\mainview\\" + tablename.ToString().ToLower() + "Grid.js", FileOperator.ReadFile(".\\WebBasic\\{tablename}Grid.js").Replace("{tplColumnDetail}", TPL).Replace("{tablename}", tablename.ToLower()).Replace("{ColumnDesc}", ColumnView.ToString()).Replace("{Modelreader}", Reader.ToString()).Replace("{ValueNotNull}", CheckValue).Replace("{Add_Records}", AddEditRecord).Replace("{Edit_Records}", AddEditRecord + ",\r\n\t\t\t\t\t\t'" + AutoID + "' : record.get('" + AutoID + "')").Replace("{SetWinValue}", SetWinValue.ToString()).Replace("{GroupColumn}", GroupName));
                    FileOperator.WriteFile(path + "Web\\Content\\scripts\\backMgr\\mainview\\" + tablename.ToString().ToLower() + "Win.js", FileOperator.ReadFile(".\\WebBasic\\{tablename}Win.js").Replace("{tablename}", tablename.ToLower()).Replace("{WinColumn}", WinColumn.ToString()));
                }
                //aspx,tree,csproj
                FileOperator.WriteFile(path + "Web\\Web.csproj", FileOperator.ReadFile(path + "Web\\Web.csproj").Replace("{EXTJSInsertPoint}", WebCsproj.ToString()));
                FileOperator.WriteFile(path + "Web\\Content\\scripts\\backMgr\\backMain.js", FileOperator.ReadFile(path + "Web\\Content\\scripts\\backMgr\\backMain.js").Replace("{BackMainELSEIF}", MenuCfg.ToString()));
                FileOperator.WriteFile(path + "Web\\View\\backMgr.aspx", FileOperator.ReadFile(path + "Web\\View\\backMgr.aspx").Replace("{EXTJS_InsertPoint}", JSLinks.ToString()));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
