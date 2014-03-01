<%-- 
    Document   : jsptest
      Updated: March 1, 2014, 1:51:46 PM
    Author     : TK
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
            //// Oppdatere Time table  /////////////
     
            String updateQ = "";    //default verdi updateQuerry
            String tableNavn = "Time";   
            String kolonneNavn = "Fra";                 
            String format = "'09:04:00'"; // <- Formatet til modifisert verdi
            String where = "id = 2";        // where id,navn,etc = "?"
           
            ////
                      
            ////////Oppdatere Team///////////// 
       /*     String updateQ = "";    //default verdi updateQuerry
            String tableNavn = "Team";       
            String kolonneNavn = "Teamleader";        
            String format = "16"; // <- Formatet til modifisert verdi            
            String where = "id = 5";        //where id,navn,etc = "?"
               */
            ///

            ///
                  ////////Oppdatere Stilling///////////// 
       /*     String updateQ = "";    //default verdi updateQuerry
            String tableNavn = "Stilling";   
            String kolonneNavn = "Navn";                
            String format = "'SuperPro'"; // <- Formatet til modifisert verdi            
            String where = "id = 1";        // where id,navn,etc = "?"
               */
            ///
            
                  ////////Oppdatere Prosjekt///////////// 
       /*     String updateQ = "";    //default verdi updateQuerry
            String tableNavn = "Prosjekt";   
            String kolonneNavn = "Oppsummering";        
            String format = "'Oppdatert Oppsummering'"; // <- Formatet til modifisert verdi            
            String where = "Navn = 'Mobilspill'";        // where id,navn,etc = "?"
           */    
            ///
            
                 ////////Oppdatere Oppgave//////////// 
       /*     String updateQ = "";    //default verdi updateQuerry
            String tableNavn = "Prosjekt";   
            String kolonneNavn = "Oppsummering";        
            String format = "'Oppdatert Oppsummering'"; // <- Formatet til modifisert verdi            
            String where = "Navn = 'Mobilspill'";        // where id,navn,etc = "?"
           */    
            ///
            
            Statement state;
            try {
               java.text.DateFormat df = new java.text.SimpleDateFormat("dd/MM/yyyy");
                String connectionURL = "jdbc:mysql://kark.hin.no:3306/HLVDKN_DB1";
                Connection connection = null;
                Class.forName("com.mysql.jdbc.Driver").newInstance();
                connection = DriverManager.getConnection(connectionURL, "halvardk", "halvardk123");
                if (!connection.isClosed()) {
                    out.println("Successfully connected to MySQL server using TCP/IP..."); 
                    updateQ = "UPDATE "+tableNavn+" SET "+kolonneNavn+" = "+format+" WHERE "+where+" "; 
                    state = connection.prepareStatement(updateQ);
                    state.executeUpdate(updateQ);  
                }
           //connection.close();
            } catch (Exception ex) {
                out.println("Unable to connect to database " + ex);
            }
        %> 


    </body>
</html>