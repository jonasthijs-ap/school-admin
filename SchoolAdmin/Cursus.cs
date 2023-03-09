using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Cursus
    {
        private int id;
        public Student[] Studenten;
        private readonly string titel;
        private static int maxId = 1;
        private byte studiepunten;

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Titel
        {
            get
            {
                return this.titel;
            }
        }

        public byte Studiepunten
        {
            get
            {
                return this.studiepunten;
            }
            private set
            {
                this.studiepunten = value;
            }
        }

        public Cursus(string cursusNaam, byte aantalStudenten, byte studiepunten)
        {
            this.titel = cursusNaam;
            this.Studiepunten = studiepunten;
            this.Studenten = new Student[aantalStudenten];

            this.id = maxId;
            maxId++;
        }

        public Cursus(string cursusNaam, byte studiepunten) : this(cursusNaam: cursusNaam, aantalStudenten: 2, studiepunten: studiepunten) { }

        public Cursus(string cursusNaam) : this(cursusNaam: cursusNaam, aantalStudenten: 2, studiepunten: 3) { }

        public void ToonOverzicht()
        {
            Console.WriteLine($"{Titel} (#{Id} - {Studiepunten} stp):");
            foreach (Student student in this.Studenten)
            {
                if (student is not null)
                {
                    Console.WriteLine($"- {student.Naam}");
                }
            }
            Console.WriteLine();
        }

        public static void DemonstreerCursussen()
        {
            Cursus communicatie = new Cursus("Communicatie");

            Cursus programmeren = new Cursus("Programmeren", 6);

            Cursus webtechnologie = new Cursus("Webtechnologie", 5, 6);

            Cursus databanken = new Cursus("Databanken", 7, 5);

            Student said = new Student();
            said.Naam = "Said Aziz";
            said.RegistreerCursusResultaat("Communicatie", 12);
            said.RegistreerCursusResultaat("Programmeren", 15);
            said.RegistreerCursusResultaat("Webtechnologie", 13);

            Student mieke = new Student();
            mieke.Naam = "Mieke Vermeulen";
            mieke.RegistreerCursusResultaat("Communicatie", 14);
            mieke.RegistreerCursusResultaat("Databanken", 11);
            mieke.RegistreerCursusResultaat("Programmeren", 8);

            communicatie.Studenten[0] = said;
            communicatie.Studenten[1] = mieke;

            programmeren.Studenten[0] = said;
            programmeren.Studenten[1] = mieke;

            webtechnologie.Studenten[0] = mieke;

            databanken.Studenten[0] = said;

            communicatie.ToonOverzicht();
            programmeren.ToonOverzicht();
            webtechnologie.ToonOverzicht();
            databanken.ToonOverzicht();
        }
    }
}