using AdventOfCode.Shared;

namespace AdventOfCode2021.Day22
{
    public static class PartTwo
    {
        public static long CalculatePartTwo(this IEnumerable<(bool TurnOn, Coordinate3D StartCoordinate, Coordinate3D EndCoordinate)> inputs)
        {
            var sparseCube = new SparseCube<bool>();
            foreach (var (turnOn, startCoordinate, endCoordinate) in inputs)
            {
                PartOne.RebootEngine(sparseCube, turnOn, startCoordinate, endCoordinate, int.MinValue, int.MaxValue);
            }

            return sparseCube.Entries.LongCount();
        }
    }
}
