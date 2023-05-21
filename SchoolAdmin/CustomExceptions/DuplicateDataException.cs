using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin.CustomExceptions
{
    public class DuplicateDataException : ApplicationException
    {
		private object nieuweCursus;
		public object NieuweCursus
		{
			get { return nieuweCursus; }
			set { nieuweCursus = value; }
		}

        private object bestaandeCursus;
        public object BestaandeCursus
        {
            get { return bestaandeCursus; }
            set { bestaandeCursus = value; }
        }
        
        
        
        public DuplicateDataException(string message, object nieuweCursus, object bestaandeCursus) : base(message)
        {
            NieuweCursus = nieuweCursus;
            BestaandeCursus = bestaandeCursus;
        }
    }
}