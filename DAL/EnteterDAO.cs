using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;

namespace DAL
{
    public class EnteterDAO
    {
        #region sing
        static EnteterDAO instance;
        static Object locker = new Object();
        public static EnteterDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new EnteterDAO();
                    }

                    return EnteterDAO.instance;
                }
            }

        }

        private EnteterDAO() { }
        #endregion sing

        #region crud
        public void ajouterEntete_Reclamation(ENTETE_RECLAMATION rec)
        {
            using (Entities ec = new Entities())
            {
                ec.ENTETE_RECLAMATION.AddObject(rec);
                ec.SaveChanges();
            }
        }

        public void modifierEntete_Reclamation(ENTETE_RECLAMATION rec)
        {
            using (Entities ec = new Entities())
            {
                ENTETE_RECLAMATION re = ec.ENTETE_RECLAMATION.Single(p => p.ID_ENTETE_RECLAMATION == rec.ID_ENTETE_RECLAMATION);
                re.NOM_ENS = rec.NOM_ENS;
                re.TYPE_RECLAMATION = rec.TYPE_RECLAMATION;
                re.DATE_RECLAMATION = rec.DATE_RECLAMATION;
                re.DESIGNATION = rec.DESIGNATION;
                re.ID_ENS = rec.ID_ENS;


                ec.SaveChanges();
            }
        }

        public void supprimerEntete_Reclamation(ENTETE_RECLAMATION rec)
        {
            using (Entities ec = new Entities())
            {
                ec.ENTETE_RECLAMATION.DeleteObject(rec);
                ec.SaveChanges();
            }
        }

        public List<ENTETE_RECLAMATION> listerEntete_Reclamation()
        {
            using (Entities ec = new Entities())
            {
                return ec.ENTETE_RECLAMATION.ToList<ENTETE_RECLAMATION>();

            }
        }

        public List<ENTETE_RECLAMATION> listerTypeEntete_Reclamation()
        {
            using (Entities ec = new Entities())
            {
                return ec.ENTETE_RECLAMATION.ToList<ENTETE_RECLAMATION>();

            }
        }


        #endregion
    }
}


