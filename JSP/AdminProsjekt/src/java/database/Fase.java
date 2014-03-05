/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package database;

/**
 *
 * @author Martin
 */
public class Fase {
    private int id;
    private String navn;
    private String datoStartet;
    private String datoSluttet;
    private String status;
    private String beskrivelse;
    private String prosjekt;
    
    public Fase(int id, String navn, String datoStartet, String datoSluttet,
            String status, String beskrivelse, String prosjekt)
    {
        this.id = id;
        this.navn = navn;
        this.datoStartet = datoStartet;
        this.datoSluttet = datoSluttet;
        this.status = status;
        this.beskrivelse = beskrivelse;
        this.prosjekt = prosjekt;
    }
            

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNavn() {
        return navn;
    }

    public void setNavn(String navn) {
        this.navn = navn;
    }

    public String getDatoStartet() {
        return datoStartet;
    }

    public void setDatoStartet(String datoStartet) {
        this.datoStartet = datoStartet;
    }

    public String getDatoSluttet() {
        return datoSluttet;
    }

    public void setDatoSluttet(String datoSluttet) {
        this.datoSluttet = datoSluttet;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getBeskrivelse() {
        return beskrivelse;
    }

    public void setBeskrivelse(String beskrivelse) {
        this.beskrivelse = beskrivelse;
    }

    public String getProsjekt() {
        return prosjekt;
    }

    public void setProsjekt(String prosjekt) {
        this.prosjekt = prosjekt;
    }
    
}
