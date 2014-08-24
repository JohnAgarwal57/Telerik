namespace LinkedList
{
    public class LinkedList<T> : System.Collections.Generic.IEnumerable<T>
    {
        private ListItem<T> Head { get; set; }

        private ListItem<T> Tail { get; set; }

        public void AddLast(T value)
        {
            var newNode = new ListItem<T>()
            {
                Value = value
            };

            if (this.Head == null && this.Tail == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                this.Tail.NextItem = newNode;
                newNode.PreviousItem = this.Tail;
                this.Tail = newNode;
            }
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            var node = this.Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.NextItem;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
