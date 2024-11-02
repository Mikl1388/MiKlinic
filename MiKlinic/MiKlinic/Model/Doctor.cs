namespace MiKlinic.Model
{
    public class Doctor : User
    {
		public Doctor() {}


		//DRAFT: im not sure doctor
		public Doctor(string name, Speciality speciality, bool canPrescribeMedication) : base(name)
        {
            Speciality = speciality;
            CanPrescribeMedication = canPrescribeMedication;
        }
        public Speciality Speciality { get; set; }
        public int SpecialityId { get; set; }
        public virtual bool CanPrescribeMedication { get; set; }
        public Schedule Schedule { get; private set; }
    }
}
