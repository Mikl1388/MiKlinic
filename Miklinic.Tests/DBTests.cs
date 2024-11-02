using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MiKlinic.Data;
using MiKlinic.Model;
using Xunit;

namespace Miklinic.Tests
{
	public class ApplicationDbContextTests
	{
		private readonly string _connectionString = "Host=localhost;Database=TestDB;Username=TestUser;Password=pass;Include Error Detail=true;";

		private ApplicationDbContext CreateTestDbContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseNpgsql(_connectionString)
				.LogTo(Console.WriteLine)
				.Options;

			var context = new ApplicationDbContext(options);
			context.Database.EnsureCreated();

			return context;
		}

		[Fact]
		public void CanAddAndRetrievePatient()
		{
			using (var context = CreateTestDbContext())
			{
				context.Database.EnsureDeleted();
				context.Database.EnsureCreated();
				var testAdress = new Adress("1", "1", "ул. Ленина", "Москва", "Москва", "Россия", "00000000");
				var newPatient = new Patient("Валерий Селёдкин", "88005553535", "1234567890", testAdress);
				context.Patients.Add(newPatient);
				context.SaveChanges();
			}

			using (var context = CreateTestDbContext())
			{
				var retrievedPatient = context.Patients.Include(p => p.Adress).FirstOrDefault(p => p.Name == "Валерий Селёдкин");
				Assert.NotNull(retrievedPatient);
				Assert.Equal("Валерий Селёдкин", retrievedPatient.Name);
				Assert.Equal("88005553535", retrievedPatient.ContactPhone);
				Assert.Equal("1234567890", retrievedPatient.InsuranceNumber);
				Assert.NotNull(retrievedPatient.Adress);
				Assert.Equal("Москва", retrievedPatient.Adress.City);
			}
		}
	}
}