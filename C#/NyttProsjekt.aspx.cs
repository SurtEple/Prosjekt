using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Timeregistreringssystem
{
    public partial class NyttProsjekt : System.Web.UI.Page
    {
        private DBConnect connection = new DBConnect();
        private bool insertOK = false, deleteOK=false, editOK=false;
        private String navn, oppsummering, nesteFase, nyttNavn, nyOppsummering, nyNesteFase;
       


        protected void Page_Load(object sender, EventArgs e)
        {

           
        }

        protected void btnLagre_Click(object sender, EventArgs e)
        {
            navn = textBoxNavn.Text;
            oppsummering = textBoxOppsummering.Text;
            nesteFase = textBoxNesteFase.Text;

            if (navn!=null && oppsummering!=null && nesteFase!=null)
                insertOK = connection.insertProject(navn, oppsummering, nesteFase);

            resultBox.Text = "Result: " + insertOK;
        }



        protected void btnSlett_Click(object sender, EventArgs e)
        {
            
           int id = Convert.ToInt32(textBoxProsjektID.Text);
            
           if(!id.Equals(null))
            deleteOK= connection.delProject(id);


           prosjektInfoBox.Text = "Prosjekt ID: " + textBoxProsjektID.Text + "\nResultat: " + deleteOK;
        }

        protected void btnLagreNewProject_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxProjectIDForEdit.Text);
            

            nyttNavn = textBoxNewNavn.Text;
            nyOppsummering = textBoxNewOppsummering.Text;
            nyNesteFase = textBoxNewNesteFase.Text;

            if (!id.Equals(null))
           editOK= connection.editProject(id, nyttNavn, nyOppsummering, nyNesteFase);

           textBoxNewDetails.Text = "Prosjekt ID: " + id + "\nNytt navn: " +  nyttNavn + "\nNy Oppsummering: " + nyOppsummering +"\n Ny Neste Fase: " 
               + nyNesteFase + "\n\n Edit OK: "+editOK;


        }




    }
}