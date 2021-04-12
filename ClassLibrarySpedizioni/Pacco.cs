namespace ClassLibrarySpedizioni
{
    public class Pacco
    {
        private int idPacco;
        private Viaggio viaggio;
        private Cliente mittente;
        private Cliente destinatario;
        private int volume;

        public Pacco(int idPacco, Viaggio viaggio, Cliente mittente, Cliente destinatario, int volume)
        {
            this.idPacco = idPacco;
            this.viaggio = viaggio;
            this.mittente = mittente;
            this.destinatario = destinatario;
            this.volume = volume;

        }

        public int IdPacco { get => idPacco; set => idPacco = value; }
        public Cliente Mittente { get => mittente; set => mittente = value; }
        public Cliente Destinatario { get => destinatario; set => destinatario = value; }
        public int Volume { get => volume; set => volume = value; }
        public Viaggio Viaggio { get => viaggio; set => viaggio = value; }

    }
}
