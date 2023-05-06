using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using System.Text.RegularExpressions;

namespace ESPOnline.Parents
{
    public partial class Historique_Paiement_Etudiant : System.Web.UI.Page
    {
        string numcompte;
        string ID_ET;
        string NOM_ET;
        string PRENOM_ET;
        string NUM_CIN_PASSEPORT;
        public class Hist_ET_PARENTS
        {

            public string PostingDate { get; set; }
            public string documenttype { get; set; }
            public string documentNo_ { get; set; }
            public string description { get; set; }
            public string amount { get; set; }



        }
        public class solde_total
        {

         
            public TableCell t { get; set; }
         
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               
                numcompte = Session["NUMCOMPTE"].ToString();
                var urlhistorique = "http://192.168.0.77/webService/web/historiquemontant/"+numcompte;
                
                var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(urlhistorique);
                using (var response = webrequest.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var result = reader.ReadToEnd();
                    var cc = Convert.ToString(result);




                    List<Hist_ET_PARENTS> list_hist1 = JsonConvert.DeserializeObject<List<Hist_ET_PARENTS>>(cc);
                    List<Hist_ET_PARENTS> list_hist = new List<Hist_ET_PARENTS>();

                    foreach (Hist_ET_PARENTS item in list_hist1)
                    {
                        Hist_ET_PARENTS vv = new Hist_ET_PARENTS();
                        vv.amount = item.amount.Substring(0, 1) == "-" ? item.amount.Substring(0, 9) : item.amount.Substring(0, 8);
                        vv.description = item.description;
                        vv.PostingDate = Convert.ToDateTime(item.PostingDate).ToString("dd/MM/yyyy");
                        vv.documentNo_ = item.documentNo_;
                        if (item.documenttype == "3") { vv.documenttype = "Avoir"; }
                        if (item.documenttype == "2") { vv.documenttype = "Facture"; }
                        if (item.documenttype == "1") { vv.documenttype = "Paiement"; }
                        if (item.documenttype == "0") { vv.documenttype = ""; }
                        list_hist.Add(vv);
                    }


                    GridView2.DataSource = list_hist.OrderByDescending(p=> Convert.ToDateTime(p.PostingDate));
                    GridView2.DataBind();
                    GridView2.Visible = true;


                }
                var url = "http://192.168.0.77/webServiceSem1/web/montant/" + numcompte;
                
                var webrequest5 = (HttpWebRequest)System.Net.WebRequest.Create(url);
                using (var response5 = webrequest5.GetResponse())
                using (var reader5 = new StreamReader(response5.GetResponseStream()))
                {

                 
                    var result5 = reader5.ReadToEnd();
                    var cc5 = Convert.ToString(result5);
                 

                   
                  //  Label7.Text = cc5.Substring(1,4);
                   

                }




             
                
                if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
                {
                    Response.Redirect("~/Online/default.aspx");
                }

                ID_ET = Session["ID_ET"].ToString();
              
                NOM_ET = Session["NOM_ET"].ToString();
                PRENOM_ET = Session["PNOM_ET"].ToString();
                NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();

            }
        }

     
        protected void GridView2_DataBound(object sender, EventArgs e)
        {
          
        }


    }
}