namespace MiKlinic.Model
{
	/// <summary>
	/// Интерфейс для обмена информацией между пользователями
	/// </summary>
	public interface INotificationMediator
	{
		void SendNotification(User sender, User recipient, string message);
	}
}
