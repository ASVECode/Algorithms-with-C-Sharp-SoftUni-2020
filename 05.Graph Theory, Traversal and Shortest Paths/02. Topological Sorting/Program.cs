using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Topological_Sorting
{
    class Program
    {
        public static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        public static Dictionary<string, int> dependencies = new Dictionary<string, int>();
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);

            //graph = new Dictionary<string, List<string>>()
            //{
            //    { "A", new List<string>() { "B", "C" } },
            //    { "B", new List<string>() { "D", "E" } },
            //    { "C", new List<string>() { "F" } },
            //    { "D", new List<string>() { "C", "F" } },
            //    { "E", new List<string>() { "D" } },
            //    { "F", new List<string>() { } }
            //};
            dependencies = ExtractDependences();
            var sorted = TopologicalSorting();

            if (sorted == null)
            {
                Console.WriteLine("Invalid topological sorting");
            }
            else
            {
                Console.WriteLine($"Topological sorting: { string.Join(", ", sorted)}");
            }

        }

        public static List<string> TopologicalSorting()
        {
            var sorted = new List<string>();

            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies.FirstOrDefault(n => n.Value == 0);

                if (string.IsNullOrEmpty(nodeToRemove.Key))
                {
                    break;
                }
                var node = nodeToRemove.Key;
                var children = graph[node];

                sorted.Add(node);
                foreach (var child in children)
                {
                    dependencies[child]--;
                }
                dependencies.Remove(nodeToRemove.Key);
            }
            if (dependencies.Count > 0)
            {
                return null;
            }
            return sorted;
        }

        public static Dictionary<string, int> ExtractDependences()
        {
            var result = new Dictionary<string, int>();
            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;

                if (!result.ContainsKey(node))
                {
                    result.Add(node, 0);
                }

                foreach (var child in children)
                {
                    if (!result.ContainsKey(child))
                    {
                        result.Add(child, 1);
                    }
                    else
                    {
                        result[child]++;
                    }
                }
            }

            return result;
        }

        public static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var graphResult = new Dictionary<string, List<string>>();
            string[] separatingString = { "->" };
            string[] separatingString1 = { ", " };


            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine()
                    .Split(separatingString, StringSplitOptions.RemoveEmptyEntries);
                var key = parts[0].Trim();
                if (parts.Length == 1)
                {
                    graphResult[key] = new List<string>();
                }
                else
                {
                    var children = parts[1]
                        .Trim()
                        .Split(separatingString1, StringSplitOptions.None)
                        .ToList();
                    graphResult[key] = children;
                }

            }
            return graphResult;
        }
    }
}