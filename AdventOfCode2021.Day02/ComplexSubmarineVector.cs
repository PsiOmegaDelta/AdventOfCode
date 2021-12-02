using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Day02
{
    public class ComplexSubmarineVector : ISubmarineVector
    {
        private static readonly IReadOnlyDictionary<string, Func<Location, int, Location>> locationModifiers = new Dictionary<string, Func<Location, int, Location>>
        {
            { "forward", (location, distance) => location with { HorizontalPosition = location.HorizontalPosition + distance, Depth = location.Depth + (location.Aim * distance) } },
            { "down" , (location, distance) => location with { Aim = location.Aim + distance } },
            { "up" , (location, distance) => location with { Aim = location.Aim - distance } },
        };

        public ComplexSubmarineVector(string direction, int distance)
        {
            Direction = direction;
            Distance = distance;
        }

        public string Direction { get; }

        public int Distance { get; }

        public Location AdjustLocation(Location location)
        {
            return locationModifiers[Direction](location, Distance);
        }
    }
}
