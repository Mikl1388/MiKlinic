namespace MiKlinic.Model
{
    public class MedicalInstitution
    {
        //DRAFT: MedicalInstitution draft
        
        public MedicalInstitution() { }

        public MedicalInstitution(string institutionInfo)
        {
            InstitutionInfo = institutionInfo ?? throw new ArgumentNullException(nameof(institutionInfo));
        }
        public int Id { get; set; }
        string InstitutionInfo { get; set; }
    }
}
