using EnitityFrameworkSample.Models;
using Microsoft.EntityFrameworkCore;

namespace EnitityFrameworkSample.Context
{
    public class SampleContextDb : DbContext
    {
        public SampleContextDb(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Paitent> Paitents { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Login> Logins { get; set; }    
        public DbSet<Clinic> Clinics { get; set; }
    }
}
