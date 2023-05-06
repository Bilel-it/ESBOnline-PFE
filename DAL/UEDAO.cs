using admiss;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
  public  class UEDAO
    {


        #region sing
        static UEDAO instance;
        static Object locker = new Object();
        public static UEDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new UEDAO();
                    }

                    return UEDAO.instance;
                }
            }

        }

        private UEDAO() { }
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

        public DataTable Getchapteraquis2018(string text, string id_ens, string an)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            //cmd.CommandText = "select a.NUM_CHAPTER,a.TITRE_CHAPTER, a.HORAIRE_CHAP from esp_acquis_module a where ID_ENS='"+ id_ens + "' and a.code_module = '" + text + "' order by NUM_CHAPTER ";
            cmd.CommandText = "select a.NUM_CHAPTER,a.TITRE_CHAPTER, a.HORAIRE_CHAP from esp_acquis_module a where  a.code_module = '" + text + "' and  a.ANNEE_DEB = '" + an + "' order by NUM_CHAPTER ";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }
        public string getAnneeSociete()
        {
            string an = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select code_cl from ESP_INSCRIPTION  e inner join societe s on s.annee_deb=e.annee_deb  where  id_et='"+id_et+"' and code_cl not in ('---')";
                string cmdQuery = "select ANNEE_DEB from  societe";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                an = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return an;
        }
        public DataTable GetUE(string id_ens, string annedeb)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select distinct e.code_ue,e.code_ue ||' '||lib_ue as UE  from ESP_MODULE_PANIER_CLASSE_SAISO e inner join ESP_UE u on u.CODE_UE = e.CODE_UE where e.ANNEE_DEB = '" + annedeb + "' and e.ID_ENS = '" + id_ens + "' order by ue";
            //AND e.CODE_UE NOT IN(select distinct s.code_ue from esp_acquis_ue S where s.annee_deb = '" + annedeb + "' AND s.ID_ENS = '" + id_ens + "'

            // cmd.CommandText = "select distinct e.code_ue,e.code_ue ||' '||lib_ue as UE  from esp_acquis_ue e inner join ESP_UE u on u.CODE_UE = e.CODE_UE where e.ANNEE_DEB = '"+annedeb+"' and e.ID_ENS = '"+id_ens+"' and e.code_ue not in (select m.code_ue from esp_acquis_module m where m.ANNEE_DEB = '"+annedeb+"' and m.ID_ENS = '"+id_ens+"') order by ue";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }




        public DataTable GetUEV0(string id_ens, string annedeb)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select distinct e.code_ue,e.code_ue ||' '||lib_ue as UE  from ESP_MODULE_PANIER_CLASSE_SAISO e inner join ESP_UE u on u.CODE_UE = e.CODE_UE where e.ANNEE_DEB = '" + annedeb + "' and e.ID_ENS = '" + id_ens + "' order by ue";

            // cmd.CommandText = "select distinct e.code_ue,e.code_ue ||' '||lib_ue as UE  from esp_acquis_ue e inner join ESP_UE u on u.CODE_UE = e.CODE_UE where e.ANNEE_DEB = '"+annedeb+"' and e.ID_ENS = '"+id_ens+"' and e.code_ue not in (select m.code_ue from esp_acquis_module m where m.ANNEE_DEB = '"+annedeb+"' and m.ID_ENS = '"+id_ens+"') order by ue";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }




        public DataTable GetUExep(string id_ens, string annedeb)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            //cmd.CommandText = "select distinct e.code_ue,e.code_ue ||' '||lib_ue as UE  from esp_acquis_ue e inner join ESP_UE u on u.CODE_UE=e.CODE_UE where e.ANNEE_DEB='" + annedeb + "' and e.ID_ENS='" + id_ens + "' order by ue";

            cmd.CommandText = "select distinct e.code_ue,e.code_ue ||' '||lib_ue as UE  from esp_acquis_ue e inner join ESP_UE u on u.CODE_UE = e.CODE_UE where e.ANNEE_DEB = '" + annedeb + "' and e.ID_ENS = '" + id_ens + "' and e.code_ue not in (select m.code_ue from esp_acquis_module m where m.ANNEE_DEB = '" + annedeb + "' and m.ID_ENS = '" + id_ens + "') order by ue";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }




        public DataTable GetUEBYRESPO(string annedeb)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select code_ue,code_ue ||' '||lib_ue as UE from esp_ue a where a.ANNEE_DEB='" + annedeb + "' and code_ue not in (select code_ue from esp_responsable_module where annee_deb='" + annedeb + "')  order by ue";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public DataTable uee(string annedeb)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select code_ue,code_ue ||' '||lib_ue as lib_ue from esp_ue a where a.ANNEE_DEB='" + annedeb + "' ";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }




        public DataTable ENS()
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select ID_ENS,id_ens||' '||nom_ens as nom from esp_enseignant where etat='A' ";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }



        public DataTable verifexist(string annedeb,string code_ue)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from esp_responsable_module where code_ue='"+code_ue+"' and annee_deb='"+annedeb+"'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public DataTable verifexistAcquis( string code_ue)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from esp_acquis_valid_ens where id_acquis='" + code_ue + "'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }
        public string GetAnnee()
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



        public DataTable GetUeDetails(string annedeb,string CODEue)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select distinct b.code_ue,b.NB_ECTS,b.CHARGE_H from ESP_MODULE_PANIER_CLASSE_SAISO a inner join esp_ue b on a.code_ue=b.code_ue where b.ANNEE_DEB = '"+annedeb+"' and b.code_ue = '"+CODEue+"'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public DataTable GetUeDetailsMODULE(string annedeb, string CODEue)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select distinct a.code_module,b.DESIGNATION,a.COEF from ESP_MODULE_PANIER_CLASSE_SAISO a inner join esp_module b on a.CODE_MODULE=b.CODE_MODULE where a.ANNEE_DEB like '" + annedeb + "' and a.CODE_UE = '" + CODEue + "'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public DataTable GetUeDetailsens()
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select id_ens,id_ens||' '||nom||' '||pnom as nom from esp_enseignant where etat='A' and id_ens not in (select id_ens from esp_responsable_module) order by nom";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public DataTable verifexistue(string codue)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from esp_aCquis_ue where code_ue='" + codue+"'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public string GetLIBUE(string code_ue)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select lib_ue from esp_ue where CODE_UE='"+code_ue+"'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public void EnregRESUE(string code_ue, string id_ens, string annee_deb,string user)
        {


            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();

            cmd.CommandText = "insert into esp_responsable_module (code_module,id_ens,DATE_SAISIE,annee_deb,Etat,ID_USER_MODIF) values('" + code_ue + "','" + id_ens + "',to_date(sysdate,'dd/MM/yyyy'),'" + annee_deb + "','A','"+user+"')";            
            cmd = new OracleCommand(cmd.CommandText, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();


        }


        public void EnregChapterBymodule(string code_module, string num_chap,string title_chapter,string annee_deb,string code_ue,string id_ens,string _HORAIRE_CHAP)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();

            cmd.CommandText = "insert into esp_acquis_module (code_module,num_chapter,titre_chapter,DATE_SAISIE,annee_deb,code_ue,id_ens,HORAIRE_CHAP) values('" + code_module + "','" + num_chap + "','" + title_chapter.Replace("'","''")+ "',to_date(sysdate,'dd/MM/yyyy'),'" + annee_deb + "','"+code_ue+"','"+id_ens+ "','"+ _HORAIRE_CHAP + "')";
            cmd = new OracleCommand(cmd.CommandText, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();


        }

        public void EnregEvalEXAM(string code_module, string annee_deb, string EXPLICATION, string MODE_EVAL, string CALCUL_EXAM, string id_user, string TYPE_EXAM, string QUOTA_TP, string QUOTA_DS, string QUOTA_QCM, string QUOTA_TEST, string typds)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();

            cmd.CommandText = "insert into ESP_EVAL_EXAMEN (code_module,DATE_SAISIE,annee_deb,EXPLICATION,MODE_EVAL,QUOTA_EXAM,id_user,TYPE_EXAM,QUOTA_TP,QUOTA_DS,QUOTA_QCM,QUOTA_TEST,type_ds) values('" + code_module + "',to_date(sysdate,'dd/MM/yyyy'),'" + annee_deb + "','" + EXPLICATION.Replace("'", "''") + "','" + MODE_EVAL + "','" + CALCUL_EXAM + "','" + id_user + "','" + TYPE_EXAM + "','" + QUOTA_TP + "','" + QUOTA_DS + "','" + QUOTA_QCM + "','" + QUOTA_TEST + "','" + typds + "')";
            cmd = new OracleCommand(cmd.CommandText, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();


        }


        public void EnregEval(string code_module, string annee_deb, string EXPLICATION, string MODE_EVAL, string CALCUL_EXAM,string id_user,string TYPE_EXAM)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();

            cmd.CommandText = "insert into ESP_EVAL_EXAMEN (code_module,DATE_SAISIE,annee_deb,EXPLICATION,MODE_EVAL,QUOTA_EXAM,id_user,TYPE_EXAM) values('" + code_module + "',to_date(sysdate,'dd/MM/yyyy'),'" + annee_deb + "','"+EXPLICATION.Replace("'", "''") + "','" + MODE_EVAL + "','" + CALCUL_EXAM + "','" +id_user + "','"+ TYPE_EXAM + "')";
            cmd = new OracleCommand(cmd.CommandText, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();


        }

        //ici

        public void EnregContentChapter(string code_module, string num_chap, string title_chapter, string annee_deb,string code_chapter)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();

            cmd.CommandText = "insert into esp_acquis_chapter (code_module,num_chapter,DESIGNATION,DATE_SAISIE,annee_deb,CODE_CHAPTER) values('" + code_module + "','" + num_chap + "','" + title_chapter + "',to_date(sysdate,'dd/MM/yyyy'),'" + annee_deb + "','" + code_chapter + "')";
            cmd = new OracleCommand(cmd.CommandText, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();


        }


        public void InsertContentCHAPTER(string code_module, string num_chap, string title_chapter, string annee_deb)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();

            cmd.CommandText = "insert into esp_acquis_chapter (CODE_MODULE,NUM_CHAPTER,DESIGNATION,DATE_SAISIE,ANNEE_DEB) values('" + code_module + "','" + num_chap + "','" + title_chapter + "',to_date(sysdate,'dd/MM/yyyy'),'" + annee_deb + "')";
            cmd = new OracleCommand(cmd.CommandText, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();


        }





        public string gETrESPONSABLEue(string code_ue,string an)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

    string cmdQuery = "SELECT NOM ||' '||PNOM as nom from esp_enseignant e inner join esp_responsable_module p on e.ID_ENS=p.ID_ENS where p.CODE_MODULE='" + code_ue + "' and p.annee_deb='"+an+"'";
    OracleCommand myCommand = new OracleCommand(cmdQuery);
    myCommand.Connection = mySqlConnection;
    myCommand.CommandType = CommandType.Text;
    lib = myCommand.ExecuteScalar().ToString();
    mySqlConnection.Close();
       }
     return lib;
        }

        public void EnregAquis(string idens,string num,string code_ue,string aquis,string annee_deb)
        {


            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();

            cmd.CommandText = "insert into ESP_AcQUIS_UE (id_ens,ID_AQUIS,code_ue,DATE_SAISIE,LIBELLE_AQUIS,annee_deb) values('"+idens+"','" + num + "','" + code_ue + "',to_date(sysdate,'dd/MM/yyyy'),'" + aquis.Replace("'", "''") + "','" + annee_deb + "')";
            cmd = new OracleCommand(cmd.CommandText, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();


        }

        //select distinct a.code_module,a.code_module||' '||designation as des from esp_module a inner join ESP_MODULE_PANIER_CLASSE_SAISO s on s.CODE_MODULE=a.CODE_MODULE where s.code_ue='EMALOQ0064';



        public DataTable getDEtailsmodule(string codue, string ann,string rr)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select distinct a.code_module,a.code_module||' '||designation as des from esp_module a inner join ESP_MODULE_PANIER_CLASSE_SAISO s on s.CODE_MODULE=a.CODE_MODULE where s.code_ue='" + codue + "' and a.etat='A' and s.ANNEE_DEB='" + ann + "' and s.code_module not in (select distinct code_module from ESP_EVAL_EXAMEN r where r.ANNEE_DEB = '" + ann + "' )";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public bool VerifExist(string _ann,string _module,string _ens)
        {
            bool exist = false;
            

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_RESPONSABLE_MODULE where ANNEE_DEB='"+_ann+"' and CODE_MODULE='"+_module+"' and ID_ENS='"+_ens+"' and etat='A'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();


                    exist = true;


                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
                return exist;
            }
        }



        public bool Verif(string _ann, string _module)
        {
            bool exist = false;


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_RESPONSABLE_MODULE where ANNEE_DEB='"+_ann+"' and CODE_MODULE='"+_module+"'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();


                    exist = true;


                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
                return exist;
            }
        }




        public DataTable GEtEval(string codmodule, string ann)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select code_module,EXPLICATION,MODE_EVAL,QUOTA_EXAM from ESP_EVAL_EXAMEN a where a.code_module='"+codmodule+"' and a.annee_deb='"+ ann + "'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public DataTable getModule(string ann, string id_ens)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select DISTINCT m.CODE_MODULE ,m.DESIGNATION,m.DESCRIPTION,e.UP,e.NOM, s.ANNEE_DEB  from esp_module  m inner join esp_enseignant e on m.up =e.up inner join ESP_MODULE_PANIER_CLASSE_SAISO s on s.CODE_MODULE=m.CODE_MODULE where e.ID_ENS='" + id_ens + "' and s.ANNEE_DEB='" + ann + "'   ";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public DataTable getModulev0(string ann,string Pid)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            //cmd.CommandText = "select distinct a.code_module,a.code_module||' '||designation as des from esp_module a inner join ESP_ACQUIS_MODULE s on s.CODE_MODULE=a.CODE_MODULE where s.ANNEE_DEB='" + ann + "' and id_ens='"+Pid+ "' and s.code_module not in (select e.code_module from esp_acquis_chapter e where s.ANNEE_DEB='" + ann + "' and id_ens='" + Pid + "')";

            // cmd.CommandText = "select distinct a.code_module,a.code_module||' '||designation as des from esp_module a inner join ESP_ACQUIS_MODULE s on s.CODE_MODULE=a.CODE_MODULE where s.ANNEE_DEB='" + ann + "' and id_ens='" + Pid + "' ";

            cmd.CommandText = "select distinct  code_module,designation_new des from ESP_MODULE_PANIER_CLASSE_SAISO e1 inner join esp_enseignant e2 on e1.ID_ENS=e2.ID_ENS where ANNEE_DEB='" + ann+"' and up='"+Pid+"'";




            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        //select distinct s.code_module,u.CHARGE_H,p.DESIGNANTION,u.LIB_UE,e.NOM_ENS,s.CODE_UE from ESP_MODULE_PANIER_CLASSE_SAISO s inner join esp_module m on m.code_module=s.code_module inner join esp_up p on p.up=m.up inner join esp_ue u on u.code_ue=s.code_ue inner join esp_enseignant e on s.id_ens=e.ID_ENS where s.CODE_MODULE='MS-08' and e.TYPE_UP='O' and s.annee_deb='2015' and code_ue='INFROC0004';

        public DataTable getDEtailsmodbMODULES(string mod)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            //
            cmd.CommandText = "select distinct r.code_module,b.DESIGNATION,e.NOM||' '||e.PNOM Nom,p.DESIGNANTION up,a.CHARGE_P1+a.CHARGE_P2 as CHARGE_H from ESP_MODULE_PANIER_CLASSE_SAISO a  inner join esp_module b on a.code_module=b.code_module inner join esp_responsable_module r on  r.CODE_MODULE=a.code_module inner join esp_enseignant e on e.id_ens=r.id_ens inner join esp_up p on p.up=b.up inner join esp_ue u on u.code_ue=a.code_ue  inner join SOCIETE s on s.ANNEE_DEB=a.ANNEE_DEB inner join SOCIETE s2 on s2.NUM_SEMESTRE_ACTUEL=a.NUM_SEMESTRE  where a.CODE_MODULE='" + mod+ "'  And r.etat='A' and u.CHARGE_H is not null and rownum <= 1";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


