using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Topological_Sorting
{
    class Program
    {
        private static string[] stringSeparator1 = new string[] { " -> " };
        private static string[] stringSeparator = new string[] { ", " };

        private static Dictionary<string, List<string>> graph;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var dependencies = new Dictionary<string, int>();

            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;

                foreach (var child in children)
                {
                    if (!dependencies.ContainsKey(child))
                    {
                        dependencies.Add(child, 1);
                    }
                    else
                    {
                        dependencies[child]++;
                    }
                }
            }
        }
    }
}
