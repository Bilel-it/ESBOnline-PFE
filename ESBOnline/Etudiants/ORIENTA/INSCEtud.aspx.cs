using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Oracle.DataAccess.Types;
using BLL;

namespace ESPOnline.Etudiants
{
    public partial class INSCEtud : System.Web.UI.Page
    {

        public string ID_ET;
        public string Code_Cl;
        //, "4INFOB1", "4INFOB2", "4INFOB3"
        List<string> classeall = new List<string> { "3A1", "3A10", "3A11", "3A12", "3A13", "3A14", "3A15", "3A16", "3A17", "3A18", "3A19", "3A2", "3A20", "3A21", "3A3", "3A4", "3A5", "3A6", "3A7", "3A8", "3A9", "3B1", "3B2", "3B3", "3B4", "3B5", "3EMA1", "3EMA2", "3EMA3", "3EMB1", "3EMB2", "3EME1", "3EME2" };
        List<string> classeA = new List<string> { "3A1", "3A10", "3A11", "3A12", "3A13", "3A14", "3A15", "3A16", "3A17", "3A18", "3A19", "3A2", "3A20", "3A21", "3A3", "3A4", "3A5", "3A6", "3A7", "3A8", "3A9" };
        List<string> classeB = new List<string> { "3B1", "3B2", "3B3", "3B4", "3B5" };
        List<string> classeC = new List<string> { "4INFOB1", "4INFOB2", "4INFOB3" };
        List<string> classe3em = new List<string> { "3EMA1", "3EMA2", "3EMA3" };
        List<string> classe3emb = new List<string> { "3EMB1", "3EMB2", "3EME1", "3EME2" };
        List<string> lisrempinfA = new List<string> { "ArcTic (cloud)", "ERP-BI", "GL", "INFINI", "NIDS (sécurité)", "SIM", "SLEAM", "WEB(TWIN)" };
        List<string> lisremptelA = new List<string> { "ISEM", "IRT" };

        List<string> lisrempInfB = new List<string> { "INFINI","INFO B" };
        List<string> lisremptelB = new List<string> { "ISEM", "IRT" };

        List<string> lisrempInfC = new List<string> { "GL", "BI", "MOBILE","ClOUD" };
       // List<string> lisremptelC = new List<string> { "ISEM", "IRT" };
        List<string> lisremp3em = new List<string> { "OGI A", "Méca A" };
        List<string> lisremp3emb = new List<string> { "OGI B", "Méca B" };
        List<string> lischoix = new List<string> { };
        OrientationDAO orientdao = new OrientationDAO();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
              ID_ET = Session["ID_ET"].ToString();
           
            Code_Cl = DAL.OrientationDAO.getlcodecl(ID_ET, "2014");
           
            LabCodeCl.Text = Code_Cl;
           

            if (!Page.IsPostBack)
            {
                if (!classeall.Contains(Code_Cl))
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Page Pour Les 3èmes A,B  Informatique B et 3èmes Electromécanique ')</script>");

                    DropDownListSpec.Enabled = false;
                    LabCodeCl.BackColor = System.Drawing.Color.Red;
                    LabCodeCl.Text = "Votre Classe est : " + LabCodeCl.Text + "  " + " Page Pour Les 3èmes A,B et 4èmes Informatique B et 3èmes Electromécanique ";


                 

                }

