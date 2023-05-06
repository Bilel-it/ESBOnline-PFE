using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ESPOnline.Etudiants
{
    public partial class noterat2021 : System.Web.UI.Page
    {
        string sess_covid; string valid_p;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;

            //if ((int)Session["nbredeconsultationparsession"] == 0)
            //{ Session["nbredeconsultationparsession"] = 3; }
            //else
            //{
            //    Session.Clear();
            //    Response.Redirect("~/Online/default.aspx");
            //}
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            string ID_ET = Session["ID_ET"].ToString();

            valid_p = "";
            //DAL.ToiecDAO.Instance.getEtat_is_valid_project(ID_ET);
            sess_covid = "";
            //DAL.ToiecDAO.Instance.getEtat_session_covid(ID_ET);
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();

            if (valid_p == "O")
            {


              //  Response.Write("<script LANGUAGE='JavaScript'> alert('Vous êtes appelé à valider votre projet.Votre département vous contactera ultérieurement')</script>");
                GridView1.Visible = true;
            }


            else
            {

                if (sess_covid == "O")

                {

                   Response.Write("<script LANGUAGE='JavaScript'> alert('En attente du conseil des classes')</script>");
                   // GridView1.Visible = true;


                }

                else
                {
                    GridView1.DataSource = SqlDataSource1;
                    GridView1.DataBind();

                    if (DAL.ToiecDAO.Instance.verif_exist_note(Session["ID_ET"].ToString()) == false)
                    {
                        Response.Write("<script LANGUAGE='JavaScript'> alert('Aucune saisie n a été effectuée')</script>");
                      //  Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu suite au déroulement des conseils de classe')</script>");



                    }

                    else
                    {
                        if (GridView1.Rows.Count == 0)
                        {
                             Response.Write("<script LANGUAGE='JavaScript'> alert('Aucune saisie n a été effectuée')</script>");
                          //  Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu suite au déroulement des conseils de classe')</script>");



                        }

                        else
                        {
                           // Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu suite au déroulement des conseils de classe')</script>");


                            //ici il faut decommenter
                            GridView1.DataSource = SqlDataSource1;
                            GridView1.DataBind();
                        }

                    }





                }


            }


             



            //GridView1.DataSource = SqlDataSource1;
            //GridView1.DataBind();
            // // lbletat.Text = DAL.Admission.Instance.getetatue(ID_ET);

            ////  Label1.Text = DAL.Admission.Instance.getetat(ID_ET);


            //  //if (lbletat.Text == ("-1") || Label1.Text == ("-1"))
            //  //{

            //  //    Response.Write("<script LANGUAGE='JavaScript'> alert('Problème pédagogique,veuillez contacter votre chef de département')</script>");

            //  //    GridView1.Visible = false;
            //  //}

            //  //else 
            //  //{

            //      if (DAL.ToiecDAO.Instance.verif_exist_note_rat(Session["ID_ET"].ToString()) == false)
            //      {
            //          Response.Write("<script LANGUAGE='JavaScript'> alert('Aucune saisie n a été effectuée')</script>");

            //      }
            //      else if (GridView1.Rows.Count == 0)
            //      {
            //          Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif, Veuillez contacter le service compétant')</script>");
            //      }
            //  //}

            //string recouvrement = "";
            //var compt = DAL.Admission.Instance.GetCompt(ID_ET);
            //try
            //{
            //    recouvrement = DAL.Admission.Instance.getRecouvrement(ID_ET);
            //}
            //catch
            //{ }
            //var url = "http://192.168.0.77/webServiceSem1/web/montant/" + compt;
            //var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            //string soldEtudiant;
            //using (var response = webrequest.GetResponse())
            //using (var reader = new StreamReader(response.GetResponseStream()))
            //{
            //    var result = reader.ReadToEnd();
            //    //  Response.Write("<script LANGUAGE='JavaScript'> alert('" + Convert.ToString(result) + "')</script>");

            //    soldEtudiant = Convert.ToString(result);
            //    int index = soldEtudiant.IndexOf(".");
            //    //if (index >= 0)
            //    //{
            //    //    soldEtudiant = soldEtudiant.Remove(index);

            //    //}
            //    Label1.Text = Convert.ToString(result);
            //}

            //if (Convert.ToDouble(soldEtudiant) > 100)
            //{
            //    if (recouvrement == "99")
            //    {
            //        if (DAL.ToiecDAO.Instance.verif_exist_note_rat(Session["ID_ET"].ToString()) == false)
            //                  {
            //                    Response.Write("<script LANGUAGE='JavaScript'> alert('Aucune saisie n a été effectuée')</script>");

            //                }
            //                 else if (GridView1.Rows.Count == 0)
            //                 {
            //                     Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif3, Veuillez contacter le service compétant')</script>");
            //                 }

            //      // else
            //      //  {
            //      //if (GridView1.Rows.Count == 0)
            //      //         {
            //      //             Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif2, Veuillez contacter le service compétant')</script>");
            //      //           }

            //        else{

            //            GridView1.Visible = true;
            //        //    GridView1.DataSource = SqlDataSource1;
            //        //    GridView1.DataBind();
            //        ////}





            //        }


            //        //Déroulement des conseils de classe

            //        // Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu suite au déroulement des conseils de classe')</script>");



            //    }
            //    else
            //    {
            //        Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif1, Veuillez contacter le service compétant')</script>");

            //        //Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu suite au déroulement des conseils de classe')</script>");




            //    }
            //}
            //else
            //{


            //    GridView1.Visible = true;

            //    //GridView1.DataSource = SqlDataSource1;
            //    //GridView1.DataBind();

            //    //Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu suite au déroulement des conseils de classe')</script>");


            //}



        }
    }
}