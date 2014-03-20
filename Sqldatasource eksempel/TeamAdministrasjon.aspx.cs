using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Timeregistreringssystem
{
    public partial class TeamAdministrasjon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridViewTeam_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void btnNyttTeam_Click(object sender, EventArgs e)
        {
            Server.Transfer("OpprettTeam.aspx");
        }

        protected void gridViewTeam_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Sjekk etter ugyldig input
        }

        protected void gridViewTeam_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
        }
    }
}