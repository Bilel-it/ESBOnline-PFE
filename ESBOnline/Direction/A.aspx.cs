using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using admiss;
using Telerik.Web.UI;
namespace ESPOnline.Direction
{
    public partial class A : System.Web.UI.Page
    {
        OracleTransaction myTrans;
        public void commicttrans()
        {
            myTrans.Commit();
        }
        public void rollbucktrans()
        {
            myTrans.Rollback();
        }
        public OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString2);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            RadGrid1.ClientSettings.Scrolling.AllowScroll = true;
            RadGrid1.ClientSettings.Scrolling.UseStaticHeaders = true;
        }
        protected void RadGrid1_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            string idET = ((userControl.FindControl("Label1") as Label).Text);
            string LIEU_NAIS_ARB1 = ((userControl.FindControl("TextBox10") as TextBox).Text);
            string PNOM_ARB1 = ((userControl.FindControl("TextBox8") as TextBox).Text);
            string NOM_ARB1 = ((userControl.FindControl("TextBox9") as TextBox).Text);
            string NATURE_BAC_ARB1 = ((userControl.FindControl("TextBox11") as TextBox).Text);
            string ETAB_ORIGINE_ARB1 = ((userControl.FindControl("TextBox14") as TextBox).Text);
            string DIPLOME_SUP_ARB1 = ((userControl.FindControl("TextBox13") as TextBox).Text);
            con.Open();

            OracleCommand cmd = new OracleCommand(" UPDATE ESP_ETUDIANT SET LIEU_NAIS_ARB='" + LIEU_NAIS_ARB1 + "',NOM_ARB='" + PNOM_ARB1 + "',PNOM_ARB='" + NOM_ARB1 + "',NATURE_BAC_ARB='" + NATURE_BAC_ARB1 + "',ETAB_ORIGINE_ARB='" + ETAB_ORIGINE_ARB1 + "',DIPLOME_SUP_ARB='" + DIPLOME_SUP_ARB1 + "' where id_et='" + idET + "'  ");


            cmd.Connection = con;

            cmd.Transaction = myTrans;
            try
            {
                cmd.ExecuteNonQuery();
                //myTrans.Commit();
                Label lblError2 = new Label();
                lblError2.Text = "Modification avec succée";
                lblError2.ForeColor = System.Drawing.Color.Green;
                RadGrid1.Controls.Add(lblError2);
            }
            catch (Exception ex)
            {
                Label lblError1 = new Label();

                lblError1.Text = "La mise à jour a échoué ...";
                lblError1.ForeColor = System.Drawing.Color.Red;
                RadGrid1.Controls.Add(lblError1);
            }

        }
    }
}