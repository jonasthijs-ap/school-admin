using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Student
    {
        private List<VakInschrijving> vakInschrijvingen = new List<VakInschrijving>();
        public string Naam;
        public DateTime GeboorteDatum;
        public uint Studentennummer;
        public static uint Studententeller = 1;

        private static List<Student> alleStudenten = new List<Student>();
        public static ImmutableList<Student> AlleStudenten
        {
            get { return alleStudenten.ToImmutableList(); }
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
            foreach (VakInschrijving vakInschrijving in vakInschrijvingen)
            {
                totaal += 10;
            }
            
            return totaal;
        }

        public double Gemiddelde()
        {
            double gemiddelde = 0.0;
            byte aantalCursussen = 0;
            foreach (VakInschrijving vakInschrijving in vakInschrijvingen)
            {
                gemiddelde += Convert.ToDouble(vakInschrijving.Resultaat);
                aantalCursussen++;
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

        public void RegistreerVakInschrijving(Cursus cursus, byte? cijfer)
        {
            vakInschrijvingen.Add(new VakInschrijving(cursus, cijfer));
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
            
            Console.WriteLine($"Gemiddelde:".PadRight(26) + $"{Math.Round(this.Gemiddelde(), 1)}\n");
        }

        public static Student StudentUitTekstFormaat(string csvWaarde)
        {
            string[] studentInfo = csvWaarde.Split(';');
            Student student = new Student(studentInfo[0], new DateTime(Convert.ToInt32(studentInfo[3]), Convert.ToInt32(studentInfo[2]), Convert.ToInt32(studentInfo[1])));

            for (byte i = 4; i < studentInfo.Length; i += 2)
            {
                student.RegistreerVakInschrijving(new Cursus(studentInfo[i]), Convert.ToByte(studentInfo[i + 1]));
            }

            return student;
        }

        public static void DemonstreerStudenten()
        {
            Cursus communicatie = new Cursus("Communicatie");
            Cursus programmeren = new Cursus("Programmeren", 6);
            Cursus webtechnologie = new Cursus("Webtechnologie", new List<Student>(), 6);
            Cursus databanken = new Cursus("Databanken", new List<Student>(), 5);

            Student said = new Student("Said Aziz", new DateTime(2001, 1, 3));
            said.RegistreerVakInschrijving(communicatie, 12);
            said.RegistreerVakInschrijving(programmeren, 15);
            said.RegistreerVakInschrijving(webtechnologie, 13);
            said.ToonOverzicht();

            Student mieke = new Student("Mieke Vermeulen", new DateTime(1996, 4, 23));
            mieke.RegistreerVakInschrijving(communicatie, 13);
            mieke.RegistreerVakInschrijving(databanken, 16);
            mieke.RegistreerVakInschrijving(programmeren, 14);
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