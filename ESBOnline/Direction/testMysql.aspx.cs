using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using ClassLibrary1;
using DAL;
using BLL;
using MySql.Data.MySqlClient;
using System.Data;
using Oracle.DataAccess.Client;

namespace ESPOnline.Direction
{
    public partial class testMysql : System.Web.UI.Page
    {
        private MySqlCommand cmd,cmd2;
        private MySqlDataReader reader;
        private DataTable dt;

        OracleConnection con = new OracleConnection("DATA SOURCE= 10.0.0.5:1521/dbesb23;PERSIST SECURITY INFO=True;USER ID=admis_esb;PASSWORD=admis1718");
        protected void Page_Load(object sender, EventArgs e)
        {

            cmd = new MySqlCommand("select quiz as id_test ,name as name_test ,substr(email, 1, 4) as user, a.sumgrades as note_candidat from mdl_quiz_attempts a, mdl_user, mdl_quiz where mdl_user.id = a.userid and a.quiz = mdl_quiz.id and quiz in (2465, 2466, 2467, 2468)", moodle_test.getconnection());
            
            reader = cmd.ExecuteReader();
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
            //Response.Redirect("https://esprit-tn.com/ESBOnline/Direction/dashboard.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            // cmd = new MySqlCommand("select quiz as id_test ,name as name_test ,substr(email, 1, 4) as user, a.sumgrades as note_candidat from mdl_quiz_attempts a, mdl_user, mdl_quiz where mdl_user.id = a.userid and a.quiz = mdl_quiz.id and quiz in (2465, 2466, 2467, 2468)", moodle_test.getconnection());
            //  cmd2 = new MySqlCommand("INSERT INTO moodle2022 (id_test, name_test, user2, note_candidat) VALUES(select quiz as id_test  from mdl_quiz_attempts a, mdl_user, mdl_quiz where mdl_user.id = a.userid and a.quiz = mdl_quiz.id and quiz in (2465, 2466, 2467, 2468),select name as name_test from mdl_quiz_attempts a, mdl_user, mdl_quiz where mdl_user.id = a.userid and a.quiz = mdl_quiz.id and quiz in (2465, 2466, 2467, 2468),select substr(email, 1, 4) as user from mdl_quiz_attempts a, mdl_user, mdl_quiz where mdl_user.id = a.userid and a.quiz = mdl_quiz.id and quiz in (2465, 2466, 2467, 2468),select a.sumgrades as note_candidat from mdl_quiz_attempts a, mdl_user, mdl_quiz where mdl_user.id = a.userid and a.quiz = mdl_quiz.id and quiz in (2465, 2466, 2467, 2468)) ", moodle_test.getconnection());
            //cmd2 = new MySqlCommand("INSERT INTO moodle2022 (id_test, name_test, user2, note_candidat) VALUES(select quiz as id_test  from mdl_quiz_attempts a, mdl_user, mdl_quiz where mdl_user.id = a.userid and a.quiz = mdl_quiz.id and quiz in (2465, 2466, 2467, 2468),select name as name_test from mdl_quiz_attempts a, mdl_user, mdl_quiz where mdl_user.id = a.userid and a.quiz = mdl_quiz.id and quiz in (2465, 2466, 2467, 2468),select substr(email, 1, 4) as user from mdl_quiz_attempts a, mdl_user, mdl_quiz where mdl_user.id = a.userid and a.quiz = mdl_quiz.id and quiz in (2465, 2466, 2467, 2468),select a.sumgrades as note_candidat from mdl_quiz_attempts a, mdl_user, mdl_quiz where mdl_user.id = a.userid and a.quiz = mdl_quiz.id and quiz in (2465, 2466, 2467, 2468)) ", moodle_test.getconnection());
            //reader = cmd2.ExecuteReader();
            //dt = new DataTable();
            //dt.Load(reader);
            //gridmoodle.DataSource = dt;
            //gridmoodle.DataBind();

            OracleCommand cmd = new OracleCommand("INSERT INTO moodle2022 (id_test, name_test, user2, note_candidat) VALUES(0,0,0,0) ",con);

            cmd.Connection = con;


            cmd.ExecuteNonQuery();

        }   
    }
}