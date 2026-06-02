using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task_2
{
    internal class FillArrayIterative
    {
        public static void Fill(int[,] array, int x, int y, int v)
        {
            int targetValue = array[x, y];
            if (targetValue == v) return;
            MyStack stack = new MyStack();
            stack.Push((x, y));

            while (!stack.IsEmpty())
            {
                var (cx, cy) = stack.Pop();

                if (cx < 0 || cx >= array.GetLength(0) || cy < 0 || cy >= array.GetLength(1)) continue;
                if (array[cx, cy] != targetValue) continue;

                array[cx, cy] = v;
                if (IsInBounds(cx + 1, array.GetLength(0)))
                    stack.Push((cx + 1, cy));
                if (IsInBounds(cx - 1, array.GetLength(0)))
                    stack.Push((cx - 1, cy));
                if (IsInBounds(cy + 1, array.GetLength(1)))
                    stack.Push((cx, cy + 1));
                if (IsInBounds(cy - 1, array.GetLength(1)))
                    stack.Push((cx, cy - 1));
            }
        }

        private static bool IsInBounds(int index, int length)
        {
            return index >= 0 && index < length;
        }
    }
}
