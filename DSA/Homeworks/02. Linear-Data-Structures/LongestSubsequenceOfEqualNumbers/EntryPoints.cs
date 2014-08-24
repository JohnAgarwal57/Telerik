namespace LongestSubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;

    public class EntryPoints
    {
        public static void Main(string[] args)
        {
            var elementSequence = ReadElements();

            var longestSubsequenceOfEqualElements = FindLongestSubsequenceOfEqualElements(elementSequence);

            PrintElements(longestSubsequenceOfEqualElements);
        }

        private static List<int> FindLongestSubsequenceOfEqualElements(List<int> elementSequence)
        {            
            var count = 1;
            var maxcount = 0;
            var mostFrequent = elementSequence[0];

            for (int i = 1; i < elementSequence.Count; i++)
            {
                if (elementSequence[i - 1] == elementSequence[i])
                {
                    count++;              
                }
                else 
                {
                    if (count > maxcount) 
                    {
                        maxcount = count;
                        mostFrequent = elementSequence[i - 1]; 
                    }

                    count = 1;
                }
            }

            if (count > maxcount) 
            {
                maxcount = count;
                mostFrequent = elementSequence[elementSequence.Count - 1];
            }

            var longestSubsequenceOfEqualElements = new List<int>();

            for (int i = 0; i < maxcount; i++)
            {
                longestSubsequenceOfEqualElements.Add(mostFrequent);
            }

            return longestSubsequenceOfEqualElements;
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
