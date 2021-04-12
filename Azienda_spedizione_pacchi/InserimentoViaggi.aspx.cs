using ClassLibrarySpedizioni;
using System;
using System.Configuration;
using System.IO;
using System.Web.UI;

namespace Azienda_spedizione_pacchi.adminPage
{
    public partial class InserimentoViaggi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                if (Session["clienteLoggato"] != null)
                {
                    Cliente c = (Cliente)Session["clienteLoggato"];
                    if (c.Utente.Privilegi != 0) Response.Redirect("LogIn.aspx");
                    if (File.Exists(Server.MapPath(Path.Combine("~/Uploads/", c.IdCliente + ".png"))))
                    {
                        profileimg.ImageUrl = "Uploads/" + c.IdCliente + ".png?" + DateTime.Now.Ticks.ToString();

                    }
                    else profileimg.ImageUrl = "Uploads/default.jpg";
                }
                else Response.Redirect("LogIn.aspx");


            foreach (Veicolo v in DataAccess.OttieniListaVeicoli(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString))
            {
                ddlTarghe.Items.Add(v.Targa);
            }
        }

        protected void submitReg_Click(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString;
            if (ddlTarghe.SelectedItem.Value.Equals(""))
            {
                msgErrorRegister.Text = "Non hai selezionato niente";
                return;
            }
            DateTime dataViaggio;
            try
            {
                dataViaggio = Convert.ToDateTime(data.Text);
            }
            catch (FormatException fe)
            {
                msgErrorRegister.Text = "data con formato sbagliato";
                return;
            }
            if (nomeCorriere.Text.Equals(""))
            {
                msgErrorRegister.Text = "nome corriere vuoto";
                return;
            }
            DataAccess.InserisciViaggio(conn, ddlTarghe.SelectedItem.Value, nomeCorriere.Text, dataViaggio);
            msgErrorRegister.Text = "Inserito correttamente";
            ddlTarghe.Items.Clear();

        }
    }
}