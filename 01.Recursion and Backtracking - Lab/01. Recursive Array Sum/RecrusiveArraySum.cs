using System;
using System.Linq;

namespace _01.Recursive_Array_Sum
{
    class RecursiveArraySum
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            Console.WriteLine(GetSum(array, 0));
        }
        private static int GetSum(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            return arr[index] + GetSum(arr, index + 1);
        }
        
    }
}
