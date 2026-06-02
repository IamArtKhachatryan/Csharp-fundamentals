using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] a = {{ 1, 1, 1, 0, 0, 2, 2, 2 },
                        { 1, 9, 9, 0, 0, 2, 3, 3 },
                        { 1, 9, 9, 9, 0, 2, 3, 3 },
                        { 0, 9, 9, 9, 9, 2, 2, 2 },
                        { 0, 0, 0, 0, 9, 9, 4, 4 },
                        { 7, 7, 0, 8, 8, 9, 6, 6 },
                        { 7, 7, 9, 9, 9, 9, 6, 6 },
                        { 9, 9, 9, 0, 0, 4, 6, 6 },};
            int x = 2, y = 2, value = 7;
            ValidateArguments(a, x, y);
            PrintArray(a);
            Console.WriteLine();
            FillArrayRecursive.Fill(a, x, y, value);
            PrintArray(a);
            Console.WriteLine();
            value = 9;
            FillArrayIterative.Fill(a, x, y, value);
            PrintArray(a);
        }

        private static void ValidateArguments(int[,] a, int x, int y)
        {
            if (a == null) { throw new ArgumentNullException(nameof(a)); }
            if (a.GetLength(0) == 0 || a.GetLength(1) == 0) { throw new ArgumentException("Array cannot be empty"); }
            if (x < 0 || x >= a.GetLength(0) || y < 0 || y >= a.GetLength(1)) { throw new ArgumentOutOfRangeException("X or/and Y are out of range"); }
        }



        static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
