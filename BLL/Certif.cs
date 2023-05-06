using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Certif
    {
        CertifDAO dao = CertifDAO.Instance;

        public bool ajouterESP_CERTIF(ESP_CERTIF rec, string id_et)
        {
            return dao.ajouterESP_CERTIF(rec, id_et);
        }


        //public bool ajouterESP_INSCRII(ESP_INSCRI rec, string nom_jeton)
        //{
        //    return dao.ajouterESP_INSCRII(rec, nom_jeton);
        //}

        public void modifierESP_CERTIF(ESP_CERTIF rec)
        {
            dao.modifierESP_CERTIF(rec);
        }
        public void supprimerESP_CERTIF(ESP_CERTIF rec)
        {
            dao.supprimerESP_CERTIF(rec);
        }
        public List<ESP_CERTIF> listerESP_CERTIF()
        {
            return dao.listerESP_CERTIF();
        }

   
        public List<ESP_CERTIF> listerESP_CERTIFParnom(string nom)
        {
            return dao.listerESP_CERTIF().Where(p => p.NOM_ET == nom).ToList<ESP_CERTIF>();
        }
        public List<ESP_CERTIF> listerESP_CERTIFParadr(string adr)
        {
            return dao.listerESP_CERTIF().Where(p => p.ADRESSE_ET == adr).ToList<ESP_CERTIF>();
        }
        public List<ESP_CERTIF> listerRESP_CERTIFPardate(DateTime date, string heure)
        {
            return dao.listerESP_CERTIF().Where(p => p.DATE_INS == date).OrderBy(c => c.HEURE_INS == heure).ToList<ESP_CERTIF>();
        }
        public List<ESP_CERTIF> listerRESP_CERTIFParheure(string heure)
        {
            return dao.listerESP_CERTIF().Where(p => p.HEURE_INS == heure).ToList<ESP_CERTIF>();
        }
        //public List<ESP_INSCRI> listerESP_INSCRIParcount(decimal id)
        //{

        //    return dao.listerESP_INSCRI().GroupBy(x => x.HEURE_INS, y => y.DATE_INS).Count().ToList<ESP_INSCRI>();
        //    //return dao.listerESP_INSCRI().Where(p => p.ADRESSE_ET == adresse).count.ToList<ESP_INSCRI>();
        //    //return dao.listerESP_INSCRI().Where(p => p.ID_INSCRIPTION ==id).Count().ToList<ESP_INSCRI>();
        //}
        //public bool verifinscr (int count, string date_ins, string heure_ins)
        //{
        //    bool exist = false;


        //}

    }
}
