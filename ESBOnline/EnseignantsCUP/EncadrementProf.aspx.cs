using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESPSuiviEncadrement;

namespace ESPOnline.EnseignantsCUP
{
    public partial class EncadrementProf : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            if (!IsPostBack)
            {
                BindProf();
                Panel1.Visible = false;
                Panel2.Visible = false;
                
                
            }


        }





        protected void BindProf()
        {
            DropDownList1.Items.Clear();
            List<recherchePROF> ls = new List<recherchePROF>();
            ls = recherchePROF.GETAllEnseignant();
            DropDownList1.DataSource = ls;
            
            DropDownList1.DataTextField = "NOM_ENS";
            
            DropDownList1.DataValueField = "NOM_ENS";
            
            DropDownList1.DataBind();
            
            DropDownList1.Items.Insert(0, new ListItem("Choisir", "0"));
            
        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue.ToString() == "0")
            {
                
                BindProf();

            }
            else if (RadioButtonList1.SelectedValue.ToString() == "1")
            {
                
                BindProf();
            }
        }
                

        protected void DropDownList11_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (DropDownList1.SelectedItem.ToString() == "Choisir")
            {
                //RadioButtonList1.ForeColor = System.Drawing.Color.Black;
                Panel1.Visible = false;
                Panel2.Visible = false;
                
                
            }
            else
            {
                if (RadioButtonList1.SelectedValue.ToString() == "0")
                {
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    

                }
                else if (RadioButtonList1.SelectedValue.ToString() == "1")
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = true;
                    }

            }

           
            
        }


       

    }

}
