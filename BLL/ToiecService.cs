using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
   public class ToiecService
   {
       ToiecDAO service = ToiecDAO.Instance;
       DataTable dt = new DataTable();

       public DataTable verif5eme()
       {
           dt = service.verif5eme();
           return dt;
       }
       public string verif5eme2014(string id_et)
       {
           return service.verif5eme2014(id_et);

       }
        public DataTable getrst(string id_etd)
        {
            dt = service.getrst(id_etd);
            return dt;

        }
        public string verif5eme2015(string id_et)
       {
           return service.verif5eme2015(id_et);

       }
       public string returnCL(string id_edt)
       {
           return service.returnCL(id_edt);
       }
       
       public void Enreg_etud_FORMAt_test(string id_et, string _choix)
       {
           service.Enreg_etud_FORMAt_test(id_et, _choix);
       }

       public void Enreg_etud_test(string id_et, string _choix)
       {
           service.Enreg_etud_test(id_et, _choix);
       }
       //public string selectEtatTPREPTOIEC(string id_edt)
       //{
       //    return service.selectEtatTPREPTOIEC(id_edt);
       //}

       public string selectEtatTTOIEC(string id_edt)
       {
           return service.selectEtatTTOIEC(id_edt);
       }

       public string selectEtatTTOIECENS(string id_ens)
       {
           return service.selectEtatTTOIECENS(id_ens);
       }


       public string selectEtatTest(string id_edt)
       {
           return service.selectEtatTest(id_edt);
       }

       public string selectPreparationEtatTTOIECenseign(string id_ens)
       {
           return service.selectPreparationEtatTTOIECenseign(id_ens);
       
       }

       public string selectEtatTTOIECenseign(string id_ens)
       {
           return service.selectEtatTTOIECenseign(id_ens);
       }
       public DataTable Afficher_date_exam_etud( string id_et)
       {
           dt = service.Afficher_date_exam_etud(id_et);
           return dt;
       
       }
       public DataTable Afficher_date_exam_etudangang(string id_etd)
       {
           dt = service.Afficher_date_exam_etudangang(id_etd);
           return dt;

       }

       public DataTable Afficher_date_exam_etudfrfr(string id_etd)
       {
           dt = service.Afficher_date_exam_etudfrfr(id_etd);
           return dt;
       }

       //public int UpdatEPREPTOICTONo(string _id_etud)
       //{
       //    return service.UpdatEPREPTOICTONo(_id_etud);
       //}

       public DataTable bindDATEexaMANGg()
       {
           dt = service.bindDATEexaMANG();
           return dt;
       }
       public DataTable bindDATEexaMANG()
       {
           dt = service.bindDATEexaMANG();
           return dt;
       }


       public int UpdatETOICToNo(string _id_etud)
       {
           return service.UpdatETOICToNo(_id_etud);
       }

       public int UpdatETOICToNoenseig(string _id_ens)
       {
           return service.UpdatETOICToNoenseig(_id_ens);
       }

       public int UpdatEPREPTOICToNoenseig(string _id_ens)
       {

           return service.UpdatEPREPTOICToNoenseig(_id_ens);
       }
       public string nbtoiec()
       {
           return service.nbtoiec();
       }
       public string nbPREPtoiec()
       {
           return service.nbPREPtoiec();
       }

       public DataTable Afficher_list_condParDateANG(DateTime date)
       {
           dt = service.Afficher_list_condParDateANG(date);
           return dt;
       }
       public string returnCLSUPP(string id_edt)
       {
           return service.returnCLSUPP(id_edt);

       }
       public string returnCLSUPP2014(string id_edt)
       {
           return service.returnCLSUPP2014(id_edt);

       }
       public DataTable Afficher_list_condParDateFR(DateTime date)
       {
           dt = service.Afficher_list_condParDateFR(date);
           return dt;
       }
       public string selectniVeauEDTFR(string id_edt)
       {
           return service.selectniVeauEDTFR(id_edt);
       }
       public string selectniVeauEDTANG(string id_edt)
       {
           return service.selectniVeauEDTANG(id_edt);
       }
       public bool verif(string idate)
       {

         return service.verif(idate);
          
       }
       public bool verifang(string idate)
       {
           return service.verifang(idate);
       }
       public string nbCondidatsInscritang(DateTime dateinsc)
       {
           return service.nbCondidatsInscritang(dateinsc);
       }

       public string nbCondidatsInscrit(DateTime dateinsc)
       {
           return service.nbCondidatsInscrit(dateinsc);
       }

       public int UpdateEtatInsctestniv(string _id_etud)
        {
            return service.UpdateEtatInsctestniv(_id_etud);
        }

       public void Enreg_inscriTest_fr(DateTime _DATE_TEST_FR, string id_et, string annee_deb)
       {
            service.Enreg_inscriTest_fr(_DATE_TEST_FR,id_et,annee_deb);
       }

       public void Enreg_inscriTest_ANG(DateTime _DATE_TEST_ANG, string id_et, string annee_deb)
       {
           service.Enreg_inscriTest_ANG(_DATE_TEST_ANG,id_et,annee_deb);
       }
       public void Enreg_inscriTest_Lng(DateTime _DATE_TEST_FR, DateTime _DATE_TEST_ANG, string id_et, string annee_deb)
       {
           service.Enreg_inscriTest_Lng(_DATE_TEST_FR, _DATE_TEST_ANG, id_et, annee_deb);
       }

       public string getANNEEDEBs()
       {
           return service.getANNEEDEBs();
       }


       public string getAnneeFiN()
       {
           return service.getAnneeFiN();
       }

       public DataTable bindDATEexaM()
       {
          dt = service.bindDATEexaM();
           return dt;
       }

       //public DataTable bindDATEexamang()
       //{
       //    dt = service.bindDATEexamang();
       //    return dt;
       //}


       //public int UpdatEPREPTOIC(string _id_etud)
       //{
       //    return service.UpdatEPREPTOIC(_id_etud);
       //}

       public int UpdatETOIC(string _id_etud)
       {
           return service.UpdatETOIC(_id_etud);
       }
       public void Addnbcondidatfr(DateTime date)
       {
           service.Addnbcondidatfr(date);
       }
       public void AddnbcondidatANG(DateTime dateang)
       {
           service.AddnbcondidatANG(dateang);
       }
       public bool ajoutnbcandidats(DateTime datetest)
       {
          
           return service.ajoutnbcandidatsfr(datetest);
          
       }
       public bool ajoutnbcandidatsang(DateTime datetest)
       {
           return service.ajoutnbcandidatsang(datetest);
       }

       public DataTable Afficher_date_exam_etud_mamadate(DateTime date)
       {
           dt = service.Afficher_date_exam_etud_mamadate(date);
           return dt;
       }

       public DataTable bindDATEx()
       {
           dt = service.bindDATEx();
           return dt;
       }

       public DataTable Affich_ETUD_NULL(DateTime date)
       {
           dt = service.Affich_ETUD_NULL(date);
           return dt;
       }

       public string countNBTOIEC()
       {
           return service.countNBTOIEC();
       }
       public string countNBPREPTOIEC()
       {
           return service.countNBPREPTOIEC();
       }
       public DataTable Afficher_list_commune()
       {
           dt = service.Afficher_list_commune();
           return dt;
       }

       public DataTable Afficher_list_commune_formation()
       {
           dt = service.Afficher_list_commune_formation();
           return dt;
       }
      
       public DataTable Afficher_list_PREP_toiec()
       {
           dt = service.Afficher_list_PREP_toiec();
           return dt;
       }
       public DataTable Afficher_format_ang()
       {
           dt = service.Afficher_format_ang();
           return dt;
       }

       public DataTable Afficher_list_toiec()
       {
           dt = service.Afficher_list_toiec();
           return dt;
       }
       //public string countNBPrep_TOIEC_et_prep()
       //{
       //    return service.countNBPrep_TOIEC_et_prep();
       //}

       public string countNB_TOIEC()
       {
           return service.countNB_TOIEC();
       }
       public string countNB_fr_ang()
       {
           return service.countNB_fr_ang();
       }
       public string countNB_ang()
       {
           return service.countNB_ang();
       }
       //public string countNB_TOIEC()
       //{
       //    return service.countNB_TOIEC();
       //}
       public string countNB_fr()
       {
           return service.countNB_fr();
       }
       public string countNBPrep_TOIEC()
       {
           return service.countNBPrep_TOIEC();
       }

       public int UpdatETOICenseign(string _id_ens)
       {
           return service.UpdatETOICenseign(_id_ens);
       }

       public int UpdatEPreparationTOICenseign(string _id_ens)
       {
           return service.UpdatEPreparationTOICenseign(_id_ens);
       }

       public DataTable Afficher_list_ens_toeic()
       {
           dt = service.Afficher_list_ens_toeic();
           return dt;
       }
       public void Enreg_etud_FORMATIONfr(string id_et, string _choix)
       {
           service.Enreg_etud_FORMATIONfr(id_et,  _choix);
       }

       public DataTable Afficher_format_fr()
       {
           dt = service.Afficher_format_fr();
           return dt;
       }
       public DataTable get_5_classe(string id_et)
       {
          dt= service.get_5_classe(id_et);
          return dt;
       }
       public DataTable get_id_etud_formation(string id_et)
       {
           dt = service.get_id_etud_formation(id_et);
           return dt;
       }

       public DataTable Afficher_list_ens_prep_toeic()
       {
           dt = service.Afficher_list_ens_prep_toeic();
           return dt;
       }


       public DataTable Afficher_list_ens_commun()
       {
           dt = service.Afficher_list_ens_commun();
           return dt;
       }

       public void Enreg_etud_toeic(string id_et, string _choix)
       {
           service.Enreg_etud_toeic(id_et, _choix);
       }

       public void Enreg_ens_toeic(string id_ens, string _choix)
       {
           service.Enreg_ens_toeic(id_ens,_choix);
       }

       public bool verifexistet()
       {
           return service.verifexistet();
       
       }

       public string getidtest_toeic()
       {
           return service.getidtest_toeic();
       }

       public DataTable Aff_list_inscrit(string id_et)
       {
           return service.Aff_list_inscrit(id_et);
       }

       public DataTable Aff_list_inscrit_ens(string id_ens)
       {
           return service.Aff_list_inscrit_ens(id_ens);
       }
       public int UpdatE_choix(string _id_etud, string choix)
       {
         return  service.UpdatE_choix(_id_etud,choix);
       }



       public string countnbinscrfr_date()
       {
           return service.countnbinscrfr_date();


       }


       public string returnCLSUPPmax(string id_edt)
       {
           return service.returnCLSUPPmax(id_edt);

       }


       public DataTable get_id_etud_formatioParDate(string id_et, string date_choix)
       {
           dt = service.get_id_etud_formatioParDate(id_et, date_choix);
           return dt;

       }


      


       public string countnbinscrANG_date()
       {
           return service.countnbinscrANG_date();
       }
       ///////////////////////////////////////////////////////////////////
      

       ////////////////////////////////////////////////////////////////////////

       public DataTable get_id_etud_formatioParDateANG(string id_et, String date_choix)
       {
           dt = service.get_id_etud_formatioParDateANG(id_et, date_choix);
           return dt;

       }
       //////////////////////////////////////////////////////////


       public void Enreg_etud_FORMAt_testparDATE(string id_et, string date)
       {
           service.Enreg_etud_FORMAt_testparDATE(id_et, date);
               
       }


       //formation29
       //public DataTable Consult_list_formation()
       //{
       //    dt = service.Consult_list_formation();
       //    return dt;
       //}

       public void Enreg_etud_FORMATION(string id_et, string _choix)
       {
           service.Enreg_etud_FORMATION(id_et, _choix);
       }

       public DataTable verifieretudiant(string id_ens)
       {

           dt = service.verifieretudiant(id_ens);
           return dt;
       }

       public DataTable Consult_list_formationggg()
       {
           dt = service.Consult_list_formationggg();
           return dt;
       }
    }
}
