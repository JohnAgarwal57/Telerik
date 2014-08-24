namespace Queue
{
    using System;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var queue = new Queue<int>();

            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            Print(queue);

            queue.Dequeue();
            Print(queue);

            queue.Enqueue(51);
            queue.Enqueue(61);
            queue.Enqueue(71);
            Print(queue);

            queue.Dequeue();
            Print(queue);
        }

        private static void Print(Queue<int> queue)
        {
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------------------");
        }
    }
}
