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
        private string titel;
        private byte studiepunten;
        private static int maxId = 1;
        private static Cursus[] alleCursussen = new Cursus[10];

        public int Id
        {
            get { return this.id; }
        }

        public string Titel
        {
            get { return this.titel; }
        }

        public byte Studiepunten
        {
            get { return this.studiepunten; }
            private set { this.studiepunten = value; }
        }

        public static Cursus[] AlleCursussen
        {
            get { return alleCursussen; }
        }

        public Cursus(string cursusNaam, Student[] aantalStudenten, byte studiepunten)
        {
            this.titel = cursusNaam;
            this.Studiepunten = studiepunten;
            this.Studenten = aantalStudenten;

            this.id = maxId;
            maxId++;

            registreerCursus(this);
        }

        public Cursus(string cursusNaam, byte studiepunten) : this(cursusNaam: cursusNaam, aantalStudenten: new Student[2], studiepunten: studiepunten) { }

        public Cursus(string cursusNaam) : this(cursusNaam: cursusNaam, aantalStudenten: new Student[2], studiepunten: 3) { }

        private static void registreerCursus(Cursus cursus)
        {
            int? vrijePositie = null;

            for (int i = 0; i < alleCursussen.Length; i++)
            {
                if (alleCursussen[i] is null && vrijePositie is null)
                {
                    vrijePositie = i;
                }
            }

            if (vrijePositie is not null)
            {
                alleCursussen[(int) vrijePositie] = cursus;
            }
            else
            {
                Console.WriteLine("Er zijn geen vrije posities meer");
            }
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

        public static Cursus? ZoekCursusOpId(int id)
        {
            for (int i = 0; i < AlleCursussen.Length; i++)
            {
                if (i + 1 == id && AlleCursussen[i] is null)
                {
                    return null;
                }
                else if (AlleCursussen[i] is null)
                {
                    //
                }
                else if (AlleCursussen[i].Id == id && AlleCursussen[i] is not null)
                {
                    return AlleCursussen[i];
                }
            }

            return null;
        }

        public static void DemonstreerCursussen()
        {
            Cursus communicatie = new Cursus("Communicatie");
            Cursus programmeren = new Cursus("Programmeren", 6);
            Cursus webtechnologie = new Cursus("Webtechnologie", new Student[5], 6);
            Cursus databanken = new Cursus("Databanken", new Student[7], 5);

            Student said = new Student("Said Aziz", new DateTime(2001, 1, 3));
            said.RegistreerCursusResultaat(communicatie, 12);
            said.RegistreerCursusResultaat(programmeren, null);
            said.RegistreerCursusResultaat(webtechnologie, 13);
            said.ToonOverzicht();

            Student mieke = new Student("Mieke Vermeulen", new DateTime(1996, 4, 23));
            mieke.RegistreerCursusResultaat(communicatie, 13);
            mieke.RegistreerCursusResultaat(databanken, null);
            mieke.RegistreerCursusResultaat(programmeren, 14);
            mieke.ToonOverzicht();

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