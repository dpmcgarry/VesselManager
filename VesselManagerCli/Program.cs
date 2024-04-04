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
            connStrBuilder.UserID = Configuration["vesselmanagerdev:user"];
            connStrBuilder.Server = Configuration["vesselmanagerdev:server"];
            connStrBuilder.Database = Configuration["vesselmanagerdev:database"];
            connStrBuilder.Password = Configuration["vesselmanagerdev:password"];
            VesselManagerContext.ConnectionString = connStrBuilder.ConnectionString;
            InsertData();
            PrintData();
        }

        private static void InsertData()
        {
            using var context = new VesselManagerContext();
            // Creates the database if not exists
            context.Database.EnsureCreated();
            SeedMaintTypes(context);
            SeedSystems(context);
            SeedRooms(context);
            // Saves changes
            context.SaveChanges();
        }

        private static void PrintData()
        {
            // Gets and prints all books in database
            using var context = new VesselManagerContext();
            var mainttypes = context.MaintainanceTypes.ToList();
            foreach (var mainttype in mainttypes)
            {
                var data = new StringBuilder();
                data.AppendLine($"ID: {mainttype.MaintainanceTypeId}");
                data.AppendLine($"Name: {mainttype.MaintainanceTypeName}");
                Console.WriteLine(data.ToString());
            }
            var systems = context.Systems.ToList();
            foreach (var system in systems)
            {
                var data = new StringBuilder();
                data.AppendLine($"ID: {system.SystemId}");
                data.AppendLine($"Name: {system.SystemName}");
                Console.WriteLine(data.ToString());
            }
            var rooms = context.Rooms.ToList();
            foreach (var room in rooms)
            {
                var data = new StringBuilder();
                data.AppendLine($"ID: {room.RoomId}");
                data.AppendLine($"Name: {room.RoomName}");
                Console.WriteLine(data.ToString());
            }
        }

        private static void SeedMaintTypes(VesselManagerContext context)
        {
            var mainttypes = context.MaintainanceTypes.ToList();
            if (!mainttypes.Contains(new MaintainanceType
            {
                MaintainanceTypeId = 1,
                MaintainanceTypeName = "Periodic"
            }))
            {
                context.MaintainanceTypes.Add(new MaintainanceType
                {
                    MaintainanceTypeId = 1,
                    MaintainanceTypeName = "Periodic"
                });
            }

            if (!mainttypes.Contains(new MaintainanceType
            {
                MaintainanceTypeId = 2,
                MaintainanceTypeName = "Corrective"
            }))
            {
                context.MaintainanceTypes.Add(new MaintainanceType
                {
                    MaintainanceTypeId = 2,
                    MaintainanceTypeName = "Corrective"
                });
            }
            if (!mainttypes.Contains(new MaintainanceType
            {
                MaintainanceTypeId = 3,
                MaintainanceTypeName = "Enhancement"
            }))
            {
                context.MaintainanceTypes.Add(new MaintainanceType
                {
                    MaintainanceTypeId = 3,
                    MaintainanceTypeName = "Enhancement"
                });
            }
        }

        private static void SeedSystems(VesselManagerContext context)
        {
            var sys = context.Systems.ToList();
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 1,
                SystemName = "Appliance"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 1,
                    SystemName = "Appliance"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 2,
                SystemName = "Bottom"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 2,
                    SystemName = "Bottom"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 3,
                SystemName = "Dinghy"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 3,
                    SystemName = "Dinghy"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 4,
                SystemName = "Electric"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 4,
                    SystemName = "Electric"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 5,
                SystemName = "Electronic"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 5,
                    SystemName = "Electronic"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 6,
                SystemName = "Exterior"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 6,
                    SystemName = "Exterior"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 7,
                SystemName = "General"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 7,
                    SystemName = "General"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 8,
                SystemName = "Generator"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 8,
                    SystemName = "Generator"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 9,
                SystemName = "HVAC"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 9,
                    SystemName = "HVAC"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 10,
                SystemName = "Hydraulic"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 10,
                    SystemName = "Hydraulic"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 11,
                SystemName = "Interior"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 11,
                    SystemName = "Interior"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 12,
                SystemName = "Main Engine"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 12,
                    SystemName = "Main Engine"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 13,
                SystemName = "Outboard"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 13,
                    SystemName = "Outboard"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 14,
                SystemName = "Plumbing"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 14,
                    SystemName = "Plumbing"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 15,
                SystemName = "Refrigeration"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 15,
                    SystemName = "Refrigeration"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 16,
                SystemName = "Safety"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 16,
                    SystemName = "Safety"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 17,
                SystemName = "Thruster"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 17,
                    SystemName = "Thruster"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 18,
                SystemName = "Watermaker"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 18,
                    SystemName = "Watermaker"
                });
            }
            if (!sys.Contains(new libVesselManager.System
            {
                SystemId = 19,
                SystemName = "Wing Engine"
            }))
            {
                context.Systems.Add(new libVesselManager.System
                {
                    SystemId = 19,
                    SystemName = "Wing Engine"
                });
            }
        }

        private static void SeedRooms(VesselManagerContext context)
        {
            var rooms = context.Rooms.ToList();
            if (!rooms.Contains(new Room
            {
                RoomId = 1,
                RoomName = "VIP Stateroom"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 1,
                    RoomName = "VIP Stateroom"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 2,
                RoomName = "VIP Head"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 2,
                    RoomName = "VIP Head"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 3,
                RoomName = "Guest Stateroom"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 3,
                    RoomName = "Guest Stateroom"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 4,
                RoomName = "Master Stateroom"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 4,
                    RoomName = "Master Stateroom"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 5,
                RoomName = "Master Head"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 5,
                    RoomName = "Master Head"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 6,
                RoomName = "Forward Stairs"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 6,
                    RoomName = "Forward Stairs"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 7,
                RoomName = "Master Stairs"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 7,
                    RoomName = "Master Stairs"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 8,
                RoomName = "Engine Room"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 8,
                    RoomName = "Engine Room"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 9,
                RoomName = "Bow"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 9,
                    RoomName = "Bow"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 10,
                RoomName = "Portuguese Bridge"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 10,
                    RoomName = "Portuguese Bridge"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 11,
                RoomName = "Pilothouse"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 11,
                    RoomName = "Pilothouse"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 12,
                RoomName = "Galley"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 12,
                    RoomName = "Galley"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 13,
                RoomName = "Salon"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 13,
                    RoomName = "Salon"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 14,
                RoomName = "Commissary"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 14,
                    RoomName = "Commissary"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 15,
                RoomName = "Aft Deck"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 15,
                    RoomName = "Aft Deck"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 16,
                RoomName = "Lazarette"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 16,
                    RoomName = "Lazarette"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 17,
                RoomName = "Flybridge"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 17,
                    RoomName = "Flybridge"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 18,
                RoomName = "Boat Deck"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 18,
                    RoomName = "Boat Deck"
                });
            }
            if (!rooms.Contains(new Room
            {
                RoomId = 19,
                RoomName = "Dinghy"
            }))
            {
                context.Rooms.Add(new Room
                {
                    RoomId = 19,
                    RoomName = "Dinghy"
                });
            }
        }
    }
}