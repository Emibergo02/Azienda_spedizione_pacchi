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
            else
            {

                return;
            }
            //Immagine utente
            if (File.Exists(Server.MapPath(Path.Combine("~/Uploads/", c.IdCliente + ".png"))))
            {
                profileimg.ImageUrl = "Uploads/" + c.IdCliente + ".png?" + DateTime.Now.Ticks.ToString();

            }
            else profileimg.ImageUrl = "Uploads/default.jpg";
            List<Pacco> listaPacchi = DataAccess.OttieniListaPacchi(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString, c.IdCliente);


            rptViaggi.DataSource = listaPacchi;
            rptViaggi.DataBind();

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