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
        private Cursus[] cursussen;

        public string Naam
        {
            get { return naam; }
        }

        public Cursus[] Cursussen
        {
            get { return cursussen; }
            set
            {
                if (value is not null)
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
            for (int i = 0; i < Cursussen.Length; i++)
            {
                Console.WriteLine($"-\t{Cursussen[i].Titel} ({Cursussen[i].Studiepunten} stp)");
            }
            Console.WriteLine();
        }

        public static void DemonstreerStudieProgramma()
        {
            Cursus communicatie = new Cursus("Communicatie");
            Cursus programmeren = new Cursus("Programmeren");
            Cursus databanken = new Cursus("Databanken", new Student[7], 5);
            Cursus[] cursussenPRO = { communicatie, programmeren, databanken };
            Cursus[] cursussenSNB = { communicatie, programmeren };
            StudieProgramma programmerenProgramma = new StudieProgramma("Programmeren");
            StudieProgramma snbProgramma = new StudieProgramma("Systeem- en netwerkbeheer");
            programmerenProgramma.cursussen = cursussenPRO;
            snbProgramma.cursussen = cursussenSNB;
            programmerenProgramma.ToonOverzicht();
            snbProgramma.ToonOverzicht();
        }
    }
}