using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Etudiants
{
    public partial class absenceetud : System.Web.UI.Page
    {
        string ID_ET;
        string NOM_ET;
        string PRENOM_ET;
        string NUM_CIN_PASSEPORT;
        int nbLignes;
        string CODE_CL;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            
            
            ID_ET = Session["ID_ET"].ToString();
            NOM_ET = Session["NOM_ET"].ToString();
            PRENOM_ET = Session["PNOM_ET"].ToString();
            NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();
            CODE_CL = Session["CODE_CL"].ToString();
            HiddenField1.Value = ID_ET;
            HiddenField2.Value = CODE_CL;
            nbLignes = GridView2.Rows.Count;
            Label6.Text = nbLignes.ToString();
            if (GridView2.Rows.Count == 0)
            {
                Label6.Text = "Vous n'avez pas d'absence";
            }
            foreach (GridViewRow gvr in GridView2.Rows)
            {

                switch (gvr.Cells[1].Text)
                {
                    case "1":
                        gvr.Cells[1].Text = "9:00 à 10:30";
                        break;
                    case "2":
                        gvr.Cells[1].Text = "10:45 à 12:15";
                        break;
                    case "3":
                        gvr.Cells[1].Text = "14:00 à 15:30";
                        break;
                    case "4":
                        gvr.Cells[1].Text = "15:45 à 17:15";
                        break;
                }
            }
        }



        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {



            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cellnbheures = e.Row.Cells[3];
                TableCell cellnbabs = e.Row.Cells[4];
                int quantity = int.Parse(cellnbheures.Text.Substring(0,2));
                int qtnbh = int.Parse(cellnbabs.Text);
                if (quantity==21 && qtnbh>3)
                {
                    // cell.BackColor = System.Drawing.Color.Red;

                    //e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='orange'");
                    //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#e37474'");
                   e.Row.BackColor = System.Drawing.Color.FromName("#C4698F");

                }

                else
                {
                    if (quantity == 28 && qtnbh > 4)
                    {
                        e.Row.BackColor = System.Drawing.Color.FromName("#C4698F");
                    }

                    else
                    {
                        if (quantity == 31.5 && qtnbh > 5)
                        {
                            e.Row.BackColor = System.Drawing.Color.FromName("#C4698F");
                        }


                        else
                        {
                            if (quantity == 42 && qtnbh > 6)
                            {
                                e.Row.BackColor = System.Drawing.Color.FromName("#C4698F");
                            }

                            else
                            {

                                if (quantity == 49 && qtnbh > 8)
                                {
                                    e.Row.BackColor = System.Drawing.Color.FromName("#C4698F");
                                }

                                else
                                {
                                    if (quantity == 56 && qtnbh > 9)
                                    {
                                        e.Row.BackColor = System.Drawing.Color.FromName("#C4698F");
                                    }


                                    else
                                    {
                                        if (quantity == 63 && qtnbh > 9)
                                        {
                                            e.Row.BackColor = System.Drawing.Color.FromName("#C4698F");
                                        }

                                        else
                                        {
                                            if (quantity == 64 && qtnbh > 9)
                                            {
                                                e.Row.BackColor = System.Drawing.Color.FromName("#C4698F");
                                            }


                                            else
                                            {

                                                if (quantity == 84 && qtnbh > 12)
                                                {
                                                    e.Row.BackColor = System.Drawing.Color.FromName("#C4698F");
                                                }
                                            }

                                        }

                                    }
                                }
                            }

                        }

                    }
                }

            }
        }

    }
}