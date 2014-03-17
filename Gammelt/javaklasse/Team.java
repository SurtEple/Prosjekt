/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package javaklasse;

public class Team {
    private int id;
    private int teamlederId;
    private String teamLeader;
    private String beskrivelse;
    
    public Team(){
        teamLeader=null;
        beskrivelse=null;
    }
    
    public Team(int id, int teamlederId, String teamLeader, String beskrivelse)
    {
        this.id = id;
        this.teamlederId = teamlederId;
        this.teamLeader = teamLeader;
        this.beskrivelse = beskrivelse;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }
    
    public int getTeamlederId() {
        return teamlederId;
    }

    public void setTeamlederId(int teamlederId) {
        this.teamlederId = teamlederId;
    }

    public String getTeamLeader() {
        return teamLeader;
    }

    public void setTeamLeader(String teamLeader) {
        this.teamLeader = teamLeader;
    }

    public String getBeskrivelse() {
        return beskrivelse;
    }

    public void setBeskrivelse(String beskrivelse) {
        this.beskrivelse = beskrivelse;
    }
    
}
