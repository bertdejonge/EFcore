using ParkDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    public class DatabaseInitializer {
        public DatabaseInitializer() {
            
        }

        public static void InitializeDatabase() {
            ParkDbContext ctx = new();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            //Console.WriteLine("Database aangemaakt!");
        }
    }
}
