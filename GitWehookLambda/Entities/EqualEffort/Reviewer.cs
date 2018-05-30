using System.Collections.Generic;

namespace GitWehookLambda.Entities.EqualEffort
{
    public class Reviewer
    {
        public string UserName { get; }
        public List<ReviewPeriod> ReviewPeriods { get; }

        public Reviewer(string userName)
        {
            UserName = userName;
        }

        public void Add(ReviewPeriod reviewPeriod)
        {
            throw new System.NotImplementedException();
        }
    }
}
