using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;


namespace BLL
{
    public class ServiceEDT
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        EmploiDAO emploi = EmploiDAO.Instance;

        public DataTable BindNumSeanceBYNnmclature()
        {
            dt = emploi.BindNumSeanceBYNnmclature();
            return dt;
        }

        
        public string verifDisponibilite(string jourSeance, int heuredebut, int heureFin, string idEns)
        {
            return emploi.verifDisponibilite(jourSeance, heuredebut, heureFin, idEns);
        }
        public DataTable getAllClass()
        {
            dt = emploi.getAllClass();
            return dt;
        }
        public DataTable Getnomens(string id_ens)
        {
            dt = emploi.Getnomens(id_ens);
            return dt;
        
        }


        public string GetnbHr(string code_cl, string code_module)
        {
            return emploi.GetnbHr(code_cl, code_module);
        }

        public DataTable BindMODULEByEns(string nom_ens,string code_cl)
        {
            dt = emploi.BindMODULEByEns(nom_ens,code_cl);
            return dt;
        }
        public DataTable getEnsinDispoparlmjed(string id_ens, DateTime jours, int num_seance1, int num_seance2)
        {
            dt = emploi.getEnsinDispoparlmjed(id_ens, jours,  num_seance1,  num_seance2);
            return dt;
        }

        public void Enre_Affect_emploi(string annee_deb, string code_cl, string code_modUle, string id_ens1, string salle_p, DateTime jours, int CR1, int CR2)
        {
            emploi.Enre_Affect_emploi(annee_deb,code_cl,code_modUle,id_ens1,salle_p,jours,CR1,CR2);
        }
        //verifier l'indisponibilite des enseignants
        public DataTable getEnsIndisponible(string code_cl,string id_ens,string code_module,DateTime  jours,int cren1,int cren2,string sallepr)
        {
            dt = emploi.getEnsIndisponible(code_cl,id_ens,code_module,jours,cren1,cren2,sallepr);
            return dt;
        }
        public string getNameteacher(string id_ens)
        {
            return emploi.getNameteacher(id_ens);
        }
        //PLAN ETUDE
        public DataTable PlanEtuDE(string codee_ccl)
        {
            dt = emploi.PlanEtuDE(codee_ccl);
            return dt;
        }

        //bind enseignant indisponible where i selected a row
        public DataTable getEnsIndispo(string id_ens)
        {
            dt = emploi.getEnsIndispo(id_ens);
            return dt;
        }

        public DataTable BindClasspegroupbycl(string code_cl)
        {
            dt = emploi.BindClasspegroupbycl(code_cl);
            return dt;
        }

       

        public DataTable getdispojours(string Jours, string num_seance1, string num_seance2,string id_ens)
        {
            dt = emploi.getdispojours(Jours,num_seance1, num_seance2,id_ens);
            return dt;
        }

        public string GetCodeCL_BYet(string id_et)
        {
            return emploi.GetCodeCL_BYet(id_et);
            
        }

        public DataTable BindClasspe()
        {
            dt = emploi.BindClasspe();
            return dt;
        }

        //public List<ESP_SALLE_CLASSE> getSalleClasse()
        //{
        //    return emploi.getSalleClase();
        //}

        public bool Delete_esp_salle(decimal _ID)
        {
            return emploi.Delete_esp_salle(_ID); 
        }

        public DataTable getListeEnseigant()
        {
            return emploi.getAllenseign();
        }

        public int UpdateSalle(string salle)
        {
            return emploi.UpdateSalle(salle);
        }

        public int DeleteEnseig(string id)
        {
            return emploi.DeleteEnseig(id);
        }

        public bool SaveEmploiduTemps(string _CODE_EMPLOI, string _TYPE, string _ID_ENS, string _H_DEBUT, string _H_FIN, DateTime _JOURS_SEANCE, string _SALLE_P, string _CODE_MODULE, string _CODE_CL)
        {
            return emploi.SaveEmploiduTemps(_CODE_EMPLOI, _TYPE, _ID_ENS, _H_DEBUT, _H_FIN, _JOURS_SEANCE, _SALLE_P, _CODE_MODULE, _CODE_CL);
        }

        public void AjouterEmploi(string _CODE_EMPLOI, string _TYPE, string _ID_ENS, int _H_DEBUT, int _H_FIN, DateTime _JOURS_SEANCE, string _SALLE_P, string _CODE_MODULE, string _CODE_CL, int minutE, int minS)
        {
            emploi.AjouterEmploi(_CODE_EMPLOI, _TYPE, _ID_ENS, _H_DEBUT, _H_FIN, _JOURS_SEANCE, _SALLE_P, _CODE_MODULE, _CODE_CL, minutE, minS);
        }
        public string getCl()
        {

            return emploi.getCl();


        }

