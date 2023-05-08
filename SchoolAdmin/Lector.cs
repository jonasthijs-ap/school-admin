using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class Lector : Personeel
    {
        // Static attributen & properties
        public static ImmutableList<Lector> AlleLectoren
        {
            get
            {
                List<Lector> alleLectoren = new List<Lector>();
                foreach (var persoon in AllePersonen)
                {
                    if (persoon is Lector)
                    {
                        alleLectoren.Add((Lector)persoon);
                    }
                }

                return alleLectoren.ToImmutableList();
            }
        }



        // Object attributen & properties
        private Dictionary<Cursus, double> cursussen = new Dictionary<Cursus, double>();



        /* ************************** */



        // Constructors
        public Lector(string naam, DateTime geboorteDatum, Dictionary<string, byte> taken) : base(naam, geboorteDatum, taken)
        {
            allePersonen.Add(this);
        }



        /* ************************** */



        // Object methoden
        public override string GenereerNaamkaartje()
        {
            string output = $"{Naam}\nLector voor:";

            foreach (var cursus in cursussen)
            {
                output += $"\n{cursus.Key.Titel}";
            }

            return output;
        }

        public override byte BepaalWerkbelasting()
        {
            byte totaal = 0;

            foreach (var cursus in cursussen)
            {
                totaal += (byte)cursus.Value;
            }

            return totaal;
        }

        public override uint BerekenSalaris()
        {
            uint loon = 2200;
            uint ancienniteitstoeslag = 120 * (uint)(Ancienniteit / 4);
            loon += ancienniteitstoeslag;
            double tewerkstellingsbreuk = (BepaalWerkbelasting() * 1.0) / 40;

            return (uint)(loon * tewerkstellingsbreuk);
        }



        // Static methoden
        public static void DemonstreerLectoren()
        {
            Lector anna = new Lector("Anna Bolzano", new DateTime(1975, 6, 12), null);
            anna.Ancienniteit = 9;
            anna.cursussen.Add(new Cursus("Economie"), 3);
            anna.cursussen.Add(new Cursus("Statistiek"), 3);
            anna.cursussen.Add(new Cursus("Analytische meetkunde"), 4);

            Lector patrick = new Lector("Patrick Gessens", new DateTime(1973, 11, 2), null);
            patrick.Ancienniteit = 28;
            patrick.cursussen.Add(new Cursus("Koeltechnieken"), 6);
            patrick.cursussen.Add(new Cursus("Toegepaste Hydrauliek"), 10);
            patrick.cursussen.Add(new Cursus("Procesbeveiliging"), 4);
            patrick.cursussen.Add(new Cursus("Algemene mechanica"), 8);

            foreach (Lector lector in AlleLectoren)
            {
                Console.WriteLine(lector.GenereerNaamkaartje());
                Console.WriteLine($"\tSalaris: {lector.BerekenSalaris()} euro.");
                Console.WriteLine($"\tWerkbelasting: {lector.BepaalWerkbelasting()} uur.\n");
            }
        }



        // System.Object overrides
        public override string ToString()
        {
            return $"{base.ToString()}\nMeerbepaald, een lector";
        }
    }
}