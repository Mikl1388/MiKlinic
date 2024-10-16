using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiKlinic.Model;

namespace MiKlinic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Analysis> Analyses => Set<Analysis>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Diagnosis> Diagnoses => Set<Diagnosis>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Laboratory> Laboratories => Set<Laboratory>();
        public DbSet<MedicalInstitution> MedicalInstitutions => Set<MedicalInstitution>();
        public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Perscription> Perscriptions => Set<Perscription>();
        public DbSet<Schedule> Schedules => Set<Schedule>();
        public DbSet<TimeSlot> TimeSlots => Set<TimeSlot>();

        public ApplicationDbContext()
        {
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MedicalRecord>()
				.HasOne(mr => mr.Patient)
				.WithOne(p => p.MedicalRecord)
				.HasForeignKey<MedicalRecord>(mr => mr.PatientId);  // Configure the foreign key
		}

		// FIXME: unsafe
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Database=TestDB;Username=TestUser;Password=pass;Include Error Detail=true;");
		}
	}
}
