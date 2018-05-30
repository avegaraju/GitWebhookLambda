using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using GitWehookLambda.DataStructures;
using GitWehookLambda.Entities.EqualEffort;
using GitWehookLambda.Selection;

using Xunit;

namespace GitWebhookLambdaTests
{
    public class EqualEffortTests
    {
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(10)]
        public void Reviewers_CanBeIteratedCircularly_OverIndicatedNumberOfTimes(int loopCount)
        {
            string[] reviewers = new[]
                                 {
                                     "R1",
                                     "R2",
                                     "R3"
                                 };

            EqualEffort sut = new EqualEffort(reviewers.ToList());

            var counter = 0;

            foreach (Node<Reviewer> reviewer in sut.Reviewers)
            {
                if(counter == loopCount)
                    break;

                counter++;
            }
        }
    }
}
