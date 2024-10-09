namespace MiKlinic.Model
{
    public class MedicalRecord
    {
        public Patient Patient { get; set; }
        public List<Appointment> Appointments { get; set; }
        public string DoctorNotes { get; set; }
    }
}
