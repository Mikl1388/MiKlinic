
namespace MiKlinic
{
	public class Doctor
	{
		//DRAFT: im not sure
		public Doctor(int specializationId, bool canPrescribeMedication, Schedule schedule)
		{
			SpecializationId = specializationId;
			CanPrescribeMedication = canPrescribeMedication;
			Schedule = schedule ?? throw new ArgumentNullException(nameof(schedule));
		}

		public int SpecializationId { get; set; }
		public bool CanPrescribeMedication { get; set; }
		public Schedule Schedule { get; private set; }
	}
}
