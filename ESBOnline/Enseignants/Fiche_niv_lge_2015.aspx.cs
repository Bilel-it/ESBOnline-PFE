using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Drawing;
using System.Data;
using System.IO;

namespace ESPOnline.Enseignants
{
    public partial class Fiche_niv_lge_2015 : System.Web.UI.Page
    {
        LangueService service = new LangueService();
        string id_ens;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            if (!IsPostBack)
            {

            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerId = Gridstudent.DataKeys[e.Row.RowIndex].Value.ToString();
                //Label lblId = (Label)Gridstudent.Rows[e.Row.RowIndex].FindControl("lblId");
                GridView gvOrders = e.Row.FindControl("gvOrders") as GridView;
                gvOrders.DataSource = service.fiche_historique(customerId);
                gvOrders.DataBind();

                
                DataRow row = ((DataRowView)e.Row.DataItem).Row;
                bool redCondition = row.Field<string>("niveau_courant_fr") == "B2";
                bool redConditionB2 = row.Field<string>("niveau_courant_ang") == "B2";
                if (redCondition == true && redConditionB2 == true)
                {
                    e.Row.BackColor = redCondition ? Color.BlanchedAlmond : Gridstudent.RowStyle.BackColor;
                    e.Row.BackColor = redConditionB2 ? Color.BlanchedAlmond : Gridstudent.RowStyle.BackColor;
                }
                }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlannee_debM.SelectedValue != null)
            {
                id_ens = Session["ID_ENS"].ToString();
                ddclasse2.DataTextField = "code_cl";
                ddclasse2.DataValueField = "code_cl";
                ddclasse2.DataSource = service.bind_classes_1516(id_ens, ddlannee_debM.SelectedValue);
                ddclasse2.DataBind();

                ddclasse2.Items.Insert(0, new ListItem("Veuillez choisir", "Veuillez choisir"));
                ddclasse2.SelectedItem.Selected = false;
                ddclasse2.Items.FindByText("Veuillez choisir").Selected = true;
            }
        }

       

        protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Gridstudent.DataSource = service.fiche_niveau_langue(ddclasse2.SelectedValue, ddlannee_debM.SelectedValue);
            Gridstudent.DataBind();
            Gridstudent.Visible = true;
            Button3.Visible = true;
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Etat_niveau.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                Gridstudent.AllowPaging = false;
                Gridstudent.DataSource = service.fiche_niveau_langue(ddclasse2.SelectedValue, ddlannee_debM.SelectedValue);
                Gridstudent.DataBind();
                Gridstudent.Visible = true;

                Gridstudent.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in Gridstudent.HeaderRow.Cells)
                {
                    cell.BackColor = Gridstudent.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in Gridstudent.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = Gridstudent.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = Gridstudent.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                Gridstudent.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}