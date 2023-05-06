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
    public class Panier
    {
        #region sing

        static Panier instance;
        static Object locker = new Object();

        public static Panier Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Panier();
                    }

                    return Panier.instance;
                }
            }

        }
        private Panier() { }

        #endregion
        #region getset
        private string _NUM_PANIER;

        public string NUM_PANIER
        {
            get { return _NUM_PANIER; }
            set { _NUM_PANIER = value; }
        }
        private decimal _MOYENNE;

        public decimal MOYENNE
        {
            get { return _MOYENNE; }
            set { _MOYENNE = value; }
        }
        #endregion

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Panier> GetListPanier(string _Id_et)
        {
            List<Panier> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "";
                cmdQuery += "SELECT CONCAT ('Panier ',ESP_V_MOY_PANIER_ETUDIANT.NUM_PANIER) as NUM_PANIER,  ESP_V_MOY_PANIER_ETUDIANT.MOYENNE ";
                cmdQuery += "FROM ESP_V_MOY_PANIER_ETUDIANT ,  ESP_V_MOY_MODULE_ETUDIANT ";
                cmdQuery += "where  ESP_V_MOY_PANIER_ETUDIANT.ID_ET='" + _Id_et + "' ";
                cmdQuery += "and ESP_V_MOY_PANIER_ETUDIANT.ANNEE_DEB=2016 ";
                cmdQuery += "and ESP_V_MOY_PANIER_ETUDIANT.type_moy='R' ";
                cmdQuery += "and ESP_V_MOY_MODULE_ETUDIANT.type_moy='R' ";
                cmdQuery += "and ESP_V_MOY_PANIER_ETUDIANT.ID_ET =  ESP_V_MOY_MODULE_ETUDIANT.ID_ET ";
                cmdQuery += "and ESP_V_MOY_PANIER_ETUDIANT.NUM_PANIER =  ESP_V_MOY_MODULE_ETUDIANT.NUM_PANIER ";
                cmdQuery += "order by NUM_PANIER ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<Panier>();
                        while (myReader.Read())
                        {
                            myList.Add(new Panier(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }

        public Panier(OracleDataReader myReader)
        {



            if (!myReader.IsDBNull(myReader.GetOrdinal("NUM_PANIER")))
            {
                _NUM_PANIER = myReader.GetString(myReader.GetOrdinal("NUM_PANIER"));


            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("MOYENNE")))
            {
                _MOYENNE = myReader.GetDecimal(myReader.GetOrdinal("MOYENNE"));


            }


        }
    }
}