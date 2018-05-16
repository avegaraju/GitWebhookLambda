namespace GitWehookLambda.DataStructures
{
    public class CircularLinkedList<T>
    {
        public Node<T> NewNode { get; private set; }
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        public void Add(T value)
        {
            if(Head == null)
                this.Head = this.Tail = new Node<T>(value);

            else
            {
                NewNode = new Node<T>(value);
                Tail.Next = NewNode;
                NewNode.Next = Head;
                Head.Previous = NewNode;
            }
        }
    }
}
