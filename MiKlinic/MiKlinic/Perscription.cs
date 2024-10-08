namespace MiKlinic
{
	public class Perscription
	{
		
		public Perscription(int regionCode, MedicalInstitution institution, Doctor prescribingDoctor, Patient patient, DateTime issueDate, DateTime expirationDate, string perscriptionInf, bool isUrgent, string? privilegeInfo, string otherInfo)
		{
			RegionCode = regionCode;
			Institution = institution ?? throw new ArgumentNullException(nameof(institution));
			PrescribingDoctor = prescribingDoctor ?? throw new ArgumentNullException(nameof(prescribingDoctor));
			Patient = patient ?? throw new ArgumentNullException(nameof(patient));
			IssueDate = issueDate;
			ExpirationDate = expirationDate;
			PerscriptionInf = perscriptionInf ?? throw new ArgumentNullException(nameof(perscriptionInf));
			IsUrgent = isUrgent;
			PrivilegeInfo = privilegeInfo;
			OtherInfo = otherInfo;
		}

		public int RegionCode { get; set; }
		public MedicalInstitution Institution { get; set; }
		public Doctor PrescribingDoctor 
		{
			get
			{
				return prescribingDoctor;
			} 
			set 
			{
				if (!value.CanPrescribeMedication)
				{
					throw new UnauthorizedAccessException("Doctor hasn't got permission to perscribe");
				}
				else
				{
					prescribingDoctor = value;
				}
			}
		}
		public Patient Patient { get; set; }
		public DateTime IssueDate { get; set; }
		public DateTime ExpirationDate { get; set; }
		public string PerscriptionInf { get; set; }
		public bool IsUrgent { get; set; }
		public string? PrivilegeInfo { get; set; }
		public string? OtherInfo { get; set; }


		private Doctor prescribingDoctor;
	}
}
