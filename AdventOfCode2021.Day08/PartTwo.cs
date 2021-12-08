namespace AdventOfCode2021.Day08
{
    public static class PartTwo
    {
        public static int CalculateResult(string inputPath)
        {
            var total = 0;
            foreach (var line in InputParser.ParseInput(inputPath))
            {
                var segmentsByNumber = new Dictionary<int, IReadOnlySet<char>>();
                foreach (var relevantEntry in line.Where(IsRelevantForMatching))
                {
                    if (relevantEntry.Length == 2 && !segmentsByNumber.ContainsKey(1)) // 1
                    {
                        segmentsByNumber[1] = relevantEntry.ToHashSet();
                    }
                    else if (relevantEntry.Length == 4 && !segmentsByNumber.ContainsKey(4)) // 4
                    {
                        segmentsByNumber[4] = relevantEntry.ToHashSet();
                    }

                    if (segmentsByNumber.Count == 2)
                    {
                        break;
                    }
                }

                total += 1000 * NumberFromString(segmentsByNumber, line[^4]);
                total += 100 * NumberFromString(segmentsByNumber, line[^3]);
                total += 10 * NumberFromString(segmentsByNumber, line[^2]);
                total += NumberFromString(segmentsByNumber, line[^1]);
            }

            return total;

            static bool IsRelevantForMatching(string input)
            {
                // We only care about 1 and 4
                return input.Length == 2 || input.Length == 4;
            }

            static int NumberFromString(IReadOnlyDictionary<int, IReadOnlySet<char>> segmentsByNumber, string input)
            {
                // The numbers with unique lengths are easy enough
                if (input.Length == 2)
                {
                    return 1;
                }
                else if (input.Length == 3)
                {
                    return 7;
                }
                else if (input.Length == 4)
                {
                    return 4;
                }
                else if (input.Length == 7)
                {
                    return 8;
                }
                else if (input.Length == 5) // Of the numbers with 5 segments...
                {
                    // Only 3 shares two segments with 1
                    if (input.Intersect(segmentsByNumber[1]).Count() == 2)
                    {
                        return 3;
                    }

                    // Only 2 shares two segments with 4 while
                    // only 5 shares three segments with 4
                    var intersections = input.Intersect(segmentsByNumber[4]).Count();
                    if (intersections == 2)
                    {
                        return 2;
                    }

                    if (intersections == 3)
                    {
                        return 5;
                    }
                }
                else if (input.Length == 6) // Of the numbers with 6 segments...
                {
                    // Only 9 shares four segments with 4
                    if (input.Intersect(segmentsByNumber[4]).Count() == 4)
                    {
                        return 9;
                    }

                    // Only 6 shares one segment with 1 while
                    // 0 shares two segments with 1 (as does 9, which is why it's checked first)
                    var intersections = input.Intersect(segmentsByNumber[1]).Count();
                    if (intersections == 1)
                    {
                        return 6;
                    }

                    if (intersections == 2)
                    {
                        return 0;
                    }
                }

                // Checking strictly, as opposed to using elses (explicit or otherwise), in order to end up here in case we got bad input
                throw new Exception();
            }
        }
    }
}
