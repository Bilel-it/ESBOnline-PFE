using ClassLibrary1;
using ESPOnline.Direction.admission;
using MySql.Data.MySqlClient;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI.Export;

namespace ESPOnline.Direction
{
    public partial class dashboard : System.Web.UI.Page
    {
        private MySqlCommand cmd, cmd2;
        private MySqlDataReader reader;
        private DataTable dt,dt2;

      
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["decision"].ToString().Equals("ok"))
                {
                    GridView1.Visible = true; GridView2.Visible = true; GridView3.Visible = true; GridView4.Visible = true; GridView5.Visible = true; GridView6.Visible = true;
                    Button7.Visible = true; Button8.Visible = true; Button9.Visible = true; Button10.Visible = true; Button11.Visible = true; Button12.Visible = true;
                }
            }
            catch { }
        }
        //notes moodles
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    //OracleConnection con = new OracleConnection("DATA SOURCE= 10.0.0.5:1521/dbesb23;PERSIST SECURITY INFO=True;USER ID=admis_esb;PASSWORD=admis1718");
        //    ////   Response.Redirect("https://esprit-tn.com/ESBOnline/Direction/testMysql.aspx");
        //    //cmd = new MySqlCommand("select quiz as id_test ,name as name_test ,substr(email, 1, 4) as user, a.sumgrades as note_candidat from mdl_quiz_attempts a, mdl_user, mdl_quiz where mdl_user.id = a.userid and a.quiz = mdl_quiz.id and quiz in (2465, 2466, 2467, 2468)", moodle_test.getconnection());
        //    OracleConnection con = new OracleConnection("DATA SOURCE= 10.0.0.5:1521/dbesb23;PERSIST SECURITY INFO=True;USER ID=admis_esb;PASSWORD=admis1718");
        //    con.Open();
        //    OracleCommand comm = new OracleCommand("select id_test, name_test, user2, note_candidat from esb_quiz_mmodle", con);
        //    OracleDataReader r = comm.ExecuteReader();
        //    dt = new DataTable();
        //    dt.Load(r);
        //    gridmoodle.DataSource = dt;
        //    gridmoodle.DataBind();
        //   // con.Open();
        //    foreach (GridViewRow GVRow in gridmoodle.Rows)
        //    {
        //        string id_test = GVRow.Cells[0].Text;
        //        string name_test = GVRow.Cells[1].Text;
        //        string user2 = GVRow.Cells[2].Text;
        //        string note_candidat = GVRow.Cells[3].Text;
        //        try
        //        {
        //            //  OracleCommand cmd = new OracleCommand("INSERT INTO moodle2022 t1 (t1.id_test, t1.name_test, t1.user2, t1.note_candidat) VALUES(:id_test,:name_test,:user2,:note_candidat) WHERE NOT EXISTS(SELECT t2.id_test,t2.user2 FROM moodle2022 t2 where t2.id_test=:id_test and t2.user2=:user2  ) ", con);
        //            OracleCommand cmd = new OracleCommand("INSERT INTO moodle2022 t1 (t1.id_test, t1.name_test, t1.user2, t1.note_candidat) VALUES(:id_test,:name_test,:user2,:note_candidat)  ", con);

        //            cmd.Parameters.Add("@id_test", id_test.ToString());
        //            cmd.Parameters.Add("@name_test", name_test.ToString().Replace("&#231;", "ç"));
        //            cmd.Parameters.Add("@user2", user2.ToString());
        //            cmd.Parameters.Add("@note_candidat", note_candidat.ToString().Replace("&nbsp;", null));
        //            cmd.ExecuteNonQuery();
        //        }
        //        //18-07-22
        //        //  int r= cmd.ExecuteNonQuery();
        //        // if (r==0)
        //        catch
        //        {
        //            id_test = GVRow.Cells[0].Text;
        //            name_test = GVRow.Cells[1].Text;
        //            user2 = GVRow.Cells[2].Text;
        //            note_candidat = GVRow.Cells[3].Text;
        //            OracleCommand cmd2 = new OracleCommand("update moodle2022 t1 set t1.name_test=:name_test,  t1.note_candidat=:note_candidat where t1.id_test=:id_test and  t1.user2=:user2 ", con);
        //            cmd2.Parameters.Add("@id_test", id_test.ToString());
        //            cmd2.Parameters.Add("@name_test", name_test.ToString().Replace("&#231;", "ç"));
        //            cmd2.Parameters.Add("@user2", user2.ToString());
        //            cmd2.Parameters.Add("@note_candidat", note_candidat.ToString().Replace("&nbsp;", null));
        //            cmd2.ExecuteNonQuery();

        //        }


        //    }
        //    con.Close();
        //    Response.Write("<script LANGUAGE='JavaScript'> alert('Mise a jour Moodle effectuée')</script>");
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection("DATA SOURCE= 10.0.0.5:1521/dbesb23;PERSIST SECURITY INFO=True;USER ID=admis_esb;PASSWORD=New#Admiesb$23");
            ////   Response.Redirect("https://esprit-tn.com/ESBOnline/Direction/testMysql.aspx");
            //cmd = new MySqlCommand("sELeCt quiz as id_test ,name as name_test ,substr(email, 1, 4) as user, a.sumgrades as note_candidat fRoM mdl_quiz_attempts a, mdl_user, mdl_quiz wHerE mdl_user.id = a.userid and a.quiz = mdl_quiz.id and quiz in (2465, 2466, 2467, 2468)", moodle_test.getconnection());
            //   sELeCt* fRoM *wHerE OWNER = 'NAME_OF_DB'
              cmd = new MySqlCommand("sELeCt quiz as id_test ,name as name_test ,substr(email, 6, 4) as user, a.sumgrades as note_candidat fRoM mdl_quiz_attempts a, mdl_user, mdl_quiz wHerE mdl_user.id = a.userid and a.quiz = mdl_quiz.id and quiz in (2473, 2470, 2471, 2472)", moodle_test.getconnection());



            reader =cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(reader);
            gridmoodle.DataSource = dt;
            gridmoodle.DataBind();
             con.Open();
            foreach (GridViewRow GVRow in gridmoodle.Rows)
            {
                string id_test = GVRow.Cells[0].Text;
                string name_test = GVRow.Cells[1].Text;
                string user2 = GVRow.Cells[2].Text;
                string note_candidat = GVRow.Cells[3].Text;
                try
                {
                    //  OracleCommand cmd = new OracleCommand("INSERT INTO moodle2022 t1 (t1.id_test, t1.name_test, t1.user2, t1.note_candidat) VALUES(:id_test,:name_test,:user2,:note_candidat) WHERE NOT EXISTS(SELECT t2.id_test,t2.user2 FROM moodle2022 t2 where t2.id_test=:id_test and t2.user2=:user2  ) ", con);
                    OracleCommand cmd = new OracleCommand("INSERT INTO moodle2022 t1 (t1.id_test, t1.name_test, t1.user2, t1.note_candidat) VALUES(:id_test,:name_test,:user2,:note_candidat)  ", con);

                    cmd.Parameters.Add("@id_test", id_test.ToString());
                    cmd.Parameters.Add("@name_test", name_test.ToString().Replace("&#231;", "ç"));
                    cmd.Parameters.Add("@user2", user2.ToString());
                    cmd.Parameters.Add("@note_candidat", note_candidat.ToString().Replace("&nbsp;", null));
                    cmd.ExecuteNonQuery();
                }
                //18-07-22
                //  int r= cmd.ExecuteNonQuery();
                // if (r==0)
                catch
                {
                    id_test = GVRow.Cells[0].Text;
                    name_test = GVRow.Cells[1].Text;
                    user2 = GVRow.Cells[2].Text;
                    note_candidat = GVRow.Cells[3].Text;
                    OracleCommand cmd2 = new OracleCommand("update moodle2022 t1 set t1.name_test=:name_test,  t1.note_candidat=:note_candidat where t1.id_test=:id_test and  t1.user2=:user2 ", con);
                    cmd2.Parameters.Add("@id_test", id_test.ToString());
                    cmd2.Parameters.Add("@name_test", name_test.ToString().Replace("&#231;", "ç"));
                    cmd2.Parameters.Add("@user2", user2.ToString());
                    cmd2.Parameters.Add("@note_candidat", note_candidat.ToString().Replace("&nbsp;", null));
                    cmd2.ExecuteNonQuery();

                }


            }
            con.Close();
            Response.Write("<script LANGUAGE='JavaScript'> alert('Mise a jour Moodle effectuée')</script>");
        }

        //score dossier    

        protected void Button4_Click(object sender, EventArgs e)
        {

            string connectionString = "User ID=admis_esb;Password=New#Admiesb$23;Data SOURCE=localhost:1521/orcl";
            OracleConnection connection = new OracleConnection(@connectionString);
          
            OracleCommand cmd = new OracleCommand("select esp_etudiant.ID_ET from esp_etudiant where esp_etudiant.id_et like '23%' minus select esp_score_dossier.ID_ET from esp_score_dossier where score_dossier is not null and esp_score_dossier.id_et like '23%'",connection);
            connection.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(reader);
            //gridmoodle.DataSource = dt;
            //gridmoodle.DataBind();
            connection.Close();
            foreach (DataRow row in dt.Rows)
            {
                string rowValue = row["ID_ET"].ToString();
             

                string query = " insert into esp_score_dossier(id_et, SCORE_DOSSIER) values('" + rowValue + "', FS_GET_SCORE_DOSSIER_ESB2('" + rowValue + "'))";
                OracleCommand command2 = new OracleCommand(query, connection);
               //try
               // {
                   connection.Open();
                   command2.ExecuteNonQuery();
               // }
              //  catch (OracleException e1)
              //  {
                   // Response.Write("<script LANGUAGE='JavaScript'> alert(e1.tostring())</script>");
              //  }
              //  finally
             //   {
                    connection.Close();
              //  }
            }
            Response.Write("<script LANGUAGE='JavaScript'> alert('score dossier calculé: '+'"+dt.Rows.Count+"')</script>");
        }
        //score_finale
        protected void Button2_Click(object sender, EventArgs e)
        {
            string connectionString = "User ID=admis_esb;Password=New#Admiesb$23;Data SOURCE=localhost:1521/orcl";
            OracleConnection connection = new OracleConnection(@connectionString);

            OracleCommand cmd = new OracleCommand("select esp_etudiant.ID_ET from esp_etudiant where esp_etudiant.id_et like '23%' minus select esp_etudiant.ID_ET from esp_etudiant  , score_final_2022 where score_final_2022.ID_ET = esp_etudiant.ID_ET and  esp_etudiant.id_et like '23%'", connection);
            connection.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(reader);
            //gridmoodle.DataSource = dt;
            //gridmoodle.DataBind();
            connection.Close();
            foreach (DataRow row in dt.Rows)
            {
                string rowValue = row["ID_ET"].ToString();
                DAL.EncadDAO.Instance.sf(rowValue);
                //string query = " insert into ADMIS_ESB.score_final_2022(id_et, SCORE_FINAL) values('" + rowValue + "', replace(FS_GET_SCORE_final_ESB('" + rowValue + "'),'.',','))";

                //OracleCommand command2 = new OracleCommand(query, connection);
                //connection.Open();
                //command2.ExecuteNonQuery();
                //connection.Close();

            }
            string query2 = " delete from ADMIS_ESB.score_final_2022 where ADMIS_ESB.score_final_2022.SCORE_FINAL is null";
            OracleCommand command3 = new OracleCommand(query2, connection);
            connection.Open();
            command3.ExecuteNonQuery();
            connection.Close();
          
            Response.Write("<script LANGUAGE='JavaScript'> alert('score final calculé')</script>");

            fn_sf2(sender,e);
            Response.Write("<script LANGUAGE='JavaScript'> alert('sf2 a jour')</script>");

        }

       // transfert scolarite
        public void Button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            string connectionString = "User ID=admis_esb;Password=New#Admiesb$23;Data SOURCE=localhost:1521/orcl";
            OracleConnection connection = new OracleConnection(@connectionString);
            string query = "insert into scoesb02.esp_etudiant e1(ADRESSE_ET, ADRESSE_PARENT, AGENT, ANNEE_BAC, ANNEE_DIPLOME, ANNEE_ENTREE_ESP_ET, BANQUE, CLASSE_COURANTE_ET, CLASSE_PREC_ET, CODE_BARRE, CODE_DECISION_SESSION_P_AP1, CODE_DECISION_SESSION_P_AP2, CODE_DECISION_SESSION_P_AP3, CODE_DECISION_SESSION_R_AP1, CODE_DECISION_SESSION_R_AP2, CODE_DECISION_SESSION_R_AP3, CODE_ETAB_ORIGINE, CODE_NATIONALITE, CODE_SPEC_ORIGINE, COMITE_ID_GRP, CP_ET, CP_PARENT, CYCLE_ET, DATE_BAC, DATE_DELIVRANCE, DATE_DERN_MODIF, DATEENTR, DATE_ENTREE_ESP_ET, DATE_LAST_CHANGE_ETAT, DATE_LIEU_NAIS, DATE_NAIS_ET, DATE_SAISIE, DATE_SORTIE_ET, DERN_UTILISATEUR, DIPLOME_OBTENU_ESP_ET, DIPLOME_SUP_ET, E_MAIL_ET, EMAIL_MERE_ET, E_MAIL_PARENT, EMAIL_PERE_ET, ENS_ID_ENS, ENTRETIEN_ANGLAIS, ENTRETIEN_FRANCAIS, ETAB_BAC, ETAB_ORIGINE, ETAT, FONCTION_ET, FONCTION_MERE_ET, FONCTION_PERE_ET, GOUVERNORAT, ID_ET, ID_ET_NEW, ID_ET_ORIGIN, ID_ET_ORIGINE, JUSTIF_ETAT, LIB_DECISION_SESSION_P_AP1, LIB_DECISION_SESSION_P_AP2, LIB_DECISION_SESSION_P_AP3, LIB_DECISION_SESSION_R_AP1, LIB_DECISION_SESSION_R_AP2, LIB_DECISION_SESSION_R_AP3, LIB_JUSTIF_ETAT, LIB_SPEC_ORIGINE, LIEU_DELIVRANCE, LIEU_NAIS_ET, LOGIN, MOY_BAC, MOY_BAC_ET, MOY_BAC_ET2, MOYENNE_DERN_SEMESTRE_ET, MOY_P_AP1, MOY_P_AP2, MOY_P_AP3, MOY_R_AP1, MOY_R_AP2, MOY_R_AP3, MP08, NATIONALITE, NATURE_BAC, NATURE_COURS, NATURE_ET, NATURE_PIECE_ID, NB_IMP_RELEVE, NIVEAU_ACCES, NIVEAU_COURANT_ET, NIVEAU_DIPLOME_SUP_ET, NOM_ET, NOM_MERE_ET, NOM_PERE_ET, NUM_BAC_ET, NUM_CIN_PASSEPORT, NUMCOMPTE, NUM_ORD, NUMPROMOTIONCS, OBSERVATION_ET, PAYS_ET, PAYS_PARENT, PNOM_ET, RESULTAT_FINAL_ET, RIB_BANQUE, SCORE_FINAL, SEXE, SITUATION_FINANCIERE_ET, SPECIALITE_ESP_ET, TEL_ET, TEL_ET1, TEL_MERE_ET, TEL_PARENT, TEL_PARENT_ET, TEL_PERE_ET, TYPE_ENREG_ET, TYPE_ET, VILLE_ET, VILLE_PARENT)select ADRESSE_ET, ADRESSE_PARENT, AGENT, ANNEE_BAC, ANNEE_DIPLOME, ANNEE_ENTREE_ESP_ET, BANQUE, CLASSE_COURANTE_ET, CLASSE_PREC_ET, CODE_BARRE, CODE_DECISION_SESSION_P_AP1, CODE_DECISION_SESSION_P_AP2, CODE_DECISION_SESSION_P_AP3, CODE_DECISION_SESSION_R_AP1, CODE_DECISION_SESSION_R_AP2, CODE_DECISION_SESSION_R_AP3, CODE_ETAB_ORIGINE, CODE_NATIONALITE, CODE_SPEC_ORIGINE, COMITE_ID_GRP, CP_ET, CP_PARENT, CYCLE_ET, DATE_BAC, DATE_DELIVRANCE, DATE_DERN_MODIF, DATEENTR, DATE_ENTREE_ESP_ET, DATE_LAST_CHANGE_ETAT, DATE_LIEU_NAIS, DATE_NAIS_ET, DATE_SAISIE, DATE_SORTIE_ET, DERN_UTILISATEUR, DIPLOME_OBTENU_ESP_ET, DIPLOME_SUP_ET, E_MAIL_ET, EMAIL_MERE_ET, E_MAIL_PARENT, EMAIL_PERE_ET, ENS_ID_ENS, ENTRETIEN_ANGLAIS, ENTRETIEN_FRANCAIS, ETAB_BAC, ETAB_ORIGINE, 'A' ETAT, FONCTION_ET, FONCTION_MERE_ET, FONCTION_PERE_ET, GOUVERNORAT, substr(trim(id_et), 1, 10), ID_ET_NEW, ID_ET_ORIGIN, ID_ET_ORIGINE, JUSTIF_ETAT, LIB_DECISION_SESSION_P_AP1, LIB_DECISION_SESSION_P_AP2, LIB_DECISION_SESSION_P_AP3, LIB_DECISION_SESSION_R_AP1, LIB_DECISION_SESSION_R_AP2, LIB_DECISION_SESSION_R_AP3, LIB_JUSTIF_ETAT, LIB_SPEC_ORIGINE, 'Tunis', LIEU_NAIS_ET, LOGIN, MOY_BAC, MOY_BAC_ET, MOY_BAC_ET2, MOYENNE_DERN_SEMESTRE_ET, MOY_P_AP1, MOY_P_AP2, MOY_P_AP3, MOY_R_AP1, MOY_R_AP2, MOY_R_AP3, MP08, NATIONALITE, NATURE_BAC, NATURE_COURS, NATURE_ET, NATURE_PIECE_ID, NB_IMP_RELEVE, NIVEAU_ACCES, NIVEAU_ACCES, NIVEAU_DIPLOME_SUP_ET, upper(NOM_ET), NOM_MERE_ET, NOM_PERE_ET, NUM_BAC_ET, NUM_CIN_PASSEPORT, NUMCOMPTE, NUM_ORD, NUMPROMOTIONCS, OBSERVATION_ET, PAYS_ET, PAYS_PARENT, initcap(PNOM_ET), RESULTAT_FINAL_ET, RIB_BANQUE, SCORE_FINAL, SEXE, SITUATION_FINANCIERE_ET, SPECIALITE_ESP_ET, TEL_ET, TEL_ET1, TEL_MERE_ET, TEL_PARENT, TEL_PARENT_ET, TEL_PERE_ET, TYPE_ENREG_ET, TYPE_ET, VILLE_ET, VILLE_PARENT from Admis_Esb.esp_etudiant where code_decision = '01'  and trim(id_et) not in  (select trim(id_et)from scoesb02.esp_etudiant where id_et like '23%') and TRIM(id_et)like '23%'";
          OracleCommand command = new OracleCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                i++; 
            }
            catch (OracleException e1)
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert(e1.tostring())</script>");
            }
            finally
            {
                connection.Close();
                Response.Write("<script LANGUAGE='JavaScript'> alert('transfert reussi :'+'"+i+"')</script>");
            }
            mdp(sender,e);
        }

        public void mdp(object sender, EventArgs e)
        {
          
            string connectionString = "User ID=admis_esb;Password=New#Admiesb$23;Data SOURCE=localhost:1521/orcl";
            OracleConnection connection = new OracleConnection(@connectionString);
            string query = "update scoesb02.esp_etudiant e  set e.pwd_et ='šŒ ÍÏÍÍ' where e.id_et like '23%' and e.pwd_et is null";
            OracleCommand command = new OracleCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
               
            }
            catch (OracleException e1)
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert(e1.tostring())</script>");
            }
            finally
            {
                connection.Close();
                Response.Write("<script LANGUAGE='JavaScript'> alert('pwd !!')</script>");
            }
        }

        public void decision(object sender, EventArgs e)
        {
            string connectionString = "User ID=admis_esb;Password=New#Admiesb$23;Data SOURCE=localhost:1521/orcl";
            OracleConnection connection = new OracleConnection(@connectionString);

            string admis = "select e.ID_ET from ADMIS_ESB.esp_etudiant e, ADMIS_ESB.SCORE_FINAL_2022 f where e.id_et = f.id_et and e.id_et like'23%' and e.CODE_DECISION is null and f.sf2 >= 40";
            OracleCommand cmd = new OracleCommand(admis, connection);
            connection.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(reader);
           
            connection.Close();
            foreach (DataRow row in dt.Rows)
            {
                string rowValue = row["ID_ET"].ToString();
                // string query3 = "update ADMIS_ESB.esp_etudiant set CODE_DECISION='01' where id_et in (select e.ID_ET from ADMIS_ESB.esp_etudiant e, ADMIS_ESB.SCORE_FINAL_2022 f where e.id_et = f.id_et and e.id_et like'22%' and e.CODE_DECISION is null and f.SCORE_FINAL >= 40)";
                string query3 = "update ADMIS_ESB.esp_etudiant set CODE_DECISION='01' where id_et ='"+rowValue+"'";
                OracleCommand command4 = new OracleCommand(query3, connection);
                connection.Open();
                command4.ExecuteNonQuery();
                connection.Close();
              
            }

            //refus

            string refus = "select e.ID_ET from ADMIS_ESB.esp_etudiant e, ADMIS_ESB.SCORE_FINAL_2022 f where e.id_et = f.id_et and e.id_et like'23%' and e.CODE_DECISION is null and f.sf2 < 40";
            OracleCommand cmd2 = new OracleCommand(refus, connection);
            connection.Open();
            OracleDataReader reader2 = cmd2.ExecuteReader();
            dt2 = new DataTable();
            dt2.Load(reader2);

            connection.Close();
            foreach (DataRow row in dt2.Rows)
            {
                string rowValue = row["ID_ET"].ToString();
                // string query3 = "update ADMIS_ESB.esp_etudiant set CODE_DECISION='01' where id_et in (select e.ID_ET from ADMIS_ESB.esp_etudiant e, ADMIS_ESB.SCORE_FINAL_2022 f where e.id_et = f.id_et and e.id_et like'22%' and e.CODE_DECISION is null and f.SCORE_FINAL >= 40)";
                string query3 = "update ADMIS_ESB.esp_etudiant set CODE_DECISION='03' where id_et ='" + rowValue + "'";
                OracleCommand command4 = new OracleCommand(query3, connection);
                connection.Open();
                command4.ExecuteNonQuery();
                connection.Close();

            }
            Response.Write("<script LANGUAGE='JavaScript'> alert('decision -> envoie mail')</script>");
            GridView1.Visible = true; GridView2.Visible = true; GridView3.Visible = true; GridView4.Visible = true; GridView5.Visible = true; GridView6.Visible = true;
            Button7.Visible = true; Button8.Visible = true; Button9.Visible = true; Button10.Visible = true; Button11.Visible = true; Button12.Visible = true;
            Session["decision"] = "ok";
        }

        public void fn_sf2(object sender, EventArgs e)
        {

            
            string connectionString = "User ID=admis_esb;Password=New#Admiesb$23;Data SOURCE=localhost:1521/orcl";
            OracleConnection connection = new OracleConnection(@connectionString);
            OracleCommand cmd2 = new OracleCommand("select id_et,SCORE_FINAL from ADMIS_ESB.score_final_2022 where sf2 is null", connection);
            connection.Open();
            OracleDataReader reader2 = cmd2.ExecuteReader();
            dt2 = new DataTable();
            dt2.Load(reader2);
            //gridmoodle.DataSource = dt;
            //gridmoodle.DataBind();
            connection.Close();

            foreach (DataRow row in dt2.Rows)
            {
                string rowValue = row["ID_ET"].ToString();
               
                string rowValue2 = row["SCORE_FINAL"].ToString().Replace('.', ',');
                DAL.EncadDAO.Instance.sf2(Convert.ToDecimal(rowValue2), rowValue); 
               
                // decimal d = decimal.Parse(rowValue2, CultureInfo.CurrentCulture);
                //  decimal d= decimal.TryParse(rowValue2,out decimal r);
                //  decimal d= Convert.ToDecimal(rowValue2);

                //NumberFormatInfo numberFormatWithComma = new NumberFormatInfo();
                //numberFormatWithComma.NumberDecimalSeparator = ",";
                //decimal d = decimal.Parse(rowValue2);
                //string query = " update ADMIS_ESB.score_final_2022 set sf2='" + d + "' where id_et='" + rowValue + "'";
                //OracleCommand command2 = new OracleCommand(query, connection);
                //connection.Open();
                //command2.ExecuteNonQuery();
                //connection.Close();
            }
        }
        ///licence niv1

        private string PopulateBody(string idi, string nom, string prenom)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Direction/admission/resultat_licenceniv1.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{nom}", nom);
            body = body.Replace("{prenom}", prenom);



            return body;
        }

        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {

                mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "inscription@esprit.tn";
                NetworkCred.Password = "esprit2012";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            Entities1 ctx = new Entities1();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string idi = GridView1.Rows[i].Cells[0].Text;
                string nom = GridView1.Rows[i].Cells[1].Text;
                string prenom = GridView1.Rows[i].Cells[2].Text;
                string body = this.PopulateBody(idi, nom, prenom);
                this.SendHtmlFormattedEmail((GridView1.Rows[i].Cells[3].Text.ToString()).Trim(), "RESULTAT CONCOURS D'ADMISSION ", body);
                var et = ctx.ESP_ETUDIANT.Where(etu => etu.ID_ET.Equals(idi)).FirstOrDefault();
                et.ENVOI_MAIL = "O";
                et.DATE_ADDMISSION = DateTime.Now;
                ctx.SaveChanges();
            }
           
            Response.Redirect("dashboard.aspx");
        }

        ///licence niv2
        private string PopulateBody2(string idi, string nom, string prenom)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Direction/admission/resultat_licenceniv2.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{nom}", nom);
            body = body.Replace("{prenom}", prenom);



            return body;
        }

        private void SendHtmlFormattedEmail2(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {

                mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "inscription@esprit.tn";
                NetworkCred.Password = "esprit2012";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        protected void Button2_Click2(object sender, EventArgs e)
        {
            Entities1 ctx = new Entities1();
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                string idi = GridView2.Rows[i].Cells[0].Text;
                string nom = GridView2.Rows[i].Cells[1].Text;
                string prenom = GridView2.Rows[i].Cells[2].Text;
                string body = this.PopulateBody2(idi, nom, prenom);
                this.SendHtmlFormattedEmail2((GridView2.Rows[i].Cells[3].Text.ToString()).Trim(), "RESULTAT CONCOURS D'ADMISSION ", body);
                var et = ctx.ESP_ETUDIANT.Where(etu => etu.ID_ET.Equals(idi)).FirstOrDefault();
                et.ENVOI_MAIL = "O";
                et.DATE_ADDMISSION = DateTime.Now;
                ctx.SaveChanges();


            }
           
            Response.Redirect("dashboard.aspx");

        }

        ///master niv 4
        private string PopulateBody3(string idi, string nom, string prenom)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Direction/admission/resultat_master_niv4.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{nom}", nom);
            body = body.Replace("{prenom}", prenom);



            return body;
        }

        private void SendHtmlFormattedEmail3(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {

                mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "inscription@esprit.tn";
                NetworkCred.Password = "esprit2012";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        protected void Button3_Click2(object sender, EventArgs e)
        {
            Entities1 ctx = new Entities1();
            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                string idi = GridView3.Rows[i].Cells[0].Text;
                string nom = GridView3.Rows[i].Cells[1].Text;
                string prenom = GridView3.Rows[i].Cells[2].Text;
                string body = this.PopulateBody3(idi, nom, prenom);
                this.SendHtmlFormattedEmail3((GridView3.Rows[i].Cells[3].Text.ToString()).Trim(), "RESULTAT CONCOURS D'ADMISSION ", body);
                var et = ctx.ESP_ETUDIANT.Where(etu => etu.ID_ET.Equals(idi)).FirstOrDefault();
                et.ENVOI_MAIL = "O";
                et.DATE_ADDMISSION = DateTime.Now;
                ctx.SaveChanges();


            }
            Response.Redirect("dashboard.aspx");

        }


        //vermeg
        private string PopulateBody4(string idi, string nom, string prenom)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Direction/admission/resultat_vermeg.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{nom}", nom);
            body = body.Replace("{prenom}", prenom);



            return body;
        }

        private void SendHtmlFormattedEmail4(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {

                mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "inscription@esprit.tn";
                NetworkCred.Password = "esprit2012";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        protected void Button4_Click2(object sender, EventArgs e)
        {
            Entities1 ctx = new Entities1();
            for (int i = 0; i < GridView4.Rows.Count; i++)
            {
                string idi = GridView4.Rows[i].Cells[0].Text;
                string nom = GridView4.Rows[i].Cells[1].Text;
                string prenom = GridView4.Rows[i].Cells[2].Text;
                string body = this.PopulateBody4(idi, nom, prenom);
                this.SendHtmlFormattedEmail4((GridView4.Rows[i].Cells[3].Text.ToString()).Trim(), "RESULTAT CONCOURS D'ADMISSION ", body);
                var et = ctx.ESP_ETUDIANT.Where(etu => etu.ID_ET.Equals(idi)).FirstOrDefault();
                et.ENVOI_MAIL = "O";
                et.DATE_ADDMISSION = DateTime.Now;
                ctx.SaveChanges();
            }
    
            Response.Redirect("dashboard.aspx");
        }

        //internatio

        private string PopulateBody5(string idi, string nom, string prenom)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Direction/admission/resultat_internationaux.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{nom}", nom);
            body = body.Replace("{prenom}", prenom);



            return body;
        }

        private void SendHtmlFormattedEmail5(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {

                mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "inscription@esprit.tn";
                NetworkCred.Password = "esprit2012";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Entities1 ctx = new Entities1();
            for (int i = 0; i < GridView5.Rows.Count; i++)
            {
                string idi = GridView5.Rows[i].Cells[0].Text;
                string nom = GridView5.Rows[i].Cells[1].Text;
                string prenom = GridView5.Rows[i].Cells[2].Text;
                string body = this.PopulateBody5(idi, nom, prenom);
                this.SendHtmlFormattedEmail5((GridView5.Rows[i].Cells[3].Text.ToString()).Trim(), "RESULTAT CONCOURS D'ADMISSION ", body);

                var et = ctx.ESP_ETUDIANT.Where(etu => etu.ID_ET.Equals(idi)).FirstOrDefault();
                et.ENVOI_MAIL = "O";
                et.DATE_ADDMISSION = DateTime.Now;
                ctx.SaveChanges();

            }

            Response.Redirect("dashboard.aspx");
        }
        private string PopulateBody6(string idi, string nom, string prenom)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Direction/admission/refus.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{nom}", nom);
            body = body.Replace("{prenom}", prenom);



            return body;
        }

        private void SendHtmlFormattedEmail6(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {

                mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "inscription@esprit.tn";
                NetworkCred.Password = "esprit2012";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Entities1 ctx = new Entities1();
            for (int i = 0; i < GridView6.Rows.Count; i++)
            {
                string idi = GridView6.Rows[i].Cells[0].Text;
                string nom = GridView6.Rows[i].Cells[1].Text;
                string prenom = GridView6.Rows[i].Cells[2].Text;
                string body = this.PopulateBody6(idi, nom, prenom);
                this.SendHtmlFormattedEmail6((GridView6.Rows[i].Cells[3].Text.ToString()).Trim(), "RESULTAT CONCOURS D'ADMISSION ", body);

                var et = ctx.ESP_ETUDIANT.Where(etu => etu.ID_ET.Equals(idi)).FirstOrDefault();
                et.ENVOI_MAIL = "O";
                et.DATE_ADDMISSION = DateTime.Now;
                ctx.SaveChanges();

            }

            Response.Redirect("dashboard.aspx");
        }






    }
}