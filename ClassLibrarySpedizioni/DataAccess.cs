using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace ClassLibrarySpedizioni
{
    public class DataAccess
    {

        public static List<Viaggio> OttieniListaViaggi(string connectionString)
        {
            List<Viaggio> lista = new List<Viaggio>();
            string queryString = "SELECT * FROM viaggio INNER JOIN veicolo ON viaggio.idVeicolo = veicolo.targa";
            string messaggio = "";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Veicolo veicolo = new Veicolo(dr["targa"].ToString(), dr["marca"].ToString(), dr["modello"].ToString(),
                            (int)dr["capacitaMax"], (int)dr["pesoMax"]);
                        Viaggio v = new Viaggio((int)dr["idViaggio"], veicolo, dr["nomeCorriere"].ToString(), (DateTime)dr["data"]);
                        lista.Add(v);
                    }
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
            return lista;
        }
        public static List<Veicolo> OttieniListaVeicoli(string connectionString)
        {
            List<Veicolo> lista = new List<Veicolo>();
            string queryString = "SELECT * FROM veicolo";
            string messaggio = "";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Veicolo veicolo = new Veicolo(dr["targa"].ToString(), dr["marca"].ToString(), dr["modello"].ToString(),
                            (int)dr["capacitaMax"], (int)dr["pesoMax"]);
                        
                        lista.Add(veicolo);
                    }
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
            return lista;
        }

        public static List<Cliente> OttieniListaClienti(string connectionString)
        {
            List<Cliente> lista = new List<Cliente>();
            string queryString = "SELECT * FROM cliente INNER JOIN utenti ON utenti.idCliente = cliente.idCliente";
            string messaggio = "";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Utente utente = new Utente(dr["username"].ToString(), dr["password"].ToString(), (int)dr["privilegi"]);
                        Cliente c = new Cliente((int)dr["idCliente"], dr["nome"].ToString(), dr["cognome"].ToString(), dr["indirizzo"].ToString(), utente);
                        lista.Add(c);
                    }
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
            return lista;
        }

        public static List<Pacco> OttieniListaPacchi(string connectionString, List<Viaggio> listaViaggi, List<Cliente> listaClienti)
        {
            List<Pacco> lista = new List<Pacco>();
            string queryString = "SELECT * FROM Pacco";
            string messaggio = "";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Pacco p = new Pacco((int)dr["idPacco"], listaViaggi.Find(x => x.IdViaggio == (int)dr["idViaggio"]), listaClienti.Find(x => x.IdCliente == (int)dr["idMittente"]), listaClienti.Find(x => x.IdCliente == (int)dr["idDestinatario"]), (int)dr["Volume"], (int)dr["numOrdineConsegna"]);
                    }
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
            return lista;
        }
        public static List<Pacco> OttieniListaPacchi(string connectionString)
        {
            List<Viaggio> listaViaggi = OttieniListaViaggi(connectionString);
            List<Cliente> listaClienti = OttieniListaClienti(connectionString);

            List<Pacco> lista = new List<Pacco>();
            string queryString = "SELECT * FROM Pacco";
            string messaggio = "";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Pacco p = new Pacco((int)dr["idPacco"], listaViaggi.Find(x => x.IdViaggio == (int)dr["idViaggio"]), listaClienti.Find(x => x.IdCliente == (int)dr["idMittente"]), listaClienti.Find(x => x.IdCliente == (int)dr["idDestinatario"]), (int)dr["Volume"], (int)dr["numOrdineConsegna"]);
                    }
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
            return lista;
        }
        public static void InserisciCliente(string connectionString,string nomeCliente,string cognomeCliente,string indirizzo,string username,string password,int privilegi)
        {
            List<Cliente> lista = new List<Cliente>();
            string queryString = "INSERT INTO cliente (idCliente,nome,cognome,indirizzo) VALUES(NULL,@NomeCliente,@CognomeCliente,@IndirizzoCliente);" +
                            "INSERT INTO utenti(username, password, privilegi, idCliente) VALUES(@Username, @Password, @Privilegi, LAST_INSERT_ID()); ";
            string messaggio = "";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    //parametri per evitare SQL Injection
                    command.Parameters.AddWithValue("@NomeCliente", nomeCliente);
                    command.Parameters.AddWithValue("@CognomeCliente", cognomeCliente);
                    command.Parameters.AddWithValue("@IndirizzoCliente", indirizzo);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Privilegi", privilegi);
                    command.ExecuteNonQuery();
                    command.Dispose();

                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
        }
        public static void InserisciVeicolo(string connectionString, string targa, string marca, string modello, int capacitàMax, int pesoMax)
        {
            List<Cliente> lista = new List<Cliente>();
            string queryString = "INSERT INTO `veicolo` (`targa`, `marca`, `modello`, `capacitaMax`, `pesoMax`) VALUES ('@targa', '@marca', '@modello', '@capacitàMax', '@pesoMax');";
            string messaggio = "";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    //parametri per evitare SQL Injection
                    command.Parameters.AddWithValue("@targa", targa);
                    command.Parameters.AddWithValue("@marca", marca);
                    command.Parameters.AddWithValue("@modello", modello);
                    command.Parameters.AddWithValue("@capacitàMax", capacitàMax);
                    command.Parameters.AddWithValue("@pesoMax", pesoMax);
                   
                    command.ExecuteNonQuery();
                    command.Dispose();

                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
        }

        public static void InserisciViaggio(string connectionString, string veicolo, string nomeCorriere, DateTime data)
        {
            List<Cliente> lista = new List<Cliente>();
            string queryString = "INSERT INTO `viaggio` (`idViaggio`, `idVeicolo`, `data`, `nomeCorriere`) VALUES (NULL,@idVeicolo,@data,@nomeCorriere);";
            string messaggio = "";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    //parametri per evitare SQL Injection
                    command.Parameters.AddWithValue("@idVeicolo", veicolo);
                    command.Parameters.AddWithValue("@data", data);
                    command.Parameters.AddWithValue("@nomeCorriere", nomeCorriere);
                    command.ExecuteNonQuery();
                    command.Dispose();

                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
        }
        public static string ComputeSha256Hash(string salt,string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(salt+rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static void InserisciPacco(string connectionString, Veicolo veicolo, string nomeCorriere, DateTime data)
        {
            List<Cliente> lista = new List<Cliente>();
            string queryString = "INSERT INTO `viaggio` (`idViaggio`, `idVeicolo`, `data`, `nomeCorriere`) VALUES (NULL,@idVeicolo,@data,@nomeCorriere);";
            string messaggio = "";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    //parametri per evitare SQL Injection
                    command.Parameters.AddWithValue("@idVeicolo", veicolo);
                    command.Parameters.AddWithValue("@data", data);
                    command.Parameters.AddWithValue("@nomeCorriere", nomeCorriere);
                    command.ExecuteNonQuery();
                    command.Dispose();

                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
        }
        /*
         * 
         */
        public static void GetDataSource(out List<int> Viaggi,out List<int> idCLienti, out List<string> listaNomeCognome, string connectionString)
        {
            Viaggi = new List<int>();
            idCLienti = new List<int>();
            listaNomeCognome = new List<string>();
            List <Cliente> lista = OttieniListaClienti(connectionString);
            List<Viaggio> V = OttieniListaViaggi(connectionString);
            List<string> listaDropDown = new List<string>();
            foreach (Cliente c in lista)
            {
                idCLienti.Add(c.IdCliente);
                listaNomeCognome.Add(c.Cognome + "-" + c.Nome);
            }
            foreach(Viaggio v in V)
            {
                Viaggi.Add(v.IdViaggio);
            }
        }



    }
}
