
namespace MiKlinic.Model
{
	public class Laboratory
	{
		public Laboratory(string name)
		{
			Name = name ?? throw new ArgumentNullException(nameof(name));
		}
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
