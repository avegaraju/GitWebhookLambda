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
            var sut = new CircularLinkedList<Reviewer>
                      {
                          new Reviewer("R")
                      };
            sut.Head.Should().Be(sut.Tail);
        }

        [Fact]
        public void Add_SetsNextOfHeadToTail()
        {
            var sut = new CircularLinkedList<Reviewer>
                      {
                          new Reviewer("R")
                      };
            sut.Head.Next.Should().Be(sut.Tail);
        }

        [Fact]
        public void Add_SetsPreviousOfHeadToTail()
        {
            var sut = new CircularLinkedList<Reviewer>
                      {
                          new Reviewer("R")
                      };
            sut.Head.Previous.Should().Be(sut.Tail);
        }

        [Fact]
        public void Add_WhenANodeExists_ThenNextOfTailIsTheHead()
        {
            var sut = new CircularLinkedList<Reviewer>
                      {
                          new Reviewer("R1"),
                          new Reviewer("R2")
                      };
            sut.Tail.Next.Should().Be(sut.Head);
        }

        [Fact]
        public void Add_WhenANodeExists_ThenPreviousOfTailIsTheFirstAndHeadNode()
        {
            var sut = new CircularLinkedList<Reviewer>
                      {
                          new Reviewer("R1"),
                          new Reviewer("R2")
                      };
            sut.Tail.Previous.Value.Should().Be(sut.Head.Value);
            sut.Head.Value.UserName.Should().Be("R1");

        }

        [Fact]
        public void Add_WhenANodeExists_ThenNextOfNewNodeIsTheHead()
        {
            var sut = new CircularLinkedList<Reviewer>
                      {
                          new Reviewer("R1"),
                          new Reviewer("R2")
                      };
            sut.NewNode.Next.Should().Be(sut.Head);
        }

        [Fact]
        public void Add_WhenANodeExists_ThenPreviousOfHeadIsTheNewNode()
        {
            var sut = new CircularLinkedList<Reviewer>
                      {
                          new Reviewer("R1"),
                          new Reviewer("R2")
                      };
            sut.Head.Previous.Should().Be(sut.NewNode);
        }

        [Fact]
        public void GetEnumerator_ReturnsTheInstanceOfCircularLinkedList()
        {
            var sut = new CircularLinkedList<Reviewer>();

            sut.GetEnumerator().Should().Be(sut);
        }

        [Fact]
        public void Current_PointsAtTheHeadOfTheCircularLinkedList()
        {
            var sut = new CircularLinkedList<Reviewer>
            {
                new Reviewer("R1"),
                new Reviewer("R2")
            };

            sut.Current.Should().Be(sut.Head);
        }

        [Fact]
        public void MoveNext_ShouldLoopEndlessly_HenceShouldAlwaysReturnTrue()
        {
            var sut = new CircularLinkedList<Reviewer>
                      {
                          new Reviewer("R1"),
                          new Reviewer("R2")
                      };

            sut.MoveNext().Should().Be(true);
        }

        [Fact]
        public void MoveNext_MovesTheCurrentToNextNode()
        {
            var sut = new CircularLinkedList<Reviewer>
                      {
                          new Reviewer("R1"),
                          new Reviewer("R2"),
                          new Reviewer("R3"),
                      };

            var current = sut.Current;

            sut.MoveNext();

            sut.Current.Should().Be(current.Next);
        }

        [Fact]
        public void Reset_SetsCurrentToTheHead()
        {
            var sut = new CircularLinkedList<Reviewer>
                      {
                          new Reviewer("R1"),
                          new Reviewer("R2"),
                          new Reviewer("R3"),
                      };
            int counter = 0;
            Node<Reviewer> currentNode = null;
            foreach (Node<Reviewer> node in sut)
            {
                if(counter == 2)
                    break;
                currentNode = node;
                counter++;
            }

            currentNode.Should().NotBe(sut.Head);

            sut.Reset();
            
            sut.Head.Should().Be(sut.Current);
        }

        [Fact]
        public void Dispose_SetsAllNodesToNull()
        {
            var sut = new CircularLinkedList<Reviewer>
                      {
                          new Reviewer("R1"),
                          new Reviewer("R2"),
                          new Reviewer("R3"),
                      };

            sut.Dispose();

            sut.Current.Should().BeNull();
            sut.Head.Should().BeNull();
            sut.Tail.Should().BeNull();
        }
    }
}
