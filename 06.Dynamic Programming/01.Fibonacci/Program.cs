using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Fibonacci
{
    class Program
    {
        private static Dictionary<int, long> memo = new Dictionary<int, long>();
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            memo = new Dictionary<int, long>();
            Console.WriteLine(Fib(n));
        }

        private static long Fib(int n)
        {
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }
            if (n == 1 || n == 2)
            {
                return 1;
            }
            long result = Fib(n - 1) + Fib(n - 2);
            memo.Add(n, result);
            return result;
        }
    }
}
