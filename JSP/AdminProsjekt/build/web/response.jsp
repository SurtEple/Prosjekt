<%-- 
    Document   : response
    Created on : Mar 3, 2014, 1:38:52 PM
    Author     : Missy
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
       <body>
           <jsp:useBean id="name" scope="session" class="database.Prosjekt" />
           <jsp:useBean id="oppsummering" scope="session" class="database.Prosjekt" />
           <jsp:useBean id="nestefase" scope="session" class="database.Prosjekt" />
           <jsp:setProperty name="navn" property="navn" />
           <jsp:setProperty name="oppsummering" property="oppsummering" />
           <jsp:setProperty name="nesteFase" property="nesteFase"  />
           
           <h3> Navn: <jsp:getProperty name="navn" property="navn" />
               Oppsummering: <jsp:getProperty name="oppsummering" property="oppsummering" />
               Neste Fase: <jsp:getProperty name="nesteFase" property="nesteFase" />
           </h3>
</body>
</html>
