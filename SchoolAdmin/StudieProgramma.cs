using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class StudieProgramma
    {
        // Object attributen & properties
        private string naam;
        public string Naam
        {
            get { return naam; }
        }


        private Dictionary<Cursus, byte> cursussen = new Dictionary<Cursus, byte>();
        public Dictionary<Cursus, byte> Cursussen
        {
            get { return cursussen; }
            set
            {
                if (value is null)
                {
                    Console.WriteLine("Null is niet toegelaten");
                }
                else
                {
                    cursussen = value;
                }
            }
        }



        /* ************************** */



        // Constructors
        public StudieProgramma(string naam)
        {
            this.naam = naam;
        }



        /* ************************** */



        // Object methoden
        public void ToonOverzicht()
        {
            Console.WriteLine($"Cursussen voor studieprogramma: '{Naam}'");
            foreach (var cursus in Cursussen)
            {
                Console.WriteLine($"-\t{cursus.Key.Titel} ({cursus.Key.Studiepunten} stp)");
            }
            Console.WriteLine();
        }



        // Static methoden
        public static void DemonstreerStudieProgramma()
        {
            Cursus communicatie = new Cursus("Communicatie");
            Cursus programmeren = new Cursus("Programmeren");
            Cursus databanken = new Cursus("Databanken", 5);
            Cursus scripting = new Cursus("Scripting");
            
            StudieProgramma programmerenProgramma = new StudieProgramma("Programmeren");
            programmerenProgramma.Cursussen.Add(communicatie, 1);
            programmerenProgramma.Cursussen.Add(programmeren, 1);
            programmerenProgramma.Cursussen.Add(databanken, 1);

            StudieProgramma snbProgramma = new StudieProgramma("Systeem- en netwerkbeheer");
            snbProgramma.Cursussen.Add(communicatie, 2);
            snbProgramma.Cursussen.Add(programmeren, 1);
            snbProgramma.Cursussen.Add(scripting, 1);

            programmerenProgramma.ToonOverzicht();
            snbProgramma.ToonOverzicht();
        }
    }
}