using System;
using System.Collections.Generic;

namespace DFS_and_BFS
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;

        static void Main()
        {
            graph = new Dictionary<int, List<int>>
            {
                {1, new List<int>{19,21,14} },
                {19, new List<int>{7,12,31,21}},
                {7, new List<int>{1}},
                {12, new List<int>()},
                {21, new List<int>{14} },
                {31, new List<int>{21} },
                {14, new List<int>{6,23} },
                {6, new List<int>() },
                {23, new List<int>{21} }

            };

            visited = new HashSet<int>();

            foreach (var node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    BFS(node);
                }
                //DFS(node);
            }
        }

        private static void DFS(int node)
        {
            if (visited.Contains(node))
            {
                return;
            }
            visited.Add(node);
            foreach (var child in graph[node])
            {
                DFS(child);
            }
            Console.WriteLine(node);
        }
        private static void BFS(int startNode)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.WriteLine(node);

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                    }
                }
            }

        }

    }
}
