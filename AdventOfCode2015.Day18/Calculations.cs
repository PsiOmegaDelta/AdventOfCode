using AdventOfCode.Shared;

namespace AdventOfCode2015.Day18
{
    public static class Calculations
    {
        public static long CalculatePartOne(this SparsePlane<char> plane, int steps)
        {
            return Conway(plane, steps, _ => { });
        }

        public static long CalculatePartTwo(this SparsePlane<char> plane, int steps)
        {
            return Conway(plane, steps, StuckCorners);

            static void StuckCorners(SparsePlane<char> plane)
            {
                plane[plane.MinX ?? 0, plane.MinY ?? 0] = '#';
                plane[plane.MaxX ?? 0, plane.MinY ?? 0] = '#';
                plane[plane.MinX ?? 0, plane.MaxY ?? 0] = '#';
                plane[plane.MaxX ?? 0, plane.MaxY ?? 0] = '#';
            }
        }

        private static long Conway(SparsePlane<char> plane, int steps, Action<SparsePlane<char>> modifyPlane)
        {
            modifyPlane(plane);
            for (int i = 0; i < steps; i++)
            {
                var newPlane = new SparsePlane<char>() { DefaultWhenUnset = plane.DefaultWhenUnset };
                foreach (var (coordinate, character) in plane.Entries)
                {
                    var isAlive = character == '#';
                    var livingNeighbours = plane.Neighbours(coordinate).Count(x => x.Entry == '#');
                    if (isAlive && (livingNeighbours == 2 || livingNeighbours == 3))
                    {
                        newPlane[coordinate.X, coordinate.Y] = '#';
                    }
                    else if (!isAlive && livingNeighbours == 3)
                    {
                        newPlane[coordinate.X, coordinate.Y] = '#';
                    }
                }

                plane = newPlane;
                modifyPlane(plane);
            }

            return plane.ExplicitEntries.LongCount();
        }
    }
}
