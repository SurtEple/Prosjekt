using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace TestMedDBConnect
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnect()
        {
            Initialize();
        }
        private void Initialize()
        {
            string[] connectInfo = System.IO.File.ReadAllLines(@"C:\Users\Martin\Documents\Visual Studio 2013\Projects\TestMedDBConnect\TestMedDBConnect\databasetilkobling.txt");
            server = connectInfo[0];
            database = connectInfo[1];
            uid = connectInfo[2];
            password = connectInfo[3];
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";"+"Convert Zero Datetime=True"+";";
            connection = new MySqlConnection(connectionString);
            

        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch(ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public List<Bruker> selectBruker()
        {
            string query = "Select `Bruker`.`ID`, `Brukernavn`, `Fornavn`, `Mellomnavn`,`Etternavn`, `Epost`, `IM`, `Telefonnr`, `Adresse`, `Postnummer`, `By`, `Stilling`.`Navn` FROM Bruker, Stilling WHERE Stilling_ID = Stilling.ID";
            List<Bruker> list = new List<Bruker>();
            if(this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader["ID"]);
                    string brukernavn = dataReader["Brukernavn"] +"";
                    string fornavn = dataReader["Fornavn"]+"";
                    string mellomnavn = dataReader["Mellomnavn"]+"";
                    string etternavn = dataReader["Etternavn"]+"";
                    string epost = dataReader["Epost"]+"";
                    string im = dataReader["IM"]+"";
                    string telefon = dataReader["Telefonnr"] + "";
                    string adresse = dataReader["Adresse"] + "";
                    string postnr = dataReader["Postnummer"] + "";
                    string by = dataReader["By"] + "";
                    string stilling = dataReader["Navn"] + "";
                    list.Add(new Bruker(id, brukernavn, fornavn, mellomnavn, etternavn, epost, im, telefon, adresse, postnr, by, stilling));
                    

                }
                dataReader.Close();
                this.CloseConnection();
                return list;


            }
            else
            {
                return list;
            }
        }
        public List<Oppgave> selectOppgave()
        {
            List<Oppgave> list = new List<Oppgave>();
            string query = "SELECT c.ID, a.Navn, p.Tittel pt, c.EstimertTid, c.Tittel, c.Beskrivelse, c.Ferdig, c.Brukt_tid, c.Dato_begynt, c.Dato_ferdig\n" +
                                    "FROM Oppgave c, Oppgave p, Prosjekt a\n" +
                                    "WHERE c.Foreldreoppgave_ID = p.ID\n" +
                                    "AND c.Prosjekt_ID = a.ID";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader["ID"]);
                    string prosjekt = dataReader["Navn"] + "";
                    string foreldreOppgave = dataReader["pt"] + "";
                    double estimertTid = Convert.ToDouble(dataReader["EstimertTid"]);
                    string tittel = dataReader["Tittel"] + "";
                    string beskrivelse = dataReader["Beskrivelse"] + "";
                    string ferdig;
                    if (Convert.ToInt32(dataReader["Ferdig"]) == 1)
                        ferdig = "ja";
                    else
                        ferdig = "nei";
                    double bruktTid = Convert.ToDouble(dataReader["Brukt_tid"]);
                    string datoBegynt = dataReader["Dato_begynt"] + "";
                    string datoFerdig = dataReader["Dato_ferdig"] + "";
                    list.Add(new Oppgave(id, prosjekt, foreldreOppgave, estimertTid, tittel, beskrivelse, ferdig, bruktTid, datoBegynt, datoFerdig));

                }
                dataReader.Close();
                this.CloseConnection();
                return list;
            }
            else
                return list;
        }
        public List<Fase> selectFase()
        {
            List<Fase> list = new List<Fase>();
            string query = "SELECT f.ID, f.Navn, f.Dato_startet, f.Dato_sluttet, f.Status, f.Beskrivelse, p.Navn n "
                            +"FROM Fase f, Prosjekt p WHERE f.Prosjekt_ID = p.ID";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader["ID"]);
                    string navn = dataReader["Navn"] + "";
                    string datoStartet = dataReader["Dato_startet"] + "";
                    string datoSluttet = dataReader["Dato_sluttet"] + "";
                    string status = dataReader["Status"] + "";
                    string beskrivelse = dataReader["Beskrivelse"] + "";
                    string prosjekt = dataReader["n"] + "";
                    list.Add(new Fase(id, navn, datoStartet, datoSluttet, status, beskrivelse, prosjekt));
                }
                dataReader.Close();
                this.CloseConnection();
                return list;
            }
            else
                return list;
        }
        public List<Prosjekt> selectProsjekt()
        {
            string query = "SELECT * FROM Prosjekt";
            List<Prosjekt> list = new List<Prosjekt>();
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["ID"]);
                    string navn = dr["Navn"] + "";
                    string oppsummering = dr["Oppsummering"] + "";
                    string nesteFase = dr["Neste_Fase"] + "";
                    list.Add(new Prosjekt(id, navn, oppsummering, nesteFase));
                }
                dr.Close();
                this.CloseConnection();
                return list;
            }
            else
                return list;
        }
        public List<Team> selectTeam()
        {
            List<Team> list = new List<Team>();
            string query = "SELECT `Team`.`ID`, `Bruker`.`ID` bID, `Bruker`.`Fornavn`, `Bruker`.`Mellomnavn`, `Bruker`.`Etternavn`, `Beskrivelse` FROM Team, Bruker "
                    + "WHERE Teamleder = Bruker.ID";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["ID"]);
                    int teamLedId = Convert.ToInt32(dr["bID"]);
                    string teamLeder = dr["Fornavn"] + " " + dr["Mellomnavn"] + " " + dr["Etternavn"];
                    teamLeder = Regex.Replace(teamLeder, @"\s+", " ");
                    string beskrivelse = dr["Beskrivelse"] + "";
                    list.Add(new Team(id, teamLedId, teamLeder, beskrivelse));

                }
                dr.Close();
                this.CloseConnection();
                return list;
            }
            else
                return list;
        }
        public List<Time> selectTime()
        {
            string query = "SELECT `Time`.`ID`, `Fra`, `Til`, `Pause`, `Dato`, `Bruker`.`Fornavn`, `Bruker`.`Etternavn`, `Oppgave`.`Tittel`, `Kommentar`, `Sted`, `Aktiv` "
                    + "FROM Time, Bruker, Oppgave WHERE Bruker_ID = Bruker.ID AND Oppgave_ID = Oppgave.ID";
            List<Time> list = new List<Time>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["ID"]);
                    string fra = dr["Fra"] + "";
                    string til = dr["Til"] + "";
                    string oppgave = dr["Tittel"] + "";
                    string pause = dr["Pause"] + "";
                    string dato = dr["Dato"] + "";
                    string bruker = dr["Fornavn"] + " " + dr["Etternavn"];
                    string kommentar = dr["Kommentar"] + "";
                    string sted = dr["Sted"] + "";
                    string aktiv;
                    if (Convert.ToInt32(dr["Aktiv"]) == 1)
                        aktiv = "Ja";
                    else
                        aktiv = "Nei";
                    list.Add(new Time(id, fra, til, pause, dato, bruker, oppgave, kommentar, sted, aktiv));
                }
                dr.Close();
                this.CloseConnection();
                return list;
            }
            else
                return list;
        }
        public int CheckInnlogging(String brukernavn, String passord)
        {
            //bool check = false;
            int i = -1;
            string salt = null;
            if (this.OpenConnection() == true)
            {
                string query1 = "SELECT Salt FROM Bruker WHERE Brukernavn like " + "'" + brukernavn + "'";
                MySqlCommand cmd = new MySqlCommand(query1, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    salt = dr["Salt"] + "";
                }
                dr.Close();
                string passWord = GetHashString(salt + passord);
                string query2 = "SELECT * FROM Bruker WHERE Passord = " + "'" + passWord + "'";
                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                MySqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    i = Convert.ToInt32(dr2["Administrator"]);
                    
                }
                dr2.Close();
                this.CloseConnection();
                return i;

            }
            else
                return i;
        }
    }
}