        public DataTable getEns()
        {
            dt = emploi.Getens();
            return dt;
        }
        public DataTable getAllenseign()
        {
            dt = emploi.getAllenseign();
            return dt;
        }
        //public List<ESP_SALLE_CLASSE> getSalle()
        //{
        //    return emploi.getSalle();
        //}
        public DataTable getAllClasses()
        {
            dt = emploi.getAllClasses();
            return dt;
        }
        public DataTable getAllModule()
        {
            dt = emploi.getAllModule();
            return dt;

        }
        public string date_seance()
        {
            return emploi.date_seance();
        }

        public int UpdateSalle(string codecl, string salle,float id)
        {
            return emploi.UpdateSalle(codecl,salle,id);
        }
        public string getanneedeb()
        {
            return emploi.getanneedeb();
        }

        public DataTable GetDataEvents()
        {
            dt = emploi.GetDataEvents();
            return dt;
        }
        public DataTable GetEventsByClasse(string code_cl)
        {
            dt = emploi.GetEventsByClasse(code_cl);
            return dt;

        }

        public List<ESP_MODULE_PANIER_CLASSE_SAISO> getnumSemestre()
        {
            return emploi.getnumSemestre();
        }
        public int Updatedispo(int idens)
        {
            return emploi.Updatedispo(idens);
        }
        //retenir les enseignants indisponible
        public DataSet GetEnseignantdisponible()
        {
            ds = emploi.GetEnseignantdisponible();
            return ds;
        }

        public DataTable getlisteCLbYeNS(string id_ens)
        {
            dt = emploi.getlisteCLbYeNS(id_ens);
            return dt;
        }
        public DataTable getENsBymoD(string code_CL)
        {
           dt= emploi.getENsBymoD(code_CL);
           return dt;
        }
        public DataTable getMODULEBY(string code_cLASSE)
        {
            dt = emploi.getMODULEBY(code_cLASSE);
            return dt;
        }
        public string getNUMSemestre()
        {
            return emploi.getNUMSemestre();
        }

        public string getAnneeFiN()
        {
            return emploi.getAnneeFiN();
        }

        public DataTable BindListensIndispo()
        {
            dt = emploi.BindListensIndispo();
            return dt;
        }
        public string getANNEEDEB()
        {
            return emploi.getANNEEDEB();
        }

        public string getIDenseignant(string nom_ense)
        {
            return emploi.getIDenseignant(nom_ense);
        }
        public string getsalleBycode(string code_cl)
        {
            return emploi.getsalleBycode(code_cl);
        }
        public string loginEns(string _ID_ENS, string _PWD_ENS)
        {
            return emploi.loginEns(_ID_ENS, _PWD_ENS);
        }

        public void addModule(string code, string designation)
        {
            emploi.Ajoutermatiere(code, designation);
        }

        public void choisirEmploiByID_ENS(string ID_ENS)
        {
            emploi.choisirEmploiByID_ENS(ID_ENS);
        }
        public DataTable GetSALLEbyClasse(string codecl)
        {
            dt = emploi.getSalleByClasSe(codecl);
            return dt;
        }
        public DataTable BindDataEventsByID_ENS(string id_ens)
        {
            dt = emploi.BindDataEventsByID_ENS(id_ens);
            return dt;
        }
        public DataTable GetDataEventsByCode_cl(string code_cl)
        {
            dt = emploi.GetDataEventsByCode_cl(code_cl);
            return dt;
        }
        
        public DataTable GetDataEventsByID_ENS(string id_ens)
        {
            dt = emploi.GetDataEventsByID_ENS(id_ens);
            return dt;
        }

        public void VerifDispo(string annee,string idens, string joursSeance, int hd, int hf)
        {
            emploi.VerifDispo(annee,idens,joursSeance, hd, hf);
        }

        public DataTable GETdispo()
        {
            dt = emploi.GETdispo();
            return dt;
        }


        public DataTable GETiNDSPObYid(string ID_ENS)
        {
            dt = emploi.GETiNDSPObYid(ID_ENS);
            return dt;
        }

        public int Deleteenseign(string id_ens)
        {
            return emploi.Deleteenseign(id_ens);
        }

        public string getdispo(string id_ens)
        {
            return emploi.getdispo(id_ens);
        }
        public void posteddate(string _SALLE_P, string _CODE_MODULE, string _CODE_CL)
        {

             emploi.posteddate(_SALLE_P, _CODE_MODULE, _CODE_CL);
        }

        public DataTable Bindrep()
        {
            dt = emploi.Bindrep();
            return dt;
        }
    }
}