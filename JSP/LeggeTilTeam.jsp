<%-- 
    Document   : LeggeTilTeam
    Created on : Feb 24, 2014, 1:51:46 PM
    Author     : Vos
--%>
<%@page import="java.sql.*"%>
<%@page import="java.io.*"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<HTML>
    <TITLE>Legge til Team JSP</TITLE>
<BODY>

    <%
           
            try {

                String connectionURL = "jdbc:mysql://kark.hin.no:3306/HLVDKN_DB1";
                Connection connection = null;
                Class.forName("com.mysql.jdbc.Driver").newInstance();
                connection = DriverManager.getConnection(connectionURL, "halvardk", "halvardk123");
                if (!connection.isClosed()) {
                    out.println("Successfully connected to MySQL server using TCP/IP... \n");
                    
                    Statement stmt=(Statement)connection.createStatement();

                    //Hardkodet insert-setning
                    String insert="INSERT INTO Team VALUES(NULL, '18', 'Beskrivelse');"; 
                    stmt.executeUpdate(insert);
                    
                    out.print("Lagt til! Alt ok!");

                }
           //connection.close();
            } catch (Exception ex) {
                out.println("Unable to connect to database " + ex);
            }
        %> 

</BODY>
</HTML>
