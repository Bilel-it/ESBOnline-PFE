using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Oracle.ManagedDataAccess.Client;
using admiss;
namespace DAL
{
   public class StatDAO
    {
         #region sing

        static StatDAO instance;
        static Object locker = new Object();

        public static StatDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new StatDAO();
                    }

                    return StatDAO.instance;
                }
            }

        }
        private StatDAO() { }
        public StatDAO(OracleDataReader myReader)
        {


            if (!myReader.IsDBNull(myReader.GetOrdinal("code_cl")))
            {

                code_cl = myReader.GetString(myReader.GetOrdinal("code_cl"));
            }



            if (!myReader.IsDBNull(myReader.GetOrdinal("NB_PALIER1")))
            {

                code_cl = myReader.GetString(myReader.GetOrdinal("NB_PALIER1"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("NB_PALIER2")))
            {

                code_cl = myReader.GetString(myReader.GetOrdinal("NB_PALIER2"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("NB_PALIER3")))
            {

                code_cl = myReader.GetString(myReader.GetOrdinal("NB_PALIER3"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("NB_PALIER4")))
            {

                code_cl = myReader.GetString(myReader.GetOrdinal("NB_PALIER4"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("NB_PALIER5")))
            {

                code_cl = myReader.GetString(myReader.GetOrdinal("NB_PALIER5"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_MODULE")))
            {

                _CODE_MODULE = myReader.GetString(myReader.GetOrdinal("CODE_MODULE"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("DESIGNATION")))
            {

                _DESIGNATION = myReader.GetString(myReader.GetOrdinal("DESIGNATION"));
            }
        }
        #endregion

         #region getset

        private string _CODE_MODULE;

        public string CODE_MODULE
        {
            get { return _CODE_MODULE; }
            set { _CODE_MODULE = value; }
        }

        private string _DESIGNATION;

        public string DESIGNATION
        {
            get { return _DESIGNATION; }
            set { _DESIGNATION = value; }
        }
      
        private string code_cl;

        public string Code_cl
        {
            get { return code_cl; }
            set { code_cl = value; }
        }

        private string c_designation;

        public string C_designation
        {
            get { return c_designation; }
            set { c_designation = value; }
        }


        #endregion

        OracleConnection mySqlConnection = new OracleConnection();
        OracleTransaction myTrans;

        public void openconntrans()
        {
            mySqlConnection.Open();
            myTrans = mySqlConnection.BeginTransaction();

        }

        public void commicttrans()
        {
            myTrans.Commit();
        }

        public void rollbucktrans()
        {
            myTrans.Rollback();
        }
        public void closeConnection()
        {

            mySqlConnection.Close();


        }
        public DataTable GetListNotes(string CODE_CL, string CODE_MODULE,string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT ESP_EVALUATION.PT_FORT , ESP_EVALUATION.PT_FAIBLE , ESP_EVALUATION.PROPOSITION FROM ESP_EVALUATION , ESP_MODULE WHERE ( ESP_MODULE.CODE_MODULE = ESP_EVALUATION.CODE_MODULE ) and ( ( ESP_EVALUATION.ANNEE_DEB = '" +Annee+ "' ) And ( trim(ESP_EVALUATION.CODE_CL) ='" + CODE_CL + "' ) And ( trim(ESP_EVALUATION.CODE_MODULE) ='" + CODE_MODULE + "' ) ) ", mySqlConnection);
                DataTable myDataTable = new DataTable();

                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }


        public DataTable GetListNotes2(string CODE_CL, string CODE_MODULE, string ID_ENS, string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
               // adapter.SelectCommand = new OracleCommand("SELECT round((ESP_EVAL_CL_MODULE.NB_PALIER1/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_0, round((ESP_EVAL_CL_MODULE.NB_PALIER2/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_1, round((ESP_EVAL_CL_MODULE.NB_PALIER3/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_2, round((ESP_EVAL_CL_MODULE.NB_PALIER4/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_3,  round((ESP_EVAL_CL_MODULE.NB_PALIER5/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_4,   ESP_CRITERE_EVAL.LIB_CRITERE crit FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE,   ESP_ENSEIGNANT  WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  ( trim(ESP_EVAL_CL_MODULE.ID_ENS) = trim(ESP_ENSEIGNANT.ID_ENS )) and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' ) and ESP_ENSEIGNANT.ID_ENS='" + ID_ENS + "' and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "') AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0) and ESP_CRITERE_EVAL.LIB_CRITERE like 'Travail%' ", mySqlConnection);
                adapter.SelectCommand = new OracleCommand("SELECT round((ESP_EVAL_CL_MODULE.NB_PALIER1/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_0, round((ESP_EVAL_CL_MODULE.NB_PALIER2/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_1, round((ESP_EVAL_CL_MODULE.NB_PALIER3/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_2, round((ESP_EVAL_CL_MODULE.NB_PALIER4/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_3,  round((ESP_EVAL_CL_MODULE.NB_PALIER5/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_4,   ESP_CRITERE_EVAL.LIB_CRITERE crit FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE ))  and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' )  and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "') AND ( trim(ESP_INSCRIPTION.CODE_CL1) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0) and ESP_CRITERE_EVAL.LIB_CRITERE like 'Travail%' ", mySqlConnection);
                DataTable myDataTable = new DataTable();


                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }
        public DataTable GetListNotes22(string CODE_CL, string CODE_MODULE, string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT round((ESP_EVAL_CL_MODULE.NB_PALIER1/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_0, round((ESP_EVAL_CL_MODULE.NB_PALIER2/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_1, round((ESP_EVAL_CL_MODULE.NB_PALIER3/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_2, round((ESP_EVAL_CL_MODULE.NB_PALIER4/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_3,  round((ESP_EVAL_CL_MODULE.NB_PALIER5/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) heure_4,   ESP_CRITERE_EVAL.LIB_CRITERE crit FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE  WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE ))  and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' )  and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "') AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0) and ESP_CRITERE_EVAL.LIB_CRITERE like 'Travail%' ", mySqlConnection);
                DataTable myDataTable = new DataTable();


                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }


        public DataTable GetListNotes3(string CODE_CL, string CODE_MODULE, string ID_ENS, string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
              //  adapter.SelectCommand = new OracleCommand("SELECT ESP_EVAL_CL_MODULE.CODE_CL, round((ESP_EVAL_CL_MODULE.NB_PALIER1/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p1 , round((ESP_EVAL_CL_MODULE.NB_PALIER2/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p2 , round((ESP_EVAL_CL_MODULE.NB_PALIER3/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p3, round((ESP_EVAL_CL_MODULE.NB_PALIER4/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p4,  round((ESP_EVAL_CL_MODULE.NB_PALIER5/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p5, ( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5) c_nb_rep, ((SELECT count(*) FROM ESP_INSCRIPTION WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND  ( ESP_INSCRIPTION.CODE_CL = ESP_EVAL_CL_MODULE.CODE_CL))-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) NB_PALIER6    ,   ESP_CRITERE_EVAL.LIB_CRITERE, (SELECT count(*)  FROM ESP_INSCRIPTION   WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND   ( trim(ESP_INSCRIPTION.CODE_CL) = trim(ESP_EVAL_CL_MODULE.CODE_CL))) c_nb_et, ESP_MODULE.DESIGNATION, ESP_ENSEIGNANT.NOM_ENS,   ESP_EVAL_CL_MODULE.ID_ENS FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE,   ESP_ENSEIGNANT  WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  ( trim(ESP_EVAL_CL_MODULE.ID_ENS) = trim(ESP_ENSEIGNANT.ID_ENS )) and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' ) and ESP_ENSEIGNANT.ID_ENS='" + ID_ENS + "' and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%' and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0)", mySqlConnection);
                adapter.SelectCommand = new OracleCommand("SELECT ESP_EVAL_CL_MODULE.CODE_CL, round((ESP_EVAL_CL_MODULE.NB_PALIER1/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p1 , round((ESP_EVAL_CL_MODULE.NB_PALIER2/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p2 , round((ESP_EVAL_CL_MODULE.NB_PALIER3/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p3, round((ESP_EVAL_CL_MODULE.NB_PALIER4/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p4,  round((ESP_EVAL_CL_MODULE.NB_PALIER5/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p5, ( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5) c_nb_rep, ((SELECT count(*) FROM ESP_INSCRIPTION WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND  ( ESP_INSCRIPTION.CODE_CL1 = ESP_EVAL_CL_MODULE.CODE_CL))-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) NB_PALIER6    ,   ESP_CRITERE_EVAL.LIB_CRITERE, (SELECT count(*)  FROM ESP_INSCRIPTION   WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND   ( trim(ESP_INSCRIPTION.CODE_CL1) = trim(ESP_EVAL_CL_MODULE.CODE_CL))) c_nb_et, ESP_MODULE.DESIGNATION FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE  WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE ))  and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' ) and  ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%' and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND ( trim(ESP_INSCRIPTION.CODE_CL1) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0)", mySqlConnection);
                DataTable myDataTable = new DataTable();

                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }
        public DataTable GetListNotes33(string CODE_CL, string CODE_MODULE, string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT ESP_EVAL_CL_MODULE.CODE_CL, round((ESP_EVAL_CL_MODULE.NB_PALIER1/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p1 , round((ESP_EVAL_CL_MODULE.NB_PALIER2/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p2 , round((ESP_EVAL_CL_MODULE.NB_PALIER3/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p3, round((ESP_EVAL_CL_MODULE.NB_PALIER4/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p4,  round((ESP_EVAL_CL_MODULE.NB_PALIER5/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) p5, ( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5) c_nb_rep, ((SELECT count(*) FROM ESP_INSCRIPTION WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND  ( ESP_INSCRIPTION.CODE_CL = ESP_EVAL_CL_MODULE.CODE_CL))-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) NB_PALIER6    ,   ESP_CRITERE_EVAL.LIB_CRITERE, (SELECT count(*)  FROM ESP_INSCRIPTION   WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND   ( trim(ESP_INSCRIPTION.CODE_CL) = trim(ESP_EVAL_CL_MODULE.CODE_CL))) c_nb_et, ESP_MODULE.DESIGNATION, ESP_ENSEIGNANT.NOM_ENS,   ESP_EVAL_CL_MODULE.ID_ENS FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE,   ESP_ENSEIGNANT  WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  ( trim(ESP_EVAL_CL_MODULE.ID_ENS) = trim(ESP_ENSEIGNANT.ID_ENS )) and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' )  and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%' and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0)", mySqlConnection);
                DataTable myDataTable = new DataTable();

                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }

        public DataTable GetListNotes4(string CODE_CL, string CODE_MODULE, string ID_ENS, string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
               // adapter.SelectCommand = new OracleCommand("SELECT round((ESP_EVAL_CL_MODULE.NB_PALIER1/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) TI, round((ESP_EVAL_CL_MODULE.NB_PALIER2/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) I, round((ESP_EVAL_CL_MODULE.NB_PALIER3/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) S, round((ESP_EVAL_CL_MODULE.NB_PALIER4/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) B,  round((ESP_EVAL_CL_MODULE.NB_PALIER5/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) TB,   ESP_CRITERE_EVAL.LIB_CRITERE crit FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE,   ESP_ENSEIGNANT  WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  ( trim(ESP_EVAL_CL_MODULE.ID_ENS) = trim(ESP_ENSEIGNANT.ID_ENS )) and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' ) and ESP_ENSEIGNANT.ID_ENS='" + ID_ENS + "' and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0) and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%' ", mySqlConnection);
                adapter.SelectCommand = new OracleCommand("SELECT round((ESP_EVAL_CL_MODULE.NB_PALIER1/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) TI, round((ESP_EVAL_CL_MODULE.NB_PALIER2/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) I, round((ESP_EVAL_CL_MODULE.NB_PALIER3/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) S, round((ESP_EVAL_CL_MODULE.NB_PALIER4/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) B,  round((ESP_EVAL_CL_MODULE.NB_PALIER5/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) TB,   ESP_CRITERE_EVAL.LIB_CRITERE crit FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE  WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE ))  and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' )  and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND ( trim(ESP_INSCRIPTION.CODE_CL1) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0) and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%' ", mySqlConnection);
                
                DataTable myDataTable = new DataTable();


                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }
        public DataTable GetListNotes44(string CODE_CL, string CODE_MODULE, string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT round((ESP_EVAL_CL_MODULE.NB_PALIER1/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) TI, round((ESP_EVAL_CL_MODULE.NB_PALIER2/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) I, round((ESP_EVAL_CL_MODULE.NB_PALIER3/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) S, round((ESP_EVAL_CL_MODULE.NB_PALIER4/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) B,  round((ESP_EVAL_CL_MODULE.NB_PALIER5/(( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))),2) TB,   ESP_CRITERE_EVAL.LIB_CRITERE crit FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE,   ESP_ENSEIGNANT  WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE ))  and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' )  and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0) and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%' ", mySqlConnection);
                DataTable myDataTable = new DataTable();


                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }

        public DataTable GetListNotes5(string ID_ENS, string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand(" select DISTINCT CODE_CL from ESP_MODULE_PANIER_CLASSE_SAISO where ANNEE_DEB='" + Annee + "' and id_ens='"+ID_ENS+"' ", mySqlConnection);
                DataTable myDataTable = new DataTable();

                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }
        public DataTable GetListNotes55(string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand(" select DISTINCT CODE_CL from ESP_MODULE_PANIER_CLASSE_SAISO where ANNEE_DEB='" + Annee + "' and code_cl not like 'FU%' order by fn_tri_classe(code_cl) ", mySqlConnection);
                DataTable myDataTable = new DataTable();

                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }

        public DataTable GetListNotes6(string ID_ENS, string CODE_CL, string Annee)
        {



            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
               // adapter.SelectCommand = new OracleCommand("SELECT ESP_MODULE.CODE_MODULE, ESP_MODULE.DESIGNATION FROM ESP_MODULE_PANIER_CLASSE_SAISO INNER JOIN  ESP_ENSEIGNANT ON ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS = ESP_ENSEIGNANT.ID_ENS INNER JOIN  ESP_MODULE ON ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE = ESP_MODULE.CODE_MODULE WHERE (ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB ='" + Annee + "') AND (ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL = '" + CODE_CL + "') AND   (ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS = '" + ID_ENS + "' or ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS2 = '" + ID_ENS + "' or ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS3 = '" + ID_ENS + "' or ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS4 = '" + ID_ENS + "' or ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS5 = '" + ID_ENS + "') ", mySqlConnection);
                adapter.SelectCommand = new OracleCommand("SELECT e1.CODE_MODULE, e3.DESIGNATION FROM ESP_MODULE_PANIER_CLASSE_SAISO e1, esp_module e3 where annee_deb=2016 and  ID_ens='"+ID_ENS+"' and e1.CODE_MODULE=e3.code_module ", mySqlConnection);
                DataTable myDataTable = new DataTable();

                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }

        public DataTable GetListNotes66(string CODE_CL, string Annee)
        {



            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT ESP_MODULE.CODE_MODULE, ESP_MODULE.DESIGNATION FROM ESP_MODULE_PANIER_CLASSE_SAISO INNER JOIN  ESP_ENSEIGNANT ON ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS = ESP_ENSEIGNANT.ID_ENS INNER JOIN  ESP_MODULE ON ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE = ESP_MODULE.CODE_MODULE WHERE (ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB ='" + Annee + "') AND (ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL = '" + CODE_CL + "')  order by DESIGNATION ", mySqlConnection);
                DataTable myDataTable = new DataTable();

                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }

        public DataTable GetListNotes7(string CODE_CL, string CODE_MODULE, string ID_ENS, string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT ( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5) c_nb_rep FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE,   ESP_ENSEIGNANT  WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  ( trim(ESP_EVAL_CL_MODULE.ID_ENS) = trim(ESP_ENSEIGNANT.ID_ENS )) and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' ) and ESP_ENSEIGNANT.ID_ENS='" + ID_ENS + "' and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%' and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0) and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%'", mySqlConnection);
                DataTable myDataTable = new DataTable();

                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }

        public DataTable GetListNotes77(string CODE_CL, string CODE_MODULE, string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT ( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5) c_nb_rep FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE,   ESP_ENSEIGNANT  WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  ( trim(ESP_EVAL_CL_MODULE.ID_ENS) = trim(ESP_ENSEIGNANT.ID_ENS )) and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' )  and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%' and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0) and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%'", mySqlConnection);
                DataTable myDataTable = new DataTable();

                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }

        public DataTable GetListNotes8(string CODE_CL, string CODE_MODULE, string ID_ENS, string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT (SELECT count(*)  FROM ESP_INSCRIPTION   WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "') AND   ( trim(ESP_INSCRIPTION.CODE_CL) = trim(ESP_EVAL_CL_MODULE.CODE_CL))) c_nb_et FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE,   ESP_ENSEIGNANT  WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  ( trim(ESP_EVAL_CL_MODULE.ID_ENS) = trim(ESP_ENSEIGNANT.ID_ENS )) and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' ) and ESP_ENSEIGNANT.ID_ENS='" + ID_ENS + "' and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%' and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0) and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%'", mySqlConnection);
                DataTable myDataTable = new DataTable();

                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }
        public DataTable GetListNotes88(string CODE_CL, string CODE_MODULE, string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT (SELECT count(*)  FROM ESP_INSCRIPTION   WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "') AND   ( trim(ESP_INSCRIPTION.CODE_CL) = trim(ESP_EVAL_CL_MODULE.CODE_CL))) c_nb_et FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE,   ESP_ENSEIGNANT  WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  ( trim(ESP_EVAL_CL_MODULE.ID_ENS) = trim(ESP_ENSEIGNANT.ID_ENS )) and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' )  and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%' and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0) and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%'", mySqlConnection);
                DataTable myDataTable = new DataTable();

                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }
        public DataTable GetTauxRep(string CODE_CL, string CODE_MODULE, string ID_ENS, string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT concat(round(((( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))/((SELECT count(*) FROM ESP_INSCRIPTION WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "') AND ( trim(ESP_INSCRIPTION.CODE_CL) = trim(ESP_EVAL_CL_MODULE.CODE_CL))))*100)),'%') taux_rep FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE, ESP_ENSEIGNANT  WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  ( trim(ESP_EVAL_CL_MODULE.ID_ENS) = trim(ESP_ENSEIGNANT.ID_ENS )) and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' ) and ESP_ENSEIGNANT.ID_ENS='" + ID_ENS + "' and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%' and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0) and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%'", mySqlConnection);
                DataTable myDataTable = new DataTable();

                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }
        public DataTable GetTauxRep1(string CODE_CL, string CODE_MODULE, string Annee)
        {


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("SELECT concat(round(((( ESP_EVAL_CL_MODULE.NB_PALIER1+ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ESP_EVAL_CL_MODULE.NB_PALIER4+ESP_EVAL_CL_MODULE.NB_PALIER5))/((SELECT count(*) FROM ESP_INSCRIPTION WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "') AND ( trim(ESP_INSCRIPTION.CODE_CL) = trim(ESP_EVAL_CL_MODULE.CODE_CL))))*100)),'%') taux_rep FROM ESP_EVAL_CL_MODULE, ESP_CRITERE_EVAL, ESP_MODULE, ESP_ENSEIGNANT  WHERE  ( substr(ESP_CRITERE_EVAL.CODE_CRITERE,1,3) = substr(ESP_EVAL_CL_MODULE.CODE_CRITERE,1,3 )) and  ( trim(ESP_EVAL_CL_MODULE.CODE_MODULE) = trim(ESP_MODULE.CODE_MODULE )) and  ( trim(ESP_EVAL_CL_MODULE.ID_ENS) = trim(ESP_ENSEIGNANT.ID_ENS )) and  ( ( ESP_EVAL_CL_MODULE.ANNEE_DEB = '" + Annee + "' )  and ESP_CRITERE_EVAL.LIB_CRITERE not like 'Travail%' and ESP_MODULE.CODE_MODULE='" + CODE_MODULE + "' and ESP_EVAL_CL_MODULE.CODE_CL='" + CODE_CL + "' and ((SELECT count(*) FROM ESP_INSCRIPTION  WHERE ( ESP_INSCRIPTION.ANNEE_DEB ='" + Annee + "' ) AND ( trim(ESP_INSCRIPTION.CODE_CL) =trim(ESP_EVAL_CL_MODULE.CODE_CL)) )-(ESP_EVAL_CL_MODULE.NB_PALIER1+ ESP_EVAL_CL_MODULE.NB_PALIER2+ ESP_EVAL_CL_MODULE.NB_PALIER3+ ESP_EVAL_CL_MODULE.NB_PALIER4 + ESP_EVAL_CL_MODULE.NB_PALIER5 )) >=0) and ESP_CRITERE_EVAL.LIB_CRITERE like 'Global%'", mySqlConnection);
                DataTable myDataTable = new DataTable();

                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }
                return myDataTable;
            }
        }
/// <summary>
/// ////////////////////:::::::::::::::::::::::::
/// </summary>
/// <returns></returns>
      
    }
}
