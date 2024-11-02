
namespace MiKlinic.Model
{
	public class User
	{
		public User(){}

		public User(string name)
		{
			Name = name ?? throw new ArgumentNullException(nameof(name));
			PasswordHash = "";
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string PasswordHash { get; set; }
	}
}
