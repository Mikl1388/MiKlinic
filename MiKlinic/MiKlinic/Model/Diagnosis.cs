using System.ComponentModel.DataAnnotations;

namespace MiKlinic.Model
{
    public class Diagnosis
    {
        //DRAFT: draft of diagnosis
        public Diagnosis(string iCDId, string description)
        {
            ICDId = iCDId;
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        [Key]
        public string ICDId { get; set; }
        public string Description { get; set; }
    }
}
