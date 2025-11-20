using ContactCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalogue.Services
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
        void Add(Contact c);
    }
}
