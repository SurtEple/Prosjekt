using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// @author Thomas og Thea

namespace Timeregistreringssystem
{
    public partial class NyttProsjekt : System.Web.UI.Page
    {
        //variabler
        private DBConnect connection;
        private bool insertOK = false, deleteOK=false, editOK=false, connectOK=false;
        private String navn, oppsummering, nesteFase, nyttNavn, nyOppsummering, nyNesteFase;
       

        protected void Page_Load(object sender, EventArgs e)
        {   
            connection = new DBConnect();
        }

        /// <summary>
        /// Nytt prosjekt
        /// </summary>
        protected void btnLagre_Click(object sender, EventArgs e)
        {
            //Sjekke etter tom/null input
            if (!String.IsNullOrEmpty(textBoxNavn.Text) || !String.IsNullOrEmpty(textBoxOppsummering.Text)
                || !String.IsNullOrEmpty(textBoxNesteFase.Text))
            {
                //Hente input
                navn = textBoxNavn.Text;
                oppsummering = textBoxOppsummering.Text;
                nesteFase = textBoxNesteFase.Text;

                insertOK = connection.insertProject(navn, oppsummering, nesteFase); //lagre boolsk returverdi

                resultBox.Text = "Result: " + insertOK;
            }
               
            else resultBox.Text = "Feltene kan ikke være tomme!";
           
        }


        /// <summary>
        /// Slette prosjekt
        /// </summary>
        protected void btnSlett_Click(object sender, EventArgs e)
        {
            try
            {
                //Sjekke etter tom/null input
                if (!String.IsNullOrEmpty(textBoxProsjektID.Text))
                {
                    int id = Convert.ToInt32(textBoxProsjektID.Text);
                    deleteOK = connection.delProject(id); //lagre boolsk returverdi

                    prosjektInfoBox.Text = "Prosjekt ID: " + textBoxProsjektID.Text + "\nResultat: " + deleteOK;
                }
                else prosjektInfoBox.Text = "Feltene kan ikke være tomme!";
            }
            catch (FormatException formatException){textBoxConnectResult.Text = "Format Exception: " + formatException.Message;}
            catch (OverflowException overFlowException){textBoxConnectResult.Text = "Overflow Exception: " + overFlowException.Message;}
            catch (Exception ex){textBoxConnectResult.Text = "Exception: " + ex.Message;}
        }

        /// <summary>
        /// Redigere prosjekt
        /// </summary>

        protected void btnLagreNewProject_Click(object sender, EventArgs e)
        {
            try
            {
                //Sjekke etter tom/null input
                if (!String.IsNullOrEmpty(textBoxProjectIDForEdit.Text) || !String.IsNullOrEmpty(textBoxNewNavn.Text) ||
                    !String.IsNullOrEmpty(textBoxNewOppsummering.Text) || !String.IsNullOrEmpty(textBoxNewNesteFase.Text))
                {
                    int id = Convert.ToInt32(textBoxProjectIDForEdit.Text); 
                    nyttNavn = textBoxNewNavn.Text;
                    nyOppsummering = textBoxNewOppsummering.Text;
                    nyNesteFase = textBoxNewNesteFase.Text;

                    editOK = connection.editProject(id, nyttNavn, nyOppsummering, nyNesteFase); //lagre boolsk returverdi

                    textBoxNewDetails.Text = "Prosjekt ID: " + id + "\nNytt navn: " + nyttNavn + "\nNy Oppsummering: " + nyOppsummering + "\n Ny Neste Fase: "
                        + nyNesteFase + "\n\n Edit OK: " + editOK;
                }
                else textBoxNewDetails.Text = "Feltene kan ikke være tomme!";
            }

            catch (FormatException formatException){textBoxConnectResult.Text = "Format Exception: " + formatException.Message;}
            catch (OverflowException overFlowException){textBoxConnectResult.Text = "Overflow Exception: " + overFlowException.Message;}
            catch (Exception ex){textBoxConnectResult.Text = "Exception: " + ex.Message;}

        }


        /// <summary>
        /// Koble Team til Prosjekt
        /// </summary>
        protected void btnConnectTeamProject_Click(object sender, EventArgs e) 
        {
            try
            {
                //Sjekke etter tom/null input
                if (!String.IsNullOrEmpty(textBoxConnectProjectID.Text) || !String.IsNullOrEmpty(textBoxConnectTeamID.Text))
                {
                    int prosjektID = Convert.ToInt32(textBoxConnectProjectID.Text);
                    int teamID = Convert.ToInt32(textBoxConnectTeamID.Text);
                    connectOK = connection.connectTeamToProject(teamID, prosjektID); //lagre boolsk returverdi

                    textBoxConnectResult.Text = "Koblet prosjekt med prosjektID lik " + prosjektID + " til team med teamID lik " + teamID + "\nResultatet er: " + connectOK;
                }
                else textBoxConnectResult.Text = "Feltene kan ikke være tomme!";
            }
            catch (FormatException formatException){ textBoxConnectResult.Text = "Exception: " + formatException.Message; }
            catch (OverflowException overFlowException){ textBoxConnectResult.Text = "Exception: " + overFlowException.Message; }
            catch(Exception ex) { textBoxConnectResult.Text = "Exception: " + ex.Message; }
        }


    }
}