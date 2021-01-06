using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Differences
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var table = new int[str1.Length + 1, str2.Length + 1];
            for (int r = 1; r < table.GetLength(0); r++)
            {
                table[r, 0] = r;
            }
            for (int c = 1; c < table.GetLength(1); c++)
            {
                table[0, c] = c;
            }
            for (int i = 1; i < table.GetLength(0); i++)
            {
                for (int j = 1; j < table.GetLength(1); j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                    {
                        table[i, j] = table[i - 1, j - 1];
                    }
                    else
                    {
                        table[i, j] = Math.Min(table[i, j - 1], table[i - 1, j]) + 1;
                    }
                }
            }
            Console.WriteLine($"Deletions and Insertions: {table[str1.Length, str2.Length]}");
        }
    }
}
