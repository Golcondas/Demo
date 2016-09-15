using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Tools
{
    public class AspxPage
    {
        public string CreateTextBox(DataTable dt)
        {
            StringBuilder sb=new StringBuilder("<!--自动产生字段输入文本框-->");
            sb.AppendLine("");
            sb.AppendLine("<table>");
            sb.AppendLine("\t <tr>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.AppendLine("\t\t <td>");
                sb.AppendLine("\t\t\t " + dt.Rows[i][1].ToString());
                sb.AppendLine("\t\t </td>");
                sb.AppendLine("\t\t <td align='left'>");
                sb.AppendLine("\t\t\t <asp:TextBox ID=\"Txt" + dt.Rows[i][0].ToString() + "\" runat=\"server\"></asp:TextBox>");
                sb.AppendLine("\t\t </td>");
                if (i % 2 != 0)
                {
                    sb.AppendLine("\t </tr>");
                    sb.AppendLine("\t <tr>");
                }
            }
            if((dt.Rows.Count-1)%2==0)
            {
                sb.AppendLine("\t <td></td><td></td></tr>");
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        public string CreateTextBoxAndSpan(DataTable dt)
        {
            StringBuilder sb = new StringBuilder("<!--自动产生字段输入文本框和标记-->");
            sb.AppendLine("");
            sb.AppendLine("<table>");
            sb.AppendLine("\t <tr>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.AppendLine("\t\t <td>");
                sb.AppendLine("\t\t\t " + dt.Rows[i][1].ToString());
                sb.AppendLine("\t\t </td>");
                sb.AppendLine("\t\t <td align='left'>");
                sb.AppendLine("\t\t\t <asp:TextBox ID=\"Txt" + dt.Rows[i][0].ToString() + "\" runat=\"server\" onblur='CheckNull();'></asp:TextBox>");
                sb.AppendLine("\t\t\t <span id='s_" + dt.Rows[i][0].ToString() + "' style='color:red'>*</span>");
                sb.AppendLine("\t\t </td>");
                if (i % 2 != 0)
                {
                    sb.AppendLine("\t </tr>");
                    sb.AppendLine("\t <tr>");
                }
            }
            if ((dt.Rows.Count - 1) % 2 == 0)
            {
                sb.AppendLine("\t <td></td><td></td></tr>");
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        public string CreateLabel(DataTable dt)
        {
            StringBuilder sb = new StringBuilder("<!--自动产生字段标签-->");
            sb.AppendLine("");
            sb.AppendLine("<table>");
            sb.AppendLine("\t <tr>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.AppendLine("\t\t <td>");
                sb.AppendLine("\t\t\t " + dt.Rows[i][1].ToString());
                sb.AppendLine("\t\t </td>");
                sb.AppendLine("\t\t <td align='left'>");
                sb.AppendLine("\t\t\t <asp:Label ID=\"Lb" + dt.Rows[i][0].ToString() + "\" runat=\"server\"></asp:Label>");
                sb.AppendLine("\t\t </td>");
                if (i % 2 != 0)
                {
                    sb.AppendLine("\t </tr>");
                    sb.AppendLine("\t <tr>");
                }
            }
            if ((dt.Rows.Count - 1) % 2 == 0)
            {
                sb.AppendLine("\t <td></td><td></td></tr>");
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }
    }
}
