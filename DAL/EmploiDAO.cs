using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;
using System;
using admiss;

namespace DAL
{
    public class EmploiDAO
    {

        #region singleton
        static EmploiDAO instance;
        static Object locker = new Object();

        public static EmploiDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new EmploiDAO();
                    }

                    return EmploiDAO.instance;
                }
            }

        }
        private EmploiDAO() { }

        #endregion

        #region getset
        private DateTime DATE_SEANCE;

        public DateTime DATE_SEANCE1
        {
            get { return DATE_SEANCE; }
            set { DATE_SEANCE = value; }
        }

        private string _CODE_MODULE;

        public string CODE_MODULE
        {
            get { return _CODE_MODULE; }
            set { _CODE_MODULE = value; }
        }

        private string _CODE_CL;

        public string CODE_CL
        {
            get { return _CODE_CL; }
            set { _CODE_CL = value; }
        }
        private string _CODE_SALLE;

        public string CODE_SALLE
        {
            get { return _CODE_SALLE; }
            set { _CODE_SALLE = value; }
        }





        #endregion

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


        //login Enseignant
        public string loginEns(string _ID_ENS, string _PWD_ENS)
        {
            bool exist = false;
            string Name = "x";
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_ENSEIGNANT WHERE  ID_ENS ='" + _ID_ENS + "'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();

                    if (MyReader["PWD_ENS"].ToString() == _PWD_ENS)/*Name.Equals(username)*/
                    {
                        Name = MyReader["TYPE_UP"].ToString();


                        break;
                    }
                }
                MyReader.Close();
                mySqlConnection.Close();
                return Name;
            }

        }
        //login Etudiant
        //login administrateur
        public string verifDisponibilite(string jourSeance, int heuredebut, int heureFin, string idEns)
        {
            string annee = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "INSERT INTO DISPONIBILITE (JOURS_SEANCE,HEURE_DEBUT,HEURE_FIN,ID_ENS) VALUES('" + jourSeance + "','" + heuredebut + "','" + heureFin + "','" + idEns + "')";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read())
                {
                    // String Name = MyReader["Username"].ToString();

                    annee = MyReader["ANNEE_DEB"].ToString();


                }
                MyReader.Close();
                mySqlConnection.Close();
            }

            return annee;

        }
        public DataTable BindClasspegroupbycl(string code_cl)
        {
            DataTable ds = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT  CODE_CL FROM  ESP_MODULE_PANIER_CLASSE_SAISO,SOCIETE  where esp_module_panier_classe_saiso.ANNEE_DEB=SOCIETE.ANNEE_DEB and esp_module_panier_classe_saiso.NUM_SEMESTRE=SOCIETE.NUM_SEMESTRE_ACTUEL and code_cl like '%"+code_cl+"%' group by code_cl", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(ds);

            con.Close();
            return ds;


        }

        public DataTable BindClasspe()
        {
            DataTable ds = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT distinct CODE_CL FROM  ESP_MODULE_PANIER_CLASSE_SAISO,SOCIETE where ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB=SOCIETE.ANNEE_DEB  and esp_module_panier_classe_saiso.NUM_SEMESTRE=SOCIETE.NUM_SEMESTRE_ACTUEL ORDER BY CODE_CL ", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(ds);

            con.Close();
            return ds;


        }

        //public List<ESP_SALLE_CLASSE> getSalleClase()
        //{
     //  OracleConnection con = new OracleConnection(source);
        //    con.Open();
        //    OracleCommand cmd = new OracleCommand("SELECT ID,CODE_CL,SALLE,ANNEE_DEB FROM ESP_SALLE_CLASSE ", con);

        //    OracleDataAdapter od = new OracleDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    od.Fill(dt);
        //    List<ESP_SALLE_CLASSE> list = testT(dt);
        //    con.Close();
        //    return list;
        //}
        //private List<ESP_SALLE_CLASSE> testT(DataTable dt)
        //{
        //    var convertedList = (from rw in dt.AsEnumerable()
        //                         select new ESP_SALLE_CLASSE()
        //                         {
        //                             CODE_CL = Convert.ToString(rw["CODE_CL"]),
        //                             SALLE = Convert.ToString(rw["SALLE"]),
        //                             ANNEE_DEB = Convert.ToInt32(rw["ANNEE_DEB"]),
        //                             ID = Convert.ToInt32(rw["ID"])
        //                         }).ToList();

        //    return convertedList;
        //}

        public DataTable getAllClass()
        {
            DataTable ds = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT SALLE_PRINCIPALE FROM  ESP_SAISON_CLASSE,SOCIETE where ESP_SAISON_CLASSE.ANNEE_DEB=SOCIETE.ANNEE_DEB  order by SALLE_PRINCIPALE", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(ds);

            con.Close();
            return ds;


        }

        public DataTable getAllClassESP()
        {
            DataTable ds = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT DISTINCT CODE_CL FROM ESP_MODULE_PANIER_CLASSE_SAISO,societe where ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB=societe.annee_deb ORDER BY CODE_CL;", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(ds);

            con.Close();
            return ds;


        }
        public DataTable getAllClasses()
        {
            DataTable ds = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT CODE_CL FROM  ESP_SALLE_CLASSE,SOCIETE WHERE SOCIETE.ANNEE_DEB=ESP_SALLE_CLASSE.ANNEE_DEB", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(ds);

            con.Close();
            return ds;


        }
        public string getCl()
        {
            string _cl = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT CODE_CL FROM  ESP_SALLE_CLASSE,SOCIETE WHERE SOCIETE.ANNEE_DEB=ESP_SALLE_CLASSE.ANNEE_DEB ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read())
                {
                    // String Name = MyReader["Username"].ToString();

                    _cl = MyReader["CODE_CL"].ToString();


                }
                MyReader.Close();
                mySqlConnection.Close();
            }

            return _cl;

        }

        public int UpdateSalle(string salle)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE  ESP_SALLE_CLASSE SET SALLE='" + salle, cn);
            cn.Open();
            return cmd.ExecuteNonQuery();

        }

        public bool Delete_esp_salle(decimal _ID)
        {
            bool result = false;

            string cmdQuery1 = "delete from ESP_SALLE_CLASSE  where ID='" + _ID + "' ";
            OracleCommand myCommand = new OracleCommand(cmdQuery1);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;




            try
            {
                myCommand.ExecuteNonQuery();

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

        //public List<ESP_SALLE_CLASSE> getSalle()
        //{
       //  OracleConnection con = new OracleConnection(source);
        //    con.Open();
        //    OracleCommand cmd = new OracleCommand("SELECT SALLE FROM ESP_SALLE_CLASSE ORDER BY SALLE", con);

        //    OracleDataAdapter od = new OracleDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    od.Fill(dt);
        //    List<ESP_SALLE_CLASSE> list = testsalle(dt);
        //    con.Close();
        //    return list;
        //}
        //private List<ESP_SALLE_CLASSE> testsalle(DataTable dt)
        //{
        //    var convertedList = (from rw in dt.AsEnumerable()
        //                         select new ESP_SALLE_CLASSE()
        //                         {

        //                             SALLE = Convert.ToString(rw["SALLE"])

        //                         }).ToList();

        //    return convertedList;
        //}
        //public DataSet getListeEnseigant()
        //{
       //    OracleConnection conn = new OracleConnection(source);
        //    conn.Open();
        //    OracleCommand cmd = conn.CreateCommand();
        //    OracleParameter ora = new OracleParameter();
        //    cmd.CommandText = "SELECT  DISTINCT ESP_ENSEIGNANT.ETAT_CIVIL_ENS,ESP_ENSEIGNANT.NOM_ENS,ESP_MODULE.DESIGNATION,ESP_SALLE_CLASSE.CODE_CL,ESP_SALLE_CLASSE.SALLE FROM ESP_SALLE_CLASSE,ESP_MODULE_PANIER_CLASSE_SAISO,ESP_ENSEIGNANT,SOCIETE,ESP_MODULE WHERE ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL=ESP_SALLE_CLASSE.CODE_CL AND ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_ENSEIGNANT.ID_ENS AND ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE=ESP_MODULE.CODE_MODULE AND ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB=ESP_SALLE_CLASSE.ANNEE_DEB and ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = 1 order by NOM_ENS";

        //    //"  SELECT  ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE,ESP_ENSEIGNANT.NOM_ENS,ESP_MODULE.DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL,ESP_SALLE_CLASSE.SALLE   FROM ESP_SALLE_CLASSE,ESP_MODULE_PANIER_CLASSE_SAISO,ESP_MODULE,ESP_ENSEIGNANT WHERE  ESP_ENSEIGNANT.ID_ENS= ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS and ESP_MODULE.CODE_MODULE= ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE AND (ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = 1)";
        //    OracleDataAdapter od = new OracleDataAdapter(cmd);
        //    DataSet dt = new DataSet();
        //    od.Fill(dt);
        //    return dt;
        //    conn.Close();

        //}

        //Autre Methode:
        public List<ESP_MODULE_PANIER_CLASSE_SAISO> getdatamodule(string id, string annedeb)
        {

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT DISTINCT ESP_ENSEIGNANT.NOM_ENS,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE, ESP_MODULE.DESIGNATION FROM SOCIETE,ESP_ENSEIGNANT INNER JOIN ESP_MODULE_PANIER_CLASSE_SAISO ON ESP_ENSEIGNANT.ID_ENS = ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS INNER JOIN ESP_MODULE ON ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE = ESP_MODULE.CODE_MODULE   )", con);
            /*"SELECT ESP_INSCRIPTION.ID_ET, ESP_INSCRIPTION.code_cl,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE, ESP_MODULE.DESIGNATION FROM SOCIETE,ESP_INSCRIPTION INNER JOIN ESP_MODULE_PANIER_CLASSE_SAISO ON ESP_INSCRIPTION.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL INNER JOIN ESP_MODULE ON ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE = ESP_MODULE.CODE_MODULE  WHERE     (ESP_INSCRIPTION.ID_ET = '" + id + "'') AND (SOCIETE.ANNEE_DEB = '" + annedeb + "') AND (ESP_INSCRIPTION.ANNEE_DEB = '" + annedeb + "') AND (ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = 1 or ( (SOCIETE.ANNEE_DEB = '" + annedeb + "') AND (ESP_INSCRIPTION.ANNEE_DEB = '" + annedeb + "')and(ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = 2  ))) minus select esp_evaluation.id_et,code_cl,esp_evaluation.code_module,ESP_MODULE.designation from esp_evaluation,ESP_MODULE  where (esp_evaluation.CODE_MODULE = ESP_MODULE.CODE_MODULE and annee_deb='" + annedeb + "' )"*/

            /*SELECT ESP_INSCRIPTION.ID_ET, ESP_INSCRIPTION.code_cl,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE, ESP_MODULE.DESIGNATION FROM ESP_INSCRIPTION INNER JOIN ESP_MODULE_PANIER_CLASSE_SAISO ON ESP_INSCRIPTION.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL INNER JOIN ESP_MODULE ON ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE = ESP_MODULE.CODE_MODULE WHERE     (ESP_INSCRIPTION.ID_ET = '" + id + "') AND (ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '2014') AND (ESP_INSCRIPTION.ANNEE_DEB = '2014') AND (ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = 1 or ( (ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '2014') AND (ESP_INSCRIPTION.ANNEE_DEB = '2014')and(ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = 2  ))) minus select esp_evaluation.id_et,code_cl,esp_evaluation.code_module,ESP_MODULE.designation from esp_evaluation,ESP_MODULE where (esp_evaluation.CODE_MODULE = ESP_MODULE.CODE_MODULE and annee_deb='2014' )*/

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            od.Fill(dt);
            List<ESP_MODULE_PANIER_CLASSE_SAISO> list = tests(dt);
            con.Close();
            return list;


        }
        private List<ESP_MODULE_PANIER_CLASSE_SAISO> tests(DataTable dt)
        {
            var convertedList = (from rw in dt.AsEnumerable()
                                 select new ESP_MODULE_PANIER_CLASSE_SAISO()
                                 {
                                     CODE_MODULE = Convert.ToString(rw["CODE_MODULE"]),
                                     //ESP_MODULE.DESIGNATION = Convert.ToString(rw["DESIGNATION"])
                                     CODE_CL = Convert.ToString(rw["CODE_CL"]),
                                     ID_ENS = Convert.ToString(rw["ID_ENS"])

                                 }).ToList();

            return convertedList;
        }

        // afficher info ds calendrier:nom_ens,module,classe salle

        public int DeleteEnseig(string id)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("Delete From ESP_MODULE_PANIER_CLASSE_SAISO Where ID_ENS=" + id, conn);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataTable getAllenseign()
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            cmd.CommandText = "SELECT DISTINCT ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,ESP_ENSEIGNANT.ETAT_CIVIL_ENS,ESP_SALLE_CLASSE.CODE_CL,ESP_MODULE.DESIGNATION,ESP_SALLE_CLASSE.SALLE FROM  ESP_MODULE,ESP_MODULE_PANIER_CLASSE_SAISO,ESP_ENSEIGNANT,SOCIETE,ESP_SALLE_CLASSE WHERE ESP_SALLE_CLASSE.CODE_CL=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL AND ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE=ESP_MODULE.CODE_MODULE AND ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_ENSEIGNANT.ID_ENS AND ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB=SOCIETE.ANNEE_DEB AND ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = 1 order by NOM_ENS";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            od.Fill(dt);
            return dt;
            conn.Close();

        }
        //get les ens
        public DataTable Getens()
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            cmd.CommandText = "SELECT DISTINCT ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS,ESP_ENSEIGNANT.NOM_ENS FROM ESP_ENSEIGNANT,ESP_MODULE_PANIER_CLASSE_SAISO,SOCIETE WHERE ETAT= 'A' and ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB=SOCIETE.ANNEE_DEB and ESP_ENSEIGNANT.ID_ENS=ESP_MODULE_PANIER_CLASSE_SAISO.id_ens order by NOM_ENS ";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            od.Fill(dt);
            return dt;
            conn.Close();
        }
        //emploi du temp par classe:
        public DataTable GetEventsByClasse(string code_cl)
        {
            DataTable dt = new DataTable("ESP_SEANCE_ENS");
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();

            cmd.CommandText = "SELECT ESP_ENSEIGNANT.NOM_ENS, ESP_SEANCE_ENS.CODE_CL,ESP_SEANCE_ENS.HEURE_SORTIE,ESP_SEANCE_ENS.HEURE_ENTREE,ESP_SEANCE_ENS.DATE_SEANCE,ESP_SEANCE_ENS.MINUTE_ENTREE,ESP_SEANCE_ENS.MINUTE_SORTIE,ESP_MODULE.DESIGNATION,ESP_SALLE_CLASSE.SALLE FROM ESP_ENSEIGNANT,ESP_MODULE,ESP_SEANCE_ENS,SOCIETE,ESP_SALLE_CLASSE WHERE ESP_ENSEIGNANT.ID_ENS=ESP_SEANCE_ENS.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_SEANCE_ENS.CODE_MODULE AND SOCIETE.ANNEE_DEB=ESP_SEANCE_ENS.ANNEE_DEB AND ESP_SALLE_CLASSE.CODE_CL=ESP_SEANCE_ENS.CODE_CL AND ESP_SALLE_CLASSE.CODE_CL='" + code_cl + "'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
            conn.Close();


        }

        private List<ESP_MODULE_PANIER_CLASSE_SAISO> tester(DataTable dts)
        {
            var convertedList = (from rw in dts.AsEnumerable()
                                 select new ESP_MODULE_PANIER_CLASSE_SAISO()
                                 {

                                     ANNEE_DEB = Convert.ToString(rw["ANNEE_DEB"]),
                                     NUM_SEMESTRE = Convert.ToInt32(rw["NUM_SEMESTRE"])
                                 }).ToList();

            return convertedList;
        }

        public DataTable GetDataEvents()
        {
            DataTable dt = new DataTable("ESP_SEANCE_ENS");
         
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();

            cmd.CommandText = "SELECT ESP_ENSEIGNANT.NOM_ENS, ESP_SEANCE_ENS.CODE_CL,ESP_SEANCE_ENS.HEURE_SORTIE,ESP_SEANCE_ENS.HEURE_ENTREE,ESP_SEANCE_ENS.DATE_SEANCE,ESP_SEANCE_ENS.MINUTE_ENTREE,ESP_SEANCE_ENS.MINUTE_SORTIE,ESP_MODULE.DESIGNATION,ESP_SALLE_CLASSE.SALLE FROM ESP_ENSEIGNANT,ESP_MODULE,ESP_SEANCE_ENS,SOCIETE,ESP_SALLE_CLASSE WHERE ESP_ENSEIGNANT.ID_ENS=ESP_SEANCE_ENS.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_SEANCE_ENS.CODE_MODULE AND SOCIETE.ANNEE_DEB=ESP_SEANCE_ENS.ANNEE_DEB AND ESP_SALLE_CLASSE.CODE_CL=ESP_SEANCE_ENS.CODE_CL";
            //" SELECT ESP_ENSEIGNANT.NOM_ENS, ESP_SEANCE_ENS.CODE_CL,ESP_SEANCE_ENS.HEURE_SORTIE,ESP_SEANCE_ENS.HEURE_ENTREE,ESP_SEANCE_ENS.DATE_SEANCE,ESP_SEANCE_ENS.MINUTE_ENTREE,ESP_SEANCE_ENS.MINUTE_SORTIE,ESP_MODULE.DESIGNATION FROM ESP_SEANCE_ENS,ESP_ENSEIGNANT,ESP_MODULE WHERE ESP_ENSEIGNANT.ID_ENS=ESP_SEANCE_ENS.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_SEANCE_ENS.CODE_MODULE AND ESP_ENSEIGNANT.ID_ENS=ESP_SEANCE_ENS.ID_ENS";

            //--//"SELECT ESP_ENSEIGNANT.NOM_ENS, ESP_SEANCE_ENS.CODE_CL,ESP_SEANCE_ENS.HEURE_SORTIE,ESP_SEANCE_ENS.HEURE_ENTREE,ESP_SEANCE_ENS.DATE_SEANCE,ESP_SEANCE_ENS.MINUTE_ENTREE,ESP_SEANCE_ENS.MINUTE_SORTIE,ESP_MODULE.DESIGNATION FROM ESP_SEANCE_ENS,ESP_ENSEIGNANT,ESP_MODULE  WHERE ESP_ENSEIGNANT.ID_ENS=ESP_SEANCE_ENS.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_SEANCE_ENS.CODE_MODULE AND ESP_ENSEIGNANT.ID_ENS=ESP_SEANCE_ENS.ID_ENS";
            //--//"SELECT ESP_ENSEIGNANT.NOM_ENS,ESP_SALLE_CLASSE.SALLE,ESP_SEANCE_ENS.CODE_CL,ESP_MODULE.DESIGNATION,ESP_SEANCE_ENS.HEURE_SORTIE,ESP_SEANCE_ENS.HEURE_ENTREE,ESP_SEANCE_ENS.DATE_SEANCE,ESP_SEANCE_ENS.MINUTE_ENTREE,ESP_SEANCE_ENS.MINUTE_SORTIE FROM ESP_ENSEIGNANT,ESP_SALLE_CLASSE,SOCIETE,ESP_SEANCE_ENS,ESP_MODULE WHERE ESP_SEANCE_ENS.ID_ENS=ESP_ENSEIGNANT.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_SEANCE_ENS.CODE_MODULE AND ESP_SEANCE_ENS.ANNEE_DEB=SOCIETE.ANNEE_DEB";
            //--//"SELECT DISTINCT ESP_ENSEIGNANT.NOM_ENS,ESP_SALLE_CLASSE.SALLE,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL,ESP_MODULE.DESIGNATION,ESP_SEANCE_ENS.HEURE_SORTIE,ESP_SEANCE_ENS.HEURE_ENTREE,ESP_SEANCE_ENS.DATE_SEANCE,ESP_SEANCE_ENS.MINUTE_ENTREE,ESP_SEANCE_ENS.MINUTE_SORTIE FROM ESP_MODULE_PANIER_CLASSE_SAISO,ESP_ENSEIGNANT,ESP_MODULE,ESP_SALLE_CLASSE,SOCIETE,ESP_SEANCE_ENS WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_SEANCE_ENS.ID_ENS and ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_ENSEIGNANT.ID_ENS AND ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE=ESP_MODULE.CODE_MODULE AND ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB=SOCIETE.ANNEE_DEB AND SOCIETE.ANNEE_DEB=ESP_SEANCE_ENS.ANNEE_DEB  order by NOM_ENS";


            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
            conn.Close();


        }

        public DataTable getAllModule()
        {
            DataTable dt = new DataTable();

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            cmd.CommandText = "   SELECT distinct DESIGNATION,ESP_MODULE.CODE_MODULE,ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB FROM ESP_MODULE_PANIER_CLASSE_SAISO,SOCIETE, ESP_MODULE WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB=SOCIETE.ANNEE_DEB AND ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE=ESP_MODULE.CODE_MODULE ORDER BY DESIGNATION ";
            //"SELECT distinct ESP_MODULE.CODE_MODULE,ESP_MODULE.DESIGNATION FROM ESP_MODULE,ESP_MODULE_PANIER_CLASSE_SAISO,SOCIETE WHERE ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE=ESP_MODULE.CODE_MODULE  AND ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB=SOCIETE.ANNEE_DEB";
            //"  SELECT  ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE,ESP_ENSEIGNANT.NOM_ENS,ESP_MODULE.DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL,ESP_SALLE_CLASSE.SALLE   FROM ESP_SALLE_CLASSE,ESP_MODULE_PANIER_CLASSE_SAISO,ESP_MODULE,ESP_ENSEIGNANT WHERE  ESP_ENSEIGNANT.ID_ENS= ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS and ESP_MODULE.CODE_MODULE= ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE AND (ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = 1)";
            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(dt);
            return dt;
            conn.Close();
        }
        public string date_seance()
        {
            string seance = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT DATE_SEANCE FROM ESP SEANCE_ENS";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                seance = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return seance;

        }
        public List<ESP_MODULE_PANIER_CLASSE_SAISO> getnumSemestre()
        {
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT distinct NUM_SEMESTRE from ESP_MODULE_PANIER_CLASSE_SAISO,SOCIETE where ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB= SOCIETE.ANNEE_DEB ", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            DataTable dts = new DataTable();
            od.Fill(dts);
            List<ESP_MODULE_PANIER_CLASSE_SAISO> list = testsem(dts);
            con.Close();
            return list;
        }
        private List<ESP_MODULE_PANIER_CLASSE_SAISO> testsem(DataTable dts)
        {
            var convertedList = (from rw in dts.AsEnumerable()
                                 select new ESP_MODULE_PANIER_CLASSE_SAISO()
                                 {
                                     NUM_SEMESTRE = Convert.ToInt32(rw["NUM_SEMESTRE"])
                                 }).ToList();

            return convertedList;
        }
        public bool SaveEnseignant(string _ID_ET, string _CODE_MODULE, string _CODE_CL, int _NUM_SEMESTRE, int _EV1, int _EV2, int _EV3, int _EV4, int _EV5, string _PT_FORT, string _PT_FAIBLE, string _PROPOSITION, int _EV6)
        {
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "INSERT INTO ESP_MODULE_PANIER_CLASSE_SAISO(ID_ENS, CODE_MODULE, CODE_CL, NUM_SEMESTRE,) VALUES (:ID_ET, '2014', :CODE_MODULE, :CODE_CL, :NUM_SEMESTRE, sysdate,:EV1,:EV2,:EV3,:EV4,:EV5,:PT_FORT,:PT_FAIBLE,:PROPOSITION,:EV6)";
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

        //Generation Emploi du temps:

        public bool SaveEvalModule(string _ID_ET, string _CODE_MODULE, string _CODE_CL, int _NUM_SEMESTRE, int _EV1, int _EV2, int _EV3, int _EV4, int _EV5, string _PT_FORT, string _PT_FAIBLE, string _PROPOSITION, int _EV6)
        {
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "INSERT INTO ESP_EVALUATION(ID_ET, ANNEE_DEB, CODE_MODULE, CODE_CL, NUM_SEMESTRE, DATE_SAISIE,EV1,EV2,EV3,EV4,EV5,PT_FORT,PT_FAIBLE,PROPOSITION,EV6) VALUES (:ID_ET, '2014', :CODE_MODULE, :CODE_CL, :NUM_SEMESTRE, sysdate,:EV1,:EV2,:EV3,:EV4,:EV5,:PT_FORT,:PT_FAIBLE,:PROPOSITION,:EV6)";
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
        //modifier la valeur de disponibilite:
        public int Updatedispo(int idens)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE  DISPONIBLITE SET DISPONIBLE='O' where ID_ENS=" + idens, cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet GetEnseignantdisponible()
        {
            //DateTime dateNow = DateTime.Now;

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            // cmd.CommandText = "select INTERVENTION.IDINTERVENTION,DATEDEBUT,GOUVERNORAT,DATEFIN,NAME_INTERVENTION,VALID FROM INTERVENTION,NATURE_INTERVENTION,Z_GEOGRAPHIQUE WHERE Z_GEOGRAPHIQUE.IDZG=INTERVENTION.IDZG AND INTERVENTION.IDNATURE=NATURE_INTERVENTION.IDNATURE AND  DATEFIN <to_date('" + DateTime.Now + "', 'dd/mm/yyyy hh24:mi:ss')";
            cmd.CommandText = "select ID_ENS,NOM_ENS,DISPONIBLE FROM DISPONIBLE where ESP_ENS.ID_ENS=DISPONIBLE.ID_ENS";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            DataSet dt = new DataSet();
            od.Fill(dt);
            return dt;
            conn.Close();

        }

        public bool SaveEmploiduTemps(string _CODE_EMPLOI, string _TYPE, string _ID_ENS, string _H_DEBUT, string _H_FIN, DateTime _JOURS_SEANCE, string _SALLE_P, string _CODE_MODULE, string _CODE_CL)
        {
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "INSERT INTO ESP_EMPLOI_DU_TEMPS(CODE_EMPLOI,TYPE,ID_ENS,H_DEBUT, H_FIN,JOURS_SEANCE, SALLE_P,CODE_MODULE,CODE_CL) VALUES (:CODE_EMPLOI,:TYPE,ID_ENS, :H_DEBUT, :H_FIN, :to_date('" + _JOURS_SEANCE.ToString() + "', 'dd/mm/yyyy hh24:mi:ss'), :SALLE_P,:CODE_MODULE,:CODE_CL)";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;


                OracleParameter prmCODE_EMPLOI = new OracleParameter(":CODE_EMPLOI", OracleDbType.Varchar2);
                prmCODE_EMPLOI.Value = _CODE_EMPLOI;
                myCommand.Parameters.Add(prmCODE_EMPLOI);

                OracleParameter prmTYPE = new OracleParameter(":TYPE", OracleDbType.Varchar2);
                prmTYPE.Value = _TYPE;
                myCommand.Parameters.Add(prmTYPE);

                OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
                prmID_ENS.Value = _ID_ENS;
                myCommand.Parameters.Add(prmID_ENS);


                OracleParameter prmHDEBUT = new OracleParameter(":H_DEBUT", OracleDbType.Varchar2);
                prmHDEBUT.Value = _H_DEBUT;
                myCommand.Parameters.Add(prmHDEBUT);

                OracleParameter prmHFIN = new OracleParameter(":H_FIN", OracleDbType.Varchar2);
                prmHFIN.Value = _H_FIN;
                myCommand.Parameters.Add(prmHFIN);

                OracleParameter prmJOURS_SEANCE = new OracleParameter(":JOURS_SEANCE", OracleDbType.Date);
                prmJOURS_SEANCE.Value = _CODE_MODULE;
                myCommand.Parameters.Add(prmJOURS_SEANCE);

                OracleParameter prmSALLE_P = new OracleParameter(":SALLE_P", OracleDbType.Varchar2);
                prmSALLE_P.Value = _CODE_MODULE;
                myCommand.Parameters.Add(prmSALLE_P);

                OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
                prmCODE_MODULE.Value = _CODE_MODULE;
                myCommand.Parameters.Add(prmCODE_MODULE);


                OracleParameter prmCODE_CL = new OracleParameter(":CODE_CL", OracleDbType.Varchar2);
                prmCODE_CL.Value = _CODE_CL;
                myCommand.Parameters.Add(prmCODE_CL);


                bool result = myCommand.ExecuteNonQuery() > 0;

                mySqlConnection.Close();

                return result;

            }

        }

        public void AjouterEmploi(string _CODE_EMPLOI, string _TYPE, string _ID_ENS, int _H_DEBUT, int _H_FIN, DateTime _JOURS_SEANCE, string _SALLE_P, string _CODE_MODULE, string _CODE_CL, int minutE, int minS)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO ESP_EMPLOI_DU_TEMPS(CODE_EMPLOI,TYPE,ID_ENS,H_DEBUT,H_FIN,JOURS_SEANCE,SALLE_P,CODE_MODULE,CODE_CL,MINUTE_ENTREE,MINUTE_SORTIE)VALUES('" + _CODE_EMPLOI + "','" + _TYPE + "','" + _ID_ENS + "','" + _H_DEBUT + "','" + _H_FIN + "',to_date('" + _JOURS_SEANCE.ToString() + "', 'dd/mm/yyyy hh24:mi:ss'),'" + _SALLE_P + "','" + _CODE_MODULE + "','" + _CODE_CL + "','" + minutE + "','" + minS + "')";
            cmd.ExecuteNonQuery();


            //OracleCommand cmd2 = conn.CreateCommand();
            //cmd.CommandText ="select MAX()"
            //conn.Close();
        }

        //Afficher l'emploi du temps dans un calendrier
       

        public void Ajoutermatiere(string _CODE_MODULE, string _DESIGNATION)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO ESP_MODULE(CODE_MODULE,DESIGNATION)VALUES('" + _CODE_MODULE + "','" + _DESIGNATION + "')";
            cmd.ExecuteNonQuery();

        }

        public void choisirEmploiByID_ENS(string ID_ENS)
        {

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM ESP_EMPLOI_DU_TEMPS WHERE ESP_EMPLOI_DU_TEMPS.ID_ENS='" + ID_ENS + "'";
            cmd.ExecuteNonQuery();
        }

        public DataTable GetDataEventsByID_ENS(string id_ens)
        {
            DataTable dt = new DataTable("ESP_EMPLOI_DU_TEMPS");

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            if (!string.IsNullOrEmpty(id_ens))
                cmd.CommandText = "SELECT distinct ESP_ENSEIGNANT.NOM_ENS, ESP_EMPLOI_DU_TEMPS.CODE_CL,ESP_EMPLOI_DU_TEMPS.H_DEBUT,ESP_EMPLOI_DU_TEMPS.MINUTE_ENTREE,ESP_EMPLOI_DU_TEMPS.MINUTE_SORTIE,ESP_EMPLOI_DU_TEMPS.H_FIN,ESP_EMPLOI_DU_TEMPS.JOURS_SEANCE,ESP_MODULE.DESIGNATION,ESP_EMPLOI_DU_TEMPS.SALLE_P FROM ESP_ENSEIGNANT,ESP_MODULE,ESP_EMPLOI_DU_TEMPS,ESP_SALLE_CLASSE WHERE ESP_ENSEIGNANT.ID_ENS=ESP_EMPLOI_DU_TEMPS.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_EMPLOI_DU_TEMPS.CODE_MODULE AND ESP_SALLE_CLASSE.CODE_CL=ESP_EMPLOI_DU_TEMPS.CODE_CL and ESP_ENSEIGNANT.ID_ENS='" + id_ens + "'";
            else
                cmd.CommandText = "SELECT distinct ESP_ENSEIGNANT.NOM_ENS, ESP_EMPLOI_DU_TEMPS.CODE_CL,ESP_EMPLOI_DU_TEMPS.H_DEBUT,ESP_EMPLOI_DU_TEMPS.MINUTE_ENTREE,ESP_EMPLOI_DU_TEMPS.MINUTE_SORTIE,ESP_EMPLOI_DU_TEMPS.H_FIN,ESP_EMPLOI_DU_TEMPS.JOURS_SEANCE,ESP_MODULE.DESIGNATION,ESP_EMPLOI_DU_TEMPS.SALLE_P FROM ESP_ENSEIGNANT,ESP_MODULE,ESP_EMPLOI_DU_TEMPS,ESP_SALLE_CLASSE WHERE ESP_ENSEIGNANT.ID_ENS=ESP_EMPLOI_DU_TEMPS.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_EMPLOI_DU_TEMPS.CODE_MODULE AND ESP_SALLE_CLASSE.CODE_CL=ESP_EMPLOI_DU_TEMPS.CODE_CL";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
            conn.Close();

        }

        public void VerifDispo(string annee,string idens, string joursSeance, int hd, int hf)
        {

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO ESP_DISPONIBILITE_ENS(ANNEE_DEB,JOURS,SEANCE_D,SEANCE_F,ID_ENS)VALUES('"+annee+"',to_date('" + joursSeance.ToString() + "', 'dd/mm/yyyy hh24:mi:ss'),'" + hd + "','" + hf + "','" + idens + "')";
            cmd.ExecuteNonQuery();

        }

        public DataTable GETdispo()
        {
            DataTable ds = new DataTable("ESP_DISPONIBILITE_ENS");

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            //cmd.CommandText = "SELECT ESP_DISPONIBILITE_ENS.ID_DISPO,ESP_DISPONIBILITE_ENS.SEANCE_D,ESP_DISPONIBILITE_ENS.SEANCE_F,ESP_DISPONIBILITE_ENS.JOURS,ESP_ENSEIGNANT.NOM_ENS FROM ESP_DISPONIBILITE_ENS,ESP_ENSEIGNANT WHERE ESP_DISPONIBILITE_ENS.ID_ENS=ESP_ENSEIGNANT.ID_ENS";
            cmd.CommandText = "select distinct SEANCE_D,SEANCE_F,esp_disponibilite_ens.ID_ENS,JOURS,ESP_ENSEIGNANT.NOM_ENS,(select code_nomenclature.LIB_NOME from code_nomenclature where (code_str='60') and code_nome=SEANCE_D)as SEANCE_Df,(select code_nomenclature.LIB_NOME from code_nomenclature where (code_str='60') and code_nome=SEANCE_F)AS SEANCE_Fg from esp_disponibilite_ens,ESP_ENSEIGNANT where esp_disponibilite_ens.ID_ENS=ESP_ENSEIGNANT.ID_ENS";
 
            
            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(ds);

            con.Close();
            return ds;
        }
        public DataTable GETiNDSPObYid(string ID_ENS)
        {
            DataTable ds = new DataTable("ESP_DISPONIBILITE_ENS");

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = con.CreateCommand();
          //  cmd.CommandText = "SELECT ESP_DISPONIBILITE_ENS.ID_DISPO,ESP_DISPONIBILITE_ENS.SEANCE_D,ESP_DISPONIBILITE_ENS.SEANCE_F,ESP_DISPONIBILITE_ENS.JOURS,ESP_ENSEIGNANT.NOM_ENS FROM ESP_DISPONIBILITE_ENS,ESP_ENSEIGNANT WHERE ESP_DISPONIBILITE_ENS.ID_ENS=ESP_ENSEIGNANT.ID_ENS AND ESP_ENSEIGNANT.ID_ENS='" + ID_ENS + "'";
           // cmd.CommandText = "select SEANCE_D,SEANCE_F,(select code_nomenclature.LIB_NOME from code_nomenclature where (code_str='60') and code_nome=SEANCE_D)as SEANCE_Df,(select code_nomenclature.LIB_NOME from code_nomenclature  where (code_str='60') and code_nome=SEANCE_F)AS SEANCE_Fg from esp_disponibilite_ens where id_ens='"+ID_ENS+"'";
            cmd.CommandText = "select distinct SEANCE_D,SEANCE_F,esp_disponibilite_ens.ID_ENS,JOURS,ESP_ENSEIGNANT.NOM_ENS,(select code_nomenclature.LIB_NOME from code_nomenclature where (code_str='60') and code_nome=SEANCE_D)as SEANCE_Df,(select code_nomenclature.LIB_NOME from code_nomenclature where (code_str='60') and code_nome=SEANCE_F)AS SEANCE_Fg from esp_disponibilite_ens,ESP_ENSEIGNANT where esp_disponibilite_ens.ID_ENS=ESP_ENSEIGNANT.ID_ENS AND esp_disponibilite_ens.id_ens='"+ID_ENS+"'";
 

            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(ds);

            con.Close();
            return ds;
        }
        public string getdispo(string idens)
        {
            string dispo = "";
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT disponible from esp_disponibilite_ens where id_ens ='" + idens + "'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                dispo = myCommand.ExecuteScalar().ToString();

                mySqlConnection.Close();
            }
            return dispo;

        }

        public DataTable getSalleByClasSe(string code_cl)
        {

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            cmd.CommandText = "SELECT DISTINCT SALLE FROM ESP_SALLE_CLASSE,SOCIETE,ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_SALLE_CLASSE.CODE_CL=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL AND ESP_SALLE_CLASSE.ANNEE_DEB=SOCIETE.ANNEE_DEB  AND ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB=SOCIETE.ANNEE_DEB  AND  ESP_SALLE_CLASSE.CODE_CL ='" + code_cl + "'";
            //"SELECT DISTINCT SALLE FROM ESP_SALLE_CLASSE,SOCIETE,ESP_EMPLOI_DU_TEMPS WHERE ESP_SALLE_CLASSE.CODE_CL=ESP_EMPLOI_DU_TEMPS.CODE_CL AND ESP_SALLE_CLASSE.ANNEE_DEB=SOCIETE.ANNEE_DEB AND  ESP_SALLE_CLASSE.CODE_CL='"+code_cl+"'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            od.Fill(dt);
            return dt;
            conn.Close();
        }

        public string getsalleBycode(string code_cl)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT SALLE_PRINCIPALE,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL FROM ESP_SAISON_CLASSE,ESP_MODULE_PANIER_CLASSE_SAISO ,SOCIETE WHERE ESP_SAISON_CLASSE.ANNEE_DEB=SOCIETE.ANNEE_DEB AND ESP_SAISON_CLASSE.CODE_CL=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL and ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL='" + code_cl + "' ORDER BY CODE_CL";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string getANNEEDEB()
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

        public string getNUMSemestre()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT NUM_SEMESTRE FROM  ESP_MODULE_PANIER_CLASSE_SAISO,SOCIETE where ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE =SOCIETE.NUM_SEMESTRE_ACTUEL";


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

        /*SELECT distinct ESP_ENSEIGNANT.NOM_ENS FROM ESP_ENSEIGNANT,ESP_MODULE_PANIER_CLASSE_SAISO,ESP_MODULE WHERE ESP_ENSEIGNANT.ID_ENS=ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS AND  ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE ='RI-09' order by NOM_ENS*/
        public DataTable getlisteCLbYeNS(string id_ens)
        {
            DataTable dt = new DataTable();

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            cmd.CommandText = " SELECT code_cl from esp_module_panier_classe_saiso,SOCIETE,ESP_ENSEIGNANT where esp_module_panier_classe_saiso.annee_deb=SOCIETE.ANNEE_DEB and esp_module_panier_classe_saiso.ID_ENS=ESP_ENSEIGNANT.ID_ENS and  esp_module_panier_classe_saiso.NUM_SEMESTRE=SOCIETE.NUM_SEMESTRE_ACTUEL and  ESP_ENSEIGNANT.id_ens='" + id_ens + "'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(dt);
            return dt;
            conn.Close();
        }

        public DataTable getENsBymoD(string code_cLASSE)
        {
            DataTable dt = new DataTable();

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            cmd.CommandText = "select DISTINCT NOM_ENS,ESP_ENSEIGNANT.ID_ENS from ESP_MODULE_PANIER_CLASSE_SAISO ,ESP_ENSEIGNANT,SOCIETE WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_ENSEIGNANT.ID_ENS AND ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB=SOCIETE.ANNEE_DEB AND ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE=SOCIETE.NUM_SEMESTRE_ACTUEL  AND ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL ='" + code_cLASSE + "'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(dt);
            return dt;
            conn.Close();
        }
        public DataTable BindListensIndispo()
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand(" select CODE_EMPLOI,annee_deb,code_cl,DESIGNATION,nom_ens,salle_principale,JOURS,CREN_1,CREN_2 from esp_affectation_emploi,esp_module,esp_enseignant where esp_module.CODE_MODULE=esp_affectation_emploi.CODE_MODULE and esp_enseignant.ID_ENS=esp_affectation_emploi.ID_ENS", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getMODULEBY(string code_cLASSE)
        {
            DataTable dt = new DataTable();

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter(); cmd.CommandText = "SELECT ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE,DESIGNATION ,id_ens from ESP_MODULE_PANIER_CLASSE_SAISO ,ESP_MODULE,SOCIETE WHERE  ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE=SOCIETE.NUM_SEMESTRE_ACTUEL AND ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE AND ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB=SOCIETE.ANNEE_DEB AND ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL ='" + code_cLASSE + "'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(dt);
            return dt;
            conn.Close();
        }
        //Modifier les affectations des salles
        public int UpdateSalle(string codecl, string salle, float id)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE  ESP_SALLE_CLASSE SET CODE_CL='" + codecl + "' ,SALLE='" + salle + "' where ID=" + id, cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }

        public string getanneedeb()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT ANNEE_DEB || '/' || ANNEE_FIN FROM SOCIETE";
                //"SELECT ANNEE_DEB,'/',ANNEE_FIN FROM SOCIETE  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string getNameteacher(string id_ens)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select distinct ESP_ENSEIGNANT.nom_ens,ESP_ENSEIGNANT.id_ens from ESP_ENSEIGNANT,esp_module_panier_classe_saiso,societe where ESP_ENSEIGNANT.id_ens=esp_module_panier_classe_saiso.id_ens and  esp_module_panier_classe_saiso.annee_deb= societe.annee_deb and  ESP_ENSEIGNANT.ETAT='A' AND ESP_ENSEIGNANT.id_ens ='" + id_ens + "'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public DataTable Getnomens(string id_ens)
        {
            DataTable dt = new DataTable();

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter(); cmd.CommandText = "select distinct ESP_ENSEIGNANT.nom_ens,ESP_ENSEIGNANT.id_ens from ESP_ENSEIGNANT,esp_module_panier_classe_saiso,societe where ESP_ENSEIGNANT.id_ens=esp_module_panier_classe_saiso.id_ens and  esp_module_panier_classe_saiso.annee_deb= societe.annee_deb and  ESP_ENSEIGNANT.ETAT='A' AND ESP_ENSEIGNANT.id_ens ='" + id_ens + "'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(dt);
            return dt;
            conn.Close();
        }



        public string GetnbHr(string code_cl, string code_module)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = " select nb_heures from ESP_MODULE_PANIER_CLASSE_SAISO where  annee_deb=2014 and "
    + "num_semestre=2 and code_cl='" + code_cl + "'AND CODE_MODULE='" + code_module + "' ";
                //"SELECT ANNEE_DEB,'/',ANNEE_FIN FROM SOCIETE  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public DataTable GetDataEventsByCode_cl(string code_cl)
        {
            DataTable dt = new DataTable("ESP_AFFECTATION_EMPLOI");
            
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            if (!string.IsNullOrEmpty(code_cl))

                cmd.CommandText = "SELECT distinct ESP_ENSEIGNANT.NOM_ENS, ESP_AFFECTATION_EMPLOI.CODE_CL,ESP_AFFECTATION_EMPLOI.CREN_1,ESP_AFFECTATION_EMPLOI.CREN_2,ESP_AFFECTATION_EMPLOI.JOURS,ESP_MODULE.DESIGNATION,ESP_AFFECTATION_EMPLOI.SALLE_PRINCIPALE,(select code_nomenclature.LIB_NOME from code_nomenclature where (code_str='60') and code_nome=CREN_1)as SEANCE_DEB,(select code_nomenclature.LIB_NOME from code_nomenclature where (code_str='60') and code_nome=CREN_2)AS SEANCE_FIN FROM ESP_ENSEIGNANT,ESP_MODULE,ESP_AFFECTATION_EMPLOI,ESP_SAISON_CLASSE WHERE ESP_ENSEIGNANT.ID_ENS=ESP_AFFECTATION_EMPLOI.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_AFFECTATION_EMPLOI.CODE_MODULE AND ESP_SAISON_CLASSE.CODE_CL=ESP_AFFECTATION_EMPLOI.CODE_CL and ESP_SAISON_CLASSE.CODE_CL='" + code_cl + "'";
            //cmd.CommandText = "SELECT distinct ESP_ENSEIGNANT.NOM_ENS, ESP_AFFECTATION_EMPLOI.CODE_CL,ESP_AFFECTATION_EMPLOI.CREN_1,ESP_AFFECTATION_EMPLOI.CREN_2,ESP_AFFECTATION_EMPLOI.JOURS,ESP_MODULE.DESIGNATION,ESP_AFFECTATION_EMPLOI.SALLE_PRINCIPALE FROM ESP_ENSEIGNANT,ESP_MODULE,ESP_AFFECTATION_EMPLOI,ESP_SAISON_CLASSE WHERE ESP_ENSEIGNANT.ID_ENS=ESP_AFFECTATION_EMPLOI.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_AFFECTATION_EMPLOI.CODE_MODULE AND ESP_SAISON_CLASSE.CODE_CL=ESP_AFFECTATION_EMPLOI.CODE_CL and ESP_SAISON_CLASSE.CODE_CL='" + code_cl + "'";
            else
                //cmd.CommandText = "SELECT distinct ESP_ENSEIGNANT.NOM_ENS, ESP_AFFECTATION_EMPLOI.CODE_CL,ESP_AFFECTATION_EMPLOI.CREN_1,ESP_AFFECTATION_EMPLOI.CREN_2,ESP_AFFECTATION_EMPLOI.JOURS,ESP_MODULE.DESIGNATION,ESP_AFFECTATION_EMPLOI.SALLE_PRINCIPALE FROM ESP_ENSEIGNANT,ESP_MODULE,ESP_AFFECTATION_EMPLOI,ESP_SAISON_CLASSE WHERE ESP_ENSEIGNANT.ID_ENS=ESP_AFFECTATION_EMPLOI.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_AFFECTATION_EMPLOI.CODE_MODULE AND ESP_SAISON_CLASSE.CODE_CL=ESP_AFFECTATION_EMPLOI.CODE_CL";

                cmd.CommandText = "SELECT distinct ESP_ENSEIGNANT.NOM_ENS, ESP_AFFECTATION_EMPLOI.CODE_CL,ESP_AFFECTATION_EMPLOI.CREN_1,ESP_AFFECTATION_EMPLOI.CREN_2,ESP_AFFECTATION_EMPLOI.JOURS,ESP_MODULE.DESIGNATION,ESP_AFFECTATION_EMPLOI.SALLE_PRINCIPALE,(select code_nomenclature.LIB_NOME from code_nomenclature where (code_str='60') and code_nome=CREN_1)as SEANCE_DEB,(select code_nomenclature.LIB_NOME from code_nomenclature where (code_str='60') and code_nome=CREN_2)AS SEANCE_FIN FROM ESP_ENSEIGNANT,ESP_MODULE,ESP_AFFECTATION_EMPLOI,ESP_SAISON_CLASSE WHERE ESP_ENSEIGNANT.ID_ENS=ESP_AFFECTATION_EMPLOI.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_AFFECTATION_EMPLOI.CODE_MODULE AND ESP_SAISON_CLASSE.CODE_CL=ESP_AFFECTATION_EMPLOI.CODE_CL";
                OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
            conn.Close();

        }


        public DataTable BindMODULEByEns(string nom_ens, string code_cl)
        {
            DataTable dt = new DataTable();

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            cmd.CommandText = "SELECT  DISTINCT DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE,ESP_MODULE_PANIER_CLASSE_SAISO.CHARGE_ENS1_P1,ESP_MODULE_PANIER_CLASSE_SAISO.CHARGE_ENS1_P2,ESP_MODULE_PANIER_CLASSE_SAISO.NB_HEURES FROM ESP_MODULE_PANIER_CLASSE_SAISO,ESP_ENSEIGNANT,ESP_MODULE,SOCIETE WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_ENSEIGNANT.ID_ENS and ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE AND ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB=SOCIETE.ANNEE_DEB AND ESP_ENSEIGNANT.ID_ENS= '" + nom_ens + "' AND CODE_CL='" + code_cl + "'";
            //SELECT  DISTINCT DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE FROM ESP_MODULE_PANIER_CLASSE_SAISO,ESP_ENSEIGNANT,ESP_MODULE,SOCIETE WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_ENSEIGNANT.ID_ENS and ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE AND ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB=SOCIETE.ANNEE_DEB AND ESP_ENSEIGNANT.NOM_ENS= '"+nom_ens+"' AND CODE_CL='"+code_cl+"'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(dt);
            return dt;
            conn.Close();
        }
        public void Enre_Affect_emploi(string annee_deb, string code_cl, string code_modUle, string id_ens1, string salle_p, DateTime jours, int _CREN_1, int CREN_2)
        {

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO ESP_AFFECTATION_EMPLOI(ANNEE_DEB,CODE_CL,CODE_MODULE,ID_ENS,SALLE_PRINCIPALE,JOURS,CREN_1,CREN_2)VALUES('" + annee_deb + "', '" + code_cl + "','" + code_modUle + "','" + id_ens1 + "', '" + salle_p + "',to_date('" + jours.ToString() + "', 'dd/mm/yyyy hh24:mi:ss'), '" + _CREN_1 + "','" + CREN_2 + "')";
            cmd.ExecuteNonQuery();

        }
        // afficher l'enseignant indisponible
        public DataTable getEnsIndispo(string id_ens)
        {
            DataTable dt = new DataTable();

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            cmd.CommandText = " SELECT  ESP_ENSEIGNANT.ID_ENS,ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB,CODE_EMPLOI,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL,DESIGNATION,ESP_ENSEIGNANT.NOM_ENS,JOURS,SALLE_PRINCIPALE,CREN_1,CREN_2,ESP_MODULE_PANIER_CLASSE_SAISO.CHARGE_ENS1_P1,ESP_MODULE_PANIER_CLASSE_SAISO.CHARGE_ENS1_P2,ESP_MODULE_PANIER_CLASSE_SAISO.NB_HEURES  FROM ESP_AFFECTATION_EMPLOI,ESP_MODULE,ESP_ENSEIGNANT,ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS= ESP_ENSEIGNANT.ID_ENS AND ESP_AFFECTATION_EMPLOI.CODE_MODULE=ESP_MODULE.CODE_MODULE AND ESP_AFFECTATION_EMPLOI.ID_ENS=ESP_ENSEIGNANT.ID_ENS AND ESP_AFFECTATION_EMPLOI.ID_ENS='" + id_ens + "'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(dt);
            return dt;
            conn.Close();
        }
        //room in use
        //public void RoomInUse()
        //{
        //    OracleCommand com = new OracleCommand("Select * from qryRoomAvailability Where cTimeIn <> #" + cboFrom.Text + "# and cTimeOut <> #" + cboTo.Text + "# and cDay LIKE '%" + cboDay.Text + "%'", clsCon.con);
        //    OracleDataReader dr = com.ExecuteReader();
        //    lvRoom2.Items.Clear();
        //    while (dr.Read())
        //    {
        //        ListViewItem list = new ListViewItem(dr["Building"].ToString());
        //        list.SubItems.Add(dr["RoomNo"].ToString());
        //        list.SubItems.Add(dr["Capacity"].ToString());
        //        lvRoom2.Items.AddRange(new ListViewItem[] { list });
        //    }
        //    txtStatus.Text = Convert.ToString(lvRooms.Items.Count) + " rooms found.";
        //    dr.Close();
        //}



        public DataTable getEnsIndisponible(string code_cl, string id_ens, string code_module, DateTime jours, int num_seance1, int num_seance2, string sallep)
        {
            DataTable dt = new DataTable();

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();

            cmd.CommandText = "SELECT CODE_CL,JOURS,CREN_1,CREN_2,id_ens,SALLE_PRINCIPALE,CODE_MODULE  FROM ESP_AFFECTATION_EMPLOI WHERE CODE_CL ='" + code_cl + "' "
            + "and iD_ens='" + id_ens + "' and code_module ='" + code_module + "'"
                + "and JOURS=to_date('" + jours.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and CREN_1='" + num_seance1 + "' and CREN_2='" + num_seance2 + "'"

                + "or (CODE_CL <>'" + code_cl + "' "
            + "and iD_ens='" + id_ens + "' and code_module ='" + code_module + "'"
                + "and JOURS <> to_date('" + jours.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and CREN_1 <>'" + num_seance1 + "' and CREN_2 <>'" + num_seance2 + "')"

               + "and (CODE_CL <>'" + code_cl + "' "
               + "and iD_ens<>'" + id_ens + "' and code_module <>'" + code_module + "'"
               + "and JOURS <> to_date('" + jours.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and CREN_1 <>'" + num_seance1 + "' and CREN_2 <>'" + num_seance2 + "')"

                + "and (CODE_CL <>'" + code_cl + "' "
                + "and iD_ens='" + id_ens + "' and code_module ='" + code_module + "'"
                + "and JOURS=to_date('" + jours.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and CREN_1 ='" + num_seance1 + "' and CREN_2 ='" + num_seance2 + "')"



                 + "and (CODE_CL ='" + code_cl + "' "
           + "and iD_ens<>'" + id_ens + "' and code_module <>'" + code_module + "'"
               + "and JOURS =to_date('" + jours.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and CREN_1 ='" + num_seance1 + "' and CREN_2 ='" + num_seance2 + "')"

            + "OR (JOURS =to_date('" + jours.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and CREN_1 ='" + num_seance1 + "' and CREN_2 ='" + num_seance2 + "' and CODE_CL ='" + code_cl + "' )"

            + "OR (JOURS =to_date('" + jours.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and CREN_1 ='" + num_seance1 + "' and CREN_2 ='" + num_seance2 + "' and ID_ENS ='" + id_ens + "' )"
           //+ "OR (JOURS =to_date('" + jours.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') or code_module ='" + code_module + "' or ID_ENS <>'" + id_ens + "'  or CREN_1 <> CREN_2 )"
           //+ "and CREN_1=CREN_2 or JOURS =to_date('" + jours.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') or ID_ENS ='" + id_ens + "' OR CODE_CL <>'" + code_cl + "' or code_module <>'" + code_module + "'  "

           //+ " and CREN_1=CREN_2 "
           + "or (  code_module <>'" + code_module + "' and iD_ens<>'" + id_ens + "' and JOURS =to_date('" + jours.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl='" + code_cl + "' and CREN_1 <>'" + num_seance1 + "' and CREN_2 <>'" + num_seance2 + "' )"
            + "or (iD_ens='" + id_ens + "' and code_module ='" + code_module + "' and JOURS =to_date('" + jours.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') )"
            ;
           
            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(dt);
            return dt;
            conn.Close();
        }

        //Requete sur le jours et les seance
        public DataTable getdispojours(string Jours, string num_seance1, string num_seance2, string id_ens)
        {
            DataTable dt = new DataTable();

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            cmd.CommandText = "SELECT JOURS,CREN_1,CREN_2  FROM ESP_AFFECTATION_EMPLOI WHERE JOURS='" + Jours + "' and CREN_1='" + num_seance1 + "' and CREN_1='" + num_seance1 + "' OR (ID_ENS <>'" + id_ens + "')";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
            conn.Close();
        }


        //Plan d'Etude pour l'annee 2014/2015
        public DataTable PlanEtuDE(string codee_ccl)
        {
            DataTable dt = new DataTable();

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            cmd.CommandText = "select ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE,societe.ANNEE_DEB, ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,esp_module.DESIGNATION,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_module  ,ESP_MODULE_PANIER_CLASSE_SAISO.CHARGE_ENS1_P1,ESP_MODULE_PANIER_CLASSE_SAISO.CHARGE_ENS1_P2,ESP_MODULE_PANIER_CLASSE_SAISO.NB_HEURES from ESP_MODULE_PANIER_CLASSE_SAISO,societe ,ESP_ENSEIGNANT,esp_module where SOCIETE.ANNEE_DEB=ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB and SOCIETE.NUM_SEMESTRE_ACTUEL=ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE and ESP_MODULE_PANIER_CLASSE_SAISO.code_cl='" + codee_ccl + "' AND ESP_ENSEIGNANT.ID_ENS=ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS and esp_module.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
            conn.Close();
        }


        //binding data using id_ens
        public DataTable BindDataEventsByID_ENS(string id_ens)
        {
            DataTable dt = new DataTable("ESP_AFFECTATION_EMPLOI");
            
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            if (!string.IsNullOrEmpty(id_ens))
                cmd.CommandText = "SELECT distinct ESP_ENSEIGNANT.NOM_ENS, ESP_AFFECTATION_EMPLOI.CODE_CL,ESP_AFFECTATION_EMPLOI.CREN_1,ESP_AFFECTATION_EMPLOI.CREN_2,ESP_AFFECTATION_EMPLOI.JOURS,ESP_MODULE.DESIGNATION,ESP_AFFECTATION_EMPLOI.SALLE_PRINCIPALE FROM ESP_ENSEIGNANT,ESP_MODULE,ESP_AFFECTATION_EMPLOI,ESP_SAISON_CLASSE WHERE ESP_ENSEIGNANT.ID_ENS=ESP_AFFECTATION_EMPLOI.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_AFFECTATION_EMPLOI.CODE_MODULE AND ESP_SAISON_CLASSE.CODE_CL=ESP_AFFECTATION_EMPLOI.CODE_CL and ESP_ENSEIGNANT.ID_ENS='" + id_ens + "'";
            else
                cmd.CommandText = "SELECT distinct ESP_ENSEIGNANT.NOM_ENS, ESP_AFFECTATION_EMPLOI.CODE_CL,ESP_AFFECTATION_EMPLOI.CREN_1,ESP_AFFECTATION_EMPLOI.CREN_2,ESP_AFFECTATION_EMPLOI.JOURS,ESP_MODULE.DESIGNATION,ESP_AFFECTATION_EMPLOI.SALLE_PRINCIPALE FROM ESP_ENSEIGNANT,ESP_MODULE,ESP_AFFECTATION_EMPLOI,ESP_SAISON_CLASSE WHERE ESP_ENSEIGNANT.ID_ENS=ESP_AFFECTATION_EMPLOI.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_AFFECTATION_EMPLOI.CODE_MODULE AND ESP_SAISON_CLASSE.CODE_CL=ESP_AFFECTATION_EMPLOI.CODE_CL";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
            conn.Close();
        }


        public DataTable BindDataEventsByCode_cl(string code_cl)
        {
            DataTable dt = new DataTable("ESP_EMPLOI_DU_TEMPS");

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            if (!string.IsNullOrEmpty(code_cl))
                cmd.CommandText = "SELECT distinct ESP_ENSEIGNANT.NOM_ENS, ESP_AFFECTATION_EMPLOI.CODE_CL,ESP_AFFECTATION_EMPLOI.CREN_1,ESP_AFFECTATION_EMPLOI.CREN_2,ESP_AFFECTATION_EMPLOI.JOURS,ESP_MODULE.DESIGNATION,ESP_AFFECTATION_EMPLOI.SALLE_PRINCIPALE FROM ESP_ENSEIGNANT,ESP_MODULE,ESP_EMPLOI_DU_TEMPS,ESP_SALLE_CLASSE WHERE ESP_ENSEIGNANT.ID_ENS=ESP_EMPLOI_DU_TEMPS.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_EMPLOI_DU_TEMPS.CODE_MODULE AND ESP_SALLE_CLASSE.CODE_CL=ESP_AFFECTATION_EMPLOI.CODE_CL and ESP_SALLE_CLASSE.CODE_CL='" + code_cl + "'";

            else
                cmd.CommandText = "SELECT distinct ESP_ENSEIGNANT.NOM_ENS, ESP_AFFECTATION_EMPLOI.CODE_CL,ESP_AFFECTATION_EMPLOI.CREN_1,ESP_AFFECTATION_EMPLOI.CREN_2,ESP_AFFECTATION_EMPLOI.JOURS,ESP_MODULE.DESIGNATION,ESP_AFFECTATION_EMPLOI.SALLE_PRINCIPALE FROM ESP_ENSEIGNANT,ESP_MODULE,ESP_EMPLOI_DU_TEMPS,ESP_SALLE_CLASSE WHERE ESP_ENSEIGNANT.ID_ENS=ESP_EMPLOI_DU_TEMPS.ID_ENS AND ESP_MODULE.CODE_MODULE=ESP_EMPLOI_DU_TEMPS.CODE_MODULE AND ESP_SALLE_CLASSE.CODE_CL=ESP_AFFECTATION_EMPLOI.CODE_CL";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
            conn.Close();

        }

        //les methodes pour le plan etude2015
        public string getCODE_CL(string id_ens)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public DataTable getcodeclByID(string ID_ens)
        {
            DataTable dt = new DataTable();

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();
            cmd.CommandText = "select code_cl from ESP_INSCRIPTION where id_et ='" + ID_ens + "'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
            conn.Close();
        }


        public string GetCodeCL_BYet(string id_et)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select code_cl from ESP_INSCRIPTION where id_et ='" + id_et + "' ";
                

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //supprimer une séance
        //and JOURS=to_date('" + jours.ToString() + "', 'dd/mm/yyyy hh24:mi:ss')
        public int Deleteenseign(string id_ens)
        {

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("Delete From ESP_AFFECTATION_EMPLOI Where ID_ENS='" + id_ens + "'", conn);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }


        //get id etudiant
        public string getIDenseignant(string nom_ense)
        {
            string _id = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT ID_ENS FROM ESP_ENSEIGNANT WHERE NOM_ENS LIKE '%"+nom_ense+"%' and etat='A' ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read())
                {
                    // String Name = MyReader["Username"].ToString();

                    _id = MyReader["ID_ENS"].ToString();


                }
                MyReader.Close();
                mySqlConnection.Close();
            }

            return _id;

        }


        public DataTable BindNumSeanceBYNnmclature()
        {
            DataTable dt = new DataTable("ESP_EMPLOI_DU_TEMPS");
         
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();

            cmd.CommandText = "SELECT CODE_NOMENCLATURE.CODE_NOME,CODE_NOMENCLATURE.LIB_NOME FROM CODE_NOMENCLATURE,STR_NOME WHERE STR_NOME.CODE_STR=CODE_NOMENCLATURE.CODE_STR and CODE_NOMENCLATURE.CODE_STR='60'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
            conn.Close();

        }

        //get disponibilite des enseignants selon si lamjed

        public DataTable getEnsinDispoparlmjed(string id_ens,DateTime jours, int num_seance1, int num_seance2)
        {
            DataTable dt = new DataTable("ESP_DISPONIBILITE_ENS");

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            OracleParameter ora = new OracleParameter();

            cmd.CommandText = "select ID_ENS ,SEANCE_D,SEANCE_F,JOURS from ESP_DISPONIBILITE_ENS WHERE iD_ens='" + id_ens + "'"
                + "and JOURS=to_date('" + jours.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and SEANCE_D='" + num_seance1 + "' and SEANCE_F='" + num_seance2 + "'";
             
               
            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(dt);
            return dt;
            conn.Close();
        }


        //ici mon exemple de table:

        public DataTable Bindrep()
        {
            DataTable ds = new DataTable();


            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand("select * from Repeater", con);

            OracleDataAdapter od = new OracleDataAdapter(cmd);

            od.Fill(ds);

            con.Close();
            return ds;


        }


        public void posteddate(string _SALLE_P, string _CODE_MODULE, string _CODE_CL)
        {

            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into REPEATER (UserName,Subject,COLCOM )VALUES('" + _SALLE_P + "','" + _CODE_MODULE + "','" + CODE_CL + "')";
            cmd.ExecuteNonQuery();


            //OracleCommand cmd2 = conn.CreateCommand();
            //cmd.CommandText ="select MAX()"
            //conn.Close();
        }
    }
}
