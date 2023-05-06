using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.OracleClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using ABSEsprit;
using System.Text.RegularExpressions;

namespace ESPOnline
{
    public class Log
    {
        #region sing

        static Log instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static Log Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Log();
                    }

                    return Log.instance;
                }
            }

        }
        private Log() { }

        #endregion

        #region public private methodes
        private string _ID_DECID;

        public string ID_DECID
        {
            get { return _ID_DECID; }
            set { _ID_DECID = value; }
        }

        private string _PWD_DECID;


        public string PWD_DECID
        {
            get { return _PWD_DECID; }
            set { _PWD_DECID = value; }
        }

        private string _NOM_DECID;
        public string NOM_DECID
        {
            get { return _NOM_DECID; }
            set { _NOM_DECID = value; }
        }
        #endregion

        public bool loginx(string _ID_ET)
        {
            bool exist = false;


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_SEMINAIRE WHERE  ID_ET ='" + _ID_ET + "'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();


                    exist = true;


                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
                return exist;
            }
        }


        public string login(string _ID_ENS, string _PWD_ENS)
        {
            bool exist = false;
            string Name = "x";

            string pwd = Regex.Replace(_PWD_ENS, @"\s+", " ");
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select * from ESP_V_ENSEIGNANT WHERE  trim(ID_ENS) =regexp_replace(:ID_ENS, '[[:space:]]*','') and etat='A' and type_ens='P'";
                // or(   trim(ID_ENS) =regexp_replace('V-1139-15', '[[:space:]]*','') or trim(ID_ENS) =regexp_replace('V-1138-15', '[[:space:]]*','') or  trim(ID_ENS) =regexp_replace('V-1151-15', '[[:space:]]*','') or  trim(ID_ENS) =regexp_replace('V-1153-15', '[[:space:]]*','') or  trim(ID_ENS) =regexp_replace('V-1161-15', '[[:space:]]*','') or  trim(ID_ENS) =regexp_replace('V-88-07', '[[:space:]]*',''))
                string cmdQuery = "select * from ESP_ENSEIGNANT WHERE  trim(ID_ENS) =regexp_replace(:ID_ENS, '[[:space:]]*','')  and trim(pwd_ens) ='"+pwd+"' and etat='A' ";
                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);
                OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
                prmID_ENS.Value = _ID_ENS;
                myCommand.Parameters.Add(prmID_ENS);

                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    String pwd22 = MyReader["PWD_ENS"].ToString().Trim();

                    if (MyReader["PWD_ENS"].ToString().Trim() == pwd)/*Name.Equals(username)*/
                    {
                         Name = MyReader["TYPE_UP"].ToString();


                        break;
                    }
                    if (MyReader["PWD_ENS"].ToString().Trim() == pwd22)/*Name.Equals(username)*/
                    {
                        Name = MyReader["TYPE_UP"].ToString();


                        break;
                    }
                }
                MyReader.Close();
                mySqlConnection.Close();
                return Name;
            }


        }

        public Log loginEntretien(string _ID_DECID, string _PWD_DECID)
        {
            Log DEC = null;



            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select * from DECID WHERE  ID_DECID ='" + _ID_DECID + "' and PWD_DECID='" + _PWD_DECID + "'";
                string cmdQuery = "select * from DECID WHERE  (ID_DECID =:ID_DECID ) and( PWD_DECID=:PWD_DECID)  and ROLE_DECID='02' and ETAT_DECID='A'";

                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);

                OracleParameter prmID_DECID = new OracleParameter(":ID_DECID", OracleDbType.Varchar2);
                prmID_DECID.Value = _ID_DECID;
                myCommand.Parameters.Add(prmID_DECID);
                OracleParameter prmPWD_DECID = new OracleParameter(":PWD_DECID", OracleDbType.Varchar2);
                prmPWD_DECID.Value = _PWD_DECID;
                myCommand.Parameters.Add(prmPWD_DECID);
                OracleDataReader MyReader = myCommand.ExecuteReader();
                try
                {
                    while (MyReader.Read())
                    {



                        DEC = new Log(MyReader);
                        break;

                    }
                }
                finally
                {
                    MyReader.Close();
                    mySqlConnection.Close();

                }
                return DEC;
            }
        }

        ///////////
        public Log loginRole3(string _ID_DECID, string _PWD_DECID)
        {
            Log DEC = null;



            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select * from DECID WHERE  ID_DECID ='" + _ID_DECID + "' and PWD_DECID='" + _PWD_DECID + "'";
                string cmdQuery = "select * from DECID WHERE  (ID_DECID =:ID_DECID ) and( PWD_DECID=:PWD_DECID)  and ROLE_DECID='03' and ETAT_DECID='A'";

                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);

                OracleParameter prmID_DECID = new OracleParameter(":ID_DECID", OracleDbType.Varchar2);
                prmID_DECID.Value = _ID_DECID;
                myCommand.Parameters.Add(prmID_DECID);
                OracleParameter prmPWD_DECID = new OracleParameter(":PWD_DECID", OracleDbType.Varchar2);
                prmPWD_DECID.Value = _PWD_DECID;
                myCommand.Parameters.Add(prmPWD_DECID);
                OracleDataReader MyReader = myCommand.ExecuteReader();
                try
                {
                    while (MyReader.Read())
                    {



                        DEC = new Log(MyReader);
                        break;

                    }
                }
                finally
                {
                    MyReader.Close();
                    mySqlConnection.Close();

                }
                return DEC;
            }
        }
        ////////

        public Log loginD(string _ID_DECID, string _PWD_DECID)
        {
            Log DEC = null;


           
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select * from DECID WHERE  ID_DECID ='" + _ID_DECID + "' and PWD_DECID='" + _PWD_DECID + "'";
                string cmdQuery = "select * from DECID WHERE  (ID_DECID =:ID_DECID ) and( PWD_DECID=:PWD_DECID)  and ROLE_DECID='01' and ETAT_DECID='A'";

                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);

                OracleParameter prmID_DECID = new OracleParameter(":ID_DECID", OracleDbType.Varchar2);
                prmID_DECID.Value = _ID_DECID;
                myCommand.Parameters.Add(prmID_DECID);
                OracleParameter prmPWD_DECID = new OracleParameter(":PWD_DECID", OracleDbType.Varchar2);
                prmPWD_DECID.Value = _PWD_DECID;
                myCommand.Parameters.Add(prmPWD_DECID);
                OracleDataReader MyReader = myCommand.ExecuteReader();
                try
                {
                    while (MyReader.Read())
                    {



                        DEC = new Log(MyReader);
                        break;

                    }
                }
                finally
                {
                    MyReader.Close();
                    mySqlConnection.Close();
                  
                }
                return DEC;
            }
        }
        public Log(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_DECID")))
            {
                _ID_DECID = myReader.GetString(myReader.GetOrdinal("ID_DECID"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("PWD_DECID")))
            {
                _PWD_DECID = myReader.GetString(myReader.GetOrdinal("PWD_DECID"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_DECID")))
            {
                _NOM_DECID = myReader.GetString(myReader.GetOrdinal("NOM_DECID"));

            }

        }
        public string logindeptCUP(string _ID_ENS)
        {
            bool exist = false;
            string Name = "x";

       
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_V_ENSEIGNANT WHERE  trim(ID_ENS) =regexp_replace(:ID_ENS, '[[:space:]]*','') and etat='A' and type_ens='P'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);
                OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
                prmID_ENS.Value = _ID_ENS;
                myCommand.Parameters.Add(prmID_ENS);

                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();


                    Name = MyReader["CODE_DEPT"].ToString();


                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
                return Name;
            }



        }
        public string logiCUP(string _ID_ENS)
        {
            bool exist = false;
            string Name = "x";


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_V_ENSEIGNANT WHERE  ID_ENS =regexp_replace(:ID_ENS, '[[:space:]]*','') and etat='A'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);

                OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
                prmID_ENS.Value = _ID_ENS;
                myCommand.Parameters.Add(prmID_ENS);
                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();

                   
                        Name = MyReader["UP"].ToString();


                        break;
                    
                }
                MyReader.Close();
                mySqlConnection.Close();
                return Name;
            }



        }
        public string loginomCUP(string _ID_ENS)
        {
            bool exist = false;
            string Name = "x";


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_ENSEIGNANT WHERE  trim(ID_ENS) =regexp_replace(:ID_ENS, '[[:space:]]*','') ";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);
                OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
                prmID_ENS.Value = _ID_ENS;
                myCommand.Parameters.Add(prmID_ENS);

                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();


                    Name = MyReader["NOM_ENS"].ToString();


                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
                return Name;
            }



        }
        public string loginPWDCUP(string _ID_ENS)
        {
            bool exist = false;
            string Name = "x";


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_ENSEIGNANT WHERE  trim(ID_ENS) =regexp_replace(:ID_ENS, '[[:space:]]*','') and etat='A'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);
                OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
                prmID_ENS.Value = _ID_ENS;
                myCommand.Parameters.Add(prmID_ENS);

                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();


                    Name = MyReader["PWD_ENS"].ToString();


                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
                return Name;
            }



        }
        public string loginPWDnomenclature()
        {
            bool exist = false;
            string Name = "x";


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT LIB_NOME FROM CODE_NOMENCLATURE where CODE_NOME='01' and CODE_STR='66'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);
                //OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
                //prmID_ENS.Value = _ID_ENS;
                //myCommand.Parameters.Add(prmID_ENS);

                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();


                    Name = MyReader["LIB_NOME"].ToString();


                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
                return Name;
            }



        }

    }
}