using ContactCatalogue.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCatalogue
{
    internal class ContactCatalogue
    {
        private Dictionary<int, Contact> byId = new Dictionary<int, Contact>();
        private HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly ILogger<ContactCatalogue> _logger;

        public ContactCatalogue(ILogger<ContactCatalogue> logger)
        {
            _logger = logger;
        }

        public void AddContact(Contact c)
        {
            try
            {
                if (!IsValidEmail(c.Email))
                    throw new InvalidEmailException(c.Email);

                if (!emails.Add(c.Email))
                    throw new DuplicateEmailException(c.Email);
                byId.Add(c.Id, c);
                _logger.LogInformation("Contact added: {Email}", c.Email);
            }
            catch (InvalidEmailException ex)
            {
                _logger.LogWarning("Invalid email: {Email}", c.Email);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"CAUGHT VALIDATION ERROR: {ex.Message}");
                Console.ResetColor();
            }
            catch (DuplicateEmailException ex)
            {
                _logger.LogWarning("Duplicated email: {Email}", c.Email);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"CAUGHT DUPLICATE ERROR: {ex.Message}");
                Console.ResetColor();
            }
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
