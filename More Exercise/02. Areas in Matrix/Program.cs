using System;
using System.Collections.Generic;

namespace _02.Areas_in_Matrix
{
    public class Node
    {
        public int Row { get; set; }
        public int Col { get; set; }

    }
    public class Program
    {
        static char[,] matrix = new char[,] { };
        private static bool[,] visited = new bool[,] { };

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var areas = new SortedDictionary<char, int>();
            var totalAreas = 0;

            matrix = ReadMatrix(n, m);
            visited = new bool[n, m];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (visited[r, c])
                    {
                        continue;
                    }
                    DFS(r, c);
                    totalAreas++;
                    var key = matrix[r, c];
                    if (!areas.ContainsKey(key))
                    {
                        areas.Add(key, 1);
                    }
                    else
                    {
                        areas[key] += 1;
                    }
                }

            }
            Console.WriteLine($"Areas: {totalAreas}");
            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }

        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static List<Node> GetChildren(int row, int col)
        {
            var children = new List<Node>();
            //row-1,col
            if (IsInside(row - 1, col) && IsChild(row, col, row - 1, col) && !IsVisited(row - 1, col))
            {
                children.Add(new Node { Row = row - 1, Col = col });
            }

            //row+1,col
            if (IsInside(row + 1, col) && IsChild(row, col, row + 1, col) && !IsVisited(row + 1, col))
            {
                children.Add(new Node { Row = row + 1, Col = col });
            }

            //row,col-1
            if (IsInside(row, col - 1) && IsChild(row, col, row, col - 1) && !IsVisited(row, col - 1))
            {
                children.Add(new Node { Row = row, Col = col - 1 });
            }

            //row,col+1
            if (IsInside(row, col + 1) && IsChild(row, col, row, col + 1) && !IsVisited(row, col + 1))
            {
                children.Add(new Node { Row = row, Col = col + 1 });
            }
            return children;
        }

        private static bool IsVisited(int row, int col)
        {
            return visited[row, col];
        }

        private static bool IsChild(int parentRow, int parentCol, int childRow, int childCol)
        {
            return matrix[parentRow, parentCol] == matrix[childRow, childCol];
        }

        private static void DFS(int row, int col)
        {
            if (visited[row, col])
            {
                return;
            }
            visited[row, col] = true;
            var children = GetChildren(row, col);

            foreach (var child in children)
            {
                DFS(child.Row, child.Col);
            }
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var result = new char[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                var elements = Console.ReadLine();
                for (int c = 0; c < elements.Length; c++)
                {
                    result[r, c] = elements[c];
                }
            }
            return result;
        }
    }
}
