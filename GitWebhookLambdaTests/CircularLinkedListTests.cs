using FluentAssertions;

using GitWehookLambda.DataStructures;
using GitWehookLambda.Entities.EqualEffort;

using Xunit;

namespace GitWebhookLambdaTests
{
    public class CircularLinkedListTests
    {

        [Fact]
        public void Add_SetsHeadAndTailToNewNode()
        {
            var sut = new CircularLinkedList<Reviewer>();
            sut.Add(new Reviewer("R"));
            sut.Head.Should().Be(sut.Tail);
        }

        [Fact]
        public void Add_SetsNextOfHeadToTail()
        {
            var sut = new CircularLinkedList<Reviewer>();
            sut.Add(new Reviewer("R"));
            sut.Head.Next.Should().Be(sut.Tail);
        }

        [Fact]
        public void Add_SetsPreviousOfHeadToTail()
        {
            var sut = new CircularLinkedList<Reviewer>();
            sut.Add(new Reviewer("R"));
            sut.Head.Previous.Should().Be(sut.Tail);
        }

        [Fact]
        public void Add_WhenANodeExists_ThenNextOfTailIsTheHead()
        {
            var sut = new CircularLinkedList<Reviewer>();
            sut.Add(new Reviewer("R1"));
            sut.Add(new Reviewer("R2"));
            sut.Tail.Next.Should().Be(sut.Head);
        }

        [Fact]
        public void Add_WhenANodeExists_ThenPreviousOfTailIsTheFirstAndHeadNode()
        {
            var sut = new CircularLinkedList<Reviewer>();
            sut.Add(new Reviewer("R1"));
            sut.Add(new Reviewer("R2"));
            sut.Tail.Previous.Value.Should().Be(sut.Head.Value);
            sut.Head.Value.UserName.Should().Be("R1");

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
