using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Two_minutes_to_Midnight
{
    class Program
    {
        private static Dictionary<string, long> cache = new Dictionary<string, long>();
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            var ways = GetBinom(n, k);
        }

        private static long GetBinom(int n, int k)
        {
            var id = $"{n} {k}";
            if (cache.ContainsKey(id))
            {
                return cache[id];
            }
            if(n==0 || k == 0)
            {
                return 1;
            }

        }
    }
}
