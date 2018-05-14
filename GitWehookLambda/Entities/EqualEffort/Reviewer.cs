namespace GitWehookLambda.Entities.EqualEffort
{
    public class Reviewer
    {
        public string UserName { get; }
        public TimeSlot ReviewTimeSlot { get; }
        public ReviewDays ReviewDays { get; }

        public Reviewer(string userName)
        {
            UserName = userName;
        }
    }
}
