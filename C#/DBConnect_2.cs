using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using MySql.Web;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;

namespace Timeregistreringssystem
{
    class DBConnect
    {
        //variabler
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Konstruktør
        public DBConnect()
        {
            Initialize();
        }

        //Initialiserer verdier og setter opp en kobling til databasen
        private void Initialize()
        {
            server = "kark.hin.no";
            database = "HLVDKN_DB1";
            uid = "halvardk";
            password = "halvardk123";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            //OBS! Vi må finne ut av hvordan vi kan koble oss til databasen uten å hardkode all informasjonen!
            //Det går kanskje an med en configuration file; leste det ett sted.

            connection = new MySqlConnection(connectionString);
        }

        //Metode som åpner tilkoblingen til databasen
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                       // MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Metode som lukker tilkoblingen til databasen
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
              //  MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Metode for å hente ut alle brukerene og legge de til en bindinglist
        public BindingList<Bruker> brukerSelect()
        {
            string query = "SELECT * FROM Bruker";

            BindingList<Bruker> blBrukerListe = new BindingList<Bruker>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    int bruker_id = (int)dataReader["ID"];
                    string bruker_brukernavn = (string)dataReader["Brukernavn"];
                    string bruker_passord = (string)dataReader["Passord"];
                    string bruker_fornavn = (string)dataReader["Fornavn"];
                    string bruker_mellomnavn = (string)dataReader["Mellomnavn"];
                    string bruker_etternavn = (string)dataReader["Etternavn"];
                    string bruker_epost = (string)dataReader["Epost"];
                    string bruker_im = (string)dataReader["IM"];
                    int tmp_telefonnr = (int)dataReader["Telefonnr"];
                    string bruker_telefonnr = Convert.ToString(tmp_telefonnr);
                    string bruker_adresse = (string)dataReader["Adresse"];
                    int tmp_postnr = (int)dataReader["Postnummer"];
                    string bruker_postnr = Convert.ToString(tmp_postnr);
                    string bruker_by = (string)dataReader["By"];


                    Bruker bruker = new Bruker(bruker_id, bruker_brukernavn, bruker_passord, bruker_fornavn, bruker_mellomnavn, bruker_etternavn, bruker_epost, bruker_im, bruker_adresse, bruker_postnr, bruker_telefonnr, bruker_by);
                    blBrukerListe.Add(bruker);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return blBrukerListe;
            }
            else
            {
                return blBrukerListe;
            }
        } //brukerselect


     /**
     * Nytt prosjekt
     * @author Thomas & Thea
    */
    public bool insertProject(String navn, String oppsummering, String nesteFase)
    {
      
        bool check = false;
        int result=0;

        if (this.OpenConnection() == true)
        {
          
            //Create Command
            String insertString = String.Format("INSERT INTO Prosjekt(Navn, Oppsummering, Neste_Fase) VALUES ('{0}','{1}','{2}')", navn, oppsummering, nesteFase);
            MySqlCommand insertCommand = new MySqlCommand(insertString, connection);

            try
            {

                insertCommand.Prepare(); //??
                result = insertCommand.ExecuteNonQuery();
                check = true;
            }
            catch (Exception e)
            {
               
                Debug.WriteLine(e.Message);
                check = false;
            }
            finally
            {
                if (result == 0)
                {
                    insertCommand.Cancel();
                    check = false;

                }

                //close Connection
                this.CloseConnection();
            }

        }
        return check;
    }

    /**
     * Slett prosjekt
     * @author Thomas & Thea
    */   
     public bool delProject(int id)
    {
        String deleteString = String.Format("DELETE FROM Prosjekt WHERE ID = {0}", id);
        bool check = false;
        int result = 0;

        MySqlCommand deleteCommand = new MySqlCommand(deleteString, connection);

        if (this.OpenConnection() == true)
        {
            try
            {
                deleteCommand.Prepare(); //??
                result = deleteCommand.ExecuteNonQuery();

                check = true;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                check = false;
            }
            finally
            {
                if (result == 0)
                {
                    deleteCommand.Cancel();
                    check = false;

                }

                //close Connection
                this.CloseConnection();
            }
            
        }
        return check;
    }//Delete project



/**
* Edit prosjekt
* @author Thomas & Thea
*/
     public bool editProject(int id, String nyttNavn, String nyOppsummering, String nyNesteFase)
     {

         bool check = false;
         int result = 0;

         if (this.OpenConnection() == true)
         {

             //Create Command
          
             String editString = String.Format("UPDATE Prosjekt SET Navn = '{0}', Oppsummering = '{1}', Neste_Fase='{2}' WHERE ID = {3}",
                 nyttNavn, nyOppsummering, nyNesteFase, id);

             MySqlCommand editCommand = new MySqlCommand(editString, connection);

             try
             {

                 editCommand.Prepare(); //??
                 result = editCommand.ExecuteNonQuery();
                 check = true;
             }
             catch (Exception e)
             {

                 Debug.WriteLine(e.Message);
                 check = false;
             }
             finally
             {
                 if (result == 0)
                 {
                     editCommand.Cancel();
                     check = false;

                 }

                 //close Connection
                 this.CloseConnection();
             }

         }
         return check;
     }

  /**
  * Koble Team til Prosjekt
  * @author Thomas & Thea
  */
     public bool connectTeamToProject(int teamID, int prosjektID) 
     { 
         bool check = false;
         int result = 0;

         if (this.OpenConnection() == true)
         {

             //Create Command
             String connectString = String.Format("INSERT INTO KoblingTeamProsjekt(Team_ID, Prosjekt_ID) VALUES ({0}, {1}); ", teamID, prosjektID);

             MySqlCommand connectCommand = new MySqlCommand(connectString, connection);

             try
             {
                 connectCommand.Prepare(); //??
                 result = connectCommand.ExecuteNonQuery();
                 check = true;
             }
             catch (Exception e)
             {
                 Debug.WriteLine(e.Message);
                 check = false;
             }
             finally
             {
                 if (result == 0)
                 {
                     connectCommand.Cancel();
                     check = false;
                 }

                 //close Connection
                 this.CloseConnection();
             }

         }
         
        return check;
     }


    }
}
