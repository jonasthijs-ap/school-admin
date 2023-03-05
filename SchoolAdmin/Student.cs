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
            Student student1 = new Student();
            student1.GeboorteDatum = new DateTime(2001, 1, 3);
            student1.Naam = "Said Aziz";
            student1.RegistreerVoorCursus("Communicatie");
            student1.CursusResultaten[0] = 12;
            student1.RegistreerVoorCursus("Programmeren");
            student1.CursusResultaten[1] = 15;
            student1.RegistreerVoorCursus("Webtechnologie");
            student1.CursusResultaten[2] = 13;
            student1.ToonOverzicht();

            Student student2 = new Student();
            student2.GeboorteDatum = new DateTime(1996, 4, 23);
            student2.Naam = "Mieke Vermeulen";
            student2.RegistreerVoorCursus("Webontwikkeling");
            student2.CursusResultaten[0] = 14;
            student2.RegistreerVoorCursus("IT Project");
            student2.CursusResultaten[1] = 11;
            student2.RegistreerVoorCursus("IT Essentials");
            student2.CursusResultaten[2] = 8;
            student2.RegistreerVoorCursus("Programmeren Intro");
            student2.CursusResultaten[3] = 18;
            student2.ToonOverzicht();
        }
    }
}