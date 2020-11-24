using System;

namespace _03.Generating_Vectors
{
    class GeneratingVectors
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Generate(new int[n], 0);
        }

        private static void Generate(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }
            for (int number = 0; number <= 1; number++)
            {
                vector[index] = number;
                Generate(vector, index + 1);
            }
        }
    }
}
