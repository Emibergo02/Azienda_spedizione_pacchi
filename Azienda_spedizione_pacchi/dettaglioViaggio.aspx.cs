using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azienda_spedizione_pacchi
{
    public partial class dettaglioViaggio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idViaggio = Int32.Parse(Request.QueryString["idViaggio"]);
            Viaggio v = ((List<Viaggio>)Session["listaViaggi"]).First(viaggio => viaggio.IdViaggio == idViaggio);
            int i = 1;


        }
    }
}