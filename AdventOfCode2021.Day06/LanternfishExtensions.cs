namespace AdventOfCode2021.Day06
{
    public static class LanternfishExtensions
    {
        public static IEnumerable<Lanternfish> DecreaseTimer(this IEnumerable<Lanternfish> lanternfishes)
        {
            foreach (var lanternfish in lanternfishes)
            {
                if (lanternfish.Timer == 0)
                {
                    yield return lanternfish with { Timer = 6, FirstCycle = false };
                    yield return lanternfish with { Timer = 8, FirstCycle = true };
                }
                else
                {
                    yield return lanternfish with { Timer = lanternfish.Timer - 1 };
                }
            }
        }
    }
}
