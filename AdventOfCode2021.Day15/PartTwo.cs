using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2021.Day15
{
    public static class PartTwo
    {
        public static long CalculatePartTwo(this int[][] maze)
        {
            maze = maze.ExpandArray(5);
            var row = maze[^1];
            // According to the task we explicitly skip the cost of the first node
            return maze.DijkstraSearch((0, 0), (maze.Length - 1, row.Length - 1)).Skip(1).Select(c => maze[c.X][c.Y]).Sum();
        }

        public static int[][] ExpandArray(this int[][] maze, int times)
        {
            var newMaze = new int[maze.Length * times][];
            // Create new matrix, we're assuming that jagged matrixes are possible rather than implementing an ostrich algorithm
            for (var x = 0; x < maze.Length; x++)
            {
                for (var time = 0; time < times; time++)
                {
                    newMaze[x + (time * maze.Length)] = new int[maze[x].Length * times];
                }
            }

            // Expand width first
            for (int x = 0; x < maze.Length; x++)
            {
                var width = maze[x].Length;
                for (int y = 0; y < maze[x].Length; y++)
                {
                    for (var time = 0; time < times; time++)
                    {
                        var newValue = maze[x][y] + time;
                        newValue = newValue > 9 ? newValue - 9 : newValue; // Should use % or similar operation in case "times" is ever >= 9
                        newMaze[x][y + (width * time)] = newValue;
                    }
                }
            }

            // Then height
            for (int x = 0; x < maze.Length; x++)
            {
                for (int y = 0; y < newMaze[x].Length; y++)
                {
                    for (int time = 1; time < times; time++)
                    {
                        var newValue = newMaze[x][y] + time;
                        newValue = newValue > 9 ? newValue - 9 : newValue;
                        newMaze[x + (time * maze.Length)][y] = newValue;
                    }
                }
            }

            return newMaze;
        }
    }
}
