using ClassLibrarySpedizioni;
using System;
using System.Configuration;

namespace Azienda_spedizione_pacchi
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitReg_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            Cliente c = DataAccess.OttieniListaUtenti(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString).Find(client => client.Utente.Username.Equals(username));

            if (c.Utente.Password.Equals(DataAccess.ComputeSha256Hash("questoèunsalt", password)))
            {
                /* msgError.Text = "Login effettuato";*/
                Session["clienteLoggato"] = c;
                if (c.Utente.Privilegi == 1)
                    Response.Redirect("UserView.aspx");
                else
                    Response.Redirect("AdminView.aspx");
            }
            else msgErr.Text = "Password errata";

        }

    }
}