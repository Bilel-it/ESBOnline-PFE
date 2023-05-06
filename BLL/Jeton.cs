using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Jeton
    {
        JetonDAO dao = JetonDAO.Instance;

        public void ajouterJETON(JETON rec)
        {
            dao.ajouterJETON(rec);
        }

          public void modifierESP_INSCRI(JETON rec)
        {
            dao.modifierJETON(rec);
        }
        public void supprimerJETON(JETON rec)
        {
            dao.supprimerJETON(rec);
        }
        public List<JETON> listerJETON()
        {
            return dao.listerJETON();
        }

        public List<JETON> listerRJETONParType(decimal id)
        {
            return dao.listerJETON().Where(p => p.ID_JETON == id).ToList<JETON>();
        }
        public List<JETON> listerJETONParnom(string nom)
        {
            return dao.listerJETON().Where(p => p.NOM_JETON == nom).ToList<JETON>();
        }
        //public List<ESP_INSCRI> listerHEURE_INSparheure(DateTime date)
        //{
        //    using (Entities ec = new Entities())
        //    {
        //        var query = (from p in ESP_INSCRI
        //                     group p by p.HEURE_INS into p
        //                     select new
        //                     {
        //                         HEURE_INS = p.Key,
        //                         nbtotal = p.Select(x => x.HEURE_INS).Count()
        //                     }).groupby(y => y.DATE_INS);
        //    }
        //}

    }
}
