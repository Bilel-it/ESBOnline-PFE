using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using admiss;

namespace DAL
{
   public class LangueDAO
    {
       #region sing
        static LangueDAO instance;
        static Object locker = new Object();
        public static LangueDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new LangueDAO();
                    }

                    return LangueDAO.instance;
                }
            }

        }

        private LangueDAO() { }
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

        public DataTable bind_etud_actif()
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = " select (nom_et ||' ' ||pnom_et ||' ' ||id_et||' ' ||e.NUM_CIN_PASSEPORT) as NOM from esp_etudiant e where lower(e.ETAT)='a' minus select (nom_et ||' ' ||pnom_et ||' ' ||id_et||' ' ||e.NUM_CIN_PASSEPORT) from esp_etudiant e  where lower(e.niveau_courant_fr) like'b2' and lower(e.niveau_courant_ang) like'b2' order by nom";
            
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        public bool verif_exist_note(string idet)
        {
            bool exist = false;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();



                string cmdQuery = " select a.* from ESP_NOTE a, societe b where id_et='" + idet + "' and a.annee_deb=b.annee_deb ";

                OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);

                OracleDataReader MyReader = myCommandAbsence.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    exist = true;

                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
            }

            return exist;
        }

        public string Get_ID_ETUD_scin(string NOM)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select id_et from esp_etudiant e where (e.nom_et ||' ' ||e.pnom_et)  like '" + NOM + "'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

