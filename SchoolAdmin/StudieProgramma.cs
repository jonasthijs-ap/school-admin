using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class StudieProgramma
    {
        private string naam;
        public string Naam
        {
            get { return naam; }
        }

        private List<Cursus> cursussen = new List<Cursus>();
        public List<Cursus> Cursussen
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

        public StudieProgramma(string naam)
        {
            this.naam = naam;
        }

        public void ToonOverzicht()
        {
            Console.WriteLine($"Cursussen voor studieprogramma: '{Naam}'");
            foreach (Cursus cursus in Cursussen)
            {
                Console.WriteLine($"-\t{cursus.Titel} ({cursus.Studiepunten} stp)");
            }
            Console.WriteLine();
        }

        public static void DemonstreerStudieProgramma()
        {
            Cursus communicatie = new Cursus("Communicatie");
            Cursus programmeren = new Cursus("Programmeren");
            Cursus databanken = new Cursus("Databanken", new List<Student>(), 5);
            List<Cursus> cursussen1 = new List<Cursus> { communicatie, programmeren, databanken };
            List<Cursus> cursussen2 = new List<Cursus> { communicatie, programmeren };
            StudieProgramma programmerenProgramma = new StudieProgramma("Programmeren");
            StudieProgramma snbProgramma = new StudieProgramma("Systeem- en netwerkbeheer");
            programmerenProgramma.cursussen = cursussen1;
            snbProgramma.cursussen = cursussen2;
            snbProgramma.cursussen[1] = new Cursus("Scripting");
            programmerenProgramma.ToonOverzicht();
            snbProgramma.ToonOverzicht();
        }
    }
}