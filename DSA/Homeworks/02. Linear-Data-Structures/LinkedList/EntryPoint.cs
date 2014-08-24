namespace LinkedList
{
    using System;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();

            linkedList.AddLast(5);
            linkedList.AddLast(4);
            linkedList.AddLast(3);

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
