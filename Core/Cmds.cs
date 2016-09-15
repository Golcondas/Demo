using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class Cmds
    {
        //Access2007连接串
        public static string AccessConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DataTemplate\Template.accdb";
        //Access2003连接串
        //public static string AccessConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DataTemplate\Template.mdb;Persist Security Info=True;Jet OLEDB:Database Password=UOIuosdf798qer234";
        public static string FindDBConn = "select * from DBInfo where DBName='{0}'";
        public static string MSSQLConn = "";
        //Create Database
        public static string CreateDB = "IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'{0}') Drop DataBase {0};Create DataBase {0};";

        //CreateTable
        public static string FindAllTables = "select distinct TableName,DBType,DBConnString from TableInfo,DBInfo where TableInfo.DBName='{0}' and TableInfo.DBName=DBInfo.DBName";
        public static string FindTableInfo = "select FieldName,FieldType,FieldSize,FieldDesc,ISPrimaryKey from TableInfo where TableName='{0}' and DBName='{1}'";


        public static string SQLBaiscUserInfo = "insert into roles values('1001','超级管理员','具有最高权限');insert into userinfo values('admin','I7CCJ46J;94I:9IFFE=9EF=8=7GHE45I',1,'15825299495','男','山东日照','ovenjackchain@gmail.com','',getdate());insert into rolefun select roles.roleid,userfun.funid,0 from roles,userfun ;";
        public static string DBBaseTable = "if Exists(select name from sysobjects where name='roles') Drop table roles ;create table roles(roleid int identity primary key,roleno nvarchar(20) not null , rolename nvarchar(30) not null,beizhu nvarchar(50));"
                                        + "if Exists(select name from sysobjects where name='userinfo') Drop table userinfo ;create table userinfo(userid int identity primary key, username nvarchar(100) not null,password nvarchar(50) not null,roleid int not null,telephone nvarchar(20) ,usersex nvarchar(4),address nvarchar(100),email nvarchar(100),logintime datetime,createtime datetime);"
                                        + "if Exists(select name from sysobjects where name='userfun') Drop table userfun ;create table userfun(funid int primary key, funno varchar(200) not null, funname varchar(100) not null,fatherid int);"
                                        + "if Exists(select name from sysobjects where name='rolefun') Drop table rolefun ;create table rolefun(pid int identity primary key,roleid int not null,funid int not null, rolep int default 0 );"
                                        + "if Exists(select name from sysobjects where name='newsinfo') Drop table newsinfo ;create table newsinfo (newsid int identity primary key,newsclassify nvarchar(50),newstitle nvarchar(255),newscontent text,newstime datetime,newsowner nvarchar(50),newsdesc nvarchar(255));";

        /***********ORACLE***********************/
        public static string DBBaseTableForOracle = "BEGIN Execute immediate 'create table roles(roleid int primary key,roleno varchar2(20) not null , rolename varchar2(30) not null,beizhu varchar2(50))';"
                                                + "Execute immediate 'create sequence seq_roles increment by 1 start with 1 nomaxvalue nocycle cache 10';"
                                                + "Execute immediate 'create table userinfo(userid int primary key, username varchar2(100) not null,password varchar2(50) not null,roleid int not null,telephone varchar2(20) ,usersex varchar2(4),address varchar2(100),email varchar2(100),logintime varchar2(30),createtime varchar2(30))';"
                                                + "Execute immediate 'create sequence seq_userinfo increment by 1 start with 1 nomaxvalue nocycle cache 10';"
                                                + "Execute immediate 'create table userfun(funid int primary key, funno varchar2(200) not null, funname varchar2(100) not null,fatherid int)';"
                                                + "Execute immediate 'create table rolefun(pid int primary key,roleid int not null,funid int not null, rolep int default 0 )';"
                                                + "Execute immediate 'create sequence seq_rolefun increment by 1 start with 1 nomaxvalue nocycle cache 10';"
                                                + "Execute immediate 'create table newsinfo (newsid int primary key,newsclassify varchar2(50),newstitle varchar2(255),newscontent clob,newstime varchar2(30),newsowner varchar2(50),newsdesc varchar2(255))';"
                                                + "Execute immediate 'create sequence seq_newsinfo increment by 1 start with 1 nomaxvalue nocycle cache 10'; END;";
        public static string DBCreateSeq = "create sequence SEQ_{0} increment by 1 start with 1 nomaxvalue nocycle cache 10";
        public static string OracleBasicData = "BEGIN insert into roles values(seq_roles.nextval,'1001','超级管理员','具有最高权限');insert into userinfo values(seq_userinfo.nextval,'admin','I7CCJ46J;94I:9IFFE=9EF=8=7GHE45I',1,'15825299495','男','山东日照','ovenjackchain@gmail.com','','1987-12-20');insert into rolefun select seq_rolefun.nextval,roles.roleid,userfun.funid,0 from roles,userfun;END;";
        public static string OracleTableExists = "create or replace procedure checkTS(ts in varchar) as snum number;begin  select count(*) into snum from user_sequences where sequence_name= 'SEQ_'||UPPER(ts);  if snum>0 then     begin execute immediate 'drop sequence  SEQ_'||UPPER(ts); end; end if;select count(*) into snum from tab where tname=UPPER(ts);if snum>0 then  begin execute immediate 'drop table  '||UPPER(ts); end; end if; end;";
        public static string OracleDropProc = "Drop procedure checkTS";
        public static string OracleClearTable = "purge recyclebin";
        /***********END***********************/

        public static string Model_Csproj = "<Compile Include=\"Entities\\{0}.cs\" />";
        public static string Hbm_Csproj = "<EmbeddedResource Include=\"Mappings\\{0}.hbm.xml\" />";
        public static string CSproj = "<Compile Include=\"{0}.cs\" />";

        //Dao
        public static string FindAutoID = "select top 1 FieldName from TableInfo  where TableName='{0}' and DBName='{1}'";

        //二次开发
        public static string MSSQLFindTableStructs = "";
        public static string MSSQLFindTableStructs2005 = "SELECT syscolumns.name as FieldName,systypes.name as FieldType, "
                                                    + " syscolumns.length as FieldSize,isnull(sys.extended_properties .value,syscolumns.name) as FieldDesc "
                                                    + " FROM syscolumns join systypes "
                                                    + " on systypes.xusertype  = syscolumns.xusertype "
                                                    + " left join sys.extended_properties  "
                                                    + " on (sys.extended_properties.major_id=syscolumns.id and sys.extended_properties.minor_id=syscolumns.colid) "
                                                    + " where syscolumns.id = object_id('{0}')";
        public static string MSSQLFindTableStructs2000 = "SELECT syscolumns.name as FieldName,systypes.name as FieldType,"
                                                        + "syscolumns.length as FieldSize,isnull(sysproperties.value,syscolumns.name) as FieldDesc "
                                                        + " FROM syscolumns join systypes "
                                                        + " on systypes.xusertype  = syscolumns.xusertype"
                                                        + " left join sysproperties "
                                                        + " on (sysproperties.id=syscolumns.id and sysproperties.smallid=syscolumns.colid) "
                                                        + " where syscolumns.id = object_id('{0}')";

        public static string MSSQLFindAutoID = "select name from syscolumns where id=object_id(N'{0}') and COLUMNPROPERTY(id,name,'IsIdentity')=1";
        public static string OracleFindTalbeStructs = "select COLUMN_NAME as FieldName,DATA_TYPE as FieldType,DATA_LENGTH as FieldSize,COLUMN_NAME as FieldDesc from ALL_TAB_COLS where TABLE_NAME='{0}'";
        //后台速成
        public static string BasicData_MSSQLServer = "insert into userfun values(111,'AutoMenuMgr','自动菜单',0);"
                                                  + "insert into userfun values(112,'newsMgr','信息管理',0);"
                                                  + "insert into userfun values(113,'sysMgr','系统管理',0);"
                                                  + "insert into userfun values(211,'userMgr','用户管理',113);"
                                                  + "insert into userfun values(212,'roleMgr','角色管理',113);"
                                                  + "insert into userfun values(213,'userInfo','个人信息',113);"
                                                  + "insert into userfun values(214,'pwdMgr','修改密码',113);"
                                                  + "insert into userfun values(215,'sysExit','退出系统',113);"
                                                  + "insert into userfun values(221,'publishNews','新闻维护',112);";
        public static string AutoMenu = "insert into userfun values({0},'{1}Menu','{2}表',111)";

        //创建字段说明SQLServer
        public static string ColumnDesc = "EXECUTE  sp_addextendedproperty  N'MS_Description', '{0}',  N'user', N'dbo', N'table', N'{1}', N'column', N'{2}';";
    }
}
