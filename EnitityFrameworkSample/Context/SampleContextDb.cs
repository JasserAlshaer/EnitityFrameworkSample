using EnitityFrameworkSample.Models;
using EnitityFrameworkSample.Models.EntityConfiguatation;
using Microsoft.EntityFrameworkCore;

namespace EnitityFrameworkSample.Context
{
    public class SampleContextDb : DbContext
    {
        public SampleContextDb(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PaientEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ClinicEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LoginEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorEntityConfiguration());
        }
        public DbSet<Paitent> Paitents { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Login> Logins { get; set; }    
        public DbSet<Clinic> Clinics { get; set; }
    }
}
