/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package database;


import java.sql.*;
import java.util.ArrayList;
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
        connectToDb();
    }
    private void connectToDb()
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
    public ArrayList<Bruker> selectBruker()
    {
        ArrayList<Bruker> liste = new ArrayList<Bruker>();
        try
        {
            stmnt = con.createStatement();
            ResultSet rs = stmnt.executeQuery("Select ID, Brukernavn, Fornavn, Mellomnavn, "
                    + "Etternavn, Epost, IM, Telefonnr, Adresse, Postnummer, By, Stilling.Navn "
                    + "FROM Bruker, Stilling where Stilling_ID = Stilling.ID");
            while(rs.next())
            {
                int id = rs.getInt("ID");
                String brukernavn = rs.getString("Brukernavn");
                String fornavn = rs.getString("Fornavn");
                String mellomnavn = rs.getString("Mellomnavn");
                String etternavn = rs.getString("Etternavn");
                String epost = rs.getString("Epost");
                String im = rs.getString("im");
                String telefon = rs.getString("Telefonnr");
                String adresse = rs.getString("Adresse");
                String postnr = rs.getString("Postnummer");
                String by = rs.getString("By");
                String stilling = rs.getString("Stilling.navn");
                
                liste.add(new Bruker(id, fornavn, mellomnavn, etternavn, epost, im, telefon, adresse, postnr, by, stilling));
                
                
            }
            
        }
        catch(Exception e)
        {
            
        }
        finally
        {
            return liste;
        }
    }
    public ArrayList<Fase> selectFase()
    {
        ArrayList<Fase> liste = new ArrayList<Fase>();
        
        try
        {
            stmnt = con.createStatement();
            ResultSet rs = stmnt.executeQuery("SELECT ID, Fase.Navn, Dato_startet, Dato_sluttet, Status, Beskrivelse, Prosjekt.Navn "
                    + "FROM Fase, Prosjekt WHERE Prosjekt_ID = Prosjekt.ID");
            
            while(rs.next())
            {
                int id = rs.getInt("ID");
                String navn = rs.getString("Fase.Navn");
                String datoStartet = rs.getDate("Dato_startet") + "";
                String datoSluttet = rs.getDate("Dato_sluttet") + "";
                String status = rs.getString("Status");
                String beskrivelse = rs.getString("Beskrivelse");
                String prosjekt = rs.getString("Prosjekt.Navn");
                liste.add(new Fase(id,navn,datoStartet,datoSluttet,status,beskrivelse,prosjekt));
            }
        }
        catch(Exception e) 
        {
            
        }
        finally 
        {
            return liste;
        }
            
    }   
    /*
    public ArrayList<Oppgave> selectOppgave()
    {
        ArrayList<Oppgave> liste = new ArrayList<Oppgave>
    }
    */
    public ArrayList<Prosjekt> selectProsjekt()
    {
        ArrayList<Prosjekt> liste = new ArrayList<Prosjekt>();
        
        try
        {
            stmnt = con.createStatement();
            ResultSet rs = stmnt.executeQuery("SELECT * FROM Prosjekt");
            
            while(rs.next())
            {
                int id = rs.getInt("ID");
                String navn = rs.getString("Navn");
                String oppsummering = rs.getString("Oppsummering");
                String nesteFase = rs.getString("Neste_Fase");
                liste.add(new Prosjekt(id,navn,oppsummering,nesteFase));
            }
        }
        catch (Exception e)
        {
            
        }
        finally
        {
           return liste; 
        }
    }
    public ArrayList<Team> selectTeam()
    {
        ArrayList<Team> liste = new ArrayList<Team>();
        try
        {
            stmnt = con.createStatement();
            ResultSet rs = stmnt.executeQuery("SELECT Team.ID, Bruker.Fornavn, Bruker.Mellomnavn Bruker.Etternavn, Beskrivelse FROM Team, Bruker "
                    + "WHERE Teamleader = Bruker.ID");
            
            while(rs.next())
            {
                int id = rs.getInt("ID");
                String teamLeader = rs.getString("Bruker.Fornavn") + " " + rs.getString("Bruker.Mellomnavn")+ " " + rs.getString("Bruker.Etternavn");
                String beskrivelse = rs.getString("Beskrivelse");
                liste.add(new Team(id, teamLeader, beskrivelse));
            }
        }
        catch (Exception e)
        {
            
        }
        finally
        {
            return liste;
        }
    }
    public ArrayList<Time> selectTime()
    {
        ArrayList<Time> liste = new ArrayList<Time>();
        try
        {
            stmnt = con.createStatement();
            ResultSet rs = stmnt.executeQuery("SELECT Time.ID, Fra, Til, Pause, Dato, Bruker.Fornavn, Bruker.Etternavn, Oppgave.Navn, Kommentar, Sted, Aktiv "
                    + "FROM Time, Bruker, Oppgave WHERE Bruker_ID = Bruker.ID AND Oppgave_ID = Oppgave.ID");
            while(rs.next())
            {
                int id = rs.getInt("Time.ID");
                String fra = rs.getTime("Fra") + "";
                String til = rs.getTime("Til") + "";
                String pause = rs.getTime("Pause") + "";
                String dato = rs.getDate("Dato") + "";
                String bruker = rs.getString("Fornavn") + " " + rs.getString("Etternavn");
                String kommentar = rs.getString("Kommentar");
                String sted = rs.getString("Sted");
                String aktiv = "";
                if(rs.getInt("Aktiv") == 1)
                {
                    aktiv = "ja";
                }
                else if (rs.getInt("Aktiv") == 0)
                {
                    aktiv = "nei";
                }
                liste.add(new Time(id,fra,til,pause,dato,bruker,kommentar,sted,aktiv));
            }
        }
        catch (Exception e)
        {
            
        }
        finally
        {
            return liste;
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

    //NEW PROJECT
    public boolean newProject(String navn, String oppsummering, String nesteFase)
    {
        
        return false;
    }
    
    //DELETE PROJECT
    
     public boolean delProject(int id)
    {
        
        return false;
    }
      
     //EDIT PROJECT
    public boolean editProject(int id)
    {
        
        return false;
    }
    
    //Connect team to project
    public boolean connTeamProject (int teamID, int projectID)
    {
    
        return false;
        
    }
}
