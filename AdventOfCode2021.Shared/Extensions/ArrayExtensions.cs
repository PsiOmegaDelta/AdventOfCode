namespace AdventOfCode2021.Shared.Extensions
{
    public static class ArrayExtensions
    {
        public static IEnumerable<(int X, int Y)> GetNeighbours(this int[][] matrix, (int X, int Y) point, bool cardinalsOnly)
        {
            return matrix.GetNeighbours(point.X, point.Y, cardinalsOnly);
        }

        public static IEnumerable<(int X, int Y)> GetNeighbours(this int[][] matrix, int x, int y, bool cardinalsOnly)
        {
            var minX = Math.Max(0, x - 1);
            var minY = Math.Max(0, y - 1);
            var maxX = Math.Min(x + 1, matrix.Length - 1);
            for (var newX = minX; newX <= maxX; newX++)
            {
                for (var newY = minY; newY <= Math.Min(y + 1, matrix[newX].Length - 1); newY++) // Recalculating maxY allows us to support jagged matrixes
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
