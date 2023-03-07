using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Cursus
    {
        public Student[] Studenten = new Student[2];
        public string Titel;

        public void ToonOverzicht()
        {
            Console.WriteLine($"{Titel}:");
            foreach (Student student in this.Studenten)
            {
                Console.WriteLine(student.Naam);
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
            said.RegistreerVoorCursus("Communicatie");
            said.CursusResultaten[0] = 12;
            said.RegistreerVoorCursus("Programmeren");
            said.CursusResultaten[1] = 15;
            said.RegistreerVoorCursus("Webtechnologie");
            said.CursusResultaten[2] = 13;

            Student mieke = new Student();
            mieke.Naam = "Mieke Vermeulen";
            mieke.RegistreerVoorCursus("Communicatie");
            mieke.CursusResultaten[0] = 14;
            mieke.RegistreerVoorCursus("Databanken");
            mieke.CursusResultaten[1] = 11;
            mieke.RegistreerVoorCursus("Programmeren");
            mieke.CursusResultaten[2] = 8;

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