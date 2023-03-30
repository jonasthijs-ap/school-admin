using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Student
    {
        private VakInschrijving[] vakInschrijvingen = new VakInschrijving[5];
        public string Naam;
        public DateTime GeboorteDatum;
        public uint Studentennummer;
        public static uint Studententeller = 1;

        private static List<Student> alleStudenten = new List<Student>();
        public static List<Student> AlleStudenten
        {
            get { return alleStudenten; }
        }

        public Student(string naam, DateTime geboorteDatum)
        {
            this.Naam = naam;
            this.GeboorteDatum = geboorteDatum;
            alleStudenten.Add(this);
        }

        public byte BepaalWerkbelasting()
        {
            byte totaal = 0;

            for (int i = 0; i < this.vakInschrijvingen.Length; i++)
            {
                if (this.vakInschrijvingen[i] is not null)
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
                this.vakInschrijvingen[cursusIndex].Resultaat = behaaldCijfer;
            }
        }

        public void RegistreerCursusResultaat(Cursus cursus, byte? cijfer)
        {
            for (int i = 0; i < vakInschrijvingen.Length; i++)
            {
                if (vakInschrijvingen[i] is null)
                {
                    vakInschrijvingen[i] = new VakInschrijving(cursus, cijfer);
                    break;
                }
            }
        }

        public void ToonOverzicht()
        {
            ushort age = Convert.ToUInt16(DateTime.Now.Year - this.GeboorteDatum.Year);
            Console.WriteLine($"{this.Naam}, {age} jaar\n");
            Console.WriteLine("Cijferrapport:\n**************");

            foreach (VakInschrijving vakInschrijving in vakInschrijvingen)
            {
                if (vakInschrijving is not null)
                {
                    Console.WriteLine($"{vakInschrijving.Cursus.Titel}:".PadRight(26) + vakInschrijving.Resultaat);
                }
            }
            
            Console.WriteLine($"Gemiddelde:".PadRight(26) + $"{Math.Round(Gemiddelde(vakInschrijvingen), 1)}\n");
        }

        public static Student StudentUitTekstFormaat(string csvWaarde)
        {
            string[] studentInfo = csvWaarde.Split(';');
            Student student = new Student(studentInfo[0], new DateTime(Convert.ToInt32(studentInfo[3]), Convert.ToInt32(studentInfo[2]), Convert.ToInt32(studentInfo[1])));

            for (byte i = 4; i < studentInfo.Length; i += 2)
            {
                student.RegistreerCursusResultaat(new Cursus(studentInfo[i]), Convert.ToByte(studentInfo[i + 1]));
            }

            return student;
        }

        public static void DemonstreerStudenten()
        {
            Cursus communicatie = new Cursus("Communicatie");
            Cursus programmeren = new Cursus("Programmeren", 6);
            Cursus webtechnologie = new Cursus("Webtechnologie", new Student[5], 6);
            Cursus databanken = new Cursus("Databanken", new Student[7], 5);

            Student said = new Student("Said Aziz", new DateTime(2001, 1, 3));
            said.RegistreerCursusResultaat(communicatie, 12);
            said.RegistreerCursusResultaat(programmeren, 15);
            said.RegistreerCursusResultaat(webtechnologie, 13);
            said.ToonOverzicht();

            Student mieke = new Student("Mieke Vermeulen", new DateTime(1996, 4, 23));
            mieke.RegistreerCursusResultaat(communicatie, 13);
            mieke.RegistreerCursusResultaat(databanken, 16);
            mieke.RegistreerCursusResultaat(programmeren, 14);
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