using System;

namespace _04.Recursive_Factorial
{
    class RecursiveFactorial
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Fact(n));
        }

        private static int Fact(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * Fact(n - 1);
        }
    }
}
