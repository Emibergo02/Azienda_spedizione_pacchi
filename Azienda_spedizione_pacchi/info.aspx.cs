using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Azienda_spedizione_pacchi
{
    public partial class info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cliente c = null;
            if (!Page.IsPostBack)
                if (Session["clienteLoggato"] != null)
                {
                    c = (Cliente)Session["clienteLoggato"];
                    if (c.Utente.Privilegi != 1)
                    {
                        Response.Redirect("LogIn.aspx");
                        return;
                    }
                }
                else
                {
                    Response.Redirect("LogIn.aspx");
                    return;
                }
            c = loadData();
            fillLiteral(c);
        }

        private void fillLiteral(Cliente c)
        {
            nome.Text = c.Nome;
            cognome.Text = c.Cognome;
            username.Text = c.Utente.Username;
            indirizzo.Text = c.Indirizzo;
        }

        private Cliente loadData()
        {
           Cliente c = (Cliente)Session["clienteLoggato"];
            return c;

        }
    }
}