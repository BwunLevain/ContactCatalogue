using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ContactCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            ILogger logger = loggerFactory.CreateLogger<Program>();
            ILogger<ContactCatalogue> cclogger = loggerFactory.CreateLogger<ContactCatalogue>();

            ContactCatalogue cc = new ContactCatalogue(cclogger);


            logger.LogInformation("Program starting");

            cc.AddContact(new Contact(1, "name", "m@gmail.com", "je, d, d"));
            cc.AddContact(new Contact(2, "name", "m@gmail.com", "je, d, d"));

        }
    }
}
