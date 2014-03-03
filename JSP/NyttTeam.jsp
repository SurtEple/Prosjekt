<%-- 
    Document   : NyttTeam
    Created on : 03.mar.2014, 12:49:45
    Author     : Kristina
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ page import="database.*" %>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Teamadministrajson</title>
    </head>
    <body>
        <h2>Oppretter nytt team...</h2>
        
        <!-- Henter informasjon fra form i teamadministrasjon.jsp og 
        lagrer den i database.-->
        
        <% 
            String beskrivelse = request.getParameter("Beskrivelse"); 
            String teamlederId = request.getParameter("Brukere");
            
            DBConnection database = new DBConnection();
            //Har ikke laget nødvendig metode i database
            //database.insertTeam(teamlederId, beskrivelse);
        %>
        
    </body>
</html>
