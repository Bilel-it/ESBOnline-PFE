using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.Etudiants
{
    public partial class RES : System.Web.UI.Page
    { public string ID_ET;
        public string TYPE_PV;
        public string CODE_CL;
        public string anneedeb;
        string gvUniqueID = String.Empty;
      
        int gvEditIndex = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            Resultatectservice res = new Resultatectservice();
            anneedeb = DAL.AffectationDAO.Instance.getanneedeb();
            //  anneedeb = res.getanneedebb();
            ID_ET = Session["ID_ET"].ToString();
            //CODE_CL = DAL.OrientationDAO.getlcodecl(ID_ET);
            CODE_CL = res.getlcodecl(ID_ET, anneedeb);
            //TYPE_PV = DAL.OrientationDAO.getTypepv(CODE_CL);
             TYPE_PV = res.getTypepv(CODE_CL, anneedeb);


            if (TYPE_PV.ToString() == "O")
            {
                Response.Redirect("~/Etudiants/ResultatCharguia.aspx");

                gvue.Visible = false;

            }
            else
            {
                if (!IsPostBack)
                {
                    gvue.Visible = true;
                    gvue.DataSource = res.getUE(ID_ET, anneedeb);

                    gvue.DataBind();
                }
                if (gvue.Rows.Count == 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif, Veuillez contacter le service compétent')</script>");
                }



            }
          
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            Resultatectservice res1 = new Resultatectservice();

            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell cell in e.Row.Cells)
                {

                    cell.Attributes.CssStyle["text-align"] = "center";
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label Label2 = (Label)e.Row.FindControl("Label2");
                Label2.Text = res1.Getnbects(ID_ET);
                foreach (TableCell cell in e.Row.Cells)
                {

                    cell.Attributes.CssStyle["text-align"] = "center";
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ueId = gvue.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvOrders = e.Row.FindControl("gvnotes") as GridView;
                gvOrders.DataSource = DAL.ResctsDAO.Instance.GetResFinal2(ID_ET, anneedeb, (string)DataBinder.Eval(e.Row.DataItem, "CODE_UE"));
                gvOrders.DataBind();
                foreach (TableCell cell in e.Row.Cells)
                {

                    cell.Attributes.CssStyle["text-align"] = "center";
                }
              
                if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE")) >= 10)
                {

                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;



                }
                else if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE")) < 10)
                {

                    e.Row.Cells[4].Text = "0";
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;



                }
            }
        }
        protected void OnRowDataBound2(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell cell in e.Row.Cells)
                {

                    cell.Attributes.CssStyle["text-align"] = "center";
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell cell in e.Row.Cells)
                {

                    cell.Attributes.CssStyle["text-align"] = "center";
                }
            }
        }
       
    }
    }
