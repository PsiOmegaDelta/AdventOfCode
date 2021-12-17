using AdventOfCode.Shared;

namespace AdventOfCode2021.Day17
{
    public static class PartOne
    {
        public static int CalculatePartOne(this (Coordinate Start, Coordinate End) targetArea)
        {
            int? height;
            var overshotXInOneStep = false;
            var highestY = 0;
            for (var x = 1; !overshotXInOneStep; x++)
            {
                for (var y = 1; y <= targetArea.End.X && !overshotXInOneStep; y++) // We're ignoring negative Y-values because the task wants to know how high we can get
                {
                    (height, overshotXInOneStep) = targetArea.ConductSteps(x, y);
                    if (height.HasValue)
                    {
                        highestY = Math.Max(highestY, height.Value);
                    }
                }
            }

            return highestY;
        }

        public static (int? height, bool overshotXInOne) ConductSteps(this (Coordinate Start, Coordinate End) targetArea, int xVelocity, int yVelocity)
        {
            var position = new Coordinate(0, 0);
            var steps = 0;
            var highestY = 0;
            do
            {
                steps++;
                position = position with { X = position.X + xVelocity, Y = position.Y + yVelocity };
                highestY = Math.Max(position.Y, highestY);
                if (position.X >= targetArea.Start.X && position.X <= targetArea.End.X && position.Y <= targetArea.Start.Y && position.Y >= targetArea.End.Y)
                {
                    return (highestY, false);
                }

                xVelocity = Math.Max(0, xVelocity - 1);
                yVelocity--;
            } while (position.X <= targetArea.End.X && position.Y >= targetArea.End.Y);

            return (null, steps == 1 && position.X > targetArea.End.X);
        }
    }
}
