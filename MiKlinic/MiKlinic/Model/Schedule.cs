namespace MiKlinic.Model
{
    public class Schedule
    {
        //DRAFT: schedule draft
        private List<TimeSlot> timeSlots;

        public Schedule()
        {
            timeSlots = new List<TimeSlot>();
        }

        // Method to add a new time slot
        public void AddTimeSlot(TimeSlot slot)
        {
            if (!IsOverlapping(slot))
            {
                timeSlots.Add(slot);
            }
            else
            {
                throw new InvalidOperationException("Time slot overlaps with an existing one.");
            }
        }

        // Check if a time slot is available
        public List<TimeSlot> GetAvailableTimeSlots(DateOnly date)
        {
            return timeSlots.Where(s => s.Date == date && !s.IsBooked).ToList();
        }

        // SUS: mb i dont need this method
        public void BookTimeSlot(DateOnly date, TimeOnly startTime)
        {
            var slot = timeSlots.FirstOrDefault(s => s.Date == date && s.StartTime >= startTime && !s.IsBooked);
            if (slot != null)
            {
                slot.IsBooked = true;
            }
            else
            {
                throw new InvalidOperationException("Time slot not available or already booked.");
            }
        }

        public void BookTimeSlot(int id)
        {
            try
            {
                if (!timeSlots[id].IsBooked)
                {
                    timeSlots[id].IsBooked = true;
                }
                else
                {
                    throw new InvalidOperationException("Time slot already booked.");
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new InvalidOperationException("Time slot doesn't exist.");
            }
        }

        // Check if a new time slot overlaps with existing ones
        private bool IsOverlapping(TimeSlot newSlot)
        {
            return timeSlots.Any(s => s.Date == newSlot.Date &&
                                      (newSlot.StartTime >= s.StartTime && newSlot.StartTime < s.EndTime ||
                                      newSlot.EndTime > s.StartTime && newSlot.EndTime <= s.EndTime));
        }
    }
}
