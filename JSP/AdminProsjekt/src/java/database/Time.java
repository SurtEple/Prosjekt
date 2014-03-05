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
public class Time {
    private int id;
    private String tidFra;
    private String tidTil;
    private String pause;
    private String dato;
    private String bruker;
    private String oppgave;
    private String kommentar;
    private String sted;
    
    public Time(int id, String tidFra, String tidTil, String pause, String dato,
            String bruker, String oppgave, String kommentar, String sted)
    {
        this.id = id;
        this.tidFra = tidFra;
        this.tidTil = tidTil;
        this.pause = pause;
        this.dato = dato;
        this.bruker = bruker;
        this.oppgave = oppgave;
        this.kommentar = kommentar;
        this.sted = sted;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getTidFra() {
        return tidFra;
    }

    public void setTidFra(String tidFra) {
        this.tidFra = tidFra;
    }

    public String getTidTil() {
        return tidTil;
    }

    public void setTidTil(String tidTil) {
        this.tidTil = tidTil;
    }

    public String getPause() {
        return pause;
    }

    public void setPause(String pause) {
        this.pause = pause;
    }

    public String getDato() {
        return dato;
    }

    public void setDato(String dato) {
        this.dato = dato;
    }

    public String getBruker() {
        return bruker;
    }

    public void setBruker(String bruker) {
        this.bruker = bruker;
    }

    public String getOppgave() {
        return oppgave;
    }

    public void setOppgave(String oppgave) {
        this.oppgave = oppgave;
    }

    public String getKommentar() {
        return kommentar;
    }

    public void setKommentar(String kommentar) {
        this.kommentar = kommentar;
    }

    public String getSted() {
        return sted;
    }

    public void setSted(String sted) {
        this.sted = sted;
    }
    
}
