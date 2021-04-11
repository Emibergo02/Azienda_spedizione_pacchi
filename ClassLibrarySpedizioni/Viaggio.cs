using System;

namespace ClassLibrarySpedizioni
{
    public class Viaggio
    {
        private int idViaggio;
        private Veicolo veicolo;
        private string nomeCorriere;
        private DateTime data;

        public Viaggio(int idViaggio, Veicolo veicolo, string nomeCorriere, DateTime data)
        {
            this.idViaggio = idViaggio;
            this.veicolo = veicolo;
            this.nomeCorriere = nomeCorriere;
            this.data = data;
        }

        public int IdViaggio { get => idViaggio; set => idViaggio = value; }
        public Veicolo Veicolo { get => veicolo; set => veicolo = value; }
        public string NomeCorriere { get => nomeCorriere; set => nomeCorriere = value; }
        public DateTime Data { get => data; set => data = value; }
        public string Targa { get => veicolo.Targa; }
    }
}
