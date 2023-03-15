using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class VakInschrijving
    {
        private string naam;
        private byte? resultaat;

        public string Naam
        {
            get
            {
                return naam;
            }
        }

        public byte? Resultaat
        {
            get
            {
                return resultaat;
            }
            set
            {
                if (value is not null || value >= 0 && value <= 20)
                {
                    resultaat = value;
                }
            }
        }

        public VakInschrijving(string cursusNaam, byte? resultaat)
        {
            this.naam = cursusNaam;
            this.Resultaat = resultaat;
        }
    }
}