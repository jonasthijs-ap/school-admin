using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolAdmin.Interfaces;

namespace SchoolAdmin
{
    public abstract class Persoon : ICSVSerializable
    {
		// Static attributen & properties
        private static uint maxId = 1;


        protected static List<Persoon> allePersonen = new List<Persoon>();
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

		public byte Leeftijd
		{
			get
			{
				byte leeftijd = (byte)(DateTime.Now.Year - GeboorteDatum.Year);
				return Convert.ToByte(leeftijd);
			}
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



		// Object methoden
		public string ToCSV()
		{
			return $"{GetType().Name};{Id};\"{Naam}\";{GeboorteDatum.ToString(new CultureInfo("nl-BE"))}";
		}



        // System.Object overrides
        public override string ToString()
        {
			string underline = "";
			for (byte i = 0; i < GetType().Name.Length; i++)
			{
				underline += "-";
			}

			return $"{GetType().Name}\n{underline}\nNaam: {Naam}\nLeeftijd: {Leeftijd}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
			{
				return false;
			}
			else if (GetType() != obj.GetType())
			{
				return false;
			}
			else
			{
				Persoon persoonObj = (Persoon)obj;
				if (Id == persoonObj.Id)
				{
					return true;
				}
			}

			return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}