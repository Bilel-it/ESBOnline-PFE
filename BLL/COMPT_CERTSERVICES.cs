using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class COMPT_CERTSERVICES
    {
        COMPT_CERTDAO dao = COMPT_CERTDAO.Instance;

        public void ajouterESP_COMPT_CERT(COMPT_CERT CPT)
        {
            dao.ajouterCOMPT_CERT(CPT);
        }
        public void modifierESP_COMPT_CERT(COMPT_CERT rec)
        {
            dao.modifierESP_COMPT_CERT(rec);
        }
        public void supprimerESP_COMPT_CERT(COMPT_CERT rec)
        {
            dao.supprimerESP_COMPT_CERT(rec);
        }
        public List<COMPT_CERT> listerCOMPT_CERT()
        {
            return dao.listerCOMPT_CERT();
        }

        public List<COMPT_CERT> listerRCOMPT_CERTParheure(string heure)
        {
            return dao.listerCOMPT_CERT().Where(p => p.HEURE == heure).ToList<COMPT_CERT>();
        }
        public List<COMPT_CERT> listerRCOMPT_CERTParheure(DateTime date)
        {
            return dao.listerCOMPT_CERT().Where(p => p.DATE_CERT == date).ToList<COMPT_CERT>();
        }
        public List<COMPT_CERT> listerRCOMPT_CERTParCPT(decimal cpt)
        {
            return dao.listerCOMPT_CERT().Where(p => p.CPT == cpt).ToList<COMPT_CERT>();
        }

    }
}
