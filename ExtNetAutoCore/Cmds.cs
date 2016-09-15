using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtNetAutoCore
{
    public class Cmds
    {
        //Access2007连接串
        public static string AccessConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DataTemplate\Template.accdb";
        //Access2003连接串
        //public static string AccessConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DataTemplate\Template.mdb;Persist Security Info=True;Jet OLEDB:Database Password=UOIuosdf798qer234";
        public static string FindDBConn = "select * from DBInfo where DBName='{0}'";

        //CreateTable
        public static string FindAllTables = "select distinct TableName,DBType,DBConnString from TableInfo,DBInfo where TableInfo.DBName='{0}' and TableInfo.DBName=DBInfo.DBName";
        public static string FindTableInfo = "select FieldName,FieldType,FieldSize,FieldDesc,ISPrimaryKey from TableInfo where TableName='{0}' and DBName='{1}'";

        public static string Model_Csproj = "<Compile Include=\"Entities\\{0}.cs\" />";
        public static string CSproj = "<Compile Include=\"{0}.cs\" />";
        public static string WCSproj = "<Content Include=\"View\\{0}Menu\\Default.aspx\" />";
        public static string WebCSProj = "<Compile Include=\"View\\{0}Menu\\Default.aspx.cs\">"
                                    + "<DependentUpon>Default.aspx</DependentUpon>"
                                    + "</Compile>"
                                    + "<Compile Include=\"View\\{0}Menu\\Default.aspx.designer.cs\">"
                                      + "<DependentUpon>Default.aspx</DependentUpon>"
                                      + "<SubType>ASPXCodeBehind</SubType>"
                                      + "</Compile>";
        public static string MenuIcon = ".icon-{0}Menu{background-image:url(/view/images/icons/{0}Menu.png) !important;}";
        public static string WinSetValue = "{0}.setValue({1}_MainStore.getAt(index).get('{2}'));";
        public static string StoreReader="<ext:RecordField Name=\"{0}\" />";
        public static string Columns="<ext:Column Header=\"{0}\" Sortable=\"true\" DataIndex=\"{1}\" />";
        public static string Filter="<ext:StringFilter DataIndex=\"{0}\" />";
        public static string TxtFields = "<ext:TextField ID=\"{0}\" AnchorHorizontal=\"92%\" runat=\"server\" AllowBlank=\"false\" EmptyText=\"该项不可为空\" FieldLabel=\"{1}\" />";
        public static string NumberField = "<ext:NumberField ID=\"{0}\" AnchorHorizontal=\"92%\" runat=\"server\" AllowBlank=\"false\" EmptyText=\"该项不可为空\" FieldLabel=\"{1}\" />";
        public static string DateField = "<ext:DateField  ID=\"{0}\"  runat=\"server\"  FieldLabel=\"{1}\" AnchorHorizontal=\"92%\" />";
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

        /************Oracle***************/
        public static string DBCreateSeq = "create sequence SEQ_{0} increment by 1 start with 1 nomaxvalue nocycle cache 10";
        /************Oracle_End***************/
    }
}
