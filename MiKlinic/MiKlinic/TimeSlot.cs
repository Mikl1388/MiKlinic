namespace MiKlinic
{
	public class TimeSlot
	{
		public DateOnly Date { get; set; }
		public TimeOnly StartTime { get; set; }
		public TimeOnly EndTime { get; set; }
		public bool IsBooked { get; set; }

		public TimeSlot(DateOnly date, TimeOnly startTime, TimeOnly endTime)
		{
			Date = date;
			StartTime = startTime;
			EndTime = endTime;
			IsBooked = false;
		}

		public TimeSlot(DateOnly date, TimeOnly startTime, TimeSpan duration)
		{
			Date = date;
			StartTime = startTime;
			EndTime = TimeOnly.FromTimeSpan(startTime.ToTimeSpan() + duration);
			IsBooked = false;
		}
	}
}
