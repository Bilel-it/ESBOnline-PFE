using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using System.Data;
using ABSEsprit;

namespace ESPOnline.Etudiants
{
    public class NoteEcts
    {
        #region sing

        static NoteEcts instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static NoteEcts Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new NoteEcts();
                    }

                    return NoteEcts.instance;
                }
            }

        }
        private NoteEcts() { }

        #endregion
        #region getset
        private string cODE_UE;

        public string CODE_UE
        {
            get { return cODE_UE; }
            set { cODE_UE = value; }
        }
        private string lIB_UE;

        public string LIB_UE
        {
            get { return lIB_UE; }
            set { lIB_UE = value; }
        }
        private decimal nB_ECTS;

        public decimal NB_ECTS
        {
            get { return nB_ECTS; }
            set { nB_ECTS = value; }
        }

        private decimal mOYENNE;

        public decimal MOYENNE
        {
            get { return mOYENNE; }
            set { mOYENNE = value; }
        }
        private decimal c_NB_MODULE_UE;

        public decimal C_NB_MODULE_UE
        {
            get { return c_NB_MODULE_UE; }
            set { c_NB_MODULE_UE = value; }
        }
        #endregion
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<NoteEcts> GetListRES(string _Id_et)
        {
            List<NoteEcts> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "select CODE_UE,LIB_UE,NB_ECTS,MOYENNE, C_NB_MODULE_UE FROM ESP_V_RESULTAT_ECTS where ID_ET='" + _Id_et + "'  order by LIB_UE ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<NoteEcts>();
                        while (myReader.Read())
                        {
                            myList.Add(new NoteEcts(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }
        public NoteEcts(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_UE")))
            {

                cODE_UE = myReader.GetString(myReader.GetOrdinal("CODE_UE"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("LIB_UE")))
            {

                lIB_UE = myReader.GetString(myReader.GetOrdinal("LIB_UE"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("NB_ECTS")))
            {

                nB_ECTS = myReader.GetDecimal(myReader.GetOrdinal("NB_ECTS"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("C_NB_MODULE_UE")))
            {
                c_NB_MODULE_UE = myReader.GetDecimal(myReader.GetOrdinal("C_NB_MODULE_UE"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("MOYENNE")))
            {

                mOYENNE = myReader.GetDecimal(myReader.GetOrdinal("MOYENNE"));
            }
        }
    }
}