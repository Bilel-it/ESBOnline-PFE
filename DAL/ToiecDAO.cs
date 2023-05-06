using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using admiss;

namespace DAL
{
  public class ToiecDAO


    {
      #region sing
        static ToiecDAO instance;
        static Object locker = new Object();
        public static ToiecDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ToiecDAO();
                    }

                    return ToiecDAO.instance;
                }
            }

        }

        private ToiecDAO() { }
        #endregion sing

        #region Connexion
        OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString);
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
        #endregion

        public void Enreg_etud_FORMAt_test(string id_et, string _choix)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleCommand cmd1 = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO ESP_TEST_ETUD(ID_ET,TYPE_CHOIX,DATE_CHOIX,TYPE_TEST) VALUES ('" + id_et + "','" + _choix + "',to_date(sysdate,'dd/MM/yy'),'D')";
           // cmd1.CommandText = "INSERT INTO ESP_TEST_ETUD(ID_ET,TYPE_CHOIX,DATE_CHOIX) VALUES ('" + id_et + "','" + _choix + "',to_date(sysdate,'dd/MM/yy'))";
            cmd.ExecuteNonQuery();
           // cmd1.ExecuteNonQuery();

        }

        public bool verif_exist_note(string idet)
        {
            bool exist = false;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();



                //string cmdQuery = " select a.* from ESP_NOTE a, societe b where id_et='" + idet + "' and a.annee_deb=b.annee_deb ";
                string cmdQuery = " select a.* from ESP_NOTE a, societe b where id_et='" + idet + "' and a.annee_deb=b.annee ";

                OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);

                OracleDataReader MyReader = myCommandAbsence.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    exist = true;

                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
            }

            return exist;
        }
        public DataTable getrst(string id_etd)
        {
            //203JFT4020 203JFT0219   201JFT5622   201JFT3614



            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            // OracleCommand cmd = new OracleCommand("select  ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET,ESP_NOTE.CODE_CL, ESP_MODULE_PANIER_CLASSE_SAISO.DESIGNATION_NEW DESIGNATION, ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,ESP_NOTE.NOTE_CC,ESP_NOTE.NOTE_TP, ESP_NOTE.NOTE_EXAM,ESP_NOTE.ABSENT_CC, ESP_NOTE.ABSENT_TP, ESP_NOTE.ABSENT_EXAM, EXISTE_NOTE_CC, EXISTE_NOTE_TP FROM ESP_ENSEIGNANT, ESP_NOTE, ESP_MODULE_PANIER_CLASSE_SAISO, ESP_ENTETE_NOTE, esp_etat_nav,societe WHERE  esp_etat_nav.identifiant_etudiant=esp_note.id_et and esp_etat_nav.etat='T'     and (ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) and (ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB) and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl) and(ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module) and (ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and(ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and (ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) and (ESP_ENTETE_NOTE.CONFIRMATION = 'O') and  ESP_NOTE.ID_ET = '" + id_etd + "' and ESP_NOTE.ID_ET != '163JFT0108' and (esp_note.id_ens = esp_enseignant.id_ens(+))  and(ESP_NOTE.annee_deb = (select max(annee_deb) from societe)) and(id_et not in (select id_et from esp_inscription where annee_deb = (select max(annee_deb) from societe) and reserve = 'O'))  ORDER BY DESIGNATION", con);
            //08032021 OracleCommand cmd = new OracleCommand("select  ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET,ESP_NOTE.CODE_CL, ESP_MODULE_PANIER_CLASSE_SAISO.DESIGNATION_NEW DESIGNATION, ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,ESP_NOTE.NOTE_CC,ESP_NOTE.NOTE_TP, ESP_NOTE.NOTE_EXAM,ESP_NOTE.ABSENT_CC, ESP_NOTE.ABSENT_TP, ESP_NOTE.ABSENT_EXAM, EXISTE_NOTE_CC, EXISTE_NOTE_TP FROM ESP_ENSEIGNANT, ESP_NOTE, ESP_MODULE_PANIER_CLASSE_SAISO, ESP_ENTETE_NOTE,societe WHERE        (ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) and (ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB) and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl) and(ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module) and (ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and(ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and (ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) and (ESP_ENTETE_NOTE.CONFIRMATION = 'O') and  (scoesb02.FS_GET_SOLDE_ETUDIANT('"+id_etd+ "') <= (select MAX_VAL_CREDIT_ACCEPTE from SCOESP09.SOCIETE where annee_deb=2020)) and   ESP_NOTE.ID_ET = '" + id_etd + "' and ESP_NOTE.ID_ET != '163JFT0108' and (esp_note.id_ens = esp_enseignant.id_ens(+))  and(ESP_NOTE.annee_deb = (select max(annee_deb) from societe)) and(id_et not in (select id_et from esp_inscription where annee_deb = (select max(annee_deb) from societe) and reserve = 'O'))  ORDER BY DESIGNATION", con);
            //OracleCommand cmd = new OracleCommand("select  ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET,ESP_NOTE.CODE_CL, ESP_MODULE_PANIER_CLASSE_SAISO.DESIGNATION_NEW DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,ESP_NOTE.NOTE_CC,ESP_NOTE.NOTE_TP,ESP_NOTE.NOTE_EXAM,ESP_NOTE.ABSENT_CC, ESP_NOTE.ABSENT_TP, ESP_NOTE.ABSENT_EXAM, EXISTE_NOTE_CC, EXISTE_NOTE_TP FROM scoesb02.ESP_ENSEIGNANT, scoesb02.ESP_NOTE, scoesb02.esp_inscription,scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO, scoesb02.ESP_ENTETE_NOTE,scoesb02.societe WHERE esp_inscription.id_et=esp_note.id_et and esp_inscription.annee_deb=(select max(annee_deb) from societe) and (ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) and (ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB)and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl) and(ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module) and (ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and(ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and (ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)and (ESP_ENTETE_NOTE.CONFIRMATION = 'O') and  (scoesb02.FS_GET_SOLDE_ETUDIANT_2021('" + id_etd+ "') <= (select MAX_VAL_CREDIT_ACCEPTE from SCOESP09.SOCIETE where annee_deb=2020) or (esp_inscription.code_cl like '3%') or ( esp_inscription.MODE_RGLT='99' and esp_inscription.DATE_LIM_PROLONG_RGLT>=sysdate)) and   ESP_NOTE.ID_ET = '" + id_etd+ "' and ESP_NOTE.ID_ET != '163JFT0108'and (esp_note.id_ens = esp_enseignant.id_ens(+))  and(ESP_NOTE.annee_deb = (select max(annee_deb) from societe)) and(esp_note.id_et not in (select id_et from esp_inscription where annee_deb = (select max(annee_deb) from societe) and reserve = 'O')) ORDER BY DESIGNATION", con);
            // OracleCommand cmd = new OracleCommand("select  ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET,ESP_NOTE.CODE_CL, ESP_MODULE_PANIER_CLASSE_SAISO.DESIGNATION_NEW DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,ESP_NOTE.NOTE_CC,ESP_NOTE.NOTE_TP,ESP_NOTE.NOTE_EXAM,ESP_NOTE.ABSENT_CC, ESP_NOTE.ABSENT_TP, ESP_NOTE.ABSENT_EXAM, EXISTE_NOTE_CC, EXISTE_NOTE_TP FROM scoesb02.ESP_ENSEIGNANT, scoesb02.ESP_NOTE, scoesb02.esp_inscription,scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO, scoesb02.ESP_ENTETE_NOTE,scoesb02.societe WHERE esp_inscription.id_et=esp_note.id_et and esp_inscription.annee_deb=(select max(annee_deb) from societe) and (ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) and (ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB)and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl) and(ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module) and (ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and(ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and (ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)and (ESP_ENTETE_NOTE.CONFIRMATION = 'O') and  (scoesb02.FS_GET_SOLDE_ETUDIANT_2021('" + id_etd + "') <= (select MAX_VAL_CREDIT_ACCEPTE from SCOESP09.SOCIETE where annee_deb=2021)  or ( esp_inscription.MODE_RGLT='99' and esp_inscription.DATE_LIM_PROLONG_RGLT>=sysdate)) and   ESP_NOTE.ID_ET = '" + id_etd + "' and ESP_NOTE.ID_ET != '163JFT0108'and (esp_note.id_ens = esp_enseignant.id_ens(+))  and(ESP_NOTE.annee_deb = (select max(annee_deb) from societe)) and(esp_note.id_et not in (select id_et from esp_inscription where annee_deb = (select max(annee_deb) from societe) and reserve = 'O')) ORDER BY DESIGNATION", con);


            //modifie car on utilise le web srvice de m zouch
        // OracleCommand cmd = new OracleCommand("select distinct ESP_NOTE.CODE_MODULE,ESP_NOTE.note_esb_01,ESP_NOTE.NOTE_ESB_02, ESP_NOTE.ID_ET,ESP_NOTE.CODE_CL, ESP_MODULE_PANIER_CLASSE_SAISO.DESIGNATION_NEW DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,ESP_NOTE.NOTE_CC,ESP_NOTE.NOTE_TP,ESP_NOTE.NOTE_EXAM,ESP_NOTE.ABSENT_CC, ESP_NOTE.ABSENT_TP, ESP_NOTE.ABSENT_EXAM, EXISTE_NOTE_CC, EXISTE_NOTE_TP FROM scoesb02.ESP_ENSEIGNANT, scoesb02.ESP_NOTE, scoesb02.esp_inscription,scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO, scoesb02.ESP_ENTETE_NOTE,scoesb02.societe WHERE   scoesb02.societe.AFFICH_NOTE='O' and esp_inscription.id_et=esp_note.id_et and esp_inscription.annee_deb=(select max(annee_deb) from societe) and (ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) and (ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB)and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl) and(ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module) and (ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and(ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and (ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)and (ESP_ENTETE_NOTE.CONFIRMATION = 'O') and   ESP_NOTE.ID_ET = '" + id_etd + "' and ESP_NOTE.ID_ET != '163JFT0108'and (esp_note.id_ens = esp_enseignant.id_ens(+))  and(ESP_NOTE.annee_deb = (select max(annee_deb) from societe)) and(esp_note.id_et not in (select id_et from esp_inscription where annee_deb = (select max(annee_deb) from societe) and reserve = 'O')) and scoesb02.esp_inscription.code_cl<>'1-LBC%' and scoesb02.esp_inscription.code_cl<>'1-MDSI-4'and scoesb02.esp_inscription.code_cl<>'1-BA-4'and scoesb02.esp_inscription.code_cl<>'1-MKD-4' ORDER BY DESIGNATION", con);
           // OracleCommand cmd = new OracleCommand("select distinct DESIGNATION,COEF,NOM_ENS,NOTE_CC,NOTE_TP,NOTE_EXAM,NOTE_ESB_02,NOTE_ESB_01 FROM ( select  ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET, ESP_NOTE.CODE_CL, ESP_MODULE.DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,ESP_NOTE.NOTE_CC, ESP_NOTE.NOTE_TP,ESP_NOTE.NOTE_EXAM,ESP_NOTE.ABSENT_CC,ESP_NOTE.ABSENT_TP,ESP_NOTE.ABSENT_EXAM ,EXISTE_NOTE_CC,EXISTE_NOTE_TP,ESP_NOTE.NOTE_ESB_01,ESP_NOTE.note_esb_02 FROM ESP_ENSEIGNANT, ESP_MODULE, ESP_NOTE,ESP_MODULE_PANIER_CLASSE_SAISO,scoesb02.ESP_ENTETE_NOTE WHERE     (ESP_NOTE.CODE_MODULE= ESP_MODULE.CODE_MODULE  ) and (ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB ) and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl ) and (ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module ) and (ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and  ( ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB ) and ( ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL ) and ( ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE ) and (ESP_ENTETE_NOTE.CONFIRMATION='O') and ( esp_note.id_ens = esp_enseignant.id_ens (+)) and(ESP_NOTE.annee_deb=(select max(annee_deb) from societe))   and ( id_et not in (select id_et from esp_inscription where annee_deb=(select max(annee_deb) from societe) and reserve='O'))) where ID_ET='" + id_etd + "' and code_cl not like '1-LBC-%'  order by DESIGNATION", con);
           // OracleCommand cmd = new OracleCommand("select distinct DESIGNATION,COEF,NOM_ENS,NOTE_CC,NOTE_TP,NOTE_EXAM,NOTE_ESB_02,NOTE_ESB_01,MOYENNE FROM (select  moy.MOYENNE, ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET, ESP_NOTE.CODE_CL, ESP_MODULE.DESIGNATION, ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS, ESP_ENSEIGNANT.NOM_ENS, ESP_NOTE.NOTE_CC, ESP_NOTE.NOTE_TP, ESP_NOTE.NOTE_EXAM, ESP_NOTE.ABSENT_CC, ESP_NOTE.ABSENT_TP, ESP_NOTE.ABSENT_EXAM, EXISTE_NOTE_CC, EXISTE_NOTE_TP, ESP_NOTE.NOTE_ESB_01, ESP_NOTE.note_esb_02 FROM ESP_ENSEIGNANT, ESP_MODULE, ESP_NOTE, ESP_MODULE_PANIER_CLASSE_SAISO, scoesb02.ESP_ENTETE_NOTE, ESP_MOY_MODULE_ETUDIANT moy WHERE(moy.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and(moy.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(moy.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)   and(moy.ID_ET = ESP_NOTE.ID_ET)and(ESP_NOTE.CODE_MODULE = ESP_MODULE.CODE_MODULE) and(ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB) and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl) and(ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module)and(ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and(ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and(ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) and(ESP_ENTETE_NOTE.CONFIRMATION = 'O') and(esp_note.id_ens = esp_enseignant.id_ens(+)) and(ESP_NOTE.annee_deb = (select max(annee_deb) from societe))   and(esp_note.id_et not in (select id_et from esp_inscription where annee_deb = (select max(annee_deb) from societe) ))) where ID_ET = '" + id_etd + "' and code_cl not like '1-LBC-%' and code_cl <> '1-MDSI-%' and code_cl <> '1-BA-4' and code_cl <> '1-MKD-4' and code_cl<> '3-LBC-BI-2' and code_cl not like '1DSI-AS1%' and code_cl not like '2-DSI-A3%' order by DESIGNATION", con);
           // OracleCommand cmd = new OracleCommand("select distinct ID_ET,CODE_CL,DESIGNATION,COEF,NOM_ENS,NOTE_CC,NOTE_TP,NOTE_EXAM,NOTE_ESB_02,NOTE_ESB_01,MOYENNE FROM(select  moy.MOYENNE, ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET, ESP_NOTE.CODE_CL, ESP_MODULE.DESIGNATION, ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS, ESP_ENSEIGNANT.NOM_ENS, ESP_NOTE.NOTE_CC, ESP_NOTE.NOTE_TP, ESP_NOTE.NOTE_EXAM, ESP_NOTE.ABSENT_CC, ESP_NOTE.ABSENT_TP, ESP_NOTE.ABSENT_EXAM, EXISTE_NOTE_CC, EXISTE_NOTE_TP, ESP_NOTE.NOTE_ESB_01, ESP_NOTE.note_esb_02 FROM ESP_ENSEIGNANT, ESP_MODULE, ESP_NOTE, ESP_MODULE_PANIER_CLASSE_SAISO, scoesb02.ESP_ENTETE_NOTE, ESP_MOY_MODULE_ETUDIANT moy WHERE(moy.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and(moy.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(moy.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)   and(moy.ID_ET = ESP_NOTE.ID_ET)and(ESP_NOTE.CODE_MODULE = ESP_MODULE.CODE_MODULE) and(ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB) and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl) and(ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module)and(ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and(ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and(ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) and(ESP_ENTETE_NOTE.CONFIRMATION = 'O') and(esp_note.id_ens = esp_enseignant.id_ens(+)) and(ESP_NOTE.annee_deb = (select max(annee_deb) from societe)) and(esp_note.id_et not in (select id_et from esp_inscription where annee_deb=(select max(annee_deb) from societe) and reserve='O'))) where ID_ET = '" + id_etd + "' and code_cl not like '1-LBC-%' and code_cl <> '1-MDSI-%' and code_cl <> '1-BA-4' and code_cl <> '1-MKD-4' and code_cl<> '3-LBC-BI-2' and code_cl not like '1DSI-AS1%' and code_cl not like '2-DSI-A3%' order by DESIGNATION", con);
            //10/03/2022 
            //OracleCommand cmd = new OracleCommand("select distinct ID_ET,CODE_CL,DESIGNATION,COEF,NOM_ENS,NOTE_CC,NOTE_TP,NOTE_EXAM,NOTE_ESB_02,NOTE_ESB_01,MOYENNE FROM(select  moy.MOYENNE, ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET, ESP_NOTE.CODE_CL, ESP_MODULE.DESIGNATION, ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS, ESP_ENSEIGNANT.NOM_ENS, ESP_NOTE.NOTE_CC, ESP_NOTE.NOTE_TP, ESP_NOTE.NOTE_EXAM, ESP_NOTE.ABSENT_CC, ESP_NOTE.ABSENT_TP, ESP_NOTE.ABSENT_EXAM, EXISTE_NOTE_CC, EXISTE_NOTE_TP, ESP_NOTE.NOTE_ESB_01, ESP_NOTE.note_esb_02 FROM ESP_ENSEIGNANT, ESP_MODULE, ESP_NOTE, ESP_MODULE_PANIER_CLASSE_SAISO, scoesb02.ESP_ENTETE_NOTE, ESP_MOY_MODULE_ETUDIANT moy WHERE(moy.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and(moy.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(moy.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)   and(moy.ID_ET = ESP_NOTE.ID_ET)and(ESP_NOTE.CODE_MODULE = ESP_MODULE.CODE_MODULE) and(ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB) and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl) and(ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module)and(ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and(ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and(ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) and(ESP_ENTETE_NOTE.CONFIRMATION = 'O') and(esp_note.id_ens = esp_enseignant.id_ens(+)) and(ESP_NOTE.annee_deb = (select max(annee_deb) from societe)) and(esp_note.id_et not in (select id_et from esp_inscription where annee_deb=(select max(annee_deb) from societe) and reserve='O'))) where ID_ET = '" + id_etd + "' and code_cl <> '1-MDSI-%' and code_cl <> '1-BA-4' and code_cl <> '1-MKD-4' and code_cl<> '3-LBC-BI-2' and code_cl not like '1DSI-AS1%' and code_cl not like '2-DSI-A3%' order by DESIGNATION", con);

            //06/04/2022
            OracleCommand cmd = new OracleCommand("select distinct ID_ET,CODE_CL,DESIGNATION,COEF,NOM_ENS,NOTE_CC,NOTE_TP,NOTE_EXAM,NOTE_ESB_02,NOTE_ESB_01,MOYENNE FROM(select  moy.MOYENNE, ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET, ESP_NOTE.CODE_CL, ESP_MODULE.DESIGNATION, ESP_MODULE_PANIER_CLASSE_SAISO.COEF,ESP_ENSEIGNANT.ID_ENS, ESP_ENSEIGNANT.NOM_ENS, ESP_NOTE.NOTE_CC, ESP_NOTE.NOTE_TP, ESP_NOTE.NOTE_EXAM, ESP_NOTE.ABSENT_CC, ESP_NOTE.ABSENT_TP,ESP_NOTE.ABSENT_EXAM, EXISTE_NOTE_CC, EXISTE_NOTE_TP, ESP_NOTE.NOTE_ESB_01, ESP_NOTE.note_esb_02 FROM ESP_ENSEIGNANT, ESP_MODULE, ESP_NOTE,ESP_MODULE_PANIER_CLASSE_SAISO, scoesb02.ESP_ENTETE_NOTE, ESP_MOY_MODULE_ETUDIANT moy WHERE(moy.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and(moy.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(moy.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)  and(moy.ID_ET = ESP_NOTE.ID_ET) and(ESP_NOTE.CODE_MODULE = ESP_MODULE.CODE_MODULE) and(ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB) and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl) and(ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module) and(ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and(ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and(ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) and(ESP_ENTETE_NOTE.CONFIRMATION = 'O') and(esp_note.id_ens = esp_enseignant.id_ens(+)) and(ESP_NOTE.annee_deb = (select max(annee_deb) from societe)) and(esp_note.id_et not in (select id_et from esp_inscription where annee_deb=(select max(annee_deb) from societe) and reserve='O'))) where ID_ET = '" + id_etd + "' order by DESIGNATION ", con);
            //ici pour tester

            //OracleCommand cmd = new OracleCommand("select  ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET,ESP_NOTE.CODE_CL, ESP_MODULE_PANIER_CLASSE_SAISO.DESIGNATION_NEW DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,ESP_NOTE.NOTE_CC,ESP_NOTE.NOTE_TP,ESP_NOTE.NOTE_EXAM,ESP_NOTE.ABSENT_CC, ESP_NOTE.ABSENT_TP, ESP_NOTE.ABSENT_EXAM, EXISTE_NOTE_CC, EXISTE_NOTE_TP FROM scoesb02.ESP_ENSEIGNANT, scoesb02.ESP_NOTE, scoesb02.esp_inscription,scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO, scoesb02.ESP_ENTETE_NOTE,scoesb02.societe WHERE   esp_inscription.id_et=esp_note.id_et and esp_inscription.annee_deb=(select max(annee) from societe) and (ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) and (ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB)and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl) and(ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module) and (ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and(ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and (ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)and (ESP_ENTETE_NOTE.CONFIRMATION = 'O') and   ESP_NOTE.ID_ET = '" + id_etd + "' and (esp_note.id_ens = esp_enseignant.id_ens(+))  and(ESP_NOTE.annee_deb = (select max(annee) from societe)) and(esp_note.id_et not in (select id_et from esp_inscription where annee_deb = (select max(annee) from societe) and reserve = 'O')) ORDER BY DESIGNATION", con);
            //sans solde faux
            // OracleCommand cmd = new OracleCommand("select  ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET,ESP_NOTE.CODE_CL, ESP_MODULE_PANIER_CLASSE_SAISO.DESIGNATION_NEW DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,ESP_NOTE.NOTE_CC,ESP_NOTE.NOTE_TP,ESP_NOTE.NOTE_EXAM,ESP_NOTE.ABSENT_CC, ESP_NOTE.ABSENT_TP, ESP_NOTE.ABSENT_EXAM, EXISTE_NOTE_CC, EXISTE_NOTE_TP FROM scoesb02.ESP_ENSEIGNANT, scoesb02.ESP_NOTE,scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO,scoesb02.ESP_ENTETE_NOTE,scoesb02.societe WHERE scoesb02.societe.AFFICH_NOTE='O' and ESP_NOTE.id_et not in ('201JMT1951','201JMT1907','201JMT1913','201JMT1411','201JMT2156','201JFT3503','201JFT2150','201JFT4130','201JMT4591','201JMT1775','201JMT4045','201JMT3486','201JMT1742','201JMT1757','201JMT2687','201JMT0069','201JMT2165','201JMT3040','201JMT3824','201JFT5622','201JMT1731','201JMT3231','201JMT3326','201JMT3667','201JMT4716','201JFT1848','201JFT3554','201JFT3206','201JMT3469','201JFT3391','201JMT3903','201JMT1749','201JMT4505','201JFT5253','201JMT2442','201JMT2185','201JFT4364','201JMT4968','201JMT4519','201JFT3344','201JMT5444','201JFT0245','201JMT1342','201JFT4061','201JMT2028','201JMT3353','201JMT2245','201JMT3416','201JMT2591','201JMT3341','201JMT1993','201JFT4974','201JMT1729','201JMT2611','201JMT2558','201JMT2070','201JFT3016','201JMT4262','201JMT2348','201JMT2935','201JMT4151','201JMT4641','201JMT2794','201JMT4796','201JMT4671','201JMT3852','201JMT4060','201JMT5316','201JMT0829','201JMT0500','201JFT1996','201JMT0115','201JMT0198','201JMT0182','201JMT0181','201JMT0256','201JMT1960','201JMT3140','201JMT2304','201JMT4792','201JMT1764','201JMT1646','201JMT4882','201JME5715','201JMT1940','201JMT1532','201JMT1096','201JMT2013','201JMT2036','201JMT1089','201JMT1870','201JMT2203','201JMT4119','201JFT5389','201JFT4080','201JMT2597','201JMT3158','201JMT2463','201JMT3274','201JMT4549','201JMT3280','201JMT2166','201JMT3594','201JMT3404','201JFE5507','201JMT2723','201JFT3614','201JFT3677','201JMT3032','201JMT0103','201JMT2956','201JMT3578','201JMT2993','201JMT2866','201JMT2902','201JMT3049','201JMT3966','201JMT3963','201JMT3971','201JMT4253','201JMT5026','201JMT3930','201JMT4205','201JMT3919','201JFT4745','201JFT4902','201JMT3961','201JMT3830','201JFT4291','201JMT2895','201JMT3785','201JMT3806','201JFT4150','201JMT3861','201JMT5147','201JMT3638','201JFT4089','201JMT3818','201JMT4489','201JMT1990','201JFT0297','201JMT4710','201JMT4460','201JFT0478','201JMT4487','201JMT4328','201JFT3056','201JMT4414','201JMT4358','201JMT4419','201JMT0027','201JMT2067','201JFT1831','201JFT4317','201JMT1837','201JFT4790','201JMT1399','201JFT1779','201JMT3095','201JFT1467','201JMT1546','201JFT3051','201JMT4597','201JMT4765','201JMT4848','201JMT3940','201JMT3571','201JMT5600','201JMT4104','201JMT2733','201JMT1844','201JMT1477','201JMT3427','201JFT1974','201JMT1263','201JMT0075','201JMT2576','201JMT0825','201JMT2078','201JMT2040','201JMT2407','201JMT2859','201JMT0144','201JMT3104','201JMT3105','201JFT2568','201JMT4819','201JMT4373','201JMT2435','201JMT2656','201JMT1947','201JMT3403','201JMT3298','201JMT3635','201JFT1782','201JFT1609','201JMT3236','201JMT2194','201JMT2022','201JFT4040','201JMT3071','201JMT4215','201JMT3264','201JMT2492','201JMT3647','201JMT1898','201JFT2629','201JFT3699','203JMT5461','203JFT2837','203JMT1252  202SMT2581','203JMT1029','203JMT2386','203JMT5140','203JMT1414','203JMT5492','203JFT1155','203JMT4815','203JMT0935','203JMT1347','203JMT2354','203JMT2292','203JMT0314','203JMT2819','203JMT1276','203JMT0834','203JMT0870','203JFT5530','203JMT5305','203JMT1773','203JFT2704','203JMT0807','203JMT0918','203JFT5342','203JMT1651','203JMT5074','203JMT4851','203JMT0369','203JMT2029','203JMT1861','203JMT1997','203JMT1086','203JFT2345','203JMT0900','203JMT1294','203JFT0219','203JFT1468','203JMT5301','203JFT5462','203JFT3660','203JMT2240','203JMT1768','203JMT2269','203JFT0555','203JFT2843','203JMT4978','203JMT1172','203JFT0907','203JFT0862','203JFT0410','203JMT1424','203JMT2209','203JFT5277','203JMT2235','203JMT5001','203JMT0155','203JFT1231','203JMT2059','203JMT0737','203JMT5516','203JFT0272','203JMT1278','203JMT0933','203JMT4552','203JMT4213','203JMT1217','203JFT2845','203JMT0746','203JMT2513','203JMT0938','203JFT3617','203JFT3595','203JFT3303','203JFT3572','203JME2596','203JFT3294','203JMT4822','203JMT4234','203JMT4619','203JMT3557','203JMT3582','203JMT2533','203JMT3408','203JFT4167','203JFT4585','203JMT3202 204JMT4443','203JMT3795','203JMT2714','203JMT3093','203JMT1879','203JMT3060','203JMT1885','203JFT3038','203JMT1408','203JFT3177','201JMT2901','203JMT1449','203JFT2759','203JMT1415','203JMT0496','203JMT1877','203JFT2807','203JFT2887','203JMT1098','203JMT1101','203JFT0813','203JFT1572','203JFT3967','203JMT1440','203JFT0006','203JFT2706','203JFT0141','203JFT4935','203JFT3528','203JMT3584','203JFT3413','203JMT4886   204JFT1097','203JMT2721','203JMT0810','203JMT2584','203JMT2791','203JMT0441','203JMT0074','203JFT1561','203JMT1001','203JMT2637','203JMT1581','203JMT1510','203JMT2616','203JMT2969','203JMT0064','203JMT2055','203JMT1039','203JMT4888','203JMT4996','203JMT4407','203JMT1037','201SMT0397','203JMT3219','203JFT4931','203JFT2777','203JMT1147','203JMT5289','203JFT4020','203JFT2470','203JFT2594','203JMT4637','203JFT3286','203JFT3319','203JFT4235','203JMT1502','203JFT2098','203JMT5040','203JFT4063','203JMT3536','203JFT1650','203JMT2206','203JMT4536','203JMT3188','203JMT5064','203JMT2566','203JMT5298','203JFT0035','203JFT1388','203JMT4425','203JMT4704 204JMT3352','203JMT4430') and esp_inscription.id_et=esp_note.id_et and esp_inscription.annee_deb=(select max(annee_deb) from societe) and (ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) and (ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB)and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl) and(ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module) and (ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and(ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and (ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)and (ESP_ENTETE_NOTE.CONFIRMATION = 'O')   and  ESP_NOTE.ID_ET = '" + id_etd + "'  and ESP_NOTE.ID_ET != '163JFT0108'and (esp_note.id_ens = esp_enseignant.id_ens(+))  and(ESP_NOTE.annee_deb = (select max(annee_deb)from societe))and(esp_note.id_et not in (select id_et from esp_inscription where annee_deb = (select max(annee_deb) from societe) and reserve = 'O'))  ORDER BY DESIGNATION", con);
            //sans solde 
            //OracleCommand cmd = new OracleCommand("select  ESP_NOTE.CODE_MODULE, ESP_NOTE.ID_ET,ESP_NOTE.CODE_CL, ESP_MODULE_PANIER_CLASSE_SAISO.DESIGNATION_NEW DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,ESP_NOTE.NOTE_CC,ESP_NOTE.NOTE_TP,ESP_NOTE.NOTE_EXAM,ESP_NOTE.ABSENT_CC, ESP_NOTE.ABSENT_TP, ESP_NOTE.ABSENT_EXAM, EXISTE_NOTE_CC, EXISTE_NOTE_TP FROM scoesb02.ESP_ENSEIGNANT, scoesb02.ESP_NOTE,scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO,scoesb02.ESP_ENTETE_NOTE,scoesb02.societe WHERE scoesb02.societe.AFFICH_NOTE='O' and ESP_NOTE.id_et not in ('201JMT1951','201JMT1907','201JMT1913','201JMT1411','201JMT2156','201JFT3503','201JFT2150','201JFT4130','201JMT4591','201JMT1775','201JMT4045','201JMT3486','201JMT1742','201JMT1757','201JMT2687','201JMT0069','201JMT2165','201JMT3040','201JMT3824','201JFT5622','201JMT1731','201JMT3231','201JMT3326','201JMT3667','201JMT4716','201JFT1848','201JFT3554','201JFT3206','201JMT3469','201JFT3391','201JMT3903','201JMT1749','201JMT4505','201JFT5253','201JMT2442','201JMT2185','201JFT4364','201JMT4968','201JMT4519','201JFT3344','201JMT5444','201JFT0245','201JMT1342','201JFT4061','201JMT2028','201JMT3353','201JMT2245','201JMT3416','201JMT2591','201JMT3341','201JMT1993','201JFT4974','201JMT1729','201JMT2611','201JMT2558','201JMT2070','201JFT3016','201JMT4262','201JMT2348','201JMT2935','201JMT4151','201JMT4641','201JMT2794','201JMT4796','201JMT4671','201JMT3852','201JMT4060','201JMT5316','201JMT0829','201JMT0500','201JFT1996','201JMT0115','201JMT0198','201JMT0182','201JMT0181','201JMT0256','201JMT1960','201JMT3140','201JMT2304','201JMT4792','201JMT1764','201JMT1646','201JMT4882','201JME5715','201JMT1940','201JMT1532','201JMT1096','201JMT2013','201JMT2036','201JMT1089','201JMT1870','201JMT2203','201JMT4119','201JFT5389','201JFT4080','201JMT2597','201JMT3158','201JMT2463','201JMT3274','201JMT4549','201JMT3280','201JMT2166','201JMT3594','201JMT3404','201JFE5507','201JMT2723','201JFT3614','201JFT3677','201JMT3032','201JMT0103','201JMT2956','201JMT3578','201JMT2993','201JMT2866','201JMT2902','201JMT3049','201JMT3966','201JMT3963','201JMT3971','201JMT4253','201JMT5026','201JMT3930','201JMT4205','201JMT3919','201JFT4745','201JFT4902','201JMT3961','201JMT3830','201JFT4291','201JMT2895','201JMT3785','201JMT3806','201JFT4150','201JMT3861','201JMT5147','201JMT3638','201JFT4089','201JMT3818','201JMT4489','201JMT1990','201JFT0297','201JMT4710','201JMT4460','201JFT0478','201JMT4487','201JMT4328','201JFT3056','201JMT4414','201JMT4358','201JMT4419','201JMT0027','201JMT2067','201JFT1831','201JFT4317','201JMT1837','201JFT4790','201JMT1399','201JFT1779','201JMT3095','201JFT1467','201JMT1546','201JFT3051','201JMT4597','201JMT4765','201JMT4848','201JMT3940','201JMT3571','201JMT5600','201JMT4104','201JMT2733','201JMT1844','201JMT1477','201JMT3427','201JFT1974','201JMT1263','201JMT0075','201JMT2576','201JMT0825','201JMT2078','201JMT2040','201JMT2407','201JMT2859','201JMT0144','201JMT3104','201JMT3105','201JFT2568','201JMT4819','201JMT4373','201JMT2435','201JMT2656','201JMT1947','201JMT3403','201JMT3298','201JMT3635','201JFT1782','201JFT1609','201JMT3236','201JMT2194','201JMT2022','201JFT4040','201JMT3071','201JMT4215','201JMT3264','201JMT2492','201JMT3647','201JMT1898','201JFT2629','201JFT3699','203JMT5461','203JFT2837','203JMT1252  202SMT2581','203JMT1029','203JMT2386','203JMT5140','203JMT1414','203JMT5492','203JFT1155','203JMT4815','203JMT0935','203JMT1347','203JMT2354','203JMT2292','203JMT0314','203JMT2819','203JMT1276','203JMT0834','203JMT0870','203JFT5530','203JMT5305','203JMT1773','203JFT2704','203JMT0807','203JMT0918','203JFT5342','203JMT1651','203JMT5074','203JMT4851','203JMT0369','203JMT2029','203JMT1861','203JMT1997','203JMT1086','203JFT2345','203JMT0900','203JMT1294','203JFT0219','203JFT1468','203JMT5301','203JFT5462','203JFT3660','203JMT2240','203JMT1768','203JMT2269','203JFT0555','203JFT2843','203JMT4978','203JMT1172','203JFT0907','203JFT0862','203JFT0410','203JMT1424','203JMT2209','203JFT5277','203JMT2235','203JMT5001','203JMT0155','203JFT1231','203JMT2059','203JMT0737','203JMT5516','203JFT0272','203JMT1278','203JMT0933','203JMT4552','203JMT4213','203JMT1217','203JFT2845','203JMT0746','203JMT2513','203JMT0938','203JFT3617','203JFT3595','203JFT3303','203JFT3572','203JME2596','203JFT3294','203JMT4822','203JMT4234','203JMT4619','203JMT3557','203JMT3582','203JMT2533','203JMT3408','203JFT4167','203JFT4585','203JMT3202 204JMT4443','203JMT3795','203JMT2714','203JMT3093','203JMT1879','203JMT3060','203JMT1885','203JFT3038','203JMT1408','203JFT3177','201JMT2901','203JMT1449','203JFT2759','203JMT1415','203JMT0496','203JMT1877','203JFT2807','203JFT2887','203JMT1098','203JMT1101','203JFT0813','203JFT1572','203JFT3967','203JMT1440','203JFT0006','203JFT2706','203JFT0141','203JFT4935','203JFT3528','203JMT3584','203JFT3413','203JMT4886   204JFT1097','203JMT2721','203JMT0810','203JMT2584','203JMT2791','203JMT0441','203JMT0074','203JFT1561','203JMT1001','203JMT2637','203JMT1581','203JMT1510','203JMT2616','203JMT2969','203JMT0064','203JMT2055','203JMT1039','203JMT4888','203JMT4996','203JMT4407','203JMT1037','201SMT0397','203JMT3219','203JFT4931','203JFT2777','203JMT1147','203JMT5289','203JFT4020','203JFT2470','203JFT2594','203JMT4637','203JFT3286','203JFT3319','203JFT4235','203JMT1502','203JFT2098','203JMT5040','203JFT4063','203JMT3536','203JFT1650','203JMT2206','203JMT4536','203JMT3188','203JMT5064','203JMT2566','203JMT5298','203JFT0035','203JFT1388','203JMT4425','203JMT4704 204JMT3352','203JMT4430')   and esp_note.annee_deb=(select max(annee_deb) from societe) and (ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE) and (ESP_NOTE.ANNEE_DEB = ESP_ENTETE_NOTE.ANNEE_DEB) and(ESP_NOTE.code_cl = ESP_ENTETE_NOTE.code_cl) and(ESP_NOTE.code_module = ESP_ENTETE_NOTE.code_module) and (ESP_NOTE.semestre = ESP_ENTETE_NOTE.semestre) and(ESP_NOTE.ANNEE_DEB = ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB) and (ESP_NOTE.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL) and(ESP_NOTE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)and (ESP_ENTETE_NOTE.CONFIRMATION = 'O')   and  ESP_NOTE.ID_ET = '"+id_etd+"'  and ESP_NOTE.ID_ET != '163JFT0108'and (esp_note.id_ens = esp_enseignant.id_ens(+)) and(ESP_NOTE.annee_deb = (select max(annee_deb)from societe))and(esp_note.id_et not in (select id_et from esp_inscription where annee_deb = (select max(annee_deb) from societe) and reserve = 'O'))  ORDER BY DESIGNATION", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }

        //enreg test
        public void Enreg_etud_test(string id_et, string _choix)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();

            OracleCommand cmd1 = conn.CreateCommand();
            cmd1.CommandText = "INSERT INTO ESP_TEST_ETUD(ID_ET,TYPE_CHOIX,DATE_CHOIX) VALUES ('" + id_et + "','" + _choix + "',to_date(sysdate,'dd/MM/yy'))";

            cmd1.ExecuteNonQuery();

        }
        public DataTable Rep_nouv_inscrits()
        {
            DataTable dt = new DataTable();
            string source = AppConfiguration.ConnectionString;
            OracleConnection con = new OracleConnection(source);
            con.Open();
            //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


            OracleCommand cmd = new OracleCommand(" select substr(code_cl,1,1) Niveau ,sum(TIC) TIC ,sum(EM) EM,sum(GC) GC,sum(TIC)+sum(EM)+sum(GC) Total from (select a.code_cl,(case when LOWER(specialite)  like 'info' then 1 else 0 end) TIC,(case when lower(specialite)  like 'em' then 1 else 0 end) EM,(case when LOWER(specialite)  like 'gc' then 1 else 0 end) GC from scoesb02.ESP_INSCRIPTION a  left join classes1516 c on a.code_cl = c.code_cl left join ESP_etudiant e on a.id_et=e.id_et where a.annee_deb='2015' and lower(e.etat) ='a' and lower( a.code_cl) between '1' and '5t'and a.id_et like '15%')group by substr(code_cl,1,1) order by Niveau", con);
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }
        public int UpdatE_choix(string _id_etud, string choix)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE ESP_TEST_ETUD SET TYPE_CHOIX='" + choix + "' where ID_ET='" + _id_etud + "'", cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }


        public string nbCondidasteste()
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection("DATA SOURCE=  ;PERSIST SECURITY INFO=True;USER ID=SCO_admis1415;PASSWORD=sco_admis1415 "))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT count(*) from ESP_etudiant where score_entretien is not null  and id_et like '15%'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidasteste2()
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT count(*) FROM esp_etudiant where DATEENTR is not null and  TO_DATE(  dateentr, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American')<  ( to_date(sysdate,'dd-MM-yy' ) ) and id_et like '15%'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidatsInscritad(DateTime dateinsc)
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT count(*) from ESP_etudiant where DATE_saisie<=to_date('" + dateinsc.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and id_et like '14%' ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
      //update toic to N:
        public int UpdatEPREPTOICTONo(string _id_etud,string annee)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE ESP_INSCRIPTION SET PREP_TOEIC='' where ID_ET='" + _id_etud + "' and annee_deb='"+annee+"'", cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int UpdatETOICToNo(string _id_etud)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE ESP_INSCRIPTION SET TEST_TOEIC='' where ID_ET='" + _id_etud + "' AND ANNee_deb='2015'", cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }
      

        public int UpdatEPREPTOIC(string _id_etud,string annee)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE ESP_INSCRIPTION SET PREP_TOEIC='2' where ID_ET='" + _id_etud + "' and annee_deb='" + annee + "'", cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int UpdatETOIC(string _id_etud)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE esp_test_etud set SET TEST_TOEIC='1' where ID_ET='" + _id_etud + "' and annee_deb='2015'", cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }
        public int UpdatETOICenseign(string _id_ens)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE ESP_enseignant SET ESP_enseignant.TEST_TOEIC='O' where ESP_enseignant.ID_ENS='"+_id_ens+"'", cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int UpdatEPreparationTOICenseign(string _id_ens)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE ESP_enseignant SET ESP_enseignant.prep_TOEIC='O' where ESP_enseignant.ID_ENS='" + _id_ens + "'", cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }


        public int UpdatETOICToNoenseig(string _id_ens)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE ESP_enseignant SET ESP_enseignant.TEST_TOEIC='N' where ESP_enseignant.ID_ENS='" + _id_ens + "'", cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int UpdatEPREPTOICToNoenseig(string _id_ens)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE ESP_enseignant SET ESP_enseignant.prep_TOEIC='N' where ESP_enseignant.ID_ENS='" + _id_ens + "'", cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }
        public int UpdateEtatInsctestniv(string _id_etud)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE ESP_INSCRIPTION SET ETAT_INS_TEST_NIV='Y' where ID_ET='" + _id_etud + "' and annee_deb='2015'" , cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }

        public string returnCL(string id_edt)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT CODE_CL from ESP_INSCRIPTION WHERE ESP_INSCRIPTION.annee_deb='2015'  and ESP_INSCRIPTION.ID_ET='" + id_edt + "'  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public void Enreg_inscriTest_Lng(DateTime _DATE_TEST_FR, DateTime _DATE_TEST_ANG, string id_et, string annee_deb)
        {

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            // cmd.CommandText = "INSERT INTO ESP_INSCRIPTION(DATE_TEST_FR,DATE_TEST_ANG) VALUES (to_date('" + _DATE_TEST_FR.ToString() + "', 'dd/mm/yyyy hh24:mi:ss'),to_date('" + _DATE_TEST_ANG.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') where ESP_INSCRIPTION.CODE_CL='" + code_cl + "' and ESP_INSCRIPTION.id_et='" + id_et + "' andESP_INSCRIPTION.annee_deb='"+annee_deb+"')";
            cmd.CommandText = "update ESP_INSCRIPTION set  DATE_TEST_FR  =to_date('" + _DATE_TEST_FR.ToString() + "', 'dd/mm/yyyy hh24:mi:ss'),DATE_TEST_ANG=to_date('" + _DATE_TEST_ANG.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') where ESP_INSCRIPTION.id_et='" + id_et + "' and ESP_INSCRIPTION.annee_deb='" + annee_deb + "' and ESP_INSCRIPTION.CODE_cl LIKE '5%' ";
            //

            // cmd.CommandText = "insert into ESP_INSCRIPTION  (DATE_TEST_FR,DATE_TEST_ANG)values(  to_date('" + _DATE_TEST_FR.ToString() + "', 'dd/mm/yyyy hh24:mi:ss'),to_date('" + _DATE_TEST_ANG.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') where ( select id_et,annee_deb from ESP_INSCRIPTION where ESP_INSCRIPTION.id_et='" + id_et + "' and ESP_INSCRIPTION.annee_deb='" + annee_deb + "')";


            cmd.ExecuteNonQuery();
          
        }
        public string selectEtatTest( string id_edt)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select ETAT_INS_TEST_NIV from esp_inscription where esp_inscription.id_et='" + id_edt + "' and annee_deb='2015'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }
        public string selectEtatTTOIEC(string id_edt)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select TYPE_CHOIX from ESP_TEST_ETUD,esp_inscription where esp_inscription.id_et=ESP_TEST_ETUD.id_et and ESP_TEST_ETUD.id_et='" + id_edt + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }



        public string selectEtatTTOIECENS(string id_ens)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select TYPE_CHOIX from ESP_TEST_ENS,esp_ENSEIGNANT where esp_ENSEIGNANT.id_eNS=ESP_TEST_ENS.id_eNS and ESP_TEST_ENS.id_ens='" + id_ens + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }




        public string selectEtatTPREPTOIEC(string id_edt,string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select PREP_TOEIC from esp_inscription where esp_inscription.id_et='" + id_edt + "' and annee_deb='" + annee + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }
       
   //enseign
        public string selectEtatTTOIECenseign(string id_ens)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select TEST_TOEIC from esp_enseignant where esp_enseignant.id_ens='" + id_ens + "' ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }

        public string selectPreparationEtatTTOIECenseign(string id_ens)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select PREP_TOEIC from esp_enseignant where esp_enseignant.id_ens='" + id_ens + "' ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }

        public DataTable Afficher_date_exam_etud(string id_etd)
        {

            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand(" select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,DATE_TEST_FR,DATE_TEST_ANG,code_cl from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and esp_etudiant.id_et='"+id_etd+"' ", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }


      //Afficher les etudiants qui inscri meme date
        public DataTable Afficher_date_exam_etud_mamadate(DateTime date)
        {

            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand(" select distinct ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,DATE_TEST_FR,DATE_TEST_ANG,code_cl from ESP_INSCRIPTION,esp_etudiant,societe,ESP_TOEIC_NB where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb  and DATE_TEST_FR=DATE_TEST_ANG and DATE_TEST_FR=to_date('" + date.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') AND CODE_CL like '5%'", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }



        public DataTable Affich_ETUD_NULL(DateTime date)
        {

            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand(" select NIV_ACQUIS_FRANCAIS,NIV_ACQUIS_ANGLAIS from esp_inscription where code_cl like '5%' and annee_deb='2015'", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }

        public DataTable Afficher_date_exam_etudfrfr(string id_etd)
        {

            DataTable dt = new DataTable();
           
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand(" select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,DATE_TEST_FR,code_cl from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and esp_etudiant.id_et='" + id_etd + "' AND CODE_CL LIKE '5%'", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }

        public DataTable Afficher_date_exam_etudangang(string id_etd)
        {

            DataTable dt = new DataTable();
            
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand(" select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,DATE_TEST_ang,code_cl from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and esp_etudiant.id_et='" + id_etd + "' AND CODE_CL LIKE '5%' ", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }
        public string getANNEEDEBs()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT ANNEE_DEB FROM SOCIETE";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string getAnneeFiN()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT ANNEE_FIN FROM SOCIETE";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public DataTable bindDATEexaM()
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
           // OracleCommand cmd = new OracleCommand("SELECT DATETEST,NB_CONDIDATS_ANG,NBMAX FROM ESP_TOEIC_NB  where NB_CONDIDATS_ANG<NBMAX order by DATETEST", con);
           // OracleCommand cmd = new OracleCommand("SELECT DATETEST,NB_CONDIDATS,NBMAX FROM ESP_TOEIC_NB  WHERE NB_CONDIDATS<NBMAX AND NIV_ACQUIS_ANGLAIS<>'B2' and  NIV_ACQUIS_FRANCAIS<>'B2' order by DATETEST", con);

            OracleCommand cmd = new OracleCommand("SELECT DATETEST FROM ESP_TOEIC_NB WHERE NB_CONDIDATS_FR<NBMAX ",con);
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable bindDATEexaMANG()
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            // OracleCommand cmd = new OracleCommand("SELECT DATETEST,NB_CONDIDATS_ANG,NBMAX FROM ESP_TOEIC_NB  where NB_CONDIDATS_ANG<NBMAX order by DATETEST", con);
            // OracleCommand cmd = new OracleCommand("SELECT DATETEST,NB_CONDIDATS,NBMAX FROM ESP_TOEIC_NB  WHERE NB_CONDIDATS<NBMAX AND NIV_ACQUIS_ANGLAIS<>'B2' and  NIV_ACQUIS_FRANCAIS<>'B2' order by DATETEST", con);

            OracleCommand cmd = new OracleCommand("SELECT DATETEST FROM ESP_TOEIC_NB WHERE NB_CONDIDATS_ang<NBMAX", con);
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable bindDATEx()
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            // OracleCommand cmd = new OracleCommand("SELECT DATETEST,NB_CONDIDATS_ANG,NBMAX FROM ESP_TOEIC_NB  where NB_CONDIDATS_ANG<NBMAX order by DATETEST", con);
            // OracleCommand cmd = new OracleCommand("SELECT DATETEST,NB_CONDIDATS,NBMAX FROM ESP_TOEIC_NB  WHERE NB_CONDIDATS<NBMAX AND NIV_ACQUIS_ANGLAIS<>'B2' and  NIV_ACQUIS_FRANCAIS<>'B2' order by DATETEST", con);

            OracleCommand cmd = new OracleCommand("SELECT DATETEST FROM ESP_TOEIC_NB ORDER BY DATETEST ", con);
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Afficher_list_charguia()
        {

            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();


            OracleCommand cmd = new OracleCommand("select a.code_cl Classe,count(*) Effectif FROM ESP_INSCRIPTION a left join classes1516 b on a.code_cl=b.code_cl left join scoesb02.ESP_ETUDIANT e on a.id_et=e.ID_ET where a.annee_deb='2015' and lower(e.ETAT)='a' and lower(a.code_cl) between '1' and '5t'  and lower(site) like 'charguia%'  group by site,a.code_cl  order BY fn_tri_classe(a.CODE_CL)", con);

            //OracleCommand cmd = new OracleCommand("select a.code_cl Classe,count(*) Effectif FROM ESP_INSCRIPTION a left join classes1516 b on a.code_cl=b.code_cl left join esp_etudiant e on a.id_et=e.ID_ET where annee_deb='2015' and lower(e.ETAT)='a' and a.code_cl between '1' and '5t'  and site like 'Charguia' group by site,a.code_cl order BY fn_tri_classe(classe)", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }

        //afficher liste gazela

        public DataTable Afficher_list_gazela()
        {

            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();



            OracleCommand cmd = new OracleCommand("select a.code_cl Classe,count(*) Effectif FROM ESP_INSCRIPTION a left join classes1516 b on a.code_cl=b.code_cl left join scoesb02.ESP_ETUDIANT e on a.id_et=e.ID_ET where a.annee_deb='2015' and lower(e.ETAT)='a' and lower(a.code_cl) between '1' and '5t'  and lower(site) like 'ghazala%'  group by site,a.code_cl  order BY fn_tri_classe(a.CODE_CL)", con);




            //OracleCommand cmd = new OracleCommand("select a.code_cl Classe,count(*) Effectif FROM ESP_INSCRIPTION a left join classes1516 b on a.code_cl=b.code_cl left join esp_etudiant e on a.id_et=e.ID_ET where annee_deb='2015' and lower(e.ETAT)='a' and lower(a.code_cl) between '1' and '5t'  and lower(site) like 'ghazala'  group by site,a.code_cl   order BY fn_tri_classe(a.CODE_CL)", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }


        public string totalch()
        {
            string lib = " ";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "SELECT CODE_CL from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.annee_deb=societe.annee_deb  and ESP_INSCRIPTION.ID_ET='" + id_edt + "'  and ESP_INSCRIPTION.code_cl like '5%' ";


                string cmdQuery = "select count(*) Effectif FROM ESP_INSCRIPTION a left join classes1516 b on a.code_cl=b.code_cl where b.annee_deb='2015' and a.code_cl between '1' and '5T'  and site like 'Charguia' ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string totalgh()
        {
            string lib = " ";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "SELECT CODE_CL from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.annee_deb=societe.annee_deb  and ESP_INSCRIPTION.ID_ET='" + id_edt + "'  and ESP_INSCRIPTION.code_cl like '5%' ";


                string cmdQuery = "select count(*) Effectif FROM ESP_INSCRIPTION a left join classes1516 b on a.code_cl=b.code_cl where b.annee_deb='2015' and a.code_cl between '1' and '5T'  and site like 'Ghazala'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


      
        public bool verif(string idate)
        {
            bool exist = false;

            mySqlConnection.Open();

            //"update ESP_INSCRIPTION set  DATE_TEST_FR  =to_date('" + _DATE_TEST_FR.ToString() + "', 'dd/mm/yyyy hh24:mi:ss'),DATE_TEST_ANG=to_date('" + _DATE_TEST_ANG.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') where ESP_INSCRIPTION.CODE_CL='" + code_cl + "' and ESP_INSCRIPTION.id_et='" + id_et + "' and ESP_INSCRIPTION.annee_deb='" + annee_deb + "'";

            string cmdQuery = "select * from ESP_TOEIC_NB where DATETEST =to_date('" + idate.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and NB_CONDIDATS_fr<NBMAX  ";

            OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);

            OracleDataReader MyReader = myCommandAbsence.ExecuteReader();

            while (MyReader.Read() && !exist)
            {
                exist = true;

                break;

            }
            MyReader.Close();
            mySqlConnection.Close();


            return exist;
        }
        public bool verifang(string idate)
        {
            bool exist = false;

            mySqlConnection.Open();

            //"update ESP_INSCRIPTION set  DATE_TEST_FR  =to_date('" + _DATE_TEST_FR.ToString() + "', 'dd/mm/yyyy hh24:mi:ss'),DATE_TEST_ANG=to_date('" + _DATE_TEST_ANG.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') where ESP_INSCRIPTION.CODE_CL='" + code_cl + "' and ESP_INSCRIPTION.id_et='" + id_et + "' and ESP_INSCRIPTION.annee_deb='" + annee_deb + "'";

            string cmdQuery = "select * from ESP_TOEIC_NB where DATETEST =to_date('" + idate.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and NB_CONDIDATS_ang<NBMAX  ";

            OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);

            OracleDataReader MyReader = myCommandAbsence.ExecuteReader();

            while (MyReader.Read() && !exist)
            {
                exist = true;

                break;

            }
            MyReader.Close();
            mySqlConnection.Close();


            return exist;
        }


      //selectionner nbcondidat inscrit
      public string  nbCondidatsInscrit(DateTime dateinsc)
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT NB_CONDIDATS_fr from ESP_TOEIC_NB where DATETEST=to_date('" + dateinsc.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }


      public string nbCondidatsInscritang(DateTime dateinsc)
      {
          string NB = "";

          using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
          {
              mySqlConnection.Open();

              string cmdQuery = "SELECT NB_CONDIDATS_ang from ESP_TOEIC_NB where DATETEST=to_date('" + dateinsc.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') ";


              OracleCommand myCommand = new OracleCommand(cmdQuery);
              myCommand.Connection = mySqlConnection;
              myCommand.CommandType = CommandType.Text;
              NB = myCommand.ExecuteScalar().ToString();
              mySqlConnection.Close();
          }
          return NB;
      }

      #region  tester
      //public DataTable bindDATEexam()
      //{
      //    DataTable dt = new DataTable();
      
      //    OracleConnection con = new OracleConnection(source);
      //    con.Open();
      //    //OracleCommand cmd = new OracleCommand("SELECT DATETEST,NB_CONDIDATS_FR,NBMAX FROM ESP_TOEIC_NB  where NB_CONDIDATS_FR<NBMAX order by DATETEST", con);
      //    OracleCommand cmd = new OracleCommand("SELECT DATETEST,NB_CONDIDATS,NBMAX FROM ESP_TOEIC_NB order by DATETEST", con);

      //    OracleDataAdapter od = new OracleDataAdapter(cmd);
      //    od.Fill(dt);
      //    con.Close();
      //    return dt;
      //}

      ////////////////////////////////////////////////////////////////
      //public bool ajoutnbcandANG(DateTime datetest)
      //{
      //    bool result = false;
      //    openconntrans();

      //    string cmdQuery = " update  ESP_TOEIC_NB set (NB_CONDIDATS_ANG)=( select NB_CONDIDATS_ANG+ 1 from ESP_TOEIC_NB where DATETEST = to_date('" + datetest.ToString() + "', 'dd/mm/yyyy hh24:mi:ss')) ";
      //    Oracle.DataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
      //    myCommand.Connection = mySqlConnection;
      //    myCommand.CommandType = CommandType.Text;
      //    myCommand.Transaction = myTrans;
      //    try
      //    {
      //        myCommand.ExecuteNonQuery();
      //        myTrans.Commit();
      //        result = true;
      //    }
      //    catch (Exception)
      //    {
      //        myTrans.Rollback();
      //        mySqlConnection.Close();
      //        throw;
      //    }
      //    mySqlConnection.Close();
      //    return result;
      //}
      //////////////////////////
      //public string nbCondidatsInscritAng(DateTime dateinsc)
      //{
      //    string NB = "";

      //    
      //    {
      //        mySqlConnection.Open();

      //        string cmdQuery = "SELECT NB_CONDIDATS_ANG from ESP_TOEIC_NB where DATETEST=to_date('" + dateinsc.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') ";


      //        OracleCommand myCommand = new OracleCommand(cmdQuery);
      //        myCommand.Connection = mySqlConnection;
      //        myCommand.CommandType = CommandType.Text;
      //        NB = myCommand.ExecuteScalar().ToString();
      //        mySqlConnection.Close();
      //    }
      //    return NB;
      //}
      //public bool verifFR(string idate)
      //{
      //    bool exist = false;



      //    mySqlConnection.Open();

      //    //"update ESP_INSCRIPTION set  DATE_TEST_FR  =to_date('" + _DATE_TEST_FR.ToString() + "', 'dd/mm/yyyy hh24:mi:ss'),DATE_TEST_ANG=to_date('" + _DATE_TEST_ANG.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') where ESP_INSCRIPTION.CODE_CL='" + code_cl + "' and ESP_INSCRIPTION.id_et='" + id_et + "' and ESP_INSCRIPTION.annee_deb='" + annee_deb + "'";

      //    string cmdQuery = "select * from ESP_TOEIC_NB where DATETEST =to_date('" + idate.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and NB_CONDIDATS_FR<NBMAX  ";

      //    OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);

      //    OracleDataReader MyReader = myCommandAbsence.ExecuteReader();

      //    while (MyReader.Read() && !exist)
      //    {
      //        exist = true;

      //        break;

      //    }
      //    MyReader.Close();
      //    mySqlConnection.Close();


      //    return exist;
      //} 
      #endregion

        public bool ajoutnbcandidatsfr(DateTime datetest)
        {
            bool result = false;
            openconntrans();

            string cmdQuery = " update  ESP_TOEIC_NB set (NB_CONDIDATS_fr)=( select NB_CONDIDATS_fr+ 1 from ESP_TOEIC_NB where DATETEST = to_date('" + datetest.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') ) ";
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;
            try
            {
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                result = true;
            }
            catch (Exception)
            {
                myTrans.Rollback();
                mySqlConnection.Close();
                throw;
            }
            mySqlConnection.Close();
            return result;
        }


        public bool ajoutnbcandidatsang(DateTime datetest)
        {
            bool result = false;
            openconntrans();

            string cmdQuery = " update  ESP_TOEIC_NB set (NB_CONDIDATS_ang)=( select NB_CONDIDATS_ang+ 1 from ESP_TOEIC_NB where DATETEST = to_date('" + datetest.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') ) ";
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;
            try
            {
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                result = true;
            }
            catch (Exception)
            {
                myTrans.Rollback();
                mySqlConnection.Close();
                throw;
            }
            mySqlConnection.Close();
            return result;
        }

        public string selectniVeauEDTFR(string id_edt)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT NIV_ACQUIS_FRANCAIS from esp_inscription where esp_inscription.id_et='" + id_edt + "' and annee_deb=2015";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }
        public string selectniVeauEDTANG(string id_edt)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT NIV_ACQUIS_ANGLAIS from esp_inscription where esp_inscription.id_et='" + id_edt + "' and annee_deb=2015";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }



        public DataTable Afficher_list_condParDateANG(DateTime dateang)
        {

            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);
            OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG  from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_ANG=esp_toeic_nb.DATETEST and DATE_TEST_ANG=to_date('" + dateang + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }

        public DataTable Afficher_list_condParDateFR(DateTime dateFR)
        {

            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_FR from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_FR =to_date('" + date.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);
            OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_FR  from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_FR=to_date('" + dateFR + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }


        public string nbtoiec()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = " SELECT count(*) from esp_inscription where TEST_toeic='O' and esp_inscription.annee_deb='2015' AND (code_cl like '4%' or code_cl like '5%')";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }

        public string nbPREPtoiec()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT count(*) from esp_inscription,societe where prep_toeic='O' and esp_inscription.annee_deb=societe.annee_deb AND (code_cl like '4%' or code_cl like '5%')";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }

        public string returnCLSUPP(string id_edt)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

               // string cmdQuery = "SELECT CODE_CL from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.annee_deb=societe.annee_deb  and ESP_INSCRIPTION.ID_ET='" + id_edt + "'  and ESP_INSCRIPTION.code_cl like '5%' ";


                string cmdQuery = "select CODE_CL from esp_inscription,esp_etudiant  where esp_inscription.id_et=esp_etudiant.id_et AND esp_inscription.annee_deb ='2015'  and ESP_ETUDIANT.etat='A' AND  esp_inscription.id_et='" + id_edt + "' ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string verif5eme2015(string id_et)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

             
                string cmdQuery = "select ( case when exists (select CODE_CL from esp_inscription,esp_etudiant  where esp_inscription.id_et=esp_etudiant.id_et AND esp_inscription.annee_deb ='2015'  and ESP_ETUDIANT.etat='A' AND code_cl like '5%' and esp_inscription.id_et='"+id_et+"')     then '5' else '' end) code_cl from dual ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string verif5eme2014(string id_et)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = "select ( case when exists (select CODE_CL from esp_inscription,esp_etudiant  where esp_inscription.id_et=esp_etudiant.id_et AND esp_inscription.annee_deb ='2014'  and ESP_ETUDIANT.etat='A' AND code_cl like '5%' and esp_inscription.id_et='" + id_et + "')     then '5' else '' end) code_cl from dual ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public DataTable verif5eme()
        {

            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
           

            OracleCommand cmd = new OracleCommand("select distinct t1.id_et from esp_inscription t1,esp_etudiant t2 where t1.id_et=t2.id_et and t2.etat='A' and (annee_deb=2015 or annee_deb=2014) and code_cl like '5%'", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }
        public string returnCLSUPP2014(string id_edt)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "SELECT CODE_CL from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.annee_deb=societe.annee_deb  and ESP_INSCRIPTION.ID_ET='" + id_edt + "'  and ESP_INSCRIPTION.code_cl like '5%' ";


                string cmdQuery = "select CODE_CL from esp_inscription,esp_etudiant  where esp_inscription.id_et=esp_etudiant.id_et AND esp_inscription.annee_deb ='2014'  and ESP_ETUDIANT.etat='A' AND  esp_inscription.id_et='" + id_edt + "' ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public void Enreg_inscriTest_fr(DateTime _DATE_TEST_FR, string id_et, string annee_deb)
        {

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            // cmd.CommandText = "INSERT INTO ESP_INSCRIPTION(DATE_TEST_FR,DATE_TEST_ANG) VALUES (to_date('" + _DATE_TEST_FR.ToString() + "', 'dd/mm/yyyy hh24:mi:ss'),to_date('" + _DATE_TEST_ANG.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') where ESP_INSCRIPTION.CODE_CL='" + code_cl + "' and ESP_INSCRIPTION.id_et='" + id_et + "' andESP_INSCRIPTION.annee_deb='"+annee_deb+"')";
            cmd.CommandText = "update ESP_INSCRIPTION set DATE_TEST_FR=to_date('" + _DATE_TEST_FR.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') where ESP_INSCRIPTION.id_et='" + id_et + "' and ESP_INSCRIPTION.annee_deb='" + annee_deb + "' and ESP_INSCRIPTION.CODE_cl like '5%' ";
            
            cmd.ExecuteNonQuery();

        }

        public void Enreg_inscriTest_ANG(DateTime _DATE_TEST_ANG, string id_et, string annee_deb)
        {

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            // cmd.CommandText = "INSERT INTO ESP_INSCRIPTION(DATE_TEST_FR,DATE_TEST_ANG) VALUES (to_date('" + _DATE_TEST_FR.ToString() + "', 'dd/mm/yyyy hh24:mi:ss'),to_date('" + _DATE_TEST_ANG.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') where ESP_INSCRIPTION.CODE_CL='" + code_cl + "' and ESP_INSCRIPTION.id_et='" + id_et + "' andESP_INSCRIPTION.annee_deb='"+annee_deb+"')";
            cmd.CommandText = "update ESP_INSCRIPTION set DATE_TEST_ANG=to_date('" + _DATE_TEST_ANG.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') where ESP_INSCRIPTION.id_et='" + id_et + "' and ESP_INSCRIPTION.annee_deb='" + annee_deb + "' and ESP_INSCRIPTION.CODE_cl like '5%' ";

            cmd.ExecuteNonQuery();

        }


        public void Addnbcondidatfr(DateTime date)
        {

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
           //  cmd.CommandText = "update  ESP_TOEIC_NB set (NB_CONDIDATS_fr)=( select (NB_CONDIDATS_fr+ 1) from ESP_TOEIC_NB where DATETEST = to_date('" + date.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') ) ";

            cmd.CommandText = "update  ESP_TOEIC_NB set NB_CONDIDATS_fr=NB_CONDIDATS_fr+1 where DATETEST = to_date('" + date.ToString() + "', 'dd/mm/yyyy hh24:mi:ss')  ";
           

            

            cmd.ExecuteNonQuery();

        }


        public void AddnbcondidatANG(DateTime dateang)
        {

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
             //cmd.CommandText = " update  ESP_TOEIC_NB set (NB_CONDIDATS_ang)=( select (NB_CONDIDATS_ang+ 1) from ESP_TOEIC_NB where DATETEST = to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') ) ";

            cmd.CommandText = " update  ESP_TOEIC_NB set NB_CONDIDATS_ang=NB_CONDIDATS_ang+ 1 where DATETEST = to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss')  ";


            cmd.ExecuteNonQuery();

        }

        public string countNBTOIEC()
        {
           
            //OracleCommand cmd = new OracleCommand("SELECT COUNT(*) from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.ANNEE_DEB=SOCIETE.ANNEE_DEB AND  TEST_TOEIC='O'", cn);
            //cn.Open();
            //return cmd.ExecuteNonQuery();

            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "SELECT CODE_CL from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.annee_deb=societe.annee_deb  and ESP_INSCRIPTION.ID_ET='" + id_edt + "'  and ESP_INSCRIPTION.code_cl like '5%' ";


                string cmdQuery = "SELECT COUNT(*) from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.ANNEE_DEB=SOCIETE.ANNEE_DEB AND  TEST_TOEIC='O' ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string countNBPREPTOIEC()
        {
           

            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "SELECT CODE_CL from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.annee_deb=societe.annee_deb  and ESP_INSCRIPTION.ID_ET='" + id_edt + "'  and ESP_INSCRIPTION.code_cl like '5%' ";


                string cmdQuery = "SELECT COUNT(*) from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.ANNEE_DEB=SOCIETE.ANNEE_DEB AND  PREP_TOEIC='O' ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }



        public DataTable Afficher_list_toiec()
        {

            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            // OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL  from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb  and TEST_TOEIC='O' and (CODE_CL LIKE '4%' or code_cl like '5%')  ", con);

            OracleCommand cmd = new OracleCommand("SELECT ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL FROM ESP_INSCRIPTION,esp_etudiant,societe,esp_test_etud where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb and esp_test_etud.ID_ET=ESP_INSCRIPTION.ID_ET and type_choix='1' AND (CODE_CL LIKE '4%' or code_cl like '5%')", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }
        public DataTable Afficher_list_PREP_toiec()
        {

            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
           // OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL  from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb  and PREP_TOEIC='O' and (CODE_CL LIKE '4%' or code_cl like '5%')  ", con);

            OracleCommand cmd = new OracleCommand("SELECT ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL FROM ESP_INSCRIPTION,esp_etudiant,societe,esp_test_etud where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb and esp_test_etud.ID_ET=ESP_INSCRIPTION.ID_ET and type_choix='2' AND (CODE_CL LIKE '4%' or code_cl like '5%')", con);
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }

       public DataTable Afficher_list_commune()
        {

            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            // OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL  from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb  and PREP_TOEIC='O' and (CODE_CL LIKE '4%' or code_cl like '5%')  ", con);

            OracleCommand cmd = new OracleCommand("SELECT ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL FROM ESP_INSCRIPTION,esp_etudiant,societe,esp_test_etud where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb and esp_test_etud.ID_ET=ESP_INSCRIPTION.ID_ET and type_choix='3' AND (CODE_CL LIKE '4%' or code_cl like '5%')", con);
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            con.Close();
            return dt;
        }


       public string countNB_TOIEC()
       {
           string lib = "";

           using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
           {
               mySqlConnection.Open();

               // string cmdQuery = "SELECT CODE_CL from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.annee_deb=societe.annee_deb  and ESP_INSCRIPTION.ID_ET='" + id_edt + "'  and ESP_INSCRIPTION.code_cl like '5%' ";


               string cmdQuery = " select sum(type_choix) from ( select count(*) type_choix from esp_TEST_ENS where  (type_choix='1' or type_choix='3') union all SELECT count(*) type_choix from esp_TEST_ETUD where (type_choix='1' or type_choix='3' ) and esp_TEST_ETUD.TYPE_TEST='T')";
               
               OracleCommand myCommand = new OracleCommand(cmdQuery);
               myCommand.Connection = mySqlConnection;
               myCommand.CommandType = CommandType.Text;
               lib = myCommand.ExecuteScalar().ToString();
               mySqlConnection.Close();
           }
           return lib;
       }

      public string countNBPrep_TOIEC()
       {
           string lib = "";

           using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
           {
               mySqlConnection.Open();

               // string cmdQuery = "SELECT CODE_CL from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.annee_deb=societe.annee_deb  and ESP_INSCRIPTION.ID_ET='" + id_edt + "'  and ESP_INSCRIPTION.code_cl like '5%' ";


               string cmdQuery = "  select sum(type_choix) from ( select count(*) type_choix from esp_TEST_ENS where  (type_choix='2' or type_choix='3') union all SELECT count(*) type_choix from esp_TEST_ETUD where (type_choix='2' or type_choix='3' )and esp_TEST_ETUD.TYPE_TEST='T' )";
               
               OracleCommand myCommand = new OracleCommand(cmdQuery);
               myCommand.Connection = mySqlConnection;
               myCommand.CommandType = CommandType.Text;
               lib = myCommand.ExecuteScalar().ToString();
               mySqlConnection.Close();
           }
           return lib;
       }

      public DataTable Afficher_list_ens_toeic()
      {

          DataTable dt = new DataTable();

          OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
          con.Open();
          // OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL  from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb  and PREP_TOEIC='O' and (CODE_CL LIKE '4%' or code_cl like '5%')  ", con);

          OracleCommand cmd = new OracleCommand("select nom_ens,esp_enseignant.id_ens from esp_enseignant,esp_test_ens where etat='A'  and esp_test_ens.ID_ENS=esp_enseignant.ID_ENS and type_choix='1'", con);
          OracleDataAdapter od = new OracleDataAdapter(cmd);
          od.Fill(dt);

          con.Close();
          return dt;
      }

      public DataTable Afficher_list_ens_prep_toeic()
      {

          DataTable dt = new DataTable();

          OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
          con.Open();
          // OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL  from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb  and PREP_TOEIC='O' and (CODE_CL LIKE '4%' or code_cl like '5%')  ", con);

          OracleCommand cmd = new OracleCommand("select nom_ens,esp_enseignant.id_ens from esp_enseignant,esp_test_ens where etat='A'  and esp_test_ens.ID_ENS=esp_enseignant.ID_ENS and type_choix='2'", con);
          OracleDataAdapter od = new OracleDataAdapter(cmd);
          od.Fill(dt);

          con.Close();
          return dt;
      }

             public DataTable Afficher_list_ens_commun()
      {

          DataTable dt = new DataTable();

          OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
          con.Open();
          // OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL  from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb  and PREP_TOEIC='O' and (CODE_CL LIKE '4%' or code_cl like '5%')  ", con);

          OracleCommand cmd = new OracleCommand("select nom_ens,esp_enseignant.id_ens from esp_enseignant,esp_test_ens where etat='A'  and esp_test_ens.ID_ENS=esp_enseignant.ID_ENS and type_choix='3'", con);
          OracleDataAdapter od = new OracleDataAdapter(cmd);
          od.Fill(dt);

          con.Close();
          return dt;
      }

             public void Enreg_etud_toeic( string id_et, string _choix)
             {
                 OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
                 conn.Open();
                 OracleCommand cmd = conn.CreateCommand();
                 cmd.CommandText = "INSERT INTO ESP_TEST_ETUD(ID_ET,TYPE_CHOIX,DATE_CHOIX) VALUES ('"+id_et+"','"+_choix+"',to_date(sysdate,'dd/MM/yyyy'))";
                
                 cmd.ExecuteNonQuery();

             }

             public void Enreg_ens_toeic(string id_ens, string _choix)
             {

                 OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
                 conn.Open();
                 OracleCommand cmd = conn.CreateCommand();
                 cmd.CommandText = "INSERT INTO ESP_TEST_Ens(ID_Ens,TYPE_CHOIX,DATE_CHOIX) VALUES ('" + id_ens + "','" + _choix + "',to_date(sysdate,'dd/MM/yyyy'))";

                 cmd.ExecuteNonQuery();

             }


             public bool verifexistet()
             {
                 bool exist = false;

                 mySqlConnection.Open();

                 //"update ESP_INSCRIPTION set  DATE_TEST_FR  =to_date('" + _DATE_TEST_FR.ToString() + "', 'dd/mm/yyyy hh24:mi:ss'),DATE_TEST_ANG=to_date('" + _DATE_TEST_ANG.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') where ESP_INSCRIPTION.CODE_CL='" + code_cl + "' and ESP_INSCRIPTION.id_et='" + id_et + "' and ESP_INSCRIPTION.annee_deb='" + annee_deb + "'";

                 string cmdQuery = " SELECT distinct esp_inscription.id_et FROM esp_inscription WHERE EXISTS (SELECT esp_test_etud.ID_ET FROM esp_test_etud WHERE esp_inscription.id_et = esp_test_etud.id_et) ";
                 
                 OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);

                 OracleDataReader MyReader = myCommandAbsence.ExecuteReader();

                 while (MyReader.Read() && !exist)
                 {
                     exist = true;

                     break;

                 }
                 MyReader.Close();
                 mySqlConnection.Close();


                 return exist;
             }

             public string getidtest_toeic()
             {
                 string lib = "";

                 using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
                 {
                     mySqlConnection.Open();

                     // string cmdQuery = "SELECT CODE_CL from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.annee_deb=societe.annee_deb  and ESP_INSCRIPTION.ID_ET='" + id_edt + "'  and ESP_INSCRIPTION.code_cl like '5%' ";


                     string cmdQuery = "SELECT ID_ET FROM ESP_TEST_ETUD  ";

                     OracleCommand myCommand = new OracleCommand(cmdQuery);
                     myCommand.Connection = mySqlConnection;
                     myCommand.CommandType = CommandType.Text;
                     lib = myCommand.ExecuteScalar().ToString();
                     mySqlConnection.Close();
                 }
                 return lib;
             }


             public DataTable Aff_list_inscrit(string id_et)
             {

                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 // OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL  from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb  and PREP_TOEIC='O' and (CODE_CL LIKE '4%' or code_cl like '5%')  ", con);

                 OracleCommand cmd = new OracleCommand("select * from esp_test_etud where esp_test_etud.id_et='"+id_et+"' ", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }


             public DataTable Aff_list_inscrit_ens(string id_ens)
             {

                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 // OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL  from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb  and PREP_TOEIC='O' and (CODE_CL LIKE '4%' or code_cl like '5%')  ", con);

                 OracleCommand cmd = new OracleCommand("select * from esp_test_ens where esp_test_ens.id_ens='" + id_ens + "' ", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }
             //fonction consernant la formation francais et anglais 2015/2015


             public DataTable Afficher_list_commune_formation()
             {

                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 // OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL  from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb  and PREP_TOEIC='O' and (CODE_CL LIKE '4%' or code_cl like '5%')  ", con);

                 OracleCommand cmd = new OracleCommand("SELECT ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL FROM ESP_INSCRIPTION,esp_etudiant,esp_test_etud where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb='2015' and esp_test_etud.ID_ET=ESP_INSCRIPTION.ID_ET and type_choix='3' AND (CODE_CL LIKE '5GC%' or code_cl like '5EM%') AND to_date (DATE_CHOIX, 'dd/MM/yy')>= TO_DATE('21/07/15','dd/MM/yy') and type_test='F'", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }

             public DataTable Afficher_format_ang()
             {

                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 // OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL  from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb  and PREP_TOEIC='O' and (CODE_CL LIKE '4%' or code_cl like '5%')  ", con);

                 OracleCommand cmd = new OracleCommand("SELECT ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL FROM ESP_INSCRIPTION,esp_etudiant,esp_test_etud where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb='2015' and esp_test_etud.ID_ET=ESP_INSCRIPTION.ID_ET and type_choix='2' AND (CODE_CL LIKE '5GC%' or code_cl like '5EM%') AND to_date (DATE_CHOIX, 'dd/MM/yy')>= TO_DATE('21/07/15','dd/MM/yy') and type_test='F'", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }
             public DataTable Afficher_format_fr()
             {

                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 // OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL  from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb  and TEST_TOEIC='O' and (CODE_CL LIKE '4%' or code_cl like '5%')  ", con);

                 OracleCommand cmd = new OracleCommand("SELECT ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL FROM ESP_INSCRIPTION,esp_etudiant,esp_test_etud where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb='2015' and esp_test_etud.ID_ET=ESP_INSCRIPTION.ID_ET and type_choix='1' AND (CODE_CL LIKE '5GC%' or code_cl like '5EM%') AND to_date (DATE_CHOIX, 'dd/MM/yy')>= TO_DATE('21/07/15','dd/MM/yy') and type_test='F' ", con);

                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }

             public void Enreg_etud_FORMATION(string id_et, string _choix)
             {

                 OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
                 conn.Open();
                 OracleCommand cmd = conn.CreateCommand();
                 // cmd.CommandText = "INSERT INTO ESP_FORMATION_ETUD_LANGUE(ID_ET,TYPE_CHOIX,DATE_CHOIX) VALUES ('" + id_et + "','" + _choix + "',to_date(sysdate,'dd/MM/yyyy'))";

                 cmd.CommandText = "INSERT INTO ESP_TEST_ETUD(ID_ET,TYPE_CHOIX,DATE_CHOIX,type_test) VALUES ('" + id_et + "','" + _choix + "',to_date(sysdate,'dd/MM/yyyy'),'F')";


                 cmd.ExecuteNonQuery();

             }

             public DataTable get_id_etud_formation(string id_et)
             {

                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 // OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL  from ESP_INSCRIPTION,esp_etudiant,societe where ESP_INSCRIPTION.id_et=esp_etudiant.id_et  and ESP_INSCRIPTION.annee_deb=societe.annee_deb  and PREP_TOEIC='O' and (CODE_CL LIKE '4%' or code_cl like '5%')  ", con);

                 //OracleCommand cmd = new OracleCommand("select * from ESP_FORMATION_ETUD_LANGUE where ESP_FORMATION_ETUD_LANGUE.id_et='" + id_et + "' and DATE_CHOIX=to_date(sysdate,'dd/MM/yyyy') ", con);

                 OracleCommand cmd = new OracleCommand("select * from ESP_TEST_ETUD where ESP_TEST_ETUD.id_et='" + id_et + "' and DATE_CHOIX=to_date(sysdate,'dd/MM/yy') ", con);

                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }
             public DataTable get_5_classe(string id_et)
             {

                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                
                 OracleCommand cmd = new OracleCommand("select * from ESP_inscription where code_cl like '5%' and id_et='"+id_et+"'  and annee_deb='2014'", con);

                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }
             public string getChoixLangues(string id_edt)
             {
                 string lib = "";

                 using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
                 {
                     mySqlConnection.Open();

                     string cmdQuery = "select TYPE_CHOIX from ESP_TEST_ETUD,esp_inscription where esp_inscription.id_et=ESP_TEST_ETUD.id_et and ESP_TEST_ETUD.id_et='" + id_edt + "' and DATE_CHOIX=to_date(sysdate,'dd/MM/yyyy') ";
                     OracleCommand myCommand = new OracleCommand(cmdQuery);
                     myCommand.Connection = mySqlConnection;
                     myCommand.CommandType = CommandType.Text;
                     lib = myCommand.ExecuteScalar().ToString();
                     mySqlConnection.Close();
                 }
                 return lib;

             }

             public string countNB_fr()
             {
                 string lib = "";

                 using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
                 {
                     mySqlConnection.Open();

                     // string cmdQuery = "SELECT CODE_CL from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.annee_deb=societe.annee_deb  and ESP_INSCRIPTION.ID_ET='" + id_edt + "'  and ESP_INSCRIPTION.code_cl like '5%' ";


                     string cmdQuery = "    SELECT count(*) type_choix from esp_TEST_ETUD where (type_choix='1' or type_choix='3' ) AND TO_DATE(DATE_CHOIX) > TO_DATE('27/07/2015','DD/MM/YYYY') and type_test='F'";

                     OracleCommand myCommand = new OracleCommand(cmdQuery);
                     myCommand.Connection = mySqlConnection;
                     myCommand.CommandType = CommandType.Text;
                     lib = myCommand.ExecuteScalar().ToString();
                     mySqlConnection.Close();
                 }
                 return lib;
             }

             public string countNB_ang()
             {
                 string lib = "";

                 using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
                 {
                     mySqlConnection.Open();

                     // string cmdQuery = "SELECT CODE_CL from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.annee_deb=societe.annee_deb  and ESP_INSCRIPTION.ID_ET='" + id_edt + "'  and ESP_INSCRIPTION.code_cl like '5%' ";


                     string cmdQuery = "   SELECT count(*) type_choix from esp_TEST_ETUD where (type_choix='2' or type_choix='3' ) AND TO_DATE(DATE_CHOIX) > TO_DATE('27/07/2015','DD/MM/YYYY') and type_test='F'";

                     OracleCommand myCommand = new OracleCommand(cmdQuery);
                     myCommand.Connection = mySqlConnection;
                     myCommand.CommandType = CommandType.Text;
                     lib = myCommand.ExecuteScalar().ToString();
                     mySqlConnection.Close();
                 }
                 return lib;
             }


             public string countNB_fr_ang()
             {
                 string lib = "";

                 using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
                 {
                     mySqlConnection.Open();

                     // string cmdQuery = "SELECT CODE_CL from ESP_INSCRIPTION,SOCIETE WHERE ESP_INSCRIPTION.annee_deb=societe.annee_deb  and ESP_INSCRIPTION.ID_ET='" + id_edt + "'  and ESP_INSCRIPTION.code_cl like '5%' ";


                     string cmdQuery = "   SELECT count(*) type_choix from esp_TEST_ETUD where (type_choix='3' ) AND TO_DATE(DATE_CHOIX) > TO_DATE('27/07/2015','DD/MM/YYYY')  and type_test='F'";

                     OracleCommand myCommand = new OracleCommand(cmdQuery);
                     myCommand.Connection = mySqlConnection;
                     myCommand.CommandType = CommandType.Text;
                     lib = myCommand.ExecuteScalar().ToString();
                     mySqlConnection.Close();
                 }
                 return lib;
             }



             public DataTable Afficher_listPARniv()
             {

                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand("select c.Site,a.code_cl Classe,sum(case when a.type_insc='I' and substr(a.code_cl,1,1)>substr(nvl(b.code_cl,'0'),1,1) then 1 else 0 end) as Nouveaux_inscrits, sum(case when a.type_insc='I' and substr(a.code_cl,1,1)<=substr(nvl(b.code_cl,'0'),1,1) then 1 else 0 end) as Redoublants_inscrits,sum(case when a.type_insc='I' then 1 else 0 end) as Inscrits,sum(case when a.type_insc='P' and substr(a.code_cl,1,1)>substr(nvl(b.code_cl,'0'),1,1) then 1 else 0 end) as Nouveaux_Pre_inscrits,sum(case when a.type_insc='P' and substr(a.code_cl,1,1)<=substr(nvl(b.code_cl,'0'),1,1) then 1 else 0 end) as Redoublants_Pre_inscrits,sum(case when a.type_insc='P' then 1 else 0 end) as Pre_Inscrits,count(*) as NB from scoesb02.ESP_INSCRIPTION a left join scoesb02.ESP_INSCRIPTION b on a.id_et=b.id_et  and to_number(a.annee_deb)=to_number(b.annee_deb)+1 left join scoesb02.ESP_ETUDIANT e on a.id_et=e.id_et  left join scoesb02.classes1516 c on a.code_cl = c.code_cl  where a.annee_deb='2015' and lower(e.etat)='a' and lower(a.code_cl) between '1' and '5t' group by c.Site,a.code_cl order by fn_tri_classe(a.CODE_CL)", con);
   
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }



             public DataTable Afficher_listetudPARniv()
             {

                 DataTable dt = new DataTable();
          
                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand("select a.Site,Niveau,count(*) NB_Classes,sum(Nouveaux_Inscrits) Nouveaux_Inscrits,sum(Redoublants_Inscrits) Redoublants_Inscrits,  sum(Inscrits) Inscrits,  sum(Nouveaux_Pre_inscrits) Nouveaux_Pre_Inscrits,sum(Redoublants_Pre_Inscrits) Redoublants_Pre_Inscrits,sum(Pré_Inscrits) Pré_Inscrits,  sum(Inscrits) + sum(Pré_Inscrits) total from (select c.Site,a.code_cl Classe,  sum(case when a.type_insc='I' and substr(a.code_cl,1,1)>substr(nvl(b.code_cl,'0'),1,1) then 1 else 0 end) Nouveaux_inscrits,sum(case when a.type_insc='I' and substr(a.code_cl,1,1)<=substr(b.code_cl,1,1) then 1 else 0 end) Redoublants_inscrits,sum(case when a.type_insc='I' then 1 else 0 end) Inscrits,  sum(case when a.type_insc='P' and substr(a.code_cl,1,1)>substr(nvl(b.code_cl,'0'),1,1) then 1 else 0 end) Nouveaux_Pre_inscrits,sum(case when a.type_insc='P' and substr(a.code_cl,1,1)<=substr(b.code_cl,1,1) then 1 else 0 end) Redoublants_Pre_inscrits,sum(case when a.type_insc='P' then 1 else 0 end) Pré_Inscrits,count(*) NB   from scoesb02.ESP_INSCRIPTION a left join scoesb02.ESP_INSCRIPTION b on a.id_et=b.id_et left join esp_etudiant e on a.id_et=e.id_et   and to_number(a.annee_deb)=to_number(b.annee_deb)+1 left join classes1516 c on a.code_cl = c.code_cl where a.annee_deb='2015' and lower(e.ETAT) ='a' and a.code_cl between '1' and '5t' group by c.Site,a.code_cl)  a left join classes1516 b on a.classe=b.code_cl group by a.site,niveau   order by a.site,niveau", con); 
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }



             //stat par site

             public DataTable Afficher_stat_site()
             {

                 DataTable dt = new DataTable();
            
                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand("select Site,sum(Nouveaux_Inscrits) Nouveaux_Inscrits,sum(Redoublants_Inscrits) Redoublants_Inscrits,sum(Inscrits) Inscrits,sum(Nouveaux_Pre_inscrits) Nouveaux_Pre_Inscrits,sum(Redoublants_Pre_Inscrits) Redoublants_Pre_Inscrits,sum(Pré_Inscrits) Pré_Inscrits,sum(Inscrits)+sum(Pré_Inscrits) Total from(select c.Site,a.code_cl Classe,sum(case when a.type_insc='I' and substr(a.code_cl,1,1)>substr(nvl(b.code_cl,'0'),1,1) then 1 else 0 end) Nouveaux_inscrits,sum(case when a.type_insc='I' and substr(a.code_cl,1,1)<=substr(b.code_cl,1,1) then 1 else 0 end) Redoublants_inscrits,sum(case when a.type_insc='I' then 1 else 0 end) Inscrits,sum(case when a.type_insc='P' and substr(a.code_cl,1,1)>substr(nvl(b.code_cl,'0'),1,1) then 1 else 0 end) Nouveaux_Pre_inscrits,sum(case when a.type_insc='P' and substr(a.code_cl,1,1)<=substr(b.code_cl,1,1) then 1 else 0 end) Redoublants_Pre_inscrits,sum(case when a.type_insc='P' then 1 else 0 end) Pré_Inscrits,count(*) NB from scoesb02.ESP_INSCRIPTION a left join scoesb02.ESP_INSCRIPTION b on a.id_et=b.id_et and to_number(a.annee_deb)=to_number(b.annee_deb)+1 left join classes1516 c on a.code_cl = c.code_cl left join esp_etudiant e on a.id_et=e.id_et where a.annee_deb='2015' and lower(e.etat) ='a' and a.code_cl between '1' and '5t' group by c.Site,a.code_cl) a group by site order by site", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }



             //1
             public DataTable Afficher_total_par_CLASSE()
             {
                 DataTable dt = new DataTable();
               
                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand("select sum(case when a.type_insc='I' and substr(a.code_cl,1,1)>substr(nvl(b.code_cl,'0'),1,1) then 1 else 0 end) as Nouveaux_inscrits,sum(case when a.type_insc='I' and substr(a.code_cl,1,1)<=substr(b.code_cl,1,1) then 1 else 0 end) as Redoublants_inscrits,sum(case when a.type_insc='I' then 1 else 0 end) as Inscrits,sum(case when a.type_insc='P' and substr(a.code_cl,1,1)>substr(nvl(b.code_cl,'0'),1,1) then 1 else 0 end) as Nouveaux_Pre_inscrits,sum(case when a.type_insc='P' and substr(a.code_cl,1,1)<=substr(b.code_cl,1,1) then 1 else 0 end) as Redoublants_Pre_inscrits,sum(case when a.type_insc='P' then 1 else 0 end) as Pre_Inscrits,count(*) as NB from scoesb02.ESP_INSCRIPTION a left join scoesb02.ESP_INSCRIPTION b on a.id_et=b.id_et and to_number(a.annee_deb)=to_number(b.annee_deb)+1 left join classes1516 c on a.code_cl = c.code_cl where a.annee_deb='2015' and a.code_cl between '1' and '5T'", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }

             //2
             public DataTable Afficher_total_par_niv()
             {
                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand("select count(*) NB_Classes,sum(Nouveaux_Inscrits) Nouveaux_Inscrits,sum(Redoublants_Inscrits) Redoublants_Inscrits,sum(Inscrits) Inscrits,sum(Nouveaux_Pre_inscrits) Nouveaux_Pre_Inscrits,sum(Redoublants_Pre_Inscrits) Redoublants_Pre_Inscrits,sum(Pré_Inscrits) Pré_Inscrits,sum(Inscrits) + sum(Pré_Inscrits) total from ( select c.Site,a.code_cl Classe,sum(case when a.type_insc='I' and substr(a.code_cl,1,1)>substr(nvl(b.code_cl,'0'),1,1) then 1 else 0 end) Nouveaux_inscrits,sum(case when a.type_insc='I' and substr(a.code_cl,1,1)<=substr(b.code_cl,1,1) then 1 else 0 end) Redoublants_inscrits,sum(case when a.type_insc='I' then 1 else 0 end) Inscrits,sum(case when a.type_insc='P' and substr(a.code_cl,1,1)>substr(nvl(b.code_cl,'0'),1,1) then 1 else 0 end) Nouveaux_Pre_inscrits,sum(case when a.type_insc='P' and substr(a.code_cl,1,1)<=substr(b.code_cl,1,1) then 1 else 0 end) Redoublants_Pre_inscrits,sum(case when a.type_insc='P' then 1 else 0 end) Pré_Inscrits,count(*) NB from scoesb02.ESP_INSCRIPTION a left join scoesb02.ESP_INSCRIPTION b on a.id_et=b.id_et  and to_number(a.annee_deb)=to_number(b.annee_deb)+1 left join classes1516 c on a.code_cl = c.code_cl where a.annee_deb='2015' and a.code_cl between '1' and '5T'group by c.Site,a.code_cl)  a left join classes1516 b on a.classe=b.code_cl", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }

             //3
             public DataTable Afficher_total_DES_TOTAUX()
             {
                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand("select sum(Nouveaux_Inscrits) Nouveaux_Inscrits,sum(Redoublants_Inscrits) Redoublants_Inscrits,sum(Inscrits) Inscrits,sum(Nouveaux_Pre_inscrits) Nouveaux_Pre_Inscrits,sum(Redoublants_Pre_Inscrits) Redoublants_Pre_Inscrits,sum(Pré_Inscrits) Pré_Inscrits,sum(Inscrits)+sum(Pré_Inscrits) Total from ( select c.Site,a.code_cl Classe,sum(case when a.type_insc='I' and substr(a.code_cl,1,1)>substr(nvl(b.code_cl,'0'),1,1) then 1 else 0 end) Nouveaux_inscrits,sum(case when a.type_insc='I' and substr(a.code_cl,1,1)<=substr(b.code_cl,1,1) then 1 else 0 end) Redoublants_inscrits,sum(case when a.type_insc='I' then 1 else 0 end) Inscrits,sum(case when a.type_insc='P' and substr(a.code_cl,1,1)>substr(nvl(b.code_cl,'0'),1,1) then 1 else 0 end) Nouveaux_Pre_inscrits,sum(case when a.type_insc='P' and substr(a.code_cl,1,1)<=substr(b.code_cl,1,1) then 1 else 0 end) Redoublants_Pre_inscrits,sum(case when a.type_insc='P' then 1 else 0 end) Pré_Inscrits,count(*) NB from scoesb02.ESP_INSCRIPTION a left join scoesb02.ESP_INSCRIPTION b on a.id_et=b.id_et and to_number(a.annee_deb)=to_number(b.annee_deb)+1 left join classes1516 c on a.code_cl = c.code_cl where a.annee_deb='2015' and a.code_cl between '1' and '5T' group by c.Site,a.code_cl) ", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }


             //Répartition des étudiants par Niveau et Pôle 

             public DataTable ReparEtudiantParPole()
             {
                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand("select substr(a.code_cl,1,1) Niveau, sum(case when lower(site) like 'ghazala'  then 1 else 0 end) as Pôle_TIC,sum(case when lower(site) like 'charguia' then 1 else 0 end) as Pôle_GCEM,count(*) Total from scoesb02.ESP_INSCRIPTION a left join classes1516 b on a.code_cl = b.code_cl  left join ESP_ETUDIANT e on a.id_et=e.id_et where a.annee_deb='2015' and lower(e.etat)='a' and a.code_cl between '1' and '5T' group by substr(a.code_cl,1,1) order by substr(a.code_cl,1,1)", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }
             //total Répartition des étudiants par Niveau et Pôle
             public DataTable titalReparEtudiantParPole()
             {
                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand("select sum(case when lower(site) like 'ghazala'  then 1 else 0 end) as Pôle_TIC,sum(case when lower(site) like 'charguia' then 1 else 0 end) as Pôle_GCEM,count(*) Total from scoesb02.ESP_INSCRIPTION a left join classes1516 b on a.code_cl = b.code_cl where a.annee_deb='2015' and a.code_cl between '1' and '5T'", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }

             //Répartition des Classes par Niveau etPôle
             public DataTable ReparclasseParPole()
             {
                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand(" select substr(a.code_cl,1,1) Niveau, sum(case when lower(site) like 'ghazala'  then 1 else 0 end) as Pôle_TIC,sum(case when lower(site) like 'charguia' then 1 else 0 end) as Pôle_GCEM,count(*) Total from(select  site, a.code_cl,count(*) Effectif from scoesb02.ESP_INSCRIPTION a left join classes1516 b on a.code_cl = b.code_cl left join esp_etudiant e on a.ID_ET=e.ID_ET where a.annee_deb='2015' and lower(e.ETAT)='a' and a.code_cl between '1' and '5T' group by site, a.code_cl) a group by substr(a.code_cl,1,1) order by substr(a.code_cl,1,1)", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }

             //total Répartition des Classes par Niveau etPôle
             public DataTable totalReparclasseParPole()
             {
                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand("SELECT sum(case when lower(site) like 'ghazala'  then 1 else 0 end) as Pôle_TIC,sum(case when lower(site) like 'charguia' then 1 else 0 end) as Pôle_GCEM,count(*) Total from(select  site, a.code_cl,count(*) Effectif from scoesb02.ESP_INSCRIPTION a left join classes1516 b on a.code_cl = b.code_cl where a.annee_deb='2015' and a.code_cl between '1' and '5T' group by site, a.code_cl) a", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }

             //liste par specialite
             public DataTable Afficher_list_ens_affecter()
             {

                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand(" select Site,Specialite,Classe,sum(case when enseignant is not null then 1 else 0 end) Enseignants_Affectes,sum(case when enseignant is null then 1 else 0 end) Enseignants_Non_affectes, count(*) Total_Modules  from (SELECT up,d.Site,d.specialite,d.niveau,a.CODE_MODULE,designation module,a.CODE_CL Classe,ANNEE_DEB,a.ID_ENS,a.ID_ENS2, case when NOM_ENS is null or NOM_ENS ='A AFFECTER' then ''else nom_ens end   Enseignant,Charge_p1,Charge_p2,num_semestre Semestre FROM scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO a left join scoesb02.ESP_ENSEIGNANT b on a.ID_ENS=b.ID_ENS left join scoesb02.ESP_MODULE c on a.code_module=c.code_module left join classes1516 d on a.code_cl=d.code_cl where annee_deb='2015'  ) group by site,specialite,classe order by site,specialite,fn_tri_classe(classe)", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }

             //liste par UP
             public DataTable Afficher_list_ens_UPaffecter()
             {

                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand("  select Site,up,Classe,sum(case when enseignant is not null then 1 else 0 end) Enseignants_Affectes,sum(case when enseignant is null then 1 else 0 end) Enseignants_Non_affectes,count(*) Total_Modules from (SELECT up,d.Site,d.specialite,d.niveau,a.CODE_MODULE,designation module,a.CODE_CL Classe,ANNEE_DEB,a.ID_ENS,a.ID_ENS2, case when NOM_ENS is null or NOM_ENS ='A AFFECTER' then ''else nom_ens end  Enseignant,Charge_p1,Charge_p2,num_semestre Semestre FROM scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO a left join scoesb02.ESP_ENSEIGNANT b on a.ID_ENS=b.ID_ENS left join scoesb02.ESP_MODULE c on a.code_module=c.code_module left join classes1516 d on a.code_cl=d.code_cl where annee_deb='2015' )group by site,up,classe order by site,up,classe", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }

             //liste par non ens saisis
             public DataTable Afficher_ens_saisis()
             {

                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand(" select Site,sum(case when enseignant is not null then 1 else 0 end) Enseignants_Affectes,sum(case when enseignant is null then 1 else 0 end) Enseignants_Non_affectes, count(*) Total_Modules from (SELECT up,d.Site,d.specialite,d.niveau,a.CODE_MODULE,designation module,a.CODE_CL Classe,ANNEE_DEB,a.ID_ENS,a.ID_ENS2,case when NOM_ENS is null or NOM_ENS ='A AFFECTER' then ''else nom_ens end   Enseignant,Charge_p1,Charge_p2,num_semestre Semestre FROM scoesb02.ESP_MODULE_PANIER_CLASSE_SAISO a left join scoesb02.ESP_ENSEIGNANT b on a.ID_ENS=b.ID_ENS left join scoesb02.ESP_MODULE c on a.code_module=c.code_module left join classes1516 d on a.code_cl=d.code_cl where annee_deb='2015')group by site order by site", con);
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }

             public DataTable Affich_list_etud_niveau_ang()
             {

                 DataTable dt = new DataTable();
                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
          
              
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 //OracleCommand cmd = new OracleCommand(" select Niveau,sum(Niveau_A1) Niveau_A1,sum(Niveau_A2) Niveau_A2,sum(Niveau_B1) Niveau_B1,sum(Niveau_B2) Niveau_B2,sum(Niveau_A1) + sum(Niveau_A2) + sum(Niveau_B1) + sum(Niveau_B2) AS total from (select a.code_cl Classe,sum(case when  lower(e.niveau_courant_ANG)='a1'  then 1 else 0 end) as Niveau_A1,sum(case when  lower(e.e.niveau_courant_ANG)='a2'   then 1 else 0 end) as Niveau_A2,sum(case when  lower(e.e.niveau_courant_ANG)='b1'   then 1 else 0 end) as Niveau_B1,sum(case when  lower(e.e.niveau_courant_ANG)='b2'   then 1 else 0 end) as Niveau_B2 from scoesb02.ESP_INSCRIPTION a left join scoesb02.ESP_ETUDIANT e on a.id_et=e.id_et left join scoesb02.classes1516 c on a.code_cl = c.code_cl where a.annee_deb='2014' and lower(e.ETAT) ='a' and lower(a.code_cl) between '1' and '4t' and lower(c.SITE) like 'ghazala' group by a.code_cl) a inner join scoesb02.classes1516 b on a.classe=b.code_cl group by niveau order by niveau", con);
                 OracleCommand cmd = new OracleCommand("select Niveau,sum(Niveau_A1) Niveau_A1,sum(Niveau_A2) Niveau_A2,sum(Niveau_B1) Niveau_B1,sum(Niveau_B2) Niveau_B2,sum(Niveau_A1) + sum(Niveau_A2) + sum(Niveau_B1) + sum(Niveau_B2) AS total from (select a.code_cl Classe,sum(case when  lower(e.niveau_courant_ANG)='a1' or ( lower(a.NIV_ACQUIS_ANGLAIS)='a1' AND code_cl like '5%') then 1 else 0 end) as Niveau_A1,sum(case when  lower(e.e.niveau_courant_ANG)='a2' or ( lower(a.NIV_ACQUIS_ANGLAIS)='a2' AND code_cl like '5%')  then 1 else 0 end) as Niveau_A2,sum(case when  lower(e.e.niveau_courant_ANG)='b1' or ( lower(a.NIV_ACQUIS_ANGLAIS)='b1' AND code_cl like '5%')  then 1 else 0 end) as Niveau_B1,sum(case when  lower(e.e.niveau_courant_ANG)='b2' or ( lower(a.NIV_ACQUIS_ANGLAIS)='b2' AND code_cl like '5%')  then 1 else 0 end) as Niveau_B2 from scoesb02.ESP_INSCRIPTION a left join scoesb02.ESP_ETUDIANT e on a.id_et=e.id_et left join scoesb02.classes1516 c on a.code_cl = c.code_cl where a.annee_deb='2014' and lower(e.ETAT) ='a' and lower(a.code_cl) between '1' and '5t' and lower(c.SITE) like 'ghazala' group by a.code_cl) a inner join scoesb02.classes1516 b on a.classe=b.code_cl group by niveau order by niveau", con);


                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }

             public DataTable Affich_list_etud_niveau_FR()
             {

                 DataTable dt = new DataTable();
                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand(" select Niveau,sum(Niveau_A1) Niveau_A1,sum(Niveau_A2) Niveau_A2,sum(Niveau_B1) Niveau_B1,sum(Niveau_B2) Niveau_B2,sum(Niveau_A1) + sum(Niveau_A2) + sum(Niveau_B1) + sum(Niveau_B2) AS total from (select a.code_cl Classe,sum(case when  lower(e.niveau_courant_FR)='a1' or ( lower(a.NIV_ACQUIS_FRANCAIS)='a1' AND code_cl like '5%') then 1 else 0 end) as Niveau_A1,sum(case when  lower(e.e.niveau_courant_FR)='a2' or ( lower(a.NIV_ACQUIS_FRANCAIS)='a2' AND code_cl like '5%')  then 1 else 0 end) as Niveau_A2,sum(case when  lower(e.e.niveau_courant_FR)='b1' or ( lower(a.NIV_ACQUIS_FRANCAIS)='b1' AND code_cl like '5%')  then 1 else 0 end) as Niveau_B1,sum(case when  lower(e.e.niveau_courant_FR)='b2' or ( lower(a.NIV_ACQUIS_FRANCAIS)='b2' AND code_cl like '5%')  then 1 else 0 end) as Niveau_B2 from scoesb02.ESP_INSCRIPTION a left join scoesb02.ESP_ETUDIANT e on a.id_et=e.id_et left join scoesb02.classes1516 c on a.code_cl = c.code_cl where a.annee_deb='2014' and lower(e.ETAT) ='a' and lower(a.code_cl) between '1' and '5t' and lower(c.SITE) like 'ghazala' group by a.code_cl) a inner join scoesb02.classes1516 b on a.classe=b.code_cl group by niveau order by niveau", con);


                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }

             public DataTable bind_niveau_1516()
             {

                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 OracleCommand cmd = new OracleCommand();
                 cmd.Connection = con;
                 cmd.CommandText = " select  distinct substr(code_cl,1,1 ) as niveau from esp_inscription where annee_deb='2014' and substr(code_cl,1,1 ) in ('1','2','3','4','5') order by niveau  ";

                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 // con.Close();
                 return dt;
             }

             public DataTable bind_classes_1516(string niv)
             {

                 DataTable dt = new DataTable();
                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
               
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand();
                 cmd.Connection = con;
                 //cmd.CommandText = "select distinct a.code_cl from ESP_MODULE_PANIER_CLASSE_SAISO a left join classes1516 c on a.code_cl =c.code_cl  where a.code_cl like  '" + niv + "%' and lower(c.site) like 'ghazala' order BY fn_tri_classe(a.code_cl) ";
                 cmd.CommandText = "select distinct a.code_cl from esp_inscription a  where a.code_cl like  '" + niv + "%' and a.annee_deb='2014' order BY fn_tri_classe(a.code_cl) ";

                 //union select 'ALL' from dual


                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);
                 // con.Close();
                 return dt;
             }

             public DataTable bind_Nom_Ens(string code_classe)
             {

                 DataTable dt = new DataTable();
                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);


                 OracleCommand cmd = new OracleCommand();
                 cmd.Connection = con;
                 cmd.CommandText = "select (nom_et ||' ' ||pnom_et) as NOM from esp_etudiant e left join esp_inscription a on a.ID_ET=e.id_et where a.code_cl like '" + code_classe + "' and a.annee_deb='2014' ";
                 //union select 'ALL' from dual


                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);
                 // con.Close();
                 return dt;
             }

             public DataTable bind_niveau_ang_et(string nom_et, string code_clcl)
             {

                 DataTable dt = new DataTable();
                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();

                 OracleCommand cmd = new OracleCommand();
                 cmd.Connection = con;
                 cmd.CommandText = "select distinct a.id_et,(nom_et|| ' '||pnom_et) as NOM,a.NIV_ACQUIS_ANGLAIS,a.NIV_ACQUIS_FRANCAIS from esp_etudiant e left join esp_inscription a on a.ID_ET=e.id_et where a.annee_deb='2014' and (nom_et|| ' '||pnom_et) like '" + nom_et + "' and code_cl like '" + code_clcl + "'";


                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);
                 // con.Close();
                 return dt;
             }

             public DataTable bind_list_niveau()
             {

                 DataTable dt = new DataTable();
                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();

                 OracleCommand cmd = new OracleCommand();
                 cmd.Connection = con;
                 cmd.CommandText = "SELECT  DISTINCT a.NIV_ACQUIS_FRANCAIS FROM ESP_INSCRIPTION a where a.annee_deb='2014' ORDER BY a.NIV_ACQUIS_FRANCAIS";

                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);
                 // con.Close();
                 return dt;
             }


             public DataTable bind_list_niveau2()
             {

                 DataTable dt = new DataTable();
                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();

                 OracleCommand cmd = new OracleCommand();
                 cmd.Connection = con;
                 cmd.CommandText = "SELECT  DISTINCT a.NIV_ACQUIS_ANGLAIS FROM ESP_INSCRIPTION a where a.annee_deb='2014' ORDER BY a.NIV_ACQUIS_ANGLAIS";

                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);
                 // con.Close();
                 return dt;
             }

             public int Update_niv_etud(string id_etud, string niv_fr, string id_ens)
             {
                 OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
                  
                 OracleCommand cmd = new OracleCommand("UPDATE  esp_inscription  SET NIV_ACQUIS_FRANCAIS='" + niv_fr + "',user_lang_modif='" + id_ens + "'  where Id_et='" + id_etud + "' and annee_deb='2014'", cn);
                 cn.Open();
                 return cmd.ExecuteNonQuery();

             }

             public int Update_niv_etud_ang(string id_etud, string niv_ang, string id_ens)
             {
                 OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
                 OracleCommand cmd = new OracleCommand("UPDATE  esp_inscription  SET NIV_ACQUIS_ANGLAIS='" + niv_ang + "',user_lang_modif='" + id_ens + "'  where Id_et='" + id_etud + "'", cn);
                 cn.Open();
                 return cmd.ExecuteNonQuery();

             }

             public string GetUP(string id_ens)
             {

                 
                 string lib = "";
                 using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                     string cmdQuery = "select up from esp_enseignant WHERE ID_ENS='" + id_ens + "'";

                     OracleCommand myCommand = new OracleCommand(cmdQuery);
                     myCommand.Connection = mySqlConnection;
                     myCommand.CommandType = CommandType.Text;
                     lib = myCommand.ExecuteScalar().ToString();
                     mySqlConnection.Close();
            }
                 
                 return lib;


             }


             public DataTable get_id_etud_formatioParDate(string id_et, String date_choix)
             {

                 DataTable dt = new DataTable();
                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();

                 OracleCommand cmd = new OracleCommand("select * from ESP_TEST_ETUD where ESP_TEST_ETUD.id_et='" + id_et + "' and DATE_CHOIX='30/03/2016'", con);

                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }


             public string returnCLSUPPmax(string id_edt)
             {
                 string lib = " ";

                 using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
                 {
                     mySqlConnection.Open();


                     string cmdQuery = "select  MAX(code_cl) from esp_inscription,esp_etudiant  where esp_inscription.id_et=esp_etudiant.id_et  and ESP_ETUDIANT.etat='A' AND  esp_inscription.id_et='" + id_edt + "' and (annee_DEB='2015' or annee_DEB='2014') ";
                     OracleCommand myCommand = new OracleCommand(cmdQuery);
                     myCommand.Connection = mySqlConnection;
                     myCommand.CommandType = CommandType.Text;
                     lib = myCommand.ExecuteScalar().ToString();
                     mySqlConnection.Close();
                 }
                 return lib;
             }

             public string countnbinscrfr_date()
             {
                 string lib = "";

                 using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
                 {
                     mySqlConnection.Open();

                     string cmdQuery = " SELECT count(*) from esp_test_etud where to_date(DATE_CHOIX)=to_date('13/04/16','dd/MM/yy')";

                     OracleCommand myCommand = new OracleCommand(cmdQuery);
                     myCommand.Connection = mySqlConnection;
                     myCommand.CommandType = CommandType.Text;
                     lib = myCommand.ExecuteScalar().ToString();
                     mySqlConnection.Close();
                 }
                 return lib;

             }


             public void Enreg_etud_FORMAt_testparDATE(string id_et, string date)
             {
                 OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
                 conn.Open();
                 OracleCommand cmd = conn.CreateCommand();
                 // OracleCommand cmd1 = conn.CreateCommand();
                 cmd.CommandText = "INSERT INTO ESP_TEST_ETUD(ID_ET,TYPE_CHOIX,DATE_CHOIX,TYPE_TEST) VALUES ('" + id_et + "','0','" + date + "','T')";
                 //cmd1.CommandText = "INSERT INTO ESP_TEST_ETUD(ID_ET,TYPE_CHOIX,DATE_CHOIX,TYPE_TEST) VALUES ('" + id_et + "','" + _choix + "',to_date(sysdate,'dd/MM/yyyy'),'T')";
                 cmd.ExecuteNonQuery();
                 //cmd1.ExecuteNonQuery();

             }


             public DataTable get_id_etud_formatioParDateANG(string id_et, String date_choix)
             {

                 DataTable dt = new DataTable();
                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();

                 OracleCommand cmd = new OracleCommand("select * from ESP_TEST_ETUD where ESP_TEST_ETUD.id_et='" + id_et + "' and DATE_CHOIX='20/04/16'", con);

                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }
             public string countnbinscrANG_date()
             {
                 string lib = "";

                 using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
                 {
                     mySqlConnection.Open();

                     string cmdQuery = " SELECT count(*) from esp_test_etud where to_date(DATE_CHOIX)=to_date('20/04/2016','dd/MM/YYYY') and type_choix='0'";

                     OracleCommand myCommand = new OracleCommand(cmdQuery);
                     myCommand.Connection = mySqlConnection;
                     myCommand.CommandType = CommandType.Text;
                     lib = myCommand.ExecuteScalar().ToString();
                     mySqlConnection.Close();
                 }
                 return lib;

             }


             //formation29

             public DataTable Consult_list_formationggg()
             {
                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 OracleCommand cmd = new OracleCommand();
                 cmd.Connection = con;
                 cmd.CommandText = "select distinct e.nom_et,e.pnom_et,t.ID_ET,e.NIVEAU_COURANT_FR,NIVEAU_COURANT_ANG ,CASE t.type_choix WHEN '1' THEN 'Formation français' WHEN '2' THEN 'Formation Anglais' WHEN '3' THEN 'Formation français+Anglais' END as type_choix,i.CODE_CL,i.annee_deb from ESP_TEST_ETUD t  inner join esp_etudiant e on e.ID_ET=t.id_et  inner join esp_inscription i on t.ID_ET=i.id_et where  (i.ANNEE_DEB='2014' or i.ANNEE_DEB='2015') and code_cl like '5%' and code_cl not like '5TIC%' and to_date(t.DATE_CHOIX)=to_date('29/02/16','dd/MM/yy')order by type_choix";
                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);
                 return dt;
             }


             public DataTable verifieretudiant(string id_et)
             {
                 DataTable dt = new DataTable();
                 //string source = "DATA SOURCE= ;PERSIST SECURITY INFO=True;USER ID=SCOESB02;PASSWORD=tbzr10ep ";
                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();

                 OracleCommand cmd = new OracleCommand("select * from esp_test_etud where id_et='" + id_et + "' and type_test='F' and to_date(DATE_CHOIX)=to_date('29/02/16','dd/MM/yy') ", con);

                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);

                 con.Close();
                 return dt;
             }


             public void Enreg_etud_FORMATIONfr(string id_et, string _choix)
             {

                 OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
                 conn.Open();
                 OracleCommand cmd = conn.CreateCommand();

                 // cmd.CommandText = "INSERT INTO ESP_FORMATION_ETUD_LANGUE(ID_ET,TYPE_CHOIX,DATE_CHOIX) VALUES ('" + id_et + "','" + _choix + "',to_date(sysdate,'dd/MM/yyyy'))";

                 cmd.CommandText = "INSERT INTO ESP_TEST_ETUD(ID_ET,TYPE_CHOIX,DATE_CHOIX,TYPE_TEST) VALUES ('" + id_et + "','" + _choix + "',to_date('29/02/16','dd/MM/yy'),'F')";


                 cmd.ExecuteNonQuery();

             }


            


    }

    }


    

