using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Azienda_spedizione_pacchi
{
    public partial class viaggi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Viaggio> listaViaggi = DataAccess.OttieniListaViaggi(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString);
            rptViaggi.DataSource = listaViaggi;
            rptViaggi.DataBind();
            Session["listaViaggi"] = listaViaggi;
        }
    }
}