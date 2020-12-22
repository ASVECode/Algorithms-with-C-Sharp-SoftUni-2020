using System;
using System.Collections.Generic;

namespace _03.Cycles_in_Graph
{
    class Program
    {
        private static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private static HashSet<string> visited = new HashSet<string>();
        private static HashSet<string> cycles = new HashSet<string>();

        static void Main()
        {
            graph = ReadGraph();
            foreach (var node in graph.Keys)
            {
                try
                {
                    DFS(node);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Acyclic: No");
                    return;
                }
            }
            Console.WriteLine("Acyclic: Yes");
        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException();
            }
            if (visited.Contains(node))
            {
                return;
            }
            cycles.Add(node);
            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycles.Remove(node);
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            Dictionary<string, List<string>> resultGraph = new Dictionary<string, List<string>>();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
                var parts = line.Split('-');
                var node = parts[0];
                var child = parts[1];
                if (!resultGraph.ContainsKey(node))
                {
                    resultGraph.Add(node, new List<string>());
                }
                if (!resultGraph.ContainsKey(child))
                {
                    resultGraph.Add(child, new List<string>());
                }
                resultGraph[node].Add(child);
            }
            return resultGraph;
        }
    }
}
