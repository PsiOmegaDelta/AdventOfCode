using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2021.Day09
{
    public static class PartTwo
    {
        public static long CalculatePartTwo(int[][] matrix)
        {
            return matrix.LowPointCoordinates().Select(x => matrix.GetBasinSize(x)).OrderByDescending(x => x).Take(3).Product();
        }

        public static int GetBasinSize(this int[][] matrix, (int, int) coordinate)
        {
            return matrix.GetBasinSize(coordinate.ToEnumerable().ToHashSet(), matrix.GetGoodNeighbours(coordinate));
        }

        // Tail-recursive to avoid the stack limit
        public static int GetBasinSize(this int[][] matrix, ISet<(int, int)> visitedCoordinates, IEnumerable<(int, int)> coordinatesToVisit)
        {
            var goodNeighbours = coordinatesToVisit.Where(x => visitedCoordinates.Add(x)).SelectMany(x => matrix.GetGoodNeighbours(x)).ToList();
            return goodNeighbours.Count == 0 ? visitedCoordinates.Count : matrix.GetBasinSize(visitedCoordinates, goodNeighbours);
        }

        // Neighbours smaller than 9 are good neighbours
        public static IEnumerable<(int, int)> GetGoodNeighbours(this int[][] matrix, (int X, int Y) coordinate)
        {
            return matrix.GetNeighbours(coordinate, true).Where(c => matrix[c.X][c.Y] < 9);
        }
    }
}
