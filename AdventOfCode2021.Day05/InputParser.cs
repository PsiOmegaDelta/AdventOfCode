﻿using AdventOfCode.Shared;

namespace AdventOfCode2021.Day05
{
    public static class InputParser
    {
        public static IEnumerable<Line2D> ParseInput(string input)
        {
            return ParseInput(input, _ => true);
        }

        public static IEnumerable<Line2D> ParseInput(string input, Predicate<Line2D> where)
        {
            return ParseInput(File.ReadLines(input), where);
        }

        public static IEnumerable<Line2D> ParseInput(IEnumerable<string> input)
        {
            return ParseInput(input, _ => true);
        }

        public static IEnumerable<Line2D> ParseInput(IEnumerable<string> input, Predicate<Line2D> where)
        {
            return input
                .Select(x => x.Split(" -> "))
                .Select(x => (Start: x[0].Split(','), End: x[1].Split(',')))
                .Select(x => (X1: int.Parse(x.Start[0]), Y1: int.Parse(x.Start[1]), X2: int.Parse(x.End[0]), Y2: int.Parse(x.End[1])))
                .Select(x => new Line2D(new Coordinate2D(x.X1, x.Y1), new Coordinate2D(x.X2, x.Y2)))
                .Where(x => where(x));
        }
    }
}
