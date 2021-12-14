using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2021.Day11
{
    public static class ArrayExtensions
    {
        public static (int[][], long) ConductStep(this int[][] input)
        {
            var newArray = input.Copy();
            var width = newArray.Length;

            var flashes = 0L;
            var flashPoints = new List<(int, int)>();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < newArray[x].Length; y++)
                {
                    newArray[x][y]++;
                    if (newArray[x][y] == 10)
                    {
                        flashPoints.Add((x, y));
                    }
                }
            }

            while (flashPoints.Count > 0)
            {
                flashes += flashPoints.Count;
                var newFlashPoints = new List<(int, int)>();
                foreach (var (x, y) in flashPoints)
                {
                    foreach (var neighbour in newArray.GetNeighbours(x, y, false))
                    {
                        newArray[neighbour.X][neighbour.Y]++;
                        if (newArray[neighbour.X][neighbour.Y] == 10)
                        {
                            newFlashPoints.Add(neighbour);
                        }
                    }
                }

                flashPoints = newFlashPoints;
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < newArray[x].Length; y++)
                {
                    if (newArray[x][y] > 9)
                    {
                        newArray[x][y] = 0;
                    }
                }
            }

            return (newArray, flashes);
        }
    }
}
