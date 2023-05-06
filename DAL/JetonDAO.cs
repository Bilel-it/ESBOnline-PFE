using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;

namespace DAL
{
    public class JetonDAO
    {
        #region sing
        static JetonDAO instance;
        static Object locker = new Object();
        public static JetonDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new JetonDAO();
                    }

                    return JetonDAO.instance;
                }
            }

        }

        private JetonDAO() { }
        #endregion sing

        #region crud
        public void ajouterJETON(JETON rec)
        {
            using (Entities ec = new Entities())
            {
                ec.JETONs.AddObject(rec);
                ec.SaveChanges();
            }
        }

        public void modifierJETON(JETON rec)
        {
            using (Entities ec = new Entities())
            {
                JETON re = ec.JETONs.Single(p => p.ID_JETON == rec.ID_JETON);
                re.NOM_JETON = rec.NOM_JETON;

                ec.SaveChanges();
            }
        }

        public void supprimerJETON(JETON rec)
        {
            using (Entities ec = new Entities())
            {
                ec.JETONs.DeleteObject(rec);
                ec.SaveChanges();
            }
        }

        public List<JETON> listerJETON()
        {
            using (Entities ec = new Entities())
            {
                return ec.JETONs.ToList<JETON>();

            }
        }



        #endregion
    }
}

