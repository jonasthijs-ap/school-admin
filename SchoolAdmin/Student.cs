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
        public string[] Cursussen;
        public static uint Studententeller = 14378;
    }
}