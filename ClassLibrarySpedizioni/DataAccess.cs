using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

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

        public static void inserisciViaggio(string connectionString, Veicolo veicolo, string nomeCorriere, DateTime data)
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

        public static void inserisciPacco(string connectionString, Veicolo veicolo, string nomeCorriere, DateTime data)
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


    }
}
