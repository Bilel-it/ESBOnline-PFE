using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.EmploiEsp
{
    public partial class Ajouter_Matiere : System.Web.UI.Page
    {
        ServiceEDT service = new ServiceEDT();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void btnadd_Click(object sender, EventArgs e)
        {
            try

            {
            service.addModule(TxtCode.Text, txtnom.Text);
            Response.Write(@"<script language='javascript'>alert('Ajout avec succès');</script>");
            }
            catch (Exception)
            {
                Response.Write(@"<script language='javascript'>alert('erreur du server ');</script>");
            }
        }

       
    }
}