using System;

namespace _02.Recursive_Drawing
{
    class RecursiveDrawing
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            PrintFigure(count);
        }

        private static void PrintFigure(int count)
        {
            if (count == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', count));
            PrintFigure(count - 1);
            Console.WriteLine(new string('#', count));
        }
    }
}
