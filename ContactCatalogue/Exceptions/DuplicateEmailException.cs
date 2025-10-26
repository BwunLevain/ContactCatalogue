﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalogue.Exceptions
{
    internal class DuplicateEmailException : Exception
    {
        public DuplicateEmailException(string email):base(email+" already exists") { }
    }
}
