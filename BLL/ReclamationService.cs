using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class ReclamationService
    {
        ReclamationDAO dao = ReclamationDAO.Instance;

        public void ajouterReclamation(RECLAMATIONN rec)
        {
            dao.ajouterReclamation(rec);
        }
        Récupérer_MotdepasseDAO recupérerdao = Récupérer_MotdepasseDAO.Instance;


        public string GET_ADRESSE_MAIL(string _id_et)
        {
            return recupérerdao.GET_ADRESSE_MAIL(_id_et);

        }

        public string GET_ADRESSE_MAIL_parent(string _id_et)
        {
            return recupérerdao.GET_ADRESSE_MAIL_parent(_id_et);

        }


        public string GET_PASSWORD(string _id_et)
        {
            return recupérerdao.GET_PASSWORD(_id_et);

        }
        public void modifierReclamation(RECLAMATIONN rec)
        {
            dao.modifierReclamation(rec);
        }
        public void supprimerReclamation(RECLAMATIONN rec)
        {
            dao.supprimerReclamation(rec);
        }
        public List<RECLAMATIONN> listerReclamation()
        {
            return dao.listerReclamation();
        }

        public List<RECLAMATIONN> listerRReclamationParType(decimal id)
        {
            return dao.listerReclamation().Where(p => p.ID_RECLAMTION == id).ToList<RECLAMATIONN>();
        }
        public List<RECLAMATIONN> listerRReclamationParType(string traiter)
        {
            return dao.listerReclamation().Where(p => p.TRAITER == traiter).ToList<RECLAMATIONN>();
        }
        public List<RECLAMATIONN> listerREntete_ReclamationParType(decimal identete)
        {
            return dao.listerReclamation().Where(p => p.ID_ENTETE_RECLAMATION == identete).ToList<RECLAMATIONN>();
        }
        public List<RECLAMATIONN> listerRReclamationPardescription(string description)
        {
            return dao.listerReclamation().Where(p => p.DESCRIPTION == description).ToList<RECLAMATIONN>();
        }

    }
}
