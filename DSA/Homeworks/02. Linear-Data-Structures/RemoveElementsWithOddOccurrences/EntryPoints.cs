namespace RemoveElementsWithOddOccurrences
{
    using System;
    using System.Collections.Generic;

    public class EntryPoints
    {
        public static void Main(string[] args)
        {
            var elementSequence = ReadElements();

            var elementNumbers = new Dictionary<int, int>();
            elementNumbers = CountElements(elementSequence);

            foreach (var element in elementNumbers)
            {
                if (element.Value % 2 == 1)
                {
                    elementSequence.RemoveAll(item => item == element.Key);
                }
            }

            PrintElements(elementSequence);
        }

        private static Dictionary<int, int> CountElements(List<int> elementSequence)
        {
            var elementNumbers = new Dictionary<int, int>();

            foreach (var element in elementSequence)
            {
                if (elementNumbers.ContainsKey(element))
                {
                    elementNumbers[element]++;
                }
                else
                {
                    elementNumbers[element] = 1;
                }
            }

            return elementNumbers;
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
