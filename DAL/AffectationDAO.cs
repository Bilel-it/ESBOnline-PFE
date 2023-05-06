using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public class AffectationDAO
    {
       #region sing
        static AffectationDAO instance;
        static Object locker = new Object();
        public static AffectationDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new AffectationDAO();
                    }

                    return AffectationDAO.instance;
                }
            }

        }

        private AffectationDAO() { }
        #endregion sing
        public string getanneedeb()
        {
            using (Entities ctx = new Entities())
            {
                var req = (from ad in ctx.SOCIETEs
                           select ad.ANNEE_DEB).FirstOrDefault();
                         return req.ToString();
            }
        }
        public string getsemestre()
        {
            using (Entities ctx = new Entities())
            {
                var req = (from ad in ctx.SOCIETEs
                           select ad.NUM_SEMESTRE_ACTUEL);
                return req.ToString();
            }
        }
        public List<CODE_NOMENCLATURE> getlisttypeepreuve()
        {
            using (Entities ctx = new Entities())
            {
                var req = (from ens in ctx.CODE_NOMENCLATURE
                           where ens.CODE_STR.Equals("78") 
                           select ens).OrderBy(ens => ens.LIB_NOME).ToList();
                return req;
            }
        }
        public List<Class1> getListClasse()
        {
            using (Entities ctx = new Entities())
            {
                var pp = ctx.ESP_ENSEIGNANT;
                var cll = ctx.ESP_MODULE_PANIER_CLASSE_SAISO;
                var moo = ctx.ESP_MODULE;
                var req = (from p in pp
                           from cl in cll
                           from mo in moo

                           where p.ID_ENS.Equals("V-104-07") &&
                           cl.ANNEE_DEB.Equals("2013") &&
                           mo.UP == p.UP &&
                           cl.CODE_MODULE == mo.CODE_MODULE
                           && cl.NUM_SEMESTRE == 1

                           select new Class1 { CODE_CL = cl.CODE_CL }).Distinct().OrderByDescending(cl => cl.CODE_CL).ToList();
                return req;
            }
        }
        public List<Class1> getListAfectation4(string idclasse, string anneedeb, string up)
        {

            using (Entities ctx = new Entities())
            {
                var req = (//from p in ctx.ESP_ENSEIGNANT
                              from cl in ctx.ESP_MODULE_PANIER_CLASSE_SAISO
                              from mo in ctx.ESP_MODULE
                             

                              where
                              cl.ANNEE_DEB.Equals(anneedeb) &&
                              mo.UP.Equals(up) && cl.CODE_MODULE == mo.CODE_MODULE
                              && cl.CODE_CL.Equals(idclasse)
                              && cl.NUM_SEMESTRE == 1
                              // && cl.ID_ENS.Equals(p.ID_ENS)





                              select new Class1
                              {

                                  CODE_CL = cl.CODE_CL,
                                  NOM_ENS = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS select c.NOM_ENS).FirstOrDefault(),
                                  NOM_ENS2 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS2 select c.NOM_ENS).FirstOrDefault(),
                                  NOM_ENS3 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS3 select c.NOM_ENS).FirstOrDefault(),
                                  NOM_ENS4 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS4 select c.NOM_ENS).FirstOrDefault(),
                                  NOM_ENS5 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS5 select c.NOM_ENS).FirstOrDefault()
                               ,
                                  TYPE_EPREUVE = (string)(from p in ctx.CODE_NOMENCLATURE where p.CODE_NOME == cl.TYPE_EPREUVE select p.LIB_NOME).FirstOrDefault(),
                                  CODE_UE = cl.CODE_UE,
                                  ID_ENS2 = cl.ID_ENS2,
                                  ID_ENS3 = cl.ID_ENS3,
                                  ID_ENS4 = cl.ID_ENS4,
                                  ID_ENS5 = cl.ID_ENS5,
                                  CODE_MODULE = cl.CODE_MODULE,
                                  ID_ENS = cl.ID_ENS,
                                  DESIGNATION = mo.DESIGNATION,
                                  NB_HEURES = (decimal)cl.NB_HEURES,
                                  CHARGE_P1 = (decimal)cl.CHARGE_P1,
                                  CHARGE_P2 = (decimal)cl.CHARGE_P2,
                                  CHARGE_ENS1_P1 = (decimal)cl.CHARGE_ENS1_P1,
                                  CHARGE_ENS1_P2 = (decimal)cl.CHARGE_ENS1_P2,

                              }
                              ).Distinct().OrderByDescending(cl => cl.CODE_MODULE).ToList();
                return req;
            }
        }
        public List<Class1> getListAfectation3(string idclasse)
        {

            using (Entities ctx = new Entities())
            {
                var req = (//from p in ctx.ESP_ENSEIGNANT
                              from cl in ctx.ESP_MODULE_PANIER_CLASSE_SAISO
                              from mo in ctx.ESP_MODULE

                              where
                              cl.ANNEE_DEB.Equals("2013") &&
                              mo.UP.Equals("UP_TELECOM") && cl.CODE_MODULE == mo.CODE_MODULE
                              && cl.CODE_CL.Equals(idclasse)
                              && cl.NUM_SEMESTRE == 1
                              // && cl.ID_ENS.Equals(p.ID_ENS)





                              select new Class1
                              {

                                  CODE_CL = cl.CODE_CL,
                                  NOM_ENS = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS select c.NOM_ENS).FirstOrDefault(),
                                  NOM_ENS2 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS2 select c.NOM_ENS).FirstOrDefault(),
                                  NOM_ENS3 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS3 select c.NOM_ENS).FirstOrDefault(),
                                  NOM_ENS4 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS4 select c.NOM_ENS).FirstOrDefault(),
                                  NOM_ENS5 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS5 select c.NOM_ENS).FirstOrDefault()
                               ,
                                  TYPE_EPREUVE = (string)(from p in ctx.CODE_NOMENCLATURE where p.CODE_NOME == cl.TYPE_EPREUVE select p.LIB_NOME).FirstOrDefault(),
                                  CODE_UE = cl.CODE_UE,
                                  ID_ENS2 = cl.ID_ENS2,
                                  ID_ENS3 = cl.ID_ENS3,
                                  ID_ENS4 = cl.ID_ENS4,
                                  ID_ENS5 = cl.ID_ENS5,
                                  CODE_MODULE = cl.CODE_MODULE,
                                  ID_ENS = cl.ID_ENS,
                                  DESIGNATION = mo.DESIGNATION,
                                  NB_HEURES = (decimal)cl.NB_HEURES,
                                  CHARGE_P1 = (decimal)cl.CHARGE_P1,
                                  CHARGE_P2 = (decimal)cl.CHARGE_P2,
                                  CHARGE_ENS1_P1 = (decimal)cl.CHARGE_ENS1_P1,
                                  CHARGE_ENS1_P2 = (decimal)cl.CHARGE_ENS1_P2,
                                  //TYPE_EPREUVE = cl.TYPE_EPREUVE
                              }
                              ).Distinct().OrderByDescending(cl => cl.CODE_MODULE).ToList();
                return req;
            }
        }
        public string gettypeep(string codemodule, string codecl)
        {
            using (Entities ctx = new Entities())
            {
                var req = (
                                from cl in ctx.ESP_MODULE_PANIER_CLASSE_SAISO
                              where
                          cl.ANNEE_DEB.Equals("2014") &&
                          cl.CODE_MODULE.Equals(codemodule)
                              && cl.CODE_CL.Equals(codecl)
                              && cl.NUM_SEMESTRE == 1

                               
                                select (
                                         cl.TYPE_EPREUVE
                                         )).FirstOrDefault();
                return req;
            }
        }
        
        public List<Class1> getListClasse2(string idens,string anneedeb)
        {
            using (Entities ctx = new Entities())
            {
                var pp = ctx.ESP_ENSEIGNANT;
                var cll = ctx.ESP_MODULE_PANIER_CLASSE_SAISO;
                var moo = ctx.ESP_MODULE;
                var req = (from p in pp
                           from cl in cll
                           from mo in moo

                           where p.ID_ENS.Equals(idens) &&
                           cl.ANNEE_DEB.Equals(anneedeb) &&
                           mo.UP == p.UP &&
                           cl.CODE_MODULE == mo.CODE_MODULE
                           && cl.NUM_SEMESTRE == 1

                           select new Class1 { CODE_CL = cl.CODE_CL }).Distinct().OrderByDescending(cl => cl.CODE_CL).ToList();
                return req;
            }
        }
       //,CHARGE_ENS2_P1=(decimal)cl.CHARGE_ENS2_P1,CHARGE_ENS2_P2=(decimal)cl.CHARGE_ENS2_P2,
       //                     CHARGE_ENS3_P1=(decimal)cl.CHARGE_ENS3_P1,CHARGE_ENS3_P2=(decimal)cl.CHARGE_ENS3_P2,CHARGE_ENS4_P1=(decimal)cl.CHARGE_ENS4_P1,CHARGE_ENS4_P2=(decimal)cl.CHARGE_ENS4_P2,
       //                     CHARGE_ENS5_P1=(decimal)cl.CHARGE_ENS5_P1,  CHARGE_ENS5_P2=(decimal)cl.CHARGE_ENS5_P2
       //                    }
        public  List<Class1> getListAfectation(string idclasse)
        {
             
            using (Entities ctx = new Entities())
            {
             var req = (//from p in ctx.ESP_ENSEIGNANT
                           from cl in ctx.ESP_MODULE_PANIER_CLASSE_SAISO
                           from mo in ctx.ESP_MODULE
                        from ty in ctx.CODE_NOMENCLATURE
                      
                           where
                           cl.ANNEE_DEB.Equals("2014") &&
                           mo.UP.Equals("UP_TELECOM") && cl.CODE_MODULE == mo.CODE_MODULE
                           && cl.CODE_CL.Equals(idclasse)
                           && cl.NUM_SEMESTRE == 1
                           // && cl.ID_ENS.Equals(p.ID_ENS)
                           
                            && cl.TYPE_EPREUVE.Equals(ty.CODE_NOME)&& ty.CODE_STR.Equals("78")
                              
                       
                        
                          
                        select new Class1
                           {

                               CODE_CL = cl.CODE_CL,
                               NOM_ENS = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS select c.NOM_ENS).FirstOrDefault(),
                               NOM_ENS2 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS2 select c.NOM_ENS).FirstOrDefault(),
                               NOM_ENS3 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS3 select c.NOM_ENS).FirstOrDefault(),
                               NOM_ENS4 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS4 select c.NOM_ENS).FirstOrDefault(),
                               NOM_ENS5 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS5 select c.NOM_ENS).FirstOrDefault()
                            ,CODE_UE=cl.CODE_UE,ID_ENS2=cl.ID_ENS2,ID_ENS3=cl.ID_ENS3,ID_ENS4=cl.ID_ENS4,ID_ENS5=cl.ID_ENS5, 
                            CODE_MODULE = cl.CODE_MODULE,ID_ENS =cl.ID_ENS,  DESIGNATION = mo.DESIGNATION ,NB_HEURES=(decimal)cl.NB_HEURES,CHARGE_P1=(decimal)cl.CHARGE_P1,
                            CHARGE_P2=(decimal)cl.CHARGE_P2,CHARGE_ENS1_P1=(decimal)cl.CHARGE_ENS1_P1,CHARGE_ENS1_P2=(decimal)cl.CHARGE_ENS1_P2 ,TYPE_EPREUVE=ty.LIB_NOME}
                           ).Distinct().OrderByDescending(cl => cl.CODE_MODULE).ToList();
                return req;
            }
        }
        public List<Class1> getListAfectation2(string idclasse,string anneedeb,string up)
        {

            using (Entities ctx = new Entities())
            {
                var req = (//from p in ctx.ESP_ENSEIGNANT
                              from cl in ctx.ESP_MODULE_PANIER_CLASSE_SAISO
                              from mo in ctx.ESP_MODULE
                              from ty in ctx.CODE_NOMENCLATURE

                              where
                              cl.ANNEE_DEB.Equals(anneedeb) &&
                              mo.UP.Equals(up) && cl.CODE_MODULE == mo.CODE_MODULE
                              && cl.CODE_CL.Equals(idclasse)
                              && cl.NUM_SEMESTRE == 1
                                  // && cl.ID_ENS.Equals(p.ID_ENS)

                               && cl.TYPE_EPREUVE.Equals(ty.CODE_NOME) && ty.CODE_STR.Equals("78")




                              select new Class1
                              {

                                  CODE_CL = cl.CODE_CL,
                                  NOM_ENS = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS select c.NOM_ENS).FirstOrDefault(),
                                  NOM_ENS2 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS2 select c.NOM_ENS).FirstOrDefault(),
                                  NOM_ENS3 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS3 select c.NOM_ENS).FirstOrDefault(),
                                  NOM_ENS4 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS4 select c.NOM_ENS).FirstOrDefault(),
                                  NOM_ENS5 = (string)(from c in ctx.ESP_ENSEIGNANT where c.ID_ENS == cl.ID_ENS5 select c.NOM_ENS).FirstOrDefault()
                               ,
                                  CODE_UE = cl.CODE_UE,
                                  ID_ENS2 = cl.ID_ENS2,
                                  ID_ENS3 = cl.ID_ENS3,
                                  ID_ENS4 = cl.ID_ENS4,
                                  ID_ENS5 = cl.ID_ENS5,
                                  CODE_MODULE = cl.CODE_MODULE,
                                  ID_ENS = cl.ID_ENS,
                                  DESIGNATION = mo.DESIGNATION,
                                  NB_HEURES = (decimal)cl.NB_HEURES,
                                  CHARGE_P1 = (decimal)cl.CHARGE_P1,
                                  CHARGE_P2 = (decimal)cl.CHARGE_P2,
                                  CHARGE_ENS1_P1 = (decimal)cl.CHARGE_ENS1_P1,
                                  CHARGE_ENS1_P2 = (decimal)cl.CHARGE_ENS1_P2,
                                  TYPE_EPREUVE = ty.LIB_NOME
                              }
                              ).Distinct().OrderByDescending(cl => cl.CODE_MODULE).ToList();
                return req;
            }
        }

        public string getens1(string codemodule,string codecl)
        {
            using (Entities ctx = new Entities())
            {
                var req = (
                                from cl in ctx.ESP_MODULE_PANIER_CLASSE_SAISO
                                from c in ctx.ESP_ENSEIGNANT
                                where
                          cl.ANNEE_DEB.Equals("2014") &&
                          cl.CODE_MODULE.Equals(codemodule)
                              && cl.CODE_CL.Equals(codecl)
                              && cl.NUM_SEMESTRE == 1

                              && c.ID_ENS == cl.ID_ENS
                                select (
                                         cl.ID_ENS
                                         )).FirstOrDefault();
                return req;
            }
        }
        public string getens2(string codemodule, string codecl)
        {
            using (Entities ctx = new Entities())
            {
                var req = (
                                from cl in ctx.ESP_MODULE_PANIER_CLASSE_SAISO
                                from c in ctx.ESP_ENSEIGNANT
                                where
                          cl.ANNEE_DEB.Equals("2014") &&
                          cl.CODE_MODULE.Equals(codemodule)
                              && cl.CODE_CL.Equals(codecl)
                              && cl.NUM_SEMESTRE == 1

                              && c.ID_ENS == cl.ID_ENS2
                                select (
                                         cl.ID_ENS2
                                         )).FirstOrDefault();
                return req;
            }
        }
        public string getens3(string codemodule, string codecl)
        {
            using (Entities ctx = new Entities())
            {
                var req = (
                                from cl in ctx.ESP_MODULE_PANIER_CLASSE_SAISO
                                from c in ctx.ESP_ENSEIGNANT
                                where
                          cl.ANNEE_DEB.Equals("2014") &&
                          cl.CODE_MODULE.Equals(codemodule)
                              && cl.CODE_CL.Equals(codecl)
                              && cl.NUM_SEMESTRE == 1

                              && c.ID_ENS == cl.ID_ENS3
                                select (
                                         cl.ID_ENS3
                                         )).FirstOrDefault();
                return req;
            }
        }
        public string getens4(string codemodule, string codecl)
        {
            using (Entities ctx = new Entities())
            {
                var req = (
                                from cl in ctx.ESP_MODULE_PANIER_CLASSE_SAISO
                                from c in ctx.ESP_ENSEIGNANT
                                where
                          cl.ANNEE_DEB.Equals("2014") &&
                          cl.CODE_MODULE.Equals(codemodule)
                              && cl.CODE_CL.Equals(codecl)
                              && cl.NUM_SEMESTRE == 1

                              && c.ID_ENS == cl.ID_ENS4
                                select (
                                         cl.ID_ENS4
                                         )).FirstOrDefault();
                return req;
            }
        }
        public string getens5(string codemodule, string codecl)
        {
            using (Entities ctx = new Entities())
            {
                var req = (
                                from cl in ctx.ESP_MODULE_PANIER_CLASSE_SAISO
                                from c in ctx.ESP_ENSEIGNANT
                                where
                          cl.ANNEE_DEB.Equals("2014") &&
                          cl.CODE_MODULE.Equals(codemodule)
                              && cl.CODE_CL.Equals(codecl)
                              && cl.NUM_SEMESTRE == 1

                              && c.ID_ENS == cl.ID_ENS5
                                select (
                                         cl.ID_ENS5
                                         )).FirstOrDefault();
                return req;
            }
        }
        public List<ESP_ENSEIGNANT> getListEnseignant()
        {
            using (Entities ctx = new Entities())
            {
                var req = (from ens in ctx.ESP_ENSEIGNANT
                           where ens.ETAT.Equals("A")
                           select ens).Distinct().OrderBy(ens => ens.NOM_ENS).ToList();
                return req;
            }
        }
         

         
        public void getListClass2(string idens,string anneedeb)
        {
            using (Entities ctx = new Entities())
            {
                var req = (from p in ctx.ESP_ENSEIGNANT
                           from cl in ctx.ESP_MODULE_PANIER_CLASSE_SAISO
                           from mo in ctx.ESP_MODULE

                           where p.ID_ENS.Equals(idens) &&
                           cl.ANNEE_DEB.Equals(anneedeb) &&
                           mo.UP == p.UP &&
                           cl.CODE_MODULE == mo.CODE_MODULE
                           orderby (cl.CODE_CL) ascending

                           select cl.CODE_CL).Distinct().ToList();
            }
        }
         
        
    }
}
