using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using admiss;
using System.Data.SqlClient;

namespace DAL
{
 public   class EncadDAO
    {

      #region sing
        static EncadDAO instance;
        static Object locker = new Object();
        public static EncadDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new EncadDAO();
                    }

                    return EncadDAO.instance;
                }
            }

        }

        private EncadDAO() { }
        #endregion sing

        #region Connexion
        OracleConnection mySqlConnection = new OracleConnection("DATA SOURCE= ;PERSIST SECURITY INFO=True;USER ID=scoesb03;PASSWORD=fikr2015");
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



        

        // paiement en ligne 

        //ID_ET,USERNAME,AMOUNT,ANNEE_DEB,ORDERNUMBER,RETURNURL,CURRENCY,PASSWORD,ETAT,DATE_PAIEMENT
        public void AjoutPaiement(string ID_ET, string USERNAME , string AMOUNT, string ANNEE_DEB, string RETURNURL, string CURRENCY, string PASSWORD, string ORDERID)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText  = "Insert into scoesb02.HISTORIQUE_PAIEMENT (ID_ET, USERNAME, AMOUNT, ANNEE_DEB , RETURNURL , CURRENCY , PASSWORD, ORDERID) values('" + ID_ET + "', '" + USERNAME + "', '" + AMOUNT + "', '" + ANNEE_DEB + "', '" + RETURNURL + "', '" + CURRENCY + "', '" + PASSWORD + "','"+ ORDERID +"')";
            cmd.ExecuteNonQuery();
        }



        public DataTable Get_data_Etudiantbycin(string id_et, string annee)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();


            OracleCommand cmd = new OracleCommand("select e1.id_et,mode_rglt,DATE_LIM_PROLONG_RGLT,numcompte,num_cin_passeport from esp_inscription e,esp_etudiant e1 where e.id_et=e1.id_et and annee_deb = '" + annee + "' and trim(e1.num_cin_passeport)='" + id_et + "'", con);
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            con.Close();
            return dt;
        }
        public string get_liaison_fin()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT LIAISON_FINANCIER from societe";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string get_type_insc(string id)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT type_insc from esp_inscription where id_et='"+id+"' and annee_deb=(select annee_deb from societe)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //update transaction payment


        public void sf(string a)
        {
            using (OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString5))
            {
              //  OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString5);
                OracleCommand cmd = new OracleCommand("insert into ADMIS_ESB.score_final_2022(id_et, SCORE_FINAL) values('" + a + "', replace(FS_GET_SCORE_final_ESB('" + a + "'),'.',','))", cn);
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public int sf2(decimal a, string b)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString5);
          
            OracleCommand cmd = new OracleCommand("update ADMIS_ESB.score_final_2022 set sf2='"+a+"' where id_et='"+b+"'", cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
            cn.Close();

        }

        public int updateTransactionPayment(string orderId, string RETURNURL, string ID_ET, decimal ORDERNUMBER)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE  scoesb02.HISTORIQUE_PAIEMENT SET orderId ='" + orderId + "', RETURNURL ='" + RETURNURL + "'   where ID_ET='" + ID_ET + "' and   ORDERNUMBER='" + ORDERNUMBER + "'", cn);
            cn.Open();
            return cmd.ExecuteNonQuery();

        }



        public DataTable Get_data_Etudiant(string id_et, string annee)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();

            //annee = "2021";
            OracleCommand cmd = new OracleCommand("select e1.id_et,mode_rglt,DATE_LIM_PROLONG_RGLT,numcompte,e.code_cl,e.RESERVE from esp_inscription e,esp_etudiant e1 where e.id_et=e1.id_et and annee_deb = '" + annee + "' and (e1.id_et='" + id_et + "' or trim(num_cin_passeport)= '" + id_et + "')", con);
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            con.Close();
            return dt;
        }




        //get  annee_deb
        public string getAnneedeb()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = "select ANNEE_DEB from  scoesb02.SOCIETE ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string OrderNumberPayment()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = "select max(ORDERNUMBER)+1 from scoesb02.HISTORIQUE_PAIEMENT";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //GET ORDER ID
        public string getOrderIdPayment(string ID_ET  , string order)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                //string cmdQuery = " select distinct t1.orderId  from  scoesp09.HISTORIQUE_PAIEMENT   t1 where t1.id_et='" + ID_ET + "' and t1.ORDERNUMBER='" + ordernbr + "' and  order by t1.DATE_PAIEMENT  ";

                 string cmdQuery = " select t1.orderId  from  scoesb02.HISTORIQUE_PAIEMENT   t1 where t1.id_et='" + ID_ET + "' and t1.ORDERNUMBER='" + order + "'   order by t1.DATE_PAIEMENT  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //GET password
        public string getPassPayment(string ID_ET)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = " select distinct max(t1.password)  from  scoesb02.HISTORIQUE_PAIEMENT   t1 where t1.id_et='" + ID_ET + "' order by t1.DATE_PAIEMENT   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //GET userName
        public string getuserNamePayment(string ID_ET)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = " select distinct max(t1.userName)  from  scoesb02.HISTORIQUE_PAIEMENT   t1 where t1.id_et='" + ID_ET + "' order by t1.DATE_PAIEMENT  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        
        public string getorderIdPayment(string ID_ET )
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = " select distinct max(t1.orderId)  from  scoesb02.HISTORIQUE_PAIEMENT   t1 where t1.id_et='" + ID_ET + "'   order by t1.DATE_PAIEMENT  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string getamountPayment(string ID_ET)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = " select distinct max( t1.amount)  from  scoesb02.HISTORIQUE_PAIEMENT   t1 where t1.id_et='" + ID_ET + "'  order by t1.DATE_PAIEMENT  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }



        // ETat finale d'enregistrement  de payment en ligne orderStatus et message d'erreur et error code dans un autre table :
        // Insert into ETAT_PAIEMENT (ID_ET,EXPIRATION,CARDHOLDERNAME,DEPOSITAMOUNT,CURRENCY,AUTHCODE,ERRORCODE,ERRORMESSAGE,ORDERSTATUS,ORDERNUMBER,PAN,AMOUNT,IP,ANNEE_DEB) values ('gggggg',null,null,null,null,null,null,'SUUCES',null,'1111111111',null,'100',null,'2019');

        public void EtatPaiement(string ID_ET, string EXPIRATION, string CARDHOLDERNAME, string DEPOSITAMOUNT, string CURRENCY, string AUTHCODE, string ERRORCODE, string ERRORMESSAGE, string ORDERSTATUS, string ORDERNUMBER, string PAN, string AMOUNT, string IP, string ANNEE_DEB)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Insert into scoesb02.ETAT_PAIEMENT (ID_ET,EXPIRATION,CARDHOLDERNAME,DEPOSITAMOUNT,CURRENCY,AUTHCODE,ERRORCODE,ERRORMESSAGE,ORDERSTATUS,ORDERNUMBER,PAN,AMOUNT,IP,ANNEE_DEB) values('" + ID_ET + "', '" + EXPIRATION + "', '" + CARDHOLDERNAME + "', '" + DEPOSITAMOUNT + "', '" + CURRENCY + "', '" + AUTHCODE + "', '" + ERRORCODE + "','" + ERRORMESSAGE + "', '" + ORDERSTATUS + "','" + ORDERNUMBER + "','" + PAN + "','" + AMOUNT + "','" + IP + "','" + ANNEE_DEB + "')";
            cmd.ExecuteNonQuery();
        }


        // get formulaire etudiant id, nom , prenom , cin , telephone , classe

        public string getnumTelephone(string ID_ET)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = "    select  trim(t1.TEL_ET) from  scoesb02.ESP_ETUDIANT   t1 where t1.id_et='" + ID_ET + "' and t1.ETAT='A'  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string getnumClasse(string ID_ET)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = "select  trim(t2.CODE_CL) from  scoesb02.ESP_ETUDIANT   t1 , scoesb02.ESP_INSCRIPTION t2 , SOCIETE t3 where t1.ID_ET=t2.ID_ET and t3.ANNEE_DEB = t2.ANNEE_DEB and t1.id_et='" + ID_ET + "' and t1.ETAT='A'  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string getCryptCin(string ID_ET)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = "select  concat( concat(SUBSTR(t1.NUM_CIN_PASSEPORT,1,2),'***'),SUBSTR(t1.NUM_CIN_PASSEPORT,5,3)) from  scoesb02.ESP_ETUDIANT   t1 , scoesb02.ESP_INSCRIPTION t2 , scoesb02.SOCIETE t3 where t1.ID_ET=t2.ID_ET and t3.ANNEE_DEB = t2.ANNEE_DEB and t1.id_et='" + ID_ET + "' and t1.ETAT='A'   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //le 04 01 2022 work esb

        public DataTable GetabsebceByFormatioOrStudent(string code_cl, string idet,string numsem,string d1,string d2,string code_module)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();


            OracleCommand cmd = new OracleCommand("select distinct e.id_et,nom_et,pnom_et,e.code_cl,e.DATE_SEANCE,c.LIB_NOME Heure,c1.DESIGNATION_NEW Module from ESP_ABSENCE_NEW e,esp_etudiant e1,CODE_NOMENCLATURE c ,ESP_MODULE_PANIER_CLASSE_SAISO c1 where  c.CODE_NOME=e.NUM_SEANCE and c1.annee_deb=(select max(annee_deb) from societe) and  c1.CODE_MODULE=e.CODE_MODULE and e.id_et=e1.id_et and e.annee_deb=(select max(annee_deb) from societe) and c.code_str='60' and( e.CODE_CL='"+code_cl+"' or e.id_et='"+idet+ "' or e.SEMESTRE='"+numsem+ "'  or e.code_module='"+code_module+"'  or(to_date (e.DATE_SEANCE,'DD/MM/YY')>='"+d1+"' and  to_date(e.DATE_SEANCE,'DD/MM/YY')<='"+d2+"'))order by e.ID_ET", con);
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetabsenceByNb(string code_cl, string idet, string numsem, string d1, string d2, string code_module)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("  select distinct e.id_et,nom_et,pnom_et,e.code_cl ,e.DATE_SEANCE,c.LIB_NOME ,c1.DESIGNATION_NEW,count(distinct e.ID_ET) nb from ESP_ABSENCE_NEW e,esp_etudiant e1,CODE_NOMENCLATURE c ,ESP_MODULE_PANIER_CLASSE_SAISO c1 where  c.CODE_NOME=e.NUM_SEANCE and c1.annee_deb=(select max(annee_deb) from societe) and  c1.CODE_MODULE=e.CODE_MODULE and e.id_et=e1.id_et and e.annee_deb=(select max(annee_deb) from societe) and c.code_str='60' and( e.CODE_CL='" + code_cl + "' or e.id_et='" + idet + "' or e.SEMESTRE='" + numsem + "'  or e.code_module='" + code_module + "'  or(to_date (e.DATE_SEANCE,'DD/MM/YY')>='" + d1 + "' and  to_date(e.DATE_SEANCE,'DD/MM/YY')<='" + d2 + "')) group by e.id_et,nom_et,pnom_et,e.code_cl,e.DATE_SEANCE,c.LIB_NOME ,c1.DESIGNATION_NEW order by c1.DESIGNATION_NEW", con);
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetabsenceByNb2(string idet)
        {
            DataTable dt2 = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("select a.ID_ET,c.NOM_ET,a.CODE_CL, b.DESIGNATION_NEW,count(a.CODE_MODULE) as NB,SEMESTRE from ESP_ABSENCE_NEW a ,ESP_MODULE_PANIER_CLASSE_SAISO b,esp_etudiant c where a.ANNEE_DEB=b.ANNEE_DEB and a.CODE_MODULE=b.CODE_MODULE and a.CODE_CL=b.CODE_CL and a.ID_ET=c.ID_ET and a.ID_ET='" + idet + "' and a.ANNEE_DEB=(select annee_deb from societe) GROUP by a.ID_ET,c.NOM_ET,a.CODE_CL, b.DESIGNATION_NEW,a.SEMESTRE", con);
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt2);
            con.Close();
            return dt2;
        }

        //15012022

        public string Get_Value_lockedfromESPRIT(string id_et)
        {
            string lib = "";

            using (SqlConnection mySqlConnection = new SqlConnection(AppConfiguration.ConnectionStringsolde))
            {
                mySqlConnection.Open();


                //  string cmdQuery = "SELECT sum(Amount) FROM[ESPRIT_NAV_PROD].[dbo].[Esprit$G_L Entry] where[Source No_] ='" + source_num + "'" [Posting Date] like '%" + annee + "%' and;

               // string cmdQuery = "SELECT Locked  FROM[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer] where[Id_Et] ='" + id_et + "' ";

                string cmdQuery = "SELECT[ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer].Id_Et,[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].Locked FROM[ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer]  ,[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer] where[ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer].[Id_Et]= [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].[Id_Et] and[ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer].[Locked] ='0' and[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].[Locked]  ='0' union (SELECT[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].Id_Et, [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].Locked from [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer] where [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].[Locked]  = '0')";
        SqlCommand myCommand = new SqlCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public DataTable Get_Value_lockedfromESPRITESB(string id_et)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(AppConfiguration.ConnectionStringsolde);


            con.Open();


 SqlCommand cmd = new SqlCommand("SELECT [ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer].[Locked] c_locked_esp,  [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].[Locked] c_locked_esb FROM[ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer]  ,[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer]  where [ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer].[Id_Et]= [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].[Id_Et] and [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].[Id_Et] ='" + id_et + "'", con);
// SqlCommand cmd = new SqlCommand("SELECT[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].Id_Et, [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].Locked  c_locked_esb from[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer] where[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].Id_Et = '" + id_et + "'", con);
            //    SqlCommand cmd = new SqlCommand(" SELECT [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].[id_et],[ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer].[Locked] c_locked_esp,[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].[Locked]  c_locked_esb FROM[ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer]  ,[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer] where[ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer].[Id_Et]= [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].[Id_Et] and[ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer].[Locked] ='0' and[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].[Locked]  ='0' union(SELECT[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].Id_Et, [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].Locked from [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer]  where[Id_Et] ='" + id_et + "'");


            //  OracleCommand cmd = new OracleCommand("SELECT e.Locked as c_locked_esp,  e1.Locked  as c_locked_esb FROM [ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer] as e  ,[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer] as e1  where e.[Id_Et]= e1.[Id_Et] and e1.[Id_Et] ='" + id_et + "'", con);

            //SELECT e.[Locked] c_locked_esp,  e1.[Locked] c_locked_esb FROM [dbo].[Esprit$My Customer] e  ,[dbo].[ESB$My Customer] e1  where e.[Id_Et]= e1.[Id_Et] and e.[Id_Et] ='161JMTB016';


            SqlDataAdapter od = new SqlDataAdapter(cmd);
            od.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable Get_Value_lockedfromESPRITESBynumcompte(string numcompte)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(AppConfiguration.ConnectionStringsolde);


            con.Open();


            SqlCommand cmd = new SqlCommand("SELECT [ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer].[Locked] c_locked_esp,  [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].[Locked] c_locked_esb FROM[ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer]  ,[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer]  where [ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer].[Id_Et]= [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].[Id_Et] and [ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer].[Id_Et] ='" + numcompte + "'", con);


            //  OracleCommand cmd = new OracleCommand("SELECT e.Locked as c_locked_esp,  e1.Locked  as c_locked_esb FROM [ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer] as e  ,[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer] as e1  where e.[Id_Et]= e1.[Id_Et] and e1.[Id_Et] ='" + id_et + "'", con);

            //SELECT e.[Locked] c_locked_esp,  e1.[Locked] c_locked_esb FROM [dbo].[Esprit$My Customer] e  ,[dbo].[ESB$My Customer] e1  where e.[Id_Et]= e1.[Id_Et] and e.[Id_Et] ='161JMTB016';


            SqlDataAdapter od = new SqlDataAdapter(cmd);
            od.Fill(dt);
            con.Close();
            return dt;
        }
        public string Get_Value_lockedfromESPRITESBs(string id_et)
        {
            string lib = "";

            using (SqlConnection mySqlConnection = new SqlConnection(AppConfiguration.ConnectionStringsolde))
            {
                mySqlConnection.Open();


                //  string cmdQuery = "SELECT sum(Amount) FROM[ESPRIT_NAV_PROD].[dbo].[Esprit$G_L Entry] where[Source No_] ='" + source_num + "'" [Posting Date] like '%" + annee + "%' and;

                string cmdQuery = "SELECT [Esprit$My Customer].[Locked] c_locked_esp,  [ESB$My Customer].[Locked] c_locked_esb FROM[ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer]  ,[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer]  where [Esprit$My Customer].[Id_Et]= [ESB$My Customer].[Id_Et] and [Esprit$My Customer].[Id_Et] ='" + id_et + "' ";
                SqlCommand myCommand = new SqlCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Get_Value_lockedfROMESB(string id_et)
        {
            string lib = "0";

            //using (SqlConnection mySqlConnection = new SqlConnection(AppConfiguration.ConnectionStringsolde))
            //{
            //    mySqlConnection.Open();


            //    //  string cmdQuery = "SELECT sum(Amount) FROM[ESPRIT_NAV_PROD].[dbo].[Esprit$G_L Entry] where[Source No_] ='" + source_num + "'" [Posting Date] like '%" + annee + "%' and;

            //    string cmdQuery = "SELECT Locked  FROM[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer] where[Id_Et] ='" + id_et + "' ";

            //  //  string cmdQuery = "SELECT [ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer].[Locked] c_locked_esp,  [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].[Locked] c_locked_esb FROM[ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer]  ,[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer]  where [ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer].[Id_Et]= [ESPRIT_NAV_PROD].[dbo].[ESB$My Customer].[Id_Et] and [ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer].[Id_Et] ='" + id_et + "'", con);
            //    SqlCommand myCommand = new SqlCommand(cmdQuery);
            //    myCommand.Connection = mySqlConnection;
            //    myCommand.CommandType = CommandType.Text;
            //    lib = myCommand.ExecuteScalar().ToString();
            //    mySqlConnection.Close();
            //}
            return lib;
        }
        public string Get_Value_lockedfROMESBynumcpt(string numcpt)
        {
            string lib = "";

            using (SqlConnection mySqlConnection = new SqlConnection(AppConfiguration.ConnectionStringsolde))
            {
                mySqlConnection.Open();


                //  string cmdQuery = "SELECT sum(Amount) FROM[ESPRIT_NAV_PROD].[dbo].[Esprit$G_L Entry] where[Source No_] ='" + source_num + "'" [Posting Date] like '%" + annee + "%' and;

                string cmdQuery = "SELECT Locked  FROM[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer] where[Customer No_] ='" + numcpt + "' ";
                SqlCommand myCommand = new SqlCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Get_Value_lockedbynumcptFROMESPRIT(string numcpt)
        {
            string lib = "";

            using (SqlConnection mySqlConnection = new SqlConnection(AppConfiguration.ConnectionStringsolde))
            {
                mySqlConnection.Open();


                //  string cmdQuery = "SELECT sum(Amount) FROM[ESPRIT_NAV_PROD].[dbo].[Esprit$G_L Entry] where[Source No_] ='" + source_num + "'" [Posting Date] like '%" + annee + "%' and;

                string cmdQuery = "SELECT Locked  FROM[ESPRIT_NAV_PROD].[dbo].[Esprit$My Customer] where[Customer No_] ='" + numcpt + "' ";
                SqlCommand myCommand = new SqlCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string Get_Value_lockedbynumcptFROMESB(string numcpt)
        {
            string lib = "";

            using (SqlConnection mySqlConnection = new SqlConnection(AppConfiguration.ConnectionStringsolde))
            {
                mySqlConnection.Open();


                //  string cmdQuery = "SELECT sum(Amount) FROM[ESPRIT_NAV_PROD].[dbo].[Esprit$G_L Entry] where[Source No_] ='" + source_num + "'" [Posting Date] like '%" + annee + "%' and;

                string cmdQuery = "SELECT Locked  FROM[ESPRIT_NAV_PROD].[dbo].[ESB$My Customer] where[Customer No_] ='" + numcpt + "' ";
                SqlCommand myCommand = new SqlCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public DataTable Get_data_societe()
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();


            OracleCommand cmd = new OracleCommand("select NUM_SEMESTRE_ACTUEL,ANNEE_DEB,CTRL_FIN_STAT,max_val_credit_accepte from SOciete", con);
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            con.Close();
            return dt;
        }



    }
}
