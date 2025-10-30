using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactCatalogue.ConsoleUI
{
    internal class ContactAdder
    {
        private readonly ContactCatalogue _cc;
        public ContactAdder(ContactCatalogue cc)
        {
            _cc = cc;
        }
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Contact Adder ===");
                Console.Write("\nName: ");
                string nameInp = Console.ReadLine();
                Console.Write("\nEmail: ");
                string emailInp = Console.ReadLine();
                Console.Write("\nTags (ex: tag1, tag2...): ");
                string tagsInp = Console.ReadLine();


                if (_cc.AddContact(new Contact(_cc.GenerateUniqueID(), nameInp, emailInp, tagsInp)))
                {
                    Console.WriteLine("[Added 1 contact in your catalogue.]");
                    break;
                }
            }
        }
    }
}
