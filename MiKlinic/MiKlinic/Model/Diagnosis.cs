namespace MiKlinic.Model
{
    public class Diagnosis
    {
        //DRAFT: draft of diagnosis
        public Diagnosis(int iCDId, string description)
        {
            ICDId = iCDId;
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public int ICDId { get; set; }
        public string Description { get; set; }
    }
}
