
namespace MiKlinic.Model
{
    public class Analysis
    {
		public Analysis(Doctor prescribingDoctor, Patient patient, Laboratory laboratory, int analisysType, string result)
		{
			PrescribingDoctor = prescribingDoctor ?? throw new ArgumentNullException(nameof(prescribingDoctor));
			Patient = patient ?? throw new ArgumentNullException(nameof(patient));
			this.laboratory = laboratory ?? throw new ArgumentNullException(nameof(laboratory));
			AnalisysType = analisysType;
			Result = result ?? throw new ArgumentNullException(nameof(result));
		}

		public Doctor PrescribingDoctor { get; set; }
        public Patient Patient { get; set; }
        public Laboratory laboratory { get; set; }
        public int AnalisysType { get; set; } //DB: another type
        public string Result { get; set; }

	}
}
