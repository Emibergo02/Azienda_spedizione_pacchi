using ClassLibrarySpedizioni;
using System;
using System.Configuration;
using System.Security.Cryptography;

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
            Utente u=DataAccess.OttieniListaClienti(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString).Find(client => client.Utente.Username.Equals(username)).Utente;
            
            if (u.Password.Equals(DataAccess.ComputeSha256Hash("questoèunsalt", password)))
            {
                msgError.Text = "Login effettuato";
            }
        }

    }
}