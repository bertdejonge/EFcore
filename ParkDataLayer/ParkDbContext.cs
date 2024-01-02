using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using ParkDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer {
    public class ParkDbContext : DbContext {
        private readonly string _connectionString = @"Data Source=HP_BERT\SQLEXPRESS;Initial Catalog = EFcore; Integrated Security = True;TrustServerCertificate = true";

        public DbSet<HuisEF> Huizen { get; set; }
        public DbSet<HuurderEF> Huurders { get; set; }
        public DbSet<HuurcontractEF> HuurContracten { get; set; }
        public DbSet<HuurperiodeEF> Huurdperiodes { get; set; }
        public DbSet<ParkEF> Parken { get; set; }

        public ParkDbContext() {            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
