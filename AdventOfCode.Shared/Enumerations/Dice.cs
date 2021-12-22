namespace AdventOfCode.Shared.Enumerations
{
    public static class Dice
    {
        public static IEnumerable<int> DeterministicD100()
        {
            while (true)
            {
                for (int i = 1; i <= 100; i++)
                {
                    yield return i;
                }
            }
        }
    }
}
