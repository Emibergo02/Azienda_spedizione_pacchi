using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Azienda_spedizione_pacchi
{
    public partial class inserimentoPacchi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fillDropListUtente();
        }
           
        public void fillDropListUtente()
        {
            if (Session["dropIndex"] == null)
            {
                string connectionString =
                       ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString;
                //SELECT gara.idGara FROM gara
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Create the Command and Parameter objects.
                    MySqlCommand command = new MySqlCommand("SELECT cliente.nome,cliente.cognome,cliente.idCliente from cliente", connection);
                    // Open the connection in a try/catch block. Use a DataAdapter to Fill a DataSet Object
                    try
                    {
                        connection.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        destinatario.DataSource = dt;
                        mittente.DataSource = dt;
                        mittente.DataTextField = dt.Columns["cognome"].ToString() ;
                        mittente.DataValueField = dt.Columns["idCliente"].ToString();
                        mittente.DataBind();
                        destinatario.DataTextField = dt.Columns["nome"].ToString();
                        destinatario.DataValueField = dt.Columns["idCliente"].ToString();
                        destinatario.DataBind();
                        Session["dropIndex"] = dt;
                    }
                    catch
                    {

                    }
                }

            }
        }

        
    }
}