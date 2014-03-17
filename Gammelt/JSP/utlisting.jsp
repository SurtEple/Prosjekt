<%-- 
    Document   : newjsp
    Created on : 19.feb.2014, 10:54:38
    Author     : Kristina
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ page import="java.sql.*" %> 
<%@ page import="java.io.*" %>
<%@ page import="javaklasse.*" %>
<%@ page import="java.util.*" %>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Testing mot database</title>
    </head>
    <body>
        
        <% 
            DBConnection database = new DBConnection();
            ArrayList<Prosjekt> prosjektliste = database.selectProsjekt();
            ArrayList<Bruker> brukerliste = database.selectBruker();
        %> 
        
        
        <!-- BRUKER TABELL  -->
        <h2>Bruker</h2>
        <TABLE BORDER=1>   
        <TR>
            <TD><h4>Fornavn</h4></TD>
            <TD><h4>Mellomnavn</h4></TD>
            <TD><h4>Etternavn</h4></TD>
            <TD><h4>Adresse</h4></TD>
            <TD><h4>By</h4></TD>
            <TD><h4>Postnummer</h4></TD>
            <TD><h4>Tlf.</h4></TD>
            <TD><h4>Epost</h4></TD>
            <TD><h4>Stilling</h4></TD>
            <TD><h4>IM</h4></TD>
                   
        </TR>
        <%
            for ( int i = 0; i < brukerliste.size(); i++ ) {
        %>
        <TR>
        <TD><%= brukerliste.get(i).getForNavn() %></TD>
        <TD><%= brukerliste.get(i).getMellomNavn() %></TD>
        <TD><%= brukerliste.get(i).getEtterNavn() %></TD>
        <TD><%= brukerliste.get(i).getAdresse() %></TD>
        <TD><%= brukerliste.get(i).getBy() %></TD>
        <TD><%= brukerliste.get(i).getPostNr() %></TD>
        <TD><%= brukerliste.get(i).getTelefonNr() %></TD>
        <TD><%= brukerliste.get(i).getePost() %></TD>
        <TD><%= brukerliste.get(i).getStilling() %></TD>
        <TD><%= brukerliste.get(i).getIm() %></TD>
        </TR>
        <%
            }
        %>
        </TABLE>
        
        
        <!-- PROSJEKT TABELL  -->
        <h2>Prosjekt</h2>
        <TABLE BORDER=1>   
        <TR>
            <TD><h4>Navn</h4></TD>
            <TD><h4>Neste Fase</h4></TD>
            <TD><h4>Oppsummering</h4></TD>
        </TR>
        <%
            for ( int i = 0; i < prosjektliste.size(); i++ ) {
        %>
        <TR>
        <TD><%= prosjektliste.get(i).getNavn() %></TD>
        <TD><%= prosjektliste.get(i).getNesteFase() %></TD>
        <TD><%= prosjektliste.get(i).getOppsummering() %></TD>
        </TR>
        <%
            }
        %>
        </TABLE>
        
       
    </body>
</html>
