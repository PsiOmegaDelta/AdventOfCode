using AdventOfCode.Shared.Extensions;

namespace AdventOfCode.Shared
{
    public class SparseCube<T>
    {
        private readonly IDictionary<int, IDictionary<int, IDictionary<int, T>>> yByX = new Dictionary<int, IDictionary<int, IDictionary<int, T>>>();

        public SparseCube()
        {
        }

        public SparseCube(T defaultWhenUnset)
        {
            DefaultWhenUnset = defaultWhenUnset;
        }

        public T? DefaultWhenUnset { get; set; } = default;

        public IEnumerable<(Coordinate3D Coordinate, T Entry)> Entries => ReturnCoordinates();

        public T? this[Coordinate3D key]
        {
            get => this[key.X, key.Y, key.Z];

            set => this[key.X, key.Y, key.Z] = value;
        }

        public T? this[int x, int y, int z]
        {
            get => yByX.TryGetValue(x, out var zBYY) && zBYY.TryGetValue(y, out var coordinateEntries) && coordinateEntries.TryGetValue(z, out var coordinateEntry) ? coordinateEntry : DefaultWhenUnset;

            set => Add(x, y, z, value);
        }

        private T? Add(int x, int y, int z, T? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return yByX.GetOrAdd(x, _ => new Dictionary<int, IDictionary<int, T>>()).GetOrAdd(y, _ => new Dictionary<int, T>())[z] = value;
        }

        private IEnumerable<(Coordinate3D, T)> ReturnCoordinates()
        {
            foreach (var (x, andYs) in yByX)
            {
                foreach (var (y, andZs) in andYs)
                {
                    foreach (var (z, andThing) in andZs)
                    {
                        yield return (new Coordinate3D(x, y, z), andThing);
                    }
                }
            }
        }
    }
}
