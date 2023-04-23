using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    public class VakInschrijving
    {
        // Object attributen & properties
        private Cursus cursus;
        public Cursus Cursus
        {
            get { return cursus; }
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
        public VakInschrijving(Cursus cursus, byte? resultaat)
        {
            this.cursus = cursus;
            this.Resultaat = resultaat;
        }
    }
}