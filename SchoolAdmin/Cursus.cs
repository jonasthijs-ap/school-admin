using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class Cursus
    {
        // Static attributen & properties
        private static List<Cursus> alleCursussen = new List<Cursus>();
        public static ImmutableList<Cursus> AlleCursussen
        {
            get { return alleCursussen.ToImmutableList(); }
        }



        // Object attributen & properties
        public List<Student> Studenten = new List<Student>();

        public string Titel;

        private static int maxId = 1;


        private int id;
        public int Id
        {
            get { return this.id; }
        }


        private byte studiepunten;
        public byte Studiepunten
        {
            get { return this.studiepunten; }
            private set { this.studiepunten = value; }
        }



        /* ************************** */



        // Constructors
        public Cursus(string cursusNaam, List<Student> aantalStudenten, byte studiepunten)
        {
            this.Titel = cursusNaam;
            this.Studiepunten = studiepunten;
            this.Studenten = aantalStudenten;

            this.id = maxId;
            maxId++;

            registreerCursus(this);
        }

        public Cursus(string cursusNaam, byte studiepunten) : this(cursusNaam: cursusNaam, aantalStudenten: new List<Student>(), studiepunten: studiepunten) { }

        public Cursus(string cursusNaam) : this(cursusNaam: cursusNaam, aantalStudenten: new List<Student>(), studiepunten: 3) { }



        /* ************************** */



        // Object methoden
        private static void registreerCursus(Cursus cursus)
        {
            alleCursussen.Add(cursus);
        }

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



        // Static methoden
        public static Cursus? ZoekCursusOpId(int id)
        {
            foreach (Cursus cursus in AlleCursussen)
            {
                if (cursus.Id == id)
                {
                    return cursus;
                }
            }

            return null;
        }

        public static void DemonstreerCursussen()
        {
            Cursus communicatie = new Cursus("Communicatie");
            Cursus programmeren = new Cursus("Programmeren", 6);
            Cursus webtechnologie = new Cursus("Webtechnologie", new List<Student>(), 6);
            Cursus databanken = new Cursus("Databanken", new List<Student>(), 5);

            Student said = new Student("Said Aziz", new DateTime(2001, 1, 3));
            said.RegistreerVakInschrijving(communicatie, 12);
            said.RegistreerVakInschrijving(programmeren, null);
            said.RegistreerVakInschrijving(webtechnologie, 13);
            said.ToonOverzicht();

            Student mieke = new Student("Mieke Vermeulen", new DateTime(1996, 4, 23));
            mieke.RegistreerVakInschrijving(communicatie, 13);
            mieke.RegistreerVakInschrijving(databanken, null);
            mieke.RegistreerVakInschrijving(programmeren, 14);
            mieke.ToonOverzicht();

            communicatie.Studenten.Add(said);
            communicatie.Studenten.Add(mieke);

            programmeren.Studenten.Add(said);
            programmeren.Studenten.Add(mieke);

            webtechnologie.Studenten.Add(mieke);

            databanken.Studenten.Add(said);

            communicatie.ToonOverzicht();
            programmeren.ToonOverzicht();
            webtechnologie.ToonOverzicht();
            databanken.ToonOverzicht();
        }
    }
}