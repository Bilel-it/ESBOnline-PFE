using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class StatService
    {
        StatDAO notedao = StatDAO.Instance;
        ToiecDAO t = ToiecDAO.Instance;


        public DataTable Rep_nouv_inscrits()
        {
            DataTable dt = new DataTable();
            dt = t.Rep_nouv_inscrits();
            return dt;
        }
        public DataTable Afficher_list_charguia()
        {
            DataTable dt = new DataTable();
            dt = t.Afficher_list_charguia();

            return dt;
        }
      
        public DataTable Afficher_list_ghazela()
        {
            DataTable dt = new DataTable();
            dt = t.Afficher_list_gazela();

            return dt;
        }

        public string totalch()
        {
            return t.totalch();
        }


        public string totalgh()
        {
            return t.totalgh();
        }
       
       public DataTable GetserviceListNotes(string CODE_CL, string CODE_MODULE, string Annee)
       {
           return notedao.GetListNotes(CODE_CL, CODE_MODULE,Annee);
       }

       public DataTable GetserviceListNotes2(string CODE_CL, string CODE_MODULE, string ID_ENS, string Annee)
       {
           return notedao.GetListNotes2(CODE_CL, CODE_MODULE, ID_ENS, Annee);
       }
       public DataTable GetserviceListNotes22(string CODE_CL, string CODE_MODULE, string Annee)
       {
           return notedao.GetListNotes22(CODE_CL, CODE_MODULE, Annee);
       }
       public DataTable GetserviceListNotes3(string CODE_CL, string CODE_MODULE, string ID_ENS, string Annee)
       {
           return notedao.GetListNotes3(CODE_CL, CODE_MODULE, ID_ENS, Annee);
       }
       public DataTable GetserviceListNotes33(string CODE_CL, string CODE_MODULE, string Annee)
       {
           return notedao.GetListNotes33(CODE_CL, CODE_MODULE, Annee);
       }
       public DataTable GetserviceListNotes4(string CODE_CL, string CODE_MODULE, string ID_ENS, string Annee)
       {
           return notedao.GetListNotes4(CODE_CL, CODE_MODULE, ID_ENS, Annee);
       }
       public DataTable GetserviceListNotes44(string CODE_CL, string CODE_MODULE, string Annee)
       {
           return notedao.GetListNotes44(CODE_CL, CODE_MODULE, Annee);
       }
       public DataTable GetserviceListNotes5(string ID_ENS, string Annee)
       {
           return notedao.GetListNotes5(ID_ENS, Annee);
       }
       public DataTable GetserviceListNotes55(string Annee)
       {
           return notedao.GetListNotes55(Annee);
       }


       public DataTable GetserviceListNotes7(string CODE_CL, string CODE_MODULE, string ID_ENS, string Annee)
       {
           return notedao.GetListNotes7(CODE_CL, CODE_MODULE, ID_ENS, Annee);
       }
       public DataTable GetserviceListNotes77(string CODE_CL, string CODE_MODULE, string Annee)
       {
           return notedao.GetListNotes77(CODE_CL, CODE_MODULE, Annee);
       }
       public DataTable GetserviceListNotes8(string CODE_CL, string CODE_MODULE, string ID_ENS, string Annee)
       {
           return notedao.GetListNotes8(CODE_CL, CODE_MODULE, ID_ENS, Annee);
       }
       public DataTable GetserviceListNotes88(string CODE_CL, string CODE_MODULE, string Annee)
       {
           return notedao.GetListNotes88(CODE_CL, CODE_MODULE, Annee);
       }

       public DataTable GetserviceListNotes6(string ID_ENS, string CODE_CL, string Annee)
       {
           return notedao.GetListNotes6(ID_ENS, CODE_CL, Annee);
       }
       public DataTable GetserviceListNotes66(string CODE_CL, string Annee)
       {
           return notedao.GetListNotes66(CODE_CL, Annee);
       }
       public DataTable GetserviceTauxRep(string CODE_CL, string CODE_MODULE, string ID_ENS, string Annee)
       {
           return notedao.GetTauxRep(CODE_CL, CODE_MODULE, ID_ENS, Annee);
       }

       public DataTable GetserviceTauxRep1(string CODE_CL, string CODE_MODULE, string Annee)
       {
           return notedao.GetTauxRep1(CODE_CL, CODE_MODULE, Annee);
       }


       public DataTable Afficher_listPARniv()
       {
           DataTable dt = new DataTable();
           dt = t.Afficher_listPARniv();
           return dt;
       }

       public DataTable Afficher_listetudPARniv()
       {
           DataTable dt = new DataTable();
           dt = t.Afficher_listetudPARniv();
           return dt;

       }

       //afficher stat site
       public DataTable Afficher_stat_site()
       {
           DataTable dt = new DataTable();
           dt = t.Afficher_stat_site();
           return dt;

       }


       public DataTable Afficher_total_par_CLASSE()
       {

           DataTable dt = new DataTable();
           dt = t.Afficher_total_par_CLASSE();
           return dt;
       }


       public DataTable Afficher_total_par_niv()
       {

           DataTable dt = new DataTable();
           dt = t.Afficher_total_par_niv();
           return dt;
       }

       public DataTable Afficher_total_DES_TOTAUX()
       {

           DataTable dt = new DataTable();
           dt = t.Afficher_total_DES_TOTAUX();
           return dt;
       }

       public DataTable ReparEtudiantParPole()
       {
           DataTable dt = new DataTable();
           dt = t.ReparEtudiantParPole();
           return dt;
       }

       //total Répartition des étudiants par Niveau et Pôle
       public DataTable titalReparEtudiantParPole()
       {
           DataTable dt = new DataTable();
           dt = t.titalReparEtudiantParPole();
           return dt;
       }

       //Répartition des Classes par Niveau etPôle
       public DataTable ReparclasseParPole()
       {
           DataTable dt = new DataTable();
           dt = t.ReparclasseParPole();
           return dt;
       }

       //total Répartition des Classes par Niveau etPôle
       public DataTable totalReparclasseParPole()
       {
           DataTable dt = new DataTable();
           dt = t.totalReparclasseParPole();
           return dt;
       }

       public DataTable Afficher_list_ens_UPaffecter()
       {
           DataTable dt = new DataTable();
           dt = t.Afficher_list_ens_UPaffecter();
           return dt;
       }
       public DataTable Afficher_ens_saisis()
       {
           DataTable dt = new DataTable();
           dt = t.Afficher_ens_saisis();
           return dt;
       }
       public DataTable Afficher_list_ens_affecter()
       {

           DataTable dt = new DataTable();
           dt = t.Afficher_list_ens_affecter();
           return dt;
       }
       public DataTable Affich_list_etud_niveau_ang()
       {
           DataTable dt = new DataTable();
           dt = t.Affich_list_etud_niveau_ang();
           return dt;
       }

       public DataTable Affich_list_etud_niveau_FR()
       {
           DataTable dt = new DataTable();
           dt = t.Affich_list_etud_niveau_FR();
           return dt;
       }

       public DataTable bind_niveau_1516()
       {
           DataTable dt = new DataTable();
           dt = t.bind_niveau_1516();
           return dt;
       }
       public DataTable bind_classes_1516(string niv)
       {
           DataTable dt = new DataTable();
           dt = t.bind_classes_1516(niv);
           return dt;
       }

       public DataTable bind_Nom_Ens(string code_classe)
       {
           DataTable dt = new DataTable();
           dt = t.bind_Nom_Ens(code_classe);
           return dt;
       }

       public DataTable bind_niveau_ang_et(string namess, string code_cl)
       {
           DataTable dt = new DataTable();
           dt = t.bind_niveau_ang_et(namess, code_cl);
           return dt;
       }
       
       public DataTable bind_list_niveau()
       {
           DataTable dt = new DataTable();
           dt = t.bind_list_niveau();
           return dt;

       }

       public DataTable bind_list_niveau2()
       {

           DataTable dt = new DataTable();
           dt = t.bind_list_niveau2();
           return dt;
       }

       public int Update_niv_etud(string id_etud, string niv_fr, string id_ens)
       {
           return t.Update_niv_etud(id_etud, niv_fr, id_ens);
       }

       public int Update_niv_etud_ang(string id_etud, string niv_ang, string id_ens)
       {
           return t.Update_niv_etud_ang(id_etud, niv_ang, id_ens);
       }
        
       public string GetUP(string id_ens)
       {
           return t.GetUP(id_ens);
       }

    }
    }

