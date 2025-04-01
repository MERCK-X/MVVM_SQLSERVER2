using Microsoft.EntityFrameworkCore;
using MVVM_SQLSERVER2.Models;

namespace MVVM_SQLSERVER2.Data
{
    public class LocalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={Path.Combine(FileSystem.AppDataDirectory, "appdb.db3")}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}