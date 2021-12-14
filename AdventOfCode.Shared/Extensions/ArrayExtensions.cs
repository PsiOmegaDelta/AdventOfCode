namespace AdventOfCode.Shared.Extensions
{
    public static class ArrayExtensions
    {
        public static bool Any<T>(this T[][] array, Predicate<T> predicate)
        {
            for (int x = 0; x < array.Length; x++)
            {
                for (int y = 0; y < array[x].Length; y++)
                {
                    if (predicate(array[x][y]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static T[][] Copy<T>(this T[][] array)
        {
            T[][] copy = new T[array.Length][];
            for (int w = 0; w < array.Length; w++)
            {
                var height = array[w].Length;
                copy[w] = new T[height];
                for (int h = 0; h < height; h++)
                {
                    copy[w][h] = array[w][h];
                }
            }

            return copy;
        }

        public static IEnumerable<(int X, int Y)> GetNeighbours<T>(this T[][] array, (int X, int Y) point, bool cardinalsOnly)
        {
            return array.GetNeighbours(point.X, point.Y, cardinalsOnly);
        }

        public static IEnumerable<(int X, int Y)> GetNeighbours<T>(this T[][] array, int x, int y, bool cardinalsOnly)
        {
            var minX = Math.Max(0, x - 1);
            var minY = Math.Max(0, y - 1);
            var maxX = Math.Min(x + 1, array.Length - 1);
            for (var newX = minX; newX <= maxX; newX++)
            {
                for (var newY = minY; newY <= Math.Min(y + 1, array[newX].Length - 1); newY++) // Recalculating maxY allows us to support jagged matrixes
                {
                    if ((newX == x && newY == y) || (cardinalsOnly && newX != x && newY != y))
                    {
                        continue;
                    }

                    yield return (newX, newY);
                }
            }
        }
    }
}
