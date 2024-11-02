using System.ComponentModel.DataAnnotations;

namespace MiKlinic.Model
{
    public class Patient : User
    {
        public Patient() { }
        public Patient(string name, string contactPhone, List<Appointment> appointments, string insuranceNumber, MedicalRecord medicalRecord) : base(name)
        {
            ContactPhone = contactPhone ?? throw new ArgumentNullException(nameof(contactPhone));
            BookedAppointments = appointments ?? throw new ArgumentNullException(nameof(appointments));
            InsuranceNumber = insuranceNumber; // SUS: проверка
			MedicalRecord = medicalRecord ?? throw new ArgumentNullException(nameof(medicalRecord));
        }

		public Patient(string name, string contactPhone, string insuranceNumber, Adress adress) : base(name)
		{
			ContactPhone = contactPhone ?? throw new ArgumentNullException(nameof(contactPhone));
            BookedAppointments = new List<Appointment>();
			InsuranceNumber = insuranceNumber; // SUS: проверка
            Adress = adress;
			MedicalRecord = new MedicalRecord();
		}

        public Adress Adress { get; set; }
        public int AdressId { get; set; }
		public string ContactPhone { get; set; }
        public List<Appointment> BookedAppointments { get; set; }
        public string InsuranceNumber { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}
