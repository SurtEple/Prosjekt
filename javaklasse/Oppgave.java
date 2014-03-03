/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package javaklasse;

/**
 *
 * @author Martin
 */
public class Oppgave
{
    private int id;
    private String prosjekt;
    private String foreldreOppgave;
    private double estimertTid;
    private String tittel;
    private String beskrivelse;
    private String ferdig;
    private double bruktTid;
    private String datoBegynt;
    private String datoFerdig;
    
    public Oppgave(int id, String prosjekt, String foreldreOppgave, double estimertTid, String tittel,
            String beskrivelse, String ferdig, double bruktTid, String datoBegynt, String datoFerdig)
    
    {
        this.id = id;
        this.prosjekt = prosjekt;
        this.foreldreOppgave = foreldreOppgave;
        this.estimertTid = estimertTid;
        this.tittel = tittel;
        this.beskrivelse = beskrivelse;
        this.ferdig = ferdig;
        this.bruktTid = bruktTid;
        this.datoBegynt = datoBegynt;
        this.datoFerdig = datoFerdig;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getProsjekt() {
        return prosjekt;
    }

    public void setProsjekt(String prosjekt) {
        this.prosjekt = prosjekt;
    }

    public String getForeldreOppgave() {
        return foreldreOppgave;
    }

    public void setForeldreOppgave(String foreldreOppgave) {
        this.foreldreOppgave = foreldreOppgave;
    }

    public double getEstimertTid() {
        return estimertTid;
    }

    public void setEstimertTid(double estimertTid) {
        this.estimertTid = estimertTid;
    }

    public String getTittel() {
        return tittel;
    }

    public void setTittel(String tittel) {
        this.tittel = tittel;
    }

    public String getBeskrivelse() {
        return beskrivelse;
    }

    public void setBeskrivelse(String beskrivelse) {
        this.beskrivelse = beskrivelse;
    }

    public String getFerdig() {
        return ferdig;
    }

    public void setFerdig(String ferdig) {
        this.ferdig = ferdig;
    }

    public double getBruktTid() {
        return bruktTid;
    }

    public void setBruktTid(double bruktTid) {
        this.bruktTid = bruktTid;
    }

    public String getDatoBegynt() {
        return datoBegynt;
    }

    public void setDatoBegynt(String datoBegynt) {
        this.datoBegynt = datoBegynt;
    }

    public String getDatoFerdig() {
        return datoFerdig;
    }

    public void setDatoFerdig(String datoFerdig) {
        this.datoFerdig = datoFerdig;
    }
    
}
