using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Drawing;
using Telerik.Web.UI;

namespace ESPOnline.Enseignants
{
    public partial class Justification_absences : System.Web.UI.Page
    {

        serviceABS s = new serviceABS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null )
            {
                Response.Redirect("~/Online/default.aspx");
            }

            if (!IsPostBack)
            {
                RadComboBox1.DataTextField = "Nom";
                RadComboBox1.DataValueField = "ID_ET";
                RadComboBox1.DataSource = s.bind_listetud();
                RadComboBox1.DataBind();

                RadComboBox2.DataTextField = "CODE_MODULE";
                RadComboBox2.DataValueField = "CODE_MODULE";
                RadComboBox2.DataSource = s.bind_Module();
                RadComboBox2.DataBind();
            }

        }

        protected void RadComboBox1_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //ici nom
            string aa = RadComboBox1.SelectedValue.Substring(0, 10);
            txtstudentt.Text =s.get_NAMES(aa) ;
            GridView1.Visible = false;
            btnx.Visible = true;
            Button3.Visible = false;
           
            TBdateseance.Text = "";
            TextBox11.Text = "";
            txtComboBox5.Text = "";
            txtboBox3.Text = "";
          


            RadComboBox2.ClearSelection();
            RadComboBox2.DataTextField = "CODE_MODULE";
            RadComboBox2.DataValueField = "CODE_MODULE";
            RadComboBox2.DataSource = s.bind_Module();
            RadComboBox2.DataBind();
          
            //vider et rebind a combobox
            RadComboBox4.ClearSelection();
            RadComboBox4.DataTextField = "LIB";
            RadComboBox4.DataValueField = "LIB";
            RadComboBox4.DataSource = s.bind_justif();
            RadComboBox4.DataBind();
            
        }

        protected void ddlprojet_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void TBdateseance_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnx_Click(object sender, EventArgs e)
        {

            if(RadComboBox1.SelectedValue=="" )

            {
                string script = "alert(\"If faut saisir un étudiant\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }

            else
            
            {
            string aa = RadComboBox1.SelectedValue.Substring(0, 10);

            GridView1.Visible = true;
            GridView1.DataSource = s.bind_dataetudabs(aa);
            GridView1.DataBind();

            RadComboBox4.DataTextField = "LIB";
            RadComboBox4.DataValueField = "LIB";
            RadComboBox4.DataSource = s.bind_justif();
            RadComboBox4.DataBind();
        }
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

               
         
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            if(RadComboBox1.SelectedValue!="")
            {
                int index = GridView1.SelectedRow.RowIndex;
                
                //txtstudentt.Text = GridView1.SelectedRow.Cells[0].Text;
                txtboBox3.Text = GridView1.SelectedRow.Cells[1].Text;
                
                TBdateseance.Text = GridView1.SelectedRow.Cells[4].Text;
                TextBox11.Text = GridView1.SelectedRow.Cells[6].Text;

                RadComboBox2.SelectedValue = GridView1.SelectedRow.Cells[0].Text;
                RadComboBox2.DataBind();
            }

            else
            {
                if (RadComboBox2.SelectedValue != "")
                {
                    int index = GridView1.SelectedRow.RowIndex;
                    //txtboBox3.Text = GridView1.SelectedRow.Cells[0].Text;

                    TBdateseance.Text = GridView1.SelectedRow.Cells[4].Text;
                    TextBox11.Text = GridView1.SelectedRow.Cells[5].Text;
                    // string id = GridView1.SelectedRow.Cells[6].Text;
                    RadComboBox1.SelectedValue = GridView1.SelectedRow.Cells[7].Text;
                    

                    RadComboBox1.DataBind();

                    //string aa = RadComboBox1.SelectedValue.Substring(0, 10);
                   // aa = GridView1.SelectedRow.Cells[7].Text; 

                    txtstudentt.Text = s.get_ETUD(RadComboBox1.SelectedValue);
                }
            }

         
         
            
        }

       

        protected void RadComboBox4_SelectedIndexChanged2(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string aa = RadComboBox4.SelectedValue.Substring(0, 2);
            txtComboBox5.Text = s.get_LIBjUSTIF(aa);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //annuler data
            TBdateseance.Text = "";
            TextBox11.Text = "";
            txtComboBox5.Text = "";
            txtboBox3.Text = "";
            txtstudentt.Text = "";

            RadComboBox2.ClearSelection();
            RadComboBox2.DataTextField = "CODE_MODULE";
            RadComboBox2.DataValueField = "CODE_MODULE";
            RadComboBox2.DataSource = s.bind_Module();
            RadComboBox2.DataBind();

            //vider et rebind a combobox
            RadComboBox4.ClearSelection();
            RadComboBox4.DataTextField = "LIB";
            RadComboBox4.DataValueField = "LIB";
            RadComboBox4.DataSource = s.bind_justif();
            RadComboBox4.DataBind();

            RadComboBox1.ClearSelection();
            RadComboBox1.DataTextField = "Nom";
            RadComboBox1.DataValueField = "ID_ET";
            RadComboBox1.DataSource = s.bind_listetud();
            RadComboBox1.DataBind();

            GridView1.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //enreg data
            //try
            //{
                 string ident = RadComboBox1.SelectedValue.Substring(0, 10);
                string a=GridView1.SelectedRow.Cells[2].Text;
                string numsea= GridView1.SelectedRow.Cells[3].Text;
               string c=  GridView1.SelectedRow.Cells[4].Text;

            
                 string xx = RadComboBox4.SelectedValue.Substring(0, 2);
                 DateTime date_se = Convert.ToDateTime(TBdateseance.Text);
                   DateTime dtu=date_se.Date;
               string libb = txtComboBox5.Text;
               TBdateseance.Text = dtu.ToString();
               s.Enreg_abs(ident, libb, numsea, dtu, xx);
               string script = "alert(\"Justification enregistré avec succès\");";
               ScriptManager.RegisterStartupScript(this, GetType(),
                                     "ServerControlScript", script, true);

               TBdateseance.Text = "";
               TextBox11.Text = "";
               txtComboBox5.Text = "";
               txtboBox3.Text = "";



               RadComboBox2.ClearSelection();
               RadComboBox2.DataTextField = "CODE_MODULE";
               RadComboBox2.DataValueField = "CODE_MODULE";
               RadComboBox2.DataSource = s.bind_Module();
               RadComboBox2.DataBind();

               //vider et rebind a combobox
               RadComboBox4.ClearSelection();
               RadComboBox4.DataTextField = "LIB";
               RadComboBox4.DataValueField = "LIB";
               RadComboBox4.DataSource = s.bind_justif();
               RadComboBox4.DataBind();
            //}

            //catch
            //{
            //    string script = "alert(\"Erreur de serveur\");";
            //    ScriptManager.RegisterStartupScript(this, GetType(),
            //                          "ServerControlScript", script, true);
            //}
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
    //abs par module

            if (RadComboBox2.SelectedValue == "" )
            {
                string script = "alert(\"If faut saisir un étudiant\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }

            else
            {
                string aa = RadComboBox2.SelectedValue;

                GridView1.Visible = true;
                GridView1.DataSource = s.bind_dataetudabsBYmodule(aa);
                GridView1.DataBind();

                RadComboBox4.DataTextField = "LIB";
                RadComboBox4.DataValueField = "LIB";
                RadComboBox4.DataSource = s.bind_justif();
                RadComboBox4.DataBind();
            }
        }

        protected void RadComboBox2_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string aa = RadComboBox2.SelectedValue;
            txtboBox3.Text = s.get_module(aa);
            btnx.Visible = false;
            Button3.Visible = true;
            //lb.Text = RadComboBox2.SelectedValue;

            RadComboBox1.ClearSelection();
            RadComboBox1.DataTextField = "Nom";
            RadComboBox1.DataValueField = "ID_ET";
            RadComboBox1.DataSource = s.bind_listetud();
            RadComboBox1.DataBind();
            txtstudentt.Text = "";
        }
    }
}