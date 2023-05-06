using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
namespace BLL
{
  public   class Resultatectservice
    {
      ResctsDAO dao = ResctsDAO.Instance;
      public string getanneedebb()
      {
        return  dao.getanneedebb( );
      }
        
           public string Getnbects(string _Id_et)
           {
           return    dao.Getnbects(_Id_et);
                }
           public string GetMoy_Gen(string _Id_et, string annee)
           {
               return dao.GetMoy_Gen(_Id_et, annee);
           }
           public string GetLib_deci(string _Id_et, string annee)
           {
               return dao.GetLib_deci(_Id_et, annee);
           }
           public List<ResctsDAO> GetResFinal(string _Id_et, string annee)
      {
          return dao.GetResFinal(_Id_et, annee);
           }
           public string getlcodecl(string _Id_et, string annee)
           {
               return dao.getlcodecl(_Id_et, annee);
           }
           public string getTypepv(string code_cl, string annee)
           {
               return dao.getTypepv(code_cl, annee);
           }
           public string getMoyRat(string _Id_et, string annee)
           {
               return dao.getMoyRat(_Id_et, annee);
           }
           public string getDecisionRat(string _Id_et, string annee)
           {
               return dao.getDecisionRat(_Id_et, annee);
           }
           public string getCodeDecisionRat(string _Id_et, string annee)
      {
          return dao.getCodeDecisionRat(_Id_et, annee);
           }
           public bool verifredouble(string id_et)
           {
               return dao.verifredouble(id_et);
           }
           public DataTable getUE(string _Id_et, string annee)
           {
              return dao.getUE(_Id_et,   annee);
           }
    }
}
