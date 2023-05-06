using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using ABSEsprit;
using System.Data;

namespace AffichageClasse
{
    //   SELECT     NOM_ET, PNOM_ET, ID_ET, NUM_CIN_PASSEPORT
    //FROM         scoesb02.ESP_ETUDIANT



    public class ESP_ETUDIANT
    {
        #region sing

        static ESP_ETUDIANT instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static ESP_ETUDIANT Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ESP_ETUDIANT();
                    }

                    return ESP_ETUDIANT.instance;
                }
            }

        }
        private ESP_ETUDIANT() { }

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
        private string _PWD_ET;

        public string PWD_ET
        {
            get { return _PWD_ET; }
            set { _PWD_ET = value; }
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
        private string _ADRESSE_MAIL_ESP;

        public string ADRESSE_MAIL_ESP
        {
            get { return _ADRESSE_MAIL_ESP; }
            set { _ADRESSE_MAIL_ESP = value; }
        }
        private string _motdepasse;

        public string motdepasse
        {
            get { return _motdepasse; }
            set { _motdepasse = value; }
        }

        
        #endregion

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public ESP_ETUDIANT loginET(string _ID_ET, string _NUM_CIN_PASSEPORT, string _PWD_ET)
        {
            bool exist = false;
            string Name = "x";
            ESP_ETUDIANT etu = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select * from ESP_ETUDIANT WHERE  (ID_ET ='" + _ID_ET + "' or trim(NUM_CIN_PASSEPORT)='" + _NUM_CIN_PASSEPORT + "') and pwd_et=FS_CRYPT_DECRYPT('" + _PWD_ET + "')  and ETAT='A'";

                //string cmdQuery = "select t1.*,FS_CRYPT_DECRYPT(pwd_et) motdepasse  from ESP_V_ETUDIANT_AUTH t1 WHERE  (regexp_replace(t1.ID_ET, '[[:space:]]*','') =regexp_replace(:ID_ET, '[[:space:]]*','') or regexp_replace(NUM_CIN_PASSEPORT, '[[:space:]]*','')=regexp_replace(:NUM_CIN_PASSEPORT, '[[:space:]]*','')) and regexp_replace(pwd_et, '[[:space:]]*','')=FS_CRYPT_DECRYPT(:PWD_ET)  and pwd_et is not null and ETAT='A'";
                //15-07-2020  string cmdQuery = "select ESP_ETUDIANT.*,FS_CRYPT_DECRYPT(pwd_et) motdepasse ,esp_inscription.code_cl  from ESP_ETUDIANT, ESP_INSCRIPTION WHERE  (regexp_replace(ESP_ETUDIANT.ID_ET, '[[:space:]]*','')=regexp_replace('" + _ID_ET + "', '[[:space:]]*','')or regexp_replace(NUM_CIN_PASSEPORT, '[[:space:]]*','')=regexp_replace('" + _NUM_CIN_PASSEPORT + "', '[[:space:]]*','')) and ETAT='A'  and esp_etudiant.id_et=esp_inscription.id_et and annee_deb=2019";
                //  string cmdQuery = "select ESP_ETUDIANT.*,FS_CRYPT_DECRYPT(pwd_et) motdepasse ,esp_inscription.code_cl  from ESP_ETUDIANT, ESP_INSCRIPTION WHERE  (regexp_replace(ESP_ETUDIANT.ID_ET, '[[:space:]]*','')=regexp_replace('" + _ID_ET + "', '[[:space:]]*','')or regexp_replace(NUM_CIN_PASSEPORT, '[[:space:]]*','')=regexp_replace('" + _NUM_CIN_PASSEPORT + "', '[[:space:]]*','')) and ETAT='A'  and esp_etudiant.id_et=esp_inscription.id_et and annee_deb=2019";
                string cmdQuery = "select t1.*,FS_CRYPT_DECRYPT(pwd_et) motdepasse ,t2.code_cl from ESP_ETUDIANT t1,esp_inscription t2,societe t3 WHERE t1.id_et=t2.id_et and t2.annee_deb=(select max(annee_deb) from societe) and  (regexp_replace(t1.ID_ET, '[[:space:]]*','') =regexp_replace('" + _ID_ET + "', '[[:space:]]*','') or regexp_replace(NUM_CIN_PASSEPORT, '[[:space:]]*','')=regexp_replace('" + _NUM_CIN_PASSEPORT + "', '[[:space:]]*','')) and regexp_replace(pwd_et, '[[:space:]]*','')=FS_CRYPT_DECRYPT('" + _PWD_ET + "')  and pwd_et is not null and ETAT='A'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);
                OracleParameter prmID_ET = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
                prmID_ET.Value = _ID_ET;
                myCommand.Parameters.Add(prmID_ET);
                OracleParameter prmNUM_CIN_PASSEPORT = new OracleParameter(":NUM_CIN_PASSEPORT", OracleDbType.Varchar2);
                prmNUM_CIN_PASSEPORT.Value = _NUM_CIN_PASSEPORT;
                myCommand.Parameters.Add(prmNUM_CIN_PASSEPORT);
                OracleParameter prmPWD_ET = new OracleParameter(":PWD_ET", OracleDbType.Varchar2);
                prmPWD_ET.Value = _PWD_ET;
                myCommand.Parameters.Add(prmPWD_ET);
                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();


                    etu = new ESP_ETUDIANT(MyReader);
                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
                return etu;
            }



        }
        public string loginet_id(string _ID_ET, string _NUM_CIN_PASSEPORT)
        {
            bool exist = false;
            string Name = "x";
            string etu = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                try
                {
                    //  mySqlConnection.Open();

                    // string cmdQuery = "select FS_CRYPT_DECRYPT(pwd_et) motdepasse from ESP_ETUDIANT t1,esp_inscription t2,societe t3 ,scoesb02.esp_etat_nav t4  WHERE t1.id_et=t2.id_et and t4.IDENTIFIANT_ETUDIANT=t2.id_et  and t2.annee_deb=(select max(annee_deb) from societe) and    (regexp_replace(t1.ID_ET, '[[:space:]]*','')=regexp_replace('" + _ID_ET + "', '[[:space:]]*','') or regexp_replace(NUM_CIN_PASSEPORT, '[[:space:]]*','')=regexp_replace('" + _NUM_CIN_PASSEPORT + "', '[[:space:]]*',''))    and t1.ETAT='A' and t4.etat='T' and t2.type_insc='I'";
                    // and t2.type_insc='I'  and t2.type_insc='I' 
                    string cmdQuery = "select scoesb02.FS_CRYPT_DECRYPT(pwd_et) motdepasse from scoesb02.ESP_ETUDIANT t1,scoesb02.esp_inscription t2,scoesb02.societe t3   WHERE t1.id_et=t2.id_et   and t2.annee_deb=(select max(annee_deb) from scoesb02.societe) and    (regexp_replace(t1.ID_ET, '[[:space:]]*','')=regexp_replace('" + _ID_ET + "', '[[:space:]]*','') or regexp_replace(NUM_CIN_PASSEPORT, '[[:space:]]*','')=regexp_replace('" + _NUM_CIN_PASSEPORT + "', '[[:space:]]*',''))    and t1.ETAT='A'     ";


                    //string cmdQuery = "select scoesb02.FS_CRYPT_DECRYPT(pwd_et) motdepasse from scoesb02.ESP_ETUDIANT t1,scoesb02.esp_inscription t2,scoesb02.societe t3   WHERE t1.id_et=t2.id_et   and t2.annee_deb=(select max(annee_deb) from scoesb02.societe) and    (regexp_replace(t1.ID_ET, '[[:space:]]*','')=regexp_replace('" + _ID_ET + "', '[[:space:]]*','') or regexp_replace(NUM_CIN_PASSEPORT, '[[:space:]]*','')=regexp_replace('" + _NUM_CIN_PASSEPORT + "', '[[:space:]]*',''))    and t1.ETAT='A'  and t2.type_insc='I' ";







                    //  string cmdQuery = "select t1.*,FS_CRYPT_DECRYPT(pwd_et) motdepasse, code_cl  from ESP_ETUDIANT t1,esp_inscription t2,societe t3 WHERE t1.id_et=t2.id_et and t2.annee_deb in ((select max(annee_deb) from societe ),(select max(annee_deb) from societe)) and    (regexp_replace(t1.ID_ET, '[[:space:]]*','')=regexp_replace('" + _ID_ET + "', '[[:space:]]*','') or regexp_replace(NUM_CIN_PASSEPORT, '[[:space:]]*','')=regexp_replace('" + _NUM_CIN_PASSEPORT + "', '[[:space:]]*',''))    and ETAT='A'";


                    //OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = mySqlConnection.CreateCommand();
                    cmd.CommandText = cmdQuery;
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();

                    mySqlConnection.Open();
                    da.Fill(ds);
                    mySqlConnection.Close();
                    etu = ds.Tables[0].Rows[0].ToString();
                    //  OracleDataReader MyReader = myCommand.ExecuteReader();

                    //while (MyReader.Read() && !exist)
                    //{
                    //    // String Name = MyReader["Username"].ToString();


                    //    etu = new ESP_ETUDIANT(MyReader);
                    //    break;

                    //}
                    //MyReader.Close(); // <- too easy to forget
                    //MyReader.Dispose(); // <- too easy to forget
                    mySqlConnection.Close();

                    mySqlConnection.Dispose();
                    OracleConnection.ClearPool(mySqlConnection);
                    OracleConnection.ClearAllPools();

                }
                catch
                {

                    mySqlConnection.Close();

                    mySqlConnection.Dispose();
                    OracleConnection.ClearPool(mySqlConnection);
                    OracleConnection.ClearAllPools();
                }
                finally
                {

                    mySqlConnection.Close();

                    mySqlConnection.Dispose();
                    OracleConnection.ClearPool(mySqlConnection);
                    OracleConnection.ClearAllPools();
                }
            }

            return etu;

        }
        //public ESP_ETUDIANT loginet_id(string _ID_ET, string _NUM_CIN_PASSEPORT)
        //{
        //    bool exist = false;
        //    string Name = "x";
        //    ESP_ETUDIANT etu = null;

        //    using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
        //    {
        //        mySqlConnection.Open();

        //        // string cmdQuery = "select ESP_ETUDIANT.*,FS_CRYPT_DECRYPT(pwd_et) motdepasse  from ESP_ETUDIANT WHERE  
        //            //(regexp_replace(ID_ET, '[[:space:]]*','')=regexp_replace('" + _ID_ET + "', '[[:space:]]*','') or regexp_replace(NUM_CIN_PASSEPORT, '[[:space:]]*','')=regexp_replace('" + _NUM_CIN_PASSEPORT + "', '[[:space:]]*',''))   and ETAT='A'";

        //        string cmdQuery = "select ESP_ETUDIANT.*,FS_CRYPT_DECRYPT(pwd_et) motdepasse ,esp_inscription.code_cl  from ESP_ETUDIANT, ESP_INSCRIPTION WHERE  (regexp_replace(ESP_ETUDIANT.ID_ET, '[[:space:]]*','')=regexp_replace('" + _ID_ET + "', '[[:space:]]*','')or regexp_replace(NUM_CIN_PASSEPORT, '[[:space:]]*','')=regexp_replace('"+ _NUM_CIN_PASSEPORT+"', '[[:space:]]*','')) and ETAT='A'  and esp_etudiant.id_et=esp_inscription.id_et and annee_deb=(select max(annee_deb) from societe)";
        //        OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


        //        OracleDataReader MyReader = myCommand.ExecuteReader();

        //        while (MyReader.Read() && !exist)
        //        {
        //            // String Name = MyReader["Username"].ToString();


        //            etu = new ESP_ETUDIANT(MyReader);
        //            break;

        //        }
        //        MyReader.Close();
        //        mySqlConnection.Close();
        //        return etu;
        //    }



        //}
        public ESP_ETUDIANT(OracleDataReader myReader)
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
            if (!myReader.IsDBNull(myReader.GetOrdinal("motdepasse")))
            {

                _motdepasse = myReader.GetString(myReader.GetOrdinal("motdepasse"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("PWD_ET")))
            {

                _PWD_ET = myReader.GetString(myReader.GetOrdinal("PWD_ET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("PNOM_ET")))
            {

                _PRENOM_ET = myReader.GetString(myReader.GetOrdinal("PNOM_ET"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_CL")))
            {

                _CODE_CL = myReader.GetString(myReader.GetOrdinal("CODE_CL"));
            }

        }

        public ESP_ETUDIANT(string ID_ET, string NUM_CIN_PASSEPORT, string NOM_ET, string PRENOM_ET, string ADRESSE_MAIL_ESP, string PWD_ET,string _code_cl)
        {
            this._ID_ET = ID_ET;
            this._NUM_CIN_PASSEPORT = NUM_CIN_PASSEPORT;
            this._NOM_ET = NOM_ET;
            this._PRENOM_ET = PRENOM_ET;
            this._ADRESSE_MAIL_ESP = ADRESSE_MAIL_ESP;
            this._PWD_ET = PWD_ET;
            this.CODE_CL = _code_cl;
            //this._motdepasse = motdepasse;
        }

        public string andb()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "select max(annee_deb) from societe";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string GetnumcompteByid(string ideee)
        {

            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "select numcompte from scoesb02.esp_etudiant where( id_et='" + ideee + "' or trim(num_cin_passeport)='" + ideee + "')";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string GetnumcompteByidet(string ideee)
        {

            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "select id_et from scoesb02.esp_etudiant where trim(num_cin_passeport)='" + ideee + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

    }

}
