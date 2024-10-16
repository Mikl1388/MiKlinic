namespace MiKlinic.Model
{
    public class Appointment
    {
		private TimeSlot timeSlot;

		public Appointment() {}
		public Appointment(Patient patient, Doctor doctor, TimeSlot timeSlot, string complaints, Diagnosis diagnosis, List<Analysis> analyses, List<Perscription> perscriptions, string otherInfo)
		{
			Patient = patient ?? throw new ArgumentNullException(nameof(patient));
			Doctor = doctor ?? throw new ArgumentNullException(nameof(doctor));
			TimeSlot = timeSlot ?? throw new ArgumentNullException(nameof(timeSlot));
			Complaints = complaints ?? throw new ArgumentNullException(nameof(complaints));
			Diagnosis = diagnosis ?? throw new ArgumentNullException(nameof(diagnosis));
			Analyses = analyses ?? throw new ArgumentNullException(nameof(analyses));
			Perscriptions = perscriptions ?? throw new ArgumentNullException(nameof(perscriptions));
			OtherInfo = otherInfo ?? throw new ArgumentNullException(nameof(otherInfo));
		}

		public int Id { get; set; }
		public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
		public TimeSlot TimeSlot { get => timeSlot; 
			set 
			{ 
				timeSlot = value;
				timeSlot.Book();
			}
		}
		public string Complaints { get; set; }
		public Diagnosis Diagnosis { get; set; }
        public List<Analysis> Analyses { get; set; }
        public List<Perscription> Perscriptions { get; set; }
        public string OtherInfo { get; set; } //SUS: mb divide in more fields

        public void NotifyPatient()
        {
            throw new NotImplementedException();
        }

    }
}
