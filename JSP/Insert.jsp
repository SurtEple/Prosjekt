<%-- 
    Document   : Insert
    Created on : Feb 17, 2014, 1:51:46 PM
    Author     : Missy

    Setter inn i tabeller. Kommentert ut for å ikke spamme databasen.
--%>


<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="java.sql.*"%>
<%@page import="java.io.*"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>


        <%
            String result = "";
            try {

                String connectionURL = "jdbc:mysql://kark.hin.no:3306/HLVDKN_DB1";
                Connection connection = null;
                Class.forName("com.mysql.jdbc.Driver").newInstance();
                connection = DriverManager.getConnection(connectionURL, "halvardk", "halvardk123");
                if (!connection.isClosed()) {
                    out.println("Successfully connected to MySQL server using TCP/IP... <br />");

                    Statement state = connection.createStatement();

                    String navn = "AnneR", passord = "passord", salt = "salt", fornavn = "Anne",
                            mellomnavn = "Br", etternavn = "Ragde", ePost = "anne@ragde.com", im = "AnneBR",
                            adresse = "Gata 1", by = "Gateby", beskrivelse = "Beskrivelse", stilling = "Stillingen", oppsummering = "Oppsummeringen", nesteF = "Warp speed",
                            status = "Status";
                    int telefonNr = 12345678, postNr = 1337, stillingId = 22, admin = 0, brukerId = 25, teamID = 22, prosjektID = 5;

                    String insertQ = "";

                    /**
                     * insertQ = "INSERT INTO Bruker (Brukernavn, Passord, Salt,
                     * Fornavn, Mellomnavn, Etternavn, Epost, IM, Telefonnr,
                     * Adresse, Postnummer, `By` , Stilling_ID, Administrator)
                     * VALUES ('" + navn + "','" + passord + "','" +salt + "','"
                     * + fornavn +"','" + mellomnavn + "','" + etternavn + "','"
                     * + ePost + "','" + im + "', " + telefonNr + ", '" +
                     * adresse + "'," + postNr + ", '" + by + "'," + stillingId
                     * + "," + admin +");" ; state.executeUpdate(insertQ);
                     */
                    out.println("Insert into Bruker OK <br />");

                    /**
                     * insertQ="INSERT INTO Fase (Navn, Dato_startet,
                     * Dato_sluttet, Status, Beskrivelse, Prosjekt_ID) VALUES
                     * ('" + navn + "',NOW(),'2014-04-30','" + status + "','" +
                     * beskrivelse + "'," +prosjektID + ");" ;
                     * state.executeUpdate(insertQ);
                     */
                    out.println("Insert into Fase OK <br />");

                    /**
                     * insertQ = "INSERT INTO KoblingBrukerTeam (Bruker_ID,
                     * Team_ID) VALUES( " + brukerId +","+ teamID +");" ;
                     * state.executeUpdate(insertQ);
                     */
                    out.println("Insert into KoblingBrukerTeam OK <br />");

                    /**
                     * insertQ="INSERT INTO KoblingTeamProsjekt(Team_ID,
                     * Prosjekt_ID) VALUES( " +teamID + "," +prosjektID + ");" ;
                     * state.executeUpdate(insertQ);
                     */
                    out.println("Insert into KoblingTeamProsjekt OK <br />");

                    /**
                     * insertQ = "INSERT INTO `Oppgave` (`Prosjekt_ID`,
                     * `Foreldreoppgave_ID`, `EstimertTid`, `Tittel`,
                     * `Beskrivelse`, `Ferdig`, `Brukt_tid`, " + "`Dato_begynt`,
                     * `Dato_ferdig`) VALUES ('3', '0', '100', 'JSP', 'Forstå
                     * seg på jsp', '0', '50', '2014-02-10', '2014-02-11');";
                     *
                     * state.executeUpdate(insertQ);
                     */
                    out.println("Insert into Oppgave OK <br />");

                    /**
                     * insertQ="INSERT INTO Prosjekt(Navn, Oppsummering,
                     * Neste_Fase) VALUES ('"+navn+"','"+oppsummering+"','" +
                     * nesteF +"');"; state.executeUpdate(insertQ);
                     */
                    out.println("Insert into Prosjekt OK <br />");

                    /**
                     * insertQ=" INSERT INTO Stilling(navn) VALUES (" + "'" +
                     * stilling + "'" + " );"; state.executeUpdate(insertQ);
                     */
                    out.println("Insert into Stilling OK <br />");

                    /**
                     * insertQ = "INSERT INTO Team(Teamleader, Beskrivelse)
                     * VALUES (" +stillingId + ",'" + beskrivelse + "');";
                     * state.executeUpdate(insertQ);
                     */
                    out.println("Insert into Team OK <br />");

                    /**
                     * insertQ = "INSERT INTO `Time` (`Fra`, `Til`, `Pause`,
                     * `Dato`, `Bruker_ID`, `Oppgave_ID`, `Kommentar`, `Sted`,
                     * `Aktiv`) " + "VALUES ('09:30:00', '10:30:00', '00:00:00',
                     * '2014-02-13', '19', '5', 'Dette er en kommentar', 'Oslo',
                     * '0');"; state.executeUpdate(insertQ);
                     */
                    out.println("Insert into Time OK <br />");

                    
                    
                    String selectQ = "SELECT * FROM Time";
                    ResultSet rS = state.executeQuery(selectQ);

                    ResultSetMetaData metaData = rS.getMetaData();
                    int columns = metaData.getColumnCount();

                    while (rS.next()) {//reading one record
                        for (int i = 1; i <= columns; ++i) {//this reads column by column
                            result += "<br> <h3>" + metaData.getColumnName(i) + "<br></h3>";
                            result += rS.getString(i) + "<br>";

                        }//closes for loop
                    }//closes while loop
                    out.print(result);

                }
                //connection.close();
            } catch (Exception ex) {
                out.println("Unable to connect to database " + ex);
            }


        %> 



        <%!
            public String doSomething(String param) {

                //String insertQ = "INSERT INTO iskrem (farge, smak) VALUES ('ROSA', 'nam')";
                //state.executeUpdate(insertQ); 
                return "";
            }

        %>







    </body>
</html>
