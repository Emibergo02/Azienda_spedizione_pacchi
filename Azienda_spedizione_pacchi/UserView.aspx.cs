using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Azienda_spedizione_pacchi
{
    public partial class UserView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                if (Session["clienteLoggato"] != null)
                {
                    Cliente c = (Cliente)Session["clienteLoggato"];
                    if (c.Utente.Privilegi != 1) Response.Redirect("LogIn.aspx");

                    List<Pacco> listaPacchi = DataAccess.OttieniListaPacchi(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString);
                    List<Pacco> listaPacchiCliente = new List<Pacco>();
                    foreach(Pacco p in listaPacchi)
                    {
                        if(p.Destinatario!=null)
                        if (p.Destinatario.IdCliente == c.IdCliente)
                            listaPacchiCliente.Add(p);
                    }
                    
                    rptViaggi.DataSource = listaPacchiCliente;
                    rptViaggi.DataBind();
                }
                else Response.Redirect("LogIn.aspx");

        }
    }
}