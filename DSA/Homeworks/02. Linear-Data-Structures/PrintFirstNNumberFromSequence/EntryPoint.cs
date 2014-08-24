namespace PrintFirstFiftyNumberFromSequence
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            const int MaxCount = 50;
            var number = int.Parse(Console.ReadLine());

            GetFirstFiftyNumbers(number, MaxCount);
        }

        private static void GetFirstFiftyNumbers(int number, int maxCount)
        {
            var firstFiftyNumbers = new Queue<int>();

            firstFiftyNumbers.Enqueue(number);

            for (int i = 0; i < maxCount; i++)
            {
                int current = firstFiftyNumbers.Dequeue();
                var currentIndex = i + 1;
                Console.WriteLine("№" + currentIndex + ":" + current);

                firstFiftyNumbers.Enqueue(current + 1);
                firstFiftyNumbers.Enqueue(2 * current + 1);
                firstFiftyNumbers.Enqueue(current + 2);
            }
        }
    }
}
