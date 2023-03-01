namespace SchoolAdmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student();
            student1.Naam = "Said Aziz";
            student1.GeboorteDatum = new DateTime(2000, 6, 1);
            student1.Studentennummer = 23424;
            student1.Cursussen = new string[] { "Programmeren", "Databanken" };

            Student student2 = new Student();
            student2.Naam = "Mieke Vermeulen";
            student2.GeboorteDatum = new DateTime(1998, 1, 1);
            student2.Studentennummer = 34583;
            student2.Cursussen = new string[] { "Communicatie" };

            Console.WriteLine($"{student1.Naam} ({student1.Studentennummer})");
            Console.WriteLine($"{student1.GeboorteDatum.ToShortDateString()}\n");

            foreach (string cursus in student1.Cursussen)
            {
                Console.WriteLine($" - {cursus}");
            }

            Console.WriteLine("\n");

            Console.WriteLine($"{student2.Naam} ({student2.Studentennummer})");
            Console.WriteLine($"{student2.GeboorteDatum.ToShortDateString()}\n");

            foreach (string cursus in student2.Cursussen)
            {
                Console.WriteLine($" - {cursus}");
            }

            Console.WriteLine($"\nTotaal aantal studenten: {Student.Studententeller}");
        }
    }
}