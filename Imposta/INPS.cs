using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Imposta
{
    internal class INPS
    {
        private static Contribuente contribuente;
        private static List<Contribuente> listaContribuenti = new List<Contribuente>();

        public static void MostraMenu()
        {
            Console.WriteLine("=================MENU================");
            Console.WriteLine("1. Inserimento nuova dichiarazione");
            Console.WriteLine("2. Mostra Lista dei Contribuenti");
            Console.WriteLine("3. ESCI");
            Console.WriteLine("=================MENU================");

            int option = int.Parse(Console.ReadLine());
            try {
                if (option < 0 || option > 3)
                {
                    Console.WriteLine("L'opzione scelta non esiste");
                    MostraMenu();
                }
                else
                {
                    switch (option)
                    {
                        case 1:
                            NuovaDichiarazione();
                            CalcoloImposta();
                            MostraContribuente();
                            MostraMenu();
                            break;
                        case 2:
                            MostraLista();
                            MostraMenu();
                            break;
                        case 3:
                            Console.WriteLine("Premi INVIO per uscire dal programma");
                            break;
                    }
                }
            }
            catch {
                Console.WriteLine("L'opzione scelta non esiste");
                MostraMenu();
            }
        }

        public static void NuovaDichiarazione()
        {
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Cognome:");
            string cognome = Console.ReadLine();
            Console.WriteLine("Data di nascita:");
            string dataNascita = Console.ReadLine();
            Console.WriteLine("Sesso:");
            string sesso = Console.ReadLine();
            Console.WriteLine("Comune di Residenza:");
            string residenza = Console.ReadLine();
            Console.WriteLine("Codice Fiscale:");
            string codiceFiscale = Console.ReadLine();

            Console.WriteLine("Reddito Annuale:");
            double redditoAnnuale = double.Parse(Console.ReadLine());
            contribuente = new Contribuente(nome, cognome, dataNascita, sesso, residenza, codiceFiscale, redditoAnnuale);            
        }    
        
        public static double CalcoloImposta()
        {
            if( contribuente.RedditoAnnuale <= 15000 && contribuente.RedditoAnnuale >= 0)
            {
                contribuente.Imposta = contribuente.RedditoAnnuale * 0.23;
                listaContribuenti.Add(contribuente);
                return contribuente.Imposta;
            }
            else if(contribuente.RedditoAnnuale > 15000 && contribuente.RedditoAnnuale <= 28000)
            {
                contribuente.Imposta = 3450 + (contribuente.RedditoAnnuale - 15000) * 0.27;
                listaContribuenti.Add(contribuente);
                return contribuente.Imposta;           
            }
            else if( contribuente.RedditoAnnuale > 28000 && contribuente.RedditoAnnuale <= 55000)
            {
                contribuente.Imposta = 6960 + (contribuente.RedditoAnnuale - 28000) * 0.38;
                listaContribuenti.Add(contribuente);
                return contribuente.Imposta;
            }
            else if (contribuente.RedditoAnnuale > 55000 && contribuente.RedditoAnnuale <= 75000)
            {
                contribuente.Imposta = 17220 + (contribuente.RedditoAnnuale - 55000) * 0.41;
                listaContribuenti.Add(contribuente);
                return contribuente.Imposta;
            }
            else if (contribuente.RedditoAnnuale > 75000)
            {
                contribuente.Imposta = 25420 + (contribuente.RedditoAnnuale - 75000) * 0.43;
                listaContribuenti.Add(contribuente);
                return contribuente.Imposta;
            }
            else { Console.WriteLine("Inserito un reddito negativo");
                return contribuente.Imposta;
                 }
        }

        public static void MostraContribuente()
        {
            Console.WriteLine("========================");
            Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome}");
            Console.WriteLine($"Nato il {contribuente.DataNascita} ({contribuente.Sesso})");
            Console.WriteLine($"Residente in {contribuente.ComuneResidenza}");
            Console.WriteLine($"Codice Fiscale: {contribuente.CodiceFiscale}");
            Console.WriteLine($"Reddito dichiarato: ${contribuente.RedditoAnnuale}");
            Console.WriteLine($"IMPOSTA DA VERSARE: ${contribuente.Imposta}");
            Console.WriteLine("========================");
        }

        public static void MostraLista()
        {
            if(listaContribuenti.Count == 0)
            {
                Console.WriteLine("Nessun contribuente inserito");
            }
            else
            {
                 foreach (Contribuente contribuente in listaContribuenti) {
                    Console.WriteLine("========================");
                    Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome}");
                    Console.WriteLine($"Nato il {contribuente.DataNascita} ({contribuente.Sesso})");
                    Console.WriteLine($"Residente in {contribuente.ComuneResidenza}");
                    Console.WriteLine($"Codice Fiscale: {contribuente.CodiceFiscale}");
                    Console.WriteLine($"Reddito dichiarato: ${contribuente.RedditoAnnuale}");
                    Console.WriteLine($"IMPOSTA DA VERSARE: ${contribuente.Imposta}");
                    Console.WriteLine("========================");
                }
            }
        }
    }
}
