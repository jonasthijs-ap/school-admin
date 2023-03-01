using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal class Student
    {
        public string Naam;
        public DateTime GeboorteDatum;
        public uint Studentennummer;
        public string[] Cursussen = new string[5];
        public static uint Studententeller = 1;

        public string GenereerNaamKaartje()
        {
            return $"{this.Naam} (STUDENT)";
        }

        public double BepaalWerkbelasting()
        {
            double totaal = 0.0;

            for (int i = 0; i < Cursussen.Length; i++)
            {
                if (Cursussen[i] is not null)
                {
                    totaal += 10;
                }
            }

            return totaal;
        }
    }
}