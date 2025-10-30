using System;
using System.Collections.Generic;
using System.Linq;
using ContactCatalogue;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace ContactCatalogue.Services
{
    internal class FilteringSystem
    {
        private readonly ContactCatalogue _cc;

        public FilteringSystem(ContactCatalogue cc) {  _cc = cc; }

        public void SearchByName()
        {
            Console.Clear();
            Console.Write("Search by name: ");
            string nameInput = Console.ReadLine();

            var hitsByName = _cc.byId.Values.Where(c => c.Name.Contains(nameInput, StringComparison.OrdinalIgnoreCase)).OrderBy(c => c.Name).ToList();
            if(hitsByName.Count == 0)
            {
                Console.WriteLine("No matches...");
                return;
            }
            foreach (var hit in hitsByName) 
            {
                Console.WriteLine(hit);
            }
        }
        public void SearchByTag()
        {
            Console.Clear();
            Console.Write("Filter by tag: ");
            string tag = Console.ReadLine();

            List<Contact> hitsByTag = _cc.byId.Values.Where(c => c.Tags.Contains(tag, StringComparer.OrdinalIgnoreCase)).OrderBy(c => c.Name).ToList();
            if (hitsByTag.Count == 0)
            {
                Console.WriteLine("No matches...");
                return;
            }
            foreach (var hit in hitsByTag)
            {
                Console.WriteLine(hit);
            }

        }

    }
}
