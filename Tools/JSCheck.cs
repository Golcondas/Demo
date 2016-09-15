using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Tools
{
    public class JSCheck
    {
        public string JSCheckNull(DataTable dt)
        {
            StringBuilder sb=new StringBuilder("/********JS验证各字段是否为空**********/");
            sb.AppendLine("");
            sb.AppendLine("<script type=\"text/javascript\" >");
            sb.AppendLine("function Trim(str){  return str.replace(/(^\\s*)|(\\s*$)/g, \"\");}");
            sb.AppendLine("function CheckNull(){");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string columnname = dt.Rows[i][0].ToString();
                sb.AppendLine("\t var v_" + columnname + "=document.getElementById(\"<%= Txt" + columnname + ".ClientID%>\").value;");
                sb.AppendLine("\t if (Trim(v_" + columnname +").length<=0)");
                sb.AppendLine("\t {");
                sb.AppendLine("\t\t alert('"+dt.Rows[i][1].ToString()+" 不能为空！');");
                sb.AppendLine("\t\t return false;");
                sb.AppendLine("\t }");
                sb.AppendLine("");
            }
            sb.AppendLine("\t return true;");
            sb.AppendLine("}");
            sb.AppendLine("</script>");
            return sb.ToString();
        }
        public string JSCheckNullToSpan(DataTable dt)
        {
            StringBuilder sb = new StringBuilder("/********JS验证各字段是否为空**********/");
            sb.AppendLine("");
            sb.AppendLine("<script type=\"text/javascript\" >");
            sb.AppendLine("function Trim(str){  return str.replace(/(^\\s*)|(\\s*$)/g, \"\");}");
            sb.AppendLine("function CheckNull(){");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string columnname = dt.Rows[i][0].ToString();
                sb.AppendLine("\t var v_" + columnname + "=document.getElementById(\"<%= Txt" + columnname + ".ClientID%>\").value;");
                sb.AppendLine("\t var s_" + columnname + "=document.getElementById(\"s_" + columnname+"\");");
                sb.AppendLine("\t if (Trim(v_" + columnname + ").length<=0)");
                sb.AppendLine("\t {");
                sb.AppendLine("\t\t s_" + columnname + ".style.color='red';");
                sb.AppendLine("\t\t s_"+columnname+".innerHTML='不能为空';");
                sb.AppendLine("\t\t return false;");
                sb.AppendLine("\t }");
                sb.AppendLine("\t else");
                sb.AppendLine("\t {");
                sb.AppendLine("\t\t s_" + columnname + ".style.color='green';");
                sb.AppendLine("\t\t s_" + columnname + ".innerHTML='正确';");
                sb.AppendLine("\t }");
                sb.AppendLine("");
            }
            sb.AppendLine("\t return true;");
            sb.AppendLine("}");
            sb.AppendLine("</script>");
            return sb.ToString();
        }
    }
}
