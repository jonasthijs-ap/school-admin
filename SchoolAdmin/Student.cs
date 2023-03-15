using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Student
    {
        private VakInschrijving[] cursusResultaten = new VakInschrijving[5];
        public string Naam;
        public DateTime GeboorteDatum;
        public uint Studentennummer;
        public static uint Studententeller = 1;

        public Student(string naam, DateTime geboorteDatum)
        {
            this.Naam = naam;
            this.GeboorteDatum = geboorteDatum;
        }

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

        public double Gemiddelde(VakInschrijving[] resultaten)
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

        public void RegistreerCursusResultaat(string cursusNaam, byte? cijfer)
        {
            for (int i = 0; i < cursusResultaten.Length; i++)
            {
                if (cursusResultaten[i] is null)
                {
                    cursusResultaten[i] = new VakInschrijving(cursusNaam, cijfer);
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

        public static Student StudentUitTekstFormaat(string csvWaarde)
        {
            string[] studentInfo = csvWaarde.Split(';');
            Student student = new Student(studentInfo[0], new DateTime(Convert.ToInt32(studentInfo[3]), Convert.ToInt32(studentInfo[2]), Convert.ToInt32(studentInfo[1])));

            for (byte i = 4; i < studentInfo.Length; i += 2)
            {
                student.RegistreerCursusResultaat(studentInfo[i], Convert.ToByte(studentInfo[i + 1]));
            }

            return student;
        }

        public static void DemonstreerStudenten()
        {
            Student said = new Student("Said Aziz", new DateTime(2001, 1, 3));
            said.RegistreerCursusResultaat("Communicatie", 12);
            said.RegistreerCursusResultaat("Programmeren", 15);
            said.RegistreerCursusResultaat("Webtechnologie", 13);
            said.ToonOverzicht();

            Student mieke = new Student("Mieke Vermeulen", new DateTime(1996, 4, 23));
            mieke.RegistreerCursusResultaat("Communicatie", 13);
            mieke.RegistreerCursusResultaat("Databanken", 16);
            mieke.RegistreerCursusResultaat("Programmeren", 14);
            mieke.ToonOverzicht();
        }

        public static void DemonstreerStudentUitTekst()
        {
            Console.WriteLine("Geef de tekstvoorstelling van een student:");
            string csvWaarde = Console.ReadLine();
            Student student = StudentUitTekstFormaat(csvWaarde);
            student.ToonOverzicht();
        }
    }
}