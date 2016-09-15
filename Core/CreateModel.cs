using System;
using System.Collections;
using System.Linq;
using System.Data;
using CJ_DBOperater;
using System.Text;
using System.IO;

/*
 * 陈杰
 * 2009-11-9
 * 为数据库表生成关系映射 
 */
namespace Core
{
    public class CreateModel
    {
        public string TableModel(string path, string dbname)
        {
            try
            {
                //获得Model层的路径
                path = path + "\\WebMisDeveloper\\Model\\";
                //找到库中所有的表,生成实体类和Hbm配置文件
                DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindAllTables, dbname));
                string dbtype = "SQLServer2005";
                if (dt.Rows.Count > 0)
                    dbtype = dt.Rows[0]["DBType"].ToString();
                StringBuilder modelcsproj = new StringBuilder();//插入到csproj
                modelcsproj.AppendLine();
                StringBuilder Hbmcsproj = new StringBuilder();  //插入到csproj，嵌入式xml
                Hbmcsproj.AppendLine();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tablename = dt.Rows[i]["TableName"].ToString();
                    #region 读取该表的详细信息，拼接字符串
                    DataTable tableColumns = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindTableInfo, tablename, dbname));
                    string basicModel = FileOperator.ReadFile(".\\WebBasic\\{tablename}.cs");
                    string basicHbm = FileOperator.ReadFile(".\\WebBasic\\{tablename}.hbm.xml");
                    string model_Constructor = "";//生成Mode
                    StringBuilder model_Property = new StringBuilder();
                    model_Property.AppendLine();
                    StringBuilder model_GetSet = new StringBuilder();
                    model_GetSet.AppendLine();
                    StringBuilder model_SetValue = new StringBuilder();
                    model_SetValue.AppendLine();
                    StringBuilder Hbm = new StringBuilder();  //生成Hbm配置文件
                    Hbm.AppendLine();
                    for (int j = 0; j < tableColumns.Rows.Count; j++)
                    {
                        string Fname = tableColumns.Rows[j]["FieldName"].ToString();
                        string FType ="";
                        if (dbtype == "SQLServer2005")
                            FType = tableColumns.Rows[j]["FieldType"].ToString().ToLower() == "int" ? "int" : "string";
                        else if (dbtype == "Oracle")
                            FType = tableColumns.Rows[j]["FieldType"].ToString().ToLower() == "number" ? "int" : "string";
                        if (j == 0)
                        {
                            Hbm.AppendLine("\t<id name=\"" + Fname.ToLower() + "\" column=\"" + Fname + "\" type=\"Int32\"  length=\"4\" unsaved-value=\"0\">");
                            if (dbtype == "SQLServer2005")
                                Hbm.AppendLine("\t\t<generator class=\"native\" />");
                            else if (dbtype == "Oracle")
                            {
                                Hbm.AppendLine("\t\t<generator class=\"sequence\" >");
                                Hbm.AppendLine("\t\t\t<param name=\"sequence\">SEQ_"+tablename.ToUpper()+"</param>");
                                Hbm.AppendLine("\t\t</generator>");
                            }
                            Hbm.AppendLine("\t</id>");
                        }
                        else
                        {
                            Hbm.AppendLine("\t<property name=\"" + Fname.ToLower() + "\" column=\"" + Fname + "\" type=\"" + FType + "\" />");
                        }
                        model_Property.AppendLine("\t\tprivate " + FType + " _" + Fname.ToLower() + ";");
                        model_GetSet.AppendLine("\t\t/// <summary>" + tableColumns.Rows[j]["FieldDesc"].ToString() + "</summary>");
                        model_GetSet.AppendLine("\t\tpublic " + FType + " " + Fname.ToLower());
                        model_GetSet.AppendLine("\t\t{");
                        model_GetSet.AppendLine("\t\t\tget { return _" + Fname.ToLower() + " ; }");
                        model_GetSet.AppendLine("\t\t\tset { _" + Fname.ToLower() + " = value ; }");
                        model_GetSet.AppendLine("\t\t}");
                        model_GetSet.AppendLine();
                        model_SetValue.AppendLine("\t\tthis._" + Fname.ToLower() + " = " + Fname.ToLower() + ";");
                        model_Constructor += FType + " " + Fname.ToLower() + ",";
                    }
                    #endregion
                    //保存实体类文件和Nhibernate配置文件
                    basicModel = basicModel.Replace("{0}", tablename.ToLower()).Replace("{1}", model_Constructor.TrimEnd(',')).Replace("{2}", model_SetValue.ToString()).Replace("{3}", model_Property.ToString()).Replace("{4}", model_GetSet.ToString());
                    basicHbm = basicHbm.Replace("{0}", tablename.ToLower()).Replace("{1}", tablename).Replace("{2}", Hbm.ToString());
                    FileOperator.WriteFile(path + "Entities\\" + tablename.ToLower() + ".cs", basicModel);
                    FileOperator.WriteFile(path + "Mappings\\" + tablename.ToLower() + ".hbm.xml", basicHbm);
                    //读取csproj文件，将文件添加到解决方案
                    modelcsproj.AppendLine(string.Format("\t"+Cmds.Model_Csproj, tablename.ToLower()));
                    Hbmcsproj.AppendLine(string.Format("\t" + Cmds.Hbm_Csproj, tablename.ToLower()));
                }
                FileOperator.WriteFile(path + "Model.csproj", FileOperator.ReadFile(path + "Model.csproj").Replace("{ModelEntityInsertPoint}", modelcsproj.ToString()).Replace("{ModelHBMInsertPoint}", Hbmcsproj.ToString()));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        //二次开发页面，生成Model
        public string BuildModel(string path, ArrayList tablelist, string dbtype)
        {
            try
            {
                path = path + "\\Model\\";
                StringBuilder modelcsproj = new StringBuilder();//插入到csproj
                modelcsproj.AppendLine();
                StringBuilder Hbmcsproj = new StringBuilder();  //插入到csproj，嵌入式xml
                Hbmcsproj.AppendLine();
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    DataTable tableColumns=null;
                    if (dbtype == "SQLServer2005")
                        tableColumns = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindTableStructs, tablename));
                    else if (dbtype == "Oracle")
                        tableColumns = CJ.Oracle_ReturnDataTable(string.Format(Cmds.OracleFindTalbeStructs, tablename.ToUpper()));
                    string basicModel = FileOperator.ReadFile(".\\WebBasic\\{tablename}.cs");
                    string basicHbm = FileOperator.ReadFile(".\\WebBasic\\{tablename}.hbm.xml");
                    string model_Constructor = "";//生成Mode
                    StringBuilder model_Property = new StringBuilder();
                    model_Property.AppendLine();
                    StringBuilder model_GetSet = new StringBuilder();
                    model_GetSet.AppendLine();
                    StringBuilder model_SetValue = new StringBuilder();
                    model_SetValue.AppendLine();
                    StringBuilder Hbm = new StringBuilder();  //生成Hbm配置文件
                    Hbm.AppendLine();
                    string AutoID = "";
                    if (dbtype == "SQLServer2005")
                    {
                        DataTable dtautoid = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindAutoID, tablename));
                        if (dtautoid.Rows.Count > 0)
                            AutoID = dtautoid.Rows[0][0].ToString();
                        else
                            AutoID = tableColumns.Rows[0]["FieldName"].ToString();
                    }
                    else if (dbtype == "Oracle")
                        AutoID = tableColumns.Rows[0]["FieldName"].ToString();
                    for (int j = 0; j < tableColumns.Rows.Count; j++)
                    {
                        string Fname = tableColumns.Rows[j]["FieldName"].ToString();
                        string FType ="";
                        if (dbtype == "SQLServer2005")
                            FType = tableColumns.Rows[j]["FieldType"].ToString().ToLower() == "int" ? "int" : "string";
                        else if (dbtype == "Oracle")
                            FType = tableColumns.Rows[j]["FieldType"].ToString().ToLower() == "number" ? "int" : "string";
                        if (Fname==AutoID)
                        {
                            Hbm.AppendLine("\t<id name=\"" + Fname.ToLower() + "\" column=\"" + Fname + "\" type=\"Int32\"  length=\"4\" unsaved-value=\"0\">");
                            if (dbtype == "SQLServer2005")
                                Hbm.AppendLine("\t\t<generator class=\"native\" />");
                            else if (dbtype == "Oracle")
                            {
                                Hbm.AppendLine("\t\t<generator class=\"sequence\" >");
                                Hbm.AppendLine("\t\t\t<param name=\"sequence\">SEQ_" + tablename.ToUpper() + "</param>");
                                Hbm.AppendLine("\t\t</generator>");
                            }
                            Hbm.AppendLine("\t</id>");
                        }
                        else
                        {
                            Hbm.AppendLine("\t<property name=\"" + Fname.ToLower() + "\" column=\"" + Fname + "\" type=\"" + FType + "\" />");
                        }
                        model_Property.AppendLine("\t\tprivate " + FType + " _" + Fname.ToLower() + ";");
                        model_GetSet.AppendLine("\t\tpublic " + FType + " " + Fname.ToLower());
                        model_GetSet.AppendLine("\t\t{");
                        model_GetSet.AppendLine("\t\t\tget { return _" + Fname.ToLower() + " ; }");
                        model_GetSet.AppendLine("\t\t\tset { _" + Fname.ToLower() + " = value ; }");
                        model_GetSet.AppendLine("\t\t}");
                        model_GetSet.AppendLine();
                        model_SetValue.AppendLine("\t\tthis._" + Fname.ToLower() + " = " + Fname.ToLower() + ";");
                        model_Constructor += FType + " " + Fname.ToLower() + ",";
                    }
                    //产生model和Hbm
                    basicModel = basicModel.Replace("{0}", tablename.ToLower()).Replace("{1}", model_Constructor.TrimEnd(',')).Replace("{2}", model_SetValue.ToString()).Replace("{3}", model_Property.ToString()).Replace("{4}", model_GetSet.ToString());
                    basicHbm = basicHbm.Replace("{0}", tablename.ToLower()).Replace("{1}", tablename).Replace("{2}", Hbm.ToString());
                    FileOperator.WriteFile(path + "Entities\\" + tablename.ToLower() + ".cs", basicModel);
                    FileOperator.WriteFile(path + "Mappings\\" + tablename.ToLower() + ".hbm.xml", basicHbm);
                    //添加生成的Model到csproj
                    modelcsproj.AppendLine(string.Format("\t" + Cmds.Model_Csproj, tablename.ToLower()));
                    Hbmcsproj.AppendLine(string.Format("\t" + Cmds.Hbm_Csproj, tablename.ToLower()));
                    //如果为oracle数据库要创建自增序列
                    try
                    {
                        if (dbtype == "Oracle")
                            CJ.Oracle_ExecuteNonQuery(string.Format(Cmds.DBCreateSeq, tablename));
                    }
                    catch { }
               }
                FileOperator.WriteFile(path + "Model.csproj", FileOperator.ReadFile(path + "Model.csproj").Replace("<!--DHELPERMODELE-->", modelcsproj.ToString()+"<!--DHELPERMODELE-->").Replace("<!--DHELPERMODELH-->", Hbmcsproj.ToString()+"<!--DHELPERMODELH-->"));
                
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //后台速成
        public string BuildModel(ArrayList tablelist,string path,string dbtype)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\Model\\";
                //找到库中所有的表,生成实体类和Hbm配置文件
                StringBuilder modelcsproj = new StringBuilder();//插入到csproj
                modelcsproj.AppendLine();
                StringBuilder Hbmcsproj = new StringBuilder();  //插入到csproj，嵌入式xml
                Hbmcsproj.AppendLine();
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    DataTable tableColumns = null;
                    if (dbtype == "SQLServer2005")
                        tableColumns = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindTableStructs, tablename));
                    else if (dbtype == "Oracle")
                        tableColumns = CJ.Oracle_ReturnDataTable(string.Format(Cmds.OracleFindTalbeStructs, tablename.ToUpper()));
                    string basicModel = FileOperator.ReadFile(".\\WebBasic\\{tablename}.cs");
                    string basicHbm = FileOperator.ReadFile(".\\WebBasic\\{tablename}.hbm.xml");
                    string model_Constructor = "";//生成Mode
                    StringBuilder model_Property = new StringBuilder();
                    model_Property.AppendLine();
                    StringBuilder model_GetSet = new StringBuilder();
                    model_GetSet.AppendLine();
                    StringBuilder model_SetValue = new StringBuilder();
                    model_SetValue.AppendLine();
                    StringBuilder Hbm = new StringBuilder();  //生成Hbm配置文件
                    Hbm.AppendLine();
                    string AutoID = "";
                    if (dbtype == "SQLServer2005")
                    {
                        DataTable dtautoid = CJ.SQL_ReturnDataTable(string.Format(Cmds.MSSQLFindAutoID, tablename));
                        if (dtautoid.Rows.Count > 0)
                            AutoID = dtautoid.Rows[0][0].ToString();
                        else
                            AutoID = tableColumns.Rows[0]["FieldName"].ToString();
                    }
                    else if (dbtype == "Oracle")
                        AutoID = tableColumns.Rows[0]["FieldName"].ToString();
                    
                    for (int j = 0; j < tableColumns.Rows.Count; j++)
                    {
                        string Fname = tableColumns.Rows[j]["FieldName"].ToString();
                        string FType = "";
                        if (dbtype == "SQLServer2005")
                            FType = tableColumns.Rows[j]["FieldType"].ToString().ToLower() == "int" ? "int" : "string";
                        else if (dbtype == "Oracle")
                            FType = tableColumns.Rows[j]["FieldType"].ToString().ToLower() == "number" ? "int" : "string";
                        if (Fname == AutoID)
                        {
                            Hbm.AppendLine("\t<id name=\"" + Fname.ToLower() + "\" column=\"" + Fname + "\" type=\"Int32\"  length=\"4\" unsaved-value=\"0\">");
                            if (dbtype == "SQLServer2005")
                                Hbm.AppendLine("\t\t<generator class=\"native\" />");
                            else if (dbtype == "Oracle")
                            {
                                Hbm.AppendLine("\t\t<generator class=\"sequence\" >");
                                Hbm.AppendLine("\t\t\t<param name=\"sequence\">SEQ_" + tablename.ToUpper() + "</param>");
                                Hbm.AppendLine("\t\t</generator>");
                            }
                            Hbm.AppendLine("\t</id>");
                        }
                        else
                        {
                            Hbm.AppendLine("\t<property name=\"" + Fname.ToLower() + "\" column=\"" + Fname + "\" type=\"" + FType + "\" />");
                        }
                        model_Property.AppendLine("\t\tprivate " + FType + " _" + Fname.ToLower() + ";");
                        model_GetSet.AppendLine("\t\tpublic " + FType + " " + Fname.ToLower());
                        model_GetSet.AppendLine("\t\t{");
                        model_GetSet.AppendLine("\t\t\tget { return _" + Fname.ToLower() + " ; }");
                        model_GetSet.AppendLine("\t\t\tset { _" + Fname.ToLower() + " = value ; }");
                        model_GetSet.AppendLine("\t\t}");
                        model_GetSet.AppendLine();
                        model_SetValue.AppendLine("\t\tthis._" + Fname.ToLower() + " = " + Fname.ToLower() + ";");
                        model_Constructor += FType + " " + Fname.ToLower() + ",";
                    }
                    //产生model和Hbm
                    basicModel = basicModel.Replace("{0}", tablename.ToLower()).Replace("{1}", model_Constructor.TrimEnd(',')).Replace("{2}", model_SetValue.ToString()).Replace("{3}", model_Property.ToString()).Replace("{4}", model_GetSet.ToString());
                    basicHbm = basicHbm.Replace("{0}", tablename.ToLower()).Replace("{1}", tablename).Replace("{2}", Hbm.ToString());
                    FileOperator.WriteFile(path + "Entities\\" + tablename.ToLower() + ".cs", basicModel);
                    FileOperator.WriteFile(path + "Mappings\\" + tablename.ToLower() + ".hbm.xml", basicHbm);
                    //添加生成的Model到csproj
                    modelcsproj.AppendLine(string.Format("\t" + Cmds.Model_Csproj, tablename.ToLower()));
                    Hbmcsproj.AppendLine(string.Format("\t" + Cmds.Hbm_Csproj, tablename.ToLower()));
                    //如果为oracle数据库要创建自增序列
                    try
                    {
                        if (dbtype == "Oracle")
                            CJ.Oracle_ExecuteNonQuery(string.Format(Cmds.DBCreateSeq, tablename));
                    }
                    catch { }
                }
                FileOperator.WriteFile(path + "Model.csproj", FileOperator.ReadFile(path + "Model.csproj").Replace("{ModelEntityInsertPoint}", modelcsproj.ToString()).Replace("{ModelHBMInsertPoint}", Hbmcsproj.ToString()));
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
