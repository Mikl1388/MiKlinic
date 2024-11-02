using MiKlinic.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miklinic.Tests.Model
{
	public class PerscriptionTests
	{
		private readonly Prescription prescription;

		public PerscriptionTests()
		{
			prescription = new Prescription();
		}

		[Fact]
		public void PrescribingDoctor_Ok()
		{
			var mockDoctor = new Mock<Doctor>();
			mockDoctor.Setup(d => d.CanPrescribeMedication).Returns(true); // Настройка mock-объект. Врач может давать рецепты

			prescription.PrescribingDoctor = mockDoctor.Object;

			Assert.Equal(mockDoctor.Object, prescription.PrescribingDoctor); // Проверка установленное свойство
		}

		[Fact]
		public void PrescribingDoctor_Exception()
		{
			var mockDoctor = new Mock<Doctor>();
			mockDoctor.Setup(d => d.CanPrescribeMedication).Returns(false); // Настройка mock-объект. Врач НЕ может давать рецепты

			Assert.Throws<UnauthorizedAccessException>(() => prescription.PrescribingDoctor = mockDoctor.Object); // Проверка, что setter выбрасывает необходимое исключение
		}
	}
}