                else
                {
                    if (orientdao.veriforientation(ID_ET, "2014"))
                    {
                        Response.Write("<script LANGUAGE='JavaScript'> alert('Vous avez deja effectué Lorientation Vous pouvez Modifié votre Choix')</script>");
                        if (Code_Cl.Substring(0, 1) == "4")
                        {
                            DropDownListSpec.SelectedValue = "INFORMATIQUE"; DropDownListSpec.Enabled = false; Panel1.Visible = true;

                        }
                        else if (Code_Cl.Substring(0, 3).Contains("M"))
                        {
                            DropDownListSpec.Items.Add("Electromecanique");
                            DropDownListSpec.SelectedValue = "Electromecanique"; DropDownListSpec.Enabled = false; Panel3.Visible = true;
                        }


                        #region bind infoA

                        lischoix.Clear();

                        DDChinfA1.DataSource = lisrempinfA.OrderBy(s => Guid.NewGuid());
                        DDChinfA1.DataBind();
                        lischoix.Add(DDChinfA1.SelectedValue);


                        DDChinfA2.DataSource = lisrempinfA.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DDChinfA2.DataBind();
                        lischoix.Add(DDChinfA2.SelectedValue);

                        DDChinfA3.DataSource = lisrempinfA.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DDChinfA3.DataBind();
                        lischoix.Add(DDChinfA3.SelectedValue);

                        DDChinfA4.DataSource = lisrempinfA.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DDChinfA4.DataBind();
                        lischoix.Add(DDChinfA4.SelectedValue);

                        DDChinfA5.DataSource = lisrempinfA.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DDChinfA5.DataBind();
                        lischoix.Add(DDChinfA5.SelectedValue);


                        DDChinfA6.DataSource = lisrempinfA.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DDChinfA6.DataBind();
                        lischoix.Add(DDChinfA6.SelectedValue);


                        DDChinfA7.DataSource = lisrempinfA.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DDChinfA7.DataBind();
                        lischoix.Add(DDChinfA7.SelectedValue);
                        DDChinfA8.DataSource = lisrempinfA.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DDChinfA8.DataBind();
                        lischoix.Add(DDChinfA8.SelectedValue);
                        #endregion

                        #region bind 3 tel a

                        lischoix.Clear();

                        DDChTelA1.DataSource = lisremptelA.OrderBy(s => Guid.NewGuid());
                        DDChTelA1.DataBind();
                        lischoix.Add(DDChTelA1.SelectedValue);

                        DDChTelA2.DataSource = lisremptelA.Except(lischoix).OrderBy(s => Guid.NewGuid());
                        DDChTelA2.DataBind();
                        lischoix.Add(DDChTelA2.SelectedValue);

                        #endregion

                        #region bind 3 inf B

                        lischoix.Clear();

                        DDChinfB1.DataSource = lisrempInfB.OrderBy(s => Guid.NewGuid());
                        DDChinfB1.DataBind();
                        lischoix.Add(DDChinfB1.SelectedValue);
                          DDChinfB2.DataSource = lisrempInfB.Except(lischoix).OrderBy(s => Guid.NewGuid());
                        DDChinfB2.DataBind();
                        lischoix.Add(DDChinfB2.SelectedValue);

                        #endregion

                        #region bind 3 tel B

                        lischoix.Clear();

                        DDChTelB1.DataSource = lisremptelB.OrderBy(s => Guid.NewGuid());
                        DDChTelB1.DataBind();
                        lischoix.Add(DDChTelB1.SelectedValue);

                        DDChTelB2.DataSource = lisremptelB.Except(lischoix).OrderBy(s => Guid.NewGuid());
                        DDChTelB2.DataBind();
                        lischoix.Add(DDChTelB2.SelectedValue);

                        #endregion

                        #region bind 4infoB


                        lischoix.Clear();

                        DropDownList1.DataSource = lisrempInfC.OrderBy(s => Guid.NewGuid());
                        DropDownList1.DataBind();
                        lischoix.Add(DropDownList1.SelectedValue);


                        DropDownList2.DataSource = lisrempInfC.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DropDownList2.DataBind();
                        lischoix.Add(DropDownList2.SelectedValue);

                        DropDownList3.DataSource = lisrempInfC.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DropDownList3.DataBind();
                        lischoix.Add(DropDownList3.SelectedValue);

                        DropDownList4.DataSource = lisrempInfC.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DropDownList4.DataBind();
                        lischoix.Add(DropDownList4.SelectedValue);

                        #endregion
                     if(Code_Cl.Substring(0, 3).Contains("M")&&Code_Cl.Substring(0,4)=="3EMA")
                     {   
                         #region bind 3EM
                        lischoix.Clear();

                        DropDownList5.DataSource = lisremp3em.OrderBy(s => Guid.NewGuid());
                        DropDownList5.DataBind();
                        lischoix.Add(DropDownList5.SelectedValue);


                        DropDownList6.DataSource = lisremp3em.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DropDownList6.DataBind();
                        lischoix.Add(DropDownList6.SelectedValue);

                       
                        #endregion

                     }
                     else if(Code_Cl.Substring(0, 3).Contains("M")&& (Code_Cl.Substring(0, 4) == ("3EMB") || Code_Cl.Substring(0, 4) == ("3EME"))) 
                     {
                         #region bind 3EM
                         lischoix.Clear();

                         DropDownList5.DataSource = lisremp3emb.OrderBy(s => Guid.NewGuid());
                         DropDownList5.DataBind();
                         lischoix.Add(DropDownList5.SelectedValue);


                         DropDownList6.DataSource = lisremp3emb.Except(lischoix).OrderBy(s => Guid.NewGuid());

                         DropDownList6.DataBind();
                         lischoix.Add(DropDownList6.SelectedValue);


                         #endregion
                     }
                        




                    }
                    else
                    {
                        if (Code_Cl.Substring(0, 1) == "4")
                        {
                            DropDownListSpec.SelectedValue = "INFORMATIQUE"; DropDownListSpec.Enabled = false; Panel1.Visible = true;

                        }
                        else if (Code_Cl.Substring(0, 3).Contains("M"))
                        {
                            DropDownListSpec.Items.Add("Electromecanique");
                            DropDownListSpec.SelectedValue = "Electromecanique"; DropDownListSpec.Enabled = false; Panel3.Visible = true;
                        }
                        if (Code_Cl.Substring(0, 3).Contains("M")&&Code_Cl.Substring(0, 4) == "3EMA")
                        {
                            #region bind 3EM
                            lischoix.Clear();

                            DropDownList5.DataSource = lisremp3em.OrderBy(s => Guid.NewGuid());
                            DropDownList5.DataBind();
                            lischoix.Add(DropDownList5.SelectedValue);


                            DropDownList6.DataSource = lisremp3em.Except(lischoix).OrderBy(s => Guid.NewGuid());

                            DropDownList6.DataBind();
                            lischoix.Add(DropDownList6.SelectedValue);


                            #endregion

                        }
                        else if (Code_Cl.Substring(0, 3).Contains("M")&&(Code_Cl.Substring(0, 4) == ("3EMB") || Code_Cl.Substring(0, 4) == ("3EME")))
                        {
                            #region bind 3EM
                            lischoix.Clear();

                            DropDownList5.DataSource = lisremp3emb.OrderBy(s => Guid.NewGuid());
                            DropDownList5.DataBind();
                            lischoix.Add(DropDownList5.SelectedValue);


                            DropDownList6.DataSource = lisremp3emb.Except(lischoix).OrderBy(s => Guid.NewGuid());

                            DropDownList6.DataBind();
                            lischoix.Add(DropDownList6.SelectedValue);


                            #endregion
                        }
                        


                        #region bind infoA

                        lischoix.Clear();

                        DDChinfA1.DataSource = lisrempinfA.OrderBy(s => Guid.NewGuid());
                        DDChinfA1.DataBind();
                        lischoix.Add(DDChinfA1.SelectedValue);


                        DDChinfA2.DataSource = lisrempinfA.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DDChinfA2.DataBind();
                        lischoix.Add(DDChinfA2.SelectedValue);

                        DDChinfA3.DataSource = lisrempinfA.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DDChinfA3.DataBind();
                        lischoix.Add(DDChinfA3.SelectedValue);

                        DDChinfA4.DataSource = lisrempinfA.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DDChinfA4.DataBind();
                        lischoix.Add(DDChinfA4.SelectedValue);
                        DDChinfA5.DataSource = lisrempinfA.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DDChinfA5.DataBind();
                        lischoix.Add(DDChinfA5.SelectedValue);


                        DDChinfA6.DataSource = lisrempinfA.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DDChinfA6.DataBind();
                        lischoix.Add(DDChinfA6.SelectedValue);


                        DDChinfA7.DataSource = lisrempinfA.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DDChinfA7.DataBind();
                        lischoix.Add(DDChinfA7.SelectedValue);
                        DDChinfA8.DataSource = lisrempinfA.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DDChinfA8.DataBind();
                        lischoix.Add(DDChinfA8.SelectedValue);
                        #endregion

                        #region bind 3 tel a

                        lischoix.Clear();

                        DDChTelA1.DataSource = lisremptelA.OrderBy(s => Guid.NewGuid());
                        DDChTelA1.DataBind();
                        lischoix.Add(DDChTelA1.SelectedValue);

                        DDChTelA2.DataSource = lisremptelA.Except(lischoix).OrderBy(s => Guid.NewGuid());
                        DDChTelA2.DataBind();
                        lischoix.Add(DDChTelA2.SelectedValue);

                        #endregion

                        #region bind 3 inf B

                        lischoix.Clear();

                        DDChinfB1.DataSource = lisrempInfB.OrderBy(s => Guid.NewGuid());
                        DDChinfB1.DataBind();
                        lischoix.Add(DDChinfB1.SelectedValue);
                        DDChinfB2.DataSource = lisrempInfB.Except(lischoix).OrderBy(s => Guid.NewGuid());
                        DDChinfB2.DataBind();
                        lischoix.Add(DDChinfB2.SelectedValue);


                        #endregion

                        #region bind 3 tel B

                        lischoix.Clear();

                        DDChTelB1.DataSource = lisremptelB.OrderBy(s => Guid.NewGuid());
                        DDChTelB1.DataBind();
                        lischoix.Add(DDChTelB1.SelectedValue);

                        DDChTelB2.DataSource = lisremptelB.Except(lischoix).OrderBy(s => Guid.NewGuid());
                        DDChTelB2.DataBind();
                        lischoix.Add(DDChTelB2.SelectedValue);

                        #endregion
                        #region bind 4infob

                        lischoix.Clear();

                        DropDownList1.DataSource = lisrempInfC.OrderBy(s => Guid.NewGuid());
                        DropDownList1.DataBind();
                        lischoix.Add(DropDownList1.SelectedValue);


                        DropDownList2.DataSource = lisrempInfC.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DropDownList2.DataBind();
                        lischoix.Add(DropDownList2.SelectedValue);

                        DropDownList3.DataSource = lisrempInfC.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DropDownList3.DataBind();
                        lischoix.Add(DropDownList3.SelectedValue);

                        DropDownList4.DataSource = lisrempInfC.Except(lischoix).OrderBy(s => Guid.NewGuid());

                        DropDownList4.DataBind();
                        lischoix.Add(DropDownList4.SelectedValue);
                        #endregion

                    }
                }




            }
        }





        protected void DropDownListSpec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListSpec.SelectedValue == "TELECOM")
            {
                if (classeA.Contains(Code_Cl))
                { Panel1.Visible=false;
                    PanelBTEL.Visible = false;
                    panelATELECOM.Visible = true;
                    P3Ainfo.Visible = false;
                    PanelBinfo.Visible = false; Panel3.Visible = false;
                }
                else if (classeB.Contains(Code_Cl))
                {  Panel1.Visible=false;
                    panelATELECOM.Visible = false;
                    PanelBTEL.Visible = true;

                    Panel3.Visible = false;

                    P3Ainfo.Visible = false;
                    PanelBinfo.Visible = false;


                }
               

            }
            else if (DropDownListSpec.SelectedValue == "INFORMATIQUE")
            {
                if (classeA.Contains(Code_Cl))
                {
                    PanelBinfo.Visible = false;
                    P3Ainfo.Visible = true;
                    Panel1.Visible = false;
                    PanelBTEL.Visible = false;
                    panelATELECOM.Visible = false;
                    Panel3.Visible = false;

                }
                else if (classeB.Contains(Code_Cl))
                {
                    P3Ainfo.Visible = false;
                    PanelBinfo.Visible = true;

                    PanelBTEL.Visible = false;
                    panelATELECOM.Visible = false;
                    Panel1.Visible = false;
                    Panel3.Visible = false;
                }
                else if (classeC.Contains(Code_Cl))
                {
                    Panel3.Visible = false;
                    Panel1.Visible = true;
                    panelATELECOM.Visible = false;
                    PanelBTEL.Visible = false;



                    P3Ainfo.Visible = false;
                    PanelBinfo.Visible = false;

                }
            }
            else if (DropDownListSpec.SelectedValue == "Electromecanique")
            {
                Panel1.Visible = false;
                panelATELECOM.Visible = false;
                PanelBTEL.Visible = false;

                Panel3.Visible = true;

                P3Ainfo.Visible = false;
                PanelBinfo.Visible = false;
            }
            else
            {
                Panel1.Visible = false;
                panelATELECOM.Visible = false;
                PanelBTEL.Visible = false;

                Panel3.Visible = false;

                P3Ainfo.Visible = false;
                PanelBinfo.Visible = false;
            }
        }

        protected void DDChinfA1_SelectedIndexChanged(object sender, EventArgs e)
        {

            lischoix.Clear();

            lischoix.Add(DDChinfA1.SelectedValue);

            DDChinfA2.DataSource = lisrempinfA.Except(lischoix);
            DDChinfA2.DataBind();

            lischoix.Add(DDChinfA2.SelectedValue);

            DDChinfA3.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA3.DataBind();

            lischoix.Add(DDChinfA3.SelectedValue);



            DDChinfA4.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA4.DataBind();
            lischoix.Add(DDChinfA4.SelectedValue);
            DDChinfA5.DataSource = lisrempinfA.Except(lischoix);
            DDChinfA5.DataBind();

            lischoix.Add(DDChinfA5.SelectedValue);

            DDChinfA6.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA6.DataBind();

            lischoix.Add(DDChinfA6.SelectedValue);



            DDChinfA7.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA7.DataBind();
            lischoix.Add(DDChinfA7.SelectedValue);

            DDChinfA8.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA8.DataBind();
            lischoix.Add(DDChinfA8.SelectedValue);

        }

        protected void DDChinfA2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DDChinfA1.SelectedValue);



            lischoix.Add(DDChinfA2.SelectedValue);

            DDChinfA3.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA3.DataBind();

            lischoix.Add(DDChinfA3.SelectedValue);



            DDChinfA4.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA4.DataBind();
            lischoix.Add(DDChinfA4.SelectedValue);
            DDChinfA5.DataSource = lisrempinfA.Except(lischoix);
            DDChinfA5.DataBind();

            lischoix.Add(DDChinfA5.SelectedValue);

            DDChinfA6.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA6.DataBind();

            lischoix.Add(DDChinfA6.SelectedValue);



            DDChinfA7.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA7.DataBind();
            lischoix.Add(DDChinfA7.SelectedValue);

            DDChinfA8.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA8.DataBind();
            lischoix.Add(DDChinfA8.SelectedValue);
        }

        protected void DDChinfA3_SelectedIndexChanged(object sender, EventArgs e)
        {

            lischoix.Clear();

            lischoix.Add(DDChinfA1.SelectedValue);



            lischoix.Add(DDChinfA2.SelectedValue);



            lischoix.Add(DDChinfA3.SelectedValue);



            DDChinfA4.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA4.DataBind();
            lischoix.Add(DDChinfA4.SelectedValue);
            DDChinfA5.DataSource = lisrempinfA.Except(lischoix);
            DDChinfA5.DataBind();

            lischoix.Add(DDChinfA5.SelectedValue);

            DDChinfA6.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA6.DataBind();

            lischoix.Add(DDChinfA6.SelectedValue);



            DDChinfA7.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA7.DataBind();
            lischoix.Add(DDChinfA7.SelectedValue);

            DDChinfA8.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA8.DataBind();
            lischoix.Add(DDChinfA8.SelectedValue);

        }

        protected void DDChinfA4_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DDChinfA1.SelectedValue);



            lischoix.Add(DDChinfA2.SelectedValue);



            lischoix.Add(DDChinfA3.SelectedValue);




            lischoix.Add(DDChinfA4.SelectedValue);
            DDChinfA5.DataSource = lisrempinfA.Except(lischoix);
            DDChinfA5.DataBind();

            lischoix.Add(DDChinfA5.SelectedValue);

            DDChinfA6.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA6.DataBind();

            lischoix.Add(DDChinfA6.SelectedValue);



            DDChinfA7.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA7.DataBind();
            lischoix.Add(DDChinfA7.SelectedValue);

            DDChinfA8.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA8.DataBind();
            lischoix.Add(DDChinfA8.SelectedValue);
        }

        protected void DDChTelA1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DDChTelA1.SelectedValue);

            DDChTelA2.DataSource = lisremptelA.Except(lischoix);
            DDChTelA2.DataBind();

            lischoix.Add(DDChTelA2.SelectedValue);



        }

        protected void DDChTelA2_SelectedIndexChanged(object sender, EventArgs e)
        {

            lischoix.Clear();

            lischoix.Add(DDChTelA1.SelectedValue);



            lischoix.Add(DDChTelA2.SelectedValue);
        }

        protected void DDChTelB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DDChTelB1.SelectedValue);

            DDChTelB2.DataSource = lisremptelB.Except(lischoix);
            DDChTelB2.DataBind();

            lischoix.Add(DDChTelB2.SelectedValue);

        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            try
            {
                ESP_ORIENTATION re = new ESP_ORIENTATION();
                re.ANNEE_DEB = "2014";
                re.CH1 = DDChinfA1.SelectedValue;
                re.CH2 = DDChinfA2.SelectedValue;
                re.CH3 = DDChinfA3.SelectedValue;
                re.CH4 = DDChinfA4.SelectedValue;
                re.CH5 = DDChinfA5.SelectedValue;
                re.CH6 = DDChinfA6.SelectedValue;
                re.CH7 = DDChinfA7.SelectedValue;
                re.CH8 = DDChinfA8.SelectedValue;
                re.DATE_SAISIE = OracleDate.GetSysDate().Value;
                re.SPECIALITE = DropDownListSpec.SelectedValue;
                re.CODE_CL = Code_Cl;

                re.ID_ET = ID_ET;



              
                OrientationDAO orientdao = new OrientationDAO();


                orientdao.addorient(re);
                

                    Response.Write("<script LANGUAGE='JavaScript'> alert('Choix Envoyer avec succés')</script>");

                

                
            }
            catch 
            {
                //string confirmValue = Request.Form["confirm_value"];
                //if (confirmValue == "Yes")
                //{
                    // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);


                    ESP_ORIENTATION re = new ESP_ORIENTATION();
                    re.ANNEE_DEB = "2014";
                    re.CH1 = DDChinfA1.SelectedValue;
                    re.CH2 = DDChinfA2.SelectedValue;
                    re.CH3 = DDChinfA3.SelectedValue;
                    re.CH4 = DDChinfA4.SelectedValue;
                    re.CH5 = DDChinfA5.SelectedValue;
                    re.CH6 = DDChinfA6.SelectedValue;
                    re.CH7 = DDChinfA7.SelectedValue;
                    re.CH8 = DDChinfA8.SelectedValue;
                    re.DATE_SAISIE = OracleDate.GetSysDate().Value;
                    re.SPECIALITE = DropDownListSpec.SelectedValue;
                    re.CODE_CL = Code_Cl;

                    re.ID_ET = ID_ET;



                    //BLL.orient ajt = new orient();
                    //OrientationDAO orientdao = new OrientationDAO();

                    if (orientdao.deleteorient(ID_ET, "2014"))
                    {


                        if (orientdao.addorient(re))
                        {

                            Response.Write("<script LANGUAGE='JavaScript'> alert('Choix Envoyer avec succés')</script>");

                        }

                        else
                        {
                            Response.Write("<script LANGUAGE='JavaScript'> alert(' Envoie echoué')</script>");
                        }
                    }
                 

                    
                }
            
           // }
            DataList1.DataBind();


        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            try
            {
                ESP_ORIENTATION re = new ESP_ORIENTATION();
                re.ANNEE_DEB = "2014";
                re.CH1 = DDChTelA1.SelectedValue;
                re.CH2 = DDChTelA2.SelectedValue;
                re.CH3 = "";
                re.CH4 = "";
                re.DATE_SAISIE = OracleDate.GetSysDate().Value;

                re.SPECIALITE = DropDownListSpec.SelectedValue;
                re.CODE_CL = Code_Cl;

                re.ID_ET = ID_ET;






                //BLL.orient ajt = new orient();
                OrientationDAO orientdao = new OrientationDAO();


                if (orientdao.addorient(re))
                {

                    Response.Write("<script LANGUAGE='JavaScript'> alert('Choix Envoyer avec succés')</script>");

                }

                else
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert(' Envoie echoué')</script>");
                }
            }
            catch 
            {

                ESP_ORIENTATION re = new ESP_ORIENTATION();

                re.ANNEE_DEB = "2014";
                re.CH1 = DDChTelA1.SelectedValue;
                re.CH2 = DDChTelA2.SelectedValue;
                re.CH3 = "";
                re.CH4 = "";
                re.DATE_SAISIE = OracleDate.GetSysDate().Value;

                re.SPECIALITE = DropDownListSpec.SelectedValue;
                re.CODE_CL = Code_Cl;

                re.ID_ET = ID_ET;

                if (orientdao.deleteorient(ID_ET, "2014"))
                {


                    if (orientdao.addorient(re))
                    {

                        Response.Write("<script LANGUAGE='JavaScript'> alert('Choix Envoyer avec succés')</script>");

                    }

                    else
                    {
                        Response.Write("<script LANGUAGE='JavaScript'> alert(' Envoie echoué')</script>");
                    }
                }
                else
                {

                }

               
                // OrientationDAO orientdao = new OrientationDAO();


            
            }
            DataList1.DataBind();

        }

        protected void LinkButton13_Click(object sender, EventArgs e)
        {
            try
            {
                ESP_ORIENTATION re = new ESP_ORIENTATION();
                re.ANNEE_DEB = "2014";
                re.CH1 = DDChTelB1.SelectedValue;
                re.CH2 = DDChTelB2.SelectedValue;
                re.CH3 = "";
                re.CH4 = "";
                re.DATE_SAISIE = OracleDate.GetSysDate().Value;
                re.SPECIALITE = DropDownListSpec.SelectedValue;
                re.CODE_CL = Code_Cl;

                re.ID_ET = ID_ET;
                ;



                OrientationDAO orientdao = new OrientationDAO();


                if (orientdao.addorient(re))
                {

                    Response.Write("<script LANGUAGE='JavaScript'> alert('Choix Envoyer avec succés')</script>");

                }

                else
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert(' Envoie echoué')</script>");
                }
            }
            catch {

                ESP_ORIENTATION re = new ESP_ORIENTATION();

                re.ANNEE_DEB = "2014";
                re.CH1 = DDChTelB1.SelectedValue;
                re.CH2 = DDChTelB2.SelectedValue;
                re.CH3 = "";
                re.CH4 = "";
                re.DATE_SAISIE = OracleDate.GetSysDate().Value;

                re.SPECIALITE = DropDownListSpec.SelectedValue;
                re.CODE_CL = Code_Cl;

                re.ID_ET = ID_ET;

                if (orientdao.deleteorient(ID_ET, "2014"))
                {


                    if (orientdao.addorient(re))
                    {

                        Response.Write("<script LANGUAGE='JavaScript'> alert('Choix Envoyer avec succés')</script>");

                    }

                    else
                    {
                        Response.Write("<script LANGUAGE='JavaScript'> alert(' Envoie echoué')</script>");
                    }
                }
                else
                {

                }

               
                // OrientationDAO orientdao = new OrientationDAO();

            
            }
            DataList1.DataBind();

        }

        protected void LinkButton14_Click(object sender, EventArgs e)
        {
            try
            {
                ESP_ORIENTATION re = new ESP_ORIENTATION();
                re.ANNEE_DEB = "2014";
                re.CH1 = DDChinfB1.SelectedValue;
                re.CH2 = DDChinfB2.SelectedValue; ;
                re.CH3 = "";
                re.CH4 = "";
                re.DATE_SAISIE = OracleDate.GetSysDate().Value;
                re.SPECIALITE = DropDownListSpec.SelectedValue;
                re.CODE_CL = Code_Cl;

                re.ID_ET = ID_ET;
                ;



                OrientationDAO orientdao = new OrientationDAO();


                if (orientdao.addorient(re))
                {

                    Response.Write("<script LANGUAGE='JavaScript'> alert('Choix Envoyer avec succés')</script>");

                }

                else
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert(' Envoie echoué')</script>");
                }
            }
            catch
            {
                ESP_ORIENTATION re = new ESP_ORIENTATION();

                re.ANNEE_DEB = "2014";
                re.CH1 = DDChinfB1.SelectedValue;
                re.CH2 = DDChinfB2.SelectedValue; ;
                re.CH3 = "";
                re.CH4 = "";
                re.DATE_SAISIE = OracleDate.GetSysDate().Value;

                re.SPECIALITE = DropDownListSpec.SelectedValue;
                re.CODE_CL = Code_Cl;

                re.ID_ET = ID_ET;

                if (orientdao.deleteorient(ID_ET, "2014"))
                {


                    if (orientdao.addorient(re))
                    {

                        Response.Write("<script LANGUAGE='JavaScript'> alert('Choix Envoyer avec succés')</script>");

                    }

                    else
                    {
                        Response.Write("<script LANGUAGE='JavaScript'> alert(' Envoie echoué')</script>");
                    }
                }
                else
                {

                }

              
        
            
            
            }
            DataList1.DataBind();
        }

     




        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DropDownList1.SelectedValue);

            DropDownList2.DataSource = lisrempInfC.Except(lischoix);
            DropDownList2.DataBind();

            lischoix.Add(DropDownList2.SelectedValue);

            DropDownList3.DataSource = lisrempInfC.Except(lischoix);

            DropDownList3.DataBind();

            lischoix.Add(DropDownList3.SelectedValue);

            DropDownList4.DataSource = lisrempInfC.Except(lischoix);

            DropDownList4.DataBind();

            lischoix.Add(DropDownList4.SelectedValue);


          

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DropDownList1.SelectedValue);



            lischoix.Add(DropDownList2.SelectedValue);

            DropDownList3.DataSource = lisrempInfC.Except(lischoix);

            DropDownList3.DataBind();

            lischoix.Add(DropDownList3.SelectedValue);


            DropDownList4.DataSource = lisrempInfC.Except(lischoix);

            DropDownList4.DataBind();

            lischoix.Add(DropDownList4.SelectedValue);

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

            lischoix.Clear();

            lischoix.Add(DropDownList1.SelectedValue);



            lischoix.Add(DropDownList2.SelectedValue);



            lischoix.Add(DropDownList3.SelectedValue);


            DropDownList4.DataSource = lisrempInfC.Except(lischoix);

            DropDownList4.DataBind();

            lischoix.Add(DropDownList4.SelectedValue);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ESP_ORIENTATION re = new ESP_ORIENTATION();
                re.ANNEE_DEB = "2014";
                re.CH1 = DropDownList1.SelectedValue;
                re.CH2 = DropDownList2.SelectedValue;
                re.CH3 = DropDownList3.SelectedValue;
                re.CH4 = DropDownList4.SelectedValue;
                re.DATE_SAISIE = OracleDate.GetSysDate().Value;
                re.SPECIALITE = DropDownListSpec.SelectedValue;
                re.CODE_CL = Code_Cl;

                re.ID_ET = ID_ET;



                //BLL.orient ajt = new orient();
                OrientationDAO orientdao = new OrientationDAO();


                if (orientdao.addorient(re))
                {

                    Response.Write("<script LANGUAGE='JavaScript'> alert('Choix Envoyer avec succés')</script>");

                }

                else
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert(' Envoie echoué')</script>");
                }
            }
            catch
            {
                //string confirmValue = Request.Form["confirm_value"];
                //if (confirmValue == "Yes")
                //{
                    // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);


                    ESP_ORIENTATION re = new ESP_ORIENTATION();
                    re.ANNEE_DEB = "2014";
                    re.CH1 = DropDownList1.SelectedValue;
                    re.CH2 = DropDownList2.SelectedValue;
                    re.CH3 = DropDownList3.SelectedValue;
                    re.CH4 = DropDownList4.SelectedValue;
                    //re.CH2 = DDChinfA2.SelectedValue;
                    //re.CH3 = DDChinfA3.SelectedValue;
                    //re.CH4 = "";
                    re.DATE_SAISIE = OracleDate.GetSysDate().Value;
                    re.SPECIALITE = DropDownListSpec.SelectedValue;
                    re.CODE_CL = Code_Cl;

                    re.ID_ET = ID_ET;



                    //BLL.orient ajt = new orient();
                    //OrientationDAO orientdao = new OrientationDAO();

                    if (orientdao.deleteorient(ID_ET, "2014"))
                    {


                        if (orientdao.addorient(re))
                        {

                            Response.Write("<script LANGUAGE='JavaScript'> alert('Choix Envoyer avec succés')</script>");

                        }

                        else
                        {
                            Response.Write("<script LANGUAGE='JavaScript'> alert(' Envoie echoué')</script>");
                        }
                    }
                    else
                    {

                    }



                    // OrientationDAO orientdao = new OrientationDAO();

                   
               // }
            
            }
            DataList1.DataBind();

        }

        protected void DDChinfA5_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DDChinfA1.SelectedValue);



            lischoix.Add(DDChinfA2.SelectedValue);



            lischoix.Add(DDChinfA3.SelectedValue);




            lischoix.Add(DDChinfA4.SelectedValue);
            lischoix.Add(DDChinfA5.SelectedValue);
            DDChinfA6.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA6.DataBind();

            lischoix.Add(DDChinfA6.SelectedValue);



            DDChinfA7.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA7.DataBind();
            lischoix.Add(DDChinfA7.SelectedValue);

            DDChinfA8.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA8.DataBind();
            lischoix.Add(DDChinfA8.SelectedValue);
        }

        protected void DDChinfA6_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DDChinfA1.SelectedValue);



            lischoix.Add(DDChinfA2.SelectedValue);



            lischoix.Add(DDChinfA3.SelectedValue);




            lischoix.Add(DDChinfA4.SelectedValue);
            lischoix.Add(DDChinfA5.SelectedValue);

            lischoix.Add(DDChinfA6.SelectedValue);


            DDChinfA7.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA7.DataBind();
            lischoix.Add(DDChinfA7.SelectedValue);

            DDChinfA8.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA8.DataBind();
            lischoix.Add(DDChinfA8.SelectedValue);
        }

        protected void DDChinfA7_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DDChinfA1.SelectedValue);



            lischoix.Add(DDChinfA2.SelectedValue);



            lischoix.Add(DDChinfA3.SelectedValue);




            lischoix.Add(DDChinfA4.SelectedValue);
            lischoix.Add(DDChinfA5.SelectedValue);

            lischoix.Add(DDChinfA6.SelectedValue);


            lischoix.Add(DDChinfA7.SelectedValue);


            DDChinfA8.DataSource = lisrempinfA.Except(lischoix);

            DDChinfA8.DataBind();
            lischoix.Add(DDChinfA8.SelectedValue);
        }

        protected void DDChinfA8_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DDChinfA1.SelectedValue);



            lischoix.Add(DDChinfA2.SelectedValue);



            lischoix.Add(DDChinfA3.SelectedValue);




            lischoix.Add(DDChinfA4.SelectedValue);
            lischoix.Add(DDChinfA5.SelectedValue);

            lischoix.Add(DDChinfA6.SelectedValue);


            lischoix.Add(DDChinfA7.SelectedValue); lischoix.Add(DDChinfA8.SelectedValue);
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DropDownList1.SelectedValue);



            lischoix.Add(DropDownList2.SelectedValue);



            lischoix.Add(DropDownList3.SelectedValue);
            lischoix.Add(DropDownList4.SelectedValue);


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                ESP_ORIENTATION re = new ESP_ORIENTATION();
                re.ANNEE_DEB = "2014";
                re.CH1 = DropDownList5.SelectedValue;
                re.CH2 = DropDownList6.SelectedValue;
               // re.CH3 = DropDownList7.SelectedValue;
                //re.CH4 = DDChinfA4.SelectedValue;
                re.DATE_SAISIE = OracleDate.GetSysDate().Value;
                re.SPECIALITE = DropDownListSpec.SelectedValue;
                re.CODE_CL = Code_Cl;

                re.ID_ET = ID_ET;



                //BLL.orient ajt = new orient();
                OrientationDAO orientdao = new OrientationDAO();


                if (orientdao.addorient(re))
                {

                    Response.Write("<script LANGUAGE='JavaScript'> alert('Choix Envoyer avec succés')</script>");

                }

                else
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert(' Envoie echoué')</script>");
                }
            }
            catch
            {
                //string confirmValue = Request.Form["confirm_value"];
                //if (confirmValue == "Yes")
                //{
                // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);


                ESP_ORIENTATION re = new ESP_ORIENTATION();
                re.ANNEE_DEB = "2014";
                re.CH1 = DropDownList5.SelectedValue;
                re.CH2 = DropDownList6.SelectedValue;
               // re.CH3 = DropDownList7.SelectedValue;
                //re.CH4 = DDChinfA1.SelectedValue;
                //re.CH2 = DDChinfA2.SelectedValue;
                //re.CH3 = DDChinfA3.SelectedValue;
                //re.CH4 = "";
                re.DATE_SAISIE = OracleDate.GetSysDate().Value;
                re.SPECIALITE = DropDownListSpec.SelectedValue;
                re.CODE_CL = Code_Cl;

                re.ID_ET = ID_ET;



                //BLL.orient ajt = new orient();
                //OrientationDAO orientdao = new OrientationDAO();

                if (orientdao.deleteorient(ID_ET, "2014"))
                {


                    if (orientdao.addorient(re))
                    {

                        Response.Write("<script LANGUAGE='JavaScript'> alert('Choix Envoyer avec succés')</script>");

                    }

                    else
                    {
                        Response.Write("<script LANGUAGE='JavaScript'> alert(' Envoie echoué')</script>");
                    }
                }
                else
                {

                }



                // OrientationDAO orientdao = new OrientationDAO();


                // }

            }
            DataList1.DataBind();
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Code_Cl.Substring(0, 4) == "3EMA")
            {
                lischoix.Clear();

                lischoix.Add(DropDownList5.SelectedValue);

                DropDownList6.DataSource = lisremp3em.Except(lischoix);
                DropDownList6.DataBind();

                lischoix.Add(DropDownList6.SelectedValue);
            }
            else
            {
                lischoix.Clear();

                lischoix.Add(DropDownList5.SelectedValue);

                DropDownList6.DataSource = lisremp3emb.Except(lischoix);
                DropDownList6.DataBind();

                lischoix.Add(DropDownList6.SelectedValue);
            }


          
        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DropDownList5.SelectedValue);

           

            lischoix.Add(DropDownList6.SelectedValue);

        }

        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DropDownList5.SelectedValue);

          
            lischoix.Add(DropDownList6.SelectedValue);

          

           



        }

        protected void DDChinfB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DDChinfB1.SelectedValue);

            DDChinfB2.DataSource = lisrempInfB.Except(lischoix);
            DDChinfB2.DataBind();

            lischoix.Add(DDChinfB2.SelectedValue);




        }

        protected void DDChinfB2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DDChinfB1.SelectedValue);


            lischoix.Add(DDChinfB2.SelectedValue);

        }

        protected void DDChTelB2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lischoix.Clear();

            lischoix.Add(DDChTelB1.SelectedValue);

            

            lischoix.Add(DDChTelB2.SelectedValue);
        }

     






        }
    }
