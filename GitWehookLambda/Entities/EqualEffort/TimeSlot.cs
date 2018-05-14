using NodaTime;

namespace GitWehookLambda.Entities.EqualEffort
{
    public class TimeSlot
    {
        public LocalDateTime StartTime { get; }
        public LocalDateTime EndTime { get; set; }
    }
}
