using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalogue.Models
{
    public class Contact
    {
        public int Id;
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Tags { get; set; }

        
        public Contact() { }
        public Contact(int id, string name, string email, string tags)
        {
            Name = name;
            Email = email;
            Id = id;
            Tags = tags.Split(",").Select(t => t.Trim()).ToList();
            
        }

        public override string ToString()
        {
            return $"- ({Id}) {Name} <{Email}> [{string.Join(", ", Tags)}]\n";
        }
    }
}
