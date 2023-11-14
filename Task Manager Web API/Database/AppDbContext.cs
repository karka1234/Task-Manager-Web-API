using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Task_Manager_Web_API.Models;

namespace Task_Manager_Web_API.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Category> Categoryes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();

            //modelBuilder.Entity<User>().HasKey(u => u.Id).HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<Category>().HasKey(c => c.Id).HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<Assignment>().HasKey(a => a.Id).HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);
        }
    }
}