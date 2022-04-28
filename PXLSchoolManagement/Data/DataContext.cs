using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PXLSchoolManagement.Models;

namespace PXLSchoolManagement.Data
{
    public class DataContext : IdentityDbContext<Gebruiker>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Academiejaar> Academiejaren { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Handboek> Handboeken { get; set; }
        public DbSet<Inschrijving> Inschrijvingen { get; set; }
        public DbSet<Lector> Lectoren { get; set; }
        public DbSet<Student> Studenten { get; set; }
        public DbSet<Vak> Vakken { get; set; }
        public DbSet<Vaklector> Vaklectoren { get; set; }

    }
}
