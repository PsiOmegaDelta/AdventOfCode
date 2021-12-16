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

        public static IReadOnlyList<(int X, int Y)> DijkstraSearch(this int[][] maze, (int X, int Y) start, (int X, int Y) end)
        {
            return maze.DijkstraSearch(start, end, x => x);
        }

        public static IReadOnlyList<(int X, int Y)> DijkstraSearch<T>(this T[][] maze, (int X, int Y) start, (int X, int Y) end, Func<T, long> getCost)
            where T : notnull
        {
            ISet<(int, int)> visited = new HashSet<(int, int)>();
            Dictionary<(int, int), (int, int)> parentMap = new();
            PriorityQueue<(int, int), long> priorityQueue = new();
            var costs = new Dictionary<(int, int), long> { { start, 0 } };

            priorityQueue.Enqueue(start, getCost(maze[start.X][start.Y]));

            (int, int) current;
            while (priorityQueue.Count > 0)
            {
                current = priorityQueue.Dequeue();
                if (!visited.Contains(current))
                {
                    visited.Add(current);

                    if (current.Equals(end))
                    {
                        break;
                    }

                    foreach (var neighbour in maze.GetNeighbours(current, true))
                    {
                        long newCost = costs.GetOrDefault(current, _ => int.MaxValue) + getCost(maze[neighbour.X][neighbour.Y]);
                        long neighborCost = costs.GetOrDefault(neighbour, _ => int.MaxValue);

                        if (newCost < neighborCost)
                        {
                            costs[neighbour] = newCost;
                            parentMap.Add(neighbour, current);
                            priorityQueue.Enqueue(neighbour, newCost);
                        }
                    }
                }
            }

            return parentMap.ReconstructPath(start, end);
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
