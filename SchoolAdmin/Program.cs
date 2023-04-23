namespace SchoolAdmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wat wil je demonstreren?\n\t1. Studenten\n\t2. Cursussen\n\t3. StudentUitTekst\n\t4. Cursussen opzoeken op Id\n\t5. Studieprogramma\n\t6. Administratief personeel\n\t7. Lectoren");
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

                case 4:
                    Cursus cursus1 = new Cursus("Programmeren");
                    Cursus cursus2 = new Cursus("Webontwikkeling");
                    Cursus cursus3 = new Cursus("Databanken");

                    Console.WriteLine("Geef een cursus Id:");
                    Cursus resultaat = Cursus.ZoekCursusOpId(Convert.ToInt32(Console.ReadLine()));

                    if (resultaat is not null)
                    {
                        Console.WriteLine(resultaat.Titel);
                    }
                    else
                    {
                        Console.WriteLine("Cursus bestaat niet!");
                    }

                    break;

                case 5:
                    StudieProgramma.DemonstreerStudieProgramma();
                    break;

                case 6:
                    AdministratiefPersoneel.DemonstreerAdministratiefPersoneel();
                    break;

                case 7:
                    Lector.DemonstreerLectoren();
                    break;
            }
        }
    }
}