using System;
using System.Collections.Generic;
using System.IO;

using GitWehookLambda.Entities.EqualEffort;

namespace GitWehookLambda.Selection
{
    public class EqualEffort: ISelector
    {
        private readonly List<Reviewer> _reviewers = new List<Reviewer>();
        public IReadOnlyList<Reviewer> Reviewers => _reviewers;

        public EqualEffort(List<string> reviewers)
        {
            BuildReviewers(reviewers);
        }

        public string Select()
        {
            return string.Empty;
        }

        private void BuildReviewers(List<string> reviewers)
        {
            foreach (string reviewer in reviewers)
            {
                _reviewers.Add(new Reviewer(reviewer));
            }
        }
    }
}
