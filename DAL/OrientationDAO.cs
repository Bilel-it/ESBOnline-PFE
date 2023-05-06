using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public class OrientationDAO
    {
       public static string getTypepv(string anneedeb, string codecl)
       {
           using (Entities ctx = new Entities())
           {
               var req = (from p in ctx.ESP_SAISON_CLASSE
                          where p.CODE_CL == codecl && p.ANNEE_DEB == anneedeb

                          select p.TYPE_PV).Single().ToString();

               return req.ToString();
           }
       }
       
       public static string getCodeDecisionRat(string idet, string anneedeb)
       {
           using (Entities ctx = new Entities())
           {
               var req = (from p in ctx.ESP_INSCRIPTION
                          where p.ID_ET == idet && p.ANNEE_DEB == anneedeb

                          select p.CODE_DECISION_SESSION_RAT).First();

               return req;
           }
       }
       public static string getMoyRat(string idet, string anneedeb)
       {
           using (Entities ctx = new Entities())
           {
               var req = (from p in ctx.ESP_INSCRIPTION
                          where p.ID_ET == idet && p.ANNEE_DEB == anneedeb

                          select p.MOY_RATT).First();
               string tt = req.ToString();

               return tt;
           }
       }
       public static string getlcodecl(string idet,string anneedeb)
       {
           using (Entities ctx = new Entities())
           {
               var req = (from p in ctx.ESP_INSCRIPTION
                         where p.ID_ET == idet && p.ANNEE_DEB==anneedeb

                         select p.CODE_CL).Single().ToString();

               return req.ToString();
           }
       }
       public static string getDecisionRat(string idet, string anneedeb)
       {
           using (Entities ctx = new Entities())
           {
               var req = (from p in ctx.ESP_INSCRIPTION
                          where p.ID_ET == idet && p.ANNEE_DEB == anneedeb

                          select p.LIB_DECISION_SESSION_RAT).FirstOrDefault();

               return req;
           }
       }
       public static string getcodeDecisionPrin(string idet, string anneedeb)
       {
           using (Entities ctx = new Entities())
           {
               var req = (from p in ctx.ESP_INSCRIPTION
                          where p.ID_ET == idet && p.ANNEE_DEB == anneedeb

                          select p.CODE_DECISION_SESSION_P).First();

               return req;
           }
       }
       public static decimal getsumnbects(string idet, string anneedeb)
       {
           //using (Entities ctx = new Entities())
           //{
           //    var req = (from p in ctx.ESP_V_MOY_UE_ETUDIANT
           //               where p.ID_ET == idet && p.ANNEE_DEB == anneedeb && p.TYPE_MOY == "R" && p.MOYENNE >= 8

           //               select p.NB_ECTS.Value).Sum();

           //    return req;
           //}
           return '0';
       }

       public static decimal getsumnbects2(string idet, string anneedeb)
       {
           //using (Entities ctx = new Entities())
           //{
           //    var req = (from p in ctx.ESP_V_MOY_UE_ETUDIANT
           //               where p.ID_ET == idet && p.ANNEE_DEB == anneedeb && p.TYPE_MOY == "R" && p.MOYENNE >= 10

           //               select p.NB_ECTS.Value).DefaultIfEmpty(0).Sum();

           //    return req;
           //}
           return '0';
       }

       public bool addorient(DAL.ESP_ORIENTATION esorientation)
       {
           using (Entities ctx = new Entities())
           {
               ctx.ESP_ORIENTATION.AddObject(esorientation);

               if(ctx.SaveChanges()>0)
               { return true;}
               else
               {
                   return false;
               }

             
               

              
           }
       }


       public  bool veriforientation(string idet,string anneedeb)
       {
           using (Entities ctx = new Entities())
           {
               var req = (from p in ctx.ESP_ORIENTATION
                          where p.ID_ET == idet && p.ANNEE_DEB == anneedeb

                          select p).Count();
               if (req > 0)
               { return true; }
               else return false;

               
           }

       }

       public  List<ESP_ORIENTATION> getlistchoix(string idet, string anneedeb)
       {
           using (Entities ctx = new Entities())
           {
               var req = (from p in ctx.ESP_ORIENTATION
                          where p.ID_ET == idet && p.ANNEE_DEB == anneedeb

                          select p).ToList();

               return req.ToList();


           }
       }

       public   bool deleteorient(string idet, string anneedeb)
       {
           using (Entities ctx = new Entities())
           {
               var req = (from p in ctx.ESP_ORIENTATION
                          where p.ID_ET == idet && p.ANNEE_DEB == anneedeb

                          select p).Single();
               ctx.DeleteObject(req);
               if (ctx.SaveChanges() > 0)
               { return true; }
               else return false;


           }
       }
    }
}
