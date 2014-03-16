using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Timeregistreringssystem;
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
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
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
            string query = "Select b.ID, b.Brukernavn, b.Fornavn, b.Mellomnavn, b.Etternavn, b.Epost, b.IM, b.Telefonnr, b.Adresse, b.Postnummer, b.By, s.Navn FROM Bruker b, Stilling s WHERE b.Stilling_ID = s.ID";
            List<Bruker> list = new List<Bruker>();
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader["ID"]);
                    string brukernavn = dataReader["Brukernavn"] + "";
                    string fornavn = dataReader["Fornavn"] + "";
                    string mellomnavn = dataReader["Mellomnavn"] + "";
                    string etternavn = dataReader["Etternavn"] + "";
                    string epost = dataReader["Epost"] + "";
                    string im = dataReader["IM"] + "";
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
            string query = "SELECT c.ID, a.Navn, p.Tittel, c.EstimertTid, c.Tittel, c.Beskrivelse, c.Ferdig, c.Brukt_tid, c.Dato_begynt, c.Dato_ferdig\n" +
                                    "FROM Oppgave c, Oppgave p, Prosjekt a\n" +
                                    "WHERE c.Foreldreoppgave_ID = p.ID\n" +
                                    "AND c.Prosjekt_ID = a.ID";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader["c.ID"]);
                    string prosjekt = dataReader["a.Navn"] + "";
                    string foreldreOppgave = dataReader["p.Tittel"] + "";
                    double estimertTid = Convert.ToDouble(dataReader["c.EstimertTid"]);
                    string tittel = dataReader["c.Tittel"] + "";
                    string beskrivelse = dataReader["c.Beskrivelse"] + "";
                    string ferdig;
                    if (Convert.ToInt32(dataReader["c.Ferdig"]) == 1)
                        ferdig = "ja";
                    else
                        ferdig = "nei";
                    double bruktTid = Convert.ToDouble(dataReader["c.Brukt_tid"]);
                    string datoBegynt = dataReader["c.Dato_begynt"] + "";
                    string datoFerdig = dataReader["c.Dato_ferdig"] + "";
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
            string query = "SELECT `Fase`.`ID`, `Fase`.`Navn`, `Dato_startet`, `Dato_sluttet`, `Status`, `Beskrivelse`, `Prosjekt`.`Navn` "
                    + "FROM Fase, Prosjekt WHERE Prosjekt_ID = Prosjekt.ID";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader["Fase.ID"]);
                    string navn = dataReader["Fase.Navn"] + "";
                    string datoStartet = dataReader["Dato_startet"] + "";
                    string datoSluttet = dataReader["Dato_sluttet"] + "";
                    string status = dataReader["Status"] + "";
                    string beskrivelse = dataReader["Beskrivelse"] + "";
                    string prosjekt = dataReader["Prosjekt.Navn"] + "";
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
            string query = "SELECT `Team`.`ID`, `Bruker`.`ID`, `Bruker`.`Fornavn`, `Bruker`.`Mellomnavn`, `Bruker`.`Etternavn`, `Beskrivelse` FROM Team, Bruker "
                    + "WHERE Teamleder = Bruker.ID";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["Team.ID"]);
                    int teamLedId = Convert.ToInt32(dr["Bruker.ID"]);
                    string teamLeder = dr["Bruker.Fornavn"] + " " + dr["Bruker.Mellomnavn"] + " " + dr["Bruker.Etternavn"];
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
                    int id = Convert.ToInt32(dr["Time.ID"]);
                    string fra = dr["Fra"] + "";
                    string til = dr["Til"] + "";
                    string oppgave = dr["Oppgave.Tittel"] + "";
                    string pause = dr["Pause"] + "";
                    string dato = dr["Dato"] + "";
                    string bruker = dr["Bruker.Fornavn"] + " " + dr["Bruker.Etternavn"];
                    string kommentar = dr["Kommentar"] + "";
                    string sted = dr["Sted"] + "";
                    string aktiv;
                    if (Convert.ToInt32(dr["Aktiv"]) == 1)
                        aktiv = "ja";
                    else
                        aktiv = "nei";
                    list.Add(new Time(id, fra, til, pause, dato, bruker, oppgave, kommentar, sted, aktiv));
                }
                dr.Close();
                this.CloseConnection();
                return list;
            }
            else
                return list;
        }
        public bool CheckInnlogging(String brukernavn, String passord)
        {
            bool check = false;
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
                    check = true;
                    
                }
                dr2.Close();
                this.CloseConnection();
                return check;

            }
            else
                return check;
        }
        public string GetSalt()
        {
            Random r = new Random();
            byte[] salt = new byte[5];
            r.NextBytes(salt);
            StringBuilder sb = new StringBuilder(2 * salt.Length);
            foreach (byte b in salt)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();  // SHA1.Create()
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }
		
		public bool InsertTeam(Team t)
        {
            bool check = false;

            if (this.OpenConnection() == true)
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement
                    command.CommandText =
                        "INSERT INTO Team (ID, Teamleder, Beskrivelse) " +
                        "VALUES (@id, @teamleder, @beskrivelse)";

                    MySqlParameter idParam = new MySqlParameter("@id", MySqlDbType.Int32, 11);
                    MySqlParameter teamlederParam = new MySqlParameter("@teamleder", MySqlDbType.Int32, 11);
                    MySqlParameter beskrivelseParam = new MySqlParameter("@beskrivelse", MySqlDbType.Text);

                    idParam.Value = t.Id;
                    beskrivelseParam.Value = t.Beskrivelse;
                    teamlederParam.Value = t.TeamLederId;

                    command.Parameters.Add(idParam);
                    command.Parameters.Add(teamlederParam);
                    command.Parameters.Add(beskrivelseParam);

                    command.Prepare();
                    command.ExecuteNonQuery();
                    check = true;
                }
                catch
                {
                    check = false;
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            return check;
        }
		
		// Setter valgt bruker til å være team-leder
        public bool setTeamLeder(int id)
        {
            bool check = false;
            int result = 0;

            // Åpner tilkoblingen til databasen
            if (this.OpenConnection() == true)
            {
                
                // Kommando for å oppdatere valgt bruker til Stilling_ID 4 - leder
                String oppdatering = String.Format("UPDATE Bruker SET Stilling_ID = 4 WHERE ID = {0}",
                    id);

                MySqlCommand oppdateringsCommand = new MySqlCommand(oppdatering, connection);

                try
                {
                    oppdateringsCommand.Prepare();
                    result = oppdateringsCommand.ExecuteNonQuery();
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
                        oppdateringsCommand.Cancel();
                        check = false;
                    }

                    // Lukker tilkoblingen
                    this.CloseConnection();
                }
            }
            return check;
        }
    }
}
