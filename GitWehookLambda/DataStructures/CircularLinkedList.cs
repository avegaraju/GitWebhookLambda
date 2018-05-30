using System.Collections;
using System.Collections.Generic;

namespace GitWehookLambda.DataStructures
{
    public class CircularLinkedList<T>: IEnumerable<Node<T>>, IEnumerator<Node<T>>
    {
        private Node<T> _current;

        public Node<T> NewNode { get; private set; }
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        object IEnumerator.Current => Current;

        public void Add(T value)
        {
            if (Head == null)
                AddFirstNode(value);

            else
            {
                NewNode = new Node<T>(value);
                Tail.Next = NewNode;
                NewNode.Next = Head;
                NewNode.Previous = Tail;
                Tail = NewNode;
                Head.Previous = Tail;
            }
        }

        private void AddFirstNode(T value)
        {
            this.Head = this.Tail = new Node<T>(value);
            this.Head.Next = Tail;
            this.Head.Previous = Tail;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            Current = Current.Next;

            return true;
        }

        public void Reset()
        {
            Current = Head;
        }

        public Node<T> Current
        {
            get => _current ?? (_current = Head);

            set => _current = value;
        }

        public void Dispose()
        {
            Current = Head = Tail = null;
        }
    }
}
