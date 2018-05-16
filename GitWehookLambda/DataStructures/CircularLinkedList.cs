namespace GitWehookLambda.DataStructures
{
    public class CircularLinkedList<T>
    {
        public Node<T> NewNode { get; private set; }
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

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
    }
}
