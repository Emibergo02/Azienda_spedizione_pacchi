using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web.UI;

namespace Azienda_spedizione_pacchi
{
    public partial class dettaglioViaggio : System.Web.UI.Page
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



            if (Request.QueryString["idViaggio"] != null)
            {
                int id = 0;
                if (!int.TryParse(Request.QueryString["idViaggio"], out id))
                {
                    Response.Redirect("AdminView.aspx");
                }

                List<Pacco> pacchiviaggio = DataAccess.OttieniListaPacchiOrdinata(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString, "Cliente", true);
                List<Pacco> pacchiselezionati = new List<Pacco>();
                foreach (Pacco p in pacchiviaggio)
                {
                    if (p.Viaggio.IdViaggio == id)
                    {
                        pacchiselezionati.Add(p);
                    }
                }
                rptPacchi.DataSource = pacchiselezionati;
                rptPacchi.DataBind();
            }
            else Response.Redirect("AdminView.aspx");

        }
    }
}