<%-- 
    Document   : NyBruker
    Created on : 03.mar.2014, 13:07:23
    Author     : Vos
--%>

<%@page import="javaklasse.DBConnection" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>

<%
    DBConnection db = new DBConnection();
    
    //Leser data fra inputfeltene 
    String brukernavn = request.getParameter("brukernavn");
    String passord = request.getParameter("passord");
    String passord2 = request.getParameter("passord2");
    String fornavn = request.getParameter("fornavn");
    String mellomnavn = request.getParameter("mellomnavn");
    String etternavn = request.getParameter("etternavn");
    String epost = request.getParameter("epost");
    String im = request.getParameter("im");
    String telefonnr = request.getParameter("telefonnr");
    String adresse = request.getParameter("adresse");
    String postnr = request.getParameter("postnr");
    String by = request.getParameter("by");
    
    //Sjekk om passordene stemmer
    if (passord.equals(passord2))
    {
        out.print(brukernavn + " lagt til!");
        //db.addUser(brukernavn, passord, fornavn, mellomnavn, etternavn, epost, im, telefonnr, adresse, postnr, by);
    }
    
    
    %>


<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Suksess!</title>
    </head>
    <body>
        <h1><% out.print(brukernavn); %> lagt til!</h1>
    </body>
</html>
