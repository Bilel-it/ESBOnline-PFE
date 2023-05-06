using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Parents
{
    public partial class esprit_payment_notification : System.Web.UI.Page
    {

        string ID_ET;
        string NOM_ET;
        string PRENOM_ET;
        string NUM_CIN_PASSEPORT;
        string order;
        public class RdirectToPay
        {
            public string orderId { get; set; }
            public string formUrl { get; set; }
        }

        public class Hist_ET_PAYMENT
        {

            public string expiration { get; set; }
            public string cardholderName { get; set; }
            public string depositAmount { get; set; }
            public string currency { get; set; }
            public string authCode { get; set; }
            public string ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public string OrderStatus { get; set; }
            public string OrderNumber { get; set; }
            public string Pan { get; set; }
            public string amount { get; set; }
            public string Ip { get; set; }



        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            //{
            //    Response.Redirect("~/Online/default.aspx");
            //}


            ID_ET = Session["ID_ET"].ToString();
            NOM_ET = Session["NOM_ET"].ToString();
            PRENOM_ET = Session["PNOM_ET"].ToString();
            NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();
            order = Session["ordernumber"].ToString();

            if (!IsPostBack)
            {
                try
                {

                    string language = "en";
                    string anneedeb = DAL.EncadDAO.Instance.getAnneedeb();
                    string orderId = DAL.EncadDAO.Instance.getOrderIdPayment(ID_ET, order).ToString();
                    string password = DAL.EncadDAO.Instance.getPassPayment(ID_ET).ToString();
                    string userName = DAL.EncadDAO.Instance.getuserNamePayment(ID_ET).ToString();


                    if (orderId == null && password == null && userName == null)
                    {

                        Response.Write("<script LANGUAGE='JavaScript'> alert('Vous n'avez pas d'enregistrement') </script>");

                    }
                    else
                    {

                        //string urltest = "https://test.clictopay.com/payment/rest/getOrderStatus.do?orderId=" + orderId + "&language=" + language + "&password=" + password + "&userName=" + userName + "";
                        string urltest = "https://test.clictopay.com/payment/rest/getOrderStatus.do?orderId=" + orderId + "&language=" + language + "&password=" + password + "&userName=" + userName + "";

                        WebRequest requestObject = WebRequest.Create(urltest);
                        requestObject.Method = "GET";
                        const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
                        const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
                        ServicePointManager.SecurityProtocol = Tls12;
                        HttpWebResponse responseObject = null;
                        responseObject = (HttpWebResponse)requestObject.GetResponse();
                        string urltestResult = null;
                        using (Stream stream = responseObject.GetResponseStream())
                        {
                            StreamReader sr = new StreamReader(stream);
                            urltestResult = sr.ReadToEnd();
                            string cc = Convert.ToString(urltestResult);// orderId //formUrl
                            Hist_ET_PAYMENT list_pay = JsonConvert.DeserializeObject<Hist_ET_PAYMENT>(cc);
                            Label1.Text = list_pay.ErrorMessage.ToString();
                            Label1.Visible = true;
                            // liste de retour Aprés le paiement
                            amount.Text = list_pay.amount.ToString();
                            authCode.Text = list_pay.authCode.ToString();
                            cardholderName.Text = list_pay.cardholderName.ToString();
                            currency.Text = list_pay.currency.ToString();
                            depositAmount.Text = list_pay.depositAmount.ToString();
                            ErrorCode.Text = list_pay.ErrorCode.ToString();
                            ErrorMessage.Text = list_pay.ErrorMessage.ToString();
                            expiration.Text = list_pay.expiration.ToString();
                            // Convert.ToDateTime(item.expirationDate).ToString("dd/MM/yyyy");
                            Ip.Text = list_pay.Ip.ToString();
                            OrderNumber.Text = list_pay.OrderNumber.ToString();
                            OrderStatus.Text = list_pay.OrderStatus.ToString();
                            Pan.Text = list_pay.Pan.ToString();

                            // save etat paiement 

                            DAL.EncadDAO.Instance.EtatPaiement(ID_ET, expiration.Text, cardholderName.Text, depositAmount.Text, currency.Text, authCode.Text, ErrorCode.Text, ErrorMessage.Text, OrderStatus.Text, OrderNumber.Text, Pan.Text, amount.Text, Ip.Text, anneedeb);




                        }
                    }
                }

                catch (Exception)
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Erreur de serveur!!!') </script>");

                }




            }
        }

      




    }
}