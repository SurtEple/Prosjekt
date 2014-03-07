﻿using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

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
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
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
                MessageBox.Show(ex.Message);
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
        }



    }
}