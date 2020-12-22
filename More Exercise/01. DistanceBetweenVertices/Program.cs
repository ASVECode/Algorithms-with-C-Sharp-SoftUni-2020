using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DistanceBetweenVertices
{
    class Program
    {
        static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        static void Main()
        {
            int numNodes = int.Parse(Console.ReadLine());
            int numOfPairs = int.Parse(Console.ReadLine());
            graph = ReadGraph(numNodes);


            for (int i = 0; i < numOfPairs; i++)
            {
                var pairs = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
                var startNode = pairs[0];
                var endNode = pairs[1];

                var steps = GetShortestPath(startNode, endNode);

                Console.WriteLine($"{{{startNode}, {endNode}}} -> {steps}");
            }

        }

        private static int GetShortestPath(int startNode, int endNode)
        {
            var queue = new Queue<int>();
            var steps = new Dictionary<int, int> { { startNode, 0 } };

            queue.Enqueue(startNode);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == endNode)
                {
                    return steps[node];
                }

                foreach (var child in graph[node])
                {
                    if (steps.ContainsKey(child))
                    {
                        continue;
                    }
                    queue.Enqueue(child);
                    steps[child] = steps[node] + 1;
                }

            }

            return -1;
        }

        private static Dictionary<int, List<int>> ReadGraph(int numNodes)
        {
            var resultGraph = new Dictionary<int, List<int>>();

            for (int i = 0; i < numNodes; i++)
            {
                var parts = Console.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                var node = int.Parse(parts[0]);
                if (parts.Length == 1)
                {
                    resultGraph[node] = new List<int>();
                }
                else
                {
                    var children = parts[1].Split().Select(int.Parse).ToList();
                    resultGraph[node] = children;
                }
            }

            return resultGraph;

        }
    }
}
