namespace SchoolAdmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student();
            student1.Naam = "Said Aziz";
            student1.GeboorteDatum = new DateTime(2000, 6, 1);
            student1.Studentennummer = Student.Studententeller;
            Student.Studententeller++;
            student1.Cursussen[0] = "Programmeren";
            student1.Cursussen[1] = "Databanken";
            
            Student student2 = new Student();
            student2.Naam = "Mieke Vermeulen";
            student2.GeboorteDatum = new DateTime(1998, 1, 1);
            student2.Studentennummer = Student.Studententeller;
            Student.Studententeller++;
            student2.Cursussen[0] = "Communicatie";

            Console.WriteLine(student1.GenereerNaamKaartje());
            Console.WriteLine(student2.GenereerNaamKaartje());
            Console.WriteLine(student1.BepaalWerkbelasting());
            Console.WriteLine(student2.BepaalWerkbelasting());
        }
    }
}