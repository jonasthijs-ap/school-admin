using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class AdministratiefPersoneel : Personeel
    {
        // Static attributen & properties
        public static ImmutableList<AdministratiefPersoneel> AlleAdministratiefPersoneel
        {
            get
            {
                List<AdministratiefPersoneel> alleAdministratiefPersoneel = new List<AdministratiefPersoneel>();
                foreach (var persoon in AllePersonen)
                {
                    if (persoon is AdministratiefPersoneel)
                    {
                        alleAdministratiefPersoneel.Add((AdministratiefPersoneel)persoon);
                    }
                }

                return alleAdministratiefPersoneel.ToImmutableList();
            }
        }



        /* ************************** */



        // Constructors
        public AdministratiefPersoneel(string naam, DateTime geboorteDatum, Dictionary<string, byte> taken) : base(naam, geboorteDatum, taken)
        {
            allePersonen.Add(this);
        }



        /* ************************** */



        // Object methoden
        public override string GenereerNaamkaartje()
        {
            return $"{Naam} (ADMINISTRATIE)";
        }

        public override byte BepaalWerkbelasting()
        {
            byte totaal = 0;
            foreach (var taak in Taken)
            {
                totaal += taak.Value;
            }

            return totaal;
        }

        public override uint BerekenSalaris()
        {
            uint loon = 2000;
            uint ancienniteitstoeslag = 75 * (uint)(Ancienniteit / 3);
            loon += ancienniteitstoeslag;
            double tewerkstellingsbreuk = (BepaalWerkbelasting() * 1.0) / 40;

            return (uint)(loon * tewerkstellingsbreuk);
        }



        // Static methoden
        public static void DemonstreerAdministratiefPersoneel()
        {
            Dictionary<string, byte> takenlijst = new Dictionary<string, byte>();
            takenlijst.Add("roostering", 10);
            takenlijst.Add("correspondentie", 10);
            takenlijst.Add("animatie", 10);

            AdministratiefPersoneel ahmed = new AdministratiefPersoneel("Ahmed Azzaoui", new DateTime(1988, 2, 4), takenlijst);
            ahmed.Ancienniteit = 4;

            takenlijst.Clear();
            takenlijst.Add("meetings", 5);
            takenlijst.Add("schriftelijke communicatie", 10);
            takenlijst.Add("mondelinge communicatie", 5);
            takenlijst.Add("documentenbeheer", 15);
            takenlijst.Add("reservetijd", 5);

            AdministratiefPersoneel hilde = new AdministratiefPersoneel("Hilde Tops", new DateTime(1964, 7, 26), takenlijst);
            hilde.Ancienniteit = 41;

            foreach (AdministratiefPersoneel personeel in AlleAdministratiefPersoneel)
            {
                Console.WriteLine($"* {personeel.GenereerNaamkaartje()}");
                Console.WriteLine($"\tSalaris: {personeel.BerekenSalaris()} euro.");
                Console.WriteLine($"\tWerkbelasting: {personeel.BepaalWerkbelasting()} uur.\n");
            }
        }



        // System.Object overrides
        public override string ToString()
        {
            return $"{base.ToString()}\nMeerbepaald, administratief personeel";
        }
    }
}