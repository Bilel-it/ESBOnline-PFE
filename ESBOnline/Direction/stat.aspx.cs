using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace ESPOnline.Direction
{
    public partial class stat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            Label15.Text = DAL.Admission.Instance.nbCondidats("1", "04");
            Label16.Text = DAL.Admission.Instance.nbCondidats("2", "04");
            Label17.Text = DAL.Admission.Instance.nbCondidats("3", "04");
            Label18.Text = DAL.Admission.Instance.nbCondidats("1", "03");
            Label19.Text = DAL.Admission.Instance.nbCondidats("2", "03");
            Label20.Text = DAL.Admission.Instance.nbCondidats("3", "03");
            Label21.Text = DAL.Admission.Instance.nbCondidats("1", "05");
            Label22.Text = DAL.Admission.Instance.nbCondidats("2", "05");
            Label23.Text = DAL.Admission.Instance.nbCondidats("3", "05");


            Label24.Text = DAL.Admission.Instance.nbCondidatsteste("1", "04");
            Label25.Text = DAL.Admission.Instance.nbCondidatsteste("2", "04");
            Label26.Text = DAL.Admission.Instance.nbCondidatsteste("3", "04");
            Label27.Text = DAL.Admission.Instance.nbCondidatsteste("1", "03");
            Label28.Text = DAL.Admission.Instance.nbCondidatsteste("2", "03");
            Label29.Text = DAL.Admission.Instance.nbCondidatsteste("3", "03");
            Label30.Text = DAL.Admission.Instance.nbCondidatsteste("1", "05");
            Label31.Text = DAL.Admission.Instance.nbCondidatsteste("2", "05");
            Label32.Text = DAL.Admission.Instance.nbCondidatsteste("3", "05");




            Label33.Text = DAL.Admission.Instance.nbCondidats2("1", "04", "01");
            Label34.Text = DAL.Admission.Instance.nbCondidats2("2", "04", "01");
            Label35.Text = DAL.Admission.Instance.nbCondidats2("3", "04", "01");

            Label36.Text = DAL.Admission.Instance.nbCondidats2("1", "03", "01");
            Label37.Text = DAL.Admission.Instance.nbCondidats2("2", "03", "01");
            Label38.Text = DAL.Admission.Instance.nbCondidats2("3", "03", "01");

            Label39.Text = DAL.Admission.Instance.nbCondidats2("1", "05", "01");
            Label40.Text = DAL.Admission.Instance.nbCondidats2("2", "05", "01");
            Label41.Text = DAL.Admission.Instance.nbCondidats2("3", "05", "01");



            Label42.Text = DAL.Admission.Instance.nbCondidats2("1", "04", "10");
            Label43.Text = DAL.Admission.Instance.nbCondidats2("2", "04", "10");
            Label44.Text = DAL.Admission.Instance.nbCondidats2("3", "04", "10");

            Label45.Text = DAL.Admission.Instance.nbCondidats2("1", "03", "10");
            Label46.Text = DAL.Admission.Instance.nbCondidats2("2", "03", "10");
            Label47.Text = DAL.Admission.Instance.nbCondidats2("3", "03", "10");

            Label48.Text = DAL.Admission.Instance.nbCondidats2("1", "05", "10");
            Label49.Text = DAL.Admission.Instance.nbCondidats2("2", "05", "10");
            Label50.Text = DAL.Admission.Instance.nbCondidats2("3", "05", "10");

            Label51.Text = DAL.Admission.Instance.nbCondidats2("1", "04", "99");
            Label52.Text = DAL.Admission.Instance.nbCondidats2("2", "04", "99");
            Label53.Text = DAL.Admission.Instance.nbCondidats2("3", "04", "99");

            Label54.Text = DAL.Admission.Instance.nbCondidats2("1", "03", "99");
            Label55.Text = DAL.Admission.Instance.nbCondidats2("2", "03", "99");
            Label56.Text = DAL.Admission.Instance.nbCondidats2("3", "03", "99");

            Label57.Text = DAL.Admission.Instance.nbCondidats2("1", "05", "99");
            Label58.Text = DAL.Admission.Instance.nbCondidats2("2", "05", "99");
            Label59.Text = DAL.Admission.Instance.nbCondidats2("3", "05", "99");
        }
    }
}