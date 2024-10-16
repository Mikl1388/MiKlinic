
namespace MiKlinic.Model
{
    public class MedicalRecord
    {
        public MedicalRecord() { }

		public MedicalRecord(Patient patient, List<Appointment> appointments, string doctorNotes)
		{
			Patient = patient ?? throw new ArgumentNullException(nameof(patient));
			Appointments = appointments ?? throw new ArgumentNullException(nameof(appointments));
			DoctorNotes = doctorNotes;
		}
		public int Id { get; set; }
		public Patient Patient { get; set; }
		public ulong PatientId { get; set; }
        public List<Appointment> Appointments { get; set; }
        public string? DoctorNotes { get; set; }
    }
}
