namespace AdventOfCode.Shared
{
    public readonly record struct Point2D<T>(Coordinate2D Coordinate, T Entry) : IEquatable<Point2D<T>>
    {
        public static implicit operator Point2D<T>((Coordinate2D Coordinate, T Entry) input) => new(input.Coordinate, input.Entry);
    }
}
