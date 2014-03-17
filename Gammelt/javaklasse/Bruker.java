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
public class Bruker {
    private int id;
    private String forNavn;
    private String mellomNavn;
    private String etterNavn;
    private String ePost;
    private String im;
    private String telefonNr;
    private String adresse;
    private String postNr;
    private String by;
    private String stilling;
    public Bruker(int id, String forNavn, String mellomNavn, String etterNavn, 
            String ePost, String im, String telefonNr, String adresse, String postNr,
            String by, String stilling)
    {
        this.id = id;
        this.forNavn = forNavn;
        this.mellomNavn = mellomNavn;
        this.etterNavn = etterNavn;
        this.ePost = ePost;
        this.im = im;
        this.telefonNr = telefonNr;
        this.adresse = adresse;
        this.postNr = postNr;
        this.by = by;
        this.stilling = stilling;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getForNavn() {
        return forNavn;
    }

    public void setForNavn(String forNavn) {
        this.forNavn = forNavn;
    }

    public String getMellomNavn() {
        return mellomNavn;
    }

    public void setMellomNavn(String mellomNavn) {
        this.mellomNavn = mellomNavn;
    }

    public String getEtterNavn() {
        return etterNavn;
    }

    public void setEtterNavn(String etterNavn) {
        this.etterNavn = etterNavn;
    }

    public String getePost() {
        return ePost;
    }

    public void setePost(String ePost) {
        this.ePost = ePost;
    }

    public String getIm() {
        return im;
    }

    public void setIm(String im) {
        this.im = im;
    }

    public String getTelefonNr() {
        return telefonNr;
    }

    public void setTelefonNr(String telefonNr) {
        this.telefonNr = telefonNr;
    }

    public String getAdresse() {
        return adresse;
    }

    public void setAdresse(String adresse) {
        this.adresse = adresse;
    }

    public String getPostNr() {
        return postNr;
    }

    public void setPostNr(String postNr) {
        this.postNr = postNr;
    }

    public String getBy() {
        return by;
    }

    public void setBy(String by) {
        this.by = by;
    }

    public String getStilling() {
        return stilling;
    }

    public void setStilling(String stilling) {
        this.stilling = stilling;
    }
    
}
