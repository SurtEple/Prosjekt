<%-- 
    Document   : Innlogging
    Created on : 03.mar.2014, 10:57:31
    Author     : Vos
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Innlogging</title>
    </head>
    <body>
        
        <form name="login" action="index_submit" method="get" accept-charset="utf-8">  
    <ul>  
        <li><label for="brukernavn">Brukernavn</label>  
        <input type="text" name="brukernavn" placeholder="Brukernavn" required></li>
        
        <li><label for="passord">Passord</label>  
        <input type="password" name="password" placeholder="Passord" required></li> 
       
        <li><input type="submit" value="Login"></li>  
    </ul>  
</form> 
        
        
        
    </body>
</html>
