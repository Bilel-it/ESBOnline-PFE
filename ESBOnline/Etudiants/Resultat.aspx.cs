using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Etudiants
{
    public partial class Resultat : System.Web.UI.Page
    {
        string ID_ET;
        string NOM_ET;
        string PRENOM_ET;
        string NUM_CIN_PASSEPORT;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (GridView1.Rows.Count == 0)
            //{
            //    Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif, Veuillez contacter le service compétent')</script>");
            //}
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            if (!IsPostBack)
            {
                
            }

            ID_ET = Session["ID_ET"].ToString();


            GridView1.DataSource = ObjectDataSource1;
            GridView1.DataBind();

            if (DAL.LangueDAO.Instance.verif_exist_note(Session["ID_ET"].ToString()) == false)
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Aucune saisie n a été effectuée')</script>");

            }

            else
            {
                if (GridView1.Rows.Count == 0)
                {
                    //Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif, Veuillez contacter le service compétant')</script>");
                    Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu')</script>");



                }

                else
                {
                    // Response.Write("<script LANGUAGE='JavaScript'> alert('L Accès est provisoirement suspendu suite au déroulement des conseils de classe')</script>");



                    GridView1.DataSource = ObjectDataSource1;
                    GridView1.DataBind();
                }

            }

            ID_ET = Session["ID_ET"].ToString();
            NOM_ET = Session["NOM_ET"].ToString();
            PRENOM_ET = Session["PNOM_ET"].ToString();
            NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();
            if (Class1.Instance.verify(NUM_CIN_PASSEPORT) == false)
                Response.Redirect("Resultas.aspx");
        }
        public string FormatNullValue(object objPrice, object obj2)
        {

            string abs = Convert.ToString(obj2);
            Decimal price = Convert.ToDecimal(objPrice);
            string tt = Convert.ToString(price);
            //if ((price == 0 || objPrice.Equals(DBNull.Value)) && abs.Equals("N"))
            if (objPrice.Equals(DBNull.Value) )
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
                note = "null";
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