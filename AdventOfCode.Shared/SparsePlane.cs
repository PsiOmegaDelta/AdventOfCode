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

        public IEnumerable<Point2D<T?>> Entries => YieldAllValues();

        public IEnumerable<Point2D<T?>> ExplicitEntries => columnsByRow.SelectMany(x => x.Value.Select(y => new Point2D<T?>((x.Key, y.Key), y.Value)));

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

        public IEnumerable<Point2D<T?>> CardinalNeighbours(IEnumerable<Coordinate2D> coordinates)
        {
            return coordinates.SelectMany(x => CardinalNeighbours(x)).Distinct();
        }

        public IEnumerable<Point2D<T?>> CardinalNeighbours(Coordinate2D coordinate)
        {
            yield return ((coordinate.X, coordinate.Y - 1), this[coordinate.X, coordinate.Y - 1]); // North
            yield return ((coordinate.X - 1, coordinate.Y), this[coordinate.X - 1, coordinate.Y]); // West
            yield return ((coordinate.X + 1, coordinate.Y), this[coordinate.X + 1, coordinate.Y]); // East
            yield return ((coordinate.X, coordinate.Y + 1), this[coordinate.X, coordinate.Y + 1]); // South
        }

        public IEnumerable<Point2D<T?>> ExplicitCardinalNeighbours(Point2D<T> point)
        {
            return ExplicitCardinalNeighbours(point.Coordinate);
        }

        public IEnumerable<Point2D<T?>> ExplicitCardinalNeighbours(IEnumerable<Point2D<T>> points)
        {
            return points.SelectMany(x => ExplicitCardinalNeighbours(x.Coordinate)).Distinct();
        }

        public IEnumerable<Point2D<T?>> ExplicitCardinalNeighbours(IEnumerable<Coordinate2D> coordinates)
        {
            return coordinates.SelectMany(x => ExplicitCardinalNeighbours(x)).Distinct();
        }

        public IEnumerable<Point2D<T?>> ExplicitCardinalNeighbours(Coordinate2D coordinate)
        {
            for (int y = coordinate.Y - 1; y <= coordinate.Y + 1; y++)
            {
                for (int x = coordinate.X - 1; x <= coordinate.X + 1; x++)
                {
                    if ((x == coordinate.X || y == coordinate.Y) && !(x == coordinate.X && y == coordinate.Y))
                    {
                        if (columnsByRow.TryGetValue(x, out var columns) && columns.TryGetValue(y, out var coordinateEntry))
                        {
                            yield return ((x, y), coordinateEntry);
                        }
                    }
                }
            }
        }

        public IEnumerable<(Coordinate2D Coordinate, T? Entry)> Neighbours(Coordinate2D coordinate)
        {
            for (var y = coordinate.Y - 1; y <= coordinate.Y + 1; y++)
            {
                for (var x = coordinate.X - 1; x <= coordinate.X + 1; x++)
                {
                    if (y == coordinate.Y && x == coordinate.X)
                    {
                        continue;
                    }

                    yield return ((x, y), this[x, y]);
                }
            }
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

        private IEnumerable<Point2D<T?>> YieldAllValues()
        {
            if (!MaxX.HasValue)
            {
                yield break;
            }

            for (int x = MinX!.Value; x <= MaxX; x++)
            {
                for (int y = MinY!.Value; y <= MaxY; y++)
                {
                    yield return ((x, y), this[x, y]);
                }
            }
        }
    }
}
