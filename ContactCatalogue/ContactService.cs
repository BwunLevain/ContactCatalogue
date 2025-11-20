using ContactCatalogue.Exceptions;
using Microsoft.Extensions.Logging;

namespace ContactCatalogue
{
    public class ContactService
    {
        private readonly IContactRepository _repository;
        private readonly ILogger<ContactService> _logger;

        public ContactService(IContactRepository repository, ILogger<ContactService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public bool AddContact(Contact c)
        {
            try
            {
                if (!IsValidEmail(c.Email)) throw new InvalidEmailException(c.Email);
                var allContacts = _repository.GetAll();
                if (allContacts.Any(existing => existing.Email.Equals(c.Email, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new DuplicateEmailException(c.Email);
                }

                _repository.Add(c);

                _logger.LogInformation("\nContact added: {Email}", c.Email);
                return true;
            }
            catch (InvalidEmailException ex)
            {
                _logger.LogWarning("Invalid email: {Email}", c.Email);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"CAUGHT VALIDATION ERROR: {ex.Message}");
                Console.ResetColor();
                return false;
            }
            catch (DuplicateEmailException ex)
            {
                _logger.LogWarning("Duplicated email: {Email}", c.Email);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"CAUGHT DUPLICATE ERROR: {ex.Message}");
                Console.ResetColor();
                return false;
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

        public void ShowAllContacts()
        {
            var contacts = _repository.GetAll().ToList();

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts....");
                Console.ReadKey(true);
            }
            foreach (var c in contacts)
            {
                Console.WriteLine(c);
            }
        }

        public List<Contact> SearchByName(string searching)
        {
            return _repository.GetAll()
                .Where(c => c.Name.Contains(searching, StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Name)
                .ToList();
        }

        public List<Contact> SearchByTag(string searching)
        {
            return _repository.GetAll()
                .Where(c => c.Tags != null && c.Tags.Contains(searching, StringComparer.OrdinalIgnoreCase))
                .OrderBy(c => c.Name)
                .ToList();
        }
    }
}