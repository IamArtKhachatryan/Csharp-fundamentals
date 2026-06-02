namespace Task_2
{
    internal class FillArrayRecursive
    {
        public static void Fill(int[,] array, int x, int y, int v)
        {
            int targetValue = array[x, y];
            if (targetValue == v) return;
            array[x, y] = v;
            if (x + 1 < array.GetLength(0) && array[x + 1, y] == targetValue)
                Fill(array, x + 1, y, v);

            if (x - 1 >= 0 && array[x - 1, y] == targetValue)
                Fill(array, x - 1, y, v);

            if (y + 1 < array.GetLength(1) && array[x, y + 1] == targetValue)
                Fill(array, x, y + 1, v);

            if (y - 1 >= 0 && array[x, y - 1] == targetValue)
                Fill(array, x, y - 1, v);
        }
    }
}
