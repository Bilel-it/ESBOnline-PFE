using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using System.Data;
using System.Web.UI.WebControls;
using ABSEsprit;


namespace ESPOnline.Enseignants
{
    public class Classenote
    {
   #region sing

        static Classenote instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static Classenote Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Classenote();
                    }

                    return Classenote.instance;
                }
            }

        }
        private Classenote() { }

        #endregion


      
#region getset
        private string dESIGNATION;

public string DESIGNATION
{
  get { return dESIGNATION; }
  set { dESIGNATION = value; }
}
        
      private  string nOM_ENS;

public string NOM_ENS
{
  get { return nOM_ENS; }
  set { nOM_ENS = value; }
}
private string cODE_CL;

private string cODE_MODULE;

public string CODE_MODULE
{
    get { return cODE_MODULE; }
    set { cODE_MODULE = value; }
}

public string CODE_CL
{
  get { return cODE_CL; }
  set { cODE_CL = value; }
}private   decimal  nOTE_CC;

public decimal NOTE_CC
{
  get { return nOTE_CC; }
  set { nOTE_CC = value; }
}
        

    private  decimal   nOTE_TP;

public decimal NOTE_TP
{
  get { return nOTE_TP; }
  set { nOTE_TP = value; }
}
    
     private   decimal  nOTE_EXAM;

public decimal NOTE_EXAM
{
  get { return nOTE_EXAM; }
  set { nOTE_EXAM = value; }
}
    

      private  string  aBSENT_CC;

public string ABSENT_CC
{
  get { return aBSENT_CC; }
  set { aBSENT_CC = value; }
}
   

      private string   aBSENT_TP;

public string ABSENT_TP
{
  get { return aBSENT_TP; }
  set { aBSENT_TP = value; }
}

   
      private string   aBSENT_EXAM;

public string ABSENT_EXAM
{
  get { return aBSENT_EXAM; }
  set { aBSENT_EXAM = value; }
}
    

#endregion


[DataObjectMethod(DataObjectMethodType.Select, true)]
public static List<Classenote> GetListNotes(string _Id_ens)
{
    List<Classenote> myList = null;

    using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
    {

        mySqlConnection.Open();

        string cmdQuery = "select Distinct(CODE_CL) ,code_module   FROM ESP_V_NOTE_SEM1 where ID_ENS='" + _Id_ens + "'  ";
        OracleCommand myCommand = new OracleCommand(cmdQuery);
        myCommand.Connection = mySqlConnection;
        myCommand.CommandType = CommandType.Text;

        using (OracleDataReader myReader = myCommand.ExecuteReader())
        {
            if (myReader.HasRows)
            {
                myList = new List<Classenote>();
                while (myReader.Read())
                {
                    myList.Add(new Classenote(myReader));
                    
                }
            }
        }

        mySqlConnection.Close();
    }
    return myList;

}



public Classenote(OracleDataReader myReader)
        {


             
          

           
    
      
       
      if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_CL")))
      {
          cODE_CL = myReader.GetString(myReader.GetOrdinal("CODE_CL"));


      }

      if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_MODULE")))
      {
          cODE_MODULE = myReader.GetString(myReader.GetOrdinal("CODE_MODULE"));


      }
        }
    }
}