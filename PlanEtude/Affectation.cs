using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Oracle.ManagedDataAccess.Client;
using ESPSuiviEncadrement;
using System.Data;
using System.Configuration;

namespace PlanEtude
{
    public class Affectation
    {
        #region sing

        static Affectation instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static Affectation Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Affectation();
                    }

                    return Affectation.instance;
                }
            }

        }
        private Affectation() { }

        #endregion

        
        #region public private methodes
        //NUM_SEMESTRE
        //CHARGE_P1
        //CHARGE_P2
        //CODE_MODULE
        //designation
        //CODE_CL
        //NB_HEURES
        //ANNEE_DEB
        //dd
        //CHARGE_ENS1_P1
        //CHARGE_ENS1_P2
        //CHARGE_ENS2_P1
        //CHARGE_ENS2_P2
        //CHARGE_ENS3_P1
        //CHARGE_ENS3_P2
        //CHARGE_ENS4_P1
        //CHARGE_ENS4_P2
        //CHARGE_ENS5_P1
        //CHARGE_ENS5_P2
        //dd2
        //dd3
        //dd4
        //dd5
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
        private decimal _NUM_SEMESTRE;

	public decimal NUM_SEMESTRE
	{
        get { return _NUM_SEMESTRE; }
        set { _NUM_SEMESTRE = value; }
	}
    private decimal _CHARGE_P1;

	public decimal CHARGE_P1
	{
        get { return _CHARGE_P1; }
        set { _CHARGE_P1 = value; }
	}
    private decimal _CHARGE_P2;
    public decimal CHARGE_P2
    {
        get { return _CHARGE_P2; }
        set { _CHARGE_P2 = value; }
    }
    private string _CODE_MODULE;
    public string CODE_MODULE
    {
        get { return _CODE_MODULE; }
        set { _CODE_MODULE = value; }
    }
    private string _designation;
    public string designation
    {
        get { return _designation; }
        set { _designation = value; }
    }
    private string _CODE_CL;
    public string CODE_CL
    {
        get { return _CODE_CL; }
        set { _CODE_CL = value; }
    }
    private decimal _NB_HEURES;
    public decimal NB_HEURES
    {
        get { return _NB_HEURES; }
        set { _NB_HEURES = value; }
    }
    private string _ANNEE_DEB;
    public string ANNEE_DEB
    {
        get { return _ANNEE_DEB; }
        set { _ANNEE_DEB = value; }
    }
    private string _dd;
    public string dd
    {
        get { return _dd; }
        set { _dd = value; }
    }
    private decimal _CHARGE_ENS1_P1;
    public decimal CHARGE_ENS1_P1
    {
        get { return _CHARGE_ENS1_P1; }
        set { _CHARGE_ENS1_P1 = value; }
    }
    private string _TYPE_EPREUVE;

    public string TYPE_EPREUVE
    {
        get { return _TYPE_EPREUVE; }
        set { _TYPE_EPREUVE = value; }
    }
    
    private decimal _CHARGE_ENS2_P1;
    public decimal CHARGE_ENS2_P1
    {
        get { return _CHARGE_ENS2_P1; }
        set { _CHARGE_ENS2_P1 = value; }
    }
    private decimal _CHARGE_ENS3_P1;
    public decimal CHARGE_ENS3_P1
    {
        get { return _CHARGE_ENS3_P1; }
        set { _CHARGE_ENS3_P1 = value; }
    }
    private decimal _CHARGE_ENS4_P1;
    public decimal CHARGE_ENS4_P1
    {
        get { return _CHARGE_ENS4_P1; }
        set { _CHARGE_ENS4_P1 = value; }
    }
    private decimal _CHARGE_ENS5_P1;
    public decimal CHARGE_ENS5_P1
    {
        get { return _CHARGE_ENS5_P1; }
        set { _CHARGE_ENS5_P1 = value; }
    }
    private decimal _CHARGE_ENS1_P2;
    public decimal CHARGE_ENS1_P2
    {
        get { return _CHARGE_ENS1_P2; }
        set { _CHARGE_ENS1_P2 = value; }
    }

    private decimal _CHARGE_ENS2_P2;
    public decimal CHARGE_ENS2_P2
    {
        get { return _CHARGE_ENS2_P2; }
        set { _CHARGE_ENS2_P2 = value; }
    }
    private decimal _CHARGE_ENS3_P2;
    public decimal CHARGE_ENS3_P2
    {
        get { return _CHARGE_ENS3_P2; }
        set { _CHARGE_ENS3_P2 = value; }
    }
    private decimal _CHARGE_ENS4_P2;
    public decimal CHARGE_ENS4_P2
    {
        get { return _CHARGE_ENS4_P2; }
        set { _CHARGE_ENS4_P2 = value; }
    }
    private decimal _CHARGE_ENS5_P2;
    public decimal CHARGE_ENS5_P2
    {
        get { return _CHARGE_ENS5_P2; }
        set { _CHARGE_ENS5_P2 = value; }
    }
    private string _dd2;
    public string dd2
    {
        get { return _dd2; }
        set { _dd2 = value; }
    }
    private string _dd3;
    public string dd3
    {
        get { return _dd3; }
        set { _dd3 = value; }
    }
    private string _dd4;
    public string dd4
    {
        get { return _dd4; }
        set { _dd4 = value; }
    }
    private string _dd5;
    public string dd5
    {
        get { return _dd5; }
        set { _dd5 = value; }
    }

        #endregion


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public virtual List<Affectation> BindAffectation(string semesetre, bool module, string code_module, string code_cl, string sessionup)
        {
            List<Affectation> myList = null;
            decimal num_sem = Entreprise.Instance.getNumSemestre();
          //  string annee_deb = Entreprise.Instance.getAnneeDeb();
            string annee_deb = "2014";

            if (module == true)
            {
                if (semesetre != "3")
                {
                    OracleCommand cmd = new OracleCommand("SELECT  (select lib_nome from CODE_NOMENCLATURE where CODE_NOMENCLATURE.code_nome=ESP_MODULE_PANIER_CLASSE_SAISO.TYPE_EPREUVE and  CODE_NOMENCLATURE.CODE_STR='78') as TYPE_EPREUVE,NUM_SEMESTRE,CHARGE_P1,CHARGE_P2,CODE_MODULE,(select Designation from ESP_MODULE where ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)as designation,  ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL,NB_HEURES, ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_ENSEIGNANT.ID_ENS)as dd ,CHARGE_ENS1_P1,CHARGE_ENS1_P2,CHARGE_ENS2_P1,CHARGE_ENS2_P2,CHARGE_ENS3_P1,CHARGE_ENS3_P2,CHARGE_ENS4_P1,CHARGE_ENS4_P2,CHARGE_ENS5_P1,CHARGE_ENS5_P2 ,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS2=ESP_ENSEIGNANT.ID_ENS)as dd2 ,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS3=ESP_ENSEIGNANT.ID_ENS)as dd3,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS4=ESP_ENSEIGNANT.ID_ENS)as dd4,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS5=ESP_ENSEIGNANT.ID_ENS)as dd5 FROM   ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '" + annee_deb + "' and ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE in (select CODE_MODULE from esp_module where esp_module.up = '" + sessionup.ToString() + "') and code_cl like '" + code_cl + "%' and code_module ='" + code_module.ToString().Trim() + "' and num_semestre = " + int.Parse(semesetre.ToString().Trim()) + " order by num_semestre,code_cl");
                    myList = this.ExecuteQuery(cmd, "SELECT");
                }
                else
                {
                    OracleCommand cmd = new OracleCommand("SELECT (select lib_nome from CODE_NOMENCLATURE where CODE_NOMENCLATURE.code_nome=ESP_MODULE_PANIER_CLASSE_SAISO.TYPE_EPREUVE and  CODE_NOMENCLATURE.CODE_STR='78') as TYPE_EPREUVE,NUM_SEMESTRE,CHARGE_P1,CHARGE_P2,CODE_MODULE,(select Designation from ESP_MODULE where ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)as designation,  ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL,NB_HEURES, ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT  where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_ENSEIGNANT.ID_ENS)as dd,CHARGE_ENS1_P1,CHARGE_ENS1_P2,CHARGE_ENS2_P1,CHARGE_ENS2_P2,CHARGE_ENS3_P1,CHARGE_ENS3_P2,CHARGE_ENS4_P1,CHARGE_ENS4_P2,CHARGE_ENS5_P1,CHARGE_ENS5_P2 ,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS2=ESP_ENSEIGNANT.ID_ENS)as dd2 ,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS3=ESP_ENSEIGNANT.ID_ENS)as dd3,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS4=ESP_ENSEIGNANT.ID_ENS)as dd4,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS5=ESP_ENSEIGNANT.ID_ENS)as dd5 FROM   ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '" + annee_deb + "' and ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE in (select CODE_MODULE from esp_module where esp_module.up = '" + sessionup.ToString() + "') and code_cl like '" + code_cl + "%' and code_module ='" + code_module.ToString().Trim() + "'order by num_semestre,code_cl");
                    myList = this.ExecuteQuery(cmd, "SELECT");
                }

            }
            else
            {
                if (semesetre != "3")
                {
                    OracleCommand cmd = new OracleCommand("SELECT  (select lib_nome from CODE_NOMENCLATURE where CODE_NOMENCLATURE.code_nome=ESP_MODULE_PANIER_CLASSE_SAISO.TYPE_EPREUVE and  CODE_NOMENCLATURE.CODE_STR='78') as TYPE_EPREUVE,NUM_SEMESTRE,CHARGE_P1,CHARGE_P2,CODE_MODULE,(select Designation from ESP_MODULE where ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)as designation,  ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL,NB_HEURES, ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_ENSEIGNANT.ID_ENS)as dd ,CHARGE_ENS1_P1,CHARGE_ENS1_P2,CHARGE_ENS2_P1,CHARGE_ENS2_P2,CHARGE_ENS3_P1,CHARGE_ENS3_P2,CHARGE_ENS4_P1,CHARGE_ENS4_P2,CHARGE_ENS5_P1,CHARGE_ENS5_P2 ,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS2=ESP_ENSEIGNANT.ID_ENS)as dd2 ,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS3=ESP_ENSEIGNANT.ID_ENS)as dd3,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS4=ESP_ENSEIGNANT.ID_ENS)as dd4,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS5=ESP_ENSEIGNANT.ID_ENS)as dd5 FROM   ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '" + annee_deb + "' and ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE in (select CODE_MODULE from esp_module where esp_module.up = '" + sessionup.ToString() + "') and code_cl like '" + code_cl + "%' and num_semestre = " + int.Parse(semesetre.ToString().Trim()) + " order by num_semestre,code_cl");
                    myList = this.ExecuteQuery(cmd, "SELECT");
                }
                else
                {
                    OracleCommand cmd = new OracleCommand("SELECT  (select lib_nome from CODE_NOMENCLATURE where CODE_NOMENCLATURE.code_nome=ESP_MODULE_PANIER_CLASSE_SAISO.TYPE_EPREUVE and  CODE_NOMENCLATURE.CODE_STR='78') as TYPE_EPREUVE,NUM_SEMESTRE,CHARGE_P1,CHARGE_P2,CODE_MODULE,(select Designation from ESP_MODULE where ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)as designation,  ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL,NB_HEURES, ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_ENSEIGNANT.ID_ENS)as dd ,CHARGE_ENS1_P1,CHARGE_ENS1_P2,CHARGE_ENS2_P1,CHARGE_ENS2_P2,CHARGE_ENS3_P1,CHARGE_ENS3_P2,CHARGE_ENS4_P1,CHARGE_ENS4_P2,CHARGE_ENS5_P1,CHARGE_ENS5_P2 ,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS2=ESP_ENSEIGNANT.ID_ENS)as dd2 ,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS3=ESP_ENSEIGNANT.ID_ENS)as dd3,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS4=ESP_ENSEIGNANT.ID_ENS)as dd4,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS5=ESP_ENSEIGNANT.ID_ENS)as dd5 FROM   ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '" + annee_deb + "' and ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE in (select CODE_MODULE from esp_module where esp_module.up = '" + sessionup.ToString() + "') and code_cl like '" + code_cl + "%' order by num_semestre,code_cl");
                    myList =  this.ExecuteQuery(cmd, "SELECT");
                }
            }
            return myList;

        }
        public List<Affectation> ExecuteQuery(OracleCommand cmd, string action)
        {
            List<Affectation> myList = null;
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(conString))
            {

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                switch (action)
                {
                    case "SELECT":
                        con.Open();
                        using (OracleDataReader myReader = cmd.ExecuteReader())
                        {
                            if (myReader.HasRows)
                            {
                                myList = new List<Affectation>();
                                while (myReader.Read())
                                {
                                    myList.Add(new Affectation(myReader));
                                }
                            }
                            con.Close();
                            return myList;
                        }
                    case "UPDATE":
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        break;
                }
                return null;
            }
        }
        
        public Affectation(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("NUM_SEMESTRE")))
            {
                _NUM_SEMESTRE = myReader.GetDecimal(myReader.GetOrdinal("NUM_SEMESTRE"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("TYPE_EPREUVE")))
            {
                _TYPE_EPREUVE = myReader.GetString(myReader.GetOrdinal("TYPE_EPREUVE"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CHARGE_P1")))
            {
                _CHARGE_P1 = myReader.GetDecimal(myReader.GetOrdinal("CHARGE_P1"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CHARGE_P2")))
            {
                _CHARGE_P2 = myReader.GetDecimal(myReader.GetOrdinal("CHARGE_P2"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_MODULE")))
            {
                _CODE_MODULE = myReader.GetString(myReader.GetOrdinal("CODE_MODULE"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("designation")))
            {
                _designation = myReader.GetString(myReader.GetOrdinal("designation"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_MODULE")))
            {
                _CODE_MODULE = myReader.GetString(myReader.GetOrdinal("CODE_MODULE"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_CL")))
            {
                _CODE_CL = myReader.GetString(myReader.GetOrdinal("CODE_CL"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NB_HEURES")))
            {
                _NB_HEURES = myReader.GetDecimal(myReader.GetOrdinal("NB_HEURES"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ANNEE_DEB")))
            {
                _ANNEE_DEB = myReader.GetString(myReader.GetOrdinal("ANNEE_DEB"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("dd")))
            {
                _dd = myReader.GetString(myReader.GetOrdinal("dd"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CHARGE_ENS1_P1")))
            {
                _CHARGE_ENS1_P1 = myReader.GetDecimal(myReader.GetOrdinal("CHARGE_ENS1_P1"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CHARGE_ENS1_P2")))
            {
                _CHARGE_ENS1_P2 = myReader.GetDecimal(myReader.GetOrdinal("CHARGE_ENS1_P2"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CHARGE_ENS2_P1")))
            {
                _CHARGE_ENS2_P1 = myReader.GetDecimal(myReader.GetOrdinal("CHARGE_ENS2_P1"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CHARGE_ENS2_P2")))
            {
                _CHARGE_ENS2_P2 = myReader.GetDecimal(myReader.GetOrdinal("CHARGE_ENS2_P2"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CHARGE_ENS3_P1")))
            {
                _CHARGE_ENS3_P1 = myReader.GetDecimal(myReader.GetOrdinal("CHARGE_ENS3_P1"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CHARGE_ENS3_P2")))
            {
                _CHARGE_ENS3_P2 = myReader.GetDecimal(myReader.GetOrdinal("CHARGE_ENS3_P2"));

            } 
            if (!myReader.IsDBNull(myReader.GetOrdinal("CHARGE_ENS4_P1")))
            {
                _CHARGE_ENS4_P1 = myReader.GetDecimal(myReader.GetOrdinal("CHARGE_ENS4_P1"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CHARGE_ENS4_P2")))
            {
                _CHARGE_ENS4_P2 = myReader.GetDecimal(myReader.GetOrdinal("CHARGE_ENS4_P2"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CHARGE_ENS5_P1")))
            {
                _CHARGE_ENS5_P1 = myReader.GetDecimal(myReader.GetOrdinal("CHARGE_ENS5_P1"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CHARGE_ENS5_P2")))
            {
                _CHARGE_ENS5_P2 = myReader.GetDecimal(myReader.GetOrdinal("CHARGE_ENS5_P2"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("dd2")))
            {
                _dd2 = myReader.GetString(myReader.GetOrdinal("dd2"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("dd3")))
            {
                _dd3 = myReader.GetString(myReader.GetOrdinal("dd3"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("dd4")))
            {
                _dd4 = myReader.GetString(myReader.GetOrdinal("dd4"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("dd5")))
            {
                _dd5 = myReader.GetString(myReader.GetOrdinal("dd5"));

            }
            //NUM_SEMESTRE
            //CHARGE_P1
            //CHARGE_P2
            //CODE_MODULE
            //designation
            //CODE_CL
            //NB_HEURES
            //ANNEE_DEB
            //dd
            //CHARGE_ENS1_P1
            //CHARGE_ENS1_P2
            //CHARGE_ENS2_P1
            //CHARGE_ENS2_P2
            //CHARGE_ENS3_P1
            //CHARGE_ENS3_P2
            //CHARGE_ENS4_P1
            //CHARGE_ENS4_P2
            //CHARGE_ENS5_P1
            //CHARGE_ENS5_P2
            //dd2
            //dd3
            //dd4
            //dd5
        }
    
    }
}
