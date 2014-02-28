<%-- 
    Document   : jsptest
    Created on : Feb 17, 2014, 1:51:46 PM
    Author     : Missy
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ page import="java.sql.*" %> 
<%@ page import="java.io.*" %> 
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
                    out.println("Successfully connected to MySQL server using TCP/IP...");
                    
                    Statement state = connection.createStatement();
                    
                 String navn="AnneR", passord="passord", salt = "salt", fornavn="Anne",
                         mellomnavn="Br", etternavn="Ragde", ePost="anne@ragde.com", im="AnneBR",
                         adresse="Gata 1", by ="Gateby", beskrivelse="Beskrivelse", stilling = "Stillingen", oppsummering="Oppsummeringen", nesteF="Warp speed",
                         status="Status";
                 int telefonNr=12345678, postNr=1337, stillingId=22, admin=0, brukerId=25, teamID=22, prosjektID=5;
              
                 java.util.Date today = new java.util.Date();//date object
                 Date time = new Date(today.getTime());
                 
                 
                // out.println(time);
                   
                   
               //  String  insertQ = "INSERT INTO Bruker (Brukernavn, Passord, Salt, Fornavn, Mellomnavn, Etternavn, Epost, IM, Telefonnr, Adresse, Postnummer, By, Stilling_ID, Administrator) VALUES("+"'"+ navn +"','" + passord +"','"+salt+"','"+fornavn+"','"+mellomnavn+"','"+etternavn+"','"+ePost+"','"+im + "'," + telefonNr +",'"+ adresse+"',"+postNr+ ",'"+ by +"',"+stillingId +"," +admin +    " );";
                
                 String insertQ="";
               // insertQ = "INSERT INTO Team(Teamleader, Beskrivelse) VALUES ("  +stillingId + ",'" +  beskrivelse + "');";
              //   state.executeUpdate(insertQ);
                  
                // insertQ=" INSERT INTO Stilling(navn) VALUES (" + "'" + stilling + "'" + " );";
               //   state.executeUpdate(insertQ);
                  
                 //  insertQ="INSERT INTO Prosjekt(Navn, Oppsummering, Neste_Fase) VALUES ('"+navn+"','"+oppsummering+"','" + nesteF  +"');";
               //   state.executeUpdate(insertQ);
                 
               //   insertQ = "INSERT INTO KoblingBrukerTeam (Bruker_ID, Team_ID) VALUES( " + brukerId +","+ teamID   +");"  ;
                 //  state.executeUpdate(insertQ);
                 
                 //insertQ="INSERT INTO KoblingTeamProsjekt(Team_ID, Prosjekt_ID) VALUES( " +teamID + "," +prosjektID  + ");" ;
                  
              /**    insertQ = "INSERT INTO Bruker (Brukernavn, Passord, Salt, Fornavn, Mellomnavn, Etternavn, Epost, IM, Telefonnr, Adresse, Postnummer, `By` , Stilling_ID, Administrator) VALUES ('"   
                          + navn + "','" + passord + "','" +salt + "','" + fornavn +"','" + mellomnavn + "','" + etternavn + "','" + ePost + "','"
                           + im + "', " + telefonNr + ", '" + adresse + "'," + postNr + ", '" + by +   "'," + stillingId + "," + admin +");" ;
                    state.executeUpdate(insertQ);
                 */
                    
                 insertQ="INSERT INTO Fase (Navn, Dato_startet, Dato_sluttet, Status, Beskrivelse, Prosjekt_ID) VALUES ('"  
                         + navn + "'," + time + "," + time + ",'" + status + "','" + beskrivelse + "'," +prosjektID
                         +  ");"  ;
                    
                 state.executeUpdate(insertQ);
                    
                    
                    
                /**    String selectQ = "SELECT * FROM Bruker";
                    ResultSet rS = state.executeQuery(selectQ);

                    ResultSetMetaData metaData = rS.getMetaData();
                    int columns = metaData.getColumnCount();
                    
                    while (rS.next()) {//reading one record
                        for (int i = 1; i <= columns; ++i) {//this reads column by column
                            result += metaData.getColumnName(i) + "\n";
                            result += rS.getString(i) + "\n";
                            result +=  metaData.getColumnName(i) + "\n";

                        }//closes for loop
                    }//closes while loop
                    out.print(result);
                    */
             
                    
        }
           //connection.close();
            } catch (Exception ex) {
                out.println("Unable to connect to database " + ex);
            }
            
           
           
            
            
        %> 
        
        

        <%! 
            public String doSomething(String param){
               
                    //String insertQ = "INSERT INTO iskrem (farge, smak) VALUES ('ROSA', 'nam')";
                    //state.executeUpdate(insertQ); 
                    
            return "";
            }
        
        %>
        
        <%
            String test = doSomething("test");
        
        %>


        
        

    </body>
</html>
