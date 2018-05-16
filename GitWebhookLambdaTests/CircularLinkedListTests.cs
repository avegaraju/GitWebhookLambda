using FluentAssertions;

using GitWehookLambda.DataStructures;
using GitWehookLambda.Entities.EqualEffort;

using Xunit;

namespace GitWebhookLambdaTests
{
    public class CircularLinkedListTests
    {
        [Fact]
        public void Add_SetsPreviousNodeToItself()
        {
            var sut = new CircularLinkedList<Reviewer>();
            sut.Add(new Reviewer("R"));
            sut.Head.Value.UserName.Should().Be("R");
        }

        [Fact]
        public void Add_SetsNextNodeToItself()
        {
            var sut = new CircularLinkedList<Reviewer>();
            sut.Add(new Reviewer("R"));
            sut.Head.Value.UserName.Should().Be("R");
        }

        [Fact]
        public void Add_WhenANodeExists_ThenNextOfTailIsTheNewNode()
        {
            var sut = new CircularLinkedList<Reviewer>();
            sut.Add(new Reviewer("R1"));
            sut.Add(new Reviewer("R2"));
            sut.Tail.Next.Value.UserName.Should().Be("R2");
        }

        [Fact]
        public void Add_WhenANodeExists_ThenNextOfNewNodeIsTheHead()
        {
            var sut = new CircularLinkedList<Reviewer>();
            sut.Add(new Reviewer("R1"));
            sut.Add(new Reviewer("R2"));
            sut.NewNode.Next.Should().Be(sut.Head);
        }

        [Fact]
        public void Add_WhenANodeExists_ThenPreviousOfHeadIsTheNewNode()
        {
            var sut = new CircularLinkedList<Reviewer>();
            sut.Add(new Reviewer("R1"));
            sut.Add(new Reviewer("R2"));
            sut.Head.Previous.Should().Be(sut.NewNode);
        }
    }
}
