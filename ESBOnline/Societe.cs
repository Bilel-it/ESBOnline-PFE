using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using ABSEsprit;

namespace soc
{
    public class Societe
    {

        #region sing
        static Societe instance;
        static Object locker = new Object();
    
        public static Societe Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Societe();
                    }

                    return Societe.instance;
                }
            }

        }
           private Societe() { }
        #endregion
        #region public private methodes

        private string _ANNEE_DEB;

public string ANNEE_DEB
{
  get { return _ANNEE_DEB; }
  set { _ANNEE_DEB = value; }
}
private string _ANNEE_FIN;

public string ANNEE_FIN
{
  get { return _ANNEE_FIN; }
  set { _ANNEE_FIN = value; }
}
        #endregion
public Societe(OracleDataReader myReader)
{
    if (!myReader.IsDBNull(myReader.GetOrdinal("ANNEE_DEB")))
    {
        _ANNEE_DEB = myReader.GetString(myReader.GetOrdinal("ANNEE_DEB"));

    }

    if (!myReader.IsDBNull(myReader.GetOrdinal("ANNEE_FIN")))
    {

        _ANNEE_FIN = myReader.GetString(myReader.GetOrdinal("ANNEE_FIN"));
    }
}
            public Societe ANNEE()
        {
            bool exist = false;
           
           Societe annee = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select ANNEE_DEB,ANNEE_FIN from SOCIETE " ;


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                   annee = new Societe(MyReader);
                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
                return annee;
            }



        }


    }
}




 