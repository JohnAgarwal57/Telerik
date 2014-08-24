namespace CalcSumAndAvarageOfSequenceOfElements
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var elementSequence = ReadElements();

            var sum = CalcSum(elementSequence);
            Console.WriteLine("The sum of the element is {0}.", sum);
            
            var avarage = sum / elementSequence.Count;
            Console.WriteLine("The avarage of the element is {0}.", avarage);
        }

        private static int CalcSum(List<int> elementSequence)
        {
            var sum = 0;
            foreach (var element in elementSequence)
            {
                sum += element;
            }

            return sum;
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
