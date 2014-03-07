using System;


namespace Timeregistreringssystem
{
    class Bruker
    {


        public Bruker(int id, String fornavn, String mellomnavn, String etternavn, 
            String epost, String im, String telefonNr, String adresse, String postNr,
            String by, String stilling)
        {
            Id = id;
            Fornavn = fornavn;
            Mellomnavn = mellomnavn;
            Etternavn = etternavn;
            Epost = epost;
            Im = im;
            Telefon = telefonNr;
            Adresse = adresse;
            PostNr = postNr;
            By = by;
            Stilling = stilling;
        }
        public int Id { get; set; }
        public String Fornavn { get; set; }
        public String Mellomnavn { get; set; }
        public String Etternavn { get; set; }
        public String Epost { get; set; }
        public String Im { get; set; }
        public String Telefon { get; set; }
        public String Adresse { get; set; }
        public String PostNr { get; set; }
        public String By { get; set; }
        public String Stilling { get; set; }
            
    
    }
}
