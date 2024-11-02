using MiKlinic.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miklinic.Tests.Model
{
	public class ScheduleTests
	{
		private readonly Schedule _schedule;

		public ScheduleTests()
		{
			_schedule = new Schedule();
			_schedule.timeSlots.Add(new TimeSlot(new DateOnly(2000, 10, 10), new TimeOnly(15, 00), new TimeOnly(16, 00)));
			_schedule.timeSlots.Add(new TimeSlot(new DateOnly(2000, 10, 10), new TimeOnly(17, 00), new TimeOnly(17, 45)));
			_schedule.timeSlots.Add(new TimeSlot(new DateOnly(2000, 10, 11), new TimeOnly(15, 00), new TimeOnly(16, 00)));
		}

		[Fact]
		public void IsOverlapping_False()
		{
			var newSlot = new TimeSlot(new DateOnly(2000, 10, 20), new TimeOnly(15, 00), new TimeOnly(16, 00)); // Не пересекается ни с одним существующим
			
			var result = _schedule.IsOverlapping(newSlot);

			Assert.False(result);
		}

		[Fact]
		public void IsOverlapping_Partitially()
		{
			var newSlot = new TimeSlot(new DateOnly(2000, 10, 10), new TimeOnly(15, 30), new TimeOnly(16, 30)); // Пересекается с одним из существующих

			var result = _schedule.IsOverlapping(newSlot);

			Assert.True(result);
		}

		[Fact]
		public void IsOverlapping_Contains()
		{
			var newSlot = new TimeSlot(new DateOnly(2000, 10, 10), new TimeOnly(15, 10), new TimeOnly(15, 50)); // Полностью находится внутри другого

			var result = _schedule.IsOverlapping(newSlot);

			Assert.True(result);
		}

		[Fact]
		public void IsOverlapping_Two()
		{
			var newSlot = new TimeSlot(new DateOnly(2000, 10, 10), new TimeOnly(15, 30), new TimeOnly(17, 10)); // Пересекает сразу два других

			var result = _schedule.IsOverlapping(newSlot);

			Assert.True(result);
		}
	}
}
