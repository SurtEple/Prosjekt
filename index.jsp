<%-- 
    Document   : newjsp
    Created on : 19.feb.2014, 10:54:38
    Author     : Kristina
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ page import="java.sql.*" %> 
<%@ page import="java.io.*" %>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Testing mot database</title>
    </head>
    <body>
        <h1>Yo</h1>
        
        <% //this is a scriptlet
            System.out.println("Finner fram dagens dato..");
            java.util.Date date = new java.util.Date();
            out.println( "<h3>" + String.valueOf( date ) + "</h3>");
        %> 
        
        <% 
            try{
                String connectionURL = "jdbc:mysql://kark.hin.no:3306/HLVDKN_DB1";
                Connection connection = null;
                Class.forName("com.mysql.jdbc.Driver").newInstance();
                connection = DriverManager.getConnection(connectionURL, "halvardk", "halvardk123" );
                if(!connection.isClosed())
                    out.println("Successfully connected to MySQL server using TCP/IP...");
                //connection.close();
            }
            catch (Exception ex)
            {
                out.println("Unable to connect to database " + ex);
            }
            %> 
        
        <% int n = 5; %>
        
        <TABLE BORDER=1>
            
        <%
            for ( int i = 0; i < n; i++ ) {
        %>
        
        <TR>
        <TD>Kolonne 1</TD>
        <TD><%= i+1 %> Kolonne 2</TD>
        </TR>
        <%
            }
        %>
        </TABLE>
        
        
        
        <p>HADE <%= System.getProperty("user.name") %></p>
    </body>
</html>
