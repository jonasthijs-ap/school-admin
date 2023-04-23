using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public abstract class Persoon
    {
		// Static attributen & properties
        private static uint maxId = 1;


        private static List<Persoon> allePersonen = new List<Persoon>();
        public static ImmutableList<Persoon> AllePersonen
        {
            get { return allePersonen.ToImmutableList(); }
        }



		// Object attributen & properties
		private string naam;
		public string Naam
		{
			get { return naam; }
			set { naam = value; }
		}


        private uint id;
		public uint Id
		{
			get { return id; }
		}


		private DateTime geboorteDatum;
		public DateTime GeboorteDatum
		{
			get { return geboorteDatum; }
		}



        /* ************************** */



        // Constructors
        public Persoon(string naam, DateTime geboorteDatum)
		{
			this.naam = naam;
			this.id = maxId;
			this.geboorteDatum = geboorteDatum;
			maxId++;
		}



        /* ************************** */



        // Abstract methoden
        public abstract string GenereerNaamkaartje();
		public abstract byte BepaalWerkbelasting();
	}
}