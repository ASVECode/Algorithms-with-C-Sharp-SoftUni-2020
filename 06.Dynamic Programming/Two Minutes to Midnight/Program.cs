using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Minutes_to_Midnight
{
    class Program
    {
        private static Dictionary<string, long> cache = new Dictionary<string, long>();
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            cache = new Dictionary<string, long>();
            var ways = GetBinom(n, k);
            Console.WriteLine(ways);
        }

        private static long GetBinom(int n, int k)
        {
            var id = $"{n} {k}";
            if (cache.ContainsKey(id))
            {
                return cache[id];
            }
            if (k == 0 || k == n)
            {
                return 1;
            }
            var result = GetBinom(n - 1, k) + GetBinom(n - 1, k - 1);
            cache[id] = result;
            return result;

        }
    }
}
