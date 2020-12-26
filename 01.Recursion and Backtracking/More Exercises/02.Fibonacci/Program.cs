using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 7; i++)
            {
                // Console.WriteLine($" Fibonacci {i} - {Fibonacci(i)}");
               // Console.WriteLine(FibonacciRec(i, 0, 1));
                Console.WriteLine(FibonacciWrapper(i));

            }
        }
        //direct,multiple recursion
        private static long Fibonacci(int n)
        {
            if (n < 2)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
        //tail abd linear recursion
        private static long FibonacciRec(int n, long f1, long f2)
        {
            if (n == 0)
            {
                return f1;
            }
            else
            {
                return FibonacciRec(n - 1, f2, f1 + f2);
            }
        }

        //Wrapper if recursive function
        //hide the additional parameters
        private static long FibonacciWrapper(int n)
        {
            return FibonacciRec(n, 0, 1);
        }
    }
}
