using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Path
{
    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
       static int n;
        static void Main()
        {
            Queue<int> queue = new Queue<int>();

             n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            visited = new bool[n];

            for (int node = 0; node < n; node++)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    var children = line
                        .Split()
                        .Select(int.Parse)
                        .ToList();

                    graph[node] = children;
                }
            }
            int numPaths = int.Parse(Console.ReadLine());
            List<List<int>> paths = new List<List<int>>();
            for (int i = 0; i < numPaths; i++)
            {
                string line = Console.ReadLine();
                List<int> path = line.Split().Select(int.Parse).ToList();
                paths.Add(path);
            }
            foreach (var path in paths)
            {
                TraversePath(path);
            }

        }

        private static void TraversePath(List<int> path)
        {
            string result = "yes";
            for (int i = 0; i < path.Count - 1; i++)
            {
                visited = new bool[n];
                if (!isConnected(graph, path[i], path[i + 1], visited))
                {
                    result = "no";
                    break;
                }
            }
            Console.WriteLine(result);
        }

        private static bool isConnected(List<int>[] graph, int src, int dest, bool[] visited)
        {

            // create a queue used to do BFS
            var queue = new Queue<int>();
            // queue<int> q;

            // mark source vertex as discovered
            visited[src] = true;

            // push source vertex into the queue
            //q.push(src);
            queue.Enqueue(src);
            // loop till queue is empty
            while (queue.Count > 0)
            {
                // pop front node from queue and print it
                int v = queue.Dequeue();
                //queue.Dequeue();

                // if destination vertex is found
                if (v == dest)
                {
                    return true;
                }

                // do for every edge (v -> u)
                foreach (var child in graph[v])
                {
                    if (!visited[child])
                    {
                        // mark it discovered and push it into queue
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }

            return false;
        }

    }
}
