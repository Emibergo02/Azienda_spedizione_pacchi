using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySpedizioni
{
    public class Veicolo
    {
        private string targa;
        private string marca;
        private string modello;
        private int capacitaMax;
        private int pesoMax;

        public Veicolo(string targa, string marca, string modello, int capacitaMax, int pesoMax)
        {
            this.targa = targa;
            this.marca = marca;
            this.modello = modello;
            this.capacitaMax = capacitaMax;
            this.pesoMax = pesoMax;
        }

        public string Targa { get => targa; set => targa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modello { get => modello; set => modello = value; }
        public int CapacitaMax { get => capacitaMax; set => capacitaMax = value; }
        public int PesoMax { get => pesoMax; set => pesoMax = value; }
    }
}
