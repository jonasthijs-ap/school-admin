using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Student
    {
        private CursusResultaat[] cursusResultaten = new CursusResultaat[5];
        public string Naam;
        public DateTime GeboorteDatum;
        public uint Studentennummer;
        public static uint Studententeller = 1;

        public byte BepaalWerkbelasting()
        {
            byte totaal = 0;

            for (int i = 0; i < this.cursusResultaten.Length; i++)
            {
                if (this.cursusResultaten[i] is not null)
                {
                    totaal += 10;
                }
            }

            return totaal;
        }

        public double Gemiddelde(CursusResultaat[] resultaten)
        {
            double gemiddelde = 0.0;
            byte aantalCursussen = 0;

            for (int i = 0; i < resultaten.Length; i++)
            {
                if (resultaten[i] is not null)
                {
                    gemiddelde += Convert.ToDouble(resultaten[i].Resultaat);
                    aantalCursussen++;
                }
            }

            gemiddelde /= aantalCursussen;
            return gemiddelde;
        }

        public string GenereerNaamKaartje()
        {
            return $"{this.Naam} (STUDENT)";
        }

        public void Kwoteer(byte cursusIndex, byte behaaldCijfer)
        {
            if (behaaldCijfer > 20)
            {
                Console.WriteLine("Ongeldig cijfer!");
            }
            else
            {
                this.cursusResultaten[cursusIndex].Resultaat = behaaldCijfer;
            }
        }

        public void RegistreerCursusResultaat(string cursusNaam, byte cijfer)
        {
            for (int i = 0; i < cursusResultaten.Length; i++)
            {
                if (cursusResultaten[i] is null)
                {
                    cursusResultaten[i] = new CursusResultaat();
                    cursusResultaten[i].Naam = cursusNaam;
                    cursusResultaten[i].Resultaat = cijfer;
                    break;
                }
            }
        }

        public void ToonOverzicht()
        {
            ushort age = Convert.ToUInt16(DateTime.Now.Year - this.GeboorteDatum.Year);
            Console.WriteLine($"{this.Naam}, {age} jaar\n");
            Console.WriteLine("Cijferrapport:\n**************");
            for (int i = 0; i < cursusResultaten.Length; i++)
            {
                if (cursusResultaten[i] is not null)
                {
                    Console.WriteLine($"{cursusResultaten[i].Naam}:".PadRight(26) + cursusResultaten[i].Resultaat);
                }
            }

            Console.WriteLine($"Gemiddelde:".PadRight(26) + $"{Math.Round(Gemiddelde(cursusResultaten), 1)}\n");
        }

        public static void DemonstreerStudenten()
        {
            Student said = new Student();
            said.GeboorteDatum = new DateTime(2001, 1, 3);
            said.Naam = "Said Aziz";
            said.RegistreerCursusResultaat("Communicatie", 12);
            said.RegistreerCursusResultaat("Programmeren", 15);
            said.RegistreerCursusResultaat("Webtechnologie", 13);
            said.ToonOverzicht();

            Student mieke = new Student();
            mieke.GeboorteDatum = new DateTime(1996, 4, 23);
            mieke.Naam = "Mieke Vermeulen";
            mieke.RegistreerCursusResultaat("Webontwikkeling", 14);
            mieke.RegistreerCursusResultaat("IT Project", 11);
            mieke.RegistreerCursusResultaat("IT Essentials", 8);
            mieke.RegistreerCursusResultaat("Programmeren Intro", 18);
            mieke.ToonOverzicht();
        }
    }
}