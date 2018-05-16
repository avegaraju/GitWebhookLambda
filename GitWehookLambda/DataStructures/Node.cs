namespace GitWehookLambda.DataStructures
{
    public class Node<T>
    {
        public T Value { get; private set; }
        public Node<T> Next { get; internal set; }
        public Node<T> Previous { get; internal set; }


        public Node(T value)
        {
            Value = value;
        }
    }
}
