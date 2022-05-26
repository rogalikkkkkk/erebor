using Erebor.Models;
using Microsoft.EntityFrameworkCore;

namespace Erebor.Application
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Attendance> Attendances { get; set; } = null!;
        public DbSet<Lector> Lectors { get; set; } = null!;
        public DbSet<Lecture> Lectures { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=erebor_db;Username=soso;Password=soso");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}