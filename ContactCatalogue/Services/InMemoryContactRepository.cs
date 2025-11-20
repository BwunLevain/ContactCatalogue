using ContactCatalogue.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactCatalogue.Services
{
    public class InMemoryContactRepository : IContactRepository
    {
        private readonly Dictionary<int, Contact> _byId = new();

        private readonly HashSet<string> _emails = new(StringComparer.OrdinalIgnoreCase);

        public IEnumerable<Contact> GetAll()
        {
            return _byId.Values;
        }

        public void Add(Contact c)
        {
            _byId.Add(c.Id, c);
            _emails.Add(c.Email);
        }

        public bool ContainsEmail(string email)
        {
            return _emails.Contains(email);
        }
    }
}