using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using Nito.Collections;

namespace AdventOfCode2023.Day03
{
    public static partial class Calculations
    {
        public static long CalculatePartOne(this SparsePlane<char> schematic)
        {
            if (schematic.ExplicitEntries.None())
            {
                return 0;
            }

            var sum = 0L;
            var minX = schematic.MinX ?? 0;
            var maxX = schematic.MaxX ?? 0;
            for (var row = schematic.MinY ?? 0; row <= (schematic.MaxY ?? 0); row++)
            {
                var currentDigits = new List<char>();
                int? startOfDigits = null;

                for (var column = minX; column <= maxX; column++)
                {
                    var character = schematic[column, row];
                    if (char.IsDigit(character))
                    {
                        startOfDigits ??= column;
                        currentDigits.Add(character);
                    }
                    else if (currentDigits.Count > 0)
                    {
                        if (startOfDigits.HasValue && HasSymbolNeighbours(row, startOfDigits.Value, column - 1))
                        {
                            sum += int.Parse(string.Concat(currentDigits));
                        }

                        currentDigits.Clear();
                        startOfDigits = null;
                    }
                }

                if (startOfDigits.HasValue && HasSymbolNeighbours(row, startOfDigits.Value, maxX))
                {
                    sum += int.Parse(string.Concat(currentDigits));
                }
            }

            return sum;

            bool HasSymbolNeighbours(int row, int startColumn, int endColumn)
            {
                // This checks if the row above and below the current low has any symbols
                for (var column = startColumn - 1; column <= endColumn + 1; column++)
                {
                    if (schematic.HasExplictValue(column, row - 1) || schematic.HasExplictValue(column, row + 1))
                    {
                        return true;
                    }
                }

                // And this checks if the columns to the left and right of the number (on the current row) has any symbols
                return schematic.HasExplictValue(startColumn - 1, row) || schematic.HasExplictValue(endColumn + 1, row);
            }
        }

        public static long CalculatePartTwo(this SparsePlane<char> schematic)
        {
            var ratios = 0L;
            // Get all cogs
            foreach (var entry in schematic.ExplicitEntries.Where(x => x.Entry == '*'))
            {
                // Get all the cog's neighbours arranged by coordinate
                var potentialNumbers = schematic
                    .ExplicitNeighbours(entry.Coordinate)
                    .Where(x => char.IsDigit(x.Entry))
                    .ToDictionary(x => x.Coordinate, x => x.Entry);

                // Exactly 2 numbers are required for a cog to be relevant
                // If we have fewer than 2 potential numbers then exit early
                // If we have numbers on more than 2 rows then exit early
                if (potentialNumbers.Count < 2 || potentialNumbers.Keys.Select(x => x.Y).Distinct().Count() > 2)
                {
                    continue;
                }

                var numbers = new List<int>();
                while (potentialNumbers.Count > 0)
                {
                    // If we already have 2 numbers that means that we're working on a 3rd
                    if (numbers.Count == 2)
                    {
                        numbers.Clear();
                        break;
                    }

                    var (coordinate, digit) = potentialNumbers.First();

                    var digitQueue = new Deque<char>();
                    digitQueue.AddToFront(digit);

                    potentialNumbers.Remove(coordinate);

                    for (var frontColumn = coordinate.X - 1; ; frontColumn--)
                    {
                        var character = schematic[frontColumn, coordinate.Y];
                        if (char.IsDigit(character))
                        {
                            digitQueue.AddToFront(character);
                            // Should the list of potential numbers contain the current coordinate then remove it (since we've now parsed it)
                            potentialNumbers.Remove((frontColumn, coordinate.Y));
                        }
                        else
                        {
                            break;
                        }
                    }

                    for (var backColumn = coordinate.X + 1; ; backColumn++)
                    {
                        var character = schematic[backColumn, coordinate.Y];
                        if (char.IsDigit(character))
                        {
                            digitQueue.AddToBack(character);
                            potentialNumbers.Remove((backColumn, coordinate.Y));
                        }
                        else
                        {
                            break;
                        }
                    }

                    numbers.Add(int.Parse(string.Concat(digitQueue)));
                }

                if (numbers.Count == 2)
                {
                    ratios += numbers[0] * numbers[1];
                }
            }

            return ratios;
        }
    }
}
