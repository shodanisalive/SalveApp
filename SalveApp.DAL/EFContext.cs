using Microsoft.EntityFrameworkCore;
using SalveApp.Infrastructure.Entities;

namespace SalveApp.DAL
{
    public class EFContext : DbContext
    {
        public DbSet<Clinic> Clinics { get; private set; }
        public DbSet<Patient> Patients { get; private set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(e =>
                e.Property(x => x.Id).ValueGeneratedOnAdd()
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
