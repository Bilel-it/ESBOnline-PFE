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
      private  string nOM_ENS;

public string NOM_ENS
{
  get { return nOM_ENS; }
  set { nOM_ENS = value; }
}

     private   decimal  nOTE_CC;

public decimal NOTE_CC
{
  get { return nOTE_CC; }
  set { nOTE_CC = value; }
}
        

    private  decimal   nOTE_TP;

public decimal NOTE_TP
{
  get { return nOTE_TP; }
  set { nOTE_TP = value; }
}
    
     private   object  nOTE_EXAM;

public object NOTE_EXAM
{
  get { return nOTE_EXAM; }
  set { nOTE_EXAM = value; }
}
    

      private  string  aBSENT_CC;

public string ABSENT_CC
{
  get { return aBSENT_CC; }
  set { aBSENT_CC = value; }
}
   

      private string   aBSENT_TP;

public string ABSENT_TP
{
  get { return aBSENT_TP; }
  set { aBSENT_TP = value; }
}

   
      private string   aBSENT_EXAM;

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

        //string cmdQuery = "select DESIGNATION,COEF,NOM_ENS,NOTE_CC,NOTE_TP,NOTE_EXAM,ABSENT_CC,ABSENT_TP,ABSENT_EXAM,EXISTE_NOTE_CC,EXISTE_NOTE_TP FROM ESP_V_NOTE_SEM1 where ID_ET='" + _Id_et + "'  order by DESIGNATION";

       // string cmdQuery = "select DESIGNATION,COEF,NOM_ENS,NOTE_CC,NOTE_TP,NOTE_EXAM,ABSENT_CC,ABSENT_TP,ABSENT_EXAM,EXISTE_NOTE_CC,EXISTE_NOTE_TP FROM ( select  ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET, ESP_NOTE.CODE_CL, ESP_MODULE.DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,ESP_NOTE.NOTE_CC, ESP_NOTE.NOTE_TP,ESP_NOTE.NOTE_EXAM,ESP_NOTE.ABSENT_CC,ESP_NOTE.ABSENT_TP,ESP_NOTE.ABSENT_EXAM ,EXISTE_NOTE_CC,EXISTE_NOTE_TP,ESP_NOTE.NOTE_ESB_01,ESP_NOTE.note_esb_02 FROM ESP_ENSEIGNANT, ESP_MODULE, ESP_NOTE,ESP_MODULE_PANIER_CLASSE_SAISO,
       //
       // .ESP_ENTETE_NOTE WHERE (ESP_NOTE.code_cl in ('3-LFIG-2','3-LFIG-1','2-BA-1','2-MKD-1','1-CCA-1','3-LFG-1','3-LFG-2','3-LFG-3','2-LFG-1','2-LFG-2','2-LFG-3','2-LFG-4','2-LFG-5','1 MAD') or esp_note.code_cl like '2-MD%') and    (ESP_NOTE.CODE_MODULE= ESP_MODULE.CODE_MODULE  ) and (ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB ) and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl ) and (ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module ) and (ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and  ( ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB ) and ( ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL ) and ( ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE ) and (ESP_ENTETE_NOTE.CONFIRMATION='O') and ( esp_note.id_ens = esp_enseignant.id_ens (+)) and(ESP_NOTE.annee_deb=(select max(annee_deb) from societe)) and  (scoesb02.fs_is_student_autorised_new( ESP_NOTE.ID_ET) =1)  and ( id_et not in (select id_et from esp_inscription where annee_deb=(select max(annee_deb) from societe) and reserve='O'))) where ID_ET='" + _Id_et + "'  order by DESIGNATION";
        //and ESP_NOTE.code_cl <> '3-LFIG-2'
      //  string cmdQuery2020 = "select DESIGNATION,COEF,NOM_ENS,NOTE_CC,NOTE_TP,NOTE_EXAM,ABSENT_CC,ABSENT_TP,ABSENT_EXAM,EXISTE_NOTE_CC,EXISTE_NOTE_TP FROM ( select  ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET, ESP_NOTE.CODE_CL, ESP_MODULE.DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,ESP_NOTE.NOTE_CC, ESP_NOTE.NOTE_TP,ESP_NOTE.NOTE_EXAM,ESP_NOTE.ABSENT_CC,ESP_NOTE.ABSENT_TP,ESP_NOTE.ABSENT_EXAM ,EXISTE_NOTE_CC,EXISTE_NOTE_TP,ESP_NOTE.NOTE_ESB_01,ESP_NOTE.note_esb_02 FROM ESP_ENSEIGNANT, ESP_MODULE, ESP_NOTE,ESP_MODULE_PANIER_CLASSE_SAISO,scoesb02.ESP_ENTETE_NOTE WHERE     (ESP_NOTE.CODE_MODULE= ESP_MODULE.CODE_MODULE  ) and (ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB ) and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl ) and (ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module ) and (ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and  ( ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB ) and ( ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL ) and ( ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE ) and (ESP_ENTETE_NOTE.CONFIRMATION='O') and ( esp_note.id_ens = esp_enseignant.id_ens (+)) and(ESP_NOTE.annee_deb=(select max(annee_deb) from societe)) and  (scoesb02.fs_is_student_autorised_new( ESP_NOTE.ID_ET) =1)  and ( id_et not in (select id_et from esp_inscription where annee_deb=(select max(annee_deb) from societe) and reserve='O'))) where ID_ET='" + _Id_et + "'   order by DESIGNATION";

                string cmdQuery = "select DESIGNATION,COEF,NOM_ENS,NOTE_CC,NOTE_TP,NOTE_EXAM,ABSENT_CC,ABSENT_TP,ABSENT_EXAM,EXISTE_NOTE_CC,EXISTE_NOTE_TP FROM( select  ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET, ESP_NOTE.CODE_CL, ESP_MODULE.DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,ESP_NOTE.NOTE_CC, ESP_NOTE.NOTE_TP,ESP_NOTE.NOTE_EXAM,ESP_NOTE.ABSENT_CC,ESP_NOTE.ABSENT_TP,ESP_NOTE.ABSENT_EXAM ,EXISTE_NOTE_CC,EXISTE_NOTE_TP,ESP_NOTE.NOTE_ESB_01,ESP_NOTE.note_esb_02 FROM ESP_ENSEIGNANT, ESP_MODULE, ESP_NOTE,ESP_MODULE_PANIER_CLASSE_SAISO,scoesb02.ESP_ENTETE_NOTE WHERE     (ESP_NOTE.CODE_MODULE= ESP_MODULE.CODE_MODULE  ) and (ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB ) and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl ) and (ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module ) and (ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and  ( ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB ) and ( ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL ) and ( ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE ) and (ESP_ENTETE_NOTE.CONFIRMATION='O') and ( esp_note.id_ens = esp_enseignant.id_ens (+)) and(ESP_NOTE.annee_deb=(select max(annee_deb) from societe))   and ( id_et not in (select id_et from esp_inscription where annee_deb=(select max(annee_deb) from societe) and reserve='O')))where ID_ET='" + _Id_et + "' and code_cl in('2-MKD-1','2-MKD-2','2-MKD-3','2-MDSI-1','2-MDSI-2','2-MDSI-3','2-MCCA','2-BA-1','2-BA-2','2-BA-3','3-LBC-BIS-1','3-LBC-BIS-2','3-LBC-BIS-3','3-LBC-BI-1')order by DESIGNATION";



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

