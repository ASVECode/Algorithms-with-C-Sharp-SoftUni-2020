using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Stroy_Telling
{
    class Program
    {
        private static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private static HashSet<string> visited = new HashSet<string>();
        private static Stack<string> result = new Stack<string>();
        static void Main()
        {
            graph = ReadGraph();
            visited = new HashSet<string>();
            result = new Stack<string>();
            foreach (var node in graph.Keys)
            {
                DFS(node);
            }
            Console.WriteLine(string.Join(" ", result));
        }

        private static void DFS(string node)
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

            result.Push(node);
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var resultGraph = new Dictionary<string, List<string>>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
                var parts = line.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                var preStory = parts[0].Trim();

                if (!resultGraph.ContainsKey(preStory))
                {
                    resultGraph.Add(preStory, new List<string>());
                }
                if (parts.Length == 1)
                {
                    continue;
                }
                var postStories = parts[1].Trim().Split();

                resultGraph[preStory].AddRange(postStories);
            }
            return resultGraph;
        }
    }
}
