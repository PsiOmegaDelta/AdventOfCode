using AdventOfCode.Shared;

namespace AdventOfCode2015.Day03
{
    public static class PartOne
    {
        public static long CalculatePartOne(this IEnumerable<Func<Coordinate2D, Coordinate2D>> inputs)
        {
            var currentCoordinate = new Coordinate2D(0, 0);
            var sparsePlane = new SparsePlane<int>();
            sparsePlane[currentCoordinate] = 1;

            foreach (var input in inputs)
            {
                currentCoordinate = input(currentCoordinate);
                sparsePlane[currentCoordinate]++;
            }

            return sparsePlane.ExplicitEntries.LongCount();
        }
    }
}
