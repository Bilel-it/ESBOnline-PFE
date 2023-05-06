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
    public class Rattra
    {
        #region sing

        static Rattra instance;
        static Object locker = new Object();

        public static Rattra Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Rattra();
                    }

                    return Rattra.instance;
                }
            }

        }
        private Rattra() { }

        #endregion
        #region getset
        private string cODE_UE;

        public string CODE_UE
        {
            get { return cODE_UE; }
            set { cODE_UE = value; }
        }
        private decimal mOY_MODULERATT;

        public decimal MOY_MODULERATT
        {
            get { return mOY_MODULERATT; }
            set { mOY_MODULERATT = value; }
        }
        private string dESIGNATION;


        public string DESIGNATION
        {
            get { return dESIGNATION; }
            set { dESIGNATION = value; }
        }private string lIB_UE;

        public string LIB_UE
        {
            get { return lIB_UE; }
            set { lIB_UE = value; }
        }
        private decimal nB_ECTS_R;

        public decimal NB_ECTS_R
        {
            get { return nB_ECTS_R; }
            set { nB_ECTS_R = value; }
        }
        private decimal nB_ECTS;

        public decimal NB_ECTS
        {
            get { return nB_ECTS; }
            set { nB_ECTS = value; }
        }
        private decimal cOEF;

        public decimal COEF
        {
            get { return cOEF; }
            set { cOEF = value; }
        }
        private decimal mOY_UE_RATT;

        public decimal MOY_UE_RATT
        {
            get { return mOY_UE_RATT; }
            set { mOY_UE_RATT = value; }
        }
        private decimal mOY_UE;

        public decimal MOY_UE
        {
            get { return mOY_UE; }
            set { mOY_UE = value; }
        }

        private decimal mOY_MODULE;

        public decimal MOY_MODULE
        {
            get { return mOY_MODULE; }
            set { mOY_MODULE = value; }
        }



        #endregion
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Rattra> GetResFinal(string _Id_et)
        {
            List<Rattra> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                //  string cmdQuery = "SELECT e2.code_ue ,lib_ue,nb_ects, designation,coef ,e1.moyenne as moy_module,e2.moyenne as moy_ue ,e1.type_moy ,(select moyenne  from ESP_V_MOY_MODULE_ETUDIANT_UE e3	 where  e3.ID_ET='" + _Id_et + "'and e1.code_module=e1.code_module  and e3.code_ue=e2.code_ue and e3.code_ue=e1.code_ue  and e3.type_moy='R') as moy_moduleRatt   FROM ESP_V_MOY_MODULE_ETUDIANT_UE e1, ESP_V_MOY_UE_ETUDIANT e2 where   e1.id_et=e2.id_et and e1.annee_deb='2015' AND e2.annee_deb='2015' and e1.code_ue=e2.code_ue and e1.ID_ET='" + _Id_et + "' and e1.type_moy='P' and  e2.type_moy='P'  order by lib_ue ";
                // string cmdQuery = "SELECT e2.code_ue ,lib_ue,nb_ects, designation,coef ,e1.moyenne as moy_module,e2.moyenne as moy_ue ,e1.type_moy ,(select moyenne from  ESP_V_MOY_UE_ETUDIANT e4 where e4.ID_ET='" + _Id_et + "' and e4.code_ue=e2.code_ue and e4.code_ue=e1.code_ue  and e4.type_moy='R' ) AS MOY_UE_RATT,(select moyenne from  ESP_V_MOY_UE_ETUDIANT e4 where e4.ID_ET='" + _Id_et + "' and e4.code_ue=e2.code_ue and e4.code_ue=e1.code_ue  and e4.type_moy='R' ) AS MOY_UE_RATT,(select moyenne from  ESP_V_MOY_UE_ETUDIANT e4 where e4.ID_ET='" + _Id_et + "' and e4.code_ue=e2.code_ue and e4.code_ue=e1.code_ue  and e4.type_moy='R' ) AS MOY_UE_RATT,(select distinct NB_ECTS  from ESP_V_MOY_MODULE_ETUDIANT_UE e3 where  e3.ID_ET='" + _Id_et + "'and e1.code_module=e3.code_module  and e3.code_ue=e2.code_ue and e3.code_ue=e1.code_ue  and e3.type_moy='R') as NB_ECTS_R ,(select distinct moyenne  from ESP_V_MOY_MODULE_ETUDIANT_UE e3 where  e3.ID_ET='" + _Id_et + "'and e1.code_module=e3.code_module    and e3.type_moy='R') as moy_moduleRatt   FROM ESP_V_MOY_MODULE_ETUDIANT_UE e1, ESP_V_MOY_UE_ETUDIANT e2 where   e1.id_et=e2.id_et and e1.annee_deb=(select max(annee_deb) from societe) AND e2.annee_deb=(select max(annee_deb) from societe) and e1.code_ue=e2.code_ue and e1.ID_ET='" + _Id_et + "' and e1.type_moy='P' and  e2.type_moy='P'  order by lib_ue  ";

                //183JMT1623
                //string cmdQuery = "SELECT distinct e2.code_ue ,e22.lib_ue,e2.nb_ects, e5.DESIGNATION_NEW AS DESIGNATION,e1.coef ,e1.moyenne as moy_module,e2.moyenne as moy_ue ,e1.type_moy ,(select moyenne from ESP_MOY_UE_ETUDIANT e4 where e4.ID_ET='"+_Id_et+ "' and e4.code_ue=e2.code_ue and e4.code_ue=e1.code_ue  and e4.type_moy='R' and  e4.ANNEE_DEB=(select max(annee_deb) from societe))AS MOY_UE_RATT,(select distinct e2.NB_ECTS  from ESP_MOY_MODULE_ETUDIANT e3 where  e3.ID_ET='" + _Id_et+"'and e1.code_module=e3.code_module  and e3.code_ue=e2.code_ue and e3.code_ue=e1.code_ue and e3.type_moy='R') as NB_ECTS_R ,(select distinct moyenne  from ESP_MOY_MODULE_ETUDIANT e3 where  e3.ID_ET='"+_Id_et+ "'and e1.code_module=e3.code_module and e3.type_moy='R' and e3.ANNEE_DEB=(select max(annee_deb) from societe)) as moy_moduleRatt  FROM ESP_MOY_MODULE_ETUDIANT e1, ESP_MOY_UE_ETUDIANT e2,ESP_UE  e22,ESP_MODULE_PANIER_CLASSE_SAISO   e5,societe e55 where  e1.CODE_MODULE = e5.CODE_MODULE and  e2.CODE_UE =e22.CODE_UE  and  e1.id_et=e2.id_et and e1.annee_deb=(select max(annee_deb) from societe) AND e2.annee_deb=(select max(annee_deb) from societe) and e5.ANNEE_DEB=(select max(annee_deb) from societe) and e1.code_ue=e2.code_ue and e1.ID_ET='" + _Id_et+ "' and e1.type_moy='P'  and e2.type_moy='P' and e5.DESIGNATION_NEW is not null and e2.type_moy='P' and e22.ANNEE_DEB=(select max(annee_deb) from societe) and e55.AFFICH_NOTE='O' order by lib_ue ";
                string cmdQuery = "SELECT distinct e2.code_ue ,e22.lib_ue,e2.nb_ects, e5.DESIGNATION_NEW AS DESIGNATION,e1.coef ,e1.moyenne as moy_module,e2.moyenne as moy_ue ,e1.type_moy ,(select moyenne from ESP_MOY_UE_ETUDIANT e4 where e4.ID_ET='" + _Id_et + "'  and e4.code_ue=e2.code_ue and e4.code_ue=e1.code_ue  and e4.type_moy='R' and  e4.ANNEE_DEB=(select max(annee_deb) from societe))AS MOY_UE_RATT,(select distinct e2.NB_ECTS  from ESP_MOY_MODULE_ETUDIANT e3 where  e3.ID_ET='" + _Id_et + "'and e1.code_module=e3.code_module  and e3.code_ue=e2.code_ue and e3.code_ue=e1.code_ue and e3.type_moy='R') as NB_ECTS_R ,(select distinct moyenne  from ESP_MOY_MODULE_ETUDIANT e3 where  e3.ID_ET='" + _Id_et + "'and e1.code_module=e3.code_module and e3.type_moy='R' and e3.ANNEE_DEB=(select max(annee_deb) from societe)) as moy_moduleRatt  FROM ESP_MOY_MODULE_ETUDIANT e1, ESP_MOY_UE_ETUDIANT e2,ESP_UE  e22,ESP_MODULE_PANIER_CLASSE_SAISO   e5,societe e55 where  e1.CODE_MODULE = e5.CODE_MODULE and  e2.CODE_UE =e22.CODE_UE  and  e1.id_et=e2.id_et and e1.annee_deb=(select max(annee_deb) from societe) AND e2.annee_deb=(select max(annee_deb) from societe) and e5.ANNEE_DEB=(select max(annee_deb) from societe) and e1.code_ue=e2.code_ue and e1.ID_ET='" + _Id_et + "' and e1.type_moy='P'  and e2.type_moy='P' and e5.DESIGNATION_NEW is not null and e2.type_moy='P' and e22.ANNEE_DEB=(select max(annee_deb) from societe) and e55.AFFICH_NOTE='O' order by lib_ue ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<Rattra>();
                        while (myReader.Read())
                        {
                            myList.Add(new Rattra(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;
        }
        //public static List<Rattra> GetResFinal(string _Id_et)
        //{
        //    List<Rattra> myList = null;

        //    using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
        //    {

        //        mySqlConnection.Open();

        //        //  string cmdQuery = "SELECT e2.code_ue ,lib_ue,nb_ects, designation,coef ,e1.moyenne as moy_module,e2.moyenne as moy_ue ,e1.type_moy ,(select moyenne  from ESP_V_MOY_MODULE_ETUDIANT_UE e3	 where  e3.ID_ET='" + _Id_et + "'and e1.code_module=e1.code_module  and e3.code_ue=e2.code_ue and e3.code_ue=e1.code_ue  and e3.type_moy='R') as moy_moduleRatt   FROM ESP_V_MOY_MODULE_ETUDIANT_UE e1, ESP_V_MOY_UE_ETUDIANT e2 where   e1.id_et=e2.id_et and e1.annee_deb='2016' AND e2.annee_deb='2016' and e1.code_ue=e2.code_ue and e1.ID_ET='" + _Id_et + "' and e1.type_moy='P' and  e2.type_moy='P'  order by lib_ue ";
        //        // string cmdQuery = "SELECT e2.code_ue ,lib_ue,nb_ects, designation,coef ,e1.moyenne as moy_module,e2.moyenne as moy_ue ,e1.type_moy ,(select moyenne from  ESP_V_MOY_UE_ETUDIANT e4 where e4.ID_ET='" + _Id_et + "' and e4.code_ue=e2.code_ue and e4.code_ue=e1.code_ue  and e4.type_moy='R' ) AS MOY_UE_RATT,(select moyenne from  ESP_V_MOY_UE_ETUDIANT e4 where e4.ID_ET='" + _Id_et + "' and e4.code_ue=e2.code_ue and e4.code_ue=e1.code_ue  and e4.type_moy='R' ) AS MOY_UE_RATT,(select moyenne from  ESP_V_MOY_UE_ETUDIANT e4 where e4.ID_ET='" + _Id_et + "' and e4.code_ue=e2.code_ue and e4.code_ue=e1.code_ue  and e4.type_moy='R' ) AS MOY_UE_RATT,(select  NB_ECTS  from ESP_V_MOY_MODULE_ETUDIANT_UE e3 where  e3.ID_ET='" + _Id_et + "'and e1.code_module=e3.code_module  and e3.code_ue=e2.code_ue and e3.code_ue=e1.code_ue  and e3.type_moy='R' and e2.type_moy=e3.type_moy) as NB_ECTS_R ,(select moyenne  from ESP_V_MOY_MODULE_ETUDIANT_UE e3 where  e3.ID_ET='" + _Id_et + "'and e1.code_module=e3.code_module and e2.type_moy=e3.type_moy and  e3.id_et=e1.id_et  and e3.type_moy='R') as moy_moduleRatt   FROM ESP_V_MOY_MODULE_ETUDIANT_UE e1, ESP_V_MOY_UE_ETUDIANT e2 where   e1.id_et=e2.id_et and e1.annee_deb='2016' AND e2.annee_deb='2016' and e1.code_ue=e2.code_ue and e1.ID_ET='" + _Id_et + "' and e1.type_moy='P' and  e2.type_moy='P'  order by lib_ue  ";
        //        // string cmdQuery = "select e3.DESIGNATION,e1.code_ue,e1.NB_ECTS,e1.NB_ECTS NB_ECTS_R,e3.moyenne moy_moduleRatt,e1.LIB_UE,coef,e1.MOYENNE MOY_UE_RATT  from ESP_V_MOY_MODULE_ETUDIANT_UE e3,ESP_V_MOY_UE_ETUDIANT e1 where    e3.ID_ET='" + _Id_et + "' and e3.type_moy='R' and  e1.type_moy='R' and e1.type_moy=e3.TYPE_MOY and e3.annee_deb=2018 and e1.ANNEE_DEB=2018     and e3.id_et=e1.id_et and e1.CODE_UE=e3.CODE_UE order by lib_ue";


        //        string cmdQuery = "select e3.DESIGNATION,e1.code_ue,e1.NB_ECTS,e1.NB_ECTS NB_ECTS_R,e3.moyenne moy_moduleRatt,e1.LIB_UE,coef,e1.MOYENNE MOY_UE_RATT  from ESP_V_MOY_MODULE_ETUDIANT_UE e3,ESP_V_MOY_UE_ETUDIANT e1 where    e3.ID_ET='" + _Id_et + "' and e3.type_moy='R' and  e1.type_moy='R' and e1.type_moy=e3.TYPE_MOY and e3.annee_deb=2019 and e1.ANNEE_DEB=2019 and e1.code_cl in ('3-LFIG-1','3-LFIG-2','3-LFG-1' ,  '3-LFG-2'  ,  '3-LFG-3','2-LFG-1' ,  '2-LFG-2'  ,  '2-LFG-3' ,  '2-LFG-4' , '2-LFG-5' , '1-MDSI-1' ,  '1-MDSI-2','1-MKD-1' ,  '1-MKD-2','1-CCA-1','1-BA-1' ,  '1-BA-2','1-LSG-1','1-LSG-2','1-LSG-3','1-LSG-4','1-LSG-5','1-LSG-6','1-LSG-7','2-LFIG-1','2-LFIG-2','1-BC-1','1-BC-2','1-BC-3','1-BC-4')   and e3.id_et=e1.id_et and e1.CODE_UE=e3.CODE_UE order by lib_ue";




        //        OracleCommand myCommand = new OracleCommand(cmdQuery);
        //        myCommand.Connection = mySqlConnection;
        //        myCommand.CommandType = CommandType.Text;

        //        using (OracleDataReader myReader = myCommand.ExecuteReader())
        //        {
        //            if (myReader.HasRows)
        //            {
        //                myList = new List<Rattra>();
        //                while (myReader.Read())
        //                {
        //                    myList.Add(new Rattra(myReader));
        //                }
        //            }
        //        }

        //        mySqlConnection.Close();
        //    }
        //    return myList;
        //}
        public Rattra(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("COEF")))
            {

                cOEF = myReader.GetDecimal(myReader.GetOrdinal("COEF"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_UE")))
            {

                cODE_UE = myReader.GetString(myReader.GetOrdinal("CODE_UE"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("DESIGNATION")))
            {

                dESIGNATION = myReader.GetString(myReader.GetOrdinal("DESIGNATION"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("LIB_UE")))
            {

                lIB_UE = myReader.GetString(myReader.GetOrdinal("LIB_UE"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("NB_ECTS")))
            {

                nB_ECTS = myReader.GetDecimal(myReader.GetOrdinal("NB_ECTS"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NB_ECTS_R")))
            {

                nB_ECTS_R = myReader.GetDecimal(myReader.GetOrdinal("NB_ECTS_R"));
            }
            //if (!myReader.IsDBNull(myReader.GetOrdinal("MOY_UE")))
            //{
            //    mOY_UE = myReader.GetDecimal(myReader.GetOrdinal("MOY_UE"));
            //}
            if (!myReader.IsDBNull(myReader.GetOrdinal("MOY_UE_RATT")))
            {
                mOY_UE_RATT = myReader.GetDecimal(myReader.GetOrdinal("MOY_UE_RATT"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("MOY_MODULE")))
            {

                mOY_MODULE = myReader.GetDecimal(myReader.GetOrdinal("MOY_MODULE"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("MOY_MODULERATT")))
            {

                mOY_MODULERATT = myReader.GetDecimal(myReader.GetOrdinal("MOY_MODULERATT"));
            }
        }
    }
}