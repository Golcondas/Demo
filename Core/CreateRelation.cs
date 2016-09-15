using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CJ_DBOperater;
using System.IO;
using System.Collections;

/*
 * 陈杰
 * 2009-11-9
 * 为各层之间建立关系 
 */
namespace Core
{
    public class CreateRelation
    {
        public string BuildRelationShip(string path, string dbname)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                string DBType = "",DBConnection="";
                DataTable dt = CJ.OtherDB_ReturnDataTable(string.Format(Cmds.FindAllTables, dbname));
                if (dt.Rows.Count > 0)
                {
                    DBType = dt.Rows[0]["DBType"].ToString();
                    if (DBType == "SQLServer2005")
                        DBConnection = dt.Rows[0]["DBConnString"].ToString() + "DataBase=" + dbname + ";";
                    else if (DBType == "Oracle")
                        DBConnection = dt.Rows[0]["DBConnString"].ToString();
                }
                StringBuilder ServiceProperty=new StringBuilder();
                ServiceProperty.AppendLine();
                StringBuilder ServiceTrans=new StringBuilder();
                ServiceTrans.AppendLine();
                StringBuilder DAOXml=new StringBuilder();
                DAOXml.AppendLine();
                StringBuilder ObjectProperty=new StringBuilder();
                ObjectProperty.AppendLine();
                StringBuilder ObjectController=new StringBuilder();
                ObjectController.AppendLine();
                StringBuilder DTOMgr = new StringBuilder();
                DTOMgr.AppendLine();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tablename = dt.Rows[i]["TableName"].ToString();

                    ServiceProperty.AppendLine("\t<object id=\"" + tablename.ToLower() + "Mgr\" type=\"BLL." + tablename.ToLower() + "Mgr,BLL\">");
                    ServiceProperty.AppendLine("\t\t<property name=\"" + tablename.ToLower() + "Dao\" ref=\"" + tablename.ToLower() + "Dao\"/>");
                    ServiceProperty.AppendLine("\t</object>");

                    ServiceTrans.AppendLine("\t<object id=\"" + tablename.ToLower() + "MgrTrans\" parent=\"BaseTransactionManager\">");
                    ServiceTrans.AppendLine("\t\t<property name=\"Target\" ref=\"" + tablename.ToLower() + "Mgr\"/>");
                    ServiceTrans.AppendLine("\t</object>");
                    
                    DAOXml.AppendLine("\t<object id=\"" + tablename.ToLower() + "Dao\" type=\"DAO." + tablename.ToLower() + "Dao, DAO\">");
                    DAOXml.AppendLine("\t\t<property name=\"HibernateTemplate\" ref=\"HibernateTemplate\"/>");
                    DAOXml.AppendLine("\t</object>");
                    DAOXml.AppendLine();

                    ObjectController.AppendLine("\t\t<object id=\"" + tablename.ToLower() + "Controller\" singleton=\"false\" type=\"Controllers." + tablename.ToLower() + "Controller,Controllers\"></object>");
                    ObjectProperty.AppendLine("\t\t<property name=\"" + tablename.ToLower() + "Mgr\" ref=\"" + tablename.ToLower() + "MgrTrans\"/>");

                    DTOMgr.AppendLine("\t\tpublic I" + tablename.ToLower() + "Mgr " + tablename.ToLower() + "Mgr { get; set;}");
                }
                //开始替换
                FileOperator.WriteFile(path + "App_Cfg\\Dao.xml", FileOperator.ReadFile(path + "App_Cfg\\Dao.xml").Replace("{DATABASECONNSTRING}", DBConnection).Replace("{DAOXMLInsertPoint}", DAOXml.ToString()));
                FileOperator.WriteFile(path + "App_Cfg\\Services.xml", FileOperator.ReadFile(path + "App_Cfg\\Services.xml").Replace("{SERVERCESXMLProperty}", ServiceProperty.ToString()).Replace("{SERVERCESXMLTrans}", ServiceTrans.ToString()));

