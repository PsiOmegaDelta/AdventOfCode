namespace AdventOfCode2023.Day04
{
    public static partial class Calculations
    {
        public static long CalculatePartOne(this IEnumerable<Scratchcard> scratchcards)
        {
            return scratchcards.Sum(x => x.Points);
        }

        public static long CalculatePartTwo(this IEnumerable<Scratchcard> scratchcards)
        {
            var enumeratedScratchcards = scratchcards.ToList();
            var numberOfCardsPerCardNumber = enumeratedScratchcards.ToDictionary(x => x.CardNumber, _ => 1);

            foreach (var scratchCard in enumeratedScratchcards)
            {
                var numberOfThisCard = numberOfCardsPerCardNumber[scratchCard.CardNumber];
                for (var i = 1; i <= scratchCard.MatchingNumbers; i++)
                {
                    if (numberOfCardsPerCardNumber.TryGetValue(scratchCard.CardNumber + i, out var numberOfOtherCards))
                    {
                        numberOfCardsPerCardNumber[scratchCard.CardNumber + i] = numberOfOtherCards + numberOfThisCard;
                    }
                }
            }

            return numberOfCardsPerCardNumber.Values.Sum();
        }
    }
}
