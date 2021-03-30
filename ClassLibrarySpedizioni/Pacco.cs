using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySpedizioni
{
    public class Pacco
    {
        private int idPacco;
        private Viaggio viaggio;
        private Cliente mittente;
        private Cliente destinatario;
        private int nOrdineConsegna;
        private int volume;

        public Pacco(int idPacco, Viaggio viaggio, Cliente mittente, Cliente destinatario, int nOrdineConsegna, int volume)
        {
            this.idPacco = idPacco;
            this.viaggio = viaggio;
            this.mittente = mittente;
            this.destinatario = destinatario;
            this.nOrdineConsegna = nOrdineConsegna;
            this.volume = volume;
        }

        public int IdPacco { get => idPacco; set => idPacco = value; }
        public Cliente Mittente { get => mittente; set => mittente = value; }
        public Cliente Destinatario { get => destinatario; set => destinatario = value; }
        public int NOrdineConsegna { get => nOrdineConsegna; set => nOrdineConsegna = value; }
        public int Volume { get => volume; set => volume = value; }
        internal Viaggio Viaggio { get => viaggio; set => viaggio = value; }
    }
}
