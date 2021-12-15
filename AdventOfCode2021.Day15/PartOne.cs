using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2021.Day15
{
    public static class PartOne
    {
        public static long CalculatePartOne(this int[][] maze)
        {
            var row = maze[^1];
            // According to the task we explicitly skip the cost of the first node
            return maze.DijkstraSearch((0, 0), (maze.Length - 1, row.Length - 1)).Skip(1).Select(c => maze[c.X][c.Y]).Sum();
        }
    }
}
