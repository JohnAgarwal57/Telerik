namespace Stack
{
    using System;
    using System.Collections.Generic;

    public class Stack<T> : System.Collections.Generic.IEnumerable<T>
    {
        private T[] items = new T[1];
        private int count = 0;

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public T[] Items
        {
            get
            {
                return this.items;
            }
        }

        public void Push(T element)
        {
            if (this.count == this.items.Length)
            {
                this.items = this.ResizeArray(this.items, this.count * 2);
            }

            this.items[this.count] = element;
            this.count++;
        }

        public void Pop()
        {
            if (this.count >= 0)
            {
                this.count--; 
                this.items[this.count] = default(T);           
            }
        }

        public T Peek()
        {
            return this.items[this.count - 1];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            var count = 0;
            var node = this.items[count];
            while (count < this.items.Length)
            {
                if (!EqualityComparer<T>.Default.Equals(this.items[count], default(T)))
                {
                    yield return this.items[count];
                }

                count++;
            }
        }

        private T[] ResizeArray(T[] oldArray, int newSize)
        {
            var newArray = new T[newSize];

            for (int i = 0; i < oldArray.Length; i++)
            {
                newArray[i] = oldArray[i];
            }

            return newArray;
        }
    }
}
