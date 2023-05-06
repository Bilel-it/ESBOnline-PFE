using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using System.Data;
using ABSEsprit;

namespace ESPOnline
{
    public class Class1
    {

          #region sing

        static Class1 instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static Class1 Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Class1();
                    }

                    return Class1.instance;
                }
            }

        }
        private Class1() { }

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

     private   decimal  nOTE_CC;

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
public static List<Class1> GetListNotes(string _Id_et)
{
    List<Class1> myList = null;

    using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
    {

        mySqlConnection.Open();
        string azerty = "select  ESP_NOTE.CODE_MODULE,ESP_NOTE.ID_ET,"+
       " ESP_NOTE.CODE_CL,ESP_MODULE.DESIGNATION,"+
         "ESP_ENSEIGNANT.ID_ENS,ESP_ENSEIGNANT.NOM_ENS,"+
        " ESP_NOTE.NOTE_CC,ESP_NOTE.NOTE_TP,ESP_NOTE.NOTE_EXAM,"+
        " ESP_NOTE.ABSENT_CC,ESP_NOTE.ABSENT_TP,"+
        " ESP_NOTE.ABSENT_EXAM FROM ESP_ENSEIGNANT,ESP_MODULE,ESP_NOTE"+
  " WHERE ( ESP_MODULE.CODE_MODULE = ESP_NOTE.CODE_MODULE ) and ( esp_note.id_ens = esp_enseignant.id_ens (+))  and ESP_NOTE.Annee_Deb like '2013' and ESP_NOTE.ID_ET='" + _Id_et + "'  order by ESP_MODULE.DESIGNATION";

        string azerty1 = "select  ESP_NOTE.CODE_MODULE," +
       " ESP_NOTE.ID_ET,"+
       " ESP_NOTE.CODE_CL,"+
        " ESP_MODULE.DESIGNATION,"+
        " ESP_ENSEIGNANT.ID_ENS,"+
        " ESP_ENSEIGNANT.NOM_ENS,"+
        " ESP_NOTE.NOTE_CC,"+
        " ESP_NOTE.NOTE_TP,"+
        " ESP_NOTE.NOTE_EXAM,"+
        " ESP_NOTE.ABSENT_CC,"+
        " ESP_NOTE.ABSENT_TP,"+
        " ESP_NOTE.ABSENT_EXAM"+
 " FROM ESP_ENSEIGNANT,ESP_MODULE, ESP_NOTE"+
  " WHERE ( ESP_MODULE.CODE_MODULE = ESP_NOTE.CODE_MODULE ) and"+
"ESP_NOTE.ID_ET='" + _Id_et + "' "+
         " and ( esp_note.id_ens = esp_enseignant.id_ens (+)) and"+
      " (annee_deb=(select max(annee_deb) from societe)) and"+
        "( id_et not in (select id_et from esp_inscription"+
		"where annee_deb=(select max(annee_deb) from societe) and reserve='O'))";


        string cmdQuery = azerty;
        OracleCommand myCommand = new OracleCommand(cmdQuery);
        myCommand.Connection = mySqlConnection;
        myCommand.CommandType = CommandType.Text;

        using (OracleDataReader myReader = myCommand.ExecuteReader())
        {
            if (myReader.HasRows)
            {
                myList = new List<Class1>();
                while (myReader.Read())
                {
                    myList.Add(new Class1(myReader));
                }
            }
        }

        mySqlConnection.Close();
    }
    return myList;

}



