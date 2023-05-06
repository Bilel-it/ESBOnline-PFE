using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using Oracle.ManagedDataAccess.Types;
using System.Collections;
using admiss;
namespace DAL
{
    public class EncadrementDAO
    {
        #region Singleton

        
        OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString);
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
        private string _DESIGNATION;

        public string DESIGNATION
        {
            get { return _DESIGNATION; }
            set { _DESIGNATION = value; }
        }
        private string _CODE_NOME;

        public string CODE_NOME
        {
            get { return _CODE_NOME; }
            set { _CODE_NOME = value; }
        }
        private string _LIB_NOME;

        public string LIB_NOME
        {
            get { return _LIB_NOME; }
            set { _LIB_NOME = value; }
        }
        private string _CODE_STR;

        public string CODE_STR
        {
            get { return _CODE_STR; }
            set { _CODE_STR = value; }
        }
        private string _ID_PROJET;

        public string ID_PROJET
        {
            get { return _ID_PROJET; }
            set { _ID_PROJET = value; }

        }
        private string _NOM_PROJET;





        public string NOM_PROJET
        {
            get { return _NOM_PROJET; }
            set { _NOM_PROJET = value; }

        }
        private string _DESCRIPTION_PROJET;
        public string DESCRIPTION_PROJET
        {
            get { return _DESCRIPTION_PROJET; }
            set { _DESCRIPTION_PROJET = value; }

        }
        private string _METHODOLOGIE;
        public string METHODOLOGIE
        {
            get { return _METHODOLOGIE; }
            set { _METHODOLOGIE = value; }

        }

        private string _TECHNOLOGIES;
        public string TECHNOLOGIES
        {
            get { return _TECHNOLOGIES; }
            set { _TECHNOLOGIES = value; }

        }
        private string _TITRE;
        public string TITRE
        {
            get { return _TITRE; }
            set { _TITRE = value; }

        }
        private string _DESI;
        public string DESI
        {
            get { return _DESI; }
            set { _DESI = value; }

        }
        private string _CODE_MODULE;

        public string CODE_MODULE
        {
            get { return _CODE_MODULE; }
            set { _CODE_MODULE = value; }
        }
        private decimal _DUREE;
        public decimal DUREE
        {
            get { return DUREE; }
            set { _DUREE = value; }
        }
        private string _TYPE_PROJET;
        public string TYPE_PROJET
        {
            get { return _TYPE_PROJET; }
            set { _TYPE_PROJET = value; }

        }
        private string _TYPE_PROJET2;
        public string TYPE_PROJET2
        {
            get { return _TYPE_PROJET2; }
            set { _TYPE_PROJET2 = value; }

        }
        static EncadrementDAO instance;
        static Object locker = new Object();
        private OracleDataReader myReader;

