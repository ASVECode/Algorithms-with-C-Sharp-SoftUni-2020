using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Permutations
{
    class Program
    {
        private static string[] permutation;
        private static string[] input;
        private static bool[] used;

        static void Main()
        {
            input = Console.ReadLine().Split(' ');
            int length = input.Length;
            permutation = new string[length];
            used = new bool[length];
            Permute(0);
        }
        private static void Permute(int index)
        {
            if (index >= input.Length)
            {
                Console.WriteLine(string.Join(" ", permutation));
                return;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutation[index] = input[i];
                    Permute(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
