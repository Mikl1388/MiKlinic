
namespace MiKlinic.Model
{
	public class Laboratory
	{
		public Laboratory(string name)
		{
			Name = name ?? throw new ArgumentNullException(nameof(name));
		}

		public string Name { get; set; }
	}
}
