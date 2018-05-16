using NodaTime;

namespace GitWehookLambda.Entities.EqualEffort
{
    public class ReviewPeriod
    {
        public IsoDayOfWeek DayOfWeek { get; set; }
        public LocalTime StartTime { get; set; }
        public LocalTime EndTime { get; set; }
    }
}
