using AdventOfCode2021.Shared.Extensions;

namespace AdventOfCode2021.Day09
{
    public static class ArrayExtensions
    {
        public static bool IsLowPoint(this int[][] matrix, int x, int y)
        {
            var value = matrix[x][y];
            foreach (var (nX, nY) in matrix.GetNeighbours(x, y, true))
            {
                if (matrix[nX][nY] <= value)
                {
                    return false;
                }
            }

            return true;
        }

        public static IEnumerable<(int X, int Y)> LowPointCoordinates(this int[][] matrix)
        {
            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[x].Length; y++)
                {
                    if (matrix.IsLowPoint(x, y))
                    {
                        yield return (x, y);
                    }
                }
            }
        }

        public static IEnumerable<int> LowPointValues(this int[][] matrix)
        {
            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[x].Length; y++)
                {
                    if (matrix.IsLowPoint(x, y))
                    {
                        yield return matrix[x][y];
                    }
                }
            }
        }
    }
}
