using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using ESPSuiviEncadrement;
using DAL;

namespace Evaluation
{
    public class services
    {
           public string anneedeb;
         #region sing

        static services instance;
        static Object locker = new Object();
        
        public static services Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new services();
                    }

                    return services.instance;
                }
            }

        }
        private services() { }

        #endregion
 

     public  string getCl(string _LOGIN)
        {
            string _cl=null;
            anneedeb = DAL.AffectationDAO.Instance.getanneedeb();

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT CODE_CL1 FROM ESP_INSCRIPTION where ID_ET ='" + _LOGIN + "' and annee_deb='2017'";
                    

                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() )
                {
                    // String Name = MyReader["Username"].ToString();

                    _cl = MyReader["CODE_CL1"].ToString();
                    
                   
                }
                MyReader.Close();
                mySqlConnection.Close();
            }

            return _cl;

        }


     public bool SaveEvalModule(string _ID_ET, string _CODE_MODULE, string _CODE_CL,int _NUM_SEMESTRE, int _EV1, int _EV2, int _EV3, int _EV4, int _EV5, int _EV6, string _PT_FORT, string _PT_FAIBLE, string _PROPOSITION)
     {
         anneedeb = DAL.AffectationDAO.Instance.getanneedeb();
         using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
         {
             mySqlConnection.Open();

             string cmdQuery = "INSERT INTO ESP_EVALUATION(ID_ET, ANNEE_DEB, CODE_MODULE, CODE_CL, NUM_SEMESTRE, DATE_SAISIE,EV1,EV2,EV3,EV4,EV5,PT_FORT,PT_FAIBLE,PROPOSITION,EV6) VALUES (:ID_ET, '2017', :CODE_MODULE, :CODE_CL, :NUM_SEMESTRE, sysdate,:EV1,:EV2,:EV3,:EV4,:EV5,:PT_FORT,:PT_FAIBLE,:PROPOSITION,:EV6)";
             OracleCommand myCommand = new OracleCommand(cmdQuery);
             myCommand.Connection = mySqlConnection;
             myCommand.CommandType = CommandType.Text;


             OracleParameter prmID_ET = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
             prmID_ET.Value = _ID_ET;
             myCommand.Parameters.Add(prmID_ET);
             
             OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
             prmCODE_MODULE.Value = _CODE_MODULE;
             myCommand.Parameters.Add(prmCODE_MODULE);

             OracleParameter prmCODE_CL = new OracleParameter(":CODE_CL", OracleDbType.Varchar2);
             prmCODE_CL.Value = _CODE_CL;
             myCommand.Parameters.Add(prmCODE_CL);

             OracleParameter prmNUM_SEMESTRE = new OracleParameter(":NUM_SEMESTRE", OracleDbType.Int32);
             prmNUM_SEMESTRE.Value = _NUM_SEMESTRE;
             myCommand.Parameters.Add(prmNUM_SEMESTRE);

             OracleParameter prmEV1 = new OracleParameter(":EV1", OracleDbType.Int32);
             prmEV1.Value = _EV1;
             myCommand.Parameters.Add(prmEV1);

             OracleParameter prmEV2 = new OracleParameter(":EV2", OracleDbType.Int32);
             prmEV2.Value = _EV2;
             myCommand.Parameters.Add(prmEV2);

             OracleParameter prmEV3 = new OracleParameter(":EV3", OracleDbType.Int32);
             prmEV3.Value = _EV3;
             myCommand.Parameters.Add(prmEV3);

             OracleParameter prmEV4 = new OracleParameter(":EV4", OracleDbType.Int32);
             prmEV4.Value = _EV4;
             myCommand.Parameters.Add(prmEV4);

             OracleParameter prmEV5 = new OracleParameter(":EV5", OracleDbType.Int32);
             prmEV5.Value = _EV5;
             myCommand.Parameters.Add(prmEV5);

             

             OracleParameter prmPT_FORT = new OracleParameter(":PT_FORT", OracleDbType.Varchar2);
             prmPT_FORT.Value = _PT_FORT;
             myCommand.Parameters.Add(prmPT_FORT);

             OracleParameter prmPT_FAIBLE = new OracleParameter(":PT_FAIBLE", OracleDbType.Varchar2);
             prmPT_FAIBLE.Value = _PT_FAIBLE;
             myCommand.Parameters.Add(prmPT_FAIBLE);

             OracleParameter prmPROPOSITION = new OracleParameter(":PROPOSITION", OracleDbType.Varchar2);
             prmPROPOSITION.Value = _PROPOSITION;
             myCommand.Parameters.Add(prmPROPOSITION);

             OracleParameter prmEV6 = new OracleParameter(":EV6", OracleDbType.Int32);
             prmEV6.Value = _EV6;
             myCommand.Parameters.Add(prmEV6);

             bool result = myCommand.ExecuteNonQuery() > 0;
             mySqlConnection.Close();

             return result;
         }

     }
  

     }
    }
