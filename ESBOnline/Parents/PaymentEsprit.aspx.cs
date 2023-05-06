using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Parents
{
    public partial class PaymentEsprit : System.Web.UI.Page
    {
        string ID_ET;
        string NOM_ET;
        string PRENOM_ET;
        string NUM_CIN_PASSEPORT;
        string order;
        public class Pay
        {

            public string amount { get; set; }
            public string currency { get; set; }
            public string language { get; set; }
            public string orderNumber { get; set; }
            public string returnUrl { get; set; }
            public string expirationDate { get; set; }
        }
        public class RdirectToPay
        {
            public string orderId { get; set; }
            public string formUrl { get; set; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/Login.aspx");
            }
            ID_ET = Session["ID_ET"].ToString();
            NOM_ET = Session["NOM_ET"].ToString();
            PRENOM_ET = Session["PNOM_ET"].ToString();
            NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();
           // order = Session["orderNumber"].ToString();
            // String annee =   DAL.EncadDAO.Instance.getAnnInscription(ID_ET).ToString();

            // get formulaire etudiant 
            identifiant.Text = ID_ET;
            nomet.Text =NOM_ET ;
            prenomet.Text = PRENOM_ET;
            classe.Text = Session["CODE_CL"].ToString();
            //DAL.EncadDAO.Instance.getnumClasse(ID_ET);
            numcinpassport.Text = DAL.EncadDAO.Instance.getCryptCin(ID_ET);
            telephone.Text = DAL.EncadDAO.Instance.getnumTelephone(ID_ET);


            string aa= DAL.EncadDAO.Instance.OrderNumberPayment();

           
                 string orderNumber = aa;
                orderNumbers.Text = orderNumber;
            Session["ordernumber"] = orderNumber;




        }




        protected void submit_Click(object sender, EventArgs e)
        {
                try
                {
                string id_et = Session["ID_ET"].ToString();
                string anneedeb = "2019";
                string orderNumber = orderNumbers.Text;
                Session["ordernumber"] = orderNumber;
                string userName = userNames.Text;
                string password = passwords.Text;
             
                //  string amount = DdrAmount.SelectedValue;
                //traitement du montant
                string amount = mntdt.Text+""+mntmillime.Text;

                if (mntdt.Text == null && mntmillime.Text==null)
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez Remplir les champs') </script>");

                }

                //  string amount = "100000";
                string returnUrl = returnUrls.Text;
                string language = languages.Text;
                string currency = currencys.Text;
                string expirationDate = expirationDates.Text;
                if(orderNumber==null && userName==null && password==null && amount == null && currency==null)
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez Remplir les champs') </script>");

                }
                else
                {
                   // https://test.clictopay.com/payment/rest/register.do

                    DAL.EncadDAO.Instance.AjoutPaiement(ID_ET, userName, amount, anneedeb, "", currency, password, "");
                    string urltest = "https://test.clictopay.com/payment/rest/register.do?amount=" + amount + "&currency=" + currency + "&language=" + language + "&orderNumber=" + orderNumber + "&password=" + password + "&returnUrl=" + returnUrl + "&userName=" + userName + "";
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
                        RdirectToPay list_pay = JsonConvert.DeserializeObject<RdirectToPay>(cc);
                        list_pay.orderId.ToString();
                        list_pay.formUrl.ToString();
                        DAL.EncadDAO.Instance.updateTransactionPayment(list_pay.orderId.ToString(), list_pay.formUrl.ToString(), ID_ET,Convert.ToDecimal(orderNumber));
                        string strURL = "https://test.clictopay.com/payment/merchants/CLICTOPAY/payment_en.html?mdOrder=" + list_pay.orderId.ToString();

                        Response.Redirect(strURL);
                    }

                    
                }

            }

           catch (Exception ex)
           {
            
              Response.Write("<script LANGUAGE='JavaScript'> alert('Erreur de serveur') </script>");

           }
          

        }

    
   
        protected void amount_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (DdrAmount.SelectedValue == "0")
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez choisir Montant') </script>");

            }

        }
    }
}