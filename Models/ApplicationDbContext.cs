using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AlbumRent_MVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        private static string ConnectionURL = @"Data Source=SHABRINA\MSSQLSERVER01;Initial Catalog = Albums; Integrated Security = True";

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionURL);
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<RentTransaction> Transactions { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
