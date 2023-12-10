namespace AdventOfCode2023.Day02
{
    public static partial class Calculations
    {
        public static long CalculatePartOne(int redCubes, int greenCubes, int blueCubes, IEnumerable<GameInfo> input)
        {
            return input.Where(PossibleMatch).Sum(x => x.GameId);

            bool PossibleMatch(GameInfo gameInfo)
            {
                if (gameInfo.MaxRedCubes > redCubes || gameInfo.MaxGreenCubes > greenCubes || gameInfo.MaxBlueCubes > blueCubes)
                {
                    return false;
                }

                if (gameInfo.MaxRevealedCubes > redCubes + greenCubes + blueCubes)
                {
                    return false;
                }

                return true;
            }
        }

        public static long CalculatePartTwo(this IEnumerable<GameInfo> input)
        {
            return input.Sum(x => x.MaxRedCubes * x.MaxGreenCubes * x.MaxBlueCubes);
        }
    }
}
