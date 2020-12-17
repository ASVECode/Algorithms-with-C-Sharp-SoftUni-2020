using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Cycles_in_Graph
{
    class Program
    {
        private static Dictionary<string, string> graph = new Dictionary<string, string>();
        static void Main()
        {
            graph = ReadGraph();

            // while()
        }

        private static Dictionary<string, string> ReadGraph()
        {
            Dictionary<string, string> resultGraph = new Dictionary<string, string>();
            var parts = Console.ReadLine().Split(' ');
            while (parts.Length > 1)
            {
                var node = parts[0];
                var child = parts[1];
                graph[node] = child;
                Console.WriteLine(child);
                parts = Console.ReadLine().Split(' ');
            }
            return resultGraph;
        }
    }
}
