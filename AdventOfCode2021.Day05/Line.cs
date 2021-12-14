using AdventOfCode.Shared;

namespace AdventOfCode2021.Day05
{
    public class Line
    {
        public Line(Coordinate start, Coordinate end)
        {
            Start = start;
            End = end;
        }

        public Coordinate End { get; }

        public bool IsCardinal => Start.X == End.X || Start.Y == End.Y;

        public bool IsDiagonal => !IsCardinal;

        public bool IsHorizontal => Start.X == End.X;

        public bool IsVertical => Start.Y == End.Y;

        public Coordinate Start { get; }
    }
}
