using Microsoft.EntityFrameworkCore;
using XpSprint3.Models;
using System.IO;

namespace XpSprint3.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Usa SQLite com um arquivo local na pasta do projeto
            var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "clientes.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
        }
    }
}
