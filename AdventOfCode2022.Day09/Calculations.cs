using AdventOfCode.Shared;

namespace AdventOfCode2022.Day09
{
    public static class Calculations
    {
        public static long CalculatePartOne(this IEnumerable<(Direction Direction, int Distance)> steps)
        {
            return CalculatePartOne(steps, (1, 1), (1, 1));
        }

        public static long CalculatePartOne(this IEnumerable<(Direction Direction, int Distance)> steps, Coordinate2D headStart, Coordinate2D tailStart)
        {
            var head = headStart;
            var tail = tailStart;
            var plane = new SparsePlane<char>() { DefaultWhenUnset = '.' };
            plane[headStart] = '#';

            foreach (var step in steps)
            {
                for (int i = 0; i < step.Distance; i++)
                {
                    var move = step.Direction switch
                    {
                        Direction.U => (0, 1),
                        Direction.D => (0, -1),
                        Direction.R => (1, 0),
                        Direction.L => (-1, 0),
                        _ => throw new ArgumentException()
                    };

                    var newKnots = MoveKnots(new[] { head, tail }, move);
                    head = newKnots[0];
                    tail = newKnots[1];
                    plane[tail] = '#';
                }
            }

            return plane.ExplicitEntries.Count();
        }

        public static long CalculatePartTwo(this IEnumerable<(Direction Direction, int Distance)> steps, int numberOfKnots)
        {
            var knots = Enumerable.Repeat(new Coordinate2D(1, 1), numberOfKnots).ToArray();
            var plane = new SparsePlane<char>() { DefaultWhenUnset = '.' };

            foreach (var step in steps)
            {
                for (int i = 0; i < step.Distance; i++)
                {
                    var move = step.Direction switch
                    {
                        Direction.U => (0, 1),
                        Direction.D => (0, -1),
                        Direction.R => (1, 0),
                        Direction.L => (-1, 0),
                        _ => throw new ArgumentException()
                    };

                    knots = MoveKnots(knots, move);
                    plane[knots[numberOfKnots - 1]] = '#';
                }
            }

            return plane.ExplicitEntries.Count();
        }

        public static Coordinate2D[] MoveKnots(Coordinate2D[] knots, (int X, int Y) move)
        {
            var newKnots = new Coordinate2D[knots.Length];
            if (knots.Length == 0)
            {
                return newKnots;
            }

            newKnots[0] = knots[0] with { X = knots[0].X + move.X, Y = knots[0].Y + move.Y };
            for (int i = 1; i < knots.Length; i++)
            {
                var previousKnot = newKnots[i - 1];
                var currentKnot = knots[i];
                var distanceX = previousKnot.X - currentKnot.X;
                var distanceY = previousKnot.Y - currentKnot.Y;
                var modifiedDistanceX = distanceX;
                var modifiedDistanceY = distanceY;

                if (distanceX < 0 && Math.Abs(distanceY) < 2)
                {
                    modifiedDistanceX++;
                }
                else if (distanceX > 0 && Math.Abs(distanceY) < 2)
                {
                    modifiedDistanceX--;
                }

                if (distanceY < 0 && Math.Abs(distanceX) < 2)
                {
                    modifiedDistanceY++;
                }
                else if (distanceY > 0 && Math.Abs(distanceX) < 2)
                {
                    modifiedDistanceY--;
                }

                currentKnot = currentKnot with { X = currentKnot.X + modifiedDistanceX, Y = currentKnot.Y + modifiedDistanceY };
                newKnots[i] = currentKnot;
            }

            return newKnots;
        }
    }
}