public static List<NoteS1> GetListNotes2(string _Id_et)
{
    List<NoteS1> myList = null;

    using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
    {

        mySqlConnection.Open();

        string cmdQuery = "(select  DESIGNATION,NOM_ENS,COEF, DECODE(NOTE_CC,'','','Module non encore évalué' )NOTE_CC  ,DECODE(NOTE_TP,'','','Module non encore évalué' )NOTE_TP,DECODE(NOTE_EXAM,'','','Module non encore évalué' )NOTE_EXAM ,ABSENT_CC,ABSENT_TP,ABSENT_EXAM,EXISTE_NOTE_CC,EXISTE_NOTE_TP from  ESP_V_NOTE_SEM1 where id_et =:id_et and code_module not in(select code_module from (select t1.CODE_MODULE from ESP_V_NOTE_SEM1  t1 ,ESP_EVALUATION  t2, esp_module t3 where t1.ID_ET = t2.ID_ET and t1.id_et='"+_Id_et+"' and t2.CODE_MODULE = t1.CODE_MODULE and  t3.CODE_MODULE=t2.CODE_MODULE ))) UNION (select t1.DESIGNATION as DESIGNATION,t1.NOM_ENS as NOM_ENS ,t1.COEF as COEF  ,TO_CHAR(t1.NOTE_CC) as  NOTE_CC,TO_CHAR(t1.NOTE_TP) as NOTE_TP,TO_CHAR(t1.NOTE_EXAM) as  NOTE_EXAM,ABSENT_CC,ABSENT_TP,ABSENT_EXAM,EXISTE_NOTE_CC,EXISTE_NOTE_TP from ESP_V_NOTE_SEM1  t1 ,ESP_EVALUATION  t2, esp_module t3 where t1.ID_ET = t2.ID_ET and t1.id_et='"+_Id_et+"'and t2.CODE_MODULE = t1.CODE_MODULE and  t3.CODE_MODULE=t2.CODE_MODULE) ";
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