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
public class Prosjekt {
    private int id;
    private String navn;
    private String oppsummering;
    private String nesteFase;
    
    public Prosjekt(){}

      public Prosjekt( String navn, String oppsummering, String nesteFase)
    {
        
        this.navn = navn;
        this.oppsummering = oppsummering;
        this.nesteFase = nesteFase;
    }
    public Prosjekt(int id, String navn, String oppsummering, String nesteFase)
    {
        this.id = id;
        this.navn = navn;
        this.oppsummering = oppsummering;
        this.nesteFase = nesteFase;
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

    public String getOppsummering() {
        return oppsummering;
    }

    public void setOppsummering(String oppsummering) {
        this.oppsummering = oppsummering;
    }

    public String getNesteFase() {
        return nesteFase;
    }

    public void setNesteFase(String nesteFase) {
        this.nesteFase = nesteFase;
    }
    
}
