using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MiKlinic.Model;

namespace MiKlinic.Data
{
    public class ApplicationDbContext : DbContext
    {
		public DbSet<User> Users => Set<User>();
		public DbSet<Doctor> Doctors => Set<Doctor>();
		public DbSet<Patient> Patients => Set<Patient>();
		public DbSet<Registrar> Registrars => Set<Registrar>();

		public DbSet<Adress> Adresses => Set<Adress>();
		public DbSet<Analysis> Analyses => Set<Analysis>();
		public DbSet<AnalisysType> AnalisysTypes => Set<AnalisysType>();
		public DbSet<Appointment> Appointments => Set<Appointment>();
		public DbSet<Diagnosis> Diagnoses => Set<Diagnosis>();
        public DbSet<Laboratory> Laboratories => Set<Laboratory>();
        public DbSet<MedicalInstitution> MedicalInstitutions => Set<MedicalInstitution>();
        public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();
        public DbSet<Perscription> Perscriptions => Set<Perscription>();
        public DbSet<Schedule> Schedules => Set<Schedule>();
        public DbSet<TimeSlot> TimeSlots => Set<TimeSlot>();
        public DbSet<Speciality> Specialities => Set<Speciality>();

        public ApplicationDbContext()
        {
		}
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MedicalRecord>()
				.HasOne(mr => mr.Patient)
				.WithOne(p => p.MedicalRecord)
				.HasForeignKey<MedicalRecord>(mr => mr.PatientId);

			modelBuilder.Entity<Doctor>().ToTable("Doctors");
			modelBuilder.Entity<Patient>().ToTable("Patients");
			modelBuilder.Entity<Registrar>().ToTable("Registrars");

			modelBuilder.Entity<Patient>()
			   .HasIndex(p => p.InsuranceNumber)
			   .IsUnique();
		}

		// FIXME: unsafe
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Database=Miklinic;Username=TestUser;Password=pass;Include Error Detail=true;");
			optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
		}
	}
}
