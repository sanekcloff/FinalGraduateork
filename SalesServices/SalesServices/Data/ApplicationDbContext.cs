using Microsoft.EntityFrameworkCore;
using SalesServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Data
{
    public class ApplicationDbContext: DbContext
    {
        private const string connectionString = @"Server=DESKTOP-I8L1GP6; Database=SalesServiceDB; Trusted_Connection=true; TrustServerCertificate=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<FavoriteUserProduct> FavoriteUserProducts { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserProduct> UserProducts { get; set; } = null!;
        public DbSet<UserProfile> UserProfiles { get; set; } = null!;
        public DbSet<UserService> UserServices { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .HasOne(up => up.User)
                .WithOne(u => u.UserProfile)
                .HasForeignKey<UserProfile>
                (up => up.UserId);
        }
    }
}
