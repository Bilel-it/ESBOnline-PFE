using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class ENTETE
    {
        EnteteDAO dao = EnteteDAO.Instance;

        public bool ajouterESP_CCNA3(ESP_CCNA3 rec, string id_et)
        {
            return dao.ajouterESP_CCNA3(rec, id_et);
        }



        public bool ajouterESP_INSCRI(ESP_INSCRI rec, string id_et)
        {
            return dao.ajouterESP_INSCRI(rec, id_et);
        }
        public bool ajouterESP_ccna4(ESP_INSCRI rec, string id_et)
        {
            return dao.ajouterESP_ccna4(rec, id_et);
        }


        public void modifierESP_CCNA3(ESP_CCNA3 rec)
        {
            dao.modifierESP_CCNA3(rec);
        }
        public void supprimerESP_CCNA3(ESP_CCNA3 rec)
        {
            dao.supprimerESP_CCNA3(rec);
        }
        public List<ESP_CCNA3> listerESP_CCNA3()
        {
            return dao.listerESP_CCNA3();
        }


        public List<ESP_CCNA3> listerESP_CCNA3Parnom(string nom)
        {
            return dao.listerESP_CCNA3().Where(p => p.NOM_ET == nom).ToList<ESP_CCNA3>();
        }
        public List<ESP_CCNA3> listerESP_CCNA3Paradr(string adr)
        {
            return dao.listerESP_CCNA3().Where(p => p.ADRESSE_ET == adr).ToList<ESP_CCNA3>();
        }
        public List<ESP_CCNA3> listerRESP_CCNA3Pardate(DateTime date, string heure)
        {
            return dao.listerESP_CCNA3().Where(p => p.DATE_INS == date).OrderBy(c => c.HEURE_INS == heure).ToList<ESP_CCNA3>();
        }
        public List<ESP_CCNA3> listerRESP_CCNA3Parheure(string heure)
        {
            return dao.listerESP_CCNA3().Where(p => p.HEURE_INS == heure).ToList<ESP_CCNA3>();
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
