namespace RemovesAllNegativeElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var elementSequence = ReadElements();

            var positive = elementSequence.Where(i => i >= 0).ToList();

            PrintElements(positive);
        }

        private static void PrintElements(List<int> elementSequence)
        {
            foreach (var element in elementSequence)
            {
                Console.WriteLine(element);
            }
        }

        private static List<int> ReadElements()
        {
            var elementSequence = new List<int>();
            string element;

            do
            {
                element = Console.ReadLine();
                if (element != string.Empty)
                {
                    elementSequence.Add(int.Parse(element));
                }
            }
            while (element != string.Empty);

            return elementSequence;
        }
    }
}
