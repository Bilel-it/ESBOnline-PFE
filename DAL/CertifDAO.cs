using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Collections;

namespace DAL
{
    public class CertifDAO
    {
        #region sing
        static CertifDAO instance;
        static Object locker = new Object();
        public static CertifDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new CertifDAO();
                    }

                    return CertifDAO.instance;
                }
            }

        }

        private CertifDAO() { }
        #endregion sing

        #region crud


        public bool ajouterESP_CERTIF(ESP_CERTIF rec, string id_et)
        {
            using (Entities ec = new Entities())
            {
                var req = (from p in ec.ESP_CERTIF where p.ID_ET == id_et select p.ID_ET).Count();
                if (int.Parse((req).ToString()) > 0)
                {
                    return false;
                }
                else
                {
                    ec.ESP_CERTIF.AddObject(rec);
                    ec.SaveChanges();
                    return true;
                }
            }
        }
        //public bool ajouterESP_INSCRII(ESP_INSCRI rec, string nom_jeton)
        //{
        //    using (Entities ec = new Entities())
        //    {
        //        var req = (from c in ec.ESP_INSCRI where c.NOM_JETON == nom_jeton select c.NOM_JETON).Count();
        //        if (int.Parse((req).ToString()) > 0)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            ec.ESP_INSCRI.AddObject(rec);
        //            ec.SaveChanges();
        //            return true;
        //        }
        //    }
        //}

        public void modifierESP_CERTIF(ESP_CERTIF rec)
        {
            using (Entities ec = new Entities())
            {
                ESP_CERTIF re = ec.ESP_CERTIF.Single(p => p.NOM_JETON == rec.NOM_JETON);
                re.NOM_ET = rec.NOM_ET;
                re.PRENOM_ET = rec.PRENOM_ET;
                re.ADRESSE_ET = rec.ADRESSE_ET;
                re.DATE_MISEJOUR = rec.DATE_MISEJOUR;
                re.DATE_INS = rec.DATE_INS;
                re.HEURE_INS = rec.HEURE_INS;
                re.NOM_JETON = rec.NOM_JETON;
                re.CLASSE = rec.CLASSE;
                re.CODE_MODULE = rec.CODE_MODULE;
                re.NOTE_EXAM = rec.NOTE_EXAM;
                ec.SaveChanges();
            }
        }

        public void supprimerESP_CERTIF(ESP_CERTIF rec)
        {
            using (Entities ec = new Entities())
            {
                ec.ESP_CERTIF.DeleteObject(rec);
                ec.SaveChanges();
            }
        }

        public List<ESP_CERTIF> listerESP_CERTIF()
        {
            using (Entities ec = new Entities())
            {
                return ec.ESP_CERTIF.ToList<ESP_CERTIF>();

            }
        }
        public List<ESP_CERTIF> listerRESP_CERTIFPardate()
        {
            using (Entities ec = new Entities())
            {
                return ec.ESP_CERTIF.ToList<ESP_CERTIF>();

            }
        }







        public List<ESP_CERTIF> listerDATE_INS()
        {
            using (Entities ec = new Entities())
            {
                return ec.ESP_CERTIF.ToList<ESP_CERTIF>();

            }
        }

        public List<ESP_CERTIF> listerPRENOM_ET()
        {
            using (Entities ec = new Entities())
            {
                return ec.ESP_CERTIF.ToList<ESP_CERTIF>();

            }
        }
        public List<ESP_CERTIF> listerNOM_ET()
        {
            using (Entities ec = new Entities())
            {
                return ec.ESP_CERTIF.ToList<ESP_CERTIF>();

            }
        }
        public List<ESP_CERTIF> listerESP_CERTIFParcount()
        {
            using (Entities ec = new Entities())
            {
                return ec.ESP_CERTIF.ToList<ESP_CERTIF>();

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
                var custQuery = (from c in ec.ESP_CERTIF

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


        #endregion
    }
}
