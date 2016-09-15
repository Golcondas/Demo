
namespace WebMisDeveloper
{
    class Cmds
    {
        //Access2003连接串
        //public static string AccessConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DataTemplate\Template.mdb;Persist Security Info=True;Jet OLEDB:Database Password=UOIuosdf798qer234";
        //Access2007连接串
        public static string AccessConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DataTemplate\Template.accdb";
        //ConnString Template
        public static string SQLServerString="Data Source=localhost;User ID=sa;Password=password123;";
        public static string OracleString="Data Source=Orcl;User ID=webmis;Password=123456;";
        //public static string AccessString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\data.mdb";
        public static string AccessString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\data.mdb";
        //WizardPage_CfgDB 第一步
        public static string FindAllTemplate = "select * from DBInfo";
        public static string FindTemplateDetails = "select * from DBInfo where DBName='{0}'";
        public static string AddNewDBTemplate = "insert into DBInfo (DBName,DBConnString,DBType) values('{0}','{1}','{2}')";
        public static string DelDBTemplate = "delete from DBInfo where DBName='{0}'";
        public static string DelTableInfo="delete from TableInfo where DBName='{0}'";
        public static string UpdateDBTemplate = "update DBInfo set DBConnString='{0}',DBType='{1}' where DBName='{2}'";

        //WizardPage_Table 第二步
        public static string FindDBTables = "select distinct DBName as 数据库名称,TableName as 表名 from TableInfo where DBName='{0}'";
        public static string DelTableColumn = "delete from TableInfo Where TableName='{0}' and DBName='{1}'";
        //TableInfo
        public static string FindTableInfo = "select FieldName,FieldType,FieldSize,FieldDesc,ISPrimaryKey from TableInfo where TableName='{0}' and DBName='{1}'";
        public static string AddNewTableColumn = "insert into TableInfo (DBName,TableName,FieldName,FieldType,FieldSize,FieldDesc,ISPrimaryKey) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
        public static string InsertIntoUserFun = "insert into userfun values({0},'{1}','{2}',{3})";
        //获得一个数据库的所有表详细信息
        public static string FindAllTable = "select TableName as 表名,FieldName as 字段名称,FieldType as 数据类型,FieldSize as 数据长度,FieldDesc as 字段描述,ISPrimaryKey as 是否主键 from TableInfo Where DBName='{0}'";

        //开发助理
        public static string MSSQLFindAllTable = "select name from dbo.sysobjects where xtype='u' and (not name LIKE 'dtproperties')";
        //Oracle
        public static string OracleFindALlTable = "select TNAME as name from tab";
        //获得用户自定义的链接串
        public static string GetDevHelperConStr = "select * from UserIni where DBType='{0}' and Location='二次开发'";
        public static string SaveDevHeloperConStr = "update UserIni set DBconstring='{0}' where DBType='{1}' and Location='二次开发'";

        //功能菜单树操作
        public static string DelFunMenu = "delete from userfun where DBName='{0}'";
        public static string FindMenu = "select * from userfun where DBName='{0}' order by fatherid asc,funid asc";

        //后台速成
        public static string GetQuickBackConStr = "select * from UserIni where DBType='{0}' and Location='后台速成'";
        public static string SaveQuickBackConStr = "update UserIni set DBconstring='{0}' where DBType='{1}' and Location='后台速成'";
        public static string OracleClearTable = "purge recyclebin";

        //工具
        public static string GetTableColumns = "select FieldName,FieldDesc from TableInfo where TableName='{0}' and DBName='{1}'";
        public static string GetQuickDesignConStr = "select * from UserIni where DBType='{0}' and Location='元素速成'";
        public static string SaveQuickDesignConStr = "update UserIni set DBconstring='{0}' where DBType='{1}' and Location='元素速成'";
        public static string FindALLTables = "select distinct TableName from TableInfo where DBName='{0}'";

        public static string MSSQLFindTableStructs2005 = "SELECT syscolumns.name ,isnull(sys.extended_properties.value,syscolumns.name) "
                                                    + " FROM syscolumns join systypes "
                                                    + " on systypes.xusertype  = syscolumns.xusertype "
                                                    + " left join sys.extended_properties  "
                                                    + " on (sys.extended_properties.major_id=syscolumns.id and sys.extended_properties.minor_id=syscolumns.colid) "
                                                    + " where syscolumns.id = object_id('{0}')";
        public static string MSSQLFindTableStructs2000 = "SELECT syscolumns.name , isnull(sysproperties.value,syscolumns.name) as FieldDesc "
                                                        + " FROM syscolumns join systypes "
                                                        + " on systypes.xusertype  = syscolumns.xusertype"
                                                        + " left join sysproperties "
                                                        + " on (sysproperties.id=syscolumns.id and sysproperties.smallid=syscolumns.colid) "
                                                        + " where syscolumns.id = object_id('{0}')";
        public static string OracleFindTalbeStructs = "select COLUMN_NAME as FieldName,COLUMN_NAME as FieldDesc from ALL_TAB_COLS where TABLE_NAME='{0}'";
    }
}
