using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Tools
{
    public class ValueGetSet
    {
        public string ValueGet(DataTable dt,string model)
        {
            StringBuilder sb=new StringBuilder("/********获取页面数据**********/");
            sb.AppendLine("");
            sb.AppendLine(model+" _"+model+" = new "+model+"();");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.AppendLine("_" + model + "." + dt.Rows[i][0].ToString() + " = Txt" + dt.Rows[i][0].ToString() + ".Text.Trim().Replace(\"'\",\"\");");
            }
            return sb.ToString();
        }
        public string ValueSet(DataTable dt, string model)
        {
            StringBuilder sb = new StringBuilder("/********给页面TextBox赋值**********/");
            sb.AppendLine("");
            sb.AppendLine(model + " _" + model + " = new " + model + "();//程序获得Model");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.AppendLine("Txt" + dt.Rows[i][0].ToString() + ".Text = " + "_" + model + "." + dt.Rows[i][0].ToString());
            }
            return sb.ToString();
        }

        public string ValueSetLabel(DataTable dt, string model)
        {
            StringBuilder sb = new StringBuilder("/********给页面Label赋值**********/");
            sb.AppendLine("");
            sb.AppendLine(model + " _" + model + " = new " + model + "();//程序获得Model");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.AppendLine("Lb" + dt.Rows[i][0].ToString() + ".Text = " + "_" + model + "." + dt.Rows[i][0].ToString());
            }
            return sb.ToString();
        }
    }
}
