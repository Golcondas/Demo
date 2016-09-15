using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CJ_DBOperater;
using System.Data.OracleClient;

/*
 * 陈杰
 * 2009-11-9
 * 创建表 
 */
namespace Core
{
    public class CreateTables
    {
        public string AddTables(string dbname)
        {
            try
            {
                string DBType = "";
                DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindAllTables, dbname));
                if (dt.Rows.Count > 0)
                {
                    DBType = dt.Rows[0]["DBType"].ToString();
                    if (DBType == "SQLServer2005")//判断数据库类型，不同数据库对应的sql不同
                    {
                        CJ.sqlconn_str = dt.Rows[0]["DBConnString"].ToString() + "DataBase=" + dbname + ";";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string tableName = dt.Rows[i]["TableName"].ToString();
                            //根据数据库名称和表名称获得该表的详细信息
                            DataTable tableinfo = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindTableInfo, tableName, dbname));
                            if (tableinfo.Rows.Count > 0)
                            {
                                #region 循环表的列，根据表的列创建sql语句，形如Create table (...)
                                string CreateSql = "if Exists(select   name   from   sysobjects   where   name='" + tableName + "') Drop table " + tableName + " ;";
                                string PK = " primary key(";
                                string columndesc = "";
                                CreateSql += " Create table " + tableName + " (";
                                for (int j = 0; j < tableinfo.Rows.Count; j++)
                                {
                                    string ctype = tableinfo.Rows[j]["FieldType"].ToString();
                                    string ispk = tableinfo.Rows[j]["ISPrimaryKey"].ToString();
                                    if (ispk == "True")
                                        PK += tableinfo.Rows[j]["FieldName"].ToString() + ",";
                                    if (j == 0)
                                        CreateSql += tableinfo.Rows[j]["FieldName"].ToString() + " int identity not null,";
                                    else
                                    {
                                        if (ctype == "int" || ctype == "Text" || ctype == "DateTime")
                                            CreateSql += tableinfo.Rows[j]["FieldName"].ToString() + " " + tableinfo.Rows[j]["FieldType"].ToString() + " ,";
                                        else
                                            CreateSql += tableinfo.Rows[j]["FieldName"].ToString() + " " + tableinfo.Rows[j]["FieldType"].ToString() + "(" + tableinfo.Rows[j]["FieldSize"].ToString() + ") ,";
                                    }
                                    columndesc += string.Format(Cmds.ColumnDesc, tableinfo.Rows[j]["FieldDesc"].ToString(), tableName, tableinfo.Rows[j]["FieldName"].ToString());
                                }
                                CreateSql += PK.TrimEnd(',') + ") );";
                                #endregion
                                CJ.SQL_ExecuteNonQuery(CreateSql);//执行建表语句
                                CJ.SQL_ExecuteNonQuery(columndesc);
                            }
                        }
                        CJ.SQL_ExecuteNonQuery(Cmds.DBBaseTable);//执行基本表的创建
                    }
                    else if (DBType == "Oracle")
                    {
                        //创建数据库表
                        CJ.oracleconn_str = dt.Rows[0]["DBConnString"].ToString();
                        CJ.Oracle_ExecuteNonQuery(Cmds.OracleTableExists.Replace("r\n", " ").Replace('\n', ' '));
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string tableName = dt.Rows[i]["TableName"].ToString();
                            DataTable tableinfo = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindTableInfo, tableName, dbname));
                            if (tableinfo.Rows.Count > 0)
                            {
                                string CreateSql = "";// "if Exists(select   name   from   sysobjects   where   name='" + tableName + "') Drop table " + tableName + " ;";判断表是否存在
                                string PK = " primary key(";
                                CreateSql += "Create table " + tableName + " (";
                                for (int j = 0; j < tableinfo.Rows.Count; j++)
                                {
                                    string ctype = tableinfo.Rows[j]["FieldType"].ToString();
                                    string ispk = tableinfo.Rows[j]["ISPrimaryKey"].ToString();
                                    if (ispk == "True")
                                        PK += tableinfo.Rows[j]["FieldName"].ToString() + ",";
                                    if (j == 0)
                                        CreateSql += tableinfo.Rows[j]["FieldName"].ToString() + " int not null,";
                                    else
                                    {
                                        if (ctype == "int" || ctype == "clob" )
                                            CreateSql += tableinfo.Rows[j]["FieldName"].ToString() + " " + tableinfo.Rows[j]["FieldType"].ToString() + " ,";
                                        else
                                            CreateSql += tableinfo.Rows[j]["FieldName"].ToString() + " " + tableinfo.Rows[j]["FieldType"].ToString() + "(" + tableinfo.Rows[j]["FieldSize"].ToString() + ") ,";
                                    }
                                }
                                CreateSql += PK.TrimEnd(',') + ") )";
                                CheckTableExists(tableName);
                                CJ.Oracle_ExecuteNonQuery(CreateSql);
                                CJ.Oracle_ExecuteNonQuery(string.Format(Cmds.DBCreateSeq, tableName));//执行建表语句
                            }
                        }
                        checkBasicTables();
                        CJ.Oracle_ExecuteNonQuery(Cmds.DBBaseTableForOracle.Replace("r\n", " ").Replace('\n', ' '));
                        CJ.Oracle_ExecuteNonQuery(Cmds.OracleDropProc);
                        CJ.Oracle_ExecuteNonQuery(Cmds.OracleClearTable);
                    }                    
                }
                else
                {
                    return "数据库为空，生成失败，请保证数据库至少有一个表存在！";
                }
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //后台速成，创建四张基础表
        public string BuildTables(string dbtype)
        {
            try
            {
                if (dbtype == "SQLServer2005")
                    CJ.SQL_ExecuteNonQuery(Cmds.DBBaseTable);
                else if (dbtype == "Oracle")
                {
                    CJ.Oracle_ExecuteNonQuery(Cmds.OracleTableExists.Replace("r\n", " ").Replace('\n', ' '));//创建存储过程
                    checkBasicTables();
                    CJ.Oracle_ExecuteNonQuery(Cmds.DBBaseTableForOracle.Replace("r\n", " ").Replace('\n', ' '));
                    CJ.Oracle_ExecuteNonQuery(Cmds.OracleDropProc);//删除存储过程
                    CJ.Oracle_ExecuteNonQuery(Cmds.OracleClearTable);
                }
                return "OK";
            }
            catch (Exception e)
            { return e.Message.ToString(); }
        }
        private void checkBasicTables()
        {
            CheckTableExists("userfun");
            CheckTableExists("userinfo");
            CheckTableExists("roles");
            CheckTableExists("rolefun");
            CheckTableExists("newsinfo");
        }
        //oracle检查表是否存在，存在则删除
        private void CheckTableExists(string tablename)
        {
            try
            {
                OracleConnection oc = new OracleConnection(CJ.oracleconn_str);
                oc.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHECKTS";
                cmd.Connection = oc;
                cmd.Parameters.Add(new OracleParameter("ts", tablename));
                cmd.ExecuteNonQuery();
                oc.Close();
            }
            catch { }
        }
    }
}
