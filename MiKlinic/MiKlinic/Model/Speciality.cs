namespace MiKlinic.Model
{
	public class Speciality
	{
		public Speciality() { }
		public Speciality(string name)
		{
			Name = name;
		}
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
