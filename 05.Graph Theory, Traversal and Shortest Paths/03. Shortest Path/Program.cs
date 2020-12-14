using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Shortest_Path
{
    class Program
    {
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        private static HashSet<int> visited = new HashSet<int>();


        static void Main()
        {
            int numNodes = int.Parse(Console.ReadLine());
            int numEdges = int.Parse(Console.ReadLine());

            graph = ReadGraph(numNodes, numEdges);
            int startNode = int.Parse(Console.ReadLine());
            int endNode = int.Parse(Console.ReadLine());
            visited = new HashSet<int>(numNodes);

            //  foreach (var children in graph.Keys)
            //  {
            //      Console.WriteLine(String.Join(" ", children));
            //  }

            Console.WriteLine(CalculateShortestDistance(startNode, endNode));
        }

        private static Dictionary<int, List<int>> ReadGraph(int numNodes, int numEdges)
        {
            Dictionary<int, List<int>> graphResult = new Dictionary<int, List<int>>();

            for (int i = 1; i <= numEdges; i++)
            {
                var children = new List<int>();
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var node = edge[0];
                graphResult[node] = children;
                var child = edge[1];

                if (!graphResult[node].Contains(child))
                {
                    graphResult[node].Add(child);
                }
                if (!visited.Contains(child))
                {
                    node = child;
                    graphResult[node] = new List<int>();
                }
            }
            return graphResult;
        }
        private static int CalculateShortestDistance(int startNode, int endNode)
        {
            visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startNode);
            List<int> children;
            int distance = 1;

            while (queue.Count > 0)
            {
                children = new List<int>();

                while (queue.Count > 0)
                {
                    ;
                    var current = queue.Dequeue();

                    foreach (var child in graph[current])
                    {
                        if (!visited.Contains(child))
                        {
                            if (child == endNode)
                            {
                                return distance;
                            }
                            visited.Add(child);
                            children.Add(child);
                        }
                    }
                }

                queue = new Queue<int>(children);
                distance++;
            }

            return -1;
        }

        private static void BFS(int startNode, int endNode)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                //Console.WriteLine(node);

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
