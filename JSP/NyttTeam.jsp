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

        <jsp:useBean id="teamlederIdBean" scope="session" class="database.Team" />
        <jsp:useBean id="beskrivelseBean" scope="session" class="database.Team" />
 
        <jsp:setProperty name="teamlederIdBean" property="teamlederId" />
        <jsp:setProperty name="beskrivelseBean" property="beskrivelse"  />
    
        <% 
            DBConnection database = new DBConnection();
            
            if(database.insertTeam(teamlederIdBean.getTeamlederId(), beskrivelseBean.getBeskrivelse()))
            {
                out.append("OK");   //Alt gikk bra
            }
            else
            {
                out.append("IKKE OK");  //Alt gikk i vasken
            }
        %>
        
    </body>
</html>
