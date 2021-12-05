using AdventOfCode2021.Shared;

namespace AdventOfCode2021.Day05
{
    public static class LineExtensions
    {
        public static void PopulatePlane<T>(this IEnumerable<Line> lines, SparsePlane<T> plane, Func<T?, T?> populate)
        {
            foreach (var line in lines)
            {
                PopulatePlane(line, plane, populate);
            }
        }

        public static void PopulatePlane<T>(this Line line, SparsePlane<T> plane, Func<T?, T?> populate)
        {
            int x, y;
            int adjustX(int inputX) => line.IsHorizontal ? inputX : (line.Start.X < line.End.X) ? inputX + 1 : inputX - 1;
            int adjustY(int inputY) => line.IsVertical ? inputY : (line.Start.Y < line.End.Y) ? inputY + 1 : inputY - 1;
            for (x = line.Start.X, y = line.Start.Y; Continue(line, x, y); x = adjustX(x), y = adjustY(y))
            {
                plane[x, y] = populate(plane[x, y]);
            }

            static bool Continue(Line line, int x, int y)
            {
                if (line.Start.X < line.End.X && x > line.End.X)
                {
                    return false;
                }

                if (line.Start.X > line.End.X && x < line.End.X)
                {
                    return false;
                }

                if (line.Start.Y < line.End.Y && y > line.End.Y)
                {
                    return false;
                }

                if (line.Start.Y > line.End.Y && y < line.End.Y)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
