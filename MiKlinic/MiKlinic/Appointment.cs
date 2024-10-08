namespace MiKlinic
{
	public class Appointment
	{
		public Appointment(Patient patient, Doctor doctor, TimeSlot timeSlot, Diagnosis diagnosis, List<Analysis> analyses, List<Perscription> perscriptions)
		{
			Patient = patient ?? throw new ArgumentNullException(nameof(patient));
			Doctor = doctor ?? throw new ArgumentNullException(nameof(doctor));
			TimeSlot = timeSlot ?? throw new ArgumentNullException(nameof(timeSlot));
			Diagnosis = diagnosis ?? throw new ArgumentNullException(nameof(diagnosis));
			Analyses = analyses ?? throw new ArgumentNullException(nameof(analyses));
			Perscriptions = perscriptions ?? throw new ArgumentNullException(nameof(perscriptions));
		}

		public Patient Patient { get; set; }
		public Doctor Doctor { get; set; }
		public TimeSlot TimeSlot { get; set; }
		public Diagnosis Diagnosis { get; set; }
		public List<Analysis> Analyses { get; set; }
		public List<Perscription> Perscriptions { get; set; }


		public void NotifyPatient()
		{
			throw new NotImplementedException();
		}

	}
}
