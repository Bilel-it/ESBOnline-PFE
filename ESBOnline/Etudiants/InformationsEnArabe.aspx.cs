using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess;
using ABSEsprit;
using Oracle.ManagedDataAccess.Types;
using System.Text.RegularExpressions;
using System.Data;

namespace ESPOnline.Etudiants
{
    public partial class InformationsEnArabe : System.Web.UI.Page
    {
        string id_etud;
        protected void Page_Load(object sender, EventArgs e)
        {
   id_etud = Session["ID_ET"].ToString();
   DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
   if (!IsPostBack)
   {
       
       foreach (DataRowView drvSql in dvSql)
       {
           TextBox1.Text = drvSql["NOM_ARB"].ToString();
           TextBox2.Text = drvSql["PNOM_ARB"].ToString();
           TextBox4.Text = drvSql["LIEU_NAIS_ARB"].ToString();
           TextBox6.Text = drvSql["NATURE_BAC_ARB"].ToString();
           TextBox8.Text = drvSql["DIPLOME_SUP_ARB"].ToString();
           TextBox9.Text = drvSql["ETAB_ORIGINE_ARB"].ToString();

       }
   }
        }
        
        DateTime datbac;
        DateTime datnac;
        protected void Button1_Click1(object sender, EventArgs e)
        {
          
           // datbac = DateTime.Parse(TextBox7.Text);
          //  datnac = DateTime.Parse(TextBox3.Text);
            Regex a = new Regex("^[\u0600-\u06ff ]*$");
            Regex b = new Regex("^[\u0600-\u06ff ]*$");
            Regex c = new Regex("^[\u0600-\u06ff0-9.,;: ()]*$");
            Regex d = new Regex("^[\u0600-\u06ff ]*$");
            Regex h = new Regex("^[\u0600-\u06ff0-9.,;: ()]*$");
            Regex f = new Regex("^[\u0600-\u06ff0-9.,;: ()]*$");
            bool aa = a.IsMatch(TextBox1.Text);
            bool bb = b.IsMatch(TextBox2.Text);
            bool cc = c.IsMatch(TextBox4.Text);
            bool dd = d.IsMatch(TextBox6.Text);
            bool ff = f.IsMatch(TextBox8.Text);
            bool hh = h.IsMatch(TextBox9.Text);
            if (aa == true && bb == true && cc == true && dd == true && ff == true && hh == true)
            {
                info_arab.Instance.insertarab(id_etud, TextBox1.Text, TextBox2.Text, TextBox4.Text, TextBox6.Text,TextBox9.Text, TextBox8.Text );
                Response.Write("<script LANGUAGE='JavaScript' >alert('Ajout avec Succées')</script>");
            }
            else {

                Response.Write("<script LANGUAGE='JavaScript' >alert('Veuillez remplir les champs en utilisant l arabe')</script>");
            }
        }
    }
}