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

                    (head, tail) = MoveHead(head, tail, move);
                    plane[tail] = '#';
                }
            }

            return plane.ExplicitEntries.Count();
        }

        public static long CalculatePartTwo(this IEnumerable<(Direction, int)> steps)
        {
            return 0;
        }

        public static (Coordinate2D Head, Coordinate2D Tail) MoveHead(Coordinate2D head, Coordinate2D tail, (int X, int Y) move)
        {
            var oldHead = head;
            head = head with { X = head.X + move.X, Y = head.Y + move.Y };
            var tailXDistance = head.X - tail.X;
            var tailYDistance = head.Y - tail.Y;

            if (Math.Abs(tailXDistance) > 1 || Math.Abs(tailYDistance) > 1)
            {
                tail = oldHead;
            }

            return (head, tail);
        }
    }
}
