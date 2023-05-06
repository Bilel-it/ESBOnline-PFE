using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using System.Data;
using ABSEsprit;

namespace ESPOnline.Parents
{
    public class NoteS1
    {
        #region sing

        static NoteS1 instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static NoteS1 Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new NoteS1();
                    }

                    return NoteS1.instance;
                }
            }

        }
        private NoteS1() { }

        #endregion
        #region getset
        private string dESIGNATION;

        public string DESIGNATION
        {
            get { return dESIGNATION; }
            set { dESIGNATION = value; }
        }
        private decimal cOEF;

        public decimal COEF
        {
            get { return cOEF; }
            set { cOEF = value; }
        }

        private string eXISTE_NOTE_CC;

        public string EXISTE_NOTE_CC
        {
            get { return eXISTE_NOTE_CC; }
            set { eXISTE_NOTE_CC = value; }
        }
        private string eXISTE_NOTE_TP;

        public string EXISTE_NOTE_TP
        {
            get { return eXISTE_NOTE_TP; }
            set { eXISTE_NOTE_TP = value; }
        }
        private string nOM_ENS;

        public string NOM_ENS
        {
            get { return nOM_ENS; }
            set { nOM_ENS = value; }
        }

        private decimal nOTE_CC;

        public decimal NOTE_CC
        {
            get { return nOTE_CC; }
            set { nOTE_CC = value; }
        }


        private decimal nOTE_TP;

        public decimal NOTE_TP
        {
            get { return nOTE_TP; }
            set { nOTE_TP = value; }
        }

        private object nOTE_EXAM;

        public object NOTE_EXAM
        {
            get { return nOTE_EXAM; }
            set { nOTE_EXAM = value; }
        }


        private string aBSENT_CC;

        public string ABSENT_CC
        {
            get { return aBSENT_CC; }
            set { aBSENT_CC = value; }
        }


        private string aBSENT_TP;

        public string ABSENT_TP
        {
            get { return aBSENT_TP; }
            set { aBSENT_TP = value; }
        }


        private string aBSENT_EXAM;

        public string ABSENT_EXAM
        {
            get { return aBSENT_EXAM; }
            set { aBSENT_EXAM = value; }
        }


        #endregion
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<NoteS1> GetListNotes(string _Id_et)
        {
            List<NoteS1> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "select DESIGNATION,COEF,NOM_ENS,NOTE_CC,NOTE_TP,NOTE_EXAM,ABSENT_CC,ABSENT_TP,ABSENT_EXAM,EXISTE_NOTE_CC,EXISTE_NOTE_TP FROM ESP_V_NOTE_SEM1 where ID_ET='" + _Id_et + "'  order by DESIGNATION";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<NoteS1>();
                        while (myReader.Read())
                        {
                            myList.Add(new NoteS1(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }



        public NoteS1(OracleDataReader myReader)
        {


            if (!myReader.IsDBNull(myReader.GetOrdinal("DESIGNATION")))
            {

                dESIGNATION = myReader.GetString(myReader.GetOrdinal("DESIGNATION"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("COEF")))
            {
                cOEF = myReader.GetDecimal(myReader.GetOrdinal("COEF"));


            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_ENS")))
            {
                nOM_ENS = myReader.GetString(myReader.GetOrdinal("NOM_ENS"));


            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("NOTE_CC")))
            {
                nOTE_CC = myReader.GetDecimal(myReader.GetOrdinal("NOTE_CC"));


            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOTE_TP")))
            {
                nOTE_TP = myReader.GetDecimal(myReader.GetOrdinal("NOTE_TP"));


            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOTE_EXAM")))
            {
                nOTE_EXAM = myReader.GetValue(myReader.GetOrdinal("NOTE_EXAM"));


            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ABSENT_CC")))
            {
                aBSENT_CC = myReader.GetString(myReader.GetOrdinal("ABSENT_CC"));


            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ABSENT_TP")))
            {
                aBSENT_TP = myReader.GetString(myReader.GetOrdinal("ABSENT_TP"));


            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ABSENT_EXAM")))
            {
                aBSENT_EXAM = myReader.GetString(myReader.GetOrdinal("ABSENT_EXAM"));


            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("EXISTE_NOTE_TP")))
            {
                eXISTE_NOTE_TP = myReader.GetString(myReader.GetOrdinal("EXISTE_NOTE_TP"));


            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("EXISTE_NOTE_CC")))
            {
                eXISTE_NOTE_CC = myReader.GetString(myReader.GetOrdinal("EXISTE_NOTE_CC"));


            }

        }

    }
}