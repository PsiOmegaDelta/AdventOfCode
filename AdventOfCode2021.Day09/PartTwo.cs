using AdventOfCode2021.Shared.Extensions;

namespace AdventOfCode2021.Day09
{
    public static class PartTwo
    {
        public static long CalculateResult(int[][] matrix)
        {
            return matrix.LowPointCoordinates().Select(x => GetBasinSize(matrix, x)).OrderByDescending(x => x).Take(3).Product();
        }

        public static int GetBasinSize(int[][] matrix, (int, int) point)
        {
            var points = point.ToEnumerable();
            return GetBasinSize(matrix, points.ToHashSet(), points);
        }

        // Tail-recursive to avoid the stack limit
        public static int GetBasinSize(int[][] matrix, ISet<(int, int)> visitedPoints, IEnumerable<(int, int)> pointsToVisit)
        {
            var goodNeighbours = new HashSet<(int, int)>();
            foreach (var point in pointsToVisit.SelectMany(x => matrix.GetGoodNeighbours(x)))
            {
                if (visitedPoints.Add(point))
                {
                    goodNeighbours.Add(point);
                }
            }

            if (goodNeighbours.Count == 0)
            {
                return visitedPoints.Count;
            }

            return GetBasinSize(matrix, visitedPoints, goodNeighbours);
        }

        // Neighbours smaller than 9 are good neighbours
        public static IEnumerable<(int, int)> GetGoodNeighbours(this int[][] matrix, (int X, int Y) point)
        {
            return matrix.GetNeighbours(point, true).Where(p => matrix[p.X][p.Y] < 9);
        }
    }
}
