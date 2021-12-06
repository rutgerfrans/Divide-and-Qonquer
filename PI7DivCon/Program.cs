using System;
using System.Collections.Generic;

namespace PI7DivCon
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> unsorted = new List<int>() { 67, 54, 28, 4, 84, 6, 53, 18, 76, 98, 32, 15};
            string Lijst = Print(unsorted);
            Console.WriteLine("Ongesorteerde Lijst:\n" + Lijst + "\n");

            List<int> sorted = MergeSort(unsorted);
            Lijst = Print(sorted);
            Console.WriteLine("Gesorteerde Lijst:\n" + Lijst + "\n");
        }

        private static string Print(List<int> List)
        {
            string ListText = "";
            foreach (var item in List)
            {
                ListText += item + " ";
            }
            return ListText;
        }

        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
            {
                return unsorted;
            }

            List<int> Left = new List<int>();
            List<int> Right = new List<int>();

            int mid = unsorted.Count / 2;

            for (int i = 0; i < mid; i++)
            {
                Left.Add(unsorted[i]);
            }
            for (int i = mid; i < unsorted.Count; i++)
            {
                Right.Add(unsorted[i]);
            }

            Left = MergeSort(Left);
            Right = MergeSort(Right);

            return Merge(Left, Right);
        }

        private static List<int> Merge(List<int> Left, List<int> Right)
        {
            List<int> sorted = new List<int>();

            while (Left.Count > 0 || Right.Count > 0)
            {
                if (Left.Count > 0  & Right.Count > 0)
                {
                    if (Left[0] > Right[0])
                    {
                        sorted.Add(Right[0]);
                        Right.RemoveAt(0);
                    }
                    else
                    {
                        sorted.Add(Left[0]);
                        Left.RemoveAt(0);
                    }
                }
                else if (Left.Count == 0)
                {
                    sorted.Add(Right[0]);
                    Right.RemoveAt(0);
                }
                else if (Right.Count == 0)
                {
                    sorted.Add(Left[0]);
                    Left.RemoveAt(0);
                }
                Console.WriteLine(Print(sorted));
            }
            return sorted;
        }
    }
}
