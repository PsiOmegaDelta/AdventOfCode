using AdventOfCode.Shared;

namespace AdventOfCode2021.Day17
{
    public static class PartTwo
    {
        public static long CalculatePartTwo(this (Coordinate Start, Coordinate End) targetArea)
        {
            int? height;
            var overshotXInOneStep = false;
            var hits = 0;
            for (var x = 1; !overshotXInOneStep; x++)
            {
                // I'll be honest, the lower and upper bounds for y were selected semi-arbitrarily
                for (var y = targetArea.End.Y; y <= targetArea.End.X && !overshotXInOneStep; y++)
                {
                    (height, overshotXInOneStep) = targetArea.ConductSteps(x, y);
                    if (height.HasValue)
                    {
                        hits++;
                    }
                }
            }

            return hits;
        }
    }
}
