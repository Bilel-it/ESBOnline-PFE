using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Collections;

namespace DAL
{
  public class EnteteDAO
    {
        #region sing
        static EnteteDAO instance;
        static Object locker = new Object();
        public static EnteteDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new EnteteDAO();
                    }

                    return EnteteDAO.instance;
                }
            }

        }

        private EnteteDAO() { }
        #endregion sing

        #region crud

        public bool ajouterESP_INSCRI(ESP_INSCRI rec, string id_et)
        {
            using (Entities ec = new Entities())
            {
                var req = (from p in ec.ESP_INSCRI where p.ID_ET == id_et && p.TYPE_CCNA=="1" select p.ID_ET).Count();
                if (int.Parse((req).ToString()) > 0)
                {
                    return false;
                }
                else
                {
                    ec.ESP_INSCRI.AddObject(rec);
                    ec.SaveChanges();
                    return true;
                }
            }
        }
        public bool ajouterESP_ccna4(ESP_INSCRI rec, string id_et)
        {
            using (Entities ec = new Entities())
            {
                var req = (from p in ec.ESP_INSCRI where p.ID_ET == id_et && p.TYPE_CCNA=="4" select p.ID_ET).Count();
                if (int.Parse((req).ToString()) > 0)
                {
                    return false;
                }
                else
                {
                    ec.ESP_INSCRI.AddObject(rec);
                    ec.SaveChanges();
                    return true;
                }
            }
        }
        public bool ajouterESP_CCNA3(ESP_CCNA3 rec, string id_et)
        {
            using (Entities ec = new Entities())
            {
                var req = (from p in ec.ESP_CCNA3 where p.ID_ET == id_et select p.ID_ET).Count();
                if (int.Parse((req).ToString())>2)
                {
                    return false;
                }
                else
                {
                    ec.ESP_CCNA3.AddObject(rec);
                    ec.SaveChanges();
                    return true;
                }
            }
        }
      

        public void modifierESP_CCNA3(ESP_CCNA3 rec)
        {
            using (Entities ec = new Entities())
            {
                ESP_CCNA3 re = ec.ESP_CCNA3.Single(p => p.NOM_JETON == rec.NOM_JETON);
                re.NOM_ET = rec.NOM_ET;
                re.PRENOM_ET = rec.PRENOM_ET;
                re.ADRESSE_ET = rec.ADRESSE_ET;
                re.DATE_MISEJOUR = rec.DATE_MISEJOUR;
                re.DATE_INS = rec.DATE_INS;
                re.HEURE_INS = rec.HEURE_INS;
             
                ec.SaveChanges();
            }
        }

        public void supprimerESP_CCNA3(ESP_CCNA3 rec)
        {
            using (Entities ec = new Entities())
            {
                ec.ESP_CCNA3.DeleteObject(rec);
                ec.SaveChanges();
            }
        }

        public List<ESP_CCNA3> listerESP_CCNA3()
        {
            using (Entities ec = new Entities())
            {
                return ec.ESP_CCNA3.ToList<ESP_CCNA3>();

            }
        }
        public List<ESP_CCNA3> listerRESP_CCNA3Pardate()
        {
            using (Entities ec = new Entities())
            {
                return ec.ESP_CCNA3.ToList<ESP_CCNA3>();

            }
        }







        public List<ESP_CCNA3> listerDATE_INS()
        {
            using (Entities ec = new Entities())
            {
                return ec.ESP_CCNA3.ToList<ESP_CCNA3>();

            }
        }

        public List<ESP_CCNA3> listerPRENOM_ET()
        {
            using (Entities ec = new Entities())
            {
                return ec.ESP_CCNA3.ToList<ESP_CCNA3>();

            }
        }
        public List<ESP_CCNA3> listerNOM_ET()
        {
            using (Entities ec = new Entities())
            {
                return ec.ESP_CCNA3.ToList<ESP_CCNA3>();

            }
        }
        public List<ESP_CCNA3> listerESP_CCNA3Parcount()
        {
            using (Entities ec = new Entities())
            {
                return ec.ESP_CCNA3.ToList<ESP_CCNA3>();

            }
        }
        public class dateconv
        { 
           public string hr;
            public string dt;
        
        }
        public static int getcountinscri(string dateins, string hrd)
        {
            using (Entities ec = new Entities())
            {
                var custQuery = (from c in ec.ESP_INSCRI

                                 select c).AsEnumerable();
                IEnumerable<dateconv> result = (from c in custQuery
                                                select new dateconv
                                                {
                                                    hr = (c.HEURE_INS),

                                                    dt = (c.DATE_INS.ToString().Substring(0, 10))


                                                }
                                              );


                var cunt = (from x in result where x.hr == hrd && x.dt == dateins select x).ToList();
                return cunt.Count();
            }
        }
        //public static int getcountinscri(string dateins, string hrd)
        //{
        //    using (Entities ec = new Entities())
        //    {
        //        var custQuery = (from c in ec.ESP_CCNA3
                                             
        //                                     select c).AsEnumerable();
        //      IEnumerable<dateconv> result = (from c in custQuery
        //                              select new dateconv
        //                                    {
        //                                       hr= (c.HEURE_INS),
                                               
        //                                       dt = (c.DATE_INS.ToString().Substring(0,10))
                                               
                                               
        //                                    }
        //                                    );


        //      var cunt = (from x in result where x.hr == hrd && x.dt == dateins select x).ToList();
        //      return cunt.Count();
        //    }
        //}
    
    
        #endregion
    }
}

