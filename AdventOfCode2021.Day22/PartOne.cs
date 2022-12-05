using AdventOfCode.Shared;

namespace AdventOfCode2021.Day22
{
    public static class PartOne
    {
        public static long CalculatePartOne(this IEnumerable<(bool TurnOn, Coordinate3D StartCoordinate, Coordinate3D EndCoordinate)> inputs)
        {
            var sparseCube = new SparseCube<bool>();
            foreach (var (turnOn, startCoordinate, endCoordinate) in inputs)
            {
                RebootEngine(sparseCube, turnOn, startCoordinate, endCoordinate, -50, 50);
            }

            return sparseCube.Entries.LongCount();
        }

        public static void RebootEngine(
            SparseCube<bool> engine,
            bool turnOn,
            Coordinate3D startCoordinate,
            Coordinate3D endCoordinate,
            int minCoordinate,
            int maxCoordinate)
        {
            for (int x = Math.Max(startCoordinate.X, minCoordinate); x <= Math.Min(endCoordinate.X, maxCoordinate); x++)
            {
                for (int y = Math.Max(startCoordinate.Y, minCoordinate); y <= Math.Min(endCoordinate.Y, maxCoordinate); y++)
                {
                    for (int z = Math.Max(startCoordinate.Z, minCoordinate); z <= Math.Min(endCoordinate.Z, maxCoordinate); z++)
                    {
                        if (turnOn)
                        {
                            engine.Add(x, y, z, true);
                        }
                        else
                        {
                            engine.Remove(x, y, z);
                        }
                    }
                }
            }
        }
    }
}
