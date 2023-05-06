using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class COMPT_CERTDAO
    {
         #region sing
        static COMPT_CERTDAO instance;
        static Object locker = new Object();
        public static COMPT_CERTDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new COMPT_CERTDAO();
                    }

                    return COMPT_CERTDAO.instance;
                }
            }

        }

        private COMPT_CERTDAO() { }
        #endregion sing

        #region crud
        public void ajouterCOMPT_CERT(COMPT_CERT rec)
        {
            using (Entities ec = new Entities())
            {
                ec.COMPT_CERT.AddObject(rec);
                ec.SaveChanges();
            }
        }
        public void modifierESP_COMPT_CERT(COMPT_CERT rec)
        {
            using (Entities ec = new Entities())
            {
                COMPT_CERT re = ec.COMPT_CERT.Single(p => p.CPT == rec.CPT);
                re.HEURE = rec.HEURE;
                re.CPT = rec.CPT;
                ec.SaveChanges();
            }
        }
        public void supprimerESP_COMPT_CERT(COMPT_CERT rec)
        {
            using (Entities ec = new Entities())
            {
                ec.COMPT_CERT.DeleteObject(rec);
                ec.SaveChanges();
            }
        }
        public List<COMPT_CERT> listerCOMPT_CERT()
        {
            using (Entities ec = new Entities())
            {
                return ec.COMPT_CERT.ToList<COMPT_CERT>();

            }
        }

        public List<COMPT_CERT> listerheureCOMPT_CERT()
        {
            using (Entities ec = new Entities())
            {
                return ec.COMPT_CERT.ToList<COMPT_CERT>();

            }
        }
            public List<COMPT_CERT> listerCPTCOMPT_CERT()
        {
            using (Entities ec = new Entities())
            {
                return ec.COMPT_CERT.ToList<COMPT_CERT>();

            }
        }

#endregion
    }
}
