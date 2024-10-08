
namespace MiKlinic
{
	public class MedicalInstitution
	{
		//DRAFT: MedicalInstitution draft
		public MedicalInstitution(string institutionInfo)
		{
			InstitutionInfo = institutionInfo ?? throw new ArgumentNullException(nameof(institutionInfo));
		}

		string InstitutionInfo { get; set; }
	}
}
