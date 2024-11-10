namespace MiKlinic.Model
{

	/// <summary>
	/// Реализация интерфейса уведомлений
	/// </summary>
	public class NotificationMediator : INotificationMediator
	{
		private readonly List<User> _users;

		public NotificationMediator()
		{
			_users = new List<User>();
		}

		public void AddUser(User user)
		{
			_users.Add(user);
		}

		public void RemoveUser(User user)
		{
			_users.Remove(user);
		}

		/// <summary>
		/// Отправляет уведомление всем зарегистрированным пользователям
		/// </summary>
		/// <param name="sender">Отправитель уведомления</param>
		/// <param name="message">Сообщение</param>
		public void NotifyAll(User sender, string message)
		{
			foreach (var user in _users)
			{
				user.Notify(sender, message);
			}
		}

		/// <summary>
		/// Отправляет уведомление пользователю
		/// </summary>
		/// <param name="sender">Отправитель уведомления</param>
		/// <param name="recipient">Сообщение</param>
		/// <param name="message">Получатель уведомления</param>
		public void SendNotification(User sender, User recipient, string message)
		{
			recipient.Notify(sender, message);
		}
	}
}
