using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;

namespace ESPOnline.Etudiants
{
    public class info_arab
    {
       
            #region sing

            static info_arab instance;
            static Object locker = new Object();

            public static info_arab Instance
            {
                get
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new info_arab();
                        }

                        return info_arab.instance;
                    }
                }

            }
            private info_arab() { }

            #endregion
            #region public private methodes

            private string _ID_ET;

            public string ID_ET
            {
                get { return _ID_ET; }
                set { _ID_ET = value; }
            }
            private string __LIEU_NAIS_ET;

            public string _LIEU_NAIS_ET
            {
                get { return __LIEU_NAIS_ET; }
                set { __LIEU_NAIS_ET = value; }
            }
            private string _NATURE_BAC;

            public string NATURE_BAC
            {
                get { return _NATURE_BAC; }
                set { _NATURE_BAC = value; }
            }


            private string _NOM_ET;

            public string NOM_ET
            {
                get { return _NOM_ET; }
                set { _NOM_ET = value; }
            }
            private string _PRENOM_ET;

            public string PRENOM_ET
            {
                get { return _PRENOM_ET; }
                set { _PRENOM_ET = value; }
            }
            private string _ETAB_ORIGINE;

            public string ETAB_ORIGINE
            {
                get { return _ETAB_ORIGINE; }
                set { _ETAB_ORIGINE = value; }
            }

            private string _DIPLOME_SUP_ET;

            public string DIPLOME_SUP_ET
            {
                get { return _DIPLOME_SUP_ET; }
                set { _DIPLOME_SUP_ET = value; }
            }
          private DateTime _DATE_NAIS_ET;

            public DateTime DATE_NAIS_ET
            {
                get { return _DATE_NAIS_ET; }
                set { _DATE_NAIS_ET = value; }
            }
         private DateTime _DATE_BAC;

            public DateTime DATE_BAC
            {
                get { return _DATE_BAC; }
                set { _DATE_BAC = value; }
            }
       
            #endregion
            OracleConnection mySqlConnection = new OracleConnection(ABSEsprit.AppConfiguration.ConnectionString2);
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



            public bool insertarab(string _ID_et, string _NOM_ET, string _PNOM_ET, string _LIEU_NAIS_ET, string _NATURE_BAC,  string _ETAB_ORIGINE, string _DIPLOME_SUP_ET)
            {

                bool result = false;


               
                string cmdQuery = "UPDATE ESP_etudiant SET " +
                    "NOM_arb=:NOM_ET,PNOM_arb=:PNOM_ET,LIEU_NAIS_arb=:LIEU_NAIS_ET ,NATURE_BAC_arb=:NATURE_BAC,ETAB_ORIGINE_arb=:ETAB_ORIGINE,DIPLOME_SUP_arb=:DIPLOME_SUP_ET where trim(id_et)=:ID_et";

                Oracle.DataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                myCommand.Transaction = myTrans;

                //_NOM_ET
                OracleParameter prmNOM_ET = new OracleParameter(":NOM_ET", OracleDbType.Varchar2);
                prmNOM_ET.Value = _NOM_ET;
                myCommand.Parameters.Add(prmNOM_ET);

                OracleParameter prmPNOM_ET = new OracleParameter(":PNOM_ET", OracleDbType.Varchar2);
                prmPNOM_ET.Value = _PNOM_ET;
                myCommand.Parameters.Add(prmPNOM_ET);
                //OracleParameter prmDATE_NAIS_ET = new OracleParameter(":DATE_NAIS_ET", OracleDbType.Date);
                //prmDATE_NAIS_ET.Value = _DATE_NAIS_ET;
                //myCommand.Parameters.Add(prmDATE_NAIS_ET);
                OracleParameter prmLIEU_NAIS_ET = new OracleParameter(":LIEU_NAIS_ET", OracleDbType.Varchar2);
                prmLIEU_NAIS_ET.Value = _LIEU_NAIS_ET;
                myCommand.Parameters.Add(prmLIEU_NAIS_ET);
                OracleParameter prmNATURE_BAC = new OracleParameter(":NATURE_BAC", OracleDbType.Varchar2);
                prmNATURE_BAC.Value = _NATURE_BAC;
                myCommand.Parameters.Add(prmNATURE_BAC);

                //OracleParameter prmDATE_BAC = new OracleParameter(":DATE_BAC", OracleDbType.Date);
                //prmDATE_BAC.Value = _DATE_BAC;
                //myCommand.Parameters.Add(prmDATE_BAC);
                OracleParameter prmETAB_ORIGINE = new OracleParameter(":ETAB_ORIGINE", OracleDbType.Varchar2);
                prmETAB_ORIGINE.Value = _ETAB_ORIGINE;
                myCommand.Parameters.Add(prmETAB_ORIGINE);

                OracleParameter prmDIPLOME_SUP_ET = new OracleParameter(":DIPLOME_SUP_ET", OracleDbType.Varchar2);
                prmDIPLOME_SUP_ET.Value = _DIPLOME_SUP_ET;
                myCommand.Parameters.Add(prmDIPLOME_SUP_ET);


                OracleParameter prmID_et = new OracleParameter(":ID_et", OracleDbType.Varchar2);
                prmID_et.Value = _ID_et;
                myCommand.Parameters.Add(prmID_et);


                try
                { 
                    openconntrans(); 
              
                    myCommand.ExecuteNonQuery();
                    myTrans.Commit();
                    closeConnection();
                    result = true;
                    }
                    catch (Exception)
                    {
                        myTrans.Rollback();
                        mySqlConnection.Close();
                        throw;
                    }
                return result;
            }
    
    }
   

}
