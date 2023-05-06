using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.ComponentModel;
using System.Data;
using admiss;
namespace DAL
{
    public class Admission
    {
        #region sing
        //OracleConnection mySqlConnection = new OracleConnection("DATA SOURCE= 10.0.0.5:1521/dbesb23;PERSIST SECURITY INFO=True;USER ID=SCOESB03;PASSWORD=Esp#hnrs#tbl21");
        //OracleConnection mySqlConnection2 = new OracleConnection("DATA SOURCE= 10.0.0.5:1521/dbesb23;PERSIST SECURITY INFO=True;USER ID=admis_esb;PASSWORD=admis1718");
        OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString2);
        OracleConnection mySqlConnection2 = new OracleConnection(AppConfiguration.myConnectionString);
        OracleTransaction myTrans;

        public void openconntrans()
        {
            mySqlConnection.Open(); 
            myTrans = mySqlConnection.BeginTransaction();

        }
        public string cmdQuery;
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
        
      
        static Admission instance;
        static Object locker = new Object();

        public static Admission Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Admission();
                    }

                    return Admission.instance;
                }
            }

        }
     


        private Admission() { }
        #endregion

           public DataTable getmoodle()
        {
            mySqlConnection2.Close();
            mySqlConnection2.Open();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand(" select COMPT_MOODEL,PWD_MOODEL from ESP_COMPT_MOODEL where COMPT_MOODEL not in (select esp_etudiant.COMPTE_MOODEL from esp_etudiant where id_et like '17%' and esp_etudiant.COMPTE_MOODEL is not null)and rownum='1'", mySqlConnection2);
            DataTable myDataTable = new DataTable();



            adapter.Fill(myDataTable);



            mySqlConnection2.Close();


            return myDataTable;

        }
        public DataTable list_ens_affectes()
        {

            mySqlConnection.Open();


            OracleDataAdapter adapter = new OracleDataAdapter();


            adapter.SelectCommand = new OracleCommand("select id_et,NOM_ET,PNOM_ET,e_mail_et,e2.NOM_ENS,DATE_AFFECTATION_ENS,dateentr,USER_AFFECTATION_ENS ,(case when SPECIALITE_ESP_ET='01' then 'Informatique' when SPECIALITE_ESP_ET='Télécom' then 'TIC' when SPECIALITE_ESP_ET='04'then 'EM' when SPECIALITE_ESP_ET='03' then 'GC' when SPECIALITE_ESP_ET='01' then 'INFO' when SPECIALITE_ESP_ET='02' then 'TELECOM'  when  SPECIALITE_ESP_ET='06' then 'Licence en Sciences de Gestion'  when SPECIALITE_ESP_ET='07'  then 'Licence en Informatique de Gestion' when SPECIALITE_ESP_ET='08' then 'Master en Management	Digital	et Systèmes d’Information'   when SPECIALITE_ESP_ET='09' then 'Master en Marketing Digital' when SPECIALITE_ESP_ET='10' then 'Master en Innovation	 Entrepreneuriat'   end)as nom,tel_et from admis_esb.esp_etudiant e1,scoesb02.ESP_ENSEIGNANT e2 where e1.ID_ENS_ENTRETIEN=e2.ID_ENS and id_et like (select concat( substr( max(annee_admission),3,2),'%') from admis_esb.societe) order by nom_ens  ", mySqlConnection);


            DataTable myDataTable = new DataTable();



            adapter.Fill(myDataTable);



            mySqlConnection.Close();


            return myDataTable;

        }




        public int updatemoodle(string id_et, string COMPT_MOODEL, string pwd_moodle)
        {
           
         
            OracleCommand cmd = new OracleCommand("update  esp_etudiant set COMPTE_MOODEL='" + COMPT_MOODEL + "',PWD_MOODEL='" + pwd_moodle + "'  where id_et='" + id_et + "' and COMPTE_MOODEL is null ",  mySqlConnection2);
            mySqlConnection2.Open();
            return cmd.ExecuteNonQuery();
            
        }

        public string nbCondidatsccna1(string dateins)
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = " select count(*) from esp_inscri where to_char (DATE_INS,'dd/MM/yyyy')=to_char('" + dateins + "') and HEURE_INS='08:30 à 10:30' ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string get_ANNEEDEB()
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
        public string moy_g(string id)
        {
            string mg = "";

            using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
            {
                con.Open();
                //string t = Session["ID_ET"].ToString().Trim();
                //string numc = Session["CIN_PASS"].ToString().Trim();
                OracleCommand cmd = new OracleCommand("SELECT MOY_GENERAL FROM ESP_INSCRIPTION where ANNEE_DEB=(select max(annee_deb) from societe) and id_et='" + id + "' and  code_cl <> '1-MDSI-%' and code_cl <> '1-BA-4'  and code_cl not like '1DSI-AS1%' and code_cl not like '2-DSI-A3%'   ");

                cmd.Connection = con;

                //                mg = cmd.ExecuteScalar().ToString();
               if( cmd.ExecuteScalar()==null)
                {
                    mg = "";
                    return mg;
                }
               else mg = cmd.ExecuteScalar().ToString();
                con.Close();
            }
          
                return mg;
        }

        public DataTable getnbparspe_niv(string spe, string niv)
        {
            mySqlConnection.Close();
            mySqlConnection.Open();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand("select substr(DATEENTR,0,6),SPECIALITE_ESP_ET,NIVEAU_ACCES,sum(nombre)nombre  from(select count(*)nombre,DATEENTR, (case when (SPECIALITE_ESP_ET='05' or SPECIALITE_ESP_ET='01' or SPECIALITE_ESP_ET='02') then 'TIC' when   SPECIALITE_ESP_ET='04' then 'EM' when SPECIALITE_ESP_ET='03' then 'GC' end)SPECIALITE_ESP_ET,NIVEAU_ACCES from scoesb02.esp_etudiant_enreg where id_et like '15%' and score_final is not null and DATEENTR    like '%-%' and SPECIALITE_ESP_ET='" + spe + "' and NIVEAU_ACCES='" + niv + "' group by DATEENTR,SPECIALITE_ESP_ET ,NIVEAU_ACCES order by TO_DATE(  DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American'),SPECIALITE_ESP_ET,NIVEAU_ACCES)group by DATEENTR,SPECIALITE_ESP_ET ,NIVEAU_ACCES order by TO_DATE(  DATEENTR, 'dd-MON-yyyy', 'NLS_DATE_LANGUAGE = American'),SPECIALITE_ESP_ET,NIVEAU_ACCES  ", mySqlConnection);
            DataTable myDataTable = new DataTable();



            adapter.Fill(myDataTable);



            mySqlConnection.Close();


            return myDataTable;

        }
        public DataTable getnbparspe2(string spe, string niv)
        {

            mySqlConnection.Open();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand(" SELECT COUNT(round( score_final,0)) AS NB,tt.id   ,SPECIALITE,niveau FROM ( SELECT 3 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL union     SELECT 6 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL union      SELECT 9 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL union        SELECT 12 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL union SELECT 15 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL        union        SELECT 18 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL     union        SELECT 21 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL     union        SELECT 24 as ID,'" + spe + "' as SPECIALITE,'" + niv + "'  niveau  FROM DUAL     union        SELECT 27 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL     union        SELECT 30 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL       union        SELECT 33 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL      union        SELECT 36 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL     union        SELECT 39 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL        union        SELECT 42 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL          union        SELECT 45 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL               union        SELECT 48 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL                   union        SELECT 51 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL          union        SELECT 54 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL           union        SELECT 57 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL            union        SELECT 60 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL             union        SELECT 63 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL              union        SELECT 66 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL               union        SELECT 69 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL                union        SELECT 72 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL                 union        SELECT 75 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL                  union        SELECT 78 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL  union  SELECT 81 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL                    union        SELECT 83 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL union SELECT 86 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL  union  SELECT 89 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL    union        SELECT 91 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL      union        SELECT 93 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL union SELECT 96 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL   union        SELECT 99 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL  union  SELECT 100 as ID,'" + spe + "' as SPECIALITE,'" + niv + "' niveau  FROM DUAL)  TT LEFT JOIN scoesb02.esp_etudiant_enreg on TT.id=round( score_final,0)   and TRIM(esp_etudiant_enreg.id_et) like '15%'  and SPECIALITE_ESP_ET=SPECIALITE and NIVEAU_ACCES=niveau GROUP BY TT.id ,SPECIALITE,niveau ORDER BY TT.id ASC", mySqlConnection);
            DataTable myDataTable = new DataTable();



            adapter.Fill(myDataTable);



            mySqlConnection.Close();


            return myDataTable;

        }


        public void update_dateENTR(string id_et, string dateentr)
        {

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                OracleCommand cmd = new OracleCommand("update  esp_etudiant set dateentr='" + dateentr + "' where id_et='" + id_et + "'  ", mySqlConnection);
                mySqlConnection.Open();
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
            }

        }

        public void update_datelimite(string dateentr)
        {

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                OracleCommand cmd = new OracleCommand("update  DATE_ENT set NOMBRE_CONDIDATS= NOMBRE_CONDIDATS+1 where DATE_ENT='" + dateentr + "'  ", mySqlConnection);
                mySqlConnection.Open();
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
            }

        }

        public DataTable getcandidats()
        {

            mySqlConnection.Open();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand("  select * from esp_etudiant where id_et like '15%T%' and score_entretien is null order by dateentr ", mySqlConnection);
            DataTable myDataTable = new DataTable();


           
                adapter.Fill(myDataTable);

          
           
                mySqlConnection.Close();
         

            return myDataTable;

        }

        public DataTable lr_etudiant(string arg_id_et)
        {

            mySqlConnection2.Open();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand("select MOY_BAC_ET,annee_bac,nature_bac,SPECIALITE_ESP_ET,NIVEAU_ACCES,annee_diplome,code_etab_origine,SESSION_BAC  from esp_etudiant where id_et = '" + arg_id_et + "' ", mySqlConnection2);
            DataTable myDataTable = new DataTable();



            adapter.Fill(myDataTable);



            mySqlConnection2.Close();


            return myDataTable;

        }
        public string nbCondidatsJuillet2014()
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.ESP_etudiant where  trim(id_et)  like '14%J%' and to_date(dateentr,'dd/MM/yy')<to_date('01/08/2014','dd/MM/yy') ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidatsaout2014()
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.ESP_etudiant where  trim(id_et)  like '14%J%' and to_date(dateentr,'dd/MM/yy')<to_date('01/09/2014','dd/MM/yy') ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidats2014testej()
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.ESP_etudiant_enreg e1 ,admis_esb.esp_etudiant e2 where  trim(e1.id_et)  like '14%J%' and e1.score_final is not null and trim(e1.id_et)=trim(e2.id_et) and to_date(e2.dateentr,'dd/MM/yy')<to_date('01/08/2014','dd/MM/yy') ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidats2014admisj()
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.ESP_etudiant_enreg e1,admis_esb.esp_etudiant e2 where  trim(e1.id_et)  like '14%J%' and trim(e1.id_et)=trim(e2.id_et) and e1.score_final is not null and code_decision='01' and to_date(e2.dateentr,'dd/MM/yy')<to_date('01/08/2015','dd/MM/yy') ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidats2014inscritj()
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.ESP_etudiant_enreg e1, esp_insCription e2,admis_esb.esp_etudiant e3 where  trim(e1.id_et)  like '15%J%' and trim(e1.id_et)=trim(e2.id_et)and trim(e1.id_et)=trim(e3.id_et) and  e1.score_final is not null and code_decision='01' and to_date(e3.dateentr,'dd/MM/yy')<to_date('01/08/2014','dd/MM/yy') and e2.annee_deb=2015  ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidats2014LAj()
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.ESP_etudiant_enreg e1  ,admis_esb.esp_etudiant e2 where  trim(e1.id_et)  like '15%J%'and trim(e1.id_et)=trim(e2.id_et) and e1.score_final is not null and code_decision='10' and to_date(e2.dateentr,'dd/MM/yy')<to_date('01/08/2014','dd/MM/yy') ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidats(string niv, string spe)
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.ESP_etudiant where NIVEAU_ACCES='" + niv + "' and SPECIALITE_ESP_ET='" + spe + "' and trim(id_et)  like '15%J%' ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidats2(string niv, string spe, string decision)
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from ESP_etudiant_ENREG where NIVEAU_ACCES='" + niv + "' and SPECIALITE_ESP_ET='" + spe + "' and CODE_DECISION='" + decision + "' and score_final is not null  and trim(id_et)  like '15%J%' ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidatsteste(string niv, string spe)
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from ESP_etudiant_ENREG where NIVEAU_ACCES='" + niv + "' and SPECIALITE_ESP_ET='" + spe + "'  and score_final is not null and trim(id_et)  like '15%J%' ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidats2014testeout()
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.ESP_etudiant_enreg e1,admis_esb.esp_etudiant e2 where  trim(e1.id_et)  like '14%J%' and trim(e1.id_et)=trim(e2.id_et) and e1.score_final is not null and to_date(e2.dateentr,'dd/MM/yy')<to_date('01/09/2014','dd/MM/yy') ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidats2014admisa()
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.ESP_etudiant_enreg e1,admis_esb.esp_etudiant e2 where  trim(e1.id_et)  like '14%J%' and trim(e1.id_et)=trim(e2.id_et) and e1.score_final is not null and code_decision='01' and to_date(e2.dateentr,'dd/MM/yy')<to_date('01/09/2014','dd/MM/yy') ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidats2014inscrita()
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.ESP_etudiant_enreg e1, esp_insCription e2,admis_esb.esp_etudiant e3 where  trim(e1.id_et)  like '14%J%'  and trim(e1.id_et)=trim(e2.id_et)and trim(e1.id_et)=trim(e3.id_et) and  e1.score_final is not null and e1.code_decision='01' and to_date(e3.dateentr,'dd/MM/yy')<to_date('01/09/2014','dd/MM/yy') and e2.annee_deb=2014  ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidats2014LAout()
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.ESP_etudiant_enreg e1,admis_esb.esp_etudiant e2 where  trim(e1.id_et)  like '14%J%' and trim(e1.id_et)=trim(e2.id_et) and e1.score_final is not null and code_decision='10' and to_date(e2.dateentr,'dd/MM/yy')<to_date('01/09/2014','dd/MM/yy') ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }

        public string nbcandidats2015(string datec)
        {

            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.ESP_etudiant where  trim(id_et)  like '14%J%' and to_date(dateentr,'dd/MM/yy')<=to_date('" + datec + "','dd/MM/yy') ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbcandidats2015teste(string datec)
        {

            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.ESP_etudiant  e1,scoesb02.esp_etudiant_enreg e2 where  trim(e1.id_et)  like '15%J%' and to_date(e1.dateentr,'dd/MM/yy')<=to_date('" + datec + "','dd/MM/yy')and trim(e1.id_et)=trim(e2.id_et) and  e2.score_final is not null";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbcandidats2015admis(string datec)
        {

            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.ESP_etudiant  e1,scoesb02.esp_etudiant_enreg e2 where  trim(e1.id_et)  like '15%J%' and to_date(e1.dateentr,'dd/MM/yy')<=to_date('" + datec + "','dd/MM/yy')and trim(e1.id_et)=trim(e2.id_et) and  e2.score_final is not null and e2.code_decision='01'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbcandidats2015LA(string datec)
        {

            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.ESP_etudiant  e1,scoesb02.esp_etudiant_enreg e2 where  trim(e1.id_et)  like '15%J%' and to_date(dateentr,'dd/MM/yy')<=to_date('" + datec + "','dd/MM/yy')and trim(e1.id_et)=trim(e2.id_et) and  e2.score_final is not null and e2.code_decision='10'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }
        public string nbCondidats2015inscrit(string datec)
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.ESP_etudiant_enreg e1, esp_insCription e2,admis_esb.esp_etudiant e3 where  trim(e1.id_et)  like '15%J%'  and trim(e1.id_et)=trim(e2.id_et)and trim(e1.id_et)=trim(e3.id_et) and  e1.score_final is not null and e1.code_decision='01' and to_date(e3.dateentr,'dd/MM/yy')<=to_date('" + datec + "','dd/MM/yy') and e2.annee_deb=2015  ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }




        public void transfer_to_etudiant(string id_et)
        {
            using (OracleConnection mySqlConnection4 = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection4.Open();
                OracleCommand comando = new OracleCommand("transfer_to_etudiant", mySqlConnection4);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(":id_ett", OracleDbType.Varchar2).Value = id_et;
                comando.ExecuteNonQuery();
                mySqlConnection4.Close();
            }

        }

        public void transfer_to_etudiant_ENREG(string id_et)
        {
            using (OracleConnection mySqlConnection4 = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection4.Open();




                OracleCommand comando = new OracleCommand(" transfer_to_enreg", mySqlConnection4);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(":id_ett", OracleDbType.Varchar2).Value = id_et;
                comando.ExecuteNonQuery();
                mySqlConnection4.Close();
            }

        }

        public DataTable getPJS(string code_mat)
        {

            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString5);
            con.Open();
            // OracleCommand cmd = new OracleCommand("select e.emp_code,e.emp_nom||' '||e.EMP_PRENOM Nom,IMAGE_CIN,DERNIER_EXTRAIT_NAISS_PERE,DERNIER_EXTRAIT_NAISS_MERE,DERNIER_EXTRAIT_NAISS_ENFANTS,DIPLOME_BAC,DIPLOME_UNIVERSITAIRE,PV_RECRUT,PV_PROMOTION,EXTRAIT_RIB,p.PHOTO from esp_document_employee d inner join employe e  on e.emp_code=d.code_mat inner join EMPLOYE_PHOTO p on p.emp_code=d.code_mat where e.emp_code='"+code_mat+"'", con);
            OracleCommand cmd = new OracleCommand("select id_et,photos_id from ADMIS_ESB.photos_etudiant  where id_et='" + code_mat + "'", con);


            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            con.Close();
            return dt;
        }



        public string get_speadmission(string id_et)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT SPECIALITE_ESP_ET FROM  ADMIS_ESB.esp_etudiant where id_et='" + id_et + "' and id_et like '23%'  ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public void add_journal_RACHAT(string id_et, string IPt)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString5);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO ESP_JOURNAL_RACHAT(ID_ET,UTILISATEUR,ADRESSE_IP) VALUES ('" + id_et + "','HASSINE','" + IPt + "')";

            cmd.ExecuteNonQuery();

        }


        public void updatedecisionBONUS(string id_et)
        {

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                OracleCommand cmd = new OracleCommand("update  ADMIS_ESB.esp_etudiant set CODE_DECISION='01'  where id_et='" + id_et + "'  ", mySqlConnection);
                mySqlConnection.Open();
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
            }

        }

        public void updatedecision23licence(string id_et)
        {

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                OracleCommand cmd = new OracleCommand("update  esp_etudiant set CODE_DECISION='23'  where id_et='" + id_et + "'  ", mySqlConnection);
                mySqlConnection.Open();
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
            }

        }


        public void Insert_inti_comp(string id_et, string IPt)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString5);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO ADMIS_ESB.ESP_COMPTCE_SPECIFIQ_CANDIDATS(ID_ET,COMP_ET) VALUES ('" + id_et + "','" + IPt + "')";

            cmd.ExecuteNonQuery();

        }

        public string get_niveauadmission(string id_et)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT niveau_acces FROM  ADMIS_ESB.esp_etudiant where id_et='" + id_et + "' and id_et like '23%' ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public DataTable getinfoetranger()
        {

            mySqlConnection2.Open();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand(" SELECT  T1.num_cin_passeport, T1.NOM_ET||' '||T1.PNOM_ET nom,(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC='03' then 'SC EXP' WHEN NATURE_BAC='02' then 'ECONOMIE' when NATURE_BAC='04' then 'TECHNIQUE'  when NATURE_BAC='35' then 'INFO' end)NATURE_BAC,SCORE_dossier,T1.SCORE_ENTRETIEN,score_final,score_francais,score_qi,score_anglais,T1.ANNEE_BAC,T1.MOY_BAC_ET,T1.NIVEAU_ACCES,T1.DIPLOME_SUP_ET,T1.E_MAIL_ET,T1.PASSWORD,(case when t1.SPECIALITE_ESP_ET='05' then 'TIC' when t1.SPECIALITE_ESP_ET='04' then 'EM' when t1.SPECIALITE_ESP_ET='03' then 'GC'  when t1.SPECIALITE_ESP_ET='01' then 'INFO' when t1.SPECIALITE_ESP_ET='02' then 'TELECOM'   when t1.SPECIALITE_ESP_ET='06' then 'Licence en Sciences de Gestion'  when t1.SPECIALITE_ESP_ET='07'  then 'Licence en Informatique de Gestion'   when t1.SPECIALITE_ESP_ET='08' then 'Master en Management	Digital	et Systèmes d’Information'   when t1.SPECIALITE_ESP_ET='09' then 'Master en Marketing Digital' when t1.SPECIALITE_ESP_ET='10' then 'Master en Innovation	 Entrepreneuriat'   end) SPECIALITE_ESP_ET ,T1.ID_ET,T1.dateentr,etab_origine, T1.TEL_ET,T1.NATIONALITE FROM   ESP_ETUDIANT t1  WHERE   id_et like '23%' and   id_et not in (select id_et from scoesb02.esp_etudiant where  id_et like '23%'  ) ", mySqlConnection2);
            DataTable myDataTable = new DataTable();



            adapter.Fill(myDataTable);



            mySqlConnection2.Close();


            return myDataTable;

        }



        public DataTable getinfodossierreussi()
        {

            mySqlConnection2.Open();


            OracleDataAdapter adapter = new OracleDataAdapter();
            //ici juste//
            adapter.SelectCommand = new OracleCommand("SELECT  T1.num_cin_passeport,T1.NOM_ET||' '||T1.PNOM_ET nom,(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC='03' then 'SC EXP' WHEN NATURE_BAC='02' then 'ECONOMIE' when NATURE_BAC='04' then 'TECHNIQUE'  when NATURE_BAC='35' then 'INFO' end)NATURE_BAC,SCORE_dossier,T1.SCORE_ENTRETIEN,score_final,score_francais,score_qi,score_anglais,T1.ANNEE_BAC,T1.MOY_BAC_ET,T1.NIVEAU_ACCES,T1.DIPLOME_SUP_ET,T1.E_MAIL_ET,T1.PASSWORD,(case when SPECIALITE_ESP_ET='05' then 'TIC' when SPECIALITE_ESP_ET='04' then 'EM' when SPECIALITE_ESP_ET='03' then 'GC'  when SPECIALITE_ESP_ET = '01' then 'INFO' when SPECIALITE_ESP_ET = '02' then 'TELECOM'   when SPECIALITE_ESP_ET = '06' then 'Licence en sciences de gestion Parcours Management' when SPECIALITE_ESP_ET = '07'  then 'Licence en sciences de gestion Parcours comptabilité'   when SPECIALITE_ESP_ET = '08' then 'Master professionnel de management digital et systèmes d information'   when SPECIALITE_ESP_ET = '09' then 'Master professionnel en Marketing digital' when SPECIALITE_ESP_ET = '10' then 'Master professionnel en innovation et entrepreneuriat' when SPECIALITE_ESP_ET = '16' then 'Licence Informatique Mention Business Computing Parcours Information System' when SPECIALITE_ESP_ET = '17' then 'Licence Informatique Mention Business Computing Parcours Business Intelligence' when SPECIALITE_ESP_ET = '18' then 'Licence Mathématiques appliqués à l analyse des données et à la décision' when SPECIALITE_ESP_ET = '11' then 'Master professionnel en Business Analytics' when SPECIALITE_ESP_ET = '12' then 'Master professionnel comptabilité contrôle audit' when SPECIALITE_ESP_ET = '21' then 'MDSI Alternance VERMEG' when SPECIALITE_ESP_ET = '22' then 'MDSI Exécutif' end) SPECIALITE_ESP_ET ,T1.ID_ET,T1.dateentr,etab_origine, T1.TEL_ET,T1.NATIONALITE FROM   ESP_ETUDIANT t1  WHERE   code_decision ='01' and id_et like '23%T%'     and  trim(t1.id_et) not in (select trim(g.id_et) from scoesb02.esp_etudiant_enreg g where g.id_et like '23%T%') order by t1.score_final", mySqlConnection2);

            //adapter.SelectCommand = new OracleCommand("SELECT  T1.num_cin_passeport,T1.NOM_ET||' '||T1.PNOM_ET nom,(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC='03' then 'SC EXP' WHEN NATURE_BAC='02' then 'ECONOMIE' when NATURE_BAC='04' then 'TECHNIQUE'  when NATURE_BAC='35' then 'INFO' end)NATURE_BAC,SCORE_dossier,T1.SCORE_ENTRETIEN,score_final,score_francais,score_qi,score_anglais,T1.ANNEE_BAC,T1.MOY_BAC_ET,T1.NIVEAU_ACCES,T1.DIPLOME_SUP_ET,T1.E_MAIL_ET,T1.PASSWORD,(case when t1.SPECIALITE_ESP_ET='05' then 'TIC' when t1.SPECIALITE_ESP_ET='04' then 'EM' when t1.SPECIALITE_ESP_ET='03' then 'GC'  when t1.SPECIALITE_ESP_ET='01' then 'INFO' when t1.SPECIALITE_ESP_ET='02' then 'TELECOM'   when t1.SPECIALITE_ESP_ET='06' then 'Licence en Sciences de Gestion'  when t1.SPECIALITE_ESP_ET='07'  then 'Licence en Informatique de Gestion'   when t1.SPECIALITE_ESP_ET='08' then 'Master en Management	Digital	et Systèmes d’Information'   when t1.SPECIALITE_ESP_ET='09' then 'Master en Marketing Digital' when t1.SPECIALITE_ESP_ET='10' then 'Master en Innovation	 Entrepreneuriat'   end) SPECIALITE_ESP_ET ,T1.ID_ET,T1.dateentr,etab_origine, T1.TEL_ET,T1.NATIONALITE FROM   ESP_ETUDIANT t1  WHERE   t1.id_et in('191JFT0177','191JFT0183','191JFT0190','191JFT0226','191JFT0265','191JFT0274','191JFT0290','191JFT0387','191JFT0544','191JFT0688','191JMT0178','191JMT0185','191JMT0192','191JMT0216','191JMT0218','191JMT0236','191JMT0262','191JMT0264','191JMT0273','191JMT0289','191JMT0393','191JMT0439','191JMT0449','191JMT0457','191JMT0462','191JMT0563','191JMT0564','191JMT0578','191JMT0638','191JMT0676','191JMT0717','191SFT0193','191SFT0203','191SFT0272','191SFT0298','191SMT0174','191SMT0182','191SMT0191','191SMT0206','191SMT0209','191SMT0234','191SMT0240','191SMT0245','191SMT0261','192JFT0210','192JMT0196','192SFT0148','192SFT0188','192SMT0077','192SMT0208','193JFT0180','193JFT0189','193JFT0255','193JFT0280','193JFT0294','193JFT0354','193JFT0420','193JFT0442','193JFT0443','193JFT0458','193JFT0470','193JFT0494','193JFT0529','193JFT0540','193JFT0595','193JFT0620','193JMT0014','193JMT0179','193JMT0181','193JMT0198','193JMT0201','193JMT0217','193JMT0225','193JMT0237','193JMT0242','193JMT0250','193JMT0266','193JMT0267','193JMT0270','193JMT0271','193JMT0285','193JMT0286','193JMT0315','193JMT0351','193JMT0407','193JMT0463','193JMT0477','193JMT0515','193JMT0525','193JMT0535','193JMT0561','193JMT0565','193JMT0580','193JMT0590','193JMT0592','193JMT0596','193JMT0597','193JMT0637','193JMT0643','193JMT0669','193JMT0672','193JMT0689','193JMT0693','193JMT0703','193JMT0707','193JMT0714')", mySqlConnection);



            // adapter.SelectCommand = new OracleCommand("SELECT T1.num_cin_passeport,T1.NOM_ET||' '||T1.PNOM_ET nom,(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC='03' then 'SC EXP' WHEN NATURE_BAC='02' then 'ECONOMIE' when NATURE_BAC='04' then 'TECHNIQUE'  when NATURE_BAC='35' then 'INFO' end)NATURE_BAC,SCORE_dossier,T1.SCORE_ENTRETIEN,score_final,score_francais,score_qi,score_anglais,T1.ANNEE_BAC,T1.MOY_BAC_ET,T1.NIVEAU_ACCES,T1.DIPLOME_SUP_ET,T1.E_MAIL_ET,T1.PASSWORD,(case when t1.SPECIALITE_ESP_ET='05' then 'TIC' when t1.SPECIALITE_ESP_ET='04' then 'EM' when t1.SPECIALITE_ESP_ET='03' then 'GC'  when t1.SPECIALITE_ESP_ET='01' then 'INFO' when t1.SPECIALITE_ESP_ET='02' then 'TELECOM'   when t1.SPECIALITE_ESP_ET='06' then 'Licence en Sciences de Gestion'  when t1.SPECIALITE_ESP_ET='07'  then 'Licence en Informatique de Gestion'   when t1.SPECIALITE_ESP_ET='08' then 'Master en Management	Digital	et Systèmes d’Information'   when t1.SPECIALITE_ESP_ET='09' then 'Master en Marketing Digital' when t1.SPECIALITE_ESP_ET='10' then 'Master en Innovation	 Entrepreneuriat'   end) SPECIALITE_ESP_ET ,T1.ID_ET,T1.dateentr,etab_origine, T1.TEL_ET,T1.NATIONALITE FROM   ESP_ETUDIANT t1  WHERE   t1.id_et in ('181SMT0102','183JMT3261','183JMT1876','181SMT0890','183JMT3433','181SMT2973','183JMT3163','181SMT1178','181SMT0050','181SFT0075','183JMT3512','183JMT3344','182SMT0928','182SMT0065','183JMT3102','181SFT0355','181SMT0585','183JMT3558','181SMT0260','181SFT0566','183JMT3418','183JMT3239','181SMT0369','183JMT3170','183JFT2574','182SMT0088','183JMT3344','183JMT3469','181SMT0440','183JMT3512')  and  trim(t1.id_et) not in (select trim(g.id_et) from scoesb02.esp_etudiant_enreg g where g.id_et like '22%T%')", mySqlConnection);


            DataTable myDataTable = new DataTable();



            adapter.Fill(myDataTable);



            mySqlConnection2.Close();


            return myDataTable;

        }


        public DataTable getinfodossierreussipreadmis(string score, string niveau, string deb , string fin)
        {



            mySqlConnection2.Open();


            OracleDataAdapter adapter = new OracleDataAdapter();
            //ici juste//
            adapter.SelectCommand = new OracleCommand("SELECT  T1.num_cin_passeport,T1.NOM_ET||' '||T1.PNOM_ET nom,(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC='03' then 'SC EXP' WHEN NATURE_BAC='02' then 'ECONOMIE' when NATURE_BAC='04' then 'TECHNIQUE' when NATURE_BAC='35' then 'INFO' end)NATURE_BAC,SCORE_dossier,T1.SCORE_ENTRETIEN,score_final,score_francais,score_qi,score_anglais,T1.ANNEE_BAC,T1.MOY_BAC_ET,T1.NIVEAU_ACCES,T1.DIPLOME_SUP_ET,T1.E_MAIL_ET,T1.PASSWORD,(case when SPECIALITE_ESP_ET='05' then 'TIC' when SPECIALITE_ESP_ET='04' then 'EM' when SPECIALITE_ESP_ET='03' then 'GC'  when SPECIALITE_ESP_ET = '01' then 'INFO' when SPECIALITE_ESP_ET = '02' then 'TELECOM'   when SPECIALITE_ESP_ET = '06' then 'Licence en sciences de gestion Parcours Management' when SPECIALITE_ESP_ET = '07'  then 'Licence en sciences de gestion Parcours comptabilité'   when SPECIALITE_ESP_ET = '08' then 'Master professionnel de management digital et systèmes d information'   when SPECIALITE_ESP_ET = '09' then 'Master professionnel en Marketing digital' when SPECIALITE_ESP_ET = '10' then 'Master professionnel en innovation et entrepreneuriat' when SPECIALITE_ESP_ET = '16' then 'Licence Informatique Mention Business Computing Parcours Information System' when SPECIALITE_ESP_ET = '17' then 'Licence Informatique Mention Business Computing Parcours Business Intelligence' when SPECIALITE_ESP_ET = '18' then 'Licence Mathématiques appliqués à l analyse des données et à la décision' when SPECIALITE_ESP_ET = '11' then 'Master professionnel en Business Analytics' when SPECIALITE_ESP_ET = '12' then 'Master professionnel comptabilité contrôle audit' when SPECIALITE_ESP_ET = '21' then 'MDSI Alternance VERMEG' when SPECIALITE_ESP_ET = '22' then 'MDSI Exécutif' end) SPECIALITE_ESP_ET ,T1.ID_ET,T1.dateentr,etab_origine, T1.TEL_ET,T1.NATIONALITE FROM   ESP_ETUDIANT t1  WHERE    id_et like '23%T%'   and  t1.NIVEAU_ACCES='" + niveau + "'   and t1.SCORE_FINAL >= '" + score + "' and t1.CODE_DECISION is null and  trim(t1.id_et) not in (select trim(g.id_et) from scoesb02.esp_etudiant_enreg g where g.id_et like '23%T%') and t1.DATEENTR IN (select DATE_ENT from DATE_ENT where TO_DATE(DATE_ENT.DATEREEL) BETWEEN to_date('" + deb + "', 'YYYY/MM/DD') and to_date('" + fin + "', 'YYYY/MM/DD')) order by  t1.score_final DESC", mySqlConnection2);

//            adapter.SelectCommand = new OracleCommand("SELECT  T1.num_cin_passeport,T1.NOM_ET||' '||T1.PNOM_ET nom,(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC='03' then 'SC EXP' WHEN NATURE_BAC='02' then 'ECONOMIE' when NATURE_BAC='04' then 'TECHNIQUE'  when NATURE_BAC='35' then 'INFO' end)NATURE_BAC,SCORE_dossier,T1.SCORE_ENTRETIEN,score_final,score_francais,score_qi,score_anglais,T1.ANNEE_BAC,T1.MOY_BAC_ET,T1.NIVEAU_ACCES,T1.DIPLOME_SUP_ET,T1.E_MAIL_ET,T1.PASSWORD,(case when SPECIALITE_ESP_ET='05' then 'TIC' when SPECIALITE_ESP_ET='04' then 'EM' when SPECIALITE_ESP_ET='03' then 'GC'  when SPECIALITE_ESP_ET = '01' then 'INFO' when SPECIALITE_ESP_ET = '02' then 'TELECOM'   when SPECIALITE_ESP_ET = '06' then 'Licence en sciences de gestion Parcours Management' when SPECIALITE_ESP_ET = '07'  then 'Licence en sciences de gestion Parcours comptabilité'   when SPECIALITE_ESP_ET = '08' then 'Master professionnel de management digital et systèmes d information'   when SPECIALITE_ESP_ET = '09' then 'Master professionnel en Marketing digital' when SPECIALITE_ESP_ET = '10' then 'Master professionnel en innovation et entrepreneuriat' when SPECIALITE_ESP_ET = '16' then 'Licence Informatique Mention Business Computing Parcours Information System' when SPECIALITE_ESP_ET = '17' then 'Licence Informatique Mention Business Computing Parcours Business Intelligence' when SPECIALITE_ESP_ET = '18' then 'Licence Mathématiques appliqués à l analyse des données et à la décision' when SPECIALITE_ESP_ET = '11' then 'Master professionnel en Business Analytics' when SPECIALITE_ESP_ET = '12' then 'Master professionnel comptabilité contrôle audit' when SPECIALITE_ESP_ET = '21' then 'MDSI Alternance VERMEG' when SPECIALITE_ESP_ET = '22' then 'MDSI Exécutif' end) SPECIALITE_ESP_ET ,T1.ID_ET,T1.dateentr,etab_origine, T1.TEL_ET,T1.NATIONALITE FROM   ESP_ETUDIANT t1  WHERE    id_et like '22%T%'   and  t1.NIVEAU_ACCES='" + niveau + "'   and t1.SCORE_FINAL >= '" + score + "' and t1.CODE_DECISION is null and  trim(t1.id_et) not in (select trim(g.id_et) from scoesb02.esp_etudiant_enreg g where g.id_et like '22%T%') order by  t1.score_final DESC", mySqlConnection2);


            //adapter.SelectCommand = new OracleCommand("SELECT  T1.num_cin_passeport,T1.NOM_ET||' '||T1.PNOM_ET nom,(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC='03' then 'SC EXP' WHEN NATURE_BAC='02' then 'ECONOMIE' when NATURE_BAC='04' then 'TECHNIQUE'  when NATURE_BAC='35' then 'INFO' end)NATURE_BAC,SCORE_dossier,T1.SCORE_ENTRETIEN,score_final,score_francais,score_qi,score_anglais,T1.ANNEE_BAC,T1.MOY_BAC_ET,T1.NIVEAU_ACCES,T1.DIPLOME_SUP_ET,T1.E_MAIL_ET,T1.PASSWORD,(case when t1.SPECIALITE_ESP_ET='05' then 'TIC' when t1.SPECIALITE_ESP_ET='04' then 'EM' when t1.SPECIALITE_ESP_ET='03' then 'GC'  when t1.SPECIALITE_ESP_ET='01' then 'INFO' when t1.SPECIALITE_ESP_ET='02' then 'TELECOM'   when t1.SPECIALITE_ESP_ET='06' then 'Licence en Sciences de Gestion'  when t1.SPECIALITE_ESP_ET='07'  then 'Licence en Informatique de Gestion'   when t1.SPECIALITE_ESP_ET='08' then 'Master en Management	Digital	et Systèmes d’Information'   when t1.SPECIALITE_ESP_ET='09' then 'Master en Marketing Digital' when t1.SPECIALITE_ESP_ET='10' then 'Master en Innovation	 Entrepreneuriat'   end) SPECIALITE_ESP_ET ,T1.ID_ET,T1.dateentr,etab_origine, T1.TEL_ET,T1.NATIONALITE FROM   ESP_ETUDIANT t1  WHERE   t1.id_et in('191JFT0177','191JFT0183','191JFT0190','191JFT0226','191JFT0265','191JFT0274','191JFT0290','191JFT0387','191JFT0544','191JFT0688','191JMT0178','191JMT0185','191JMT0192','191JMT0216','191JMT0218','191JMT0236','191JMT0262','191JMT0264','191JMT0273','191JMT0289','191JMT0393','191JMT0439','191JMT0449','191JMT0457','191JMT0462','191JMT0563','191JMT0564','191JMT0578','191JMT0638','191JMT0676','191JMT0717','191SFT0193','191SFT0203','191SFT0272','191SFT0298','191SMT0174','191SMT0182','191SMT0191','191SMT0206','191SMT0209','191SMT0234','191SMT0240','191SMT0245','191SMT0261','192JFT0210','192JMT0196','192SFT0148','192SFT0188','192SMT0077','192SMT0208','193JFT0180','193JFT0189','193JFT0255','193JFT0280','193JFT0294','193JFT0354','193JFT0420','193JFT0442','193JFT0443','193JFT0458','193JFT0470','193JFT0494','193JFT0529','193JFT0540','193JFT0595','193JFT0620','193JMT0014','193JMT0179','193JMT0181','193JMT0198','193JMT0201','193JMT0217','193JMT0225','193JMT0237','193JMT0242','193JMT0250','193JMT0266','193JMT0267','193JMT0270','193JMT0271','193JMT0285','193JMT0286','193JMT0315','193JMT0351','193JMT0407','193JMT0463','193JMT0477','193JMT0515','193JMT0525','193JMT0535','193JMT0561','193JMT0565','193JMT0580','193JMT0590','193JMT0592','193JMT0596','193JMT0597','193JMT0637','193JMT0643','193JMT0669','193JMT0672','193JMT0689','193JMT0693','193JMT0703','193JMT0707','193JMT0714')", mySqlConnection);



            // adapter.SelectCommand = new OracleCommand("SELECT T1.num_cin_passeport,T1.NOM_ET||' '||T1.PNOM_ET nom,(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC='03' then 'SC EXP' WHEN NATURE_BAC='02' then 'ECONOMIE' when NATURE_BAC='04' then 'TECHNIQUE'  when NATURE_BAC='35' then 'INFO' end)NATURE_BAC,SCORE_dossier,T1.SCORE_ENTRETIEN,score_final,score_francais,score_qi,score_anglais,T1.ANNEE_BAC,T1.MOY_BAC_ET,T1.NIVEAU_ACCES,T1.DIPLOME_SUP_ET,T1.E_MAIL_ET,T1.PASSWORD,(case when t1.SPECIALITE_ESP_ET='05' then 'TIC' when t1.SPECIALITE_ESP_ET='04' then 'EM' when t1.SPECIALITE_ESP_ET='03' then 'GC'  when t1.SPECIALITE_ESP_ET='01' then 'INFO' when t1.SPECIALITE_ESP_ET='02' then 'TELECOM'   when t1.SPECIALITE_ESP_ET='06' then 'Licence en Sciences de Gestion'  when t1.SPECIALITE_ESP_ET='07'  then 'Licence en Informatique de Gestion'   when t1.SPECIALITE_ESP_ET='08' then 'Master en Management	Digital	et Systèmes d’Information'   when t1.SPECIALITE_ESP_ET='09' then 'Master en Marketing Digital' when t1.SPECIALITE_ESP_ET='10' then 'Master en Innovation	 Entrepreneuriat'   end) SPECIALITE_ESP_ET ,T1.ID_ET,T1.dateentr,etab_origine, T1.TEL_ET,T1.NATIONALITE FROM   ESP_ETUDIANT t1  WHERE   t1.id_et in ('181SMT0102','183JMT3261','183JMT1876','181SMT0890','183JMT3433','181SMT2973','183JMT3163','181SMT1178','181SMT0050','181SFT0075','183JMT3512','183JMT3344','182SMT0928','182SMT0065','183JMT3102','181SFT0355','181SMT0585','183JMT3558','181SMT0260','181SFT0566','183JMT3418','183JMT3239','181SMT0369','183JMT3170','183JFT2574','182SMT0088','183JMT3344','183JMT3469','181SMT0440','183JMT3512')  and  trim(t1.id_et) not in (select trim(g.id_et) from scoesb02.esp_etudiant_enreg g where g.id_et like '22%T%')", mySqlConnection);


            DataTable myDataTable = new DataTable();



            adapter.Fill(myDataTable);



            mySqlConnection2.Close();


            return myDataTable;

        }

        public string nbadmisreussis()
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT  count(*) FROM   ESP_ETUDIANT t1  WHERE   code_decision ='01'  and id_et not like ('184%') and id_et like '23%T%' And  trim(t1.id_et) not in (select trim(g.id_et) from esp_etudiant_enreg g where g.id_et like '23%T%') order by score_final";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }

        public string Getscorefinal(string id_et)
        {
            string NB = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = " select SCORE_FINAL from ESP_ETUDIANT where id_et='" + id_et + "' ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                NB = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return NB;
        }

        public void Modif_score(string score, string id_et)
        {

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                OracleCommand cmd = new OracleCommand("update  esp_etudiant set SCORE_FINAL='" + score + "'  where id_et='" + id_et + "'  ", mySqlConnection);



                mySqlConnection.Open();
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
                OracleCommand cmd2 = new OracleCommand("update  esp_etudiant_enreg set SCORE_FINAL='" + score + "'  where id_et='" + id_et + "'  ", mySqlConnection);

                mySqlConnection.Open();
                cmd2.ExecuteNonQuery();
                mySqlConnection.Close();
            }

        }

        public void update_scoreentretien(decimal scoreentretien, string ens ,string observation ,string id_et)
        {

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                OracleCommand cmd = new OracleCommand("update  ADMIS_ESB.esp_etudiant set SCORE_ENTRETIEN='" + scoreentretien + "', ID_ENS_ENTRETIEN='" + ens + "',OBSERVATION_ENTRETIEN= '" + observation + "'  where id_et='" + id_et + "'  ", mySqlConnection);
                mySqlConnection.Open();
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
              
            }

        }




        public void ESP_JOURNAL_4ADMISSIBLE(string id_et, string IPt)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString5);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO ESP_JOURNAL_4ADMISSIBLE(ID_ET,UTILISATEUR,ADRESSE_IP) VALUES ('" + id_et + "','HASSINE','" + IPt + "')";

            cmd.ExecuteNonQuery();

        }


        public void mail_envoyer4emme(string id_et)
        {

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                OracleCommand cmd = new OracleCommand("update  esp_etudiant set ENVOI_MAIL='O'  where id_et='" + id_et + "'  ", mySqlConnection);
                mySqlConnection.Open();
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
            }

        }




        public DataTable GetInfoByIDtotransfert(string id_et)
        {

            mySqlConnection2.Open();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand("SELECT  e_mail_et,nom_et||' '||pnom_et nom,num_cin_passeport FROM   ESP_ETUDIANT t1  whERE id_et = '" + id_et + "'", mySqlConnection2);
            DataTable myDataTable = new DataTable();





            adapter.Fill(myDataTable);



            mySqlConnection2.Close();


            return myDataTable;

        }

        public void update_envoiMail(string id_et)
        {
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                OracleCommand cmd = new OracleCommand("update esp_etudiant set envoi_mail='O' where id_et ='" + id_et + "' and CODE_DECISION='01'", mySqlConnection);

                mySqlConnection.Open();
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();

            }

        }



        //public void update_code_decision(string id_et)
        //{
        //    using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
        //    {
        //        OracleCommand cmd = new OracleCommand("update esp_etudiant set CODE_DECISION='01'  where id_et ='" + id_et + "' and CODE_DECISION is null", mySqlConnection);

        //        mySqlConnection.Open();
        //        cmd.ExecuteNonQuery();
        //        mySqlConnection.Close();

        //    }

        //}


        public void transfer_to_enreg(string id_et)
        {
            using (OracleConnection mySqlConnection4 = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection4.Open();




                OracleCommand comando = new OracleCommand("transfer_to_enreg", mySqlConnection4);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(":id_ett", OracleDbType.Varchar2).Value = id_et;
                comando.ExecuteNonQuery();
                mySqlConnection4.Close();
            }

        }


        public DataTable getinfscoresupsoir()
        {

            mySqlConnection2.Open();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand("SELECT  T1.num_cin_passeport,T1.NOM_ET||' '||T1.PNOM_ET nom,(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC='03' then 'SC EXP' WHEN NATURE_BAC='02' then 'ECONOMIE' when NATURE_BAC='04' then 'TECHNIQUE'  when NATURE_BAC='35' then 'INFO' end)NATURE_BAC,SCORE_dossier,T1.SCORE_ENTRETIEN,score_final,score_francais,score_qi,score_anglais,T1.ANNEE_BAC,T1.MOY_BAC_ET,T1.NIVEAU_ACCES,T1.DIPLOME_SUP_ET,T1.E_MAIL_ET,T1.PASSWORD,(case when t1.SPECIALITE_ESP_ET='05' then 'TIC' when t1.SPECIALITE_ESP_ET='04' then 'EM' when t1.SPECIALITE_ESP_ET='03' then 'GC'  when t1.SPECIALITE_ESP_ET='01' then 'INFO' when t1.SPECIALITE_ESP_ET='02' then 'TELECOM'   when t1.SPECIALITE_ESP_ET='06' then 'Licence en Sciences de Gestion'  when t1.SPECIALITE_ESP_ET='07'  then 'Licence en Informatique de Gestion'   when t1.SPECIALITE_ESP_ET='08' then 'Master en Management	Digital	et Systèmes d’Information'   when t1.SPECIALITE_ESP_ET='09' then 'Master en Marketing Digital' when t1.SPECIALITE_ESP_ET='10' then 'Master en Innovation	 Entrepreneuriat'   end) SPECIALITE_ESP_ET ,T1.ID_ET,T1.dateentr,etab_origine, T1.TEL_ET,T1.NATIONALITE FROM   ESP_ETUDIANT t1  WHERE  id_et not like ('184%') and   id_et like '23%S%' and id_et like '23%T%' and (code_decision is null or code_decision='02') and score_final is not null AND SCORE_entretien is not null and total_test is not null order by score_final  ", mySqlConnection2);
            DataTable myDataTable = new DataTable();



            adapter.Fill(myDataTable);



            mySqlConnection2.Close();


            return myDataTable;

        }


        public DataTable getinf4code03()
        {

            mySqlConnection2.Open();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand("SELECT  T1.num_cin_passeport,T1.NOM_ET||' '||T1.PNOM_ET nom,(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC='03' then 'SC EXP' WHEN NATURE_BAC='02' then 'ECONOMIE' when NATURE_BAC='04' then 'TECHNIQUE'  when NATURE_BAC='35' then 'INFO' end)NATURE_BAC,SCORE_dossier,T1.SCORE_ENTRETIEN,score_final,score_francais,score_qi,score_anglais,T1.ANNEE_BAC,T1.MOY_BAC_ET,T1.NIVEAU_ACCES,T1.DIPLOME_SUP_ET,T1.E_MAIL_ET,T1.PASSWORD,(case when t1.SPECIALITE_ESP_ET='05' then 'TIC' when t1.SPECIALITE_ESP_ET='04' then 'EM' when t1.SPECIALITE_ESP_ET='03' then 'GC'  when t1.SPECIALITE_ESP_ET='01' then 'INFO' when t1.SPECIALITE_ESP_ET='02' then 'TELECOM'   when t1.SPECIALITE_ESP_ET='06' then 'Licence en Sciences de Gestion'  when t1.SPECIALITE_ESP_ET='07'  then 'Licence en Informatique de Gestion'   when t1.SPECIALITE_ESP_ET='08' then 'Master en Management	Digital	et Systèmes d’Information'   when t1.SPECIALITE_ESP_ET='09' then 'Master en Marketing Digital' when t1.SPECIALITE_ESP_ET='10' then 'Master en Innovation	 Entrepreneuriat'   end) SPECIALITE_ESP_ET ,T1.ID_ET,T1.dateentr,etab_origine, T1.TEL_ET,T1.NATIONALITE FROM   ESP_ETUDIANT t1  WHERE   NIVEAU_ACCES='4' and id_et like '23%T%' and code_decision='03'  and score_final is not null AND SCORE_entretien is not null and total_test is not null order by score_final  ", mySqlConnection2);
            DataTable myDataTable = new DataTable();



            adapter.Fill(myDataTable);



            mySqlConnection2.Close();


            return myDataTable;

        }
        public void update_ensEntretien(string id_ens, string userid, string id_et, string datepe)
        {

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                //DATE_AFFECTATION_ENS USER_AFFECTATION_ENS
                OracleCommand cmd = new OracleCommand("update  esp_etudiant set ID_ENS_ENTRETIEN='" + id_ens + "',DATE_PASSAGE_ENTRETIEN='" + datepe + "',DATE_AFFECTATION_ENS=to_date(sysdate,'dd/MM/yyyy'),USER_AFFECTATION_ENS='" + userid + "'  where id_et= '" + id_et + "'  ", mySqlConnection);
                mySqlConnection.Open();
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
            }

        }
        public DataTable listEntretienetud(string id_ens)
        {

            //mySqlConnection.Open();


            OracleDataAdapter adapter = new OracleDataAdapter();


            adapter.SelectCommand = new OracleCommand(" select id_et,nom_et,PNOM_ET,e_mail_et,dateentr from admis_esb.esp_etudiant where ID_ENS_ENTRETIEN='" + id_ens + "' and SCORE_ENTRETIEN is null and id_et like '23%'", mySqlConnection);


            DataTable myDataTable = new DataTable();



            adapter.Fill(myDataTable);



            mySqlConnection.Close();


            return myDataTable;

        }


        public DataTable getprepa()
        {

            mySqlConnection2.Open();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand("SELECT  T1.num_cin_passeport,T1.NOM_ET||' '||T1.PNOM_ET nom,(case when NATURE_BAC='01' then 'MATH' when NATURE_BAC='03' then 'SC EXP' WHEN NATURE_BAC='02' then 'ECONOMIE' when NATURE_BAC='04' then 'TECHNIQUE' when NATURE_BAC='35' then 'INFO' end)NATURE_BAC,SCORE_dossier,T1.SCORE_ENTRETIEN,score_final,score_francais,score_qi,score_anglais, T1.ANNEE_BAC,T1.MOY_BAC_ET,T1.NIVEAU_ACCES,T1.DIPLOME_SUP_ET,T1.E_MAIL_ET,T1.PASSWORD,(case when t1.SPECIALITE_ESP_ET='05' then 'TIC' when t1.SPECIALITE_ESP_ET='04' then 'EM' when t1.SPECIALITE_ESP_ET='03' then 'GC'  when t1.SPECIALITE_ESP_ET='01' then 'INFO' when t1.SPECIALITE_ESP_ET='02' then 'TELECOM'   when t1.SPECIALITE_ESP_ET='06' then 'Licence en Sciences de Gestion'  when t1.SPECIALITE_ESP_ET='07'  then 'Licence en Informatique de Gestion'   when t1.SPECIALITE_ESP_ET='08' then 'Master en Management	Digital	et Systèmes d’Information'   when t1.SPECIALITE_ESP_ET='09' then 'Master en Marketing Digital'  when t1.SPECIALITE_ESP_ET='10' then 'Master en Innovation	 Entrepreneuriat'   end) SPECIALITE_ESP_ET ,T1.ID_ET,T1.dateentr,etab_origine, T1.TEL_ET,T1.NATIONALITE FROM   ESP_ETUDIANT t1  where id_et like '23%T%' and RANGP is not null and code_decision ='01' and score_final is not null and score_entretien is not null and total_test is not null and  trim(t1.id_et) not in (select trim(g.id_et) from scoesb02.esp_etudiant_enreg g where g.id_et like '23%T%')", mySqlConnection2);
            DataTable myDataTable = new DataTable();



            adapter.Fill(myDataTable);



            mySqlConnection2.Close();


            return myDataTable;

        }


    }
}
