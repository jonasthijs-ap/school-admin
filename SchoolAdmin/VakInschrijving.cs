using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolAdmin.CustomExceptions;

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
            if (cursus is null || student is null)
            {
                throw new ArgumentException("Vakinschrijvingen mogen geen lege waarden voor 'cursus' en 'student' hebben.");
            }

            byte aantalCursussen = 0;
            foreach (VakInschrijving vakInschrijving in AlleVakInschrijvingen)
            {
                if (vakInschrijving.Cursus.Equals(cursus) && vakInschrijving.Resultaat is null)
                {
                    aantalCursussen++;

                    if (aantalCursussen >= 20)
                    {
                        throw new CapaciteitOverschredenException("Maximumcapaciteit is overschreden. Elk vak kan slechts 20 vakinschrijvingen tegelijk hebben.");
                    }
                }
                else if (vakInschrijving.Student.Cursussen.Contains(cursus))
                {
                    throw new ArgumentException("Student mag niet meermaals toegevoegd worden aan dezelfde cursus.");
                }
            }
            
            this.cursus = cursus;
            this.student = student;
            this.Resultaat = resultaat;

            alleVakInschrijvingen.Add(this);
        }
    }
}