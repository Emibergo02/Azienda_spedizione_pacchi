using ClassLibrarySpedizioni;
using System;
using System.IO;
using System.Web.UI;

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
                    if (File.Exists(Server.MapPath(Path.Combine("~/Uploads/", c.IdCliente + ".png"))))
                    {
                        profileimg.ImageUrl = "Uploads/" + c.IdCliente + ".png?" + DateTime.Now.Ticks.ToString();

                    }
                    else profileimg.ImageUrl = "Uploads/default.jpg";
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