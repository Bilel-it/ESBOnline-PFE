using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using ABSEsprit;

namespace ESPOnline
{
    public class esp_parent2
    {
        #region sing

        static esp_parent2 instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static esp_parent2 Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new esp_parent2();
                    }

                    return esp_parent2.instance;
                }
            }

        }
        private esp_parent2() { }

        #endregion
        #region public private methodes

        private string _ID_ET;

        public string ID_ET
        {
            get { return _ID_ET; }
            set { _ID_ET = value; }
        }

        private string _NUM_CIN_PASSEPORT;

        public string NUM_CIN_PASSEPORT
        {
            get { return _NUM_CIN_PASSEPORT; }
            set { _NUM_CIN_PASSEPORT = value; }
        }


        private string _NOM_ET;

        public string NOM_ET
        {
            get { return _NOM_ET; }
            set { _NOM_ET = value; }
        }
        private string _CODE_CL;
        public string CODE_CL
        {
            get { return _CODE_CL; }
            set { _CODE_CL = value; }
        }
        private string _PRENOM_ET;

        public string PRENOM_ET
        {
            get { return _PRENOM_ET; }
            set { _PRENOM_ET = value; }
        }



        private string _TEL_ET;
        public string TEL_ET
        {
            get { return _TEL_ET; }
            set { _TEL_ET = value; }
        }



        // login parent for payement cour de jours 

        public esp_parent2 loginETParentPayment(string id)
        {
            bool exist = false;
            string Name = "x";
            esp_parent2 etu = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = "select t1.id_et,t1.NOM_ET,t1.PNOM_ET,t1.NUM_CIN_PASSEPORT ,t1.TEL_ET,  t2.code_cl from scoesb02.ESP_ETUDIANT t1 , scoesb02.esp_inscription t2,societe t3 WHERE trim(t1.ID_ET)='" + id + "' and  t1.id_et=t2.id_et   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);

                OracleParameter paramid = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
                paramid.Value = id;
                myCommand.Parameters.Add(paramid);
                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();


                    etu = new esp_parent2(MyReader);
                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
                return etu;
            }

        }







        public string CIN_EXISTE(string _NUM_CIN_PASSEPORT)
        {
            bool exist = false;
            string Name = "x";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select t1.*,FS_CRYPT_DECRYPT(pwd_et) motdepasse,code_cl  from scoesb02.ESP_ETUDIANT t1 ,esp_inscription t2,societe t3 WHERE ( regexp_replace(NUM_CIN_PASSEPORT, '[[:space:]]*','')=regexp_replace('" + _NUM_CIN_PASSEPORT + "', '[[:space:]]*','')) and t1.id_et=t2.id_et and t2.annee_deb=t3.annee_deb  and ETAT='A'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);
                OracleParameter prmNUM_CIN_PASSEPORT = new OracleParameter(":NUM_CIN_PASSEPORT", OracleDbType.Varchar2);
                prmNUM_CIN_PASSEPORT.Value = _NUM_CIN_PASSEPORT;
                myCommand.Parameters.Add(prmNUM_CIN_PASSEPORT);
                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {

                    Name = MyReader["NUM_CIN_PASSEPORT"].ToString();
                }
                MyReader.Close();
                mySqlConnection.Close();
                return Name;
            }
        }
        public esp_parent2(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ET")))
            {
                _ID_ET = myReader.GetString(myReader.GetOrdinal("ID_ET"));

            }


            if (!myReader.IsDBNull(myReader.GetOrdinal("NUM_CIN_PASSEPORT")))
            {

                _NUM_CIN_PASSEPORT = myReader.GetString(myReader.GetOrdinal("NUM_CIN_PASSEPORT"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_ET")))
            {

                _NOM_ET = myReader.GetString(myReader.GetOrdinal("NOM_ET"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("PNOM_ET")))
            {

                _PRENOM_ET = myReader.GetString(myReader.GetOrdinal("PNOM_ET"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("TEL_ET")))
            {

                _TEL_ET = myReader.GetString(myReader.GetOrdinal("TEL_ET"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_CL")))
            {

                _CODE_CL = myReader.GetString(myReader.GetOrdinal("CODE_CL"));
            }

        }

        public esp_parent2(string ID_ET, string NUM_CIN_PASSEPORT, string NOM_ET, string PRENOM_ET, string TEL_ET)
        {
            this._ID_ET = ID_ET;
            this._NUM_CIN_PASSEPORT = NUM_CIN_PASSEPORT;
            this._NOM_ET = NOM_ET;
            this._PRENOM_ET = PRENOM_ET;
            this._TEL_ET = TEL_ET;


        }
    }

}
#endregion