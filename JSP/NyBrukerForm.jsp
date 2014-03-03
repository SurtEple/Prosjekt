<%-- 
    Document   : Ny_Bruker
    Created on : 03.mar.2014, 12:10:45
    Author     : Vos
--%>
<%@page import="java.io.*"%>
<%@page import ="java.sql.*" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Opprette ny bruker</title>
    </head>
    <body>
        <form name="nybruker" action="NyBruker.jsp" method="post" accept-charset="utf-8">  
    <ul>  
        <li><label for="brukernavn">Brukernavn</label>  
        <input type="text" name="brukernavn" placeholder="Brukernavn" required></li>
        
        <li><label for="passord">Passord</label>  
        <input type="text" name="password" placeholder="Passord"></li> 
       
        <li><label for="passord2">Gjenta Passord</label>  
        <input type="text" name="password" placeholder="Gjenta passord"></li>
        
        <li><label for="fornavn">Fornavn</label>  
        <input type="text" name="fornavn" placeholder="Fornavn"></li>
        
        <li><label for="mellomnavn">Mellomnavn</label>  
        <input type="text" name="mellomnavn" placeholder="Mellomnavn"></li>
        
        <li><label for="etternavn">Etternavn</label>  
        <input type="text" name="etternavn" placeholder="Etternavn"></li>
        
        <li><label for="epost">Epost</label>  
        <input type="text" name="epost" placeholder="Epost"></li>
        
        <li><label for="im">Instant Messenger</label>  
        <input type="text" name="im" placeholder="IM"></li>
        
        <li><label for="telefonnr">Telefonnummer</label>  
        <input type="text" name="telefonnr" placeholder="Telefonnummer"></li>
        
        <li><label for="adresse">Adresse</label>  
        <input type="text" name="adresse" placeholder="Adresse"></li>
        
        <li><label for="postnr">Postnummer</label>  
        <input type="text" name="postnummer" placeholder="Postnummer"></li>
        
        <li><label for="by">By</label>  
        <input type="text" name="by" placeholder="By"></li>
        
        <li><input type="submit" value="submit"></li>
    </ul>  
           
    </body>
</html>
