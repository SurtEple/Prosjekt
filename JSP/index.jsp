<%-- 
    Document   : jsptest
    Created on : Feb 17, 2014, 1:51:46 PM
    Author     : Missy
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ page import="java.sql.*" %> 
<%@ page import="java.io.*" %> 
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>


        <%
            String result = "";
            try {

                String connectionURL = "jdbc:mysql://kark.hin.no:3306/HLVDKN_DB1";
                Connection connection = null;
                Class.forName("com.mysql.jdbc.Driver").newInstance();
                connection = DriverManager.getConnection(connectionURL, "halvardk", "halvardk123");
                if (!connection.isClosed()) {
                    out.println("Successfully connected to MySQL server using TCP/IP...");
                    String selectQ = "SELECT * FROM iskrem";
                    Statement state = connection.createStatement();
                    ResultSet rS = state.executeQuery(selectQ);

                    ResultSetMetaData metaData = rS.getMetaData();
                    int columns = metaData.getColumnCount();
                    
                    while (rS.next()) {//reading one record
                        for (int i = 1; i <= columns; ++i) {//this reads column by column
                            result += metaData.getColumnName(i) + "\n";
                            result += rS.getString(i) + "\n";
                            result +=  metaData.getColumnName(i) + "\n";

                        }//closes for loop
                    }//closes while loop
                    out.print(result);

                }
           //connection.close();
            } catch (Exception ex) {
                out.println("Unable to connect to database " + ex);
            }
        %> 


    </body>
</html>
