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
        public Student[] Studenten = new Student[2];
        public string Titel;
        private static int maxId = 1;

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public Cursus()
        {
            this.id = maxId;
            maxId++;
        }

        public void ToonOverzicht()
        {
            Console.WriteLine($"{Titel} ({this.Id}):");
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
            Cursus communicatie = new Cursus();
            communicatie.Titel = "Communicatie";

            Cursus programmeren = new Cursus();
            programmeren.Titel = "Programmeren";

            Cursus webtechnologie = new Cursus();
            webtechnologie.Titel = "Webtechnologie";

            Cursus databanken = new Cursus();
            databanken.Titel = "Databanken";

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