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
            PrintArray(a);
            Console.WriteLine();
            FillArrayRecursive(ref a, 2, 2, 7);
            PrintArray(a);
            Console.WriteLine();
            FillArrayIterative(ref a, 2, 2, 9);
            PrintArray(a);
        }

        private static void FillArrayIterative(ref int[,] array, int x, int y, int v)
        {
            int targetValue = array[x, y];
            if (targetValue == v) return;
            MyStack stack = new MyStack();
            stack.Push((x, y));

            while (!stack.IsEmpty())
            {
                var (cx, cy) = stack.Peek();
                stack.Pop();

                if (cx < 0 || cx >= array.GetLength(0) || cy < 0 || cy >= array.GetLength(1)) continue;
                if (array[cx, cy] != targetValue) continue;

                array[cx, cy] = v;

                stack.Push((cx + 1, cy));
                stack.Push((cx - 1, cy));
                stack.Push((cx, cy + 1));
                stack.Push((cx, cy - 1));
            }
        }

        private static void FillArrayRecursive(ref int [,] array, int x, int y, int v)
        {   
            if(x < 0 || x >= array.GetLength(0) || y < 0 || y >= array.GetLength(1)) { return; }
            int targetValue = array[x, y];
            if (targetValue == v) return;
            array[x, y] = v;
            if (x + 1 < array.GetLength(0) && array[x + 1, y] == targetValue)
                FillArrayRecursive(ref array, x + 1, y, v);

            if (x - 1 >= 0 && array[x - 1, y] == targetValue)
                FillArrayRecursive(ref array, x - 1, y, v);

            if (y + 1 < array.GetLength(1) && array[x, y + 1] == targetValue)
                FillArrayRecursive(ref array, x, y + 1, v);

            if (y - 1 >= 0 && array[x, y - 1] == targetValue)
                FillArrayRecursive(ref array, x, y - 1, v);
            return;

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
