using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using System.Data;
using Oracle.ManagedDataAccess.Types;
namespace ABSEsprit
{
    public class ESP_ABS
    {




            #region Primitive Properties

            private string _CODE_CL;

            public string CODE_CL
            {
                get { return _CODE_CL; }
                set { _CODE_CL = value; }
            }


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
            private decimal _NUM_SEANCE;
            public decimal NUM_SEANCE
            {
                get { return _NUM_SEANCE; }
                set { _NUM_SEANCE = value; }
            }
            private OracleDate _DATE_SEANCE;
            public OracleDate DATE_SEANCE
            {
                get { return _DATE_SEANCE; }
                set { _DATE_SEANCE = value; }
            }
            private string _ID_ENS;

            public string ID_ENS
            {
                get { return _ID_ENS; }
                set { _ID_ENS = value; }
            }
            private string _UTILISATEUR;

            public string UTILISATEUR
            {
                get { return _UTILISATEUR; }
                set { _UTILISATEUR = value; }
            }


            private decimal _SEMESTRE;

            public decimal SEMESTRE
            {
                get { return _SEMESTRE; }
                set { _SEMESTRE = value; }
            }

            private string _JUSTIFICATION;

            public string JUSTIFICATION
            {
                get { return _JUSTIFICATION; }
                set { _JUSTIFICATION = value; }
            }

            private string _CODE_JUSTIF;

            public string CODE_JUSTIF
            {
                get { return _CODE_JUSTIF; }
                set { _CODE_JUSTIF = value; }
            }

            private string _LIB_JUSTIF;

            public string LIB_JUSTIF
            {
                get { return _LIB_JUSTIF; }
                set { _LIB_JUSTIF = value; }
            }


            #endregion


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ABS> GetListabsence(string _ANNEE_DEB, string _CODE_CL, string _CODE_MODULE, decimal _SEMESTRE,string _ID_ENS)
        {
            List<ESP_ABS> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT     * FROM         ESP_NOTE WHERE     (ANNEE_DEB = :ANNEE_DEB) AND (CODE_CL = :CODE_CL) AND (CODE_MODULE = :CODE_MODULE) AND (SEMESTRE = :SEMESTRE) and (ID_ENS = :ID_ENS)";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                //prmCODE_MODULEnote
                OracleParameter prmCODE_MODULEnote = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
                prmCODE_MODULEnote.Value = _CODE_MODULE;
                myCommand.Parameters.Add(prmCODE_MODULEnote);



                //CODE_CLnote
                OracleParameter prmCODE_CLnote = new OracleParameter(":CODE_CL", OracleDbType.Varchar2);
                prmCODE_CLnote.Value = _CODE_CL;
                myCommand.Parameters.Add(prmCODE_CLnote);

                //ANNEE_DEB2
                OracleParameter prmANNEE_DEBnote = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
                prmANNEE_DEBnote.Value = _ANNEE_DEB;

                myCommand.Parameters.Add(prmANNEE_DEBnote);


                //semestre
                OracleParameter prmSEMESTREnote = new OracleParameter(":SEMESTRE", OracleDbType.Decimal);
                prmSEMESTREnote.Value = _SEMESTRE;

                myCommand.Parameters.Add(prmSEMESTREnote);

                OracleParameter prmID_ENSnote = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
                prmID_ENSnote.Value = _ID_ENS;

                myCommand.Parameters.Add(prmID_ENSnote);

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_ABS>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ABS(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;



        }

           public ESP_ABS(OracleDataReader myReader)
            {
                if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_CL")))
                {
                    _CODE_CL = myReader.GetString(myReader.GetOrdinal("CODE_CL "));

                }
                if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_CL")))
                {
                    _CODE_CL = myReader.GetString(myReader.GetOrdinal("CODE_CL"));

                }


                if (!myReader.IsDBNull(myReader.GetOrdinal("ANNEE_DEB")))
                {
                    _ANNEE_DEB = myReader.GetString(myReader.GetOrdinal("ANNEE_DEB"));

                }
                if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ENS")))
                {
                    _ID_ENS = myReader.GetString(myReader.GetOrdinal("ID_ENS"));

                }

               
            }


    }
}