public Class1(OracleDataReader myReader)
        {


            if (!myReader.IsDBNull(myReader.GetOrdinal("DESIGNATION")))
            {

                dESIGNATION = myReader.GetString(myReader.GetOrdinal("DESIGNATION"));
            }


            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_ENS")))
            {
                nOM_ENS = myReader.GetString(myReader.GetOrdinal("NOM_ENS"));


            }

           if (!myReader.IsDBNull(myReader.GetOrdinal("NOTE_CC")))
            {
                nOTE_CC = myReader.GetDecimal(myReader.GetOrdinal("NOTE_CC"));


            }
     if (!myReader.IsDBNull(myReader.GetOrdinal("NOTE_TP")))
            {
                nOTE_TP = myReader.GetDecimal(myReader.GetOrdinal("NOTE_TP"));


            }
     if (!myReader.IsDBNull(myReader.GetOrdinal("NOTE_EXAM")))
            {
                nOTE_EXAM = myReader.GetDecimal(myReader.GetOrdinal("NOTE_EXAM"));


            }
      if (!myReader.IsDBNull(myReader.GetOrdinal("ABSENT_CC")))
            {
                aBSENT_CC = myReader.GetString(myReader.GetOrdinal("ABSENT_CC"));


            }
      if (!myReader.IsDBNull(myReader.GetOrdinal("ABSENT_TP")))
            {
                aBSENT_TP = myReader.GetString(myReader.GetOrdinal("ABSENT_TP"));


            }
      if (!myReader.IsDBNull(myReader.GetOrdinal("ABSENT_EXAM")))
      {
          aBSENT_EXAM = myReader.GetString(myReader.GetOrdinal("ABSENT_EXAM"));


      }


        }

#region
//List<string> verif = new List<string>(new string[]
//    {
//        
//        "amazon",     // River 2
//        "yangtze",    // River 3
//        "mississippi",
//        "yellow"
//    });

#region
//List<string> verif = new List<string>(new string[]
//    {
//        
//        "amazon",     // River 2
//        "yangtze",    // River 3
//        "mississippi",
//        "yellow"
//    });//List<string> verif = new List<string>(new string[]
//    {
//        
//        "amazon",     // River 2
//        "yangtze",    // River 3
//        "mississippi",
//        "yellow"
//    });
#region
//List<string> verif = new List<string>(new string[]
//    {
//        
//        "amazon",     // River 2
//        "yangtze",    // River 3
//        "mississippi",
//        "yellow"
//    });//List<string> verif = new List<string>(new string[]
//    {
//        
//        "amazon",     // River 2
//        "yangtze",    // River 3
//        "mississippi",
//        "yellow"
//    });
public bool verify(string verf)
{
    var list = new List<string>();


    // 2. Search for this element.
    if (list.Contains(verf))
    {
        return false;
    }
    else return true;
}
        //List<string> verif = new List<string>(new string[]
        //    {
        //        
        //        "amazon",     // River 2
        //        "yangtze",    // River 3
        //        "mississippi",
        //        "yellow"
        //    });//List<string> verif = new List<string>(new string[]
        //    {
        //        
        //        "amazon",     // River 2
        //        "yangtze",    // River 3
        //        "mississippi",
        //        "yellow"
        //    });//List<string> verif = new List<string>(new string[]
        //    {
        //        
        //        "amazon",     // River 2
        //        "yangtze",    // River 3
        //        "mississippi",
        //        "yellow"
        //    });
#endregion

        //List<string> verif = new List<string>(new string[]
        //    {
        //        
        //        "amazon",     // River 2
        //        "yangtze",    // River 3
        //        "mississippi",
        //        "yellow"
        //    });//List<string> verif = new List<string>(new string[]
        //    {
        //        
        //        "amazon",     // River 2
        //        "yangtze",    // River 3
        //        "mississippi",
        //        "yellow"
        //    });//List<string> verif = new List<string>(new string[]
        //    {
        //        
        //        "amazon",     // River 2
        //        "yangtze",    // River 3
        //        "mississippi",
        //        "yellow"
        //    });
#endregion

        //List<string> verif = new List<string>(new string[]
        //    {
        //        
        //        "amazon",     // River 2
        //        "yangtze",    // River 3
        //        "mississippi",
        //        "yellow"
        //    });//List<string> verif = new List<string>(new string[]
        //    {
        //        
        //        "amazon",     // River 2
        //        "yangtze",    // River 3
        //        "mississippi",
        //        "yellow"
        //    });//List<string> verif = new List<string>(new string[]
        //    {
        //        
        //        "amazon",     // River 2
        //        "yangtze",    // River 3
        //        "mississippi",
        //        "yellow"
        //    });
#endregion
    }
}