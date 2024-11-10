
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


		/// <summary>
		/// Функция получения уведомления
		/// </summary>
		/// <param name="sender">Отправитель уведомления</param>
		/// <param name="message">Сообщение</param>
		public void Notify(User sender, string message)
		{
			Console.WriteLine($"Уведомление от {sender.Name}: {message}");
		}
	}
}
