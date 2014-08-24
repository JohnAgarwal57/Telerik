namespace Queue
{
    using System;
    using System.Collections.Generic;

    public class Queue<T> : System.Collections.Generic.IEnumerable<T>
    {
        private LinkedList<T> items = new LinkedList<T>();

        public void Enqueue(T element) {
            this.items.AddLast(element);
        }

        public void Dequeue()
        {
            this.items.RemoveFirst();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            var node = this.items.First;
            for (int i = 0; i < this.items.Count; i++)
            {

                if (!EqualityComparer<T>.Default.Equals(node.Value, default(T)))
                {
                    yield return node.Value;
                }

                var newNode = node.Next;
                node = newNode;
            }
        }

    }
}