        public static EncadrementDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new EncadrementDAO();
                    }

                    return EncadrementDAO.instance;
                }
            }

        }
        private EncadrementDAO()
        {

        }
         
        public EncadrementDAO(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_MODULE")))
            {
                _CODE_MODULE = myReader.GetString(myReader.GetOrdinal("CODE_MODULE"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("DESIGNATION")))
            {
                _DESIGNATION = myReader.GetString(myReader.GetOrdinal("DESIGNATION"));

            }
             
            //if (!myReader.IsDBNull(myReader.GetOrdinal("ID_PROJET")))
            //{
            //    _ID_PROJET = myReader.GetString(myReader.GetOrdinal("ID_PROJET"));

            //}
            //if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_PROJET")))
            //{
            //    _NOM_PROJET = myReader.GetString(myReader.GetOrdinal("NOM_PROJET"));
            //}

            //if (!myReader.IsDBNull(myReader.GetOrdinal("TITRE")))
            //{

            //    _TITRE = myReader.GetString(myReader.GetOrdinal("TITRE"));
            //}
            //if (!myReader.IsDBNull(myReader.GetOrdinal("METHODOLOGIE")))
            //{

            //    _METHODOLOGIE = myReader.GetString(myReader.GetOrdinal("METHODOLOGIE"));
            //}
            //if (!myReader.IsDBNull(myReader.GetOrdinal("DUREE")))
            //{

            //    _DUREE = myReader.GetDecimal(myReader.GetOrdinal("DUREE"));
            //}
            //if (!myReader.IsDBNull(myReader.GetOrdinal("TECHNOLOGIES")))
            //{

            //    _TECHNOLOGIES = myReader.GetString(myReader.GetOrdinal("TECHNOLOGIES"));
            //}
            //if (!myReader.IsDBNull(myReader.GetOrdinal("DESCRIPTION_PROJET")))
            //{

            //    _DESCRIPTION_PROJET = myReader.GetString(myReader.GetOrdinal("DESCRIPTION_PROJET"));
            //}

            //if (!myReader.IsDBNull(myReader.GetOrdinal("DESI")))
            //{

            //    _DESI = myReader.GetString(myReader.GetOrdinal("DESI"));
            //}

            //if (!myReader.IsDBNull(myReader.GetOrdinal("TYPE_PROJET")))
            //{

            //    _TYPE_PROJET = myReader.GetString(myReader.GetOrdinal("TYPE_PROJET"));
            //}

            //if (!myReader.IsDBNull(myReader.GetOrdinal("TYPE_PROJET2")))
            //{

            //    _TYPE_PROJET2 = myReader.GetString(myReader.GetOrdinal("TYPE_PROJET2"));
            //}
        }
        #endregion
       public DataTable listeprojetudiant(string ID_PROJET)
        {
            
 
                 openconntrans();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand(" select NOM_ET||' '||PNOM_ET as NOM, e1.id_projet,e1.id_et,e2.classe_courante_et, e1.date_saisie from esp_projet_etudiant e1,esp_etudiant e2 where id_projet='" + ID_PROJET + "' and e1.id_et=e2.id_et and etat='A' ", mySqlConnection);
            DataTable myDataTable = new DataTable();


            try
            {
                adapter.Fill(myDataTable);

            }
            finally
            {
                mySqlConnection.Close();
            }

            return myDataTable;

        }
               public DataTable listeprojens2(string id_ens)
        {
            
 
                 openconntrans();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand("select e2.NOM_PROJET as TITRE,e2.ID_PROJET,e2.NOM_PROJET,e2.*,"
       + " e2.DESCRIPTION_PROJET,e2.duree,(SELECT code_module FROM ESP_MODULE where e2.code_module=code_module ) as DESI," +
      "  (SELECT CODE_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '64') and  code_nome=e2.METHODOLOGIE)as METHODOLOGIE ,"
       + " (SELECT CODE_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '65') and  code_nome=e2.Technologies)as TECHNOLOGIES ," +
        " (SELECT CODE_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '79') and code_nome=e2.type_projet) as TYPE_PROJET," +
        " (SELECT LIB_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '79') and code_nome=e2.type_projet) as TYPE_PROJET2" +
      "  from  esp_projet_n e2 where   (e2.ID_ENS='" + id_ens + "') ", mySqlConnection);
            DataTable myDataTable = new DataTable();


            try
            {
                adapter.Fill(myDataTable);

            }
            finally
            {
                mySqlConnection.Close();
            }

            return myDataTable;

        }

        public string TYPEENS(string id_ens)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT TYPE_ens from esp_enseignant  where id_ens='" + id_ens + "' ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }
        public List<EncadrementDAO> Listmodule()
        {
            List<EncadrementDAO> myList = null;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "select * from esp_module order by designation ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<EncadrementDAO>();
                        while (myReader.Read())
                        {
                            myList.Add(new EncadrementDAO(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;
        }
        public DataTable listeetudiant()
        {

            openconntrans();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand(" select NOM_ET||' '||PNOM_ET || ' '||e2.ID_ET ||'  '|| e1.code_cl as NOM, e2.ID_ET as ID_ET from esp_inscription e1,esp_etudiant e2 where  annee_deb=2014 AND e2.id_et=e1.id_et and e2.etat='A'", mySqlConnection);
            DataTable myDataTable = new DataTable();


            try
            {
                adapter.Fill(myDataTable);

            }
            finally
            {
                mySqlConnection.Close();
            }

            return myDataTable;
        }

        //public List<ESP_MODULE> Listmodule()
        //{
        //    Entities ec = new Entities();
        //    {
        //        var req = (from mod in ec.ESP_MODULE select mod).OrderBy(mod => mod.DESIGNATION).ToList();
        //        return req;

        //    }
        //}
        public DataTable Listtypeprojet()
        {
           
             using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
             {

                 mySqlConnection.Open();

                 OracleDataAdapter adapter = new OracleDataAdapter();
                
                 adapter.SelectCommand = new OracleCommand("select * from CODE_NOMENCLATURE where code_str='79' Order by lib_nome", mySqlConnection);
                 DataTable myDataTable = new DataTable();


                 try
                 {
                     adapter.Fill(myDataTable);

                 }
                 finally
                 {
                     mySqlConnection.Close();
                 }

                 return myDataTable;
             }
         }
        //public List<CODE_NOMENCLATURE> Listtypeprojet()
        //{
        //    using (Entities ctx = new Entities())
        //    {
        //        var req = (from typ in ctx.CODE_NOMENCLATURE
        //                   where typ.CODE_STR.Equals("79")
        //                   select typ).OrderBy(typ => typ.LIB_NOME).ToList();
        //        return req;
               
        //    }
        //}
       
        //public List<CODE_NOMENCLATURE> Listtech()
        //{
        //    using (Entities ctx = new Entities())
        //    {
        //        var req = (from typ in ctx.CODE_NOMENCLATURE
        //                   where typ.CODE_STR.Equals("65")
        //                   select typ).OrderBy(typ => typ.LIB_NOME).ToList();
        //        return req;

        //    }
        //}

        public DataTable Listtech()
        {

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                OracleDataAdapter adapter = new OracleDataAdapter();

                adapter.SelectCommand = new OracleCommand("select * from CODE_NOMENCLATURE where code_str='65' Order by lib_nome", mySqlConnection);
                DataTable myDataTable = new DataTable();


                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }

                return myDataTable;
            }
        }
        //public List<CODE_NOMENCLATURE> Listmethodo()
        //{
        //    using (Entities ctx = new Entities())
        //    {
        //        var req = (from typ in ctx.CODE_NOMENCLATURE
        //                   where typ.CODE_STR.Equals("64")
        //                   select typ).OrderBy(typ => typ.LIB_NOME).ToList();
        //        return req;

        //    }
        //}
        public string getClasse(string id_et)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))

            {
                mySqlConnection.Open();

                string cmdQuery = "select ( case when CLASSE_COURANTE_ET is null then '1' else CLASSE_COURANTE_ET end )CLASSE_COURANTE_ET from esp_etudiant where etat='A' and pwd_et is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }
        public string CHEFDEPT(string id_ens)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT CHEF_DEPT from esp_enseignant  where id_ens='" + id_ens + "' ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }
        public string getDEPT(string code_dept)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT LIBELLE_DEPT FROM ESP_DEPT where code_dept='" + code_dept + "' ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }
        public DataTable Listmethodo()
        {

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                OracleDataAdapter adapter = new OracleDataAdapter();

                adapter.SelectCommand = new OracleCommand("select * from CODE_NOMENCLATURE where code_str='64' Order by lib_nome", mySqlConnection);
                DataTable myDataTable = new DataTable();


                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }

                return myDataTable;
            }
        }
        public decimal inc_id_projet()
        {
            decimal x = 0;
            OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString);
            mySqlConnection.Open();
            string cmdQuery = "SELECT COUNT(*) AS NB FROM ESP_PROJET_N";

            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            using (OracleDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.HasRows)
                {
                    x = myReader.GetDecimal(myReader.GetOrdinal("NB"));
                }


                return x;
               
            }
            closeConnection();
           
        }
        public ArrayList ListMois()
        {

            ArrayList ListMois = new ArrayList(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            return ListMois;

        }
        public bool Save_projet(string _ANNEE_DEB1, string _ID_PROJET1, string _NOM_PROJET1, string _CODE_MODULE1, string _TYPE_PROJET1, string _DESCRIPTION_PROJET1, string _TECHNOLOGIES1, string _METHODOLOGIE1, decimal _DUREE1, decimal _SEMESTRE1, decimal _PERIODE1, OracleDate _DATE_SAISIE1, string _ID_ENS1)
        {
            bool result = false;
            openconntrans();
            cmdQuery = "INSERT INTO ESP_PROJET_N  ( ANNEE_DEB, ID_PROJET, NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, DUREE, SEMESTRE, PERIODE,DATE_SAISIE,ID_ENS)  VALUES   ( :ANNEE_DEB1, :ID_PROJET1, :NOM_PROJET1, :CODE_MODULE1, :TYPE_PROJET1, :DESCRIPTION_PROJET1, :TECHNOLOGIES1, :METHODOLOGIE1,:DUREE1,:SEMESTRE1, :PERIODE1,:DATE_SAISIE1,:ID_ENS1) ";
            //cmdQuery = "INSERT INTO ESP_PROJET_N  ( ANNEE_DEB, ID_PROJET, NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, DUREE, SEMESTRE, PERIODE,DATE_SAISIE,ID_ENS)  VALUES   ( '2014', 'PROJ9','vv','Ap-12', '01', 'ttt','12', '01', null, null,null,'31-OCT-14','P-399-11') ";
            OracleCommand myCommand = new OracleCommand(cmdQuery);

            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;
            //ANNEE_DEB, 
            OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB1", OracleDbType.Varchar2);
            prmANNEE_DEB.Value = _ANNEE_DEB1;
            myCommand.Parameters.Add(prmANNEE_DEB);
            //ID_PROJET
            OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET1", OracleDbType.Varchar2);
            prmID_PROJET.Value = _ID_PROJET1;
            myCommand.Parameters.Add(prmID_PROJET);
            //NOM_PROJET 

            OracleParameter prmNOM_PROJET = new OracleParameter(":NOM_PROJET1", OracleDbType.Varchar2);
            prmNOM_PROJET.Value = _NOM_PROJET1;
            myCommand.Parameters.Add(prmNOM_PROJET);
            //CODE_MODULE,
            OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE1", OracleDbType.Varchar2);
            prmCODE_MODULE.Value = _CODE_MODULE1;
            myCommand.Parameters.Add(prmCODE_MODULE);
            //TYPE_PROJET

            OracleParameter prmTYPE_PROJET = new OracleParameter(":TYPE_PROJET1", OracleDbType.Varchar2);
            prmTYPE_PROJET.Value = _TYPE_PROJET1;
            myCommand.Parameters.Add(prmTYPE_PROJET);
            //_DESCRIPTION_PROJET

            OracleParameter prmDESCRIPTION_PROJET = new OracleParameter(":DESCRIPTION_PROJET1", OracleDbType.Varchar2);
            prmDESCRIPTION_PROJET.Value = _DESCRIPTION_PROJET1;
            myCommand.Parameters.Add(prmDESCRIPTION_PROJET);
            //_TECHNOLOGIES
            OracleParameter prmTECHNOLOGIES = new OracleParameter(":TECHNOLOGIES1", OracleDbType.Varchar2);
            prmTECHNOLOGIES.Value = _TECHNOLOGIES1;
            myCommand.Parameters.Add(prmTECHNOLOGIES);
            //_METHODOLOGIE

            OracleParameter prmMETHODOLOGIE = new OracleParameter(":METHODOLOGIE1", OracleDbType.Varchar2);
            prmMETHODOLOGIE.Value = _METHODOLOGIE1;
            myCommand.Parameters.Add(prmMETHODOLOGIE);
            //_DUREE

            OracleParameter prmDUREE = new OracleParameter(":DUREE1", OracleDbType.Decimal);
            prmDUREE.Value = _DUREE1;
            myCommand.Parameters.Add(prmDUREE);
            //SEMESTRE

            OracleParameter prmSEMESTRE = new OracleParameter(":SEMESTRE1", OracleDbType.Decimal);
            prmSEMESTRE.Value = _SEMESTRE1;
            myCommand.Parameters.Add(prmSEMESTRE);
            //PERIODE

            OracleParameter prmPERIODE = new OracleParameter(":PERIODE1", OracleDbType.Decimal);
            prmPERIODE.Value = _PERIODE1;
            myCommand.Parameters.Add(prmPERIODE);
            // _DATE_SEANCE

            OracleParameter prmDATE_SAISIE = new OracleParameter(":DATE_SAISIE1", OracleDbType.Date);
            prmDATE_SAISIE.Value = _DATE_SAISIE1;
            myCommand.Parameters.Add(prmDATE_SAISIE);
            //ID_ENS
            OracleParameter prmID_ENS = new OracleParameter(":ID_ENS1", OracleDbType.Varchar2);
            prmID_ENS.Value = _ID_ENS1;
            myCommand.Parameters.Add(prmID_ENS);






            // myCommand.ExecuteNonQuery();
            try
            {
                myCommand.ExecuteNonQuery();
                //myCommandnote.ExecuteNonQuery();
                myTrans.Commit();
                result = true;
            }
            catch (Exception)
            {
                myTrans.Rollback();
                mySqlConnection.Close();
                throw;
            }

            //bool result = myCommand.ExecuteNonQuery() > 0;
            mySqlConnection.Close();

            return result;
        }
        public string getanneedeb()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT ANNEE_DEB FROM SOCIETE  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;

        }
        //public string getanneedeb()
        //{
        //    using (Entities ctx = new Entities())
        //    {
        //        var req = (from ad in ctx.SOCIETEs
        //                   select ad.ANNEE_DEB).FirstOrDefault();
        //        return req.ToString();
        //    }
        //}
        public bool update_projet(string _ANNEE_DEB, string _ID_PROJET, string _NOM_PROJET, string _CODE_MODULE, string _TYPE_PROJET, string _DESCRIPTION_PROJET, string _TECHNOLOGIES, string _METHODOLOGIE, decimal _DUREE, decimal _SEMESTRE, decimal _PERIODE, string _ID_ENS)
        {

            bool result = false;
            openconntrans();
            string cmdQuery = "UPDATE ESP_PROJET_N SET ANNEE_DEB=:ANNEE_DEB, NOM_PROJET=: NOM_PROJET, CODE_MODULE=:CODE_MODULE, TYPE_PROJET=:TYPE_PROJET, DESCRIPTION_PROJET=:DESCRIPTION_PROJET, TECHNOLOGIES=:TECHNOLOGIES, METHODOLOGIE=:METHODOLOGIE, DUREE=:DUREE, SEMESTRE=:SEMESTRE, PERIODE=:PERIODE ,ID_ENS=:ID_ENS WHERE ID_PROJET='" + _ID_PROJET + "'";
            /* "UPDATE ESP_PROJET SET ID_PROJET=:ID_PROJET , NOM_PROJET=:NOM_PROJET , CODE_MODULE=:CODE_MODULE , TYPE_PROJET=:TYPE_PROJET"
             + "DESCRIPTION_PROJET=:DESCRIPTION_PROJET , DUREE_EN_MOIS=:DUREE_EN_MOIS , SEMESTRE_PROJET=:SEMESTRE_PROJET , PERIODE_PROJET=:PERIODE_PROJET"
             + "ETAT_PROJET=:ETAT_PROJET , TECHNIQUE_UTLISE=:TECHNIQUE_UTLISE , METHODOLOGIE=:METHODOLOGIE , NIVEAU_ETUDIANT=:NIVEAU_ETUDIANT"
             + "ANNEE_DEB=:ANNEE_DEB";*/

            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // Anne du debut du projet : _ANNEE_DEBUT
            OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            prmANNEE_DEB.Value = _ANNEE_DEB;
            myCommand.Parameters.Add(prmANNEE_DEB);



            //le nom du projet _NOM_PROJET
            OracleParameter prmNOM_PROJET = new OracleParameter(":NOM_PROJET", OracleDbType.Varchar2);
            prmNOM_PROJET.Value = _NOM_PROJET;
            myCommand.Parameters.Add(prmNOM_PROJET);

            //le code module : _CODE_MODULE
            OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
            prmCODE_MODULE.Value = _CODE_MODULE;
            myCommand.Parameters.Add(prmCODE_MODULE);

            //le type du projet : _TYPE_PROJET
            OracleParameter prmTYPE_PROJET = new OracleParameter(":TYPE_PROJET", OracleDbType.Varchar2);
            prmTYPE_PROJET.Value = _TYPE_PROJET;
            myCommand.Parameters.Add(prmTYPE_PROJET);

            //la description du projet :_DESCRIPTION_PROJET
            OracleParameter prmDESCRIPTION_PROJET = new OracleParameter(":DESCRIPTION_PROJET", OracleDbType.Varchar2);
            prmDESCRIPTION_PROJET.Value = _DESCRIPTION_PROJET;
            myCommand.Parameters.Add(prmDESCRIPTION_PROJET);

            //technique utilisé dans le projet : _TECHNOLOGIES
            OracleParameter prmTECHNIQUE_UTLISE = new OracleParameter(":TECHNOLOGIES", OracleDbType.Varchar2);
            prmTECHNIQUE_UTLISE.Value = _TECHNOLOGIES;
            myCommand.Parameters.Add(prmTECHNIQUE_UTLISE);


            //methodoligie utilisé dans le projet : _METHODOLOGIE
            OracleParameter prmMETHODOLOGIE = new OracleParameter(":METHODOLOGIE", OracleDbType.Varchar2);
            prmMETHODOLOGIE.Value = _METHODOLOGIE;
            myCommand.Parameters.Add(prmMETHODOLOGIE);



            OracleParameter prmDUREE = new OracleParameter(":DUREE", OracleDbType.Int32);
            prmDUREE.Value = _DUREE;
            myCommand.Parameters.Add(prmDUREE);

            OracleParameter prmSEMESTRE = new OracleParameter(":SEMESTRE", OracleDbType.Int32);
            prmSEMESTRE.Value = _SEMESTRE;
            myCommand.Parameters.Add(prmSEMESTRE);

            OracleParameter prmPERIODE = new OracleParameter(":PERIODE", OracleDbType.Int32);
            prmPERIODE.Value = _PERIODE;
            myCommand.Parameters.Add(prmPERIODE);

            // id du projet, _ID_PROJET
            //OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET", OracleDbType.Varchar2);
            //prmID_PROJET.Value = _ID_PROJET;
            //myCommand.Parameters.Add(prmID_PROJET);

            OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
            prmID_ENS.Value = _ID_ENS;
            myCommand.Parameters.Add(prmID_ENS);

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
        public bool save_projet_etudiant(string _ID_PROJET1, string _ID_ET1, OracleDate _DATE)
        {


            bool result = false;
            openconntrans();
            cmdQuery = " Insert into ESP_PROJET_ETUDIANT (ID_PROJET,ID_ET,DATE_SAISIE)   VALUES   (  :ID_PROJET1, :ID_ET1, :DATE1) ";
            //cmdQuery = "INSERT INTO ESP_PROJET_N  ( ANNEE_DEB, ID_PROJET, NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, DUREE, SEMESTRE, PERIODE,DATE_SAISIE,ID_ENS)  VALUES   ( '2014', 'PROJ9','vv','Ap-12', '01', 'ttt','12', '01', null, null,null,'31-OCT-14','P-399-11') ";
            OracleCommand myCommand = new OracleCommand(cmdQuery);

            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            //ID_PROJET
            OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET1", OracleDbType.Varchar2);
            prmID_PROJET.Value = _ID_PROJET1;
            myCommand.Parameters.Add(prmID_PROJET);


            //ID_ET

            OracleParameter prmID_ET = new OracleParameter(":ID_ET1", OracleDbType.Varchar2);
            prmID_ET.Value = _ID_ET1;
            myCommand.Parameters.Add(prmID_ET);
            //_DESCRIPTION_PROJET


            // _DATE

            OracleParameter prmDATE_SAISIE = new OracleParameter(":DATE1", OracleDbType.Date);
            prmDATE_SAISIE.Value = _DATE;
            myCommand.Parameters.Add(prmDATE_SAISIE);







            // myCommand.ExecuteNonQuery();
            try
            {
                myCommand.ExecuteNonQuery();
                //myCommandnote.ExecuteNonQuery();
                myTrans.Commit();
                result = true;
            }
            catch (Exception)
            {
                myTrans.Rollback();
                mySqlConnection.Close();
                throw;
            }

            //bool result = myCommand.ExecuteNonQuery() > 0;
            mySqlConnection.Close();

            return result;
        }
        public DataTable GetDataTable1(string t, string p)
        {



            openconntrans();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand("  select *,  (SELECT CODE_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '80') and  code_nome=AV_FR)as AV_FR,(SELECT CODE_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '80') and  code_nome=AV_ANG)as AV_ANG from esp_encadrement where id_et='" + t + "'and id_projet ='" + p + "'", mySqlConnection);
            DataTable myDataTable = new DataTable();


            try
            {
                adapter.Fill(myDataTable);

            }
            finally
            {
                mySqlConnection.Close();
            }

            return myDataTable;
        }
        public DataTable GetDataTable3(string p)
        {



            openconntrans();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand(" select NOM_ET||' '||PNOM_ET as NOM, e1.id_projet,e1.id_et,e2.classe_courante_et, e1.date_saisie from esp_projet_etudiant e1,esp_etudiant e2 where id_projet='"+p+"' and e1.id_et=e2.id_et and etat='A' ", mySqlConnection);
            DataTable myDataTable = new DataTable();


            try
            {
                adapter.Fill(myDataTable);

            }
            finally
            {
                mySqlConnection.Close();
            }

            return myDataTable;
        }
        public DataTable GetDataAnglais()
        {



            openconntrans();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand(" SELECT * FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '80') ", mySqlConnection);
            DataTable myDataTable = new DataTable();


            try
            {
                adapter.Fill(myDataTable);

            }
            finally
            {
                mySqlConnection.Close();
            }

            return myDataTable;
        }
        public bool add_encadrement(string _ID_PROJET, string _ANNEE_DEB, string _ID_ET, string _ID_ENS, string _DATE_ENC, DateTime _HEURE_DEB, DateTime _HEURE_FIN, string _AV_TECH, string _AV_ANG, string _AV_FR, string _AV_RAPPORT, string _AV_CC, string _REMARQUE_OBS, string _TRAVAUX_DEMANDE, OracleDate _DATE_SAISIE, string _OBS_TECH, string _OBS_ANG, string _OBS_RAP, string _OBS_FR, string _OBS_CC)
        {
            // Insert into ESP_ENCADREMENT (ID_PROJET,ANNEE_DEB,TYPE_PROJET,ID_ET,ID_ENS,DATE_ENC,HEURE_DEB,HEURE_FIN,AV_TECH,AV_ANG,AV_FR,AV_RAPPORT,AV_CC,COMPORTEMENT,REMARQUE_OBS,TRAVAUX_DEMANDE,DATE_SAISIE,OBS_TECH,OBS_ANGLAIS,OBS_RAPPORT,OBS_FRANCAIS,OBS_CC) values  ('" + idproj + "','2014','12','" + idet + "','" + ID_ENS + "','1A1',to_date((SUBSTR('" + date_encp + "',1,6)||''||SUBSTR('" + date_encp + "',9,2)),'dd/MM/yy'),to_date((SUBSTR('" + time_start + "',1,6)||''||SUBSTR('" + time_start + "',9,2)||' '||Substr('" + time_start + "' ,12,2)||':'||Substr('" + time_start + "' ,15,2)||':'||Substr('" + time_start + "' ,18,2)),'dd/MM/yy hh:mi:ss') ,to_date((SUBSTR('" + time_start + "',1,6)||''||SUBSTR('" + time_start + "',9,2)||' '||Substr('" + time_end + "' ,12,2)||':'||Substr('" + time_end + "' ,15,2)||':'||Substr('" + time_end + "' ,18,2)),'dd/MM/yy hh:mi:ss') ,'" + AV_TECH + "','" + ang + "','" + fran + "','" + AV_RAP + "','" + cc + "',null,'" + Obs + "','" + TravD + "','" + date + "','" + OBS_TECH + "','" + OBS_ANG + "','" + OBS_RAP + "','" + OBS_FR + "','" + OBS_CC + "')");
            bool result = false;
            openconntrans();
            cmdQuery = " Insert into ESP_ENCADREMENT (ID_PROJET,ANNEE_DEB,ID_ET,ID_ENS,DATE_ENC,HEURE_DEB,HEURE_FIN,AV_TECH,AV_ANG,AV_FR,AV_RAPPORT,AV_CC,REMARQUE_OBS,TRAVAUX_DEMANDE,DATE_SAISIE,OBS_TECH,OBS_ANGLAIS,OBS_RAPPORT,OBS_FRANCAIS,OBS_CC) values  ('" + _ID_PROJET + "','" + _ANNEE_DEB + "','" + _ID_ET + "','" + _ID_ENS + "',to_date((SUBSTR('" + _DATE_ENC + "',1,6)||''||SUBSTR('" + _DATE_ENC + "',9,2)),'dd/MM/yy'),to_date((SUBSTR('" + _HEURE_DEB + "',1,6)||''||SUBSTR('" + _HEURE_DEB + "',9,2)||' '||Substr('" + _HEURE_DEB + "' ,12,2)||':'||Substr('" + _HEURE_DEB + "' ,15,2)||':'||Substr('" + _HEURE_DEB + "' ,18,2)),'dd/MM/yy hh:mi:ss') ,to_date((SUBSTR('" + _HEURE_DEB + "',1,6)||''||SUBSTR('" + _HEURE_DEB + "',9,2)||' '||Substr('" + _HEURE_FIN + "' ,12,2)||':'||Substr('" + _HEURE_FIN + "' ,15,2)||':'||Substr('" + _HEURE_FIN + "' ,18,2)),'dd/MM/yy hh:mi:ss') ,'" + _AV_TECH + "','" + _AV_ANG + "','" + _AV_FR + "','" + _AV_RAPPORT + "','" + _AV_CC + "','" + _REMARQUE_OBS + "','" + _TRAVAUX_DEMANDE + "','" + _DATE_SAISIE + "','" + _OBS_TECH + "','" + _OBS_ANG + "','" + _OBS_RAP + "','" + _OBS_FR + "','" + _OBS_CC + "')";

            OracleCommand myCommand = new OracleCommand(cmdQuery);

            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;


            // myCommand.ExecuteNonQuery();
            try
            {
                myCommand.ExecuteNonQuery();
                //myCommandnote.ExecuteNonQuery();
                myTrans.Commit();
                result = true;
            }
            catch (Exception)
            {
                myTrans.Rollback();
                mySqlConnection.Close();
                throw;
            }

            //bool result = myCommand.ExecuteNonQuery() > 0;
            mySqlConnection.Close();

            return result;

        }

       
        public bool ens_lang(string _ID_ENS)
        {
            bool exist = false;


            
                mySqlConnection.Open();


                string cmdQuery =  "select * from esp_module_panier_classe_saiso where ( code_module like 'FR%' or code_module like 'AN%') and (id_ens='" + _ID_ENS + "' or id_ens2='" + _ID_ENS + "' or id_ens3='" + _ID_ENS + "')  ";

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
        public bool update_encadrement( string idet, string dateenc,string dateencp,string idproj, string ang, DateTime time_start, DateTime time_end, string Obs, string TravD, string fran, string cc, string rapp, string AV_TECH, string OBS_RAP, string OBS_TECH, string OBS_ANG, string OBS_CC, string OBS_FR)
        {
            bool result = false;
            openconntrans();
            string cmdQuery = " UPDATE ESP_ENCADREMENT SET AV_ANG='" + ang + "',HEURE_DEB=to_date((SUBSTR('" + time_start + "',1,6)||''||SUBSTR('" + time_start + "',9,2)||' '||Substr('" + time_start + "' ,12,2)||':'||Substr('" + time_start + "' ,15,2)||':'||Substr('" + time_start + "' ,18,2)),'dd/MM/yy hh:mi:ss'),HEURE_FIN=to_date((SUBSTR('" + time_start + "',1,6)||''||SUBSTR('" + time_start + "',9,2)||' '||Substr('" + time_end + "' ,12,2)||':'||Substr('" + time_end + "' ,15,2)||':'||Substr('" + time_end + "' ,18,2)),'dd/MM/yy hh:mi:ss') ,REMARQUE_OBS='" + Obs + "',TRAVAUX_DEMANDE='" + TravD + "',AV_FR='" + fran + "',   AV_CC='" + cc + "',AV_RAPPORT='" + rapp + "',AV_TECH='" + AV_TECH + "',OBS_RAPPORT='" + OBS_RAP + "',OBS_TECH='" + OBS_TECH + "',OBS_ANGLAIS='" + OBS_ANG + "',OBS_CC='" + OBS_CC + "',OBS_FRANCAIS='" + OBS_FR + "', DATE_ENC =to_date((SUBSTR('" + dateenc + "',1,6)||''||SUBSTR('" + dateenc + "',9,2)),'dd/MM/yy') where id_projet='" + idproj + "' and id_et= '" + idet + "' and date_enc=to_date((SUBSTR('" + dateencp + "',1,6)||''||SUBSTR('" + dateencp + "',9,2)),'dd/MM/yy')  ";
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
        }
    }

