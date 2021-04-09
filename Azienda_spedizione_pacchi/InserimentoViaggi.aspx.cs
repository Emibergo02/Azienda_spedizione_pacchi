using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                }
                else Response.Redirect("LogIn.aspx");

            List<string> targheVeicoli = new List<string>();
            foreach(Veicolo v in DataAccess.OttieniListaVeicoli(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString))
            {
                targheVeicoli.Add(v.Targa);
            }

            ddlTarghe.DataSource = targheVeicoli;
            this.DataBind();
        }

        protected void submitReg_Click(object sender, EventArgs e)
        {
            string a = ddlTarghe.SelectedItem.Value;
            string b = ddlTarghe.SelectedItem.Text;
            if (ddlTarghe.SelectedItem.Value.Equals("")) return;
            DateTime dataViaggio;
            try {
                dataViaggio = Convert.ToDateTime(data.Text);
            }catch (FormatException fe)
            {

                return;
            }
            if(nomeCorriere.Text.Equals(""))return;
            msgErrorRegister.Text = ddlTarghe.SelectedItem.Value + "Fatto" +dataViaggio.ToString()+ nomeCorriere.Text;
        }
    }
}