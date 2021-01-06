using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_recunstuction
{
    public class Street
    {
        public Street(int firstBuilding, int secondBuilding)
        {
            this.FirstBuilding = firstBuilding;
            this.SecondBuilding = secondBuilding;
        }

        public int FirstBuilding { get; set; }

        public int SecondBuilding { get; set; }

        public override string ToString()
        {
            if (this.FirstBuilding < this.SecondBuilding)
            {
                return $"{FirstBuilding} {SecondBuilding}";
            }
            else
            {
                return $"{SecondBuilding} {FirstBuilding}";
            }
        }
    }

    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static List<Street> streets;

        static void Main(string[] args)
        {
            var buildingsCount = int.Parse(Console.ReadLine());
            var streetsCount = int.Parse(Console.ReadLine());

            streets = new List<Street>(streetsCount);
            graph = ReadGraph(buildingsCount, streetsCount);

            var importantStreets = new List<Street>();

            foreach (var street in streets)
            {
                var firstBuilding = street.FirstBuilding;
                var secondBuilding = street.SecondBuilding;

                graph[firstBuilding].Remove(secondBuilding);
                graph[secondBuilding].Remove(firstBuilding);

                if (IsImportant(firstBuilding, secondBuilding))
                {
                    importantStreets.Add(street);
                }

                graph[firstBuilding].Add(secondBuilding);
                graph[secondBuilding].Add(firstBuilding);
            }

            Console.WriteLine("Important streets:");
            foreach (var item in importantStreets)
            {
                Console.WriteLine(item);

            }
        }

        //BFS
        private static bool IsImportant(int firstBuilding, int secondBuilding)
        {
            var queue = new Queue<int>();
            queue.Enqueue(firstBuilding);

            var visited = new HashSet<int>();
            visited.Add(firstBuilding);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == secondBuilding)
                {
                    return false;
                }

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            return true;
        }

        private static Dictionary<int, List<int>> ReadGraph(int buildingsCount, int streetsCount)
        {
            var result = new Dictionary<int, List<int>>(buildingsCount);

            for (int i = 0; i < streetsCount; i++)
            {
                var input = Console.ReadLine()
                    .Split(new string[]{ " - "}, StringSplitOptions.RemoveEmptyEntries);

                var firstBulding = int.Parse(input[0]);
                var secondBulding = int.Parse(input[1]);

                if (!result.ContainsKey(firstBulding))
                {
                    result[firstBulding] = new List<int>();
                }

                if (!result.ContainsKey(secondBulding))
                {
                    result[secondBulding] = new List<int>();
                }

                result[firstBulding].Add(secondBulding);
                result[secondBulding].Add(firstBulding);

                AddStreets(firstBulding, secondBulding);
            }

            return result;
        }

        private static void AddStreets(int firstBulding, int secondBulding)
        {
            var street = new Street(firstBulding, secondBulding);

            streets.Add(street);
        }
    }
}
