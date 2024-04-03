using System.Text;
using libVesselManager;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace mysqlefcore
{
    class Program
    {
        static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables()
            .Build();
            var connStrBuilder = new MySqlConnectionStringBuilder();
            connStrBuilder.UserID=Configuration["vesselmanagerdev:user"];
            connStrBuilder.Server=Configuration["vesselmanagerdev:server"];
            connStrBuilder.Database=Configuration["vesselmanagerdev:database"];
            connStrBuilder.Password=Configuration["vesselmanagerdev:password"];
            VesselManagerContext.ConnectionString = connStrBuilder.ConnectionString;
            InsertData();
            PrintData();
        }

        private static void InsertData()
        {
            using var context = new VesselManagerContext();
            // Creates the database if not exists
            context.Database.EnsureCreated();

            context.Contacts.Add(new Contact
            {
                Name = "Person A",
                PhoneNumber = "(202) 867-5309"
            });

            context.Contacts.Add(new Contact
            {
                Name = "Person B"
            });

            context.Rooms.Add(new Room
            {
                RoomName = "Lazerette"
            });

            // Saves changes
            context.SaveChanges();
        }

        private static void PrintData()
        {
            // Gets and prints all books in database
            using var context = new VesselManagerContext();
            var contacts = context.Contacts;
            foreach (var contact in contacts)
            {
                var data = new StringBuilder();
                data.AppendLine($"ID: {contact.ContactId}");
                data.AppendLine($"Name: {contact.Name}");
                data.AppendLine($"Phone: {contact.PhoneNumber}");
                data.AppendLine($"Address: {contact.Address}");
                data.AppendLine($"Website: {contact.Website}");
                Console.WriteLine(data.ToString());
            }
        }
    }
}