                FileOperator.WriteFile(path + "Controllers\\objects.xml", FileOperator.ReadFile(path + "Controllers\\objects.xml").Replace("{OBJECTSXMLProperty}", ObjectProperty.ToString()).Replace("{OBJECTSXMLController}", ObjectController.ToString()));
                FileOperator.WriteFile(path + "DTO\\ManagerFactory.cs", FileOperator.ReadFile(path + "DTO\\ManagerFactory.cs").Replace("{DTOMgr}", DTOMgr.ToString()));
                DeleteFiles();
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //二次开发
        public string BuildRelationShip(string path, ArrayList tablelist)
        {
            try
            {
                StringBuilder ServiceProperty = new StringBuilder();
                ServiceProperty.AppendLine();
                StringBuilder ServiceTrans = new StringBuilder();
                ServiceTrans.AppendLine();
                StringBuilder DAOXml = new StringBuilder();
                DAOXml.AppendLine();
                StringBuilder ObjectProperty = new StringBuilder();
                ObjectProperty.AppendLine();
                StringBuilder ObjectController = new StringBuilder();
                ObjectController.AppendLine();
                StringBuilder DTOMgr = new StringBuilder();
                DTOMgr.AppendLine();
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();
                    ServiceProperty.AppendLine("\t<object id=\"" + tablename.ToLower() + "Mgr\" type=\"BLL." + tablename.ToLower() + "Mgr,BLL\">");
                    ServiceProperty.AppendLine("\t\t<property name=\"" + tablename.ToLower() + "Dao\" ref=\"" + tablename.ToLower() + "Dao\"/>");
                    ServiceProperty.AppendLine("\t</object>");

                    ServiceTrans.AppendLine("\t<object id=\"" + tablename.ToLower() + "MgrTrans\" parent=\"BaseTransactionManager\">");
                    ServiceTrans.AppendLine("\t\t<property name=\"Target\" ref=\"" + tablename.ToLower() + "Mgr\"/>");
                    ServiceTrans.AppendLine("\t</object>");

                    DAOXml.AppendLine("\t<object id=\"" + tablename.ToLower() + "Dao\" type=\"DAO." + tablename.ToLower() + "Dao, DAO\">");
                    DAOXml.AppendLine("\t\t<property name=\"HibernateTemplate\" ref=\"HibernateTemplate\"/>");
                    DAOXml.AppendLine("\t</object>");
                    DAOXml.AppendLine();

                    ObjectController.AppendLine("\t\t<object id=\"" + tablename.ToLower() + "Controller\" singleton=\"false\" type=\"Controllers." + tablename.ToLower() + "Controller,Controllers\"></object>");
                    ObjectProperty.AppendLine("\t\t<property name=\"" + tablename.ToLower() + "Mgr\" ref=\"" + tablename.ToLower() + "MgrTrans\"/>");

                    DTOMgr.AppendLine("\t\tpublic I" + tablename.ToLower() + "Mgr " + tablename.ToLower() + "Mgr { get; set;}");
                }
                //开始替换
                FileOperator.WriteFile(path + "\\App_Cfg\\Dao.xml", FileOperator.ReadFile(path + "\\App_Cfg\\Dao.xml").Replace("<!--DHELPERDAO-->", DAOXml.ToString()+"<!--DHELPERDAO-->"));
                FileOperator.WriteFile(path + "\\App_Cfg\\Services.xml", FileOperator.ReadFile(path + "\\App_Cfg\\Services.xml").Replace("<!--DHELPERSERVERCES1-->", ServiceProperty.ToString() + "<!--DHELPERSERVERCES1-->").Replace("<!--DHELPERSERVERCES2-->", ServiceTrans.ToString()+"<!--DHELPERSERVERCES2-->"));

                FileOperator.WriteFile(path + "\\Controllers\\objects.xml", FileOperator.ReadFile(path + "\\Controllers\\objects.xml").Replace("<!--DHELPEROBJECTS1-->", ObjectProperty.ToString() + "<!--DHELPEROBJECTS1-->").Replace("<!--DHELPEROBJECTS2-->", ObjectController.ToString()+"<!--DHELPEROBJECTS2-->"));
                FileOperator.WriteFile(path + "\\DTO\\ManagerFactory.cs", FileOperator.ReadFile(path + "\\DTO\\ManagerFactory.cs").Replace("//DHELPERDTO", DTOMgr.ToString()+"//DHELPERDTO"));
                DeleteFiles();
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //后台速成
        public string BuildRelationShip(ArrayList tablelist, string path)
        {
            try
            {
                path = path + "\\WebMisDeveloper\\";
                StringBuilder ServiceProperty = new StringBuilder();
                ServiceProperty.AppendLine();
                StringBuilder ServiceTrans = new StringBuilder();
                ServiceTrans.AppendLine();
                StringBuilder DAOXml = new StringBuilder();
                DAOXml.AppendLine();
                StringBuilder ObjectProperty = new StringBuilder();
                ObjectProperty.AppendLine();
                StringBuilder ObjectController = new StringBuilder();
                ObjectController.AppendLine();
                StringBuilder DTOMgr = new StringBuilder();
                DTOMgr.AppendLine();
                for (int i = 0; i < tablelist.Count; i++)
                {
                    string tablename = tablelist[i].ToString();

                    ServiceProperty.AppendLine("\t<object id=\"" + tablename.ToLower() + "Mgr\" type=\"BLL." + tablename.ToLower() + "Mgr,BLL\">");
                    ServiceProperty.AppendLine("\t\t<property name=\"" + tablename.ToLower() + "Dao\" ref=\"" + tablename.ToLower() + "Dao\"/>");
                    ServiceProperty.AppendLine("\t</object>");

                    ServiceTrans.AppendLine("\t<object id=\"" + tablename.ToLower() + "MgrTrans\" parent=\"BaseTransactionManager\">");
                    ServiceTrans.AppendLine("\t\t<property name=\"Target\" ref=\"" + tablename.ToLower() + "Mgr\"/>");
                    ServiceTrans.AppendLine("\t</object>");

                    DAOXml.AppendLine("\t<object id=\"" + tablename.ToLower() + "Dao\" type=\"DAO." + tablename.ToLower() + "Dao, DAO\">");
                    DAOXml.AppendLine("\t\t<property name=\"HibernateTemplate\" ref=\"HibernateTemplate\"/>");
                    DAOXml.AppendLine("\t</object>");
                    DAOXml.AppendLine();

                    ObjectController.AppendLine("\t\t<object id=\"" + tablename.ToLower() + "Controller\" singleton=\"false\" type=\"Controllers." + tablename.ToLower() + "Controller,Controllers\"></object>");
                    ObjectProperty.AppendLine("\t\t<property name=\"" + tablename.ToLower() + "Mgr\" ref=\"" + tablename.ToLower() + "MgrTrans\"/>");

                    DTOMgr.AppendLine("\t\tpublic I" + tablename.ToLower() + "Mgr " + tablename.ToLower() + "Mgr { get; set;}");
                }
                //开始替换
                FileOperator.WriteFile(path + "App_Cfg\\Dao.xml", FileOperator.ReadFile(path + "App_Cfg\\Dao.xml").Replace("{DATABASECONNSTRING}", Core.Cmds.MSSQLConn).Replace("{DAOXMLInsertPoint}", DAOXml.ToString()));
                FileOperator.WriteFile(path + "App_Cfg\\Services.xml", FileOperator.ReadFile(path + "App_Cfg\\Services.xml").Replace("{SERVERCESXMLProperty}", ServiceProperty.ToString()).Replace("{SERVERCESXMLTrans}", ServiceTrans.ToString()));

                FileOperator.WriteFile(path + "Controllers\\objects.xml", FileOperator.ReadFile(path + "Controllers\\objects.xml").Replace("{OBJECTSXMLProperty}", ObjectProperty.ToString()).Replace("{OBJECTSXMLController}", ObjectController.ToString()));
                FileOperator.WriteFile(path + "DTO\\ManagerFactory.cs", FileOperator.ReadFile(path + "DTO\\ManagerFactory.cs").Replace("{DTOMgr}", DTOMgr.ToString()));
                DeleteFiles();
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //删除文件
        public void DeleteFiles()
        {
            try
            {
                File.Delete(".\\WebBasic\\I{tablename}Dao.cs");
                File.Delete(".\\WebBasic\\I{tablename}Mgr.cs");
                File.Delete(".\\WebBasic\\{tablename}.cs");
                File.Delete(".\\WebBasic\\{tablename}.hbm.xml");
                File.Delete(".\\WebBasic\\{tablename}Controller.cs");
                File.Delete(".\\WebBasic\\{tablename}Dao.cs");
                File.Delete(".\\WebBasic\\{tablename}Grid.js");
                File.Delete(".\\WebBasic\\{tablename}Mgr.cs");
                File.Delete(".\\WebBasic\\{tablename}Win.js");
                File.Delete(".\\WebBasic\\Dao.xml");
                File.Delete(".\\WebBasic\\newsInfo.hbm.xml");
                File.Delete(".\\WebBasic\\oracle{tablename}Dao.cs");
                File.Delete(".\\WebBasic\\rolefun.hbm.xml");
                File.Delete(".\\WebBasic\\roles.hbm.xml");
                File.Delete(".\\WebBasic\\userinfo.hbm.xml");
                File.Delete(".\\WebBasic\\newsinfoDao.cs");
                File.Delete(".\\WebBasic\\{S_tablename}.cs");
                File.Delete(".\\WebBasic\\{S_tablename}Controller.cs");
                File.Delete(".\\WebBasic\\{S_tablename}Dao.cs");
                File.Delete(".\\WebBasic\\{S_tablename}Mgr.cs");
            }
            catch
            {

            }
        }
    }
}
