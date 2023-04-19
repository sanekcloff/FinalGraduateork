using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Entities;

namespace Tests.Data
{
    public class ApplicationDbContext:DbContext
    {
        // Server=DESKTOP-I8L1GP6
        private const string connectionString = @"Server=DESKTOP-I8L1GP6; Database=TestDB; Trusted_Connection=true; TrustServerCertificate=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<MigrationCard> MigrationCards { get; set; }
        public DbSet<Passport> Passports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passport>()
                .HasOne(p => p.Client)
                .WithOne(c => c.Passport)
                .HasForeignKey<Passport>
                (p => p.Id);

            modelBuilder.Entity<MigrationCard>()
                .HasOne(p => p.Client)
                .WithOne(c => c.MigrationCard)
                .HasForeignKey<MigrationCard>
                (p => p.Id);
        }
    }
}
