using System;
using System.Collections.Generic;
using ContactCatalogue.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ContactCatalogue.ConsoleUI
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

            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Ava Harper", "ava.harper@example.com", "friend, coworker"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Ben Carter", "ben.carter@example.com", "family"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Clara Nguyen", "clara.nguyen@example.org", "work"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Diego Morales", "diego.morales@gmail.com", "gym, friend"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Eva Thompson", "eva.thompson@outlook.com", "neighbor"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Frank Liu", "frank.liu@company.com", "work, manager"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Grace Lee", "grace.lee@gmail.com", "friend, school"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Hector Ramirez", "hector.ramirez@mail.com", "guitar, band"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Iris Patel", "iris.patel@domain.com", "friend, colleague"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Jon Smith", "jon.smith@example.com", "school"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Kira Johnson", "kira.johnson@pobox.com", "friend"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Liam O'Connor", "liam.oconnor@example.com", "young"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Mona Rossi", "mona.rossi@art.com", "artist"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Noah Brown", "noah.brown@home.com", "family"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Olivia Martin", "olivia.martin@example.com", "work, lead"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Pablo Suarez", "pablo.suarez@studio.com", "photography"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Quinn Blake", "quinn.blake@example.com", "gym"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Rita Gomez", "rita.gomez@mail.com", "friend, cooking"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Sam Walker", "sam.walker@tech.io", "dev, coworker"));
            cc.AddContact(new Contact(cc.GenerateUniqueID(), "Tina Alvarez", "tina.alvarez@company.org", "hr"));
            FilteringSystem filterSystem = new(cc);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Contact Catalogue ===");
                Console.WriteLine("1) Add");
                Console.WriteLine("2) List");
                Console.WriteLine("3) Search (Name contains)");
                Console.WriteLine("4) Filter");
                Console.WriteLine("5) Export to CSV file");
                Console.WriteLine("0) Exit");
                Console.Write("\n>> ");
                string inp = Console.ReadLine();


                switch (inp)
                {
                    case "1":
                        ContactAdder contactAdder = new ContactAdder(cc);
                        contactAdder.Run();
                        break;
                    case "2":
                        cc.ShowAllContacts();
                        Console.ReadKey(true);
                        break;
                    case "3":
                        filterSystem.SearchByName();
                        Console.ReadKey(true);
                        break;
                    case "4":
                        filterSystem.SearchByTag();
                        Console.ReadKey(true);
                        break;
                    case "5":
                        Console.WriteLine("Feature not yet implemented.");
                        Console.ReadKey(true);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid Input. Try Again...");
                        Console.ReadKey(true);
                        break;
                }
            }

        }
    }
}
