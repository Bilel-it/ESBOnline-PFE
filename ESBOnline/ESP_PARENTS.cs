using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using ABSEsprit;

namespace ESPOnline
{
    public class ESP_PARENTS
    {
        #region sing

        static ESP_PARENTS instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static ESP_PARENTS Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ESP_PARENTS();
                    }

                    return ESP_PARENTS.instance;
                }
            }

        }
        private ESP_PARENTS() { }

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
        private string _PWD_ET_INIT;

        public string PWD_ET_INIT
        {
            get { return _PWD_ET_INIT; }
            set { _PWD_ET_INIT = value; }
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
        private string _PWD_PARENT;

        public string PWD_PARENT
        {
            get { return PWD_PARENT; }
            set { PWD_PARENT = value; }
        }
        private string _TYPE_PV;

        public string TYPE_PV
        {
            get { return _TYPE_PV; }
            set { _TYPE_PV = value; }
        }
        private string _NUMCOMPTE;
        public string NUMCOMPTE
        {
            get { return _NUMCOMPTE; }
            set { _NUMCOMPTE = value; }
        }

        #endregion
        [DataObjectMethod(DataObjectMethodType.Select, true)]

        public ESP_PARENTS loginETP(string _NUM_CIN_PASSEPORT, string _PWD_PARENT)
        {
            bool exist = false;
            string Name = "x";
            ESP_PARENTS etu = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select * from ESP_ETUDIANT WHERE  (ID_ET ='" + _ID_ET + "' or NUM_CIN_PASSEPORT='" + _NUM_CIN_PASSEPORT + "') and pwd_et=FS_CRYPT_DECRYPT('" + _PWD_ET + "')  and ETAT='A'";

                // string cmdQuery = "select e1.*,e3.type_pv as TYPE_PV from  ESP_ETUDIANT e1, esp_inscription e2, esp_saison_classe e3 WHERE   regexp_replace(e1.NUM_CIN_PASSEPORT, '[[:space:]]*','')=regexp_replace(:NUM_CIN_PASSEPORT, '[[:space:]]*','') and  FS_IS_STUDENT_AUTORISED_NEW(e1.id_et)=1 and ETAT='A' and e2.annee_deb='2016' and e3.annee_deb='2016'  and e2.code_cl =e3.code_cl and e1.id_et=e2.id_et";
                string cmdQuery = "select t1.*,FS_CRYPT_DECRYPT(pwd_et) motdepasse,code_cl  from ESP_ETUDIANT t1 ,esp_inscription t2,societe t3 WHERE  ( regexp_replace(trim(NUM_CIN_PASSEPORT), '[[:space:]]*','')=regexp_replace('" + _NUM_CIN_PASSEPORT + "', '[[:space:]]*','')) and t1.id_et=t2.id_et and t2.annee_deb=(select max(annee_deb) from societe)  and pwd_parent='" + _PWD_PARENT + "'  and ETAT='A'";
                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);

                OracleParameter prmNUM_CIN_PASSEPORT = new OracleParameter(":NUM_CIN_PASSEPORT", OracleDbType.Varchar2);
                prmNUM_CIN_PASSEPORT.Value = _NUM_CIN_PASSEPORT;
                myCommand.Parameters.Add(prmNUM_CIN_PASSEPORT);

                OracleParameter prmpwd_parent = new OracleParameter(":PWD_PARENT", OracleDbType.Varchar2);
                prmpwd_parent.Value = _PWD_PARENT;
                myCommand.Parameters.Add(prmpwd_parent);
                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();


                    etu = new ESP_PARENTS(MyReader);
                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
                return etu;
            }



        }

        //public ESP_PARENTS loginETP(string _NUM_CIN_PASSEPORT, string _PWD_PARENT)
        //{
        //    bool exist = false;
        //    string Name = "x";
        //    ESP_PARENTS etu = null;

        //    using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
        //    {
        //        mySqlConnection.Open();

        //        //string cmdQuery = "select * from ESP_ETUDIANT WHERE  (ID_ET ='" + _ID_ET + "' or NUM_CIN_PASSEPORT='" + _NUM_CIN_PASSEPORT + "') and pwd_et=FS_CRYPT_DECRYPT('" + _PWD_ET + "')  and ETAT='A'";

        //        // 15-07-2020  string cmdQuery = "select e1.*,e3.type_pv as TYPE_PV from  ESP_ETUDIANT e1, esp_inscription e2, esp_saison_classe e3,SOCIETE e4 WHERE   regexp_replace(e1.NUM_CIN_PASSEPORT, '[[:space:]]*','')=regexp_replace(:NUM_CIN_PASSEPORT, '[[:space:]]*','') and ETAT='A' and  e2.annee_deb=e4.annee_deb and e3.annee_deb=e4.annee_deb   and e2.code_cl =e3.code_cl and e1.id_et=e2.id_et";
        //        string cmdQuery = "select t1.*,FS_CRYPT_DECRYPT(pwd_et) motdepasse,code_cl  from ESP_ETUDIANT t1 ,esp_inscription t2,societe t3 WHERE  ( regexp_replace(trim(NUM_CIN_PASSEPORT), '[[:space:]]*','')=regexp_replace('" + _NUM_CIN_PASSEPORT + "', '[[:space:]]*','')) and t1.id_et=t2.id_et and t2.annee_deb=(select max(annee_deb) from societe)  and pwd_parent='" + _PWD_PARENT + "' and  pwd_parent is not null   and ETAT='A'";

        //        OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);

        //        OracleParameter prmNUM_CIN_PASSEPORT = new OracleParameter(":NUM_CIN_PASSEPORT", OracleDbType.Varchar2);
        //        prmNUM_CIN_PASSEPORT.Value = _NUM_CIN_PASSEPORT;
        //        myCommand.Parameters.Add(prmNUM_CIN_PASSEPORT);
        //        OracleDataReader MyReader = myCommand.ExecuteReader();

        //        while (MyReader.Read() && !exist)
        //        {
        //            // String Name = MyReader["Username"].ToString();


        //            etu = new ESP_PARENTS(MyReader);
        //            break;

        //        }
        //        MyReader.Close();
        //        mySqlConnection.Close();
        //        return etu;
        //    }



        //}
        public string CIN_EXISTE(string _NUM_CIN_PASSEPORT, string _PWD_PARENT)
          {
              bool exist = false;
              string Name = "x";

              using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
              {
                  mySqlConnection.Open();

                //15-07-20 string cmdQuery = "select t1.*,FS_CRYPT_DECRYPT(pwd_et) motdepasse,code_cl  from ESP_ETUDIANT t1 ,esp_inscription t2,societe t3 WHERE  ( regexp_replace(NUM_CIN_PASSEPORT, '[[:space:]]*','')=regexp_replace('" + _NUM_CIN_PASSEPORT + "', '[[:space:]]*','')) and t1.id_et=t2.id_et and t2.annee_deb=t3.annee_deb  and ETAT='A'";
                string cmdQuery = "select t1.*,FS_CRYPT_DECRYPT(pwd_et) motdepasse,code_cl  from ESP_ETUDIANT t1 ,esp_inscription t2,societe t3 WHERE  ( regexp_replace(trim(NUM_CIN_PASSEPORT), '[[:space:]]*','')=regexp_replace('" + _NUM_CIN_PASSEPORT + "', '[[:space:]]*','')) and t1.id_et=t2.id_et and t2.annee_deb=(select max(annee_deb) from societe)  and pwd_parent='" + _PWD_PARENT + "'  and ETAT='A'";


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
        //public ESP_PARENTS(OracleDataReader myReader)
        //{
        //    if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ET")))
        //    {
        //        _ID_ET = myReader.GetString(myReader.GetOrdinal("ID_ET"));

        //    }

        //    if (!myReader.IsDBNull(myReader.GetOrdinal("NUM_CIN_PASSEPORT")))
        //    {

        //        _NUM_CIN_PASSEPORT = myReader.GetString(myReader.GetOrdinal("NUM_CIN_PASSEPORT"));
        //    }
        //    if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_ET")))
        //    {

        //        _NOM_ET = myReader.GetString(myReader.GetOrdinal("NOM_ET"));
        //    }
        //    if (!myReader.IsDBNull(myReader.GetOrdinal("PWD_ET_INIT")))
        //    {

        //        _PWD_ET_INIT = myReader.GetString(myReader.GetOrdinal("PWD_ET_INIT"));
        //    }
        //    if (!myReader.IsDBNull(myReader.GetOrdinal("PNOM_ET")))
        //    {

        //        _PRENOM_ET = myReader.GetString(myReader.GetOrdinal("PNOM_ET"));
        //    }
        //    if (!myReader.IsDBNull(myReader.GetOrdinal("ADRESSE_MAIL_ESP")))
        //    {

        //        _ADRESSE_MAIL_ESP = myReader.GetString(myReader.GetOrdinal("ADRESSE_MAIL_ESP"));
        //    }
        //    if (!myReader.IsDBNull(myReader.GetOrdinal("TYPE_PV")))
        //    {

        //        _TYPE_PV = myReader.GetString(myReader.GetOrdinal("TYPE_PV"));
        //    }


        //}

        //public ESP_PARENTS(string ID_ET, string NUM_CIN_PASSEPORT, string NOM_ET, string PRENOM_ET, string ADRESSE_MAIL_ESP, string _PWD_ET_INIT, string TYPE_PV)
        //{
        //    this._ID_ET = ID_ET;
        //    this._NUM_CIN_PASSEPORT = NUM_CIN_PASSEPORT;
        //    this._NOM_ET = NOM_ET;
        //    this._PRENOM_ET = PRENOM_ET;
        //    this._ADRESSE_MAIL_ESP = ADRESSE_MAIL_ESP;
        //    this._PWD_ET_INIT = PWD_ET_INIT;
        //    this._TYPE_PV = TYPE_PV;

        //}


        public ESP_PARENTS(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ET")))
            {
                _ID_ET = myReader.GetString(myReader.GetOrdinal("ID_ET"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NUMCOMPTE")))
            {
                NUMCOMPTE = myReader.GetString(myReader.GetOrdinal("NUMCOMPTE"));

            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("NUM_CIN_PASSEPORT")))
            {

                _NUM_CIN_PASSEPORT = myReader.GetString(myReader.GetOrdinal("NUM_CIN_PASSEPORT"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_ET")))
            {

                _NOM_ET = myReader.GetString(myReader.GetOrdinal("NOM_ET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("PWD_ET_INIT")))
            {

                _PWD_ET_INIT = myReader.GetString(myReader.GetOrdinal("PWD_ET_INIT"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("PNOM_ET")))
            {

                _PRENOM_ET = myReader.GetString(myReader.GetOrdinal("PNOM_ET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ADRESSE_MAIL_ESP")))
            {

                _ADRESSE_MAIL_ESP = myReader.GetString(myReader.GetOrdinal("ADRESSE_MAIL_ESP"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("PWD_PARENT")))
            {

                _PWD_PARENT = myReader.GetString(myReader.GetOrdinal("PWD_PARENT"));
            }
            ////if (!myReader.IsDBNull(myReader.GetOrdinal("TYPE_PV")))
            ////{

            ////    _TYPE_PV = myReader.GetString(myReader.GetOrdinal("TYPE_PV"));
            ////}
            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_CL")))
            {

                _CODE_CL = myReader.GetString(myReader.GetOrdinal("CODE_CL"));
            }

        }

        public ESP_PARENTS(string ID_ET, string NUM_CIN_PASSEPORT, string NOM_ET, string PRENOM_ET, string ADRESSE_MAIL_ESP, string _PWD_ET_INIT, string TYPE_PV, string NUMCOMPTE)
        {
            this._ID_ET = ID_ET;
            this._NUM_CIN_PASSEPORT = NUM_CIN_PASSEPORT;
            this._NOM_ET = NOM_ET;
            this._PRENOM_ET = PRENOM_ET;
            this._ADRESSE_MAIL_ESP = ADRESSE_MAIL_ESP;
            this._PWD_ET_INIT = PWD_ET_INIT;
            this._TYPE_PV = TYPE_PV;
            this.NUMCOMPTE = NUMCOMPTE;

        }



    }

}
