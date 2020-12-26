using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Power
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"2 powered {i} - {Power(2, i)}");
            }
        }
        private static double Power(int x, int n)
        {
            if (n < 1)
            {
                return 1;
            }
            else
            {
                return x * Power(x, n - 1);
            }
        }
    }
}
