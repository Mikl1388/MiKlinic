

namespace MiKlinic.Model
{
    public class Analysis
    {
		public Analysis() { }

		public Analysis(int id, int prescribingDoctorId, Doctor prescribingDoctor, int patientId, Patient patient, int laboratoryId, Laboratory laboratory, int analisysType, string result)
		{
			Id = id;
			PrescribingDoctorId = prescribingDoctorId;
			PrescribingDoctor = prescribingDoctor ?? throw new ArgumentNullException(nameof(prescribingDoctor));
			PatientId = patientId;
			Patient = patient ?? throw new ArgumentNullException(nameof(patient));
			LaboratoryId = laboratoryId;
			Laboratory = laboratory ?? throw new ArgumentNullException(nameof(laboratory));
			AnalisysType = analisysType;
			Result = result ?? throw new ArgumentNullException(nameof(result));
		}

		public Analysis(Doctor prescribingDoctor, Patient patient, Laboratory laboratory, int analisysType, string result)
		{
			PrescribingDoctor = prescribingDoctor;
			Patient = patient;
			Laboratory = laboratory;
			AnalisysType = analisysType;
			Result = result;
		}

		public int Id { get; set; }
		public int PrescribingDoctorId { get; set; }
		public Doctor PrescribingDoctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
		public int LaboratoryId { get; set; }
		public Laboratory Laboratory { get; set; }
		public int AnalisysType { get; set; } //DB: another type
        public string Result { get; set; }

	}
}
