using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using GitWehookLambda.Entities.EqualEffort;
using GitWehookLambda.Selection;

using Xunit;

namespace GitWebhookLambdaTests
{
    public class EqualEffortTests
    {
        [Fact]
        public void Ctor_Builds_Reviewer_Instances_PerReviewerUserName()
        {
            string[] reviewers = new[]
                                 {
                                     "R1",
                                     "R2",
                                     "R3"
                                 };

            EqualEffort sut = new EqualEffort(reviewers.ToList());

            sut.Reviewers.Count.Should().Be(reviewers.Length);
            sut.Reviewers.Should().BeOfType<List<Reviewer>>();
            foreach (string reviewer in reviewers)
            {
                sut.Reviewers.Should().Contain(r => r.UserName.Equals(reviewer));
            }
        }
    }
}
