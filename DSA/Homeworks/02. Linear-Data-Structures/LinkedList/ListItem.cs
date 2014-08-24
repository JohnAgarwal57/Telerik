namespace LinkedList
{
    public class ListItem<T>
    {
        public T Value { get; set; }

        public ListItem<T> NextItem { get; set; }

        public ListItem<T> PreviousItem { get; set; }
    }
}
