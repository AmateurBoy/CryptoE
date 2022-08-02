using CryptoE.Data.Entitys;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CryptoE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private static string IpServer = "(localdb)";
        private static string NameDB = "BitExchanger";
        public DbSet<Coin> Coins { get; set; }
        
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server={IpServer}\\mssqllocaldb;Database={NameDB};Trusted_Connection=True;");
        }
    }
}