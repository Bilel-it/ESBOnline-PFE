using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
  public class LangueService
    {

        LangueDAO service = LangueDAO.Instance;
        DataTable dt = new DataTable();

        public string Get_ID_ETUD_scin(string NOM)
        {
            return service.Get_ID_ETUD_scin(NOM);
        }
        public DataTable bind_etud_actif()
        {
            dt = service.bind_etud_actif();
            return dt;
        }
        public void enreg8transportoui(string id_et, string etat, string ligne)
        {
            service.enreg8transportoui(id_et, etat, ligne);
        }

        public void enreg8transportnon(string id_et, string etat)
        {
            service.enreg8transportnon(id_et, etat);
        }

        public DataTable Find_TARANSPORT(string id_et)
        {
            dt = service.Find_TARANSPORT(id_et);
            return dt;
        }

        public string Get_ID_ETUD(string NOM)
        {
            return service.Get_ID_ETUD(NOM);
        }

        public DataTable bind_niveau_etudiant(string id_et)
        {
            dt = service.bind_niveau_etudiant(id_et);
            return dt;
        }

        public DataTable bind_niveau_etudiantbycl(string code_cl, string ann_deb)
        {
            dt = service.bind_niveau_etudiantbycl(code_cl, ann_deb);
            return dt;
        }

        public DataTable bind_niveau_ang()
        {
            dt = service.bind_niveau_ang();
            return dt;
        }

        public DataTable bind_niveau_fr()
        {
            dt = service.bind_niveau_fr();
            return dt;
        }

        public void Enreg_niv_langue(string id_et, string langue, string niv_act, string ancien_niv, string id_ens)
        {
            service.Enreg_niv_langue(id_et, langue, niv_act, ancien_niv, id_ens);
        }

      //bind ancien niveau des etudiants
        public string getAncien_niveau_ang(string id_etud)
        {
           return service.getAncien_niveau_ang(id_etud);
            
        }
        public string getAncien_niveau_fr(string id_etud)
        {
           return service.getAncien_niveau_fr(id_etud);
            
        }

        public int Update_niv_etud_fr(string id_etud, string niv_fr)
        {
            return service.Update_niv_etud_fr(id_etud,niv_fr);
        }

        public int Update_niv_etud_ang(string id_etud, string niv_fr)
        {
            return service.Update_niv_etud_ang(id_etud, niv_fr);
        }

        public DataTable bind_niveau_1516(string ANNEE_DEB)
        {
            dt = service.bind_niveau_1516(ANNEE_DEB);
            return dt;
        }

        public DataTable bind_classes_1516(string niv, string annee_deb)
        {
            dt = service.bind_classes_1516(niv,annee_deb);
            return dt;
        }

        public DataTable bind_Nom_Etud(string code_classe, string annee_deb)
        {
            dt = service.bind_Nom_Etud(code_classe, annee_deb);
            return dt;
        }

        public DataTable fiche_niveau_langue(string code_class, string annee_deb)
        {
            dt = service.fiche_niveau_langue(code_class, annee_deb);
            return dt;
        }

        public DataTable fiche_historique(string id_et)
        {
            dt = service.fiche_historique(id_et);
            return dt;
        }

        public DataTable fiche_niveau_langue_moins_B2(string code_class, string annee_deb)
        {
            dt = service.fiche_niveau_langue_moins_B2(code_class,annee_deb);
            return dt;
        }

        public DataTable Etat_lge_fr()
        {
            dt = service.Etat_lge_fr();
            return dt;
        }

        public DataTable Etat_lge_ang()
        {
            dt = service.Etat_lge_ang();
            return dt;
        }

      //existance de l'etudiant
        public DataTable ETUD_EXIST(string id_et, string langue)
        {
            dt = service.ETUD_EXIST(id_et,langue);
            return dt;
        }
        public DataTable bind_classes_parniv(string niv, string annee_deb)
        {
            dt = service.bind_classes_parniv(niv,annee_deb);
            return dt;
        }

        public string get_Code_module(string id_ens)
        {
            return service.get_Code_module(id_ens);
        }

        public DataTable verifier(string id_et, string lge)
        {
            dt = service.verifier(id_et, lge);
            return dt;
        }

      //get ancien niveau de langue:
        public string get_anc_niv_student(string id_eet)
        {
            return service.get_anc_niv_student(id_eet);
        }

        public string get_anc_niv_studentANG(string id_eet)
        {
            return service.get_anc_niv_studentANG(id_eet);
        }

      //bind of teachers

        public DataTable bind_classes_1516_cup(string annee_deb)
        {
            return service.bind_classes_1516_cup(annee_deb);
        }


        public DataTable Consult_list_frform()
        {
            dt = service.Consult_list_frform();
            return dt;
        }

        public DataTable Consult_list_PAR_DATE()
        {

            dt = service.Consult_list_PAR_DATE();
            return dt;
        }



        public DataTable Consult_list_PAR_DATEANG()
        {
            dt = service.Consult_list_PAR_DATEANG();
            return dt;

        }

     

    }
}
