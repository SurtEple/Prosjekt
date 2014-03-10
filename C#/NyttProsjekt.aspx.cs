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
        private bool commandOK = false;
        private String navn, oppsummering, nesteFase, insertQ;


        protected void Page_Load(object sender, EventArgs e)
        {

           
        }

        protected void btnLagre_Click(object sender, EventArgs e)
        {
            navn = textBoxNavn.Text;
            oppsummering = textBoxOppsummering.Text;
            nesteFase = textBoxNesteFase.Text;

            if (navn!=null && oppsummering!=null && nesteFase!=null)
                commandOK = connection.insertProject(navn, oppsummering, nesteFase);

            resultBox.Text = "Result: " + commandOK;
        }


    }
}