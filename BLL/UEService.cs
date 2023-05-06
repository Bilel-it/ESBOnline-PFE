using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    public class UEService
    {
       UEDAO ue = UEDAO.Instance;
       UEDAO moo = UEDAO.Instance;
        DataTable dt = new DataTable();
        public DataTable Getchapteraquis(string annedeb, string mod)
        {
            dt = ue.Getchapteraquis(annedeb, mod);
            return dt;
        }
        public DataTable GetUEV0(string id_ens, string annedeb)
        {
            dt = ue.GetUEV0(id_ens, annedeb);
            return dt;

        }
        public void Delete_Chapter_Acquis(string id_ens, string num_chap, string titre, string code_module, string annee)
        {
            ue.Delete_Chapter_Acquis(id_ens, num_chap, titre, code_module, annee);

        }

        public DataTable GetlistOFChapterByModuleFirst(string cod_module)
        {
            dt = ue.GetlistOFChapterByModuleFirst(cod_module);
            return dt;
        }
        public string HaveCLfromemploi(string id_ens, DateTime d1, string heure)
        {

            return ue.HaveCLfromemploi(id_ens, d1, heure);


        }
        public string getAnneeSociete()
        {
            return ue.getAnneeSociete();
        }
        public DataTable Getchapteraquis2018(string text, string id_ens, string an)

        {
            dt = ue.Getchapteraquis2018(text, id_ens, an);
            return dt;
        }

        public DataTable getseance(string id_ens, string codmod, string codcl)
        {

            dt = ue.getseance(id_ens, codmod, codcl);
            return dt;
        }

        //public DataTable getclasse(string id_ens)
        //{
        //    dt = ue.getclasse(id_ens);
        //    return dt;

        //}

        public DataTable GetlistOFChapterByModule(string cod_module, string code_cl)
        {
            dt = ue.GetlistOFChapterByModule(cod_module, code_cl);
            return dt;
        }
        public DataTable GetUE(string id_ens, string annedeb)
        {
            dt = ue.GetUE(id_ens, annedeb);
            return dt;
        }
        public DataTable GetUExep(string id_ens, string annedeb)
        {
            dt = ue.GetUExep(id_ens, annedeb);
            return dt;
        }

        public string getCode_CL(string id_et)
        {
            return ue.getCode_CL(id_et);
        }
        public int Updateacquis(string idens, string idacquis)
        {
            return ue.Updateacquis(idens, idacquis);
        }

        public void ValidChapterBYCLS(string id_ens, string code_cl, string code_module, string id_acquis, DateTime d2, string _PROG_COURS, string rq, string PROG_COURS_PERCENT)
        {

            ue.ValidChapterBYCLS(id_ens, code_cl, code_module, id_acquis, d2, _PROG_COURS, rq, PROG_COURS_PERCENT);


        }
        public DataTable verifexistAcquis(string code_ue)
        {
            dt = ue.verifexistAcquis(code_ue);
            return dt;
        }
        public int UpdateValidChapterBYCLS(string id_ens, string id_acquis, string _PROG_COURS, string REMARQUE_ENS, string _PROG_COURS_PERCENT)
        {
            return ue.UpdateValidChapterBYCLS(id_ens, id_acquis, _PROG_COURS, REMARQUE_ENS, _PROG_COURS_PERCENT);

        }
        public DataTable GetCl(string idenss, string mod)
        {
            dt = ue.GetCl(idenss, mod);
            return dt;
        }
        public DataTable GetUEBYRESPO(string annedeb)
        {
            dt = ue.GetUEBYRESPO(annedeb);
            return dt;
        }
        public void EnregAquis(string idens, string num, string code_ue, string aquis, string annee_deb)
        {

            ue.EnregAquis(idens, num, code_ue, aquis, annee_deb);
        }


        public DataTable verifexistue(string codue)
        {
            dt = ue.verifexistue(codue);
            return dt;

        }

        public bool Verif(string _ann, string _module)
        {
            return ue.Verif(_ann, _module);
        }
        public string GetAnnee()
        {
            return ue.GetAnnee();
        }
        public DataTable GetUeDetails(string annedeb, string CODEue)
        {
            dt = ue.GetUeDetails(annedeb, CODEue);
            return dt;
        }

        public DataTable GetUeDetailsMODULE(string annedeb, string CODEue)
        {
            dt = ue.GetUeDetailsMODULE(annedeb, CODEue);
            return dt;
        }
        public DataTable getDEtailsmodule(string codue, string ann,string id_ens)
        {
         dt = ue.getDEtailsmodule(codue, ann, id_ens);
            return dt;
        }
        public string getannee_deb()
        {
            return ue.getannee_deb();
        }
        public string getUP(string code_ue)
        {
            return ue.getUP(code_ue);
        }
        
            public DataTable getModule(string ann, string Pid)
        {
            dt = ue.getModule(ann, Pid);
            return dt;
        }
        public DataTable GetUeDetailsens()
        {
            dt = ue.GetUeDetailsens();
            return dt;
        }

        public string GetLIBUE(string code_ue)
        {
            return ue.GetLIBUE(code_ue);
        }

        public void EnregRESUE(string code_ue, string id_ens, string annee_deb, string user)
        {
            ue.EnregRESUE(code_ue, id_ens, annee_deb, user);
        }
        public string getRespoUE(string code_ue, string an)
        {
            return ue.getRespoUE(code_ue, an);
        }

        public DataTable verifexist(string annedeb, string code_ue)
        {

            dt = ue.verifexist(annedeb, code_ue);
            return dt;
        }

        public string gETrESPONSABLEue(string code_ue, string an)
        {
            return ue.gETrESPONSABLEue(code_ue, an);
        }


        public DataTable getDEtailsmodbMODULES(string mod)
        {
            dt = ue.getDEtailsmodbMODULES(mod);
            return dt;
        }


        public void EnregChapterBymodule(string code_module, string num_chap, string title_chapter, string annee_deb, string cue, string id_ens, string chapH)
        {
            ue.EnregChapterBymodule(code_module, num_chap, title_chapter, annee_deb, cue, id_ens, chapH);
        }

        public void EnregEvalEXAM(string code_module, string annee_deb, string EXPLICATION, string MODE_EVAL, string CALCUL_EXAM, string id_user, string TYPE_EXAM, string QUOTA_TP, string QUOTA_DS, string QUOTA_QCM, string QUOTA_TEST, string typds)
        {
            ue.EnregEvalEXAM(code_module, annee_deb, EXPLICATION, MODE_EVAL, CALCUL_EXAM, id_user, TYPE_EXAM, QUOTA_TP, QUOTA_DS, QUOTA_QCM, QUOTA_TEST, typds);
        }

        public DataTable GEtEval(string codmodule, string ann)
        {
            dt = ue.GEtEval(codmodule, ann);
            return dt;
        }

        public void EnregEval(string code_module, string annee_deb, string EXPLICATION, string MODE_EVAL, string CALCUL_EXAM, string id_user, string TYPE_EXAM)
        {
            ue.EnregEval(code_module, annee_deb, EXPLICATION, MODE_EVAL, CALCUL_EXAM, id_user, TYPE_EXAM);
        }
        public void EnregContentChapter(string code_module, string num_chap, string title_chapter, string annee_deb, string code_chapter)
        {

            ue.EnregContentChapter(code_module, num_chap, title_chapter, annee_deb, code_chapter);

        }

        public DataTable GetDATAUe2017(string annedeb, string up)
        {
            dt = ue.GetDATAUe2017(annedeb, up);
            return dt;
        }


        public DataTable GETlISTEns(string up)
        {
            dt = ue.GETlISTEns(up);
            return dt;

        }
        public DataTable GETlISTEns_all(string up)
        {
            dt = ue.GETlISTEns_all(up);
            return dt;

        }
        //public string getUP(String id_ens)
        //{
        //    return ue.getUP(id_ens);
        //}

        public string getannee_debFin()
        {
            return ue.getannee_debFin();
        }


        public int UpdateCoordinator(string etat, string user, string idens, string ue, string an)
        {


            return moo.UpdateCoordinator(etat, user,idens, ue, an);
        }

        public int UpdateCoordinatorup(string id, string user)
        {


            return moo.UpdateCoordinatorup(id,user);
        }
        public DataTable GetDATAUe(string cd, string cm)
        {
            dt = ue.GetDATAUe(cd, cm);
            return dt;
        }

        public DataTable uee(string annedeb)
        {
            dt = ue.uee(annedeb);
            return dt;
        }



        public DataTable ENS()
        {
            dt = ue.ENS();
            return dt;
        }


        public DataTable getModuleBYEns(string id_ens)
        {

            dt = ue.getModuleBYEns(id_ens);
            return dt;
        }
        //public DataTable getseance(string id_ens)
        //{
        //    dt = ue.getseance(id_ens);
        //    return dt;
        //}

        public DataTable gemodule(string id_ens, string d1, string code_cl)
        {
            dt = ue.gemodule(id_ens, d1, code_cl);
            return dt;

        }
        //public int UpdateCoordinator(string idens, string ue, string an)
        //{
        //    return ue.UpdateCoordinator(idens, ue, an);
        //}


        public DataTable getModuleByCL(string code_cl)
        {
            dt = ue.getModuleByCL(code_cl);
            return dt;
        }


        public DataTable GetModuleValidForEtud(string cod_module, string cod_cl, string id_ens)
        {
            dt = ue.GetModuleValidForEtud(cod_module, cod_cl, id_ens);
            return dt;

        }



        public string GetensBymodule(string cl, string modd)
        {
            return ue.GetensBymodule(cl, modd);

        }



        public DataTable GetModuleValidForEtudByseance(string cod_cl, string cod_module, string id_ens, DateTime s)
        {
            dt = ue.GetModuleValidForEtudByseance(cod_cl, cod_module, id_ens, s);
            return dt;
        }

        public void InsertobservEtud(string id_et, string code_module, string annee_deb, string observ, DateTime d1, string t, string typ)
        {
            ue.InsertobservEtud(id_et, code_module, annee_deb, observ, d1, t, typ);

        }

        public DataTable Getcordmodule(string codmod)
        {
            dt = ue.Getcordmodule(codmod);
            return dt;
        }

        //coordinateur

        public DataTable GetUP()
        {
            dt = ue.GetUP();
            return dt;

        }


        public DataTable GetUPBYdept(string iddept)
        {
            dt = ue.GetUPBYdept(iddept);
            return dt;
        }


        public DataTable GetUPBYdeptByens()
        {
            dt = ue.GetUPBYdeptByens();
            return dt;

        }


        public DataTable GetUPBYdeptByensid(string id)
        {
            dt = ue.GetUPBYdeptByensid(id);
            return dt;

        }

        public string Get_dept(string id_ens)
        {
            return ue.Get_dept(id_ens);
        }
        public DataTable Havmod()
        {
            dt = ue.Havmod();
            return dt;
        }

        public DataTable Getmodule(string up)
        {
            dt = ue.Getmodule(up);
            return dt;
        }

        public DataTable GetmoduleBy()
        {
            dt = ue.GetmoduleBy();
            return dt;
        }
        public DataTable Getens(string up)
        {

            dt = ue.Getens(up);
            return dt;
        }

        public DataTable Getensansup()
        {

            dt = ue.Getensansup();
            return dt;
        }
        public DataTable HAVens()
        {

            dt = ue.HAVens();
            return dt;
        }
        public DataTable GetDATAUe(string cd)
        {
            dt = ue.GetDATAUe(cd);
            return dt;
        }

        public string getLIbelModule(string cdmod)
        {
            return ue.getLIbelModule(cdmod);
        }



        public DataTable GetEns(string codmod, string codcl)
        {
            dt = ue.GetEns(codmod, codcl);
            return dt;

        }
        public string Get_enss(string codmod, string codcl)
        {

            return ue.Get_enss(codmod, codcl);
        }


        public string getcl(string id_et, string ann_deb)
        {

            return ue.getcl(id_et, ann_deb);
        }
        public DataTable GetResponsModule(string codmod)
        {
            dt = ue.GetResponsModule(codmod);
            return dt;
        }
        //////////////////maj saber
        public DataTable Getdatedeb()
        {
            return ue.Getdatedeb();
        }

        public DataTable Getdatefin()
        {
            return ue.Getdatefin();
        }
        public string GetProgress2(string id_acquis, string id_ens, string classe, string Code_Module, string date_seance)
        {
            return ue.GetProgress2(id_acquis, id_ens, classe, Code_Module, date_seance);
        }

        public string remarque_ens(string id_acquis, string id_ens, string code_module, string classe, string date_seance)
        {
            return ue.remarque_ens(id_acquis, id_ens, code_module, classe, date_seance);
        }

    

        public string GetProgress3(string id_acquis, string id_ens, string classe, string Code_Module, string date_seance)
        {
            return ue.GetProgress3(id_acquis, id_ens, classe, Code_Module, date_seance);
        }

        public bool VerifExist(string _ann, string _module, string _ens)
        {
            return ue.VerifExist(_ann,_module,_ens);
        }
        public DataTable nb_acquis(string id_ens, string code_module, string id_acquis, string classe, string date_seance)
        {
            dt = ue.nb_acquis(id_ens, code_module, id_acquis, classe, date_seance);
            return dt;
        }

        public DataTable Getchapteraquis2018(string text, string id_ens)

        {
            dt = ue.Getchapteraquis2018(text, id_ens);
            return dt;
        }

        public void Insert_Chapter_Acquis(string annee_deb, string code_module, string designation, string num_chap)
        {
            ue.Insert_Chapter_Acquis(annee_deb, code_module, designation, num_chap);

        }
        public DataTable Getchapteraquis2(string annedeb, string mod, string num_chap)
        {
            dt = ue.Getchapteraquis2(annedeb, mod, num_chap);
            return dt;
        }


        public string getID_Ens_Chapitre(string selectedValue1, string selectedValue2, string num_chap)
        {
            return ue.getID_Ens_Chapitre(selectedValue1, selectedValue2, num_chap);


        }
     

        public void Delete_Acquis_only_1(string num_chap, string module, string designation,string annd)
        {
            ue.Delete_Acquis_only_1(num_chap, module, designation,annd);
        }
        public void Delete_Acquis(string num_chap, string code_module,string ann)
        {
            ue.Delete_Acquis(num_chap, code_module,ann);

        }
        public DataTable AddChapter(string annedeb, string mod, string id_ens, string titre, string numero, string heure)
        {
            dt = ue.Addchapter(annedeb, mod, id_ens, titre, numero, heure);
            return dt;
        }
      

        public int UpdateChapter(string annedeb, string mod, string id_ens, string titre2, string heure, string titre, string num)
        {
            return ue.Updatechapter(annedeb, mod, id_ens, titre2, heure, titre, num);

        }
        //public DataTable Getchapteraquis2018(string text, string id_ens)

        //{
        //    dt = ue.Getchapteraquis2018(text, id_ens);
        //    return dt;
        //}

        public DataTable GetAssignments(string id_ens, string debut, string fin)
        {
            dt = ue.GetAssignments(id_ens, debut, fin);
            return dt;
        }
        //public DataTable GetAssignments(string id_ens)
        //{
        //    dt = ue.GetAssignments(id_ens);
        //    return dt;
        //}
        public DataTable Getchapteraquis22(string text1, string v, string text2, string classe, string date_seance)
        {
            dt = ue.Getchapteraquis22(text1, v, text2, classe, date_seance);
            return dt;
        }


        public int remarque_update(string id_ens, string code_module, string id_acquis, string classe, string remarque, string date_seance, string PROG_COURS, string pourcentage)
        {
            return ue.remarque_update(id_ens, code_module, id_acquis, classe, remarque, date_seance, PROG_COURS, pourcentage);
        }


        public DataTable remarque(string id_ens, string code_module, string id_acquis, string classe, string remarque, string date_seance, string PROG_COURS, string pourcentage, string jour2)
        {
            dt = ue.remarque(id_ens, code_module, id_acquis, classe, remarque, date_seance, PROG_COURS, pourcentage, jour2);
            return dt;
        }



        //////////Mise a jour saber 08/02/2019
        public DataTable FindEval(string selectedValue1, string selectedValue2, string id_ens)
        {
            dt = ue.FindEval(selectedValue1, selectedValue2, id_ens);
            return dt;

        }

        public int UpdateEvalEXAM(string selectedValue1, string an, string v, string hgd, string selectedValue2, string id_ens, string selectedValue3, string text1, string text2, string text3, string text4, string selectedValue4)
        {
            return ue.UpdateEvalEXAM(selectedValue1, an, v, hgd, selectedValue2, id_ens, selectedValue3, text1, text2, text3, text4, selectedValue4);
        }

        public object getModuleResponsable(string id_ens, string selectedValue)
        {
            dt = ue.getModuleResponsable(id_ens, selectedValue);
            return dt;
        }
        public DataTable GetDetailsModule(string mod, string ann, string id)
        {
            dt = ue.GetDetailsModule(mod, ann, id);
            return dt;
        }
        public void Delete_Eval(string selectedValue1, string selectedValue2)
        {
            ue.Delete_Eval(selectedValue1, selectedValue2);


        }

        //sevice responsable module 27092019


      
        public DataTable Listmodules(string id_ens, string an)
        {
            dt = ue.Listmodules(id_ens, an);
            return dt;
        }

        public DataTable module_sans_responsable(string id_ens, string an)
        {
            dt = ue.module_sans_responsable(id_ens, an);
            return dt;
        }

        public DataTable ListResponsable(string id_ens)
        {
            dt = ue.ListResponsable(id_ens);
            return dt;
        }

        public DataTable ListEnseignantUP(string id_ens)
        {
            dt = ue.ListEnseignantUP(id_ens);
            return dt;
        }

        public int desactiver(string idens, string code_module, string id)
        {
            return ue.desactiver(idens, code_module, id);
        }

        public void EnregistrerModification(string code_ue, string id_ens, string annee_deb, string user)
        {
            ue.EnregistrerModification(code_ue, id_ens, annee_deb, user);
        }

        public void EnregistrerAffectation(string code_module, string id_responsable, string annee_deb, string id_ens)
        {
            ue.EnregistrerAffectation(code_module, id_responsable, annee_deb, id_ens);
        }
    }

}
    
