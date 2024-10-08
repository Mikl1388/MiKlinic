
namespace MiKlinic
{
    public class Patient : Person
    {
		//SUS: can be redone entirely
		public Patient(int id, string name, string contactPhone, List<Appointment> appointments, ulong insuranceNumber, MedicalRecord medicalRecord) : base(id, name)
		{
			ContactPhone = contactPhone ?? throw new ArgumentNullException(nameof(contactPhone));
			Appointments = appointments ?? throw new ArgumentNullException(nameof(appointments));
			InsuranceNumber = insuranceNumber;
			MedicalRecord = medicalRecord ?? throw new ArgumentNullException(nameof(medicalRecord));
		}

		public string ContactPhone { get; set; }
        public List<Appointment> Appointments { get; set; }
        public ulong InsuranceNumber { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

		//TODO: Add methods idk xd

	}
}
