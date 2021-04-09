using ClassLibrarySpedizioni;
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
            if (!Page.IsPostBack)
                if (Session["clienteLoggato"] != null)
                {
                    Cliente c = (Cliente)Session["clienteLoggato"];
                    if (c.Utente.Privilegi != 0) Response.Redirect("LogIn.aspx");
                }
                else Response.Redirect("LogIn.aspx");
            fillDropListUtente();
        }
        public void fillDropListViaggi() 
        {
            
        }
        public void fillDropListUtente()
        {
            List<int> idClienti;
            List<string> listaNomeCognome;
            List<int> Viaggi;
            string connectionString =
                       ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString;
            DataAccess.GetDataSource(out Viaggi,out idClienti,out listaNomeCognome, connectionString);

            var numbersAndWords = idClienti.Zip(listaNomeCognome, (n, w) => new { Number = n, Word = w });
            foreach (var nw in numbersAndWords)
            {
                mittente.Items.Add(new ListItem(nw.Word, nw.Number.ToString()));
                destinatario.Items.Add(new ListItem(nw.Word, nw.Number.ToString()));
                
            }
            foreach(int v in Viaggi)
            {
                viaggio.Items.Add(v.ToString());
            }
            
        }

        
    }
}