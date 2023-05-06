using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Enseignants
{
    public partial class AffichageAbsence : System.Web.UI.Page
    {
       int nbLignes;
        string id;


       



        protected void Page_Load(object sender, EventArgs e)
        {
           
            
           
            Affiche();
            if (Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }



            id = Session["ID_ENS"].ToString().Trim();
            Label1.Text = id;
         
            Label1.Visible = false;
           
         
            
        }

        protected void DDClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            EtudiantClassBind(DDClasse.SelectedValue );
            Affiche();
        }

        protected void DdlModule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
           
            if (RadioButtonList1.SelectedIndex == 0)
            {
                DDClasse.Items.Clear();
                DdlModule.Items.Clear();
                DDClasse.Visible = false;

                DdlModule.Visible = false;
                DropDownList3.Visible = false;
                
            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {
                DDClasse.Visible = true;
                DropDownList3.Visible = false;
                DdlModule.Visible = false;
                //GridView1.Visible = true;
            }
            else if (RadioButtonList1.SelectedIndex == 2)
            {
                DDClasse.Visible = true;
                               DdlModule.Visible = true;
                               DropDownList3.Visible = false;
                //GridView1.Visible = true;
            }
            else if (RadioButtonList1.SelectedIndex == 3)
            {
                DDClasse.Visible = true;
                DdlModule.Visible = false;
                DropDownList3.Visible = true;
            }
            Affiche();
          
        }

        protected void DdlNumSeance_SelectedIndexChanged(object sender, EventArgs e)
        {
            Affiche();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void EtudiantClassBind(string codecl)
        {
            List<EtudiantClasses> ls = new List<EtudiantClasses>();
            ls = EtudiantClasses.GetListEtudiantClasse(codecl);
            DropDownList3.DataSource = ls;
           //DropDownList3.DataTextField = "NOM_ET";
            DropDownList3.DataValueField = "ID_ET";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("Choisir", "0"));
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }
        public void Affiche()
        {
            nbLignes = GridView1.Rows.Count;
            Label7.Text = nbLignes.ToString();

            foreach (GridViewRow gvr in GridView1.Rows)
            {

                switch (gvr.Cells[4].Text)
                {
                    case "1":
                        gvr.Cells[4].Text = "9:00 à 10:30";
                        break;
                    case "2":
                        gvr.Cells[4].Text = "11:45 à 12:15";
                        break;
                    case "3":
                        gvr.Cells[4].Text = "14:00 à 15:30";
                        break;
                    case "4":
                        gvr.Cells[4].Text = "15:45 à 17:15";
                        break;
                }
            }
            if (Label7.Text == "0")
            {
                Label7.Text = " Aucune absence enregistrée";
            }
           
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}