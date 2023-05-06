using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ReclamationDAO
    {
        #region sing
        static ReclamationDAO instance;
        static Object locker = new Object();
        public static ReclamationDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ReclamationDAO();
                    }

                    return ReclamationDAO.instance;
                }
            }

        }

        private ReclamationDAO() { }
        #endregion sing

        #region crud
        public void ajouterReclamation(RECLAMATIONN rec)
        {
            using (Entities ec = new Entities())
            {
                ec.RECLAMATIONNs.AddObject(rec);
                ec.SaveChanges();
            }
        }

        public void modifierReclamation(RECLAMATIONN rec)
        {
            using (Entities ec = new Entities())
            {
                RECLAMATIONN re = ec.RECLAMATIONNs.Single(p => p.ID_RECLAMTION == rec.ID_RECLAMTION);
                re.TRAITER = rec.TRAITER;
                re.DATE_TRAITEMENT = rec.DATE_TRAITEMENT;
                re.DESCRIPTION = rec.DESCRIPTION;
                re.UTILISATEUR = rec.UTILISATEUR;
                re.NOM_ENS = rec.NOM_ENS;
                
                ec.SaveChanges();
            }
        }


        public void supprimerReclamation(RECLAMATIONN rec)
        {
            using (Entities ec = new Entities())
            {
                ec.RECLAMATIONNs.DeleteObject(rec);
                ec.SaveChanges();
            }
        }

        public List<RECLAMATIONN> listerReclamation()
        {
            using (Entities ec = new Entities())
            {
                return ec.RECLAMATIONNs.ToList<RECLAMATIONN>();

            }
        }

        public List<RECLAMATIONN> listerTypeReclamation()
        {
            using (Entities ec = new Entities())
            {
                return ec.RECLAMATIONNs.ToList<RECLAMATIONN>();

            }
        }
        public List<RECLAMATIONN> listerType_Reclamation()
        {
            using (Entities ec = new Entities())
            {
                return ec.RECLAMATIONNs.ToList<RECLAMATIONN>();

            }
        }




        public class dateconv
        {
        
            public string dt;
      

        }
        public static int getcountinscri(string dateins)
        {
            using (Entities ec = new Entities())
            {
                var custQuery = (from c in ec.RECLAMATIONNs

                                 select c).AsEnumerable();
                IEnumerable<dateconv> result = (from c in custQuery
                                                select new dateconv
                                                {
                                                

                                                    dt = (c.DATE_TRAITEMENT.ToString())


                                                }
                                              );


                var cunt = (from x in result where  x.dt == dateins select x).ToList();
                return cunt.Count();
            }
        }
        #endregion
    }
}

