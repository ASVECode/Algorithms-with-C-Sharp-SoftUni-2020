using System;

namespace Minimum_Edit_Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            var replaceCost = int.Parse(Console.ReadLine());
            var insertCost = int.Parse(Console.ReadLine());
            var deleteCost = int.Parse(Console.ReadLine());
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var table = new int[str1.Length + 1, str2.Length + 1];

            for (int row = 1; row < table.GetLength(0); row++)
            {
                table[row, 0] = row * deleteCost;
            }

            for (int col = 1; col < table.GetLength(1); col++)
            {
                table[0, col] = col * insertCost;
            }

            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    var cost = str1[row - 1] == str2[col - 1] ? 0 : replaceCost;

                    var delete = table[row - 1, col] + deleteCost;
                    var replace = table[row - 1, col - 1] + cost;
                    var insert = table[row, col - 1] + insertCost;

                    table[row, col] = Math.Min(Math.Min(delete, insert), replace);
                }
            }

            var result = table[str1.Length, str2.Length];
            Console.WriteLine($"Minimum edit distance: {result}");
        }

    }
}
