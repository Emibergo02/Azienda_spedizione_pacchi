using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace Azienda_spedizione_pacchi
{
    public partial class UserView : System.Web.UI.Page
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

            List<Pacco> listaPacchi = DataAccess.OttieniListaPacchi(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString,c.IdCliente);


            rptViaggi.DataSource = listaPacchi;
            rptViaggi.DataBind();

        }
    }
}