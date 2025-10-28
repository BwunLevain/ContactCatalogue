using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCatalogue.Exceptions;

namespace ContactCatalogue
{
    internal class ContactCatalogue
    {

        public Dictionary<int, Contact> ById = new Dictionary<int, Contact>();
        private HashSet<string> Emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public bool AddContact(Contact c)
        {
            try
            {
                if (!IsValidEmail(c.Email)) throw new InvalidEmailException(c.Email);
                if (!Emails.Add(c.Email)) throw new DuplicateEmailException(c.Email);
            }
            catch (InvalidEmailException ex)
            {
                // CATCH block for a specific validation error
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"CAUGHT VALIDATION ERROR: {ex.Message}");
                Console.ResetColor();
                Console.ReadKey(true);
                return false;
            }
            catch (DuplicateEmailException ex)
            {
                // CATCH block for a specific data integrity error
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"CAUGHT DUPLICATE ERROR: {ex.Message}");
                Console.ResetColor();
                Console.ReadKey(true);
                return false;
            }
            ById.Add(c.Id, c);
            return true;
        }

       

        public int GenerateUniqueID()
        {
            int uniqueID = 0;
            Random random = new Random();
            do
            {
                uniqueID = random.Next(10000);
            } while (ById.ContainsKey(uniqueID));
            return uniqueID;   
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch { return false; }
        }
    }
}
