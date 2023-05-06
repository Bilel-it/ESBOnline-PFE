using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using admiss;

namespace DAL
{
  public class AbsenceDAO
    {

      #region sing
        static AbsenceDAO instance;
        static Object locker = new Object();
        public static AbsenceDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new AbsenceDAO();
                    }

                    return AbsenceDAO.instance;
                }
            }

        }

        private AbsenceDAO() { }
        #endregion sing

        #region Connexion
        OracleConnection mySqlConnection = new OracleConnection("DATA SOURCE= ;PERSIST SECURITY INFO=True;USER ID=SCOESP09;PASSWORD= tbzr10ep");
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
      //bind list etudiant
        public DataTable bind_listetud()
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
           // cmd.CommandText = " select distinct a.code_cl from ESP_MODULE_PANIER_CLASSE_SAISO a where a.id_ens like '"+_id_ens+"' AND a.annee_deb='"+annedeb+"' and num_semestre='"+numsem+"' order BY fn_tri_classe(a.code_cl)";
            cmd.CommandText = "SELECT distinct t1.ID_ET,t1.ID_ET||' '||t1.NOM_ET||' '||t1.PNOM_ET Nom FROM ESP_ETUDIANT t1 inner join ESP_ABSENCE_NEW t2 on t1.id_et=t2.id_et inner join societe t3 on t3.annee_deb=t2.annee_deb";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        //bind data in a gridview
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

        public DataTable bind_dataetudabs(string _id_etud)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            // cmd.CommandText = translate(t3.designation, 'éèà&', 'eea') designation" select distinct a.code_cl from ESP_MODULE_PANIER_CLASSE_SAISO a where a.id_ens like '"+_id_ens+"' AND a.annee_deb='"+annedeb+"' and num_semestre='"+numsem+"' order BY fn_tri_classe(a.code_cl)";
            cmd.CommandText = "select t1.id_et,translate(t3.designation, 'éèà&', 'eea') designation,t3.CODE_MODULE,t4.NOM_ENS,t1.NUM_SEANCE,t1.DATE_SEANCE,t1.DATE_SAISIE,t1.CODE_CL from ESP_ABSENCE_NEW t1 inner join SOCIETE t2 on t1.annee_deb=t2.annee_deb inner join ESP_MODULE t3 on t3.CODE_MODULE=t1.CODE_MODULE inner join ESP_ENSEIGNANT t4 on t4.ID_ENS=t1.ID_ENS  where t1.id_et='" + _id_etud + "' and JUSTIFICATION='N' and JUSTIFICATION is not null ";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


       public string get_NAMES(string id_et)
       {
           string lib = "";

           using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
           {
               mySqlConnection.Open();

               string cmdQuery = "select t1.NOM_ET||' '||t1.PNOM_ET Nom FROM ESP_ETUDIANT t1 where id_et ='"+id_et+"'";


               OracleCommand myCommand = new OracleCommand(cmdQuery);
               myCommand.Connection = mySqlConnection;
               myCommand.CommandType = CommandType.Text;
               lib = myCommand.ExecuteScalar().ToString();
               mySqlConnection.Close();
           }
           return lib;
       }

       public string get_module(string code_module)
       {
           string lib = "";

           using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
           {
               mySqlConnection.Open();

               string cmdQuery = "select designation from esp_module where code_module='" + code_module + "'";


               OracleCommand myCommand = new OracleCommand(cmdQuery);
               myCommand.Connection = mySqlConnection;
               myCommand.CommandType = CommandType.Text;
               lib = myCommand.ExecuteScalar().ToString();
               mySqlConnection.Close();
           }
           return lib;
       }

       public DataTable bind_Module()
       {
           DataTable dt = new DataTable();

           OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
           con.Open();
           OracleCommand cmd = new OracleCommand();
           cmd.Connection = con;
           // cmd.CommandText = " select distinct a.code_cl from ESP_MODULE_PANIER_CLASSE_SAISO a where a.id_ens like '"+_id_ens+"' AND a.annee_deb='"+annedeb+"' and num_semestre='"+numsem+"' order BY fn_tri_classe(a.code_cl)";
           cmd.CommandText = "select distinct t1.code_module from ESP_MODULE_PANIER_CLASSE_SAISO t1 inner join SOCIETE t2 on t1.ANNEE_DEB=t2.ANNEE_DEB ";

           OracleDataAdapter od = new OracleDataAdapter(cmd);
           od.Fill(dt);
           return dt;
       }


       public DataTable bind_justif()
       {
           DataTable dt = new DataTable();

           OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
           con.Open();
           OracleCommand cmd = new OracleCommand();
           cmd.Connection = con;

           cmd.CommandText = "SELECT CODE_NOME ||' '||LIB_nome as LIB from CODE_NOMENCLATURE where code_str='43'";

           OracleDataAdapter od = new OracleDataAdapter(cmd);
           od.Fill(dt);
           return dt;
       }

       public string get_LIBjUSTIF(string CODE_NOME)
       {
           string lib = "";

           using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
           {
               mySqlConnection.Open();

               string cmdQuery = "SELECT LIB_NOME FROM CODE_NOMENCLATURE WHERE code_nome ='"+CODE_NOME+"' and code_str='43'";


               OracleCommand myCommand = new OracleCommand(cmdQuery);
               myCommand.Connection = mySqlConnection;
               myCommand.CommandType = CommandType.Text;
               lib = myCommand.ExecuteScalar().ToString();
               mySqlConnection.Close();
           }
           return lib;
       }


       public string get_ETUD(string NOM)
       {
           string lib = "";

           using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
           {
               mySqlConnection.Open();

               string cmdQuery = "SELECT NOM_ET ||' '||PNOM_ET FROM ESP_ETUDIANT WHERE ID_ET='"+NOM+"'";


               OracleCommand myCommand = new OracleCommand(cmdQuery);
               myCommand.Connection = mySqlConnection;
               myCommand.CommandType = CommandType.Text;
               lib = myCommand.ExecuteScalar().ToString();
               mySqlConnection.Close();
           }
           return lib;
       }
       public int Enreg_abs(string id_et,string lib_justif,string num_seance,DateTime date_seance,string cd)
       {
           //OracleConnection cn = new OracleConnection("DATA SOURCE= ;PERSIST SECURITY INFO=True;USER ID=SCOESP09;PASSWORD=tbzr10ep ");
           OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
           OracleCommand cmd = new OracleCommand("UPDATE ESP_ABSENCE_NEW set JUSTIFICATION='O',DATE_MODIF_JUSTIF= to_date(sysdate,'dd/MM/yy HH24:MI:SS'),LIB_JUSTIF='" + lib_justif + "',code_justif='" + cd + "' WHERE ID_ET='" + id_et + "' and DATE_SEANCE=to_date('" + date_seance + "','dd/MM/yy HH24:MI:SS') and NUM_SEANCE='" + num_seance + "'", con);
           con.Open();
           return cmd.ExecuteNonQuery();
       }


       public DataTable bind_dataetudabsBYmodule(string _code_module)
       {
           DataTable dt = new DataTable();

           OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
           con.Open();
           OracleCommand cmd = new OracleCommand();
           cmd.Connection = con;
           // cmd.CommandText = " select distinct a.code_cl from ESP_MODULE_PANIER_CLASSE_SAISO a where a.id_ens like '"+_id_ens+"' AND a.annee_deb='"+annedeb+"' and num_semestre='"+numsem+"' order BY fn_tri_classe(a.code_cl)";
           cmd.CommandText = "select t1.id_et,translate(t3.designation, 'éèà&', 'eea') designation,t3.CODE_MODULE,t4.NOM_ENS,t1.NUM_SEANCE,t1.DATE_SEANCE,t1.DATE_SAISIE,t1.CODE_CL from ESP_ABSENCE_NEW t1 inner join SOCIETE t2 on t1.annee_deb=t2.annee_deb inner join ESP_MODULE t3 on t3.CODE_MODULE=t1.CODE_MODULE inner join ESP_ENSEIGNANT t4 on t4.ID_ENS=t1.ID_ENS  where code_module='" + _code_module + "' and JUSTIFICATION='N' and JUSTIFICATION is not null";

           OracleDataAdapter od = new OracleDataAdapter(cmd);
           od.Fill(dt);
           return dt;
       }

  }
    }

