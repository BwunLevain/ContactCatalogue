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
        private Dictionary<int, Contact> byId = new Dictionary<int, Contact>();
        private HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public void AddContact(Contact c)
        {
            try
            {
                if (!IsValidEmail(c.Email)) throw new InvalidEmailException(c.Email);
                if (!emails.Add(c.Email)) throw new DuplicateEmailException(c.Email);
            }
            catch (InvalidEmailException ex)
            {
                // CATCH block for a specific validation error
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"CAUGHT VALIDATION ERROR: {ex.Message}");
                Console.ResetColor();
            }
            catch (DuplicateEmailException ex)
            {
                // CATCH block for a specific data integrity error
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"CAUGHT DUPLICATE ERROR: {ex.Message}");
                Console.ResetColor();
            }
            byId.Add(c.Id, c);
        }
        static bool IsValidEmail(string email)
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
