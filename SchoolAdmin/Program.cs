using SchoolAdmin.CustomExceptions;

namespace SchoolAdmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                string[] opties =
                {
                    "Studenten",
                    "Cursussen",
                    "Student uit tekst",
                    "Cursussen opzoeken op ID",
                    "Studieprogramma",
                    "Administratief personeel",
                    "Lectoren",
                    "Student toevoegen",
                    "Cursus toevoegen",
                    "Vakinschrijving toevoegen",
                    "Inschrijvingsgegevens tonen"
                };

                Console.WriteLine("Wat wil je demonstreren?");
                for (byte i = 0; i < opties.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.".PadRight(4) + opties[i]);
                }

                try
                {
                    byte choice = Convert.ToByte(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            try
                            {
                                Student.DemonstreerStudenten();
                            }
                            catch (DuplicateDataException e)
                            {
                                Console.WriteLine(e.Message + $"\nID van bestaande, overlappende cursus:\t{((Cursus)e.BestaandeCursus).Id}");
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 2:
                            try
                            {
                                Cursus.DemonstreerCursussen();
                            }
                            catch (DuplicateDataException e)
                            {
                                Console.WriteLine(e.Message + $"\nID van bestaande, overlappende cursus:\t{((Cursus)e.BestaandeCursus).Id}");
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 3:
                            Student.DemonstreerStudentUitTekst();
                            break;

                        case 4:
                            try
                            {
                                Cursus cursus1 = new Cursus("Programmeren");
                                Cursus cursus2 = new Cursus("Webontwikkeling");
                                Cursus cursus3 = new Cursus("Databanken");
                            }
                            catch (DuplicateDataException e)
                            {
                                Console.WriteLine(e.Message + $"\nID van bestaande, overlappende cursus:\t{((Cursus)e.BestaandeCursus).Id}");
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }

                            Console.WriteLine("Geef een cursus Id:");
                            Cursus opgezochteCursus = Cursus.ZoekCursusOpId(Convert.ToInt32(Console.ReadLine()));

                            if (opgezochteCursus is not null)
                            {
                                Console.WriteLine(opgezochteCursus.Titel);
                            }
                            else
                            {
                                Console.WriteLine("Cursus bestaat niet!");
                            }

                            break;

                        case 5:
                            try
                            {
                                StudieProgramma.DemonstreerStudieProgramma();
                            }
                            catch (DuplicateDataException e)
                            {
                                Console.WriteLine(e.Message + $"\nID van bestaande, overlappende cursus:\t{((Cursus)e.BestaandeCursus).Id}");
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 6:
                            AdministratiefPersoneel.DemonstreerAdministratiefPersoneel();
                            break;

                        case 7:
                            try
                            {
                                Lector.DemonstreerLectoren();
                            }
                            catch (DuplicateDataException e)
                            {
                                Console.WriteLine(e.Message + $"\nID van bestaande, overlappende cursus:\t{((Cursus)e.BestaandeCursus).Id}");
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 8:
                            // Interactie aanmaken nieuwe student

                            Console.WriteLine("Naam van de student?");
                            string naam = Console.ReadLine();

                            Console.WriteLine("Geboortedatum van de student?");
                            DateTime geboorteDatum = DateTime.Parse(Console.ReadLine());

                            new Student(naam, geboorteDatum);
                            break;

                        case 9:
                            // Interactie aanmaken nieuwe cursus

                            Console.WriteLine("Titel van de cursus?");
                            string titel = Console.ReadLine();

                            Console.WriteLine("Aantal studiepunten?");
                            byte studiepunten = Convert.ToByte(Console.ReadLine());

                            try
                            {
                                new Cursus(titel, studiepunten);
                            }
                            catch (DuplicateDataException e)
                            {
                                Console.WriteLine(e.Message + $"\nID van bestaande, overlappende cursus:\t{((Cursus)e.BestaandeCursus).Id}");
                            }
                            break;

                        case 10:
                            // Interactie aanmaken nieuwe vakinschrijving

                            try
                            {
                                Console.WriteLine("Welke student?");
                                for (byte i = 0; i < Student.AlleStudenten.Count; i++)
                                {
                                    Console.WriteLine($"[{i + 1}]{Student.AlleStudenten[i].Naam.PadLeft(3 + Student.AlleStudenten.Count.ToString().Length + 1)}");
                                }
                                uint studentId = Convert.ToUInt32(Console.ReadLine());
                                for (byte i = 0; i < Student.AlleStudenten.Count; i++)
                                {
                                    if (Student.AlleStudenten[i].Id == studentId)
                                    {
                                        Console.WriteLine(Student.AlleStudenten[i].ToString());
                                        studentId = (uint)i;
                                    }
                                }

                                Console.WriteLine("Welke cursus?");
                                for (byte i = 0; i < Cursus.AlleCursussen.Count; i++)
                                {
                                    Console.WriteLine($"[{i + 1}]{Cursus.AlleCursussen[i].Titel.PadLeft(3 + Cursus.AlleCursussen.Count.ToString().Length + 1)}");
                                }
                                uint cursusId = Convert.ToUInt32(Console.ReadLine());

                                if (studentId == 0 || cursusId == 0)
                                {
                                    new VakInschrijving(null, null, null);
                                }
                                else
                                {
                                    Console.WriteLine("Wil je een resultaat toevoegen?");
                                    string antwoord = Console.ReadLine();
                                    if (antwoord.ToLower() == "ja")
                                    {
                                        Console.WriteLine("Wat is het resultaat?");
                                        byte resultaat = Convert.ToByte(Console.ReadLine());
                                        new VakInschrijving(Cursus.AlleCursussen[(int)(cursusId - 1)], Student.AlleStudenten[(int)studentId - 1], resultaat);
                                    }
                                    else
                                    {
                                        new VakInschrijving(Cursus.AlleCursussen[(int)(cursusId - 1)], Student.AlleStudenten[(int)studentId - 1], null);
                                    }
                                }
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 11:
                            // Interactie tonen inschrijvingsgegevens

                            foreach (VakInschrijving vakInschrijving in VakInschrijving.AlleVakInschrijvingen)
                            {
                                Console.WriteLine(vakInschrijving.Student.ToString());
                                Console.WriteLine("Ingeschreven voor:");
                                foreach (Cursus cursus in vakInschrijving.Student.Cursussen)
                                {
                                    Console.WriteLine($"- {cursus.Titel}");
                                }
                            }
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Gelieve enkel (gehele) getallen in te geven.");
                    Console.ResetColor();
                }
                catch (OverflowException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("De input moet tussen 0 en 255 liggen.");
                    Console.ResetColor();
                }

                Console.ReadLine();
            }
        }
    }
}