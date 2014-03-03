<%-- 
    Document   : Teamadministrasjon
    Created on : 03.mar.2014, 12:02:07
    Author     : Kristina
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ page import="database.*" %>
<%@ page import="java.util.*" %>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Team administrasjon</title>
    </head>
    <body>
        
        <% 
            DBConnection database = new DBConnection();
            ArrayList<Bruker> brukerliste = database.selectBruker();
        %>
        
        <!-- FORM FOR OPPRETTING AV NYTT TEAM -->
        <form action="NyttTeam.jsp" method="POST">
            <h2>Opprett nytt team</h2>
            <textarea name="Beskrivelse" rows="16" cols="32" placeholder="Beskrivelse"></textarea>
            <br/>Velg teamleder<br/>
            
            <!-- Skriver ut en drop down liste med brukere -->
            <select name="Brukere">
                <%
                    for(int i = 0; i < brukerliste.size(); i++) {
                        String navn = brukerliste.get(i).getForNavn() + " " + brukerliste.get(i).getMellomNavn()
                        + " " + brukerliste.get(i).getEtterNavn();
                        int id = brukerliste.get(i).getId();               
                %>
                <option value=" <%= id %> "> <%= navn %> </option>
                <% } %>
            </select><br/><br/>
            
            <input type="submit" value="Lagre"/>
        </form>   
        
    </body>
</html>
