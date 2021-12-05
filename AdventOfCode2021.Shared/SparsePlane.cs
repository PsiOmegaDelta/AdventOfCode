using AdventOfCode2021.Shared.Extensions;
using System.Text;

namespace AdventOfCode2021.Shared
{
    public class SparsePlane<T>
    {
        private readonly IDictionary<int, IDictionary<int, T?>> columnsByRow = new Dictionary<int, IDictionary<int, T?>>();

        public IEnumerable<(Coordinate Coordinate, T? Entry)> Entries => columnsByRow.SelectMany(x => x.Value.Select(y => (new Coordinate(x.Key, y.Key), y.Value)));

        private int? HighestX { get; set; }

        private int? HighestY { get; set; }

        private int? LowestX { get; set; }

        private int? LowestY { get; set; }

        public T? this[Coordinate key]
        {
            get => this[key.X, key.Y];

            set => this[key.X, key.Y] = value;
        }

        public T? this[int x, int y]
        {
            get => columnsByRow.TryGetValue(x, out var columns) && columns.TryGetValue(y, out var coordinateEntry) ? coordinateEntry : default;

            set => Add(x, y, value);
        }

        public override string ToString()
        {
            if (HighestX == null)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            for (int y = LowestY!.Value; y <= HighestY; y++)
            {
                for (int x = LowestX!.Value; x <= HighestX; x++)
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
            HighestX = Math.Max(x, HighestX ?? x);
            HighestY = Math.Max(y, HighestY ?? y);
            LowestX = Math.Min(x, LowestX ?? x);
            LowestY = Math.Min(y, LowestY ?? y);
            return columnsByRow.GetOrAdd(x, _ => new Dictionary<int, T?>())[y] = value;
        }
    }
}
