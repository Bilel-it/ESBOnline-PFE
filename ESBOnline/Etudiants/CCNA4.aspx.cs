using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Types;
using DAL;
using BLL;

using System.Globalization;

namespace ESPOnline.Etudiants
{
    public partial class CCNA4 : System.Web.UI.Page
    {
        string ID_ET;
        string NOM_JETON;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }


            ID_ET = Session["ID_ET"].ToString();
            TextBox1.Text = Session["NOM_ET"].ToString();
            TextBox2.Text = Session["PNOM_ET"].ToString();


            TextBox2.Enabled = false;
            TextBox1.Enabled = false;

            TextBox3.Enabled = false;
            if (!Page.IsPostBack)
            {
                //DropDownList4.DataBind();


                DropDownList3.Items.Insert(0, new ListItem("Faites votre choix"));

            }

            foreach (GridViewRow row in GridView1.Rows)
            {

                if (GridView1.Visible == true)
                {
                    Panel3.Visible = false;
                    DropDownList4.Visible = false;
                }
            }



        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {


            string date;
            string annee;
            string mois;
            string jour;


            if ((TextBox1.Text == ""))
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Identifier Votre Nom SVP ')</script>");

            }
            if ((LabCount.Text == "12"))
            {

                Response.Write("<script LANGUAGE='JavaScript'> alert('Il faut choisir une autre seance car le max dinscri dans la meme heure est 12 ')</script>");

            }

            else if ((DropDownList4.SelectedValue == ""))
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('linscription à la certification est fini ')</script>");
            }
            else if ((TextBox2.Text == ""))
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Identifier Votre Prenom SVP ')</script>");
            }

            else if ((DropDownList3.SelectedValue == "Faites votre choix"))
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Identifier la Date SVP ')</script>");
            }
            else if ((DropDownList1.SelectedValue == "Choisir"))
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Identifier l'Heure SVP ')</script>");
            }

            else
            {
                Label25.Text = "test";
                ESP_INSCRI re = new ESP_INSCRI();
                DropDownList4.DataBind();
                re.NOM_ET = TextBox1.Text;
                re.PRENOM_ET = TextBox2.Text;
                re.ADRESSE_ET = TextBox3.Text;
                re.TYPE_CCNA = "4";
                re.DATE_MISEJOUR = OracleDate.GetSysDate().Value;
                //date = DropDownList3.SelectedValue.ToString();
                date = DateTime.Parse(DropDownList3.SelectedValue).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).ToUpper();
                annee = date.Substring(6, 4);
                mois = date.Substring(3, 2);
                jour = date.Substring(0, 2);
                //DateTime oracledate = new DateTime(DropDownList3.SelectedValue.ToString().Trim()).ToString("dd/MM/yy", CultureInfo.InvariantCulture).ToUpper();
                DateTime oracledate = new DateTime(int.Parse(annee), int.Parse(mois), int.Parse(jour), 1, 1, 1);

                re.DATE_INS = oracledate;

                //re.HEURE_INS = decimal.Parse(DropDownList1.SelectedValue.ToString());
                re.HEURE_INS = DropDownList1.SelectedValue.ToString();
                re.NOM_JETON = DropDownList4.Text;
                re.ID_ET = ID_ET;

                //ENTETE rs = new ENTETE();
                //if (rs.ajouterESP_INSCRI(re, ID_ET) == true)
                //{

                //}
                //BLL.ENTETE ajtT = new ENTETE();
                //if ((ajtT.ajouterESP_INSCRII(re, NOM_JETON) == true))
                //{
                //    Response.Write("<script LANGUAGE='JavaScript'> alert('Inscription Envoyée Avec Succès')</script>");
                //}
                BLL.ENTETE ajt = new ENTETE();

                if ((ajt.ajouterESP_ccna4(re, ID_ET) == true))
                {

                    //Response.Write("<script LANGUAGE='JavaScript'> alert('Inscription Envoyée Avec Succès')</script>");
                    Label25.Text = "Inscription Envoyée Avec Succès";
                    GridView1.DataBind();
                    Panel1.Visible = true;
                    LinkButton11.Visible = false;
                    //Response.Redirect("http://www.netacad.com/self-enroll;jsessionid=CA19D9722F633FBBF3C6684E5587A754.node1?p_p_auth=jpDs7Zrx&p_p_id=selfenroll_WAR_selfenrollportlet&p_p_lifecycle=0&p_o_p_id=56_INSTANCE_PWlZv0V6YydF");
                }

                else
                {
                    Label25.Text = "Inscription Envoyer echoué";
                    // Response.Write("<script LANGUAGE='JavaScript'> alert('Inscription Envoyer echoué')</script>");
                }





            }
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //for (int i = 1; i <= 1; i++)
            //{
            //    COMPT_CERT re = new COMPT_CERT();
            //    re.CPT = decimal.Parse(DropDownList4.SelectedValue.ToString()) + i;

            //    COMPT_CERTSERVICES rs = new COMPT_CERTSERVICES();
            //    rs.ajouterESP_COMPT_CERT(re);
            //}

            DropDownList3.Items.Clear();
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("Faites votre choix"));
            DropDownList4.Items.Clear();
            DropDownList4.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalModifier();", true);

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }



        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {

            //for (int i = 1; i <= 1; i++)
            //{
            //    COMPT_CERT re = new COMPT_CERT();
            //    re.CPT = decimal.Parse(DropDownList4.SelectedValue.ToString())+i;

            //    COMPT_CERTSERVICES rs = new COMPT_CERTSERVICES();
            //    rs.ajouterESP_COMPT_CERT(re);
            //}



        }

        protected void SqlDataSource4_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

            // DateTime dat = DateTime.Parse(DropDownList3.SelectedValue.ToString());

            //string dat1= dat.ToShortDateString();
            // dat.ToString().Substring(0, 10)
            //int a = DAL.EnteteDAO.getcountinscri(dat.ToString().Substring(0, 10), DropDownList1.SelectedValue);
            string a = DAL.Admission.Instance.nbCondidatsccna1(DropDownList3.SelectedValue.ToString().Substring(0, 10));
            LabCount.Text = a.ToString();//DropDownList3.SelectedValue.ToString();//System.DateTime.ToShortDateString("");// DropDownList3.SelectedValue.ToString("dd-mm-yy");
            //  Label25.Text =  DateTime.Parse(DropDownList3.SelectedValue).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).ToUpper();

            DropDownList4.Items.Clear();
            DropDownList4.DataBind();
            //if ((LabCount.Text == "2"))
            //{
            //    DropDownList4.Visible = false;
            //}
            //else 
            //{
            //    DropDownList4.Visible = true;
            //}
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            Response.Redirect("http://www.netacad.com/self-enroll;jsessionid=CA19D9722F633FBBF3C6684E5587A754.node1?p_p_auth=jpDs7Zrx&p_p_id=selfenroll_WAR_selfenrollportlet&p_p_lifecycle=0&p_o_p_id=56_INSTANCE_PWlZv0V6YydF");

        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.netacad.com/self-enroll;jsessionid=CA19D9722F633FBBF3C6684E5587A754.node1?p_p_auth=jpDs7Zrx&p_p_id=selfenroll_WAR_selfenrollportlet&p_p_lifecycle=0&p_o_p_id=56_INSTANCE_PWlZv0V6YydF");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {

                if (Convert.ToString(row.Cells[2].Text) == "1")
                {
                    row.BackColor = System.Drawing.Color.Lime;
                }
            }
        }

        protected void DropDownList4_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }








    }
}