//
        public DataTable Getchapteraquis(string annedeb,string code_mod)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            //cmd.CommandText = "select a.NUM_CHAPTER,NUM_CHAPTER||' '||titre_chapter as num from esp_acquis_module a where a.ANNEE_DEB='" + annedeb + "' and code_module ='"+code_mod+ "' and NUM_CHAPTER||' '||titre_chapter not in(select NUM_CHAPTER||' '||titre_chapter as num from ESP_ACQUIS_CHAPTER) order by NUM_CHAPTER";
            cmd.CommandText = "select a.NUM_CHAPTER,titre_chapter,a.HORAIRE_chap  from esp_acquis_module a where a.ANNEE_DEB = '"+annedeb+"' and a.code_module = '"+code_mod+"' and a.NUM_CHAPTER || ' ' || a.CODE_MODULE not in (select NUM_CHAPTER || ' ' || CODE_MODULE from ESP_ACQUIS_CHAPTER where a.ANNEE_DEB = '"+annedeb+"' and a.code_module = '"+code_mod+ "') order by num_chapter";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public string getUP(string code_ue)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT up from esp_enseignant where id_ens='"+code_ue+"' ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }





        public string getRespoUE(string code_ue, string an)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "Select a.id_ens,b.NOM_ENS from esp_responsable_module a inner join ESP_ENSEIGNANT b on a.id_ens=b.id_ens where CODE_UE='"+code_ue+"' and annee_deb='"+an+"' ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public DataTable getInfo_ue_ansBYID(string id_ens)
        {
            DataTable dt = new DataTable();
            //OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            //con.Open();

            ////OracleCommand cmd = new OracleCommand("select emp_code,emp_nom,emp_num_p,emp_prenom,emp_date_p,emp_regsoc_num,EMP_DATE_NAISS,emp_ADRESSE,emp_tel1,EMP_RECRUT_DATE,t.LIB_NOME cat,t.CODE_NOME id_cat,echl_code,EMP_BQ_COMPTE,EMP_SIT_FAM,EMP_ENF_IPOSABLES,DATE_ECHELON,t1.LIB_NOME type_emp ,e.EMP_EMAIL ,EMP_CHEF_FAM,PR_CODE from EMPLOYE e inner join scoesb02.CODE_NOMENCLATURE t on t.CODE_NOME=e.ECH_CODE inner join scoesb02.CODE_NOMENCLATURE t1 on t1.CODE_NOME=e.PR_CODE where  emp_code='" + code_mat + "' and t.CODE_STR='37' and t1.CODE_STR='35'  order by emp_nom", con);

            //OracleDataAdapter od = new OracleDataAdapter(cmd);
            //od.Fill(dt);
            //con.Close();
            return dt;
        }
        //
        public DataTable GetDATAUe(string idens,string cm)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            //cmd.CommandText = "select DISTINCT a.code_module,REPLACE(b.designation, '?', 'e') as lib_module,e.NOM||' '||e.PNOM nom,e.ID_ENS,a.ETAT,e.UP,p.DESIGNANTION lib_up from esp_responsable_module a inner join esp_enseignant e on e.id_ens=a.ID_ENS inner join societe s  on s.annee_deb=a.ANNEE_DEB  inner join esp_module b on b.code_module=a.code_module inner join ESP_UP p on e.up=p.UP where a.id_ens='" + idens + "' and a.code_module='"+cm+"'";
            cmd.CommandText = "select DISTINCT a.code_module,REPLACE(b.designation, '?', 'e') as lib_module,e.NOM||' '||e.PNOM nom,e.ID_ENS,a.ETAT,e.UP,p.DESIGNANTION lib_up from esp_responsable_module a inner join esp_enseignant e on e.id_ens=a.ID_ENS  inner join esp_module b on b.code_module=a.code_module inner join ESP_UP p on e.up=p.UP where a.id_ens='" + idens + "' and a.code_module='" + cm + "'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }
      
        public DataTable GetDATAUe2017(string annedeb, string up)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            //cmd.CommandText = "select distinct a.code_ue,REPLACE(b.lib_ue, '&#233;', 'e') as lib_ue,NOM_ENS,ID_ENS,a.ETAT from esp_responsable_module a inner join esp_ue b on a.code_ue=b.code_ue inner join esp_enseignant e on a.ID_ENS=e.ID_ens where a.annee_deb='" + annedeb + "'";


            cmd.CommandText = " select distinct a.CODE_MODULE,REPLACE(b.designation, '&#233;', 'e') as lib_module,NOM_ENS,ID_ENS, case  a.ETAT when 'A' then 'Chef module' when 'N' then 'Enseignant' end ETAT,a.date_saisie,a.date_modif from esp_responsable_module a inner join esp_module b on a.CODE_MODULE = b.CODE_MODULE inner join esp_enseignant e on a.ID_ENS = e.ID_ens where a.annee_deb = '" + annedeb + "' and a.ID_USER_MODIF='"+up+"' and a.etat='A'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }



        public DataTable GETlISTEns(string up)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            //cmd.CommandText = "select distinct a.code_ue,REPLACE(b.lib_ue, '&#233;', 'e') as lib_ue,NOM_ENS,ID_ENS,a.ETAT from esp_responsable_module a inner join esp_ue b on a.code_ue=b.code_ue inner join esp_enseignant e on a.ID_ENS=e.ID_ens where a.annee_deb='" + annedeb + "'";


            // cmd.CommandText = "select distinct a.ID_ENS,e.nom||' '||e.pnom nom,a.CODE_MODULE,REPLACE(b.designation, '&#233;', 'e') as  designation from esp_responsable_module a inner join esp_module b on a.CODE_MODULE = b.CODE_MODULE inner join esp_enseignant e on a.ID_ENS = e.ID_ens where a.Etat='A' order by designation";
            // and e.id_ens='V-463-12'
            //cmd.CommandText = "select distinct a.ID_ENS,e.nom||' '||e.pnom nom,a.CODE_MODULE,REPLACE(b.designation, '&#233;', 'e') as designation from esp_responsable_module a inner join esp_module b on a.CODE_MODULE = b.CODE_MODULE  inner join esp_enseignant e on a.ID_ENS = e.ID_ens where a.Etat='A'  and  a.ID_USER_MODIF='"+up+"' union select distinct a.ID_ENS,e.nom||' '||e.pnom nom,a.CODE_MODULE,REPLACE(b.designation, '&#233;', 'e') as designation from esp_responsable_module a inner join esp_module b on a.CODE_MODULE = b.CODE_MODULE inner join esp_enseignant e on a.ID_ENS = e.ID_ens where a.Etat='A' order by nom desc";


            // cmd.CommandText = "select distinct a.ID_ENS,e.nom||' '||e.pnom nom,a.CODE_MODULE,REPLACE(b.designation, '&#233;', 'e')  as designation from esp_responsable_module a inner join esp_module b on a.CODE_MODULE = b.CODE_MODULE  inner join esp_enseignant e on a.ID_ENS = e.ID_ens where a.Etat='A'  and  a.ID_USER_MODIF='" + up + "' union select distinct a.ID_ENS,e.nom||' '||e.pnom nom,a.CODE_MODULE,REPLACE(b.designation, '&#233;', 'e') as designation from esp_responsable_module a inner join esp_module b on a.CODE_MODULE = b.CODE_MODULE  inner join esp_enseignant e on a.ID_ENS = e.ID_ens  inner join societe s on s.annee_deb=a.ANNEE_DEB where a.Etat='A' order by nom desc";
            cmd.CommandText = "select distinct a.CODE_MODULE ,c.DESIGNATION, b.NOM_ENS as nom, a.ID_ENS  from ESP_RESPONSABLE_MODULE a inner join ESP_ENSEIGNANT b on a.ID_ENS=b.ID_ENS  inner join ESP_MODULE c on a.CODE_MODULE=c.CODE_MODULE where b.up='" + up + "' and a.ETAT='A' and a.ANNEE_DEB = (select ANNEE_DEB from SOCIETE) and a.etat='A' order by CODE_MODULE";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public DataTable GETlISTEns_all(string up)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;


            
            //cmd.CommandText = "select distinct a.ID_ENS,e.nom||' '||e.pnom nom,a.CODE_MODULE,REPLACE(b.designation, '&#233;', 'e') as designation from esp_responsable_module a inner join esp_module b on a.CODE_MODULE = b.CODE_MODULE  inner join esp_enseignant e on a.ID_ENS = e.ID_ens where a.Etat='A'  and  a.ID_USER_MODIF='"+up+"' union select distinct a.ID_ENS,e.nom||' '||e.pnom nom,a.CODE_MODULE,REPLACE(b.designation, '&#233;', 'e') as designation from esp_responsable_module a inner join esp_module b on a.CODE_MODULE = b.CODE_MODULE inner join esp_enseignant e on a.ID_ENS = e.ID_ens where a.Etat='A' order by nom desc";


            cmd.CommandText = "select distinct a.ID_ENS,e.nom||' '||e.pnom nom,a.CODE_MODULE,REPLACE(b.designation, '&#233;', 'e')  as designation from esp_responsable_module a inner join esp_module b on a.CODE_MODULE = b.CODE_MODULE  inner join esp_enseignant e on a.ID_ENS = e.ID_ens inner join societe s on s.annee_deb=a.ANNEE_DEB where a.Etat='A' and  e.up=:up union select distinct a.ID_ENS,e.nom||' '||e.pnom nom,a.CODE_MODULE,REPLACE(b.designation, '&#233;', 'e') as designation from esp_responsable_module a  inner join esp_module b on a.CODE_MODULE = b.CODE_MODULE  inner join esp_enseignant e on a.ID_ENS = e.ID_ens inner join societe s on s.annee_deb=a.ANNEE_DEB where a.Etat='A' and  e.up=:up  order by nom desc";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public int UpdateCoordinator(string etat, string user,string idens,string ue, string an)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);


            //OracleCommand cmd = new OracleCommand("update esp_responsable_module set id_ens='" + idens + "',DATE_MODIF=to_date(sysdate,'dd/MM/yyyy') where code_module='" + ue+"' and annee_deb='"+an+"'", cn);


            OracleCommand cmd = new OracleCommand("update esp_responsable_module set ETAT='"+etat+ "',DATE_MODIF=to_date(sysdate,'dd/MM/yyyy') ,ID_USER_MODIF='" + user+"',id_ens='"+idens+"' where code_module='" + ue + "' and annee_deb='" + an + "'", cn);

            cn.Open();
            return cmd.ExecuteNonQuery();
        }


        public int UpdateCoordinatorup(string id,string user)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);


            //OracleCommand cmd = new OracleCommand("update esp_responsable_module set id_ens='" + idens + "',DATE_MODIF=to_date(sysdate,'dd/MM/yyyy') where code_module='" + ue+"' and annee_deb='"+an+"'", cn);


            OracleCommand cmd = new OracleCommand("update esp_responsable_module set ETAT='N',DATE_MODIF=to_date(sysdate,'dd/MM/yyyy') ,ID_USER_MODIF='" + user + "' where id_ens='" + id + "'", cn);

            cn.Open();
            return cmd.ExecuteNonQuery();
        }

        //
        public DataTable GetlistOFChapterByModule(string cod_module,string code_cl)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select e.CODE_MODULE,a.NUM_CHAPTER,b.TITRE_CHAPTER,a.DESIGNATION,e.ID_ACQUIS,e.PROG_COURS,e.PROG_COURS_PERCENT from ESP_ACQUIS_VALID_ENS e inner join ESP_ACQUIS_CHAPTER a on e.ID_ACQUIS=a.ID_ACQUIS inner join ESP_ACQUIS_MODULE b on a.NUM_CHAPTER = b.NUM_CHAPTER where e.code_cl='"+code_cl+"' and b.code_module='"+cod_module+"' and lower(e.PROG_COURS) not like '%done%' union select distinct b.CODE_MODULE,a.NUM_CHAPTER,b.TITRE_CHAPTER,a.DESIGNATION,a.ID_ACQUIS,'to_do' PROG_COURS,'0%' PROG_COURS_PERCENT from ESP_ACQUIS_CHAPTER a inner join ESP_ACQUIS_MODULE b on a.code_module = b.code_module  where b.code_module = '"+cod_module+"' and a.NUM_CHAPTEr = b.NUM_CHAPTEr and a.id_acquis not in (select id_acquis from ESP_ACQUIS_VALID_ENS where code_module='"+cod_module+"' )";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public DataTable GetlistOFChapterByModuleFirst(string cod_module)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select distinct b.CODE_MODULE,a.NUM_CHAPTER,b.TITRE_CHAPTER,a.DESIGNATION,a.ID_ACQUIS from ESP_ACQUIS_CHAPTER a inner join ESP_ACQUIS_MODULE b on a.code_module = b.code_module  where b.code_module = '"+cod_module+"' and a.NUM_CHAPTEr = b.NUM_CHAPTEr";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }



        public DataTable getModuleBYEns(string id_ens)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            // cmd.CommandText = "select distinct a.code_module,a.code_module||' '||designation as des from esp_module a inner join ESP_MODULE_PANIER_CLASSE_SAISO s on s.CODE_MODULE = a.CODE_MODULE where s.ANNEE_DEB = '"+ann+"' and id_ens = '"+id_ens+"' and s.NUM_SEMESTRE = '"+semestre+"' ";


            cmd.CommandText = "select distinct a.code_module,a.code_module||' '||designation as des  from esp_module a inner join ESP_MODULE_PANIER_CLASSE_SAISO s on s.CODE_MODULE = a.CODE_MODULE inner join SOCIETE s1 on s1.ANNEE_DEB=s.ANNEE_DEB inner join societe s2 on s2.NUM_SEMESTRE_ACTUEL=s.NUM_SEMESTRE where  id_ens = '"+id_ens+"'";


            //and s.code_module not in (select distinct code_module from ESP_ACQUIS_MODULE r where r.ANNEE_DEB = '" + ann + "' )
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        //ici seance

        public DataTable getseance(string id_ens,string codmod,string codcl)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT TO_DATE(TO_CHAR(sem.datedeb + emploi.codejour - 2) || ' ' || REPLACE(seanc.HEUREDEB, 'H', ''), 'DD-MM-YY HH24:MI') as Endd ,SCOEMPLOI2.classe.codecl FROM SCOEMPLOI2.emploisemaine emploi, SCOEMPLOI2.emploisemens ens, SCOEMPLOI2.empsem_clas classe, SCOEMPLOI2.empsem_module module, SCOEMPLOI2.empsem_salle salle, SCOEMPLOI2.semaine sem, SCOEMPLOI2.seance seanc, SCOEMPLOI2.esp_module espmod, SCOEMPLOI2.journee jour  where emploi.codemploi = ens.codemploi and emploi.codemploi = classe.codemploi and emploi.codemploi = module.codemploi and emploi.codemploi = salle.codemploi and emploi.idsemaine = sem.id and emploi.codeseance like seanc.codeseance and espmod.code_module like module.codemodule and emploi.codejour = jour.codejour  and emploi.actif like '1' and espmod.code_module like '"+codmod+ "%' and classe.CODECL like'"+codcl+"%' order by TO_DATE(TO_CHAR(sem.datedeb + emploi.codejour - 2) || ' ' || REPLACE(seanc.heurefin, 'H', ''), 'DD-MM-YY HH24:MI')";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


      

        public DataTable gemodule(string id_ens,string d1,string code_cl)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
          cmd.CommandText = "SELECT espmod.CODE_MODULE,TO_DATE(TO_CHAR(sem.datedeb + emploi.codejour - 2) || ' ' || REPLACE(seanc.heurefin, 'H', ''), 'DD-MM-YY HH24:MI') as endd, espmod.CODE_MODULE || ' ' || espmod.designation || ' ' || classe.codecl || ' ' || salle.codesalle Title FROM SCOEMPLOI2.emploisemaine emploi, SCOEMPLOI2.emploisemens ens, SCOEMPLOI2.empsem_clas classe, SCOEMPLOI2.empsem_module module, SCOEMPLOI2.empsem_salle salle, SCOEMPLOI2.semaine sem, SCOEMPLOI2.seance seanc, SCOEMPLOI2.esp_module espmod, SCOEMPLOI2.journee jour  where emploi.codemploi = ens.codemploi and emploi.codemploi = classe.codemploi and emploi.codemploi = module.codemploi and emploi.codemploi = salle.codemploi and emploi.idsemaine = sem.id and emploi.codeseance like seanc.codeseance and espmod.code_module like module.codemodule and emploi.codejour = jour.codejour and emploi.actif like '1'    and IDENS = '"+id_ens+"' and TO_DATE(TO_CHAR(sem.datedeb + emploi.codejour - 2) || ' ' || REPLACE(seanc.heurefin, 'H', ''), 'DD-MM-YY HH24:MI') like to_date('"+d1.ToString()+ "', 'dd/MM/yy HH24:MI:SS') and classe.CODECL='"+code_cl+"'";




            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        //  public DataTable getseance(string id_ens,DateTime d1)
     

    public int Updateacquis(string idens,string idacquis)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);

            // OracleCommand cmd = new OracleCommand(" update EMPLOYE set PASSWD=FS_CRYPT_ORACLE('"+mpd+"',HEXTORAW('9CA181F1F7E94D1EADBFC270C8BC53EB')) where EMP_NUM_P='" + id_decidd + "'", cn);

            OracleCommand cmd = new OracleCommand(" update esp_acquis_chapter set ETAT_ACQUIS='A',ID_ENS_MODIF='" + idens + "',DATE_DERNIER_MODIF=to_date(sysdate,'dd/MM/yyyy') where ID_ACQUIS='" + idacquis + "'", cn);

            cn.Open();
            return cmd.ExecuteNonQuery();
        }

        // cmd.CommandText = "SELECT TO_DATE(TO_CHAR(sem.datedeb + emploi.codejour - 2) || ' ' || REPLACE(seanc.heurefin, 'H', ''), 'DD-MM-YY HH24:MI') as Endd ,SCOEMPLOI2.classe.codecl FROM SCOEMPLOI2.emploisemaine emploi, SCOEMPLOI2.emploisemens ens, SCOEMPLOI2.empsem_clas classe, SCOEMPLOI2.empsem_module module, SCOEMPLOI2.empsem_salle salle, SCOEMPLOI2.semaine sem, SCOEMPLOI2.seance seanc, SCOEMPLOI2.esp_module espmod, SCOEMPLOI2.journee jour  where emploi.codemploi = ens.codemploi and emploi.codemploi = classe.codemploi and emploi.codemploi = module.codemploi and emploi.codemploi = salle.codemploi and emploi.idsemaine = sem.id and emploi.codeseance like seanc.codeseance and espmod.code_module like module.codemodule and emploi.codejour = jour.codejour  and emploi.actif like '1' and IDENS = '"+id_ens+"' order by TO_DATE(TO_CHAR(sem.datedeb + emploi.codejour - 2) || ' ' || REPLACE(seanc.heurefin, 'H', ''), 'DD-MM-YY HH24:MI')";
        public string HaveCLfromemploi(string id_ens,DateTime d1,string heure)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT  classe.codecl FROM SCOEMPLOI2.emploisemaine emploi, SCOEMPLOI2.emploisemens ens,  SCOEMPLOI2.empsem_clas classe, SCOEMPLOI2.empsem_module module,SCOEMPLOI2.empsem_salle salle, SCOEMPLOI2.semaine sem, SCOEMPLOI2.seance seanc, SCOEMPLOI2.esp_module espmod, SCOEMPLOI2.journee jour,ESP_ENSEIGNANT ens  where emploi.codemploi = ens.codemploi and emploi.codemploi = classe.codemploi and emploi.codemploi = module.codemploi and emploi.codemploi = salle.codemploi and emploi.idsemaine = sem.id and emploi.codeseance like seanc.codeseance and espmod.code_module like module.codemodule and emploi.codejour = jour.codejour and emploi.actif like '1'    and ens.ID_ENS  = '" + id_ens+ "' and TO_DATE(TO_CHAR(sem.datedeb + emploi.codejour - 2) || ' ' || REPLACE(seanc.HEUREDEB, 'H', ''), 'DD-MM-YY HH24:MI') like to_date('" + d1.ToString()+ "', 'dd/MM/yy HH24:MI:SS') and seanc.HEUREDEB like '" + heure+"%'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }



        public string getCode_CL(string id_et)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select code_cl from ESP_INSCRIPTION  e inner join societe s on s.annee_deb=e.annee_deb  where  id_et='"+id_et+"' and code_cl not in ('---')";
                string cmdQuery = "select code_cl from ESP_INSCRIPTION  e   inner join societe s on s.annee_deb=e.annee_deb where  id_et='" + id_et + "' and code_cl not in ('---')";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public DataTable getModuleByCL(string code_cl)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            //inner join SOCIETE t2 on t2.NUM_SEMESTRE_ACTUEL=e.NUM_SEMESTRE
            cmd.CommandText = "select e.CODE_MODULE,e1.CODE_MODULE ||' '||e1.DESIGNATION  DESIGNATION from ESP_MODULE_PANIER_CLASSE_SAISO e inner join esp_module e1 on e.code_module=e1.code_module inner join SOCIETE t1 on e.ANNEE_DEB=t1.ANNEE_DEB inner join SOCIETE t2 on e.NUM_SEMESTRE=t2.NUM_SEMESTRE_ACTUEL where e.code_cl='" + code_cl+"'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public DataTable GetEns(string codmod,string codcl)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            //inner join societe s1 on s.NUM_SEMESTRE_ACTUEL=e.NUM_SEMESTRE
            cmd.CommandText = "select  e.id_ens,NOM||' '||pnom nom,d.MAIL_ENS mail from esp_enseignant d inner join ESP_MODULE_PANIER_CLASSE_SAISO e  on e.id_ens=d.id_ens inner join societe s on s.ANNEE_DEB=e.ANNEE_DEB  where e.code_module='" + codmod+"' and code_cl='"+codcl+ "' and d.ETAT='A'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public DataTable GetResponsModule(string codmod)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            //inner join societe s on s.ANNEE_DEB = e.ANNEE_DEB
            cmd.CommandText = "select  e.id_ens,NOM||' '||pnom nom ,d.MAIL_ENS mail from esp_enseignant d inner join ESP_RESPONSABLE_MODULE e  on e.id_ens=d.id_ens  where e.code_module='" + codmod+"'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }




        public DataTable GetModuleValidForEtud(string cod_module,string cod_cl,string id_ens)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "select e.CODE_MODULE,m.DESIGNATION,a.DESIGNATION ACQUIS,e.ID_ACQUIS,a.NUM_CHAPTER,b.TITRE_CHAPTER,a.DESIGNATION,e.date_seance from ESP_ACQUIS_VALID_ENS e inner join ESP_ACQUIS_CHAPTER a on e.ID_ACQUIS=a.ID_ACQUIS inner join ESP_ACQUIS_MODULE b on a.NUM_CHAPTER = b.NUM_CHAPTER inner join esp_module m on m.CODE_MODULE=e.CODE_MODULE where e.code_cl='" + cod_cl+"' and b.code_module='"+cod_module+ "' and e.id_ens='"+id_ens+"'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public DataTable GetModuleValidForEtudByseance( string cod_cl, string cod_module, string id_ens, DateTime s)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "select e.CODE_MODULE,m.DESIGNATION,a.DESIGNATION ACQUIS,e.ID_ACQUIS,a.NUM_CHAPTER,b.TITRE_CHAPTER,a.DESIGNATION,e.date_seance from ESP_ACQUIS_VALID_ENS e inner join ESP_ACQUIS_CHAPTER a on e.ID_ACQUIS=a.ID_ACQUIS inner join ESP_ACQUIS_MODULE b on a.NUM_CHAPTER = b.NUM_CHAPTER inner join esp_module m on m.CODE_MODULE=e.CODE_MODULE where e.code_cl='" + cod_cl + "' and b.code_module='" + cod_module + "' and  e.id_ens='"+id_ens+"' and date_seance like to_date('"+s.ToString()+"', 'dd/MM/yy HH24:MI:SS') ";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }




        public DataTable GetBYSeance(string cod_module, string cod_cl,DateTime seance)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "select e.CODE_MODULE,m.DESIGNATION,a.DESIGNATION ACQUIS,e.ID_ACQUIS,a.NUM_CHAPTER,b.TITRE_CHAPTER,a.DESIGNATION,e.date_seance from ESP_ACQUIS_VALID_ENS e inner join ESP_ACQUIS_CHAPTER a on e.ID_ACQUIS=a.ID_ACQUIS inner join ESP_ACQUIS_MODULE b on a.NUM_CHAPTER = b.NUM_CHAPTER inner join esp_module m on m.CODE_MODULE=e.CODE_MODULE where e.code_cl='" + cod_cl + "' and b.code_module='" + cod_module + "'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }




        public void InsertobservEtud(string id_et, string code_module, string annee_deb,string observ,DateTime d1,string titre_chapter,string typ_obsr)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into ESP_OBSERVATIONS_ACQUIS(id_et,code_module,annee_deb,date_saisie,observation,DATE_SEANCE,TITRE_CHAPTER,TYPE_OBSERV) values ('"+id_et+"', '"+code_module+"', '"+annee_deb+"', to_date(sysdate, 'dd/MM/yyyy'), '"+observ+"',to_date('"+d1.ToString()+"', 'dd/MM/yy HH24:MI:SS'), '"+titre_chapter+"', '"+typ_obsr+"') ";
            cmd = new OracleCommand(cmd.CommandText, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }

        //ici insert chapter valid by clss

        public void ValidChapterBYCLS(string id_ens,string code_cl, string code_module, string id_acquis,DateTime d2,string _PROG_COURS,string REMARQUE_ENS,string _PROG_COURS_PERCENT)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into ESP_ACQUIS_VALID_ENS(ID_ENS,CODE_CL,CODE_MODULE,ID_ACQUIS,date_saisie,date_seance,PROG_COURS,REMARQUE_ENS,PROG_COURS_PERCENT)values('" + id_ens + "','" + code_cl + "','" + code_module + "','" + id_acquis + "',to_date(sysdate,'dd/MM/yyyy'),to_date('"+d2.ToString()+ "','DD-MM-YY HH24:MI:SS'),'"+ _PROG_COURS + "','"+ REMARQUE_ENS.Replace("'", "''") + "','"+ _PROG_COURS_PERCENT + "') ";
            cmd = new OracleCommand(cmd.CommandText, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }
        public int UpdateValidChapterBYCLS(string id_ens,  string id_acquis, string _PROG_COURS, string REMARQUE_ENS, string _PROG_COURS_PERCENT)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);

            // OracleCommand cmd = new OracleCommand(" update EMPLOYE set PASSWD=FS_CRYPT_ORACLE('"+mpd+"',HEXTORAW('9CA181F1F7E94D1EADBFC270C8BC53EB')) where EMP_NUM_P='" + id_decidd + "'", cn);

            OracleCommand cmd = new OracleCommand(" update  ESP_ACQUIS_VALID_ENS set PROG_COURS='" + _PROG_COURS + "',REMARQUE_ENS='" + REMARQUE_ENS + "',PROG_COURS_PERCENT='" + _PROG_COURS_PERCENT + "',DATE_MODIF=to_date(sysdate,'dd/MM/yyyy') where id_ens='" + id_ens + "' and ID_ACQUIS='" + id_acquis + "' ", cn);

            cn.Open();
            return cmd.ExecuteNonQuery();
        }
        

        //get cord module

        public DataTable Getcordmodule(string codmod)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select e.id_ens,e1.NOM||' '||e1.PNOM nom,e1.MAIL_ENS,e.CODE_MODULE from ESP_RESPONSABLE_MODULE e inner join esp_enseignant e1 on e.id_ens=e1.id_ens inner join SOCIETE s on s.ANNEE_DEB=e.ANNEE_DEB where code_module='"+codmod+"' and e.etat='A'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        //gestion coordinateur

        public DataTable GetUP()
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select DISTINCT a.UP,a.UP||' '||b.DESIGNANTION lib_up from esp_enseignant a inner join ESP_UP b on a.up = b.up order by a.UP"; 
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }



        public DataTable GetUPBYdept(string iddept)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            //cmd.CommandText = "select DISTINCT a.UP,a.UP||' '||b.DESIGNANTION lib_up from ESP_ENSEIGNANT a inner join ESP_UP b on a.up = b.up inner join esp_dept d on d.CODE_DEPT =a.CODE_DEPT where  b.code_dept='" + iddept+"' order by a.UP";

            cmd.CommandText = "select DISTINCT a.UP,a.UP||' '||b.DESIGNANTION lib_up from ESP_ENSEIGNANT a inner join ESP_UP b on a.up = b.up inner join esp_dept d on d.CODE_DEPT =a.CODE_DEPT where  b.code_dept='" + iddept + "' order by a.UP";


            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }



        public DataTable GetUPBYdeptByens()
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            //cmd.CommandText = "select DISTINCT a.UP,a.UP||' '||b.DESIGNANTION lib_up from ESP_ENSEIGNANT a inner join ESP_UP b on a.up = b.up inner join esp_dept d on d.CODE_DEPT =a.CODE_DEPT where  b.code_dept='" + iddept+"' order by a.UP";

           // cmd.CommandText = "select DISTINCT a.UP,a.UP||' '||b.DESIGNANTION lib_up from ESP_ENSEIGNANT a inner join ESP_UP b on a.up = b.up inner join esp_dept d on d.CODE_DEPT =a.CODE_DEPT where  a.id_ens='" + iddept + "' order by a.UP";

            cmd.CommandText = "select DISTINCT a.UP,a.UP||' '||b.DESIGNANTION lib_up from ESP_ENSEIGNANT a inner join ESP_UP b on a.up = b.up inner join esp_dept d on d.CODE_DEPT =a.CODE_DEPT order by a.UP";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public DataTable GetUPBYdeptByensid(string idens)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            
            cmd.CommandText = "select DISTINCT a.UP,a.UP||' '||b.DESIGNANTION lib_up from ESP_ENSEIGNANT a inner join ESP_UP b on a.up = b.up inner join esp_dept d on d.CODE_DEPT =a.CODE_DEPT where  a.up='" + idens + "' order by a.UP";

            
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }




        //cmd.CommandText = "select  e.id_ens,NOM||' '||pnom nom,d.MAIL_ENS mail from esp_enseignant d inner join ESP_MODULE_PANIER_CLASSE_SAISO e  on e.id_ens=d.id_ens inner join societe s on s.ANNEE_DEB=e.ANNEE_DEB  where e.code_module='" + codmod+"' and code_cl='"+codcl+ "' and d.ETAT='A'";


        public string Get_enss(string codmod,string codcl)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery =  "select e.id_ens,NOM || ' ' || pnom nom,d.MAIL_ENS mail from esp_enseignant d inner join ESP_MODULE_PANIER_CLASSE_SAISO e  on e.id_ens = d.id_ens inner join societe s on s.ANNEE_DEB = e.ANNEE_DEB  where e.code_module = '" + codmod+"' and code_cl = '"+codcl+ "' and d.ETAT = 'A'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }







        public string Get_dept(string id_ens)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select code_dept from ESP_ENSEIGNANT where id_ens='"+id_ens+"'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }




        public DataTable GetCl(string idens, string mod)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            //cmd.CommandText = "select code_cl from ESP_MODULE_PANIER_CLASSE_SAISO a inner join societe s on s.ANNEE_DEB=a.ANNEE_DEB inner join societe s2 on s.NUM_SEMESTRE_ACTUEL=a.NUM_SEMESTRE where  ID_ENS = '"+idens+"' and code_module ='"+mod+"'";

           // cmd.CommandText = " SELECT DISTINCT SCOEMPLOI2.classe.codecl code_cl ,ens.IDENS FROM SCOEMPLOI2.emploisemaine emploi, SCOEMPLOI2.emploisemens ens, SCOEMPLOI2.empsem_clas classe, SCOEMPLOI2.empsem_module module, SCOEMPLOI2.empsem_salle salle, SCOEMPLOI2.semaine sem,SCOEMPLOI2.seance seanc,SCOEMPLOI2.esp_module espmod, SCOEMPLOI2.journee jour ,SCOEMPLOI2.semestre a,SOCIETE w where emploi.codemploi = ens.codemploi and emploi.codemploi = classe.codemploi and emploi.codemploi = module.codemploi and emploi.codemploi = salle.codemploi and emploi.idsemaine = sem.id and emploi.codeseance like seanc.codeseance and espmod.code_module like module.codemodule and emploi.codejour = jour.codejour and emploi.actif like '1' and substr(a.ANNEUNIVERSITAIRE,1,4)=w.annee_deb and ens.IDENS='"+idens+ "' and espmod.code_module ='" + mod + "'";
                //"SELECT DISTINCT SCOEMPLOI2.classe.codecl code_cl FROM SCOEMPLOI2.emploisemaine emploi, SCOEMPLOI2.emploisemens ens, SCOEMPLOI2.empsem_clas classe, SCOEMPLOI2.empsem_module module, SCOEMPLOI2.empsem_salle salle, SCOEMPLOI2.semaine sem,SCOEMPLOI2.seance seanc, SCOEMPLOI2.esp_module espmod, SCOEMPLOI2.journee jour  where emploi.codemploi = ens.codemploi and emploi.codemploi = classe.codemploi and emploi.codemploi = module.codemploi and emploi.codemploi = salle.codemploi and emploi.idsemaine = sem.id and emploi.codeseance like seanc.codeseance and espmod.code_module like module.codemodule and emploi.codejour = jour.codejour  and emploi.actif like '1' and IDENS = '" + idens+"' and espmod.code_module ='"+mod+"'";

            cmd.CommandText = " SELECT DISTINCT SCOEMPLOI2.classe.codecl code_cl ,ens.IDENS FROM SCOEMPLOI2.emploisemaine emploi, SCOEMPLOI2.emploisemens ens, SCOEMPLOI2.empsem_clas classe, SCOEMPLOI2.empsem_module module, SCOEMPLOI2.empsem_salle salle, SCOEMPLOI2.semaine sem,SCOEMPLOI2.seance seanc,SCOEMPLOI2.esp_module espmod, SCOEMPLOI2.journee jour,SOCIETE w where emploi.codemploi = ens.codemploi and emploi.codemploi = classe.codemploi and emploi.codemploi = module.codemploi and emploi.codemploi = salle.codemploi and emploi.idsemaine = sem.id and emploi.codeseance like seanc.codeseance and espmod.code_module like module.codemodule and emploi.codejour = jour.codejour and emploi.actif like '1' and w.annee_deb=(select max(annee_deb) from societe ) and ens.IDENS='" + idens + "' and espmod.code_module ='" + mod + "'";
            
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }
        public DataTable Getmodule(string up)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select distinct a.code_module,a.CODE_MODULE||' '||a.DESIGNATION lib_module from ESP_MODULE a inner join ESP_MODULE_PANIER_CLASSE_SAISO s2 on s2.CODE_MODULE=a.CODE_MODULE inner join SOCIETE c on c.ANNEE_DEB=s2.ANNEE_DEB where upper(up)like '%" + up + "%' and a.ETAT='A' ";// and a.CODE_MODULE not in (select b.code_module from ESP_RESPONSABLE_MODULE b where b.etat='A') ";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public DataTable GetmoduleBy()
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select distinct a.code_module,a.CODE_MODULE||' '||a.DESIGNATION lib_module from ESP_MODULE a where  a.ETAT='A' and a.CODE_MODULE not in (select b.code_module from ESP_RESPONSABLE_MODULE b where b.etat='A') ";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public DataTable Havmod()
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select distinct a.code_module,a.CODE_MODULE||' '||a.DESIGNATION lib_module from ESP_MODULE a where  a.ETAT='A'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }
         public DataTable GetDATAUe(string idens)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "select DISTINCT a.code_module,REPLACE(b.designation, '?', 'e') as lib_module,e.NOM||' '||e.PNOM nom,e.ID_ENS,a.ETAT,e.UP,p.DESIGNANTION lib_up from esp_responsable_module a inner join esp_enseignant e on e.id_ens=a.ID_ENS inner join societe s  on s.annee_deb=a.ANNEE_DEB  inner join esp_module b on b.code_module=a.code_module inner join ESP_UP p on e.up=p.UP where a.id_ens='" + idens + "'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }
             public DataTable HAVens()
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select id_ens,id_ens||' '|| nom||' '||pnom as nom from esp_enseignant where  ETAT='A'  ";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }
             public DataTable Getensansup()
             {
                 DataTable dt = new DataTable();

                 OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
                 con.Open();
                 OracleCommand cmd = new OracleCommand();
                 cmd.Connection = con;
                 // cmd.CommandText = "select id_ens,id_ens||' '|| nom||' '||pnom as nom from esp_enseignant where  upper(up) like '%"+up+ "%' and ETAT='A'  and id_ens not in (select b.id_ens from ESP_RESPONSABLE_MODULE b where b.etat='A')";

                 cmd.CommandText = "select id_ens,id_ens||' '|| nom||' '||pnom as nom from esp_enseignant where  ETAT='A'";


                 OracleDataAdapter od = new OracleDataAdapter(cmd);
                 od.Fill(dt);
                 return dt;
             }

        public DataTable Getens(string up)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
           // cmd.CommandText = "select id_ens,id_ens||' '|| nom||' '||pnom as nom from esp_enseignant where  upper(up) like '%"+up+ "%' and ETAT='A'  and id_ens not in (select b.id_ens from ESP_RESPONSABLE_MODULE b where b.etat='A')";

            cmd.CommandText = "select id_ens,id_ens||' '|| nom||' '||pnom as nom from esp_enseignant where  upper(up) like '%" + up + "%' and ETAT='A'";
            
            
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public string getLIbelModule(string cdmod)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select designation from esp_module where code_module='"+cdmod+"'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }






        public string GetensBymodule(string cl,string modd)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                //inner join societe s1 on s.NUM_SEMESTRE_ACTUEL=a.NUM_SEMESTRE
                string cmdQuery = "select a.id_ens from ESP_MODULE_PANIER_CLASSE_SAISO a inner join societe s on s.annee_deb=a.annee_deb  where a.code_cl='"+cl+"' and a.code_module='"+modd+"'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }




        public string getannee_deb()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                //inner join societe s1 on s.NUM_SEMESTRE_ACTUEL=a.NUM_SEMESTRE
                string cmdQuery = "select annee_deb from societe ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        

        public string getannee_debFin()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                //inner join societe s1 on s.NUM_SEMESTRE_ACTUEL=a.NUM_SEMESTRE
                string cmdQuery = "select  annee_deb||'-'||annee_fin  from societe ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string getcl(string id_et,string ann_deb)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select e.code_cl from esp_inscription e where e.id_et='" + id_et + "' and e.annee_deb='"+ann_deb+"'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //maj saber

        public DataTable Getdatedeb()
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString5);

            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "select datedeb from semaine ";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }
        public DataTable Getdatefin()
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString5);

            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "select datfin from semaine";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public string GetProgress2(string id_acquis, string id_ens, string classe, string Code_Module, string date_seance)
        {
            string prog = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "select b.PROG_COURS from  ESP_ACQUIS_VALID_ENS b  where   b.CODE_MODULE = '" + Code_Module + "' and b.ID_ENS = '" + id_ens + "' and b.CODE_CL = '" + classe + "' and b.ID_ACQUIS = '" + id_acquis + "' and b.DATE_SEANCE = '" + date_seance + "' ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                prog = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return prog;
        }
        public DataTable Getchapteraquis2018(string text, string id_ens)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            //cmd.CommandText = "select a.NUM_CHAPTER,a.TITRE_CHAPTER, a.HORAIRE_CHAP from esp_acquis_module a where ID_ENS='"+ id_ens + "' and a.code_module = '" + text + "' order by NUM_CHAPTER ";
            cmd.CommandText = "select a.NUM_CHAPTER,a.TITRE_CHAPTER, a.HORAIRE_CHAP from esp_acquis_module a,societe s where  a.code_module = '" + text + "' and a.annee_deb=s.annee_deb order by NUM_CHAPTER ";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }
        public DataTable nb_acquis(string id_ens, string code_module, string id_acquis, string classe, string date_seance)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from esp_acquis_valid_ens where ID_ACQUIS='" + id_acquis + "' and  ID_ENS='" + id_ens + "' and  CODE_CL='" + classe + "'  and  DATE_SEANCE='" + date_seance + "' and CODE_MODULE='" + code_module + "' ";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }
        public DataTable GetAssignments(string id_ens, string debut, string fin)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString5);

            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            //cmd.CommandText = "select  TO_DATE((((a.CODEJOUR -2)*1000000) +to_number(to_char(e.DATEDEB, 'ddmmyyyy'))))as jour,b.IDENS,c.CODEMODULE,d.DESIGNATION,a.CODEJOUR,a.CODESEANCE,a.semestre ,f.HEUREDEB,f.HEUREFIN,a.IDSEMAINE,e.DATEDEB,e.DATFIN,a.HORAIREMATIN from emploisemaine a INNER JOIN EMPLOISEMENS b  on (a.codemploi=b.codemploi ) INNER JOIN empsem_module c on( a.codemploi=c.codemploi) INNER JOIN ESP_MODULE d on (c.CODEMODULE=d.CODE_MODULE) INNER join semaine e  on (e.id=a.IDSEMAINE) inner join SEANCE f on (a.CODESEANCE=f.CODESEANCE) where b.IDENS='" + id_ens + "' and e.DATEDEB = to_date('" + debut.ToString() + "', 'dd/MM/yy HH24:MI:SS') and e.DATFIN = to_date('" + fin.ToString() + "', 'dd/MM/yy HH24:MI:SS') ";
            //cmd.CommandText = "select  TO_DATE((((a.CODEJOUR -2)*1000000) +to_number(to_char(e.DATEDEB, 'ddmmyyyy')))) as jour,b.IDENS,g.CODECL,c.CODEMODULE,d.DESIGNATION,a.CODEJOUR,a.CODESEANCE,a.semestre ,f.HEUREDEB,f.HEUREFIN,a.IDSEMAINE,e.DATEDEB,e.DATFIN,a.HORAIREMATIN from emploisemaine a INNER JOIN EMPLOISEMENS b  on (a.codemploi=b.codemploi ) INNER JOIN empsem_module c on( a.codemploi=c.codemploi) INNER JOIN ESP_MODULE d on (c.CODEMODULE=d.CODE_MODULE) INNER join semaine e  on (e.id=a.IDSEMAINE) inner join SEANCE f on (a.CODESEANCE=f.CODESEANCE) inner join EMPSEM_CLAS g on (g.CODEMPLOI=a.CODEMPLOI) where b.IDENS='" + id_ens + "' and e.DATEDEB between to_date('"+ debut.ToString() + "', 'dd/MM/yy HH24:MI:SS') and  to_date('" + fin.ToString() + "', 'dd/MM/yy HH24:MI:SS')  and e.DATFIN  between to_date('"+ debut.ToString() + "', 'dd/MM/yy HH24:MI:SS') and to_date('" + fin.ToString() + "', 'dd/MM/yy HH24:MI:SS') order by jour";
            //cmd.CommandText = "SELECT (a.CODEJOUR - 2+to_number(to_char(e.DATEDEB, 'yyyymmdd')))as Jour,b.IDENS,c.CODEMODULE,d.DESIGNATION,a.CODEJOUR,a.CODESEANCE,a.semestre ,f.HEUREDEB,f.HEUREFIN,a.IDSEMAINE,e.DATEDEB,e.DATFIN,a.HORAIREMATIN from emploisemaine a INNER JOIN EMPLOISEMENS b  on (a.codemploi=b.codemploi ) INNER JOIN empsem_module c on( a.codemploi=c.codemploi) INNER JOIN ESP_MODULE d on (c.CODEMODULE=d.CODE_MODULE) INNER join semaine e  on (e.id=a.IDSEMAINE) inner join SEANCE f on (a.CODESEANCE=f.CODESEANCE) where b.IDENS='" + id_ens + "' and Jour = 20171114  ";
            //cmd.CommandText = "select j.NOMJOUR || ' ' ||TO_DATE(to_number(to_char(e.DATFIN-(7-a.CODEJOUR), 'yyyymmdd')),'yyyymmdd') as jour,b.IDENS,g.CODECL,c.CODEMODULE,d.DESIGNATION,a.CODEJOUR,a.CODESEANCE,a.semestre ,f.HEUREDEB,f.HEUREFIN,a.IDSEMAINE,e.DATEDEB,e.DATFIN,a.HORAIREMATIN from emploisemaine a INNER JOIN EMPLOISEMENS b  on (a.codemploi=b.codemploi ) INNER JOIN empsem_module c on( a.codemploi=c.codemploi) INNER JOIN ESP_MODULE d on (c.CODEMODULE=d.CODE_MODULE) INNER join semaine e  on (e.id=a.IDSEMAINE) inner join SEANCE f on (a.CODESEANCE=f.CODESEANCE) inner join EMPSEM_CLAS g on (g.CODEMPLOI=a.CODEMPLOI) inner join JOURNEE j on(a.CODEJOUR=j.CODEJOUR) where b.IDENS='" + id_ens + "' and e.DATEDEB between to_date('" + debut.ToString() + "', 'dd/MM/yy HH24:MI:SS') and  to_date('" + fin.ToString() + "', 'dd/MM/yy HH24:MI:SS')  and e.DATFIN  between to_date('" + debut.ToString() + "', 'dd/MM/yy HH24:MI:SS') and to_date('" + fin.ToString() + "', 'dd/MM/yy HH24:MI:SS') order by TO_DATE(to_number(to_char(e.DATFIN-(7-a.CODEJOUR), 'yyyymmdd')),'yyyymmdd')";
            cmd.CommandText = "select j.NOMJOUR as jour2 ,TO_DATE(to_number(to_char(e.DATFIN-(7-a.CODEJOUR), 'yyyymmdd')),'yy/mm/dd') as jour,b.IDENS,g.CODECL,c.CODEMODULE,d.DESIGNATION,a.CODEJOUR,a.CODESEANCE,a.semestre ,f.HEUREDEB,f.HEUREFIN,a.IDSEMAINE,e.DATEDEB,e.DATFIN,a.HORAIREMATIN from emploisemaine a INNER JOIN EMPLOISEMENS b  on (a.codemploi=b.codemploi ) INNER JOIN empsem_module c on( a.codemploi=c.codemploi) INNER JOIN ESP_MODULE d on (c.CODEMODULE=d.CODE_MODULE) INNER join semaine e  on (e.id=a.IDSEMAINE) inner join SEANCE f on (a.CODESEANCE=f.CODESEANCE) inner join EMPSEM_CLAS g on (g.CODEMPLOI=a.CODEMPLOI) inner join JOURNEE j on(a.CODEJOUR=j.CODEJOUR) where b.IDENS='" + id_ens + "' and (TO_DATE(to_number(to_char(e.DATFIN-(7-a.CODEJOUR), 'yyyymmdd')),'yyyymmdd') between to_date('" + debut.ToString() + "', 'dd/MM/yy HH24:MI:SS') and  to_date('" + fin.ToString() + "', 'dd/MM/yy HH24:MI:SS')) order by TO_DATE(to_number(to_char(e.DATFIN-(7-a.CODEJOUR), 'yyyymmdd')),'yyyymmdd')";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;

        }
        public string remarque_ens(string id_acquis, string id_ens, string code_module, string classe, string date_seance)
        {
            string remarque = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT REMARQUE_ENS FROM ESP_ACQUIS_VALID_ENS where ID_ACQUIS ='" + id_acquis + "' and ID_ENS='" + id_ens + "' and CODE_MODULE='" + code_module + "' and CODE_CL='" + classe + "' and DATE_SEANCE='" + date_seance + "' ";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                remarque = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return remarque;
        }

        public string GetProgress3(string id_acquis, string id_ens, string classe, string Code_Module, string date_seance)
        {
            string pourcent = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "select b.PROG_COURS_PERCENT from  ESP_ACQUIS_VALID_ENS b  where   b.CODE_MODULE = '" + Code_Module + "' and b.ID_ENS = '" + id_ens + "' and b.CODE_CL = '" + classe + "' and b.ID_ACQUIS = '" + id_acquis + "' and b.DATE_SEANCE = '" + date_seance + "' ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                pourcent = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return pourcent;
        }


        public DataTable Getchapteraquis22(string text1, string v, string text2, string classe, string date_seance)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            //cmd.CommandText = "select a.ID_ACQUIS,a.DESIGNATION , a.DATE_SAISIE ,b.REMARQUE_ENS,b.PROG_COURS,b.PROG_COURS_PERCENT from esp_acquis_CHAPTER a INNER JOIN ESP_ACQUIS_VALID_ENS b on (a.ID_ACQUIS=b.ID_ACQUIS) where a.ANNEE_DEB =  '" + v + "' and a.code_module = '" + text1 + "' and a.num_chapter = '" + text2 + "' order by  DATE_SAISIE ";
            // cmd.CommandText = "select a.ID_ACQUIS,a.DESIGNATION , a.DATE_SAISIE ,b.REMARQUE_ENS,b.PROG_COURS,b.PROG_COURS_PERCENT from esp_acquis_CHAPTER a full outer JOIN ESP_ACQUIS_VALID_ENS b on (a.ID_ACQUIS=b.ID_ACQUIS) where a.ANNEE_DEB =  '" + v + "' and a.code_module = '" + text1 + "' and a.num_chapter = '" + text2 + "' and b.CODE_CL = '" + classe + "' and b.DATE_SEANCE = '" + date_seance + "' order by  DATE_SAISIE ";
            cmd.CommandText = "select a.ID_ACQUIS,a.DESIGNATION , a.DATE_SAISIE  from esp_acquis_CHAPTER a  where a.ANNEE_DEB =  '" + v + "' and a.code_module = '" + text1 + "' and a.num_chapter = '" + text2 + "' order by  DATE_SAISIE ";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public int Updatechapter(string annedeb, string code_mod, string id_ens, string titre2, string heure, string titre, string num)
        {
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);

            OracleCommand cmd = new OracleCommand("update  esp_acquis_module set titre_chapter='" + titre2 + "',DATE_SAISIE=to_date(sysdate,'dd/MM/yyyy'),horaire_chap='" + heure + "'  where ID_ENS='" + id_ens + "' and code_module='" + code_mod + "' and annee_deb='" + annedeb + "' and titre_chapter='" + titre + "'and num_chapter='" + num + "' ", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public string getID_Ens_Chapitre(string selectedValue1, string selectedValue2, string num_chap)
        {
            string id = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "select b.ID_ENS from  ESP_ACQUIS_MODULE b  where   b.CODE_MODULE = '" + selectedValue2 + "'  and b.ANNEE_DEB = '" + selectedValue1 + "' and b.NUM_CHAPTER='" + num_chap + "' ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                id = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return id;
        }
        public DataTable Getchapteraquis2(string annedeb, string code_mod, string num_chap)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;


            cmd.CommandText = "select a.NUM_CHAPTER,a.DESIGNATION , a.DATE_SAISIE from esp_acquis_CHAPTER a where a.ANNEE_DEB =  '" + annedeb + "' and a.code_module = '" + code_mod + "' and a.num_chapter = '" + num_chap + "' order by  DATE_SAISIE ";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }
        public DataTable Addchapter(string annedeb, string code_mod, string id_ens, string titre, string numero, string heure)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;


            cmd.CommandText = "insert into esp_acquis_module (code_module,titre_chapter,DATE_SAISIE,annee_deb,id_ens,num_chapter,horaire_chap) values('" + code_mod + "','" + titre + "',to_date(sysdate,'dd/MM/yyyy'),'" + annedeb + "','" + id_ens + "','" + numero + "','" + heure + "' )";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }
        public DataTable Delete_Acquis(string num_chap, string code_module,string annee_deb)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            //cmd.CommandText = "delete from esp_acquis_module  where  NUM_CHAPTER='" + num_chap + "'and CODE_MODULE='" + code_module + "'";
            cmd.CommandText = "delete from esp_acquis_chapter  where  NUM_CHAPTER='" + num_chap + "' and CODE_MODULE='" + code_module + "' and annee_deb='"+annee_deb+"'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public DataTable Delete_Acquis_only_1(string num_chap, string module, string designation,string ann)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "delete from esp_acquis_chapter  where  NUM_CHAPTER='" + num_chap + "' and CODE_MODULE='" + module + "' and designation='" + designation + "' and annee_deb='"+ann+"'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public DataTable Delete_Chapter_Acquis(string id_ens, string num_chap, string titre, string code_module, string annee)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from esp_acquis_module  where ID_ENS='" + id_ens + "' and NUM_CHAPTER='" + num_chap + "'and  CODE_MODULE='" + code_module + "' and ANNEE_DEB ='" + annee + "'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public void Insert_Chapter_Acquis(string annee_deb, string code_module, string designation, string num_chap)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();

            cmd.CommandText = "insert into esp_acquis_chapter (ANNEE_DEB,CODE_MODULE,DESIGNATION,CODE_CHAPTER,NUM_CHAPTER,ETAT_ACQUIS,DATE_SAISIE) values('" + annee_deb + "','" + code_module + "','" + designation + "','x','" + num_chap + "','O',To_Date(To_Char(Sysdate, 'MM/DD/YYYY HH24:MI:SS'), 'MM/DD/YYYY HH24:MI:SS'))";
            cmd = new OracleCommand(cmd.CommandText, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }




        //public DataTable Getchapteraquis2018(string text, string id_ens)
        //{
        //    DataTable dt = new DataTable();

        //    OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
        //    con.Open();
        //    OracleCommand cmd = new OracleCommand();
        //    cmd.Connection = con;

        //    //cmd.CommandText = "select a.NUM_CHAPTER,a.TITRE_CHAPTER, a.HORAIRE_CHAP from esp_acquis_module a where ID_ENS='"+ id_ens + "' and a.code_module = '" + text + "' order by NUM_CHAPTER ";
        //    cmd.CommandText = "select a.NUM_CHAPTER,a.TITRE_CHAPTER, a.HORAIRE_CHAP from esp_acquis_module a where  a.code_module = '" + text + "' order by NUM_CHAPTER ";

        //    OracleDataAdapter od = new OracleDataAdapter(cmd);
        //    od.Fill(dt);
        //    return dt;
        //}

        public DataTable remarque(string id_ens, string code_module, string id_acquis, string classe, string remarque, string date_seance, string PROG_COURS, string pourcentage, string jour2)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;


            cmd.CommandText = "insert into ESP_ACQUIS_VALID_ENS (ID_ENS,CODE_MODULE,DATE_SAISIE,ID_ACQUIS,CODE_CL,REMARQUE_ENS,DATE_SEANCE,PROG_COURS,PROG_COURS_PERCENT,JOUR) values('" + id_ens + "','" + code_module + "',to_date(sysdate,'dd/MM/yyyy'),'" + id_acquis + "','" + classe + "','" + remarque + "','" + date_seance + "','" + PROG_COURS + "','" + pourcentage + "','" + jour2 + "' )";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }
        public int remarque_update(string id_ens, string code_module, string id_acquis, string classe, string remarque, string date_seance, string PROG_COURS, string pourcentage)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);

            OracleCommand cmd = new OracleCommand("  UPDATE ESP_ACQUIS_VALID_ENS set DATE_MODIF=to_date(sysdate,'dd/MM/yyyy'),REMARQUE_ENS='" + remarque + "',PROG_COURS='" + PROG_COURS + "',PROG_COURS_PERCENT='" + pourcentage + "'  where CODE_CL='" + classe + "' and id_ens='" + id_ens + "' and DATE_SEANCE='" + date_seance + "' and ID_ACQUIS='" + id_acquis + "'", cn);

            cn.Open();
            return cmd.ExecuteNonQuery();
        }






        //mise a  jour saber 08/02/2019
        public DataTable FindEval(string selectedValue1, string selectedValue2, string id_ens)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from ESP_EVAL_EXAMEN where CODE_MODULE='" + selectedValue2 + "' and  ID_USER='" + id_ens + "' and  ANNEE_DEB='" + selectedValue1 + "'  ";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public int UpdateEvalEXAM(string selectedValue1, string an, string v, string hgd, string selectedValue2, string id_ens, string selectedValue3, string text1, string text2, string text3, string text4, string selectedValue4)
        {
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);

            OracleCommand cmd = new OracleCommand("update  ESP_EVAL_EXAMEN set code_module='" + selectedValue1 + "',DATE_SAISIE=to_date(sysdate,'dd/MM/yyyy'),annee_deb='" + an + "' ,EXPLICATION='" + v + "',MODE_EVAL='" + hgd + "',QUOTA_EXAM='" + selectedValue2 + "',id_user='" + id_ens + "',TYPE_EXAM='" + selectedValue3 + "',QUOTA_TP='" + text1 + "',QUOTA_DS='" + text2 + "',QUOTA_QCM='" + text3 + "',QUOTA_TEST='" + text4 + "',type_ds='" + selectedValue4 + "'         where ID_USER='" + id_ens + "' and CODE_MODULE='" + selectedValue1 + "' and ANNEE_DEB='" + an + "'  ", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataTable getModuleResponsable(string id_ens, string selectedValue)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            //cmd.CommandText = "select distinct a.CODE_MODULE,a.ID_ENS,e.NOM_ENS from ESP_RESPONSABLE_MODULE a  inner join ESP_ENSEIGNANT e on a.ID_ENS=e.ID_ENS where a.ID_USER_MODIF='"+ id_ens + "' and a.ANNEE_DEB='"+ selectedValue + "'";
            cmd.CommandText = "select distinct a.CODE_MODULE, a.CODE_MODULE || ' ' || b.DESIGNATION as m,a.ID_ENS,e.NOM_ENS from ESP_RESPONSABLE_MODULE a  inner join ESP_ENSEIGNANT e on a.ID_ENS = e.ID_ENS inner join ESP_MODULE b on b.code_module = a.code_module where a.ID_USER_MODIF = '" + id_ens + "' and a.ANNEE_DEB = '" + selectedValue + "'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public DataTable GetDetailsModule(string mod, string ann, string id)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select distinct a.CODE_MODULE,b.DESIGNATION as m,e.NOM_ENS as responsable  from ESP_RESPONSABLE_MODULE a  inner join ESP_ENSEIGNANT e on a.ID_ENS=e.ID_ENS inner join ESP_MODULE b on b.code_module=a.code_module inner join ESP_MODULE_PANIER_CLASSE_SAISO c on c.CODE_MODULE=a.CODE_MODULE where a.ID_USER_MODIF='" + id + "' and a.ANNEE_DEB='" + ann + "' and c.ANNEE_DEB='" + ann + "' and a.code_module='" + mod + "' order by a.CODE_MODULE";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }
        public DataTable Delete_Eval(string selectedValue1, string selectedValue2)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "delete from ESP_EVAL_EXAMEN  where  CODE_MODULE='" + selectedValue1 + "' and ANNEE_DEB='" + selectedValue2 + "'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }




        //novelle version 27092019


        
        public DataTable Listmodules(string id_ens, string an)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select  distinct a.CODE_MODULE,  a.CODE_MODULE || ' ' || b.DESIGNATION as m from ESP_MODULE_PANIER_CLASSE_SAISO a inner join ESP_MODULE b on a.CODE_MODULE=b.CODE_MODULE inner join ESP_ENSEIGNANT c on c.UP=b.UP where a.ANNEE_DEB='" + an + "' and c.ID_ENS='" + id_ens + "' ";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public DataTable module_sans_responsable(string id_ens, string an)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select  distinct a.CODE_MODULE,  a.CODE_MODULE || ' ' || b.DESIGNATION as m from ESP_MODULE_PANIER_CLASSE_SAISO a inner join ESP_MODULE b on a.CODE_MODULE=b.CODE_MODULE inner join ESP_ENSEIGNANT c on c.UP=b.UP where a.ANNEE_DEB='" + an + "' and c.ID_ENS='" + id_ens + "' and  a.CODE_MODULE not in (select distinct CODE_MODULE   from ESP_RESPONSABLE_MODULE where ESP_RESPONSABLE_MODULE.ANNEE_DEB='" + an + "' and ESP_RESPONSABLE_MODULE.ETAT='A')  ";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public DataTable ListResponsable(string id_ens)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select distinct a.CODE_MODULE ,c.DESIGNATION, b.NOM_ENS as nom, a.ID_ENS  from ESP_RESPONSABLE_MODULE a inner join ESP_ENSEIGNANT b on a.ID_ENS=b.ID_ENS  inner join ESP_MODULE c on a.CODE_MODULE=c.CODE_MODULE where b.up='" + id_ens + "' and a.ETAT='A' and a.ANNEE_DEB = (select ANNEE_DEB from SOCIETE) order by CODE_MODULE";


            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public DataTable ListEnseignantUP(string id_ens)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select ID_ENS, ID_ENS  || ' ' || NOM_ENS as e from ESP_ENSEIGNANT where etat='A' and UP=(select UP from ESP_ENSEIGNANT where ID_ENS='" + id_ens + "') order by NOM_ENS";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public int desactiver(string idens, string code_module, string id)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("update esp_responsable_module set ETAT='N',DATE_MODIF=to_date(sysdate,'dd/MM/yyyy') ,ID_USER_MODIF='" + id + "' where code_module='" + code_module + "' and annee_deb=(select annee_deb from SOCIETE ) and ID_USER_MODIF='" + id + "' ", cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }

        public void EnregistrerModification(string code_module, string id_ens, string annee_deb, string user)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into esp_responsable_module (code_module,id_ens,DATE_SAISIE,annee_deb,Etat,ID_USER_MODIF) values('" + code_module + "','" + id_ens + "',to_date(sysdate,'dd/MM/yyyy'),'" + annee_deb + "','A','" + user + "')";
            cmd = new OracleCommand(cmd.CommandText, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }

        public void EnregistrerAffectation(string code_module, string id_responsable, string annee_deb, string id_ens)
        {
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into esp_responsable_module (code_module,id_ens,DATE_SAISIE,annee_deb,Etat,ID_USER_MODIF) values('" + code_module + "','" + id_responsable + "',to_date(sysdate,'dd/MM/yyyy'),'" + annee_deb + "','A','" + id_ens + "')";
            cmd = new OracleCommand(cmd.CommandText, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
}
