using AdventOfCode.Shared;

namespace AdventOfCode2015.Day03
{
    public static class PartTwo
    {
        public static long CalculatePartTwo(this IEnumerable<Func<Coordinate2D, Coordinate2D>> inputs)
        {
            var santaCoordinate = new Coordinate2D(0, 0);
            var robotCoordinate = santaCoordinate;
            var moveSanta = true;
            var sparsePlane = new SparsePlane<int>();
            sparsePlane[santaCoordinate] = 2;

            foreach (var input in inputs)
            {
                Coordinate2D coordinate;
                if (moveSanta)
                {
                    coordinate = santaCoordinate = input(santaCoordinate);
                }
                else
                {
                    coordinate = robotCoordinate = input(robotCoordinate);
                }

                sparsePlane[coordinate]++;

                moveSanta = !moveSanta;
            }

            return sparsePlane.ExplicitEntries.LongCount();
        }
    }
}
