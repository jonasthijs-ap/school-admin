using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Student
    {
        private string[] cursussen = new string[5];
        public byte[] CursusResultaten = new byte[5];
        public string Naam;
        public DateTime GeboorteDatum;
        public uint Studentennummer;
        public static uint Studententeller = 1;

        public byte BepaalWerkbelasting()
        {
            byte totaal = 0;

            for (int i = 0; i < this.cursussen.Length; i++)
            {
                if (this.cursussen[i] is not null)
                {
                    totaal += 10;
                }
            }

            return totaal;
        }

        public double Gemiddelde(string[] cursussen)
        {
            double gemiddelde = 0.0;
            byte aantalCursussen = 0;

            for (int i = 0; i < cursussen.Length; i++)
            {
                if (cursussen[i] is not null)
                {
                    gemiddelde += Convert.ToDouble(CursusResultaten[i]);
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
                this.CursusResultaten[cursusIndex] = behaaldCijfer;
            }
        }

        public void RegistreerVoorCursus(string cursus)
        {
            for (int i = 0; i < this.cursussen.Length; i++)
            {
                if (this.cursussen[i] is null)
                {
                    cursussen[i] = cursus;
                    break;
                }
            }
        }

        public void ToonOverzicht()
        {
            ushort age = Convert.ToUInt16(DateTime.Now.Year - this.GeboorteDatum.Year);
            Console.WriteLine($"{this.Naam}, {age} jaar\n");
            Console.WriteLine("Cijferrapport:\n**************");
            for (int i = 0; i < cursussen.Length; i++)
            {
                if (cursussen[i] is not null)
                {
                    Console.WriteLine($"{cursussen[i]}:".PadRight(26) + CursusResultaten[i]);
                }
            }

            Console.WriteLine($"Gemiddelde:".PadRight(26) + $"{Math.Round(Gemiddelde(cursussen), 1)}\n");
        }

        public static void DemonstreerStudenten()
        {
            Student said = new Student();
            said.GeboorteDatum = new DateTime(2001, 1, 3);
            said.Naam = "Said Aziz";
            said.RegistreerVoorCursus("Communicatie");
            said.CursusResultaten[0] = 12;
            said.RegistreerVoorCursus("Programmeren");
            said.CursusResultaten[1] = 15;
            said.RegistreerVoorCursus("Webtechnologie");
            said.CursusResultaten[2] = 13;
            said.ToonOverzicht();

            Student mieke = new Student();
            mieke.GeboorteDatum = new DateTime(1996, 4, 23);
            mieke.Naam = "Mieke Vermeulen";
            mieke.RegistreerVoorCursus("Webontwikkeling");
            mieke.CursusResultaten[0] = 14;
            mieke.RegistreerVoorCursus("IT Project");
            mieke.CursusResultaten[1] = 11;
            mieke.RegistreerVoorCursus("IT Essentials");
            mieke.CursusResultaten[2] = 8;
            mieke.RegistreerVoorCursus("Programmeren Intro");
            mieke.CursusResultaten[3] = 18;
            mieke.ToonOverzicht();
        }
    }
}