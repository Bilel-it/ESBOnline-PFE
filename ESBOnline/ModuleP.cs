using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using System.Data;
using ABSEsprit;


namespace ESPOnline
{
    public class ModuleP
    {
        #region sing

        static ModuleP instance;
        static Object locker = new Object();
    
        public static ModuleP Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ModuleP();
                    }

                    return ModuleP.instance;
                }
            }

        }
        private ModuleP() { }

        #endregion
        #region


        private string code_module;

        public string Code_module
        {
            get { return code_module; }
            set { code_module = value; }
        }



        private string designation;

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }
        private string num_panier;

        public string Num_panier
        {
            get { return num_panier; }
            set { num_panier = value; }
        }


        private decimal moyenne;

        public decimal Moyenne
        {
            get { return moyenne; }
            set { moyenne = value; }
        }

        #endregion


           [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ModuleP> GetListModuleP(string _Id_et)
        {
            List<ModuleP> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT  NUM_PANIER,  CODE_MODULE,  DESIGNATION_MODULE,  MOYENNE FROM ESP_V_MOY_MODULE_ETUDIANT where ID_ET='" + _Id_et + "' and ANNEE_DEB=2017 and TYPE_MOY='P' order by num_panier";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ModuleP>();
                        while (myReader.Read())
                        {
                            myList.Add(new ModuleP(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }


         [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ModuleP> GetListModulePRatt(string _Id_et)
        {
            List<ModuleP> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT  NUM_PANIER,  CODE_MODULE,  DESIGNATION_MODULE,  MOYENNE FROM ESP_V_MOY_MODULE_ETUDIANT where ID_ET='" + _Id_et + "' and ANNEE_DEB=2017 and TYPE_MOY='R' order by num_panier";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ModuleP>();
                        while (myReader.Read())
                        {
                            myList.Add(new ModuleP(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }


        public ModuleP(OracleDataReader myReader)
        {
           

            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_MODULE")))
            {

                code_module = myReader.GetString(myReader.GetOrdinal("CODE_MODULE"));
            }


            if (!myReader.IsDBNull(myReader.GetOrdinal("DESIGNATION_MODULE")))
            {
                designation = myReader.GetString(myReader.GetOrdinal("DESIGNATION_MODULE"));


            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("NUM_PANIER")))
            {
                num_panier = myReader.GetString(myReader.GetOrdinal("NUM_PANIER"));


            }

          
            if (!myReader.IsDBNull(myReader.GetOrdinal("MOYENNE")))
            {
                moyenne = myReader.GetDecimal(myReader.GetOrdinal("MOYENNE"));


            }


        }
    
    }
}