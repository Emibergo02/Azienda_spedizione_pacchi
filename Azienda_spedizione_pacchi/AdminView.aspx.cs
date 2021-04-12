using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace Azienda_spedizione_pacchi
{
    public partial class AdminView : System.Web.UI.Page
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
            List<Pacco> pacchisortati = DataAccess.OttieniListaPacchiOrdinata(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString, "Cliente",false);
            rptPacchi.DataSource = pacchisortati;
            rptPacchi.DataBind();
            List<Viaggio> listaViaggi = DataAccess.OttieniListaViaggi(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString);

            rptViaggi.DataSource = listaViaggi;
            rptViaggi.DataBind();
        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorttype = ddlSort.SelectedValue;
            List<Pacco> pacchisortati = DataAccess.OttieniListaPacchiOrdinata(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString, sorttype, cbvedidata.Checked);
            rptPacchi.DataSource = pacchisortati;
            rptPacchi.DataBind();

        }
    }
}