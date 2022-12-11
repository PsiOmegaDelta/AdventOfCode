namespace AdventOfCode.Shared
{
    public readonly record struct Coordinate2D(int X, int Y)
    {
        public static implicit operator Coordinate2D((int X, int Y) input) => new(input.X, input.Y);

        public static implicit operator (int X, int Y)(Coordinate2D input) => (input.X, input.Y);
    }
}
