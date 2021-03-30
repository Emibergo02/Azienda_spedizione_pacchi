using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySpedizioni
{
    public class Cliente
    {
        private int idCliente;
        private string nome;
        private string cognome;
        private string indirizzo;

        public Cliente(int idCliente, string nome, string cognome, string indirizzo)
        {
            this.idCliente = idCliente;
            this.nome = nome;
            this.cognome = cognome;
            this.indirizzo = indirizzo;
        }

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Indirizzo { get => indirizzo; set => indirizzo = value; }
    }
}
