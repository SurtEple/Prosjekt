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
           <jsp:useBean id="nameBean" scope="session" class="database.Prosjekt" />
           <jsp:useBean id="summaryBean" scope="session" class="database.Prosjekt" />
           <jsp:useBean id="nextphaseBean" scope="session" class="database.Prosjekt" />
           
           <jsp:setProperty name="nameBean" property="navn" />
           
           <jsp:setProperty name="summaryBean" property="oppsummering" />
           <jsp:setProperty name="nextphaseBean" property="nesteFase"  />
           
           <h3> Navn: <jsp:getProperty name="nameBean" property="navn" />
               Oppsummering: <jsp:getProperty name="summaryBean" property="oppsummering" />
               Neste Fase: <jsp:getProperty name="nextphaseBean" property="nesteFase" />
           </h3>
         </body> 
</html>
