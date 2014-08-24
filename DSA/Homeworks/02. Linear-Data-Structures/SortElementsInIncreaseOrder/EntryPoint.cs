namespace SortElementsInIncreaseOrder
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var elementSequence = ReadElements();

            elementSequence.Sort();

            PrintElements(elementSequence);
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
