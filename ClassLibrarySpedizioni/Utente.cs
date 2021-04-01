using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySpedizioni
{
    public class Utente
    {
        private string username;
        private string password;
        private int privilegi;

        public Utente(string username,string password,int privilegi)
        {
            this.username = username;
            this.password = password;
            this.privilegi = privilegi;

        }

        public string Username { get => username; }
        public string Password { get => password; }
        public int Privilegi { get => privilegi; set => privilegi = value; }
    }
}
