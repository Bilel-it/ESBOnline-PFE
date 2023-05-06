using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using DAL;
using System.Configuration;
using Oracle.ManagedDataAccess.Types;
using BLL;
using Oracle.ManagedDataAccess.Client;
using ABSEsprit;
 
using System.IO;

namespace ESPOnline.EnseignantsCUP
{
    public partial class Affectation1415 : System.Web.UI.Page
    {
        string x;
        string y;
        string z;
        string gvUniqueID = String.Empty;
        public string anneedeb;
        int gvEditIndex = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            x = Session["UP"].ToString().Trim();
            y = Session["Nom_ENS"].ToString().Trim();
            z = Session["ID_ENS"].ToString().Trim();
            anneedeb = DAL.AffectationDAO.Instance.getanneedeb();

            if (!IsPostBack)
            {
                gvClasses.DataSource = DAL.AffectationDAO.Instance.getListClasse2(z, anneedeb);

                gvClasses.DataBind();
            }

        }
        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            DropDownList ddl = null;
            DropDownList ddltype = null;
            DropDownList ddens2 = null;
            DropDownList ddens3 = null;
            DropDownList ddens4 = null;
            DropDownList ddens5 = null;
          

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddeneseignant") as DropDownList;
                ddltype = e.Row.FindControl("ddepreuve") as DropDownList;

