using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Azienda_spedizione_pacchi
{
    public partial class Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitReg_Click(object sender, EventArgs e)
        {
            List<Cliente> clienti = DataAccess.OttieniListaClienti(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString);
            if (clienti.Find(cl => cl.Utente.Username == txtUsername.Text) != null)
            {
                msgErrorRegister.Text = "L'username è già stato scelto";
                return;
            }
            else
            if (!txtPassword.Text.Equals(txtPasswordConfirm.Text))
            {
                msgErrorRegister.Text = "La password non è uguale";
                return;
            }
            else
            if (txtNome.Text.Equals(""))
            {
                msgErrorRegister.Text = "il nome è vuoto";
                return;
            }
            else if (txtCognome.Text.Equals(""))
            {
                msgErrorRegister.Text = "il cognome è vuoto";
                return;
            }
            else if (txtindirizzo.Text.Equals(""))
            {
                msgErrorRegister.Text = "l'indirizzo è vuoto";
                return;
            }
            DataAccess.InserisciCliente(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString, txtNome.Text, txtCognome.Text, txtindirizzo.Text, txtUsername.Text, DataAccess.ComputeSha256Hash("questoèunsalt",txtPassword.Text), 1);
            msgErrorRegister.Text = "Bene";
        }
    }
}