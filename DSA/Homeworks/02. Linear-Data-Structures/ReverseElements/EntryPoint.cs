namespace ReverseElements
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var elementSequence = ReadElements();

            PrintElements(elementSequence);
        }

        private static Stack<int> ReadElements()
        {
            var elementSequence = new Stack<int>();
            string element;

            do
            {
                element = Console.ReadLine();
                if (element != string.Empty)
                {
                    elementSequence.Push(int.Parse(element));
                }
            }
            while (element != string.Empty);

            return elementSequence;
        }

        private static void PrintElements(Stack<int> elementSequence)
        {
            while (elementSequence.Count > 0)
            {
                int element = elementSequence.Pop();
                Console.WriteLine(element);
            }
        }
    }
}
