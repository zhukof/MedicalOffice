using MedicalOffice.DAL.Extensions;
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
        public DbSet<PatientRegionMapping> PatientRegionMappings { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientRegionMapping>()
                .HasKey(bc => new { bc.PatientId, bc.RegionId });
            
            modelBuilder.Entity<PatientRegionMapping>()
                .HasOne(bc => bc.Patient)
                .WithMany(b => b.Regions)
                .HasForeignKey(bc => bc.PatientId);
            
            modelBuilder.Entity<PatientRegionMapping>()
                .HasOne(bc => bc.Region)
                .WithMany(c => c.Patients)
                .HasForeignKey(bc => bc.RegionId);
            
            modelBuilder.Seed();
        }
    }
}