using admiss;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class StatMCHOKRIET_MAHA
    {
        #region sing
        static StatMCHOKRIET_MAHA instance;
        static Object locker = new Object();
        public static StatMCHOKRIET_MAHA Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new StatMCHOKRIET_MAHA();
                    }

                    return StatMCHOKRIET_MAHA.instance;
                }
            }

        }

        private StatMCHOKRIET_MAHA() { }
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

        //debut from fikr


        //debut from fikr



        public string nouvInscritsETRTIC1fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='1' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM1fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='1' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc1fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='1' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //2

        public string nouvInscritsETRTIC2fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='2' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM2fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='2' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc2fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='2' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string nouvInscritsETRTIC3fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='3' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM3fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='3' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc3fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='3' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string nouvInscritsETRTIC4fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='4' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM4fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='4' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc4fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='4' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //5

        public string nouvInscritsETRTIC5fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='5' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM5fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='5' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc5fikr(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='5' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scofikr.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }






        //fin


        //fin from fikr




        //debut from esb



        public string nouvInscritsETRTIC1esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='1' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM1esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='1' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc1esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='1' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //2

        public string nouvInscritsETRTIC2esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='2' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM2esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='2' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc2esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='2' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string nouvInscritsETRTIC3esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='3' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM3esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='3' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc3esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='3' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string nouvInscritsETRTIC4esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='4' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM4esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='4' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc4esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='4' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //5

        public string nouvInscritsETRTIC5esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='5' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM5esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='5' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc5esb(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='5' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scoesb02.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }






        //fin



        //debut from prepa


        public string nouvInscritsETRTIC1prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='1' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM1prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='1' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc1prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='1' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //2

        public string nouvInscritsETRTIC2prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='2' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM2prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='2' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc2prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='2' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string nouvInscritsETRTIC3prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='3' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM3prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='3' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc3prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='3' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string nouvInscritsETRTIC4prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='4' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM4prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='4' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc4prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='4' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //5

        public string nouvInscritsETRTIC5prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='5' and e2.SPECIALITE_ESP_ET in ('01','02','05') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM5prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='5' and e2.SPECIALITE_ESP_ET in ('04') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc5prep(string annee, string a, string py)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "'  and code_cl <> '---' and e1.NIVEAU_ACCEES='5' and e2.SPECIALITE_ESP_ET in ('03') and e2.id_et in (select id_et from scoesprep.esp_inscription where annee_deb = '" + py + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }




        //fin

        //fillescS





        public string EGC1TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        
        public string Eetic1TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM1TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //2

        public string EGC2TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('01','02','05' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic2TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('04' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM2TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('03' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //3



        public string EGC3TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('01','02','05') and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic3TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('04' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM3TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('03' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4


        public string EGC4TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('01','02','05') and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic4TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('04' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM4TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('03') and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //5
        public string EGC5TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('01','02','05' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic5TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('04') and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM5TUNcletrfCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from SCOCS9I.esp_inscription e1 ,SCOCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from SCOCS9I.classe where  code_specialite in ('03') and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //filles alternance 



        public string EGC1TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---' and code_cl like '%AL%' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03') and e1.niveau_accees <=5 )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic1TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05') and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM1TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //2

        public string EGC2TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic2TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM2TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //3



        public string EGC3TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic3TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM3TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4


        public string EGC4TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic4TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM4TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04') and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //5
        public string EGC5TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic5TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM5TUNcletrfalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //fille alternance




        //filles cj

        public string EGC1TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic1TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05') and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM1TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04' ) and e1.niveau_accees <=5)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //cj,cs,etr1
        public string EGC1TUNcletrf00(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET from scoesb02.esp_inscription e1, scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "' and e1.NIVEAU_ACCEES = '1' and code_cl <> '---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <= 5 and code_cl  like '%AL%')x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic1TUNcletrf00(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='"+annee+"' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='"+annee+ "' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET from scoesb02.esp_inscription e1, scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "' and e1.NIVEAU_ACCEES = '1' and code_cl <> '---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <= 5 and code_cl  like '%AL%')x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM1TUNcletrf00(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='1' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET from scoesb02.esp_inscription e1, scoesb02.esp_etudiant e2 where e1.id_et = e2.id_et and annee_deb = '" + annee + "' and e1.NIVEAU_ACCEES = '1' and code_cl <> '---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <= 5 and code_cl  like '%AL%')x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //cj,cs,etr2
        public string EGC1TUNcletrf002(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 union all select distinct e1.id_et  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05' ) and e1.niveau_accees <=5))x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic1TUNcletrf002(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5 union all select distinct e1.id_et  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04' ) and e1.niveau_accees <=5))x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM1TUNcletrf002(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();



                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5 union all select distinct e1.id_et  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03' ) and e1.niveau_accees <=5))x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //cj,cs,etr3
        public string EGC1TUNcletrf003(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 union all select distinct e1.id_et  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05' ) and e1.niveau_accees <=5))x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic1TUNcletrf003(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5 union all select distinct e1.id_et  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04' ) and e1.niveau_accees <=5))x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM1TUNcletrf003(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5 union all select distinct e1.id_et  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03' ) and e1.niveau_accees <=5))x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //cj,cs,etr4
        public string EGC1TUNcletrf004(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 union all select distinct e1.id_et  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05' ) and e1.niveau_accees <=5))x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic1TUNcletrf004(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5 union all select distinct e1.id_et  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04' ) and e1.niveau_accees <=5))x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM1TUNcletrf004(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5 union all select distinct e1.id_et  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03' ) and e1.niveau_accees <=5))x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //cj,cs,etr5
        public string EGC1TUNcletrf005(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 union all select distinct e1.id_et  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05' ) and e1.niveau_accees <=5))x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic1TUNcletrf005(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5 union all select distinct e1.id_et  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04' ) and e1.niveau_accees <=5))x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM1TUNcletrf005(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT COUNT(*)FROM (select distinct e1.ID_ET  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---'  and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5 union all select distinct e1.ID_ET  from scocs9i.esp_inscription e1 ,scocs9i.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from scocs9i.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5 union all select distinct e1.id_et  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and code_cl like '%AL%' and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03' ) and e1.niveau_accees <=5))x";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string EGC2TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic2TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM2TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='2' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //3



        public string EGC3TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic3TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM3TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='3' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4


        public string EGC4TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic4TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM4TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='4' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //5
        public string EGC5TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic5TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM5TUNcletrf(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*)  from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.sexe='F'and niveau_accees='5' and  code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where  code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        ////affectes etr  CS


        public string Eetic1TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='1' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        #endregion


        //nouvETR

        public string nouvInscritsETRTIC1(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '1' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM1(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '1' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc1(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '1' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //2

        public string nouvInscritsETRTIC2(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '2' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM2(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '2' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc2(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '2' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string nouvInscritsETRTIC3(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '3' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM3(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '3' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc3(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '3' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string nouvInscritsETRTIC4(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '4' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM4(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '4' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc4(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '4' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //5

        public string nouvInscritsETRTIC5(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '5' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string nouvInscritsETREM5(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '5' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string nouvInscritsETRgc5(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%E%' and code_cl <> '---' and NIVEAU_ACCEES = '5' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //fin

        public string EeM1TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='1' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC1TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='1' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //2
        public string Eetic2TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='2' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM2TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='2' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC2TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='2' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3


        public string Eetic3TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='3' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM3TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='3' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC3TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='3' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4



        public string Eetic4TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='4' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM4TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='4' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC4TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='4' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //5



        public string Eetic5TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='5' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM5TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='5' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC5TUNcletrCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoCS9I.esp_inscription e1 ,scoCS9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='5' and code_cl <>'---' and code_cl in (select code_cl from scoCS9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }




        //*********//





        //debut etr alternance


        public string Eetic1TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM1TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC1TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //2
        public string Eetic2TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM2TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC2TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3


        public string Eetic3TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM3TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC3TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4



        public string Eetic4TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM4TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC4TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //5



        public string Eetic5TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM5TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC5TUNcletralt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }








        //fin

        //affectes etr  CJ
        public string Eetic1TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM1TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC1TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //2
        public string Eetic2TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM2TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC2TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3


        public string Eetic3TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM3TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC3TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4



        public string Eetic4TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM4TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC4TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //5



        public string Eetic5TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EeM5TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC5TUNcletr(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e2.code_nationalite<>'99' and niveau_accees='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }




        //debut nb classe alt





        //fin

        //  //nb classes CS


        public string Eetic1TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM1TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC1TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string Eetic2TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM2TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC2TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string Eetic3TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                // string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='"+annee+"' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='"+annee+"')";

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.classe e2 where e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='3' and e2.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM3TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC3TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string Eetic4TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM4TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC4TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        // 5
        public string Eetic5TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM5TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC5TUNclCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //debut nb classe alternance
        //nb classes CJ

        public string Eetic1TUNclalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "'  and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM1TUNclalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "'  and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC1TUNclalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "'  and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string Eetic2TUNclalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "'  and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM2TUNclalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "'  and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC2TUNclalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "'  and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string Eetic3TUNclalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "'  and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM3TUNclalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "'  and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC3TUNclalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "'  and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string Eetic4TUNclalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "'  and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM4TUNclalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "'  and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC4TUNclalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "'  and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        // 5
        public string Eetic5TUNclalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "'  and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM5TUNclALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "' and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC5TUNclalt(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "'  and code_cl like '%AL%')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //fin

        //nb classes CJ

        public string Eetic1TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('02','03','04') and e3.ANNEE_DEB='"+annee+"' and e2.NIVEAU_ACCEES='1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM1TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('05') and e3.ANNEE_DEB='" + annee + "' and e2.NIVEAU_ACCEES='1'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC1TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";

                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('06') and e3.ANNEE_DEB='" + annee + "' and e2.NIVEAU_ACCEES='1'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string Eetic2TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('02','03','04') and e3.ANNEE_DEB='" + annee + "' and e2.NIVEAU_ACCEES='2'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM2TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //  string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('05') and e3.ANNEE_DEB='" + annee + "' and e2.NIVEAU_ACCEES='2'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC2TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

               // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";

                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('06') and e3.ANNEE_DEB='" + annee + "' and e2.NIVEAU_ACCEES='2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string Eetic3TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('02','03','04') and e3.ANNEE_DEB='" + annee + "' and e2.NIVEAU_ACCEES='3'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM3TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('05') and e3.ANNEE_DEB='" + annee + "' and e2.NIVEAU_ACCEES='3'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC3TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('06') and e3.ANNEE_DEB='" + annee + "' and e2.NIVEAU_ACCEES='3'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string Eetic4TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('02','03','04') and e3.ANNEE_DEB='" + annee + "' and e2.NIVEAU_ACCEES='4'";



                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM4TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";


                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('05') and e3.ANNEE_DEB='" + annee + "' and e2.NIVEAU_ACCEES='4'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC4TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";

                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('06') and e3.ANNEE_DEB='" + annee + "' and e2.NIVEAU_ACCEES='4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        // 5
        public string Eetic5TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01','02','05') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('02','03','04') and e3.ANNEE_DEB='" + annee + "' and e2.NIVEAU_ACCEES='5'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM5TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";

                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('05') and e3.ANNEE_DEB='" + annee + "' and e2.NIVEAU_ACCEES='5'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC5TUNcl(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('06') and e3.ANNEE_DEB='" + annee + "' and e2.NIVEAU_ACCEES='5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        ////affectes nouv et anciens CS











        public string Eetic1TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM1TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC1TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string Eetic2TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM2TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC2TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //3


        public string Eetic3TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM3TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC3TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string Eetic4TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM4TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC4TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //5


        public string Eetic5TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM5TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC5TUNNetcCS(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //affectation nouv et anciens ALternance



        public string Eetic1TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM1TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC1TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string Eetic2TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM2TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC2TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //3


        public string Eetic3TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM3TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC3TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string Eetic4TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM4TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC4TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //5


        public string Eetic5TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM5TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC5TUNNetcALT(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl  like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }






        //affectes nouv et anciens CJ

        public string Eetic1TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string mail_ens(string id_ens)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select trim(mail_ens) from esp_enseignant where id_ens='"+id_ens+"'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }



        public string EeM1TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC1TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string Eetic2TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM2TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC2TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //3


        public string Eetic3TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM3TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC3TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string Eetic4TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM4TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC4TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //5


        public string Eetic5TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM5TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC5TUNNetc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //***//***///

        //Affectés Tunisien


        public string Eetic1TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='1' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM1TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='1' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC1TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='1' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string Eetic2TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='2' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM2TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='2' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC2TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='2' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03')) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string Eetic3TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='3' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM3TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='3' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC3TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='3' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string Eetic4TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='4' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM4TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='4' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC4TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='4' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //5
        public string Eetic5TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='5' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01','02','05'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM5TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='5' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC5TUN(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription where annee_deb='" + annee + "' and id_et like '" + a + "%' and code_cl <>'---' and NIVEAU_ACCEES='5' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03'))";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }




        /// <summary>
        /// ///////////////////
        /// </summary>
        /// <returns></returns>

        //Affectés Non Tunisiens
        public string Eetic1(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "E%'   and SPECIALITE_ESP_ET in ('01','02','05') and NIVEAU_ACCES='1' and id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM1(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "E%'   and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES='1' and id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC1(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "E%'   and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES='1' and id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string Eetic2(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "E%'   and SPECIALITE_ESP_ET in ('01','02','05') and NIVEAU_ACCES='2' and id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM2(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "E%'   and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES='2' and id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC2(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "E%'   and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES='2' and id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string Eetic3(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "E%'   and SPECIALITE_ESP_ET in ('01','02','05') and NIVEAU_ACCES='3' and id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM3(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "E%'   and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES='3' and id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC3(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "E%'   and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES='3' and id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string Eetic4(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "E%'   and SPECIALITE_ESP_ET in ('01','02','05') and NIVEAU_ACCES='4' and id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string EeM4(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "E%'   and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES='4' and id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string EGC4(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "E%'   and SPECIALITE_ESP_ET in ('3') and NIVEAU_ACCES='4' and id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //Enregistrés

        public string etic1(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string etic1CJ(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99'   and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        // 
        public string etic1CS(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '1'";

    OracleCommand myCommand = new OracleCommand(cmdQuery);
    myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
    mySqlConnection.Close();
            }
            return lib;
        }
        public string etic1ETR(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        /// <summary>
        /// ///////////////////ici fin
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>

        public string eM1(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string eM1CJ(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string eM1CS(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string eM1ETR(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string GC1(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string GC1CJ(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string GC1CS(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string GC1ETR(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string etic2(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //cj
        public string etic2cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //cs
        public string etic2cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //etr
        public string eticetr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        /// <summary>
        /// //////////
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>

        public string eM2(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //cj
        public string eM2cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //cs
        public string eM2cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //etr
        public string eM2etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //cj
        public string GC2cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //cs
        public string GC2cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //etr
        public string GC2etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string GC2(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string etic3(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //3 cj
        public string etic3cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //cs
        public string etic3cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //etr
        public string etic3etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string eM3(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //cj
        public string eM3cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //cs

        public string eM3cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //etr

        public string eM3etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string GC3(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //cj

        public string GC3cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //cs

        public string GC3cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //etr

        public string GC3etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //4 

        public string etic4(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string etic4cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string etic4cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string etic4etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string eM4(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string eM4cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string eM4cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string eM4etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string GC4(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //cj
        public string GC4cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string GC4cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string GC4etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //5

        public string etic5(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //cj

        public string etic5cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //cs

        public string etic5cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //etr

        public string etic5etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string eM5(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //cj

        public string eM5cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }



        //cs

        public string eM5cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }



        //etr

        public string eM5etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string GC5(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //cj

        public string GC5cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //cs

        public string GC5cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //etr

        public string GC5etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        // Candidats
        //5

        public string Cetic5(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '5' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM5(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '5' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC5(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '5' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //1
        public string Cetic1(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '1' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM1(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '1' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC1(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '1' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //1 cj


        public string Cetic1cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '1' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM1cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '1' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC1cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '1' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //1 cs

        public string Cetic1cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%'  and SPECIALITE_ESP_ET in ('01','02') and NIVEAU_ACCES = '1' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM1cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%'   and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '1' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC1cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%'   and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '1' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //1 etr

        public string Cetic1etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%'  and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '1' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM1etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%'   and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '1' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC1etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%'   and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '1' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //2

        public string Cetic2(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '2' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '2' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '2' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2 cj

        public string Cetic2cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '2' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '2' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '2' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2cs
        public string Cetic2cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '2' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '2' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '2' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2etr


        public string Cetic2etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '2' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '2' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '2' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //3

        public string Cetic3(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '3' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '3' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '3' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3cj
        public string Cetic3cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '3' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '3' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '3' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3cs
        public string Cetic3cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '3' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '3' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '3' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3etr

        public string Cetic3etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '3' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '3' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '3' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //4

        public string Cetic4(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '4' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '4' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '4' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4cj
        public string Cetic4cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '4' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '4' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4cj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '4' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //4cs

        public string Cetic4cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '4' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '4' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4cs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '4' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //4etr


        public string Cetic4etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '4' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '4' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4etr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '4' and SCORE_ENTRETIEN is not null";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //admis
        //5

        public string Cetic5admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '5' and score_final is not null and code_decision='01'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM5admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '5' and score_final is not null and code_decision='01'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC5admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '5' and score_final is not null and code_decision='01'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //1
        public string Cetic1admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%J%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '1' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM1admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%J%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '1' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC1admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%J%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '1' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //1 cj

        public string Cetic1admiscj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '1' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM1admiscj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '1' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC1admiscj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%J%'  and code_nationalite='99' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '1' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //1 cs
        //1
        public string Cetic1admiscs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('01','02') and NIVEAU_ACCES = '1' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM1admiscs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '1' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC1admiscs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '1' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //1 etr


        //1
        public string Cetic1admisetr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '1' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM1admisetr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '1' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC1admisetr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '1' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string Cetic2admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '2' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '2' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '2' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //2 cj
        public string Cetic2admiscj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '2' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2admiscj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '2' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2admiscj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '2' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //2 cs
        public string Cetic2admiscs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '2' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2admiscs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '2' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2admiscs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '2' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        // 2 etr

        public string Cetic2admisetr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '2' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2admisetr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '2' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2admisetr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '2' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //3

        public string Cetic3admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '3' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '3' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '3' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //3 cj
        public string Cetic3admiscj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '3' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3admiscj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '3' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3admiscj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '3' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //3cs
        public string Cetic3admiscs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '3' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3admiscs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '3' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3admiscs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '3' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //3etr
        public string Cetic3admisetr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '3' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3admisetr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '3' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3admisetr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '3' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string Cetic4admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '4' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '4' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4admis(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '4' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4cj

        public string Cetic4admiscj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '4' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4admiscj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '4' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4admiscj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%J%' and code_nationalite='99'  and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '4' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4cs
        public string Cetic4admiscs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '4' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4admiscs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '4' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4admiscs(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%S%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '4' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4etr
        public string Cetic4admisetr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('01','02','05','07','08','06') and NIVEAU_ACCES = '4' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4admisetr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('04') and NIVEAU_ACCES = '4' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4admisetr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_etudiant where id_et like '" + a + "%E%' and SPECIALITE_ESP_ET in ('03') and NIVEAU_ACCES = '4' and score_final is not null ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //CNA RNV
        public string Cetic1admisrnv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where e1.id_et like '20%' and e1.score_final is not null and e1.NIVEAU_ACCES = '1' and e1.SPECIALITE_ESP_ET  in ('01','02','05','07','08','06') and e1.code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where SOLDE_DS <= 500 and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CeM1admisrnv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where e1.id_et like '" + a + "%' and e1.score_final is not null and e1.NIVEAU_ACCES = '1' and e1.SPECIALITE_ESP_ET  in ('04')  and e1.code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where SOLDE_DS <= 500 and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CGC1admisrnv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where e1.id_et like '" + a + "%' and e1.score_final is not null and e1.NIVEAU_ACCES = '1' and e1.SPECIALITE_ESP_ET  in ('03')  and e1.code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where SOLDE_DS <= 500 and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string Cetic2admisrnv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where SOLDE_DS <= 500 and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2admisrnv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('04')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where SOLDE_DS <= 500 and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2admisrnv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('03')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where SOLDE_DS <= 500 and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string Cetic3admisrnv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where SOLDE_DS <= 500 and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3admisrnv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('04')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where SOLDE_DS <= 500 and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3admisrnv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('03')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where SOLDE_DS <= 500 and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string Cetic4admisrnv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where SOLDE_DS <= 500 and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4admisrnv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('04')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where SOLDE_DS <= 500 and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4admisrnv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('03')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where SOLDE_DS <= 500 and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }



        //CNA RV
        public string Cetic1admisrv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where( SOLDE_DS >500 and  SOLDE_DS <=3500)and IDENTIFIANT_ETUDIANT like '20%' )";
                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where( SOLDE_DS >500 and  SOLDE_DS <=3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CeM1admisrv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('04')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where( SOLDE_DS >500 and  SOLDE_DS <=3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CGC1admisrv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('03')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where( SOLDE_DS >500 and  SOLDE_DS <=3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string Cetic2admisrv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where( SOLDE_DS >500 and  SOLDE_DS <=3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2admisrv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('04')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where( SOLDE_DS >500 and  SOLDE_DS <=3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2admisrv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('03')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where( SOLDE_DS >500 and  SOLDE_DS <=3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string Cetic3admisrv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where( SOLDE_DS >500 and  SOLDE_DS <=3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3admisrv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('04')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where( SOLDE_DS >500 and  SOLDE_DS <=3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3admisrv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('03')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where( SOLDE_DS >500 and  SOLDE_DS <=3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string Cetic4admisrv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where( SOLDE_DS >500 and  SOLDE_DS <=3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4admisrv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('04')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where( SOLDE_DS >500 and  SOLDE_DS <=3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4admisrv(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and score_final is not null and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('03')  and code_decision = '01' and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where( SOLDE_DS >500 and  SOLDE_DS <=3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //PR

        //CNA PR
        public string Cetic1admisrvpr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and id_et not like '" + a + "E%' and score_final is not null and code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06') and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where(  SOLDE_DS >3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CeM1admisrvpr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and id_et not like '" + a + "E%' and score_final is not null and code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('04') and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where(  SOLDE_DS >3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CGC1admisrvpr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and id_et not like '" + a + "E%' and score_final is not null and code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('03') and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where(  SOLDE_DS >3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string Cetic2admisrvpr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and id_et not like '" + a + "E%' and score_final is not null and code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06') and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where(  SOLDE_DS >3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2admisrvpr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and id_et not like '" + a + "E%' and score_final is not null and code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('04') and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where(  SOLDE_DS >3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2admisrvpr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and id_et not like '" + a + "E%' and score_final is not null and code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('03') and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where(  SOLDE_DS >3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string Cetic3admisrvpr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and id_et not like '" + a + "E%' and score_final is not null and code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06') and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where(  SOLDE_DS >3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3admisrvpr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and id_et not like '" + a + "E%' and score_final is not null and code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('04') and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where(  SOLDE_DS >3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3admisrvpr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and id_et not like '" + a + "E%' and score_final is not null and code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('03') and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where(  SOLDE_DS >3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string Cetic4admisrvpr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and id_et not like '" + a + "E%' and score_final is not null and code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06') and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where(  SOLDE_DS >3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4admisrvpr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and id_et not like '" + a + "E%' and score_final is not null and code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('04') and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where(  SOLDE_DS >3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4admisrvpr(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant e1 where id_et like '" + a + "%' and id_et not like '" + a + "E%' and score_final is not null and code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('03') and e1.id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where(  SOLDE_DS >3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //DNR




        public string Cetic1admisrvprdnr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and id_et in (select id_et from scoesb02.esp_inscription  where annee_deb='" + annee + "' and code_cl='---' ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CeM1admisrvprdnr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('04') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and id_et in (select id_et from scoesb02.esp_inscription  where annee_deb='" + annee + "' and code_cl='---' ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CGC1admisrvprdnr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('03') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and id_et in (select id_et from scoesb02.esp_inscription  where annee_deb='" + annee + "' and code_cl='---' ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string Cetic2admisrvprdnr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and id_et in (select id_et from scoesb02.esp_inscription  where annee_deb='" + annee + "' and code_cl='---' ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2admisrvprdnr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('04') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and id_et in (select id_et from scoesb02.esp_inscription  where annee_deb='" + annee + "' and code_cl='---' ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2admisrvprdnr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('03') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and id_et in (select id_et from scoesb02.esp_inscription  where annee_deb='" + annee + "' and code_cl='---' ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string Cetic3admisrvprdnr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and id_et in (select id_et from scoesb02.esp_inscription  where annee_deb='" + annee + "' and code_cl='---' ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3admisrvprdnr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('04') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and id_et in (select id_et from scoesb02.esp_inscription  where annee_deb='" + annee + "' and code_cl='---' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3admisrvprdnr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('03') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and id_et in (select id_et from scoesb02.esp_inscription  where annee_deb='" + annee + "' and code_cl='---' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string Cetic4admisrvprdnr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and id_et in (select id_et from scoesb02.esp_inscription  where annee_deb='" + annee + "' and code_cl='---' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4admisrvprdnr(string annee, string a)
        {
            // string lib = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('04') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and id_et in (select id_et from scoesb02.esp_inscription  where annee_deb='" + annee + "' and code_cl='---' )";
            string lib = "";
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and id_et not like '" + a + "E%' and score_final is not null and code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('04') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_2021 where(  SOLDE_DS >3500)and IDENTIFIANT_ETUDIANT like '20%' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4admisrvprdnr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('03') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and id_et in (select id_et from scoesb02.esp_inscription  where annee_deb='" + annee + "' and code_cl='---' )";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //DR


        public string Cetic1admisrvprdr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CeM1admisrvprdr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('04') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CGC1admisrvprdr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('03') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2

        public string Cetic2admisrvprdr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2admisrvprdr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('04') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2admisrvprdr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('03') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3

        public string Cetic3admisrvprdr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3admisrvprdr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('04') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3admisrvprdr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('03') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4

        public string Cetic4admisrvprdr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4admisrvprdr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('04') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4admisrvprdr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('03') and id_et in (select IDENTIFIANT_ETUDIANT from scoesb02.tmp_solde_etud2 where SOLDE_DS<=-3100 ) and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }





        public string GetNBeNS()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select   count(*) from EMPLOYE@ESPPRIME_PAIE.REGRESS.RDBMS.DEV.US.ORACLE.COM e left join emploi @ESPPRIME_PAIE.REGRESS.RDBMS.DEV.US.ORACLE.COM emp on emp.em_code = e.em_code  left join esp_enseignant ens on trim(ens.code_mat) = trim(e.emp_code) left join esp_dept e2 on e2.CODE_DEPT = ens.CODE_DEPT where pr_code in ('001') and  emp_situation = 'A'  order by e2.CODE_TRIE, up";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //autres stat N2 LAMJED BETTAIEB
        /*****cs/
        /*info*/
        public string Eetic1TUNNetcCSINFO(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('01') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic2TUNNetcCSINFO(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('01') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string Eetic3TUNNetcCSINFO(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('01') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string Eetic4TUNNetcCSINFO(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('01') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic5TUNNetcCSINFO(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('01') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }



        /*tel*/
        public string Eetic1TUNNetcCStel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('02') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNNetcCStel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('02') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic3TUNNetcCStel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('02') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic4TUNNetcCStel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('02') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic5TUNNetcCStel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('02') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        /*EM*/

        public string Eetic1TUNNetcCStEM(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNNetcCStEM(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic3TUNNetcCStEM(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic4TUNNetcCStEM(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic5TUNNetcCSEM(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        /*GC*/

        public string Eetic1TUNNetcCStGC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNNetcCStGC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic3TUNNetcCStGC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic4TUNNetcCStGC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic5TUNNetcCSGC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scocs9I.esp_inscription e1 ,scocs9I.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scocs9I.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        /*****cj**/
        /*tic*/
        public string Eetic1TUNNetcCJTIC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic2TUNNetcCJTIC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string Eetic3TUNNetcCJTIC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string Eetic4TUNNetcCJTIC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic5TUNNetcCJTIC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('05') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        /*info*/
        public string Eetic1TUNNetcCJINFO(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic2TUNNetcCJINFO(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string Eetic3TUNNetcCJINFO(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string Eetic4TUNNetcCJINFO(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic5TUNNetcCJINFO(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('01') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }



        /*tel*/
        public string Eetic1TUNNetcCJtel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('02') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNNetcCJtel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('02') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic3TUNNetcCJtel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('02') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic4TUNNetcCJtel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('02') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic5TUNNetcCJtel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('02') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        /*EM*/

        public string Eetic1TUNNetcCJtEM(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNNetcCJtEM(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic3TUNNetcCJtEM(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic4TUNNetcCJtEM(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic5TUNNetcCJEM(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('04') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        /*GC*/

        public string Eetic1TUNNetcCJtGC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='1' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNNetcCJtGC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='2' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic3TUNNetcCJtGC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='3' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic4TUNNetcCJtGC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='4' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic5TUNNetcCJGC(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from scoesb02.esp_inscription e1 ,scoesb02.esp_etudiant e2 where e1.id_et=e2.id_et and  annee_deb='" + annee + "' and e1.NIVEAU_ACCEES='5' and code_cl <>'---' and code_cl in (select code_cl from scoesb02.classe where code_specialite in ('03') ) and e1.niveau_accees <=5 and code_cl not like '%AL%'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //classe cs
        /*Info*/
        public string Eetic1TUNclCSinfo(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNclCSinfo(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic3TUNclCSinfo(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic4TUNclCSinfo(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic5TUNclCSinfo(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        /*tel*/
        public string Eetic1TUNclCStel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('02') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNclCStel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('02') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic3TUNclCStel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('02') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic4TUNclCStel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('02') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic5TUNclCStel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('02') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        /*em*/
        public string Eetic1TUNclCSem(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNclCSem(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic3TUNclCSem(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic4TUNclCSem(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic5TUNclCSem(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        /*GC*/

        public string Eetic1TUNclCSgc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNclCSgc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic3TUNclCSgc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic4TUNclCSgc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string Eetic5TUNclCSgc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) c_nb_classe from scocs9i.esp_saison_classe e1,scocs9i.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scocs9i.esp_inscription where annee_deb='" + annee + "')";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //Classe CJ

        /*TIC*/
        public string Eetic1TUNclCJtic(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

               // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('02') and e3.ANNEE_DEB='"+annee+"' and e3.NIVEAU_ACCEES='1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNclCJtic(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('02') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic3TUNclCJtic(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('02') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic4TUNclCJtic(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

               // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('02') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic5TUNclCJtic(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('02') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        /*Info*/
        public string Eetic1TUNclCJinfo(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('03') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNclCJinfo(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('03') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic3TUNclCJinfo(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('03') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic4TUNclCJinfo(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('03') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='4'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic5TUNclCJinfo(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('01') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('03') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='5'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        /*tel*/
        public string Eetic1TUNclCJtel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('02') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('04') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='1'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNclCJtel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('02') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('04') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic3TUNclCJtel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

               // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('02') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('04') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic4TUNclCJtel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('02') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";


                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('04') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='4'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic5TUNclCJtel(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('02') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";

                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('04') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='5'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        /*em*/
        public string Eetic1TUNclCJem(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";

                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('05') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='1'";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNclCJem(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('05') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='2'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic3TUNclCJem(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";


                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('05') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='3'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic4TUNclCJem(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('05') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='4'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic5TUNclCJem(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('04') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('05') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='5'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        /*GC*/

        public string Eetic1TUNclCJgc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='1' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('06') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='1'";



                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string Eetic2TUNclCJgc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='2' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('06') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='2'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic3TUNclCJgc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='3' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('06') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='3'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string Eetic4TUNclCJgc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='4' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('06') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='4'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string Eetic5TUNclCJgc(string annee)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                // string cmdQuery = "select count(*) c_nb_classe from scoesb02.esp_saison_classe e1,scoesb02.classe e2 where e1.code_cl=e2.code_cl and annee_deb='" + annee + "' and e2.code_specialite in ('03') and e2.NIVEAU_ACCEES='5' and e1.code_cl in (select distinct code_cl from scoesb02.esp_inscription where annee_deb='" + annee + "')";
                string cmdQuery = "select count(distinct e2.CODE_CL ) c_nb_classe from scoesb02.classe e2,esp_inscription e3 where  e2.code_cl=e3.code_cl and e2.CODE_DEPT in ('06') and e3.ANNEE_DEB='" + annee + "' and e3.NIVEAU_ACCEES='5'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //nouvelle 31/05/2020

        //DR

//CJ 1
        public string Cetic1admisrvprinscritcj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '"+a+"%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CeM1admisrvprinscritcj( string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                //string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '"+annee+"%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper ) ";


                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('04')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CGC1admisrvprinscritcj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('03')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //INSCRIT DV 1
        public string Cetic1admisrvprinscritcs(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and  id_et in (select id_et from scoesb02.esp_inscription where type_insc='I' and annee_deb='"+annee+ "' union (select id_et from scocs9i.esp_inscription where type_insc='I' and annee_deb='" + annee + "') )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CeM1admisrvprinscritcs(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('04')  and  id_et in (select id_et from scoesb02.esp_inscription where type_insc='I' and annee_deb='" + annee + "' union (select id_et from scocs9i.esp_inscription where type_insc='I' and annee_deb='" + annee + "') )   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CGC1admisrvprinscritcs(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('03')  and id_et in (select id_et from scoesb02.esp_inscription where type_insc='I' and annee_deb='" + annee + "' union (select id_et from scocs9i.esp_inscription where type_insc='I' and annee_deb='" + annee + "') )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //etr 1
        public string Cetic1admisrvprinscritetr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CeM1admisrvprinscritetr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and     code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('04')  and   id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string CGC1admisrvprinscritetr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and  code_decision='01' and NIVEAU_ACCES = '1' and SPECIALITE_ESP_ET  in ('03')  and   id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2
        //2cj
        public string Cetic2admisrvprinscritcj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2admisrvprinscritcj( string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('04')  and   id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2admisrvprinscritcj( string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'    and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('03')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //2cs DV INSCRIT

        public string Cetic2admisrvprinscritcs(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and  id_et in (select id_et from scoesb02.esp_inscription where type_insc='I' and annee_deb='" + annee + "' union (select id_et from scocs9i.esp_inscription where type_insc='I' and annee_deb='" + annee + "') )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2admisrvprinscritcs(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%' and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('04')  and id_et in (select id_et from scoesb02.esp_inscription where type_insc='I' and annee_deb='" + annee + "' union (select id_et from scocs9i.esp_inscription where type_insc='I' and annee_deb='" + annee + "') )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2admisrvprinscritcs(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%S%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('03')  and  id_et in (select id_et from scoesb02.esp_inscription where type_insc='I' and annee_deb='" + annee + "' union (select id_et from scocs9i.esp_inscription where type_insc='I' and annee_deb='" + annee + "') )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        //2etr

        public string Cetic2admisrvprinscritetr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM2admisrvprinscritetr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('04')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC2admisrvprinscritetr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '2' and SPECIALITE_ESP_ET  in ('03')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3 cj

        public string Cetic3admisrvprinscritcj(string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'    and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3admisrvprinscritcj( string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('04')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3admisrvprinscritcj( string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('03')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3cs
        public string Cetic3admisrvprinscritcs(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and  id_et in (select id_et from scoesb02.esp_inscription where type_insc='I' and annee_deb='" + annee + "' union (select id_et from scocs9i.esp_inscription where type_insc='I' and annee_deb='" + annee + "') ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3admisrvprinscritcs(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%' and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('04')  and  id_et in (select id_et from scoesb02.esp_inscription where type_insc='I' and annee_deb='" + annee + "' union (select id_et from scocs9i.esp_inscription where type_insc='I' and annee_deb='" + annee + "') )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3admisrvprinscritcs(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('03')  and  id_et in (select id_et from scoesb02.esp_inscription where type_insc='I' and annee_deb='" + annee + "' union (select id_et from scocs9i.esp_inscription where type_insc='I' and annee_deb='" + annee + "') )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //3etr

        public string Cetic3admisrvprinscritetr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM3admisrvprinscritetr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%' and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('04')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC3admisrvprinscritetr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%'  and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '3' and SPECIALITE_ESP_ET  in ('03')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //4 cj

        public string Cetic4admisrvprinscritcj( string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'    and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')   and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4admisrvprinscritcj( string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'     and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('04')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4admisrvprinscritcj( string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'    and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('03')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        //4cs
        public string Cetic4admisrvprinscritcs(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'    and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')   and  id_et in (select id_et from scoesb02.esp_inscription where type_insc='I' and annee_deb='" + annee + "' union (select id_et from scocs9i.esp_inscription where type_insc='I' and annee_deb='" + annee + "') ) ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4admisrvprinscritcs(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'    and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('04')  and id_et in (select id_et from scoesb02.esp_inscription where type_insc='I' and annee_deb='" + annee + "' union (select id_et from scocs9i.esp_inscription where type_insc='I' and annee_deb='" + annee + "') )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4admisrvprinscritcs(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('03')  and id_et in (select id_et from scoesb02.esp_inscription where type_insc='I' and annee_deb='" + annee + "' union (select id_et from scocs9i.esp_inscription where type_insc='I' and annee_deb='" + annee + "') )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        //4etr



        public string Cetic4admisrvprinscritetr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('01','02','05','07','08','06')   and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public string CeM4admisrvprinscritetr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%'    and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('04')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string CGC4admisrvprinscritetr(string annee, string a)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                mySqlConnection.Open();

                string cmdQuery = "select count(*) from admis_esb.esp_etudiant where id_et like '" + a + "%E%'   and score_final is not null and  code_decision='01' and NIVEAU_ACCES = '4' and SPECIALITE_ESP_ET  in ('03')  and  id_et in (select admis_esb.esp_paper.PAPER_ETUDIANT from admis_esb.esp_paper )  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }




    }
}
