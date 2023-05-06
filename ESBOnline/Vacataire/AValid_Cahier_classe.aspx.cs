using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Telerik.Web.UI;
using System.Data;

namespace ESPOnline.Vacataire
{
    public partial class AValid_Cahier_classe : System.Web.UI.Page
    {
        UEService serv = new UEService();
        string ID_ENS;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID_ENS = Session["ID_ENS"].ToString();

            if (!IsPostBack)
            {
                GetModule();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ici bind module
        }

        public void GetModule()
        {
            ID_ENS = Session["ID_ENS"].ToString();
            RadComboBox4.DataTextField = "des";
            RadComboBox4.DataValueField = "code_module";
            RadComboBox4.DataSource = serv.getModuleBYEns(ID_ENS);
            RadComboBox4.DataBind();

        }


        public void GetCL()
        {
            ID_ENS = Session["ID_ENS"].ToString();
            RadComboBox2.DataTextField = "code_cl";
            RadComboBox2.DataValueField = "code_cl";
            RadComboBox2.DataSource = serv.GetCl(ID_ENS, RadComboBox4.SelectedValue);
            RadComboBox2.DataBind();

        }


        public void getseance()
        {
            ID_ENS = Session["ID_ENS"].ToString();

            dropseance.DataTextField = "ENDd";
            dropseance.DataValueField = "ENDd";
            dropseance.DataSource = serv.getseance(ID_ENS,RadComboBox4.SelectedValue, RadComboBox2.SelectedValue);



          
            dropseance.DataBind();

            dropseance.Items.Insert(0, new ListItem("Veuillez choisir", "Veuillez choisir"));
            dropseance.SelectedItem.Selected = false;
            dropseance.Items.FindByText("Veuillez choisir").Selected = true;
        }


        protected void CL_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            getseance();
            td1.Visible = true;

        }




        protected void RadComboBox4_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //ici deance par module
            //getseance();
            td2.Visible = true;
            GetCL();
        }

        protected void ddlseance4(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
           
        }
        protected void OnCheckedChangedDDD(object sender, EventArgs e)
        {
        }


        protected void OnCheckedChanged(object sender, EventArgs e)
        {


        }


        protected void OnRowDataBoundS(object sender, GridViewRowEventArgs e)
        {




            for (int i = 0; i < crd.Rows.Count; i++)
            {
                RadioButtonList RadioButtonds = (crd.Rows[i].FindControl("RadioButtonds")) as RadioButtonList;
                DropDownList DrpPercentageComplete = (crd.Rows[i].FindControl("DrpPercentageComplete")) as DropDownList;
                //(DropDownList)row.FindControl("DrpPercentageComplete");



                if (RadioButtonds.SelectedValue !=null)
                {
                    string ds = crd.Rows[i].Cells[1].Text;

                    if (RadioButtonds.SelectedValue == "doing")
                    {
                        DrpPercentageComplete.Visible = true;
                    }
                    else
                    {
                        DrpPercentageComplete.Visible = false;
                    }
                }
            }
            //GridViewRow row = ((GridViewRow)((RadioButtonList)sender).NamingContainer);
            //DropDownList DrpPercentageComplete = (DropDownList)row.FindControl("DrpPercentageComplete");

            //RadioButtonList RadioButtonds = (RadioButtonList)row.FindControl("RadioButtonds");

            //if (RadioButtonds.SelectedValue == "doing")
            //{
            //    DrpPercentageComplete.Visible = true;
            //}
            //else
            //{
            //    DrpPercentageComplete.Visible = false;
            //}
        }

        private void ShowPopupMessage(string message, PopupMessageType messageType)
        {
            switch (messageType)
            {
                case PopupMessageType.Error:
                    lblMessagePopupHeading.Text = "Error";
                    //Render image in literal control
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("~/Contentcls/images/error.png") + "' alt='' />";
                    break;
                case PopupMessageType.Message:
                    lblMessagePopupHeading.Text = "Information";
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("~/Contentcls/Images/info.png") + "' alt='' />";
                    break;
                case PopupMessageType.Warning:
                    lblMessagePopupHeading.Text = "Warning";
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("~/Contentcls/Images/Warning.png") + "' alt='' />";
                    break;
                case PopupMessageType.Success:
                    lblMessagePopupHeading.Text = "Success";
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("~/Contentcls/Images/success.png") + "' alt='' />";
                    break;
                default:
                    lblMessagePopupHeading.Text = "Information";
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("~/Contentcls/Images/info.png") + "' alt='' />";
                    break;
            }

            lblMessagePopupText.Text = message;
            mpeMessagePopup.Show();
        }

        /// <summary>
        /// Message type enum
        /// </summary>
        public enum PopupMessageType
        {
            Error,
            Message,
            Warning,
            Success
        }



        protected void CountryChanged(object sender, EventArgs e)
        {
            var listControl = (ListControl)sender;
            var row = (GridViewRow)listControl.NamingContainer;
            var item = listControl.SelectedItem;
            RadioButtonList RadioButtonds = (RadioButtonList)row.FindControl("RadioButtonds");

            //  DropDownList DrpPercentageComplete = (DropDownList)row.FindControl("DrpPercentageComplete");

            DropDownList DrpPercentageComplete = (DropDownList)row.FindControl("DrpPercentageComplete");

            //RadioButtonList RadioButtonds = (RadioButtonList)crd.HeaderRow.FindControl("RadioButtonds");



            if (RadioButtonds.SelectedValue == "doing")
            {
                DrpPercentageComplete.Visible = true;
            }
            else
            {
                DrpPercentageComplete.Visible = false;
            }
        }

        /* if(RadioButtonds.SelectedValue != "doing")
                        {
                            DrpPercentageComplete.Visible = true;
                        }
                        else
                        {
                            DrpPercentageComplete.Visible = false;
                        }*/
        protected void Update2(object sender, EventArgs e)
        {
            foreach (GridViewRow row in crd.Rows)
            {
                ID_ENS = Session["ID_ENS"].ToString();
                Label LBLID_ACQUIS = (Label)row.FindControl("LBLID_ACQUIS");
                Label LBLDESIGNATION = (Label)row.FindControl("LBLDESIGNATION");
                Label LBLTITRE_CHAPTER = (Label)row.FindControl("LBLTITRE_CHAPTER");
                Label LBLNUM_CHAPTER = (Label)row.FindControl("LBLNUM_CHAPTER");

                Label LBLCODE_MODULE = (Label)row.FindControl("LBLCODE_MODULE");
                RadioButtonList RadioButtonds = (RadioButtonList)row.FindControl("RadioButtonds");

                DropDownList DrpPercentageComplete = (DropDownList)row.FindControl("DrpPercentageComplete");

                //CheckBox chkSelect = (CheckBox)row.FindControl("CheckBox1");
                if (row.RowType == DataControlRowType.DataRow)
                {

                    //bool isChecked = row.Cells[4].Controls.OfType<CheckBox>().FirstOrDefault().Checked;


                   if (RadioButtonds.SelectedValue != "to_do")
                    { 
                       
                        try
                        {
                            //ici service
                            //serv.Updateacquis(ID_ENS,aquis.Text);
                            string cl = RadComboBox2.SelectedValue;
                            DataTable dtaq = serv.verifexistAcquis(LBLID_ACQUIS.Text);


                            if(dtaq.Rows.Count==0)
                            {
                                serv.ValidChapterBYCLS(ID_ENS, cl, LBLCODE_MODULE.Text, LBLID_ACQUIS.Text, Convert.ToDateTime(dropseance.SelectedValue), RadioButtonds.SelectedValue, txtid.Text, DrpPercentageComplete.SelectedValue);

                            }

                            else
                            {
                                serv.UpdateValidChapterBYCLS(ID_ENS, LBLID_ACQUIS.Text, RadioButtonds.SelectedValue, txtid.Text, DrpPercentageComplete.SelectedValue);

                            }

                            //ici update
                            ShowPopupMessage("Modification effectué",
                            PopupMessageType.Success);
                            txtid.Text = "";
                            crd.Visible = true;
                            l1.Visible = true;
                            crd.DataSource = serv.GetlistOFChapterByModule(RadComboBox4.SelectedValue, txtclasse.Text);

                            crd.DataBind();

                            btnUpdate.Visible = true;

                        }
                        catch (Exception ex)
                        {

                            string bug = ex.ToString();
                            ShowPopupMessage("ERREUR DE SERVEUR",
          PopupMessageType.Error);
                        }


                    }

                   else
                    {
                        if (RadioButtonds.SelectedValue =="")
                        {
                            try
                            {
                                //ici service
                                //serv.Updateacquis(ID_ENS,aquis.Text);
                                string cl = RadComboBox2.SelectedValue;

                                serv.ValidChapterBYCLS(ID_ENS, cl, LBLCODE_MODULE.Text, LBLID_ACQUIS.Text, Convert.ToDateTime(dropseance.SelectedValue), RadioButtonds.SelectedValue, txtid.Text, DrpPercentageComplete.SelectedValue);
                                ShowPopupMessage("Enregistrement effectué",
                                PopupMessageType.Success);
                                txtid.Text = "";
                                crd.Visible = true;
                                l1.Visible = true;
                                crd.DataSource = serv.GetlistOFChapterByModule(RadComboBox4.SelectedValue, txtclasse.Text);

                                crd.DataBind();

                                btnUpdate.Visible = true;

                            }
                            catch (Exception ex)
                            {

                                string bug = ex.ToString();
                                ShowPopupMessage("ERREUR DE SERVEUR",
              PopupMessageType.Error);
                            }

                        }


                    }
                }
            }
        }

        protected void ddlseance(object sender, EventArgs e)
        {
            ID_ENS = Session["ID_ENS"].ToString();

            string H = dropseance.SelectedValue.ToString().Substring(9, 2);


            txtclasse.Text = RadComboBox2.SelectedValue;
            //serv.HaveCLfromemploi(ID_ENS, Convert.ToDateTime(RadComboBox1.SelectedValue), H);

            string dis = txtclasse.Text;
            Session["dis"] = dis;
            //ici gridview 
            lbltxt1.Visible = true;
            txtid.Visible = true;
            lbltxt1.ForeColor = System.Drawing.Color.Red;

            lbltxt1.Text = RadComboBox4.SelectedItem.Text;

            crd.Visible = true;
            l1.Visible = true;
            btnUpdate.Visible = true;
            Label8.Visible = true;
            RadComboBox4.Visible = true;

            crd.DataSource = serv.GetlistOFChapterByModule(RadComboBox4.SelectedValue, txtclasse.Text);

            crd.DataBind();
            

        }
    }
}