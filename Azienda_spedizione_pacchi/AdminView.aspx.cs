using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
                    if (File.Exists(Server.MapPath(Path.Combine("~/Uploads/", c.IdCliente + ".png"))))
                    {
                        profileimg.ImageUrl = "Uploads/" + c.IdCliente + ".png?" + DateTime.Now.Ticks.ToString();

                    }
                    else profileimg.ImageUrl = "Uploads/default.jpg";
                }
                else Response.Redirect("LogIn.aspx");


            List<Pacco> pacchisortati = DataAccess.OttieniListaPacchiOrdinata(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString, "Cliente", false);
            rptPacchi.DataSource = pacchisortati;
            rptPacchi.DataBind();
            List<Viaggio> listaViaggi = DataAccess.OttieniListaViaggi(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString);

            rptViaggi.DataSource = listaViaggi;
            rptViaggi.DataBind();

            List<Veicolo> listaVeicoli = DataAccess.OttieniListaVeicoli(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString);
            Repeater1.DataSource = listaVeicoli;
            Repeater1.DataBind();
        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorttype = ddlSort.SelectedValue;
            List<Pacco> pacchisortati = DataAccess.OttieniListaPacchiOrdinata(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString, sorttype, cbvedidata.Checked);
            rptPacchi.DataSource = pacchisortati;
            rptPacchi.DataBind();

        }
        protected void btnupload_Click(object sender, EventArgs e)
        {
            //Immagine utente
            if (fileUpload1.HasFile)
            {
                Cliente c = (Cliente)Session["clienteLoggato"];
                string path = Server.MapPath(Path.Combine("~/Uploads/", c.IdCliente + ".png"));
                if (File.Exists(path)) File.Delete(path);
                Image png = Image.FromStream(fileUpload1.PostedFile.InputStream);
                png.Save(path, ImageFormat.Png);
                profileimg.ImageUrl = "Uploads/" + c.IdCliente + ".png?" + DateTime.Now.Ticks.ToString();
            }
        }
    }
}