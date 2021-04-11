﻿using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

        public void fillDropListUtente()
        {
            List<int> idClienti;
            List<string> listaNomeCognome;
            List<int> Viaggi;
            string connectionString =
                       ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString;
            DataAccess.GetDataSource(out Viaggi, out idClienti, out listaNomeCognome, connectionString);

            var numbersAndWords = idClienti.Zip(listaNomeCognome, (n, w) => new { Number = n, Word = w });
            foreach (var nw in numbersAndWords)
            {
                mittente.Items.Add(new ListItem(nw.Word, nw.Number.ToString()));
                destinatario.Items.Add(new ListItem(nw.Word, nw.Number.ToString()));

            }
            foreach (int v in Viaggi)
            {
                viaggio.Items.Add(v.ToString());
            }

        }

        protected void submitReg_Click(object sender, EventArgs e)
        {
            if (mittente.SelectedItem.Value.Equals(""))
            {
                msgErrorRegister.Text = "mittente vuoto";
                return;
            }
            if (destinatario.SelectedItem.Value.Equals(""))
            {
                msgErrorRegister.Text = "destinatario vuoto";
                return;
            }
            if (viaggio.SelectedItem.Value.Equals(""))
            {
                msgErrorRegister.Text = "viaggio vuoto";
                return;
            }
            int volumeint;
            if (!Int32.TryParse(volume.Text, out volumeint))
            {
                msgErrorRegister.Text = "volume non è un numero";
                return;
            }

            DataAccess.InserisciPacco(ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString, viaggio.SelectedItem.Value, mittente.SelectedItem.Value, destinatario.SelectedItem.Value, volumeint);
            msgErrorRegister.Text = "completato con successo";

            mittente.Items.Clear();
            destinatario.Items.Clear();
            viaggio.Items.Clear();
        }
    }
}