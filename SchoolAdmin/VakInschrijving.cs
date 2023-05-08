using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class VakInschrijving
    {
        // Static attributen & properties
        private static List<VakInschrijving> alleVakInschrijvingen = new List<VakInschrijving>();
        public static ImmutableList<VakInschrijving> AlleVakInschrijvingen
        {
            get { return alleVakInschrijvingen.ToImmutableList(); }
        }



        // Object attributen & properties
        private Cursus cursus;
        public Cursus Cursus
        {
            get { return cursus; }
        }


        private Student student;
        public Student Student
        {
            get { return student; }
        }


        private byte? resultaat;
        public byte? Resultaat
        {
            get { return resultaat; }
            set
            {
                if (value is not null || value >= 0 && value <= 20)
                {
                    resultaat = value;
                }
            }
        }



        /* ************************** */



        // Constructors
        public VakInschrijving(Cursus cursus, Student student, byte? resultaat)
        {
            this.cursus = cursus;
            this.student = student;
            this.Resultaat = resultaat;

            alleVakInschrijvingen.Add(this);
        }
    }
}