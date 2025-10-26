using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalogue.Exceptions
{
    internal class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email) : base(email + " is invalid") { }
    }
}
