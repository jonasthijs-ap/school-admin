namespace SchoolAdmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wat wil je doen?");
            Console.WriteLine("1. DemonstreerStudenten uitvoeren");
            byte choice = Convert.ToByte(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Student.DemonstreerStudenten();
                    break;
            }
        }
    }
}