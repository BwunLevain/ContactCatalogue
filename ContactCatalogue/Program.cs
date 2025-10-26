namespace ContactCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContactCatalogue cc = new ContactCatalogue();
            cc.AddContact(new Contact(1, "name", "m@gmail.com", "je, d, d"));
            cc.AddContact(new Contact(2, "name", "m@gmail.com", "je, d, d"));

        }
    }
}
