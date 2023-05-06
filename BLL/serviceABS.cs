using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
   public class serviceABS
    {
       AbsenceDAO dao = AbsenceDAO.Instance;
       DataTable dt = new DataTable();

       public DataTable bind_listetud()
       { 
       dt=dao.bind_listetud();
       return dt;

       }

       public string get_NAMES(string id_et)
       {
           return dao.get_NAMES(id_et);
       }

       public string get_LIBjUSTIF(string CODE_NOME)
       {

           return dao.get_LIBjUSTIF(CODE_NOME);
       }


        public string getANNEEDEBs()
        {
            return dao.getANNEEDEBs();
        }


        public string getAnneeFiN()
        {
            return dao.getAnneeFiN();
        }
        public DataTable bind_dataetudabs(string _id_etud)
       {
           dt = dao.bind_dataetudabs(_id_etud);
           return dt;
       }

       public string get_ETUD(string NOM)
       { 
         return dao.get_ETUD(NOM);
       }


       public DataTable bind_dataetudabsBYmodule(string _code_module)
       {
           dt = dao.bind_dataetudabsBYmodule(_code_module);
           return dt;
       }

       public DataTable bind_Module()
       {
           dt = dao.bind_Module();
           return dt;
       
       }

       public DataTable bind_justif()
       {
           dt = dao.bind_justif();
           return dt;
       }

       public int Enreg_abs(string id_et, string lib_justif,  string num_seance, DateTime date_seance,string cd)
       { 
         return dao.Enreg_abs(id_et,lib_justif,num_seance,date_seance,cd);
       }

       public string get_module(string code_module)
       {
           return dao.get_module(code_module);
       }
    }
}
