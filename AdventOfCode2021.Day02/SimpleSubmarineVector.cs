using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Day02
{
    public class SimpleSubmarineVector : ISubmarineVector
    {
        private static readonly IReadOnlyDictionary<string, Func<Location, int, Location>> locationModifiers = new Dictionary<string, Func<Location, int, Location>>
        {
            { "forward", (location, distance) => location with { HorizontalPosition = location.HorizontalPosition + distance } },
            { "down" , (location, distance) => location with { Depth = location.Depth + distance } },
            { "up" , (location, distance) => location with { Depth = location.Depth - distance } },
        };

        public SimpleSubmarineVector(string direction, int distance)
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
