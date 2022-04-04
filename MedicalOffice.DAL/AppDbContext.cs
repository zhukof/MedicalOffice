using MedicalOffice.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalOffice.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
    }
}