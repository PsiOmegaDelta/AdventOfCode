using AdventOfCode.Shared;

namespace AdventOfCode2021.Day05
{
    public class Line2D
    {
        public Line2D(Coordinate2D start, Coordinate2D end)
        {
            Start = start;
            End = end;
        }

        public Coordinate2D End { get; }

        public bool IsCardinal => Start.X == End.X || Start.Y == End.Y;

        public bool IsDiagonal => !IsCardinal;

        public bool IsHorizontal => Start.X == End.X;

        public bool IsVertical => Start.Y == End.Y;

        public Coordinate2D Start { get; }
    }
}
