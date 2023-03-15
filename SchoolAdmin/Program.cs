namespace SchoolAdmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wat wil je demonstreren?\n\t1. Studenten\n\t2. Cursussen\n\t3. StudentUitTekst");
            byte choice = Convert.ToByte(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Student.DemonstreerStudenten();
                    break;
                case 2:
                    Cursus.DemonstreerCursussen();
                    break;
                case 3:
                    Student.DemonstreerStudentUitTekst();
                    break;
            }
        }
    }
}