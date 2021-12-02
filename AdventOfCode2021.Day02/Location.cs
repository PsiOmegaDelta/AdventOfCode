namespace AdventOfCode2021.Day02
{
    public record Location
    {
        public Location(int depth, int horizontalPosition, int aim)
        {
            Depth = depth;
            HorizontalPosition = horizontalPosition;
            Aim = aim;
        }

        public int Aim { get; init; }

        public int Depth { get; init; }

        public int HorizontalPosition { get; init; }

        public static Location Zero { get; } = new Location(0, 0, 0);
    }
}
