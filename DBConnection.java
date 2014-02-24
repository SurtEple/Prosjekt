/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package javaklasse;


import java.sql.*;
import java.util.logging.Level;
import java.util.logging.Logger;



/**
 *
 * @author Martin
 */
public class DBConnection {
    
    private Connection con = null;
    private Statement stmnt = null;

    public DBConnection()
    {
        try
        {
                String connectionURL = "jdbc:mysql://kark.hin.no:3306/HLVDKN_DB1";
                Class.forName("com.mysql.jdbc.Driver").newInstance();
                con = DriverManager.getConnection(connectionURL, "halvardk", "halvardk123");

            
        

        } catch (SQLException e) {
            System.out.println("Feil!: " + e);
        } catch (Exception ex) {
            Logger.getLogger(DBConnection.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    public ResultSet select(String _query) throws SQLException
    {
        try
        {
        stmnt = con.createStatement();
        ResultSet rs = stmnt.executeQuery(_query);
        return rs;
        }
        catch (Exception e)
        {
            System.out.println(e.getMessage());
            return null;
        }
        finally
        {
            if(con != null)
            {
                con.close();
            }
            if(stmnt != null)
            {
                stmnt.close();
            }
        }
    }
    public void insert(String _query) throws SQLException
    {
        try{
            stmnt = con.createStatement();
            stmnt.executeUpdate(_query);
        }
        catch(Exception e)
        {
            System.out.println(e.getMessage());
        }
        finally
        {
            if(con != null)
                con.close();
            if(stmnt != null)
                stmnt.close();
        }
    }
    public void delete(String _query) throws SQLException
    {
        try{
            stmnt = con.createStatement();
            stmnt.executeUpdate(_query);
        }
        catch(Exception e)
        {
            System.out.println(e.getMessage());
        }
        finally
        {
            if(con != null)
                con.close();
            if(stmnt != null)
                stmnt.close();
        }
    }
    public boolean isClosed()
    {
        try {
            return con.isClosed();
        } catch (SQLException ex) {
            Logger.getLogger(DBConnection.class.getName()).log(Level.SEVERE, null, ex);
            return true;
        }
        
    }

    
}
