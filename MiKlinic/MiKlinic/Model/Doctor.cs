namespace MiKlinic.Model
{
    public class Doctor : Person
    {
        //DRAFT: im not sure doctor
        public Doctor(string name, int specializationId, bool canPrescribeMedication, Schedule schedule) : base(name)
        {
            SpecializationId = specializationId;
            CanPrescribeMedication = canPrescribeMedication;
            Schedule = schedule ?? throw new ArgumentNullException(nameof(schedule));
        }

        public int SpecializationId { get; set; } //DB: idk how to store
        public bool CanPrescribeMedication { get; set; }
        public Schedule Schedule { get; private set; }
    }
}
