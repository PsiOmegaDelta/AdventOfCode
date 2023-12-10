namespace AdventOfCode2023.Day04
{
    public readonly record struct Scratchcard(int CardNumber, IReadOnlySet<int> WinningNumbers, IReadOnlySet<int> ScratchedNumbers)
    {
        public int Points { get; } = (int)Math.Pow(2, ScratchedNumbers.Intersect(WinningNumbers).Count() - 1);

        public int MatchingNumbers { get; } = ScratchedNumbers.Intersect(WinningNumbers).Count();
    }
}
