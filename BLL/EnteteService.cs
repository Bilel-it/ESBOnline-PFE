using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class EnteteService
    {
        EnteterDAO dao = EnteterDAO.Instance;

        public void ajouterEntete_Reclamation(ENTETE_RECLAMATION rec)
        {
            dao.ajouterEntete_Reclamation(rec);
        }

        public void modifierEntete_Reclamation(ENTETE_RECLAMATION rec)
        {
            dao.modifierEntete_Reclamation(rec);
        }
        public void supprimerEntete_Reclamation(ENTETE_RECLAMATION rec)
        {
            dao.supprimerEntete_Reclamation(rec);
        }
        public List<ENTETE_RECLAMATION> listerEntete_Reclamation()
        {
            return dao.listerEntete_Reclamation();
        }

        public List<ENTETE_RECLAMATION> listerREntete_ReclamationParType(decimal id)
        {
            return dao.listerEntete_Reclamation().Where(p => p.ID_ENTETE_RECLAMATION == id).ToList<ENTETE_RECLAMATION>();
        }
        public List<ENTETE_RECLAMATION> listerEntete_ReclamationParnom(string nom_enseignant)
        {
            return dao.listerEntete_Reclamation().Where(p => p.NOM_ENS == nom_enseignant).ToList<ENTETE_RECLAMATION>();
        }
        public List<ENTETE_RECLAMATION> listerEntete_ReclamationParDate(DateTime date)
        {
            return dao.listerEntete_Reclamation().Where(p => p.DATE_RECLAMATION == date).ToList<ENTETE_RECLAMATION>();
        }
        public List<ENTETE_RECLAMATION> listerEntete_ReclamationPartype_reclamation(string type_reclamation)
        {
            return dao.listerEntete_Reclamation().Where(p => p.TYPE_RECLAMATION == type_reclamation).ToList<ENTETE_RECLAMATION>();
        }
        public List<ENTETE_RECLAMATION> countEntete_ReclamationPartype_reclamation(string type_reclamation)
        {
            return dao.listerEntete_Reclamation().Where(p => p.TYPE_RECLAMATION == type_reclamation).ToList<ENTETE_RECLAMATION>();
        }
        public List<ENTETE_RECLAMATION> countEntete_ReclamationParid_ens(string id_ens)
        {
            return dao.listerEntete_Reclamation().Where(p => p.ID_ENS == id_ens).ToList<ENTETE_RECLAMATION>();
        }
    }
}
