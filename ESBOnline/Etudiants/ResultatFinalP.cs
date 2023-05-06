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
    public class ResultatFinalP
    {
        #region sing

        static ResultatFinalP instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static ResultatFinalP Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ResultatFinalP();
                    }

                    return ResultatFinalP.instance;
                }
            }

        }
        private ResultatFinalP() { }

        #endregion
        #region getset
        private string cODE_UE;

        public string CODE_UE
        {
            get { return cODE_UE; }
            set { cODE_UE = value; }
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
        public static List<ResultatFinalP> GetResFinal(string _Id_et)
        {
            List<ResultatFinalP> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();


                //string cmdQuery = "select distinct e2.code_ue ,e2.lib_ue,e2.nb_ects, e3.DESIGNATION_NEW as DESIGNATION,e4.coef,e1.moyenne as moy_ue,e4.moyenne as moy_module from ESP_MOY_UE_ETUDIANT e1 ,esp_ue e2,ESP_MODULE_PANIER_CLASSE_SAISO e3,ESP_MOY_MODULE_ETUDIANT e4,SOCIETE e5 where e1.id_et ='" + _Id_et + "' and  e4.ANNEE_DEB=(select max(annee_deb) from societe) and e4.ANNEE_DEB = e3.ANNEE_DEB and e2.ANNEE_DEB = (select max(annee_deb) from societe) and e2.CODE_UE = e1.CODE_UE  and e3.CODE_MODULE = e4.CODE_MODULE  and e4.CODE_UE = e1.CODE_UE and e4.ID_ET = e1.ID_ET AND  e1.id_et!='163JFT0108'   and e4.TYPE_MOY = 'P'   and e1.TYPE_MOY = 'P' and(e1.moyenne IS NOT NULL) and (SCOESP09.fs_is_student_autorised_new('" + _Id_et + "') in (1))  and e4.moyenne is not null and e1.annee_deb=(select max(annee_deb) from societe)  order by lib_ue";
                // string cmdQuery = "select distinct e2.code_ue ,e2.lib_ue,e2.nb_ects, e3.DESIGNATION_NEW as DESIGNATION,e4.coef,e1.moyenne as moy_ue,e4.moyenne as moy_module from ESP_MOY_UE_ETUDIANT e1 ,esp_ue e2,ESP_MODULE_PANIER_CLASSE_SAISO e3,ESP_MOY_MODULE_ETUDIANT e4,SOCIETE e5 ,esp_etat_nav e7 where  e7.IDENTIFIANT_ETUDIANT=e1.id_et and e7.etat='T' and e1.id_et ='" + _Id_et + "' and  e4.ANNEE_DEB=(select max(annee_deb) from societe) and e4.ANNEE_DEB = e3.ANNEE_DEB and e2.ANNEE_DEB = (select max(annee_deb) from societe) and e2.CODE_UE = e1.CODE_UE  and e3.CODE_MODULE = e4.CODE_MODULE  and e4.CODE_UE = e1.CODE_UE and e4.ID_ET = e1.ID_ET AND  e1.id_et!='163JFT0108'   and e4.TYPE_MOY = 'P'   and e1.TYPE_MOY = 'P' and(e1.moyenne IS NOT NULL)  and e4.moyenne is not null and e5.Delib_resultats='O' and e1.ANNEE_DEB=(select max(annee_deb) from scoesb02.societe) order by lib_ue";
                // string cmdQuery = "select distinct e2.code_ue ,e2.lib_ue,e2.nb_ects, e3.DESIGNATION_NEW as DESIGNATION,e4.coef,e1.moyenne as moy_ue,e4.moyenne as moy_module from ESP_MOY_UE_ETUDIANT e1 ,esp_ue e2,ESP_MODULE_PANIER_CLASSE_SAISO e3,ESP_MOY_MODULE_ETUDIANT e4,SOCIETE e5 where      e1.id_et ='" + _Id_et + "' and  e4.ANNEE_DEB=(select max(annee_deb) from societe) and e4.ANNEE_DEB = e3.ANNEE_DEB and e2.ANNEE_DEB = (select max(annee_deb) from societe) and e2.CODE_UE = e1.CODE_UE  and e3.CODE_MODULE = e4.CODE_MODULE  and e4.CODE_UE = e1.CODE_UE and e4.ID_ET = e1.ID_ET AND  e1.id_et!='163JFT0108'   and e4.TYPE_MOY = 'P'   and e1.TYPE_MOY = 'P' and(e1.moyenne IS NOT NULL)  and e4.moyenne is not null and e5.Delib_resultats='O' and e1.ANNEE_DEB=(select max(annee_deb) from scoesb02.societe) order by lib_ue";
                //avec solde string cmdQuery = "select distinct e2.code_ue ,e2.lib_ue,e1.nb_ects, e3.DESIGNATION_NEW as DESIGNATION,e4.coef,e1.moyenne as moy_ue,e4.moyenne as moy_module from ESP_MOY_UE_ETUDIANT e1 ,esp_ue e2,ESP_MODULE_PANIER_CLASSE_SAISO e3,ESP_MOY_MODULE_ETUDIANT e4,SOCIETE e5,esp_inscription e7 where e1.id_et ='"+_Id_et+ "' and  e4.ANNEE_DEB=(select max(annee_deb) from societe) and e4.ANNEE_DEB = e3.ANNEE_DEB and e2.ANNEE_DEB = (select max(annee_deb) from societe)and e2.CODE_UE = e1.CODE_UE  and e3.CODE_MODULE = e4.CODE_MODULE  and e4.CODE_UE = e1.CODE_UE and e4.ID_ET = e1.ID_ET AND  e1.id_et!='163JFT0108' and e4.TYPE_MOY = 'P'   and e1.TYPE_MOY = 'P'  and e7.id_et not in ('201JMT1951','201JMT1907','201JMT1913','201JMT1411','201JMT2156','201JFT3503','201JFT2150','201JFT4130','201JMT4591','201JMT1775','201JMT4045','201JMT3486','201JMT1742','201JMT1757','201JMT2687','201JMT0069','201JMT2165','201JMT3040','201JMT3824','201JFT5622','201JMT1731','201JMT3231','201JMT3326','201JMT3667','201JMT4716','201JFT1848','201JFT3554','201JFT3206','201JMT3469','201JFT3391','201JMT3903','201JMT1749','201JMT4505','201JFT5253','201JMT2442','201JMT2185','201JFT4364','201JMT4968','201JMT4519','201JFT3344','201JMT5444','201JFT0245','201JMT1342','201JFT4061','201JMT2028','201JMT3353','201JMT2245','201JMT3416','201JMT2591','201JMT3341','201JMT1993','201JFT4974','201JMT1729','201JMT2611','201JMT2558','201JMT2070','201JFT3016','201JMT4262','201JMT2348','201JMT2935','201JMT4151','201JMT4641','201JMT2794','201JMT4796','201JMT4671','201JMT3852','201JMT4060','201JMT5316','201JMT0829','201JMT0500','201JFT1996','201JMT0115','201JMT0198','201JMT0182','201JMT0181','201JMT0256','201JMT1960','201JMT3140','201JMT2304','201JMT4792','201JMT1764','201JMT1646','201JMT4882','201JME5715','201JMT1940','201JMT1532','201JMT1096','201JMT2013','201JMT2036','201JMT1089','201JMT1870','201JMT2203','201JMT4119','201JFT5389','201JFT4080','201JMT2597','201JMT3158','201JMT2463','201JMT3274','201JMT4549','201JMT3280','201JMT2166','201JMT3594','201JMT3404','201JFE5507','201JMT2723','201JFT3614','201JFT3677','201JMT3032','201JMT0103','201JMT2956','201JMT3578','201JMT2993','201JMT2866','201JMT2902','201JMT3049','201JMT3966','201JMT3963','201JMT3971','201JMT4253','201JMT5026','201JMT3930','201JMT4205','201JMT3919','201JFT4745','201JFT4902','201JMT3961','201JMT3830','201JFT4291','201JMT2895','201JMT3785','201JMT3806','201JFT4150','201JMT3861','201JMT5147','201JMT3638','201JFT4089','201JMT3818','201JMT4489','201JMT1990','201JFT0297','201JMT4710','201JMT4460','201JFT0478','201JMT4487','201JMT4328','201JFT3056','201JMT4414','201JMT4358','201JMT4419','201JMT0027','201JMT2067','201JFT1831','201JFT4317','201JMT1837','201JFT4790','201JMT1399','201JFT1779','201JMT3095','201JFT1467','201JMT1546','201JFT3051','201JMT4597','201JMT4765','201JMT4848','201JMT3940','201JMT3571','201JMT5600','201JMT4104','201JMT2733','201JMT1844','201JMT1477','201JMT3427','201JFT1974','201JMT1263','201JMT0075','201JMT2576','201JMT0825','201JMT2078','201JMT2040','201JMT2407','201JMT2859','201JMT0144','201JMT3104','201JMT3105','201JFT2568','201JMT4819','201JMT4373','201JMT2435','201JMT2656','201JMT1947','201JMT3403','201JMT3298','201JMT3635','201JFT1782','201JFT1609','201JMT3236','201JMT2194','201JMT2022','201JFT4040','201JMT3071','201JMT4215','201JMT3264','201JMT2492','201JMT3647','201JMT1898','201JFT2629','201JFT3699','203JMT5461','203JFT2837','203JMT1252  202SMT2581','203JMT1029','203JMT2386','203JMT5140','203JMT1414','203JMT5492','203JFT1155','203JMT4815','203JMT0935','203JMT1347','203JMT2354','203JMT2292','203JMT0314','203JMT2819','203JMT1276','203JMT0834','203JMT0870','203JFT5530','203JMT5305','203JMT1773','203JFT2704','203JMT0807','203JMT0918','203JFT5342','203JMT1651','203JMT5074','203JMT4851','203JMT0369','203JMT2029','203JMT1861','203JMT1997','203JMT1086','203JFT2345','203JMT0900','203JMT1294','203JFT0219','203JFT1468','203JMT5301','203JFT5462','203JFT3660','203JMT2240','203JMT1768','203JMT2269','203JFT0555','203JFT2843','203JMT4978','203JMT1172','203JFT0907','203JFT0862','203JFT0410','203JMT1424','203JMT2209','203JFT5277','203JMT2235','203JMT5001','203JMT0155','203JFT1231','203JMT2059','203JMT0737','203JMT5516','203JFT0272','203JMT1278','203JMT0933','203JMT4552','203JMT4213','203JMT1217','203JFT2845','203JMT0746','203JMT2513','203JMT0938','203JFT3617','203JFT3595','203JFT3303','203JFT3572','203JME2596','203JFT3294','203JMT4822','203JMT4234','203JMT4619','203JMT3557','203JMT3582','203JMT2533','203JMT3408','203JFT4167','203JFT4585','203JMT3202 204JMT4443','203JMT3795','203JMT2714','203JMT3093','203JMT1879','203JMT3060','203JMT1885','203JFT3038','203JMT1408','203JFT3177','201JMT2901','203JMT1449','203JFT2759','203JMT1415','203JMT0496','203JMT1877','203JFT2807','203JFT2887','203JMT1098','203JMT1101','203JFT0813','203JFT1572','203JFT3967','203JMT1440','203JFT0006','203JFT2706','203JFT0141','203JFT4935','203JFT3528','203JMT3584','203JFT3413','203JMT4886   204JFT1097','203JMT2721','203JMT0810','203JMT2584','203JMT2791','203JMT0441','203JMT0074','203JFT1561','203JMT1001','203JMT2637','203JMT1581','203JMT1510','203JMT2616','203JMT2969','203JMT0064','203JMT2055','203JMT1039','203JMT4888','203JMT4996','203JMT4407','203JMT1037','201SMT0397','203JMT3219','203JFT4931','203JFT2777','203JMT1147','203JMT5289','203JFT4020','203JFT2470','203JFT2594','203JMT4637','203JFT3286','203JFT3319','203JFT4235','203JMT1502','203JFT2098','203JMT5040','203JFT4063','203JMT3536','203JFT1650','203JMT2206','203JMT4536','203JMT3188','203JMT5064','203JMT2566','203JMT5298','203JFT0035','203JFT1388','203JMT4425','203JMT4704 204JMT3352','203JMT4430') and(e1.moyenne IS NOT NULL)  and e4.moyenne is not null and e5.Delib_resultats='O' and  (scoesb02.FS_GET_SOLDE_ETUDIANT_2021('"+_Id_et+"') <= (select MAX_VAL_CREDIT_ACCEPTE from SCOESP09.SOCIETE where annee_deb=2020) or ( e7.MODE_RGLT='99' and e7.DATE_LIM_PROLONG_RGLT>=sysdate)) and e7.id_et=e1.id_et and e1.ANNEE_DEB=(select max(annee_deb) from scoesb02.societe) order by lib_ue";

                //sanssolde
                // string cmdQuery = "select distinct e2.code_ue ,e2.lib_ue,e1.nb_ects, e3.DESIGNATION_NEW as DESIGNATION,e4.coef,e1.moyenne as moy_ue,e4.moyenne as moy_module from ESP_MOY_UE_ETUDIANT e1 ,esp_ue e2,ESP_MODULE_PANIER_CLASSE_SAISO e3,ESP_MOY_MODULE_ETUDIANT e4,SOCIETE e5 where e1.id_et ='" + _Id_et + "' and  e4.ANNEE_DEB=(select max(annee_deb) from societe) and e4.ANNEE_DEB = e3.ANNEE_DEB and e2.ANNEE_DEB = (select max(annee_deb) from societe)and e2.CODE_UE = e1.CODE_UE  and e3.CODE_MODULE = e4.CODE_MODULE  and e4.CODE_UE = e1.CODE_UE and e4.ID_ET = e1.ID_ET AND  e1.id_et!='163JFT0108' and e4.TYPE_MOY = 'P'   and e1.TYPE_MOY = 'P' and e1.id_et not in (select id_et from esp_inscription where annee_deb = (select max(annee_deb) from societe) and reserve = 'O') and(e1.moyenne IS NOT NULL)  and e4.moyenne is not null and e5.Delib_resultats='O'  and e1.ANNEE_DEB=(select max(annee_deb) from scoesb02.societe) order by lib_ue";
                string cmdQuery = "select distinct e2.code_ue ,e2.lib_ue,e1.nb_ects, e3.DESIGNATION_NEW as DESIGNATION,e4.coef,e1.moyenne as moy_ue,e4.moyenne as moy_module from ESP_MOY_UE_ETUDIANT e1 ,esp_ue e2,ESP_MODULE_PANIER_CLASSE_SAISO e3,ESP_MOY_MODULE_ETUDIANT e4,SOCIETE e5 where e1.id_et ='" + _Id_et + "' and  e4.ANNEE_DEB=(select max(annee_deb) from societe) and e4.ANNEE_DEB = e3.ANNEE_DEB and e2.ANNEE_DEB = (select max(annee_deb) from societe)and e2.CODE_UE = e1.CODE_UE  and e3.CODE_MODULE = e4.CODE_MODULE  and e4.CODE_UE = e1.CODE_UE and e4.ID_ET = e1.ID_ET AND  e1.id_et!='163JFT0108' and e4.TYPE_MOY = 'P'   and e1.TYPE_MOY = 'P' and e1.id_et not in (select id_et from esp_inscription where annee_deb = (select max(annee_deb) from societe) and reserve = 'O') and(e1.moyenne IS NOT NULL)  and e4.moyenne is not null  and e5.Delib_resultats='O' and e1.ANNEE_DEB=(select max(annee_deb) from scoesb02.societe) order by lib_ue";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ResultatFinalP>();
                        while (myReader.Read())
                        {
                            myList.Add(new ResultatFinalP(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }
        //public static List<ResultatFinalP> GetResFinal(string _Id_et)
        //{
        //    List<ResultatFinalP> myList = null;

        //    using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
        //    {

        //        mySqlConnection.Open();

        //       // string cmdQuery = " SELECT e2.code_ue ,lib_ue,nb_ects, designation,coef ,e1.moyenne as moy_module,e2.moyenne as moy_ue FROM ESP_V_MOY_MODULE_ETUDIANT_UE e1, ESP_V_MOY_UE_ETUDIANT e2 where   e1.id_et=e2.id_et and e1.annee_deb=(select max (annee_deb)  from societe) AND e2.annee_deb=(select max (annee_deb)  from societe) and e1.code_ue=e2.code_ue and e1.ID_ET='" + _Id_et + "'  and e1.type_moy='P'and e2.type_moy='P'  order by lib_ue ";
        //        string cmdQuery = " SELECT  distinct e2.code_ue ,UPPER(lib_ue) lib_ue,nb_ects, designation,coef ,e1.moyenne as moy_module,e2.moyenne as moy_ue FROM ESP_V_MOY_MODULE_ETUDIANT_UE e1, ESP_V_MOY_UE_ETUDIANT e2 where   e1.id_et=e2.id_et and e1.annee_deb=(select max (annee_deb)  from societe) AND e2.annee_deb=(select max (annee_deb)  from societe) and e1.code_ue=e2.code_ue and e1.ID_ET='" + _Id_et + "'  and e1.type_moy='P'and e2.type_moy='P'  order by lib_ue  ";

        //        OracleCommand myCommand = new OracleCommand(cmdQuery);
        //        myCommand.Connection = mySqlConnection;
        //        myCommand.CommandType = CommandType.Text;

        //        using (OracleDataReader myReader = myCommand.ExecuteReader())
        //        {
        //            if (myReader.HasRows)
        //            {
        //                myList = new List<ResultatFinalP>();
        //                while (myReader.Read())
        //                {
        //                    myList.Add(new ResultatFinalP(myReader));
        //                }
        //            }
        //        }

        //        mySqlConnection.Close();
        //    }
        //    return myList;

        //}
        public ResultatFinalP(OracleDataReader myReader)
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
            if (!myReader.IsDBNull(myReader.GetOrdinal("MOY_UE")))
            {
                mOY_UE = myReader.GetDecimal(myReader.GetOrdinal("MOY_UE"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("MOY_MODULE")))
            {

                mOY_MODULE = myReader.GetDecimal(myReader.GetOrdinal("MOY_MODULE"));
            }
        }
    }
}