using AdventOfCode.Shared.Extensions;
using System.Text;

namespace AdventOfCode.Shared
{
    public sealed class SparsePlane<T>
    {
        private readonly IDictionary<int, IDictionary<int, T?>> columnsByRow = new Dictionary<int, IDictionary<int, T?>>();

        public SparsePlane()
        {
            DefaultWhenUnset = default;
        }

        public SparsePlane(T? defaultWhenUnset)
        {
            DefaultWhenUnset = defaultWhenUnset;
        }

        public T? DefaultWhenUnset { get; set; }

        public IEnumerable<(Coordinate2D Coordinate, T? Entry)> Entries => YieldAllValues();

        public IEnumerable<(Coordinate2D Coordinate, T? Entry)> ExplicitEntries => columnsByRow.SelectMany(x => x.Value.Select(y => (new Coordinate2D(x.Key, y.Key), y.Value)));

        public int? MaxX { get; private set; }

        public int? MaxY { get; private set; }

        public int? MinX { get; private set; }

        public int? MinY { get; private set; }

        public T? this[Coordinate2D key]
        {
            get => this[key.X, key.Y];

            set => this[key.X, key.Y] = value;
        }

        public T? this[int x, int y]
        {
            get => columnsByRow.TryGetValue(x, out var columns) && columns.TryGetValue(y, out var coordinateEntry) ? coordinateEntry : DefaultWhenUnset;

            set => Add(x, y, value);
        }

        public override string ToString()
        {
            if (MaxX == null)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            for (int y = MinY!.Value; y <= MaxY; y++)
            {
                for (int x = MinX!.Value; x <= MaxX; x++)
                {
                    T? entry = this[x, y];
                    stringBuilder.Append(entry?.ToString() ?? ".");
                }

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        private T? Add(int x, int y, T? value)
        {
            MaxX = Math.Max(x, MaxX ?? x);
            MaxY = Math.Max(y, MaxY ?? y);
            MinX = Math.Min(x, MinX ?? x);
            MinY = Math.Min(y, MinY ?? y);
            return columnsByRow.GetOrAdd(x, _ => new Dictionary<int, T?>())[y] = value;
        }

        private IEnumerable<(Coordinate2D Coordinate, T? Entry)> YieldAllValues()
        {
            if (!MaxX.HasValue)
            {
                yield break;
            }

            for (int x = MinX!.Value; x <= MaxX; x++)
            {
                for (int y = MinY!.Value; y <= MaxY; y++)
                {
                    yield return (new Coordinate2D(x, y), this[x, y]);
                }
            }
        }
    }
}
