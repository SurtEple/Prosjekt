<%-- 
    Document   : ProsjektAdministrering
    Created on : Mar 3, 2014, 1:38:52 PM
    Author     : Thomas og Thea
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="javaklasse.DBConnection"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
       <body>
           <jsp:useBean id="nameBean" scope="request" class="javaklasse.Prosjekt" />
           <jsp:useBean id="summaryBean" scope="request" class="javaklasse.Prosjekt" />
           <jsp:useBean id="nextPhaseBean" scope="request" class="javaklasse.Prosjekt" />
            <jsp:useBean id="connBean" scope="request" class="javaklasse.DBConnection" />
           
           
           <jsp:setProperty name="nameBean" property="navn" />        
           <jsp:setProperty name="summaryBean" property="oppsummering" />
           <jsp:setProperty name="nextPhaseBean" property="nesteFase"  /> 
           
           <% 
               String navn = nameBean.getNavn();
               String oppsummering = summaryBean.getOppsummering();
               String nesteFase = nextPhaseBean.getNesteFase();
               DBConnection con = new DBConnection();
               
            %> 
           <h3> Navn: <%= navn %>   
               <br>
               Oppsummering: <%= oppsummering %>   
               <br>
               Neste Fase: <%= nesteFase %>   
               <br>
               Innsetting: <%
               
               if (con.insertProject(navn, oppsummering, nesteFase)){
                    out.append("Innsetting OK");
               }  else { out.append("Innsetting feilet!");}
               %>
           </h3>
           
           
         </body> 
</html>
