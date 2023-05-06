using BLL;
using Oracle.DataAccess.Client;
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
    public partial class Resultat2021 : System.Web.UI.Page
    {
        string ID_ET;
        string NOM_ET;
        string PRENOM_ET;
        string NUM_CIN_PASSEPORT;
        ToiecService service = new ToiecService();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Response.Redirect("~/Online/default.aspx");
            // commenter le 17-02-2022

            string id = Session["ID_ET"].ToString();
            Label_mg.Text = DAL.Admission.Instance.moy_g(id);

            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");

            }
            //if ((int)Session["nbredeconsultationparsession"] == 0)
            //{

            //    Session["nbredeconsultationparsession"] = 3; }
            //else
            //{
            //    Session.Clear();
            //    Response.Redirect("~/Online/default.aspx");
            //}
            //if (IsPostBack)
            //{

            //    Session.Clear();
            //    Response.Redirect("~/Online/default.aspx");
            //}
            //if (GridView1.Rows.Count == 0)
            //{
            //    Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu suite au déroulement des conseils de classe')</script>");


            //}



            ID_ET = Session["ID_ET"].ToString();
            GridView1.DataSource = service.getrst(ID_ET);
            GridView1.DataBind();
            //GridView1.DataSource = SqlDataSource1;
            //GridView1.DataBind();

            if (DAL.ToiecDAO.Instance.verif_exist_note(Session["ID_ET"].ToString()) == false)
               {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Aucune saisie n a été effectuée')</script>");
              //Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu suite au déroulement des conseils de classe')</script>");

            }

            else
            {
                if (GridView1.Rows.Count == 0)
            {
                    //Response.Write("<script LANGUAGE='JavaScript'> alert('Aucune saisie n a été effectuée')</script>");
                     //Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu suite au déroulement des conseils de classe')</script>");

                   


                }

                else
                {
                    //Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif, Veuillez contacter le service compétant')</script>");

                     //Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu suite au déroulement des conseils de classe')</script>");

                    //string s=service.returnCLSUPP(id_et);

                    //GridView1.DataSource = SqlDataSource1;
                    //GridView1.DataBind();

                  GridView1.Visible = true;
                    if (Session["ID_ET"].ToString()== ID_ET || Session["CIN_PASS"].ToString()== ID_ET)
                    {
                        //commenter le gridview en cas de verouillage
                        GridView1.DataSource = service.getrst(ID_ET);
                        GridView1.DataBind();
                    

                    }
                    else Response.Redirect("~/Online/default.aspx");
                }

            }

            // lbletat.Text = DAL.Admission.Instance.getetatue(ID_ET);

            //////Label1.Text = DAL.Admission.Instance.getetat(ID_ET);


            //////if (lbletat.Text == ("-1") || Label1.Text == ("-1"))
            //////{
            //////    //
            //////    Response.Write("<script LANGUAGE='JavaScript'> alert('Problème pédagogique,veuillez contacter votre chef de département')</script>");

            //////    GridView1.Visible = false;
            //////}

            //////else
            //////{
            //if (DAL.ToiecDAO.Instance.verif_exist_note(Session["ID_ET"].ToString()) == false)
            //{
            //    Response.Write("<script LANGUAGE='JavaScript'> alert('Aucune saisie n a été effectuée')</script>");

            //}
            //else
            //          string recouvrement ="";
            //var compt = DAL.Admission.Instance.GetCompt(ID_ET);
            //try {
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
            //    if (index >= 0)
            //    {
            //        soldEtudiant = soldEtudiant.Remove(index);
            //    }
            //    Label1.Text = Convert.ToString(result);
            //}

 //           if (Convert.ToDouble(soldEtudiant) >100 )
 //           {
 //               if (recouvrement == "99" )
 //               {
                    
 //                   GridView1.DataSource = SqlDataSource1;
 //                   GridView1.DataBind();
 //                   //Déroulement des conseils de classe
 ////Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu suite au déroulement des conseils de classe')</script>");



 //               }
 //               else
 //               {
 //                   Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif, Veuillez contacter le service compétant')</script>");

 //                   //Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu suite au déroulement des conseils de classe')</script>");




 //               }
 //           }
            //else
            //{
            //    GridView1.DataSource = SqlDataSource1;
            //    GridView1.DataBind();
            //    if (GridView1.Rows.Count==0)
            //    {
                    
            //       Response.Write("<script LANGUAGE='JavaScript'> alert('Aucune note n a été saisie')</script>");

            //    }

            //    else
            //    {
            //        GridView1.DataSource = SqlDataSource1;
            //        GridView1.DataBind();
            //        //Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu suite au déroulement des conseils de classe')</script>");
            //    }



            //}


            ID_ET = Session["ID_ET"].ToString();
            NOM_ET = Session["NOM_ET"].ToString();
            PRENOM_ET = Session["PNOM_ET"].ToString();
            NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();
            //if (Class1.Instance.verify(NUM_CIN_PASSEPORT) == false)
            //    Response.Redirect("Resultas.aspx");
            //  }

        }

        public string FormatNullValue(object objPrice, object obj2)
        {

            string abs = Convert.ToString(obj2);
            Decimal price = Convert.ToDecimal(objPrice);
            string tt = Convert.ToString(price);
            //if ((price == 0 || objPrice.Equals(DBNull.Value)) && abs.Equals("N"))
            if (objPrice.Equals(DBNull.Value))
            {
                return "";

            }

            return tt;

        }
        public string ExisteNote(object objnote, object ob2, object obj3)
        {
            string note;
            string tt = Convert.ToString(ob2);
            string ab = Convert.ToString(obj3);
            if (ob2.Equals("O"))
            {
                note = Convert.ToString(objnote);
            }
            else
            {
                note = "";
            }


            return note;

        }
        //public Boolean AbsentExamen(object objab)
        //{

        //    string abs = Convert.ToString(objab);
        //    if (abs.Equals("O"))
        //    {
        //        return true;
        //    }

        //    return false;
        //}
        public string AbsentExamen(object objab)
        {

            string abs = Convert.ToString(objab);
            if (abs.Equals("O"))
            {
                return "O";
            }

            return "N";
        }

        
        }       
}