using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Tools
{
    public class AspxRepeater
    {
        public string CreateAjaxRepeater(DataTable dt, string model)
        {
            StringBuilder TdHeader = new StringBuilder();
            TdHeader.AppendLine("");
            StringBuilder RepeaterTd = new StringBuilder();
            RepeaterTd.AppendLine("");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TdHeader.AppendLine("\t\t<td>" + dt.Rows[i][1].ToString() + "</td>");
                RepeaterTd.AppendLine("\t\t<td><%# Eval(\"" + dt.Rows[i][0].ToString() + "\").ToString() %></td>");
            }
            return CJ_DBOperater.CJ.ReadFile(".\\WebBasic\\R.cj").Replace("{tablename}", model).Replace("{0}", TdHeader.ToString()).Replace("{1}", RepeaterTd.ToString());
        }
    }
}
