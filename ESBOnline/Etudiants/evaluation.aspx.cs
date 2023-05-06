//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using Evaluation;
 

//namespace ESPOnline.Etudiants
//{
//    public partial class evaluation : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
//            {
//                Response.Redirect("~/Online/default.aspx");
//            }

//            HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");

      
//            if (!Page.IsPostBack)
//            {
//                HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
//                if (Session["ID_ET"] == null)
//                {
//                    Response.Redirect("~/Online/default.aspx");
//                }
//                else
//                {
                  

//                    List<ModulesEval> module = new List<ModulesEval>();
//                    module = ModulesEval.GetList(Session["ID_ET"].ToString());
//                    DDlistmodule.DataSource = module;
//                    DDlistmodule.DataTextField = "DESIGNATION";
//                    DDlistmodule.DataValueField = "CODE_MODULE";
//                    DDlistmodule.DataBind();

//                    // Response.Write(@"<script language='javascript'>alert('Il vous reste  " + (DDlistmodule.Items.Count - 1).ToString() + " Modules à Valider ');</script>");
//                    LabelModule.Text = DDlistmodule.SelectedItem.Text.ToString();

//                    TBnmbr.Text = (DDlistmodule.Items.Count - 1).ToString();
//                    if (TBnmbr.Text != "0")
//                    {
//                        Response.Write(@"<script language='javascript'>alert('Il vous reste  " + TBnmbr.Text + " Modules à Valider ');</script>");
//                    }




//                    Session.Add("code_classe", services.Instance.getCl(Session["ID_ET"].ToString()));

//                    LabelClasse.Text = services.Instance.getCl(Session["ID_ET"].ToString());
//                    LabelClasse.Visible = false;
//                    Panel2.Visible = false;
//                    LabelModule.Text = DDlistmodule.SelectedItem.Text.ToString();

//                    if (DDlistmodule.Items.Count > 1)
//                    {
//                        DDlistmodule.Enabled = true;
//                    }

//                    else DDlistmodule.Enabled = false;

//                }

//            }





//        }

//        protected void DDlistmodule_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
//            LabelModule.Text = DDlistmodule.SelectedItem.Text.ToString();
//            Panel2.Visible = true;
//         //   this.Panel2_ModalPopupExtender.Show();
//            if (DDlistmodule.Items.Count == 1)
//            {
//                DDlistmodule.Enabled = false;
//            }

//        }

//        protected void BTnValidation_Click(object sender, EventArgs e)
//        {
//            HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
//            //LabelModule.Text = Session["code_classe"].ToString();
//            string a = injectionSQL.Sanitize(TBfort.Text);
//            string b = injectionSQL.Sanitize(TBfaible.Text);
//            string c = injectionSQL.Sanitize(TBprop.Text);


//            try
//            {
//                services.Instance.SaveEvalModule(Session["ID_ET"].ToString(), DDlistmodule.SelectedValue.ToString(), Session["code_classe"].ToString(), int.Parse(DropDownList1.SelectedValue), int.Parse(RD1.SelectedValue), int.Parse(RD2.SelectedValue), int.Parse(RD3.SelectedValue), int.Parse(RD4.SelectedValue), int.Parse(RD5.SelectedValue), int.Parse(RD6.SelectedValue), a, b, c); //DDlistmodule.SelectedValue.ToString(), cdc, int.Parse(RD1.SelectedValue), int.Parse(RD2.SelectedValue), int.Parse(RD3.SelectedValue), int.Parse(RD4.SelectedValue), int.Parse(RD5.SelectedValue), TBfort.Text, TBfaible.Text, TBprop.Text);
               

//            }
//            catch (Exception)
//            {

//                Response.Write(@"<script language='javascript'>alert('erreur du server ');</script>");
//            }
//            // services.Instance.SaveEvalModule("10-3MT-833", "", "", 1, 1, 1, 1, 1, "", "", "");
//            // Response.Write(@"<script language='javascript'>alert('Il vous reste  Modules à Valider ');</script>");
//            //Response.AddHeader("REFRESH", "1;URL=listemodule.aspx");


//            Response.Redirect(Request.Url.AbsoluteUri);


//        }

        
//    }
//}