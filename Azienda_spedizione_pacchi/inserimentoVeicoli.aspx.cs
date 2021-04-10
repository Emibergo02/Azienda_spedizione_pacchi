using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Azienda_spedizione_pacchi
{
    public partial class inserimentoVeicoli : System.Web.UI.Page
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

            
            
        }

        protected void submitReg_Click(object sender, EventArgs e)
        {
            Regex rgx = new Regex("/^[a-zA-Z]{2}[0-9]{3,4}[a-zA-Z]{2}$/");
            if (rgx.IsMatch(targa.Text))
            {
                msgErrorRegister.Text = "Il formato della Targa non è corretto";
                return;
            }
            if (marca.Text.Equals(""))
            {
                msgErrorRegister.Text = "inserire una marca";
                return;
            }
            if (modello.Text.Equals(""))
            {
                msgErrorRegister.Text = "inserire una marca";
                return;
            }
            int isNum = 0;
            
            if (int.TryParse(capacita.Text, out isNum))
            {
                if (isNum < 0)
                {
                    msgErrorRegister.Text = "numero minore di zero";
                    return;
                }
            }
            else
            {
                msgErrorRegister.Text = "non è stato inserito un numero, oppure non era intero";
                return;
            }
            isNum = 0;

            if(int.TryParse(pesoMax.Text, out isNum))
            {
                if (isNum < 0)
                {
                    msgErrorRegister.Text = "numero minore di zero";
                    return;
                }
            }
            else
            {
                msgErrorRegister.Text = "non è stato inserito un numero, oppure non era intero";
                return;
            }
            string connectionString =
                       ConfigurationManager.ConnectionStrings["ConnectionStringAziendaSpedizionePacchiMySQL"].ConnectionString;
            DataAccess.InserisciVeicolo(connectionString, targa.Text,marca.Text,modello.Text,int.Parse(capacita.Text),int.Parse(pesoMax.Text));

        }


        }
    }