public DataTable Find_TARANSPORT(string id_et)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = " select * from ESP_TRANSPORT_ET where id_et='"+id_et+"'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


        public string Get_DEPT_ENS(string ID_ENS)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select id_dept from esp_enseignant  where id_ens= '" + ID_ENS + "'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


    



        public string Get_ID_ETUD(string NOM)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select id_et from esp_etudiant e where (e.nom_et ||' ' ||e.pnom_et ||' ' ||e.id_et|| ' ' ||e.NUM_CIN_PASSEPORT)  like '" + NOM + "'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }


        public void enreg8transportoui(string id_et, string etat, string ligne)
        {
            //string source = "DATA SOURCE= ;PERSIST SECURITY INFO=True;USER ID=SCOESP09;PASSWORD= tbzr10ep";
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            //  OracleCommand cmd2 = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO scoesb02.ESP_TRANSPORT_ET(ID_ET,ETAT,LIGNE)  VALUES ('" + id_et + "','" + etat + "','" + ligne + "')";

            //  cmd2.CommandText = "INSERT INTO scocs9i.ESP_NIVEAU_LANGUE(ID_ET,Langue,ancien_niveau,NIVEAU_ACTUEL,id_ens)  VALUES ('" + id_et + "','" + langue + "','" + ancien_niv + "','" + niv_act + "','" + id_ens + "')";
            cmd.ExecuteNonQuery();
            //cmd2.ExecuteNonQuery();

        }

        public void enreg8transportnon(string ID_ET, string etat)
        {
            //string source = "DATA SOURCE= ;PERSIST SECURITY INFO=True;USER ID=SCOESP09;PASSWORD= tbzr10ep";
            OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            //  OracleCommand cmd2 = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO scoesb02.ESP_TRANSPORT_ET(ID_ET,ETAT)  VALUES ('" + ID_ET + "','" + etat + "')";

            //  cmd2.CommandText = "INSERT INTO scocs9i.ESP_NIVEAU_LANGUE(ID_ET,Langue,ancien_niveau,NIVEAU_ACTUEL,id_ens)  VALUES ('" + id_et + "','" + langue + "','" + ancien_niv + "','" + niv_act + "','" + id_ens + "')";
            cmd.ExecuteNonQuery();
            //cmd2.ExecuteNonQuery();

        }
       //bind by id
        public DataTable bind_niveau_etudiant(string id_et)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select e.id_et,(nom_et|| ' '||pnom_et) as NOM,e.niveau_courant_ang,e.niveau_courant_fr from esp_etudiant e where e.id_et like '" + id_et + "'and lower(e.etat) like 'a'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }


       //bind by code_cl
        public DataTable bind_niveau_etudiantbycl(string code_cl,string ann_deb)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select a.id_et,(nom_et|| ' '||pnom_et) as NOM,e.niveau_courant_ang,e.niveau_courant_fr from esp_etudiant e inner join esp_inscription a on a.id_et =e.id_et   where a.code_cl like '" + code_cl + "' and lower(e.etat) like 'a' and annee_deb ='" + ann_deb + "' ORDER BY NOM";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }



        public DataTable bind_niveau_fr()
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT  DISTINCT e.niveau_courant_fr FROM ESP_ETUDIANT e where e.niveau_courant_fr !='null'  AND e.niveau_courant_fr !='NN' ORDER BY e.niveau_courant_fr";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            // con.Close();
            return dt;
        }

        public DataTable bind_niveau_ang()
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT  DISTINCT e.niveau_courant_ang FROM ESP_ETUDIANT e where e.niveau_courant_ang !='null' AND  e.niveau_courant_ang !='NN'  ORDER BY e.niveau_courant_ang";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            // con.Close();
            return dt;
        }


       //update niveau en anglais et en français:

        public void Enreg_niv_langue( string id_et, string langue,string niv_act,string ancien_niv,string id_ens)
             {
                 //string source = "DATA SOURCE= ;PERSIST SECURITY INFO=True;USER ID=SCOESB02;PASSWORD= tbzr10ep";
                 OracleConnection conn = new OracleConnection(AppConfiguration.ConnectionString);
                 conn.Open();
                 OracleCommand cmd = conn.CreateCommand();
                 cmd.CommandText = "INSERT INTO ESP_NIVEAU_LANGUE(ID_ET,Langue,ancien_niveau,NIVEAU_ACTUEL,id_ens)  VALUES ('" + id_et + "','" + langue + "','" + ancien_niv + "','" + niv_act + "','" + id_ens + "')";
            
                 cmd.ExecuteNonQuery();
             }

        public string getAncien_niveau_fr(string id_etud)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "select niveau_courant_fr from esp_etudiant where id_et like '"+id_etud+"'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string getAncien_niveau_ang(string id_etud)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "select niveau_courant_ang from esp_etudiant where id_et like '" + id_etud + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

       //LA DERNIERE MODIFICATION EST FAITES DS TABLE ETUDIANT
        public int Update_niv_etud_fr(string id_etud, string niv_fr)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE  esp_ETUDIANT SET NIVEAU_courant_fr ='" + niv_fr + "'  where Id_et='" + id_etud + "'", cn);
            cn.Open();
            return cmd.ExecuteNonQuery();

        }


        public int Update_niv_etud_ang(string id_etud, string niv_fr)
        {
            OracleConnection cn = new OracleConnection(AppConfiguration.ConnectionString);
            OracleCommand cmd = new OracleCommand("UPDATE  esp_ETUDIANT SET NIVEAU_courant_ang ='" + niv_fr + "'  where Id_et='" + id_etud + "'", cn);
            cn.Open();
            return cmd.ExecuteNonQuery();

        }
//**********************************************CHOIX DES CLASSES maha le 10/10/15*****************************************************************

        public DataTable bind_niveau_1516(string ANNEE_DEB)
        {

            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = " select  distinct substr(code_cl,1,1 ) as niveau from esp_inscription where annee_deb='" + ANNEE_DEB + "' and substr(code_cl,1,1 ) in ('1','2','3','4','5') order by niveau  ";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            // con.Close();
            return dt;
        }

        public DataTable bind_classes_1516(string id_ens, string annee_deb)
        {

            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);

            con.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            //cmd.CommandText = "select distinct a.code_cl from esp_inscription a  where a.code_cl like  '" + niv + "%' and a.annee_deb='" + annee_deb + "' order BY fn_tri_classe(a.code_cl) ";
            cmd.CommandText = "select distinct a.code_cl from ESP_MODULE_PANIER_CLASSE_SAISO a where a.id_ens like '"+id_ens+"' AND a.annee_deb='"+annee_deb+"' order BY fn_tri_classe(a.code_cl) ";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            // con.Close();
            return dt;
        }

        public DataTable bind_Nom_Etud(string code_classe, string annee_deb)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            //OracleCommand cmd = new OracleCommand("select ESP_INSCRIPTION.id_et,NOM_ET,PNOM_ET,ESP_INSCRIPTION.CODE_CL,DATE_TEST_ANG from ESP_INSCRIPTION,esp_etudiant,societe,esp_toeic_nb where ESP_INSCRIPTION.id_et=esp_etudiant.id_et and ESP_INSCRIPTION.annee_deb=societe.annee_deb and ETAT_INS_TEST_NIV='Y' and ESP_INSCRIPTION.DATE_TEST_FR=esp_toeic_nb.DATETEST and DATE_TEST_ANG =to_date('" + dateang.ToString() + "', 'dd/mm/yyyy hh24:mi:ss') and code_cl like '5%'", con);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select (nom_et ||' ' ||pnom_et ||' ' ||a.id_et||' ' ||e.NUM_CIN_PASSEPORT) as NOM from esp_etudiant e left join esp_inscription a on a.ID_ET=e.id_et where a.code_cl like '"+code_classe+"' and a.annee_deb='"+annee_deb+"' minus select (nom_et ||' ' ||pnom_et ||' ' ||a.id_et||' ' ||e.NUM_CIN_PASSEPORT) as NOM from esp_etudiant e inner join esp_inscription a on a.ID_ET=e.id_et where a.code_cl like '"+code_classe+"' and a.annee_deb='"+annee_deb+"' and lower(e.niveau_courant_fr) like'b2' and lower(e.niveau_courant_ang) like'b2' ORDER BY NOM";
            //union select 'ALL' from dual
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            // con.Close();
            return dt;
        }
        public DataTable fiche_niveau_langue(string code_class,string annee_deb)
        {

            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = " select  a.id_et,niveau_courant_fr,niveau_courant_ang,(nom_et||' '||pnom_et) as nom from esp_etudiant e inner join esp_inscription a on a.id_et=e.id_et  where  a.code_cl like '"+code_class+"' and a.annee_deb ='"+annee_deb+"'";

            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            // con.Close();
            return dt;
        }

        public DataTable fiche_historique(string id_et)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
           // cmd.CommandText = "Select id_et,Langue,niveau_actuel,Date_niveau,id_ens from esp_niveau_langue where id_et ='" + id_et + "'";
            cmd.CommandText = "Select a.id_et,Langue,niveau_actuel,Date_niveau,nom_ens from esp_niveau_langue a inner join ESP_ENSEIGNANT e on a.id_ens=e.id_ens where a.id_et ='" + id_et + "'";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);

            // con.Close();
            return dt;
        }

       //fiche niveau de langue mpins B2
        public DataTable fiche_niveau_langue_moins_B2(string code_class, string annee_deb)
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = " select  a.id_et,niveau_courant_fr,niveau_courant_ang,(nom_et||' '||pnom_et) as Nom ,a.code_cl from esp_etudiant e inner join esp_inscription a on a.id_et=e.id_et  where  a.code_cl like '"+code_class+"' and a.annee_deb ='"+annee_deb+"' MINUS (select  a.id_et,niveau_courant_fr,niveau_courant_ang,(nom_et||' '||pnom_et) as nom,a.code_cl from esp_etudiant e inner join esp_inscription a on a.id_et=e.id_et where  a.code_cl like '"+code_class+"' and a.annee_deb ='"+annee_deb+"' and lower(niveau_courant_fr) like'b2' and lower(niveau_courant_ang) like 'b2')";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        //Statistique  en français et en anglais
       //fr
        public DataTable Etat_lge_fr()
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = " select Niveau,sum(Niveau_A1) Niveau_A1,sum(Niveau_A2) Niveau_A2,sum(Niveau_B1) Niveau_B1,sum(Niveau_B2) Niveau_B2,sum(Niveau_A1) + sum(Niveau_A2) + sum(Niveau_B1) + sum(Niveau_B2) AS total from (select a.code_cl Classe,sum(case when  lower(e.niveau_courant_FR)='a1'  then 1 else 0 end) as Niveau_A1,sum(case when  lower(e.niveau_courant_FR)='a2' then 1 else 0 end) as Niveau_A2,sum(case when  lower(e.niveau_courant_FR)='b1'   then 1 else 0 end) as Niveau_B1,sum(case when  lower(e.niveau_courant_FR)='b2'   then 1 else 0 end) as Niveau_B2 from scoesb02.ESP_INSCRIPTION a left join scoesb02.ESP_ETUDIANT e on a.id_et=e.id_et left join scoesb02.classes1516 c on a.code_cl = c.code_cl where lower(e.ETAT) ='a' group by a.code_cl) a inner join scoesb02.classes1516 b on a.classe=b.code_cl group by niveau order by niveau";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

        //ang
        public DataTable Etat_lge_ang()
        {
            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = " select Niveau,sum(Niveau_A1) Niveau_A1,sum(Niveau_A2) Niveau_A2,sum(Niveau_B1) Niveau_B1,sum(Niveau_B2) Niveau_B2,sum(Niveau_A1) + sum(Niveau_A2) + sum(Niveau_B1) + sum(Niveau_B2) AS total from (select a.code_cl Classe,sum(case when  lower(e.niveau_courant_ang)='a1'  then 1 else 0 end) as Niveau_A1,sum(case when  lower(e.niveau_courant_ang)='a2' then 1 else 0 end) as Niveau_A2,sum(case when  lower(e.niveau_courant_ang)='b1'   then 1 else 0 end) as Niveau_B1,sum(case when  lower(e.niveau_courant_ang)='b2'   then 1 else 0 end) as Niveau_B2 from scoesb02.ESP_INSCRIPTION a left join scoesb02.ESP_ETUDIANT e on a.id_et=e.id_et left join scoesb02.classes1516 c on a.code_cl = c.code_cl where lower(e.ETAT) ='a' group by a.code_cl) a inner join scoesb02.classes1516 b on a.classe=b.code_cl group by niveau order by niveau";
            OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;
        }

       //get etudiant existe
          public DataTable ETUD_EXIST(string id_et,string langue)
        {

            DataTable dt = new DataTable();
            OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
           // cmd.CommandText = "select * from esp_niveau_langue WHERE ID_ET like '" + id_et + "' and to_date(DATE_NIVEAU)=to_date('" + date+ "', 'dd/mm/yy') and LANGUE='" + langue + "'";
            cmd.CommandText = "select * from esp_niveau_langue WHERE ID_ET like '" + id_et + "' and lower(LANGUE)='" + langue + "'";

              OracleDataAdapter od = new OracleDataAdapter(cmd);
            od.Fill(dt);
            return dt;

        }
       //get class by niveau
          public DataTable bind_classes_parniv(string niv, string annee_deb)
          {

              DataTable dt = new DataTable();
              OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);

              con.Open();

              OracleCommand cmd = new OracleCommand();
              cmd.Connection = con;

              cmd.CommandText = "select distinct a.code_cl from esp_inscription a  where a.code_cl like  '" + niv + "%' and a.annee_deb='" + annee_deb + "' order BY fn_tri_classe(a.code_cl) ";
             // cmd.CommandText = "select distinct a.code_cl from ESP_MODULE_PANIER_CLASSE_SAISO a where a.id_ens like '" + id_ens + "' AND a.annee_deb='" + annee_deb + "' order BY fn_tri_classe(a.code_cl) ";

              OracleDataAdapter od = new OracleDataAdapter(cmd);
              od.Fill(dt);
              // con.Close();
              return dt;
          }

       //get code_classe
          public string get_Code_module(string id_ens)
          {
              string lib = "";

              using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
              {
                  mySqlConnection.Open();
                  string cmdQuery = "select distinct p.CODE_MODULE from ESP_MODULE_PANIER_CLASSE_SAISO p inner join esp_enseignant e on p.ID_ENS =e.ID_ENS where p.ID_ENS ='"+id_ens+"'";
                  OracleCommand myCommand = new OracleCommand(cmdQuery);
                  myCommand.Connection = mySqlConnection;
                  myCommand.CommandType = CommandType.Text;
                  lib = myCommand.ExecuteScalar().ToString();
                  mySqlConnection.Close();
              }
              return lib;
          }

          public DataTable verifier(string id_et,string lge)
          {

              DataTable dt = new DataTable();
            //  string source = "DATA SOURCE= ;PERSIST SECURITY INFO=True;USER ID=SCOESB02;PASSWORD=tbzr10ep ";
              OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
              con.Open();

              OracleCommand cmd = new OracleCommand("select * from ESP_NIVEAU_LANGUE where id_et='" + id_et + "' and upper(LANGUE)='" + lge + "' and to_date(DATE_NIVEAU)=to_date(sysdate,'dd/MM/yy') ", con);

              OracleDataAdapter od = new OracleDataAdapter(cmd);
              od.Fill(dt);

              con.Close();
              return dt;
          }
       
       //update with multiple rows 
        /* OracleCommand cmd = new SqlCommand("UPDATE Customers SET ContactName = @ContactName, Country = @Country WHERE CustomerId = @CustomerId");
                         cmd.Parameters.AddWithValue("@ContactName", row.Cells[1].Controls.OfType<TextBox>().FirstOrDefault().Text);
                         cmd.Parameters.AddWithValue("@Country", row.Cells[2].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);
                         cmd.Parameters.AddWithValue("@CustomerId", gvCustomers.DataKeys[row.RowIndex].Value);
                         this.ExecuteQuery(cmd, "SELECT");*/


       //get ancien niv of student
          public string get_anc_niv_student(string id_eet)
          {
              string lib = "";

              using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
              {
                  mySqlConnection.Open();
                  string cmdQuery = "select NIVEAU_courant_fr from esp_etudiant where id_et like '" + id_eet + "'";
                  OracleCommand myCommand = new OracleCommand(cmdQuery);
                  myCommand.Connection = mySqlConnection;
                  myCommand.CommandType = CommandType.Text;
                  lib = myCommand.ExecuteScalar().ToString();
                  mySqlConnection.Close();
              }
              return lib;
          }

       //get ancien niv ang 

          public string get_anc_niv_studentANG(string id_eet)
          {
              string lib = "";

              using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
              {
                  mySqlConnection.Open();
                  string cmdQuery = "select NIVEAU_courant_ang from esp_etudiant where id_et like '" + id_eet + "'";
                  OracleCommand myCommand = new OracleCommand(cmdQuery);
                  myCommand.Connection = mySqlConnection;
                  myCommand.CommandType = CommandType.Text;
                  lib = myCommand.ExecuteScalar().ToString();
                  mySqlConnection.Close();
              }
              return lib;
          }
       //bind class of cup teachers


          public DataTable bind_classes_1516_cup(string annee_deb)
          {

              DataTable dt = new DataTable();
              OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);

              con.Open();

              OracleCommand cmd = new OracleCommand();
              cmd.Connection = con;

              //cmd.CommandText = "select distinct a.code_cl from esp_inscription a  where a.code_cl like  '" + niv + "%' and a.annee_deb='" + annee_deb + "' order BY fn_tri_classe(a.code_cl) ";
              cmd.CommandText = "select distinct a.code_cl from ESP_MODULE_PANIER_CLASSE_SAISO a where  a.annee_deb='" + annee_deb + "' order BY fn_tri_classe(a.code_cl) ";

              OracleDataAdapter od = new OracleDataAdapter(cmd);
              od.Fill(dt);
              // con.Close();
              return dt;
          }

       //modif code_cl niv//
          public DataTable Consult_list_frform()
          {
              DataTable dt = new DataTable();

              OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
              con.Open();
              OracleCommand cmd = new OracleCommand();
              cmd.Connection = con;
              cmd.CommandText = "select e.nom_et,e.pnom_et,t.ID_ET,e.NIVEAU_COURANT_FR,NIVEAU_COURANT_ANG,CASE t.type_test WHEN 'D' THEN 'Test+formation' WHEN 'T' THEN 'Test' END as type_test,CASE t.type_choix WHEN '1' THEN 'Formation français+test' WHEN '2' THEN 'Formation Anglais+test' WHEN '3' THEN 'Test français' WHEN '4' THEN 'Test anglais' WHEN '5' THEN 'Formation français+anglais+test' WHEN '6' THEN 'Test français+anglais' END as type_choix from ESP_TEST_ETUD t  inner join esp_etudiant e on e.ID_ET=t.id_et where to_date(Date_choix) > TO_DATE('20/12/2015','dd/MM/yy')order by t.TYPE_CHOIX";

              OracleDataAdapter od = new OracleDataAdapter(cmd);
              od.Fill(dt);
              return dt;
          }


          public DataTable Consult_list_PAR_DATE()
          {
              DataTable dt = new DataTable();

              OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
              con.Open();
              OracleCommand cmd = new OracleCommand();
              cmd.Connection = con;
              cmd.CommandText = "select distinct e.nom_et,e.pnom_et,t.ID_ET,e.NIVEAU_COURANT_FR,NIVEAU_COURANT_ANG ,i.CODE_CL,i.annee_deb from ESP_TEST_ETUD t  inner join esp_etudiant e on e.ID_ET=t.id_et  inner join esp_inscription i on t.ID_ET=i.id_et where  (i.ANNEE_DEB='2014' or i.ANNEE_DEB='2015') and code_cl like '5%' and type_choix=0 and code_cl not like '5TIC%' and to_date(t.DATE_CHOIX)=to_date('13/04/16','dd/MM/YY') order by nom_et";
              //"select e.nom_et,e.pnom_et,t.ID_ET,e.NIVEAU_COURANT_FR,NIVEAU_COURANT_ANG,CASE t.type_test WHEN 'D' THEN 'Test+formation' WHEN 'T' THEN 'Test' END as type_test,CASE t.type_choix WHEN '1' THEN 'Formation français+test' WHEN '2' THEN 'Formation Anglais+test' WHEN '3' THEN 'Test français' WHEN '4' THEN 'Test anglais' WHEN '5' THEN 'Formation français+anglais+test' WHEN '6' THEN 'Test français+anglais' END as type_choix from ESP_TEST_ETUD t  inner join esp_etudiant e on e.ID_ET=t.id_et where to_date(Date_choix) > TO_DATE('20/12/2015','dd/MM/yy')order by t.TYPE_CHOIX";

              OracleDataAdapter od = new OracleDataAdapter(cmd);
              od.Fill(dt);
              return dt;
          }



          public DataTable Consult_list_PAR_DATEANG()
          {
              DataTable dt = new DataTable();

              OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
              con.Open();
              OracleCommand cmd = new OracleCommand();
              cmd.Connection = con;
              cmd.CommandText = "select distinct e.nom_et,e.pnom_et,t.ID_ET,e.NIVEAU_COURANT_FR,NIVEAU_COURANT_ANG ,t.DATE_CHOIX,i.CODE_CL,i.annee_deb from ESP_TEST_ETUD t  inner join esp_etudiant e on e.ID_ET=t.id_et  inner join esp_inscription i on t.ID_ET=i.id_et where  (i.ANNEE_DEB='2014' or i.ANNEE_DEB='2015') and code_cl like '5%' and type_choix=0 and code_cl not like '5TIC%' and to_date(t.DATE_CHOIX)=to_date('20/04/16','dd/MM/YY')order by nom_et,i.annee_deb";
              //"select e.nom_et,e.pnom_et,t.ID_ET,e.NIVEAU_COURANT_FR,NIVEAU_COURANT_ANG,CASE t.type_test WHEN 'D' THEN 'Test+formation' WHEN 'T' THEN 'Test' END as type_test,CASE t.type_choix WHEN '1' THEN 'Formation français+test' WHEN '2' THEN 'Formation Anglais+test' WHEN '3' THEN 'Test français' WHEN '4' THEN 'Test anglais' WHEN '5' THEN 'Formation français+anglais+test' WHEN '6' THEN 'Test français+anglais' END as type_choix from ESP_TEST_ETUD t  inner join esp_etudiant e on e.ID_ET=t.id_et where to_date(Date_choix) > TO_DATE('20/12/2015','dd/MM/yy')order by t.TYPE_CHOIX";

              OracleDataAdapter od = new OracleDataAdapter(cmd);
              od.Fill(dt);
              return dt;
          }

      

   }
}
