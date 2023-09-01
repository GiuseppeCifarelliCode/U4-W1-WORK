using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Imposta
{
    internal class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string DataNascita { get; set; }
        public string Sesso { get; set; }
        public string ComuneResidenza { get; set; }

        public string CodiceFiscale { get; set; }
        public double RedditoAnnuale { get; set; }

        public double Imposta;

        public Contribuente() { }

        public Contribuente(string nome, string cognome, string dataNascita, string sesso, string comuneResidenza, string codiceFiscale, double redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            CodiceFiscale = codiceFiscale;
            RedditoAnnuale = redditoAnnuale;
        }
    }
}
