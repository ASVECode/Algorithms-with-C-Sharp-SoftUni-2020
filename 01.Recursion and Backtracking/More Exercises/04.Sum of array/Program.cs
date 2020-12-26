using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sum_of_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4 };
            Console.WriteLine(SumR(array, 3));
        }
        private static int SumR(int[] array, int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else
            {
                return array[n - 1] + SumR(array, n - 1);
            }
        }
    }
}
