<%-- 
    Document   : projectadmin
    Created on : Mar 3, 2014, 1:38:42 PM
    Author     : Missy
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Administrer prosjekter </title>
    </head>
    <body>
        <h1>Prosjektadministrering</h1>
        
          <h3>Nytt Prosjekt</h3>
          
        <form name="Nytt prosjekt" action="response.jsp">
            <br> Prosjektnavn: <br> 
            <input type="text" name="navn" />
            <br> Oppsummering: <br> 
            <textarea name="oppsummering" rows="4" cols="20">
            </textarea>
            <br> Neste fase: <br>
            <textarea name="nesteFase" rows="4" cols="20">
            </textarea>
            <input type="submit" value="OK" />
        </form>
    </body>
</html>