                ddens2 = e.Row.FindControl("ddeneseignant2") as DropDownList;
                ddens3 = e.Row.FindControl("ddeneseignant3") as DropDownList;
                ddens4 = e.Row.FindControl("ddeneseignant4") as DropDownList;
                ddens5 = e.Row.FindControl("ddeneseignant5") as DropDownList;

               
            }

            //DropDownList ddl = e.Row.Cells[9].FindControl("ddeneseignant") as DropDownList;
            if (ddltype != null)
            {
                 
                ddltype.Visible = true;
                ddltype.DataSource = DAL.AffectationDAO.Instance.getlisttypeepreuve();
                ddltype.DataTextField = "LIB_NOME";
                ddltype.DataValueField = "CODE_NOME";
                ddltype.DataBind();
                ddltype.Items.Insert(0, new ListItem(""));

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {

                        string codemodule = ((e.Row.FindControl("lblcodemodule") as Label).Text);
                        string codecl = ((e.Row.FindControl("lblcodecl") as Label).Text); 
                     
                        ddltype.SelectedValue = DAL.AffectationDAO.Instance.gettypeep(codemodule, codecl);

                    }
                }
            }


            # region dropdownens1

            if (ddl != null)
            {
                ddl.Visible = true;
                ddl.DataSource = DAL.AffectationDAO.Instance.getListEnseignant();
                ddl.DataTextField = "NOM_ENS";
                ddl.DataValueField = "ID_ENS";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem(""));

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
 
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        string codemodule = ((e.Row.FindControl("lblcodemodule") as Label).Text);
                        string codecl = ((e.Row.FindControl("lblcodecl") as Label).Text);
                      
                         
                        ddl.SelectedValue = DAL.AffectationDAO.Instance.getens1(codemodule, codecl);

                    }
                }
            }
            # endregion
            # region dropdownens2

            if (ddens2 != null)
            {
                ddens2.Visible = true;
                ddens2.DataSource = DAL.AffectationDAO.Instance.getListEnseignant();
                ddens2.DataTextField = "NOM_ENS";
                ddens2.DataValueField = "ID_ENS";
                ddens2.DataBind();
                ddens2.Items.Insert(0, new ListItem(""));

                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        string codemodule = ((e.Row.FindControl("lblcodemodule") as Label).Text);
                        string codecl = ((e.Row.FindControl("lblcodecl") as Label).Text); 

                        ddens2.SelectedValue = DAL.AffectationDAO.Instance.getens2(codemodule, codecl);

                    }
                }
            }
            # endregion
            # region dropdownens3

            if (ddens3 != null)
            {
                ddens3.Visible = true;
                ddens3.DataSource = DAL.AffectationDAO.Instance.getListEnseignant();
                ddens3.DataTextField = "NOM_ENS";
                ddens3.DataValueField = "ID_ENS";
                ddens3.DataBind();
                ddens3.Items.Insert(0, new ListItem(""));

                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {


                        string codemodule = ((e.Row.FindControl("lblcodemodule") as Label).Text);
                        string codecl = ((e.Row.FindControl("lblcodecl") as Label).Text);


                        ddens3.SelectedValue = DAL.AffectationDAO.Instance.getens3(codemodule, codecl);

                    }
                }
            }
            # endregion
            # region dropdownens4

            if (ddens4 != null)
            {
                ddens4.Visible = true;
                ddens4.DataSource = DAL.AffectationDAO.Instance.getListEnseignant();
                ddens4.DataTextField = "NOM_ENS";
                ddens4.DataValueField = "ID_ENS";
                ddens4.DataBind();
                ddens4.Items.Insert(0, new ListItem(""));

                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        string codemodule = ((e.Row.FindControl("lblcodemodule") as Label).Text);
                        string codecl = ((e.Row.FindControl("lblcodecl") as Label).Text);
                        ddens3.SelectedValue = DAL.AffectationDAO.Instance.getens4(codemodule, codecl);

                    }
                }
            }
            # endregion
            # region dropdownens5

            if (ddens5 != null)
            {
                ddens5.Visible = true;
                ddens5.DataSource = DAL.AffectationDAO.Instance.getListEnseignant();
                ddens5.DataTextField = "NOM_ENS";
                ddens5.DataValueField = "ID_ENS";
                ddens5.DataBind();
                ddens5.Items.Insert(0, new ListItem(""));

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    //if (lblens1 != null)
                    //{
                    //    string country1 = lblens1.Text;
                    //    ddl.Items.FindByText(country1).Selected = true;
                    //}
                    //ddl.SelectedValue =  ID_ENS;
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {

                        string codemodule = ((e.Row.FindControl("lblcodemodule") as Label).Text);
                        string codecl = ((e.Row.FindControl("lblcodecl") as Label).Text);

                        ddens5.SelectedValue = DAL.AffectationDAO.Instance.getens4(codemodule, codecl);

                    }
                }
            }
            # endregion

        }
        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gvTemp = (GridView)sender;
            gvUniqueID = gvTemp.UniqueID;
            gvEditIndex = e.NewEditIndex;
            gvClasses.DataBind();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row;
            if (row.DataItem == null)
            {
                return;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ClasseId = gvClasses.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvAffectation = e.Row.FindControl("gvAffectation") as GridView;
                if (gvAffectation.UniqueID == gvUniqueID)
                {

                    gvAffectation.EditIndex = gvEditIndex;
                    //(string)DataBinder.Eval(e.Row.DataItem, "CODE_CL")
                    ClientScript.RegisterStartupScript(GetType(), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + (string)DataBinder.Eval(e.Row.DataItem, "CODE_CL") + "','one');</script>");
                }
                gvAffectation.DataSource = DAL.AffectationDAO.Instance.getListAfectation4((string)DataBinder.Eval(e.Row.DataItem, "CODE_CL"),"2014",x);
                gvAffectation.DataBind();
            }


        }
        protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {


            GridView gvAffectation = sender as GridView;
            GridViewRow row = gvAffectation.Rows[e.RowIndex];
            gvAffectation.EditIndex = -1;
            string codecl = ((row.Cells[0].FindControl("lblcodecl") as Label).Text);
            //lblMessage.Text = "eee";
          
               

                gvAffectation.DataSource = DAL.AffectationDAO.Instance.getListAfectation4(codecl,"2014",x);
                gvAffectation.DataBind();

            }
        protected void gvAffectation_OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView gvAffectation = sender as GridView;

            GridViewRow row = gvAffectation.Rows[e.NewEditIndex];
            for (int j = 0; j <= gvAffectation.Rows.Count - 1; j++)
            {
                gvAffectation.EditIndex = e.NewEditIndex;
                string codecl = ((row.Cells[0].FindControl("lblcodecl") as Label).Text);

                string codemodule = ((row.Cells[0].FindControl("lblcodemodule") as Label).Text);
                DropDownList ddl = row.FindControl("ddeneseignant") as DropDownList;
                //  DropDownList ddl = (DropDownList)GridView1.Rows[e.NewEditIndex].Cells[9].FindControl("ddeneseignant");
                ClientScript.RegisterStartupScript(GetType(), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + codecl + "','one');</script>");
                //ddl.Visible = false;
                var lblens1 = row.FindControl("ddleneseignant") as Label;
                gvAffectation.DataSource = DAL.AffectationDAO.Instance.getListAfectation4(codecl,"2014",x);
                gvAffectation.DataBind();

            }
        }
protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridView gvAffectation = sender as GridView;
            gvUniqueID = gvAffectation.UniqueID;
            GridViewRow row = gvAffectation.Rows[e.RowIndex];
            string codecl = ((row.Cells[e.RowIndex].FindControl("lblcodecl") as Label).Text);
            // TextBox txtFirstName = row.FindControl("txtIDENS") as TextBox;
            TextBox textp1 = (TextBox)row.FindControl("TBEnsP1");
            TextBox textp2 = (TextBox)row.FindControl("TBEnsP2");
            TextBox text2p1 = (TextBox)row.FindControl("TBEns2P1");
            TextBox text2p2 = (TextBox)row.FindControl("TBEns2P2");
            TextBox text3p1 = (TextBox)row.FindControl("TBEns3P1");
            TextBox text3p2 = (TextBox)row.FindControl("TBEns3P2");
            TextBox text4p1 = (TextBox)row.FindControl("TBEns4P1");
            TextBox text4p2 = (TextBox)row.FindControl("TBEns4P2");
            TextBox text5p1 = (TextBox)row.FindControl("TBEns5P1");
            TextBox text5p2 = (TextBox)row.FindControl("TBEns5P2");
            var lblp1 = row.FindControl("Label4") as Label;
            var lblp2 = row.FindControl("Label5") as Label;
            string ensp1 = lblp1.Text.Trim();
            string ensp2 = lblp2.Text.Trim();
            string ens1 = ensp1.Replace(".", ",");
            string ens2 = ensp2.Replace(".", ",");
            decimal p1 = decimal.Parse(ensp1.Trim());
            decimal p2 = decimal.Parse(ensp2.Trim());
            decimal charge1p1;
            string ch1p1 = textp1.Text.Trim();
            string c1p1 = ch1p1;
         
 
            ch1p1 = c1p1.Replace(".", ",");

            if (ch1p1.Length == 0)
            {
                ch1p1 = "0";
            }
             
            
           
               charge1p1 = decimal.Parse(ch1p1);
            
            string ch1p2 = textp2.Text.Trim();

            string c1p2 = ch1p2;
            ch1p2 = ch1p2.Replace(".", ",");
            if (ch1p2.Length == 0)
            {
                ch1p2 = "0";
            }
           

            // decimal charge1p2 = decimal.Parse(ch1p2);
            decimal charge1p2 = Convert.ToDecimal(ch1p2);

            string ch2p1 = text2p1.Text.Trim();
            string c2p1 = ch2p1;
            ch2p1 = ch2p1.Replace(".", ",");
            if (ch2p1.Length == 0)
            {
                ch2p1 = "0";
            }
            decimal charge2p1 = decimal.Parse(ch2p1);
            string ch2p2 = text2p2.Text.Trim();
            string c2p2 = ch2p2;
            ch2p2 = ch2p2.Replace(".", ",");
            if (ch2p2.Length == 0)
            {
                ch2p2 = "0";
            }
            decimal charge2p2 = decimal.Parse(ch2p2);
            string ch3p1 = text3p1.Text.Trim();
            string c3p1 = ch3p1;
            ch3p1 = ch3p1.Replace(".", ",");
            if (ch3p1.Length == 0)
            {
                ch3p1 = "0";
            }
            decimal charge3p1 = decimal.Parse(ch3p1);
            string ch3p2 = text3p2.Text.Trim();
            string c3p2 = ch3p2;
            ch3p2 = ch3p2.Replace(".", ",");
            if (ch3p2.Length == 0)
            {
                ch3p2 = "0";
            }
            decimal charge3p2 = decimal.Parse(ch3p2);
            string ch4p1 = text4p1.Text.Trim();
            string c4p1 = ch4p1;
            ch4p1 = ch4p1.Replace(".", ",");
            if (ch4p1.Length == 0)
            {
                ch4p1 = "0";
            }
            decimal charge4p1 = decimal.Parse(ch4p1);
            string ch4p2 = text4p2.Text.Trim();
            string c4p2 = ch4p2;
            ch4p2 = ch4p2.Replace(".", ",");
            if (ch4p2.Length == 0)
            {
                ch4p2 = "0";
            }
            decimal charge4p2 = decimal.Parse(ch4p2);
            string ch5p1 = text5p1.Text.Trim();
            string c5p1 = ch5p1;
            ch5p1 = ch5p1.Replace(".", ",");
            if (ch5p1.Length == 0)
            {
                ch5p1 = "0";
            }
            decimal charge5p1 = decimal.Parse(ch5p1);
            string ch5p2 = text5p2.Text.Trim();
            string c5p2 = ch5p2;
            ch5p2 = ch5p2.Replace(".", ",");
            if (ch5p2.Length == 0)
            {
                ch5p2 = "0";
            }
            decimal charge5p2 = decimal.Parse(ch5p2);

            string codemodule = ((row.Cells[e.RowIndex].FindControl("lblcodemodule") as Label).Text);
            //int sem = Convert.ToInt32(((Label)GridView1.Rows[e.RowIndex].FindControl("lblsem")).Text);

            DropDownList ddlens = row.FindControl("ddeneseignant") as DropDownList;
            DropDownList ddlepr = row.FindControl("ddepreuve") as DropDownList;
    DropDownList ddlens2  = row.FindControl("ddeneseignant2") as DropDownList;
    DropDownList ddlens3 = row.FindControl("ddeneseignant3") as DropDownList;
    DropDownList ddlens4 = row.FindControl("ddeneseignant4") as DropDownList;
    DropDownList ddlens5 = row.FindControl("ddeneseignant5") as DropDownList;
   
   


            if (codecl != null && codemodule != null)
            {


                using (Entities ctx = new Entities())
                {
                    var req1 = (
                             from cl in ctx.ESP_MODULE_PANIER_CLASSE_SAISO


                             where cl.CODE_CL.Equals(codecl) && cl.NUM_SEMESTRE.Equals(1) && cl.ANNEE_DEB.Equals("2013") && cl.CODE_MODULE.Equals(codemodule)
                             select cl).SingleOrDefault();
                    //ESP_MODULE_PANIER_CLASSE_SAISO aff = ctx.ESP_MODULE_PANIER_CLASSE_SAISO
                    //    .FirstOrDefault(x => x.CODE_CL == codecl && x.ANNEE_DEB.Equals("2013") && x.NUM_SEMESTRE == sem && x.CODE_MODULE == codemodule);

                    req1.CHARGE_ENS1_P1 = charge1p1;
                    req1.CHARGE_ENS1_P2 = charge1p2;
                    req1.CHARGE_ENS2_P1 = charge2p1;
                    req1.CHARGE_ENS2_P2 = charge1p2;
                    req1.CHARGE_ENS3_P1 = charge3p1;
                    req1.CHARGE_ENS3_P2 = charge3p2;
                    req1.CHARGE_ENS4_P1 = charge4p1;
                    req1.CHARGE_ENS4_P2 = charge4p2;
                    req1.CHARGE_ENS5_P1 = charge5p1;
                    req1.CHARGE_ENS5_P2 = charge5p2;
                    req1.ID_ENS = ddlens.SelectedValue;
                    req1.ID_ENS2 = ddlens2.SelectedValue;
                    req1.ID_ENS3 = ddlens3.SelectedValue;
                    req1.ID_ENS4 = ddlens4.SelectedValue;
                    req1.ID_ENS5 = ddlens5.SelectedValue;
                    req1.TYPE_EPREUVE = ddlepr.SelectedValue;
                    if (charge1p1 <= p1 && charge1p2 <= p2 && charge2p1 <= p1 && charge2p2 <= p2 && charge3p1 <= p1 && charge3p2 <= p2 && charge4p1 <= p1 && charge4p2 <= p2 && charge5p1 <= p1 && charge5p2 <= p2)
                    {
                        ctx.SaveChanges();
                        ClientScript.RegisterStartupScript(Page.GetType(), "key", "showNotification('Enregistrement effectué avec succès "+codecl+" ' )", true);
                    }
                    else ClientScript.RegisterStartupScript(Page.GetType(), "key", "showwarning()", true);
                  
                    gvAffectation.EditIndex = -1;
                

                    ClientScript.RegisterStartupScript(GetType(), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + codecl + "','one');</script>");
                    gvAffectation.DataSource = DAL.AffectationDAO.Instance.getListAfectation4(codecl,"2014",x);
                    gvAffectation.DataBind();

                }
            }




        }
//protected void ExportExcel(object sender, EventArgs e)
//{
//    DataTable dt = new DataTable("GridView_Data");
//    foreach (TableCell cell in GridView1.HeaderRow.Cells)
//    {
//        dt.Columns.Add(cell.Text);
//    }
//    foreach (GridViewRow row in GridView1.Rows)
//    {
//        dt.Rows.Add();
//        for (int i = 0; i < row.Cells.Count; i++)
//        {
//            dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
//        }
//    }
//    using (XLWorkbook wb = new XLWorkbook())
//    {
//        wb.Worksheets.Add(dt);

//        Response.Clear();
//        Response.Buffer = true;
//        Response.Charset = "";
//        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
//        Response.AddHeader("content-disposition", "attachment;filename=Affectation.xlsx");
//        using (MemoryStream MyMemoryStream = new MemoryStream())
//        {
//            wb.SaveAs(MyMemoryStream);
//            MyMemoryStream.WriteTo(Response.OutputStream);
//            Response.Flush();
//            Response.End();
//        }
//    }
//}

        }
    
}