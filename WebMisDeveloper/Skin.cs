using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Sunisoft.IrisSkin;

namespace WebMisDeveloper
{
    class Skin
    {
        public static Sunisoft.IrisSkin.SkinEngine se = new SkinEngine();

        /// <summary> 
        /// 增加换肤菜单 
        /// </summary> 
        /// <param name="toolMenu"></param> 
        public static void AddSkinMenu(ToolStripMenuItem toolMenu)
        {
            DataSet skin = new DataSet();
            try
            {

                skin.ReadXml(".\\Skins\\skin.xml", XmlReadMode.Auto);
            }
            catch
            {

            }
            if (skin == null || skin.Tables.Count < 1)
            {
                skin = new DataSet();
                skin.Tables.Add("skin");
                skin.Tables["skin"].Columns.Add("style");
                System.Data.DataRow dr = skin.Tables["skin"].NewRow();
                dr[0] = "Default";
                skin.Tables[0].Rows.Add(dr);
                skin.WriteXml(".\\Skins\\skin.xml", XmlWriteMode.IgnoreSchema);
            }

            foreach (SkinType st in (SkinType[])System.Enum.GetValues(typeof(SkinType)))
            {
                toolMenu.DropDownItems.Add(new ToolStripMenuItem(st.ToString()));

                toolMenu.DropDownItems[toolMenu.DropDownItems.Count - 1].Click += new EventHandler(frm_Main_Click);
                if (st.ToString() == skin.Tables[0].Rows[0][0].ToString())
                {
                    ((ToolStripMenuItem)toolMenu.DropDownItems[toolMenu.DropDownItems.Count - 1]).Checked = true;
                    frm_Main_Click(toolMenu.DropDownItems[toolMenu.DropDownItems.Count - 1], null);

                }

            }
        }
        static void frm_Main_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems.Count; i++)
                {
                    if (((ToolStripMenuItem)sender).Text == ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[i].Text)
                    {
                        ((ToolStripMenuItem)sender).CheckState = CheckState.Checked;
                        DataSet skin = new DataSet();
                        skin.Tables.Add("skin");
                        skin.Tables["skin"].Columns.Add("style");
                        System.Data.DataRow dr = skin.Tables["skin"].NewRow();
                        dr[0] = ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[i].Text;
                        skin.Tables[0].Rows.Add(dr);
                        skin.WriteXml(".\\Skins\\skin.xml", XmlWriteMode.IgnoreSchema);
                    }
                    else
                    {
                        ((ToolStripMenuItem)((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[i]).CheckState = CheckState.Unchecked;
                    }
                }
                if (((ToolStripMenuItem)sender).Text == "Default")
                {
                    RemoveSkin();
                    DataSet skin = new DataSet();
                    skin.Tables.Add("skin");
                    skin.Tables["skin"].Columns.Add("style");
                    System.Data.DataRow dr = skin.Tables["skin"].NewRow();
                    dr[0] = "Default";
                    skin.Tables[0].Rows.Add(dr);
                    skin.WriteXml(".\\Skins\\skin.xml", XmlWriteMode.IgnoreSchema);
                    return;
                }
                foreach (SkinType st in (SkinType[])System.Enum.GetValues(typeof(SkinType)))
                {
                    if (st.ToString() == ((ToolStripMenuItem)sender).Text)
                    {
                        ChangeSkin(st.ToString());
                        return;
                    }
                }
            }
            catch { }
        }
        /// <summary> 
        /// 改变皮肤 
        /// </summary> 
        /// <param name="st"></param> 
        public static void ChangeSkin(string st)
        {
            se.SkinFile = ".\\Skins\\" + st.ToString() + ".ssk";
            se.Active = true;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                se.AddForm(Application.OpenForms[i]);
            }
        }
        /// <summary> 
        /// 移除皮肤 
        /// </summary> 
        public static void RemoveSkin()
        {
            if (se == null)
            {
                return;
            }
            else
            {
                se.Active = false;
            }
        }
    }
    /// <summary> 
    /// 换肤类型 
    /// </summary> 
    public enum SkinType
    {
        //Default,
        Calmness,
        DeepGreen,
        DeepOrange,
        DiamondBlue,
        DiamondGreen,
        GlassBrown,
        GlassGreen,
        GlassOrange,
        Longhorn,
        Midsummer,
        MP,
        MSN,
        SportsBlack,
        SportsBlue,
        SportsGreen,
        SportsOrange,
        Vista,
        WaveBlue,
        WaveGreen
    }
}
