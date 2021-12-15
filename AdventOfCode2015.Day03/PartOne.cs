using AdventOfCode.Shared;

namespace AdventOfCode2015.Day03
{
    public static class PartOne
    {
        public static long CalculatePartOne(this IEnumerable<Func<Coordinate, Coordinate>> inputs)
        {
            var currentCoordinate = new Coordinate(0, 0);
            var sparsePlane = new SparsePlane<int>();
            sparsePlane[currentCoordinate] = 1;

            foreach (var input in inputs)
            {
                currentCoordinate = input(currentCoordinate);
                sparsePlane[currentCoordinate]++;
            }

            return sparsePlane.Entries.LongCount();
        }
    }
}
