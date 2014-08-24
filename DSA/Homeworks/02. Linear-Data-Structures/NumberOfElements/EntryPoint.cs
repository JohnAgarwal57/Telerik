namespace NumberOfElements
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var elementNumbers = new Dictionary<int, int>();

            var elementSequence = ReadElements();

            elementNumbers = CountElements(elementSequence);

            PrintElements(elementNumbers);
        }

        private static void PrintElements(Dictionary<int, int> elementSequence)
        {
            foreach (var element in elementSequence)
            {
                Console.WriteLine(element);
            }
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
