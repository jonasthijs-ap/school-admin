using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public abstract class Personeel : Persoon
    {
        // Static attributen & properties
        public static ImmutableList<Personeel> AllePersoneel
        {
            get
            {
                List<Personeel> allePersoneel = new List<Personeel>();
                foreach (var persoon in AllePersonen)
                {
                    if (persoon is Personeel)
                    {
                        allePersoneel.Add((Personeel)persoon);
                    }
                }

                return allePersoneel.ToImmutableList();
            }
        }



        // Object attributen & properties
        private byte ancienniteit;
        public byte Ancienniteit
        {
            get { return ancienniteit; }
            set
            {
                if (value > 50)
                {
                    ancienniteit = 50;
                }
                else
                {
                    ancienniteit = value;
                }
            }
        }


        private Dictionary<string, byte> taken = new Dictionary<string, byte>();
        public ImmutableDictionary<string, byte> Taken
        {
            get { return taken.ToImmutableDictionary(); }
        }



        /* ************************** */



        // Constructors
        public Personeel(string naam, DateTime geboorteDatum, Dictionary<string, byte> taken) : base(naam, geboorteDatum)
        {
            if (taken is not null)
            {
                foreach (var taak in taken)
                {
                    this.taken.Add(taak.Key, taak.Value);
                }
            }
        }



        /* ************************** */



        // Abstract methoden
        public abstract uint BerekenSalaris();



        // Object methoden
        public string ToCSV()
        {
            string taken = "";
            foreach (var taak in Taken)
            {
                taken += ";\"" + taak.Key + "\";" + taak.Value;
            }
            return $"{base.ToCSV()}{taken}";
        }
    }
}