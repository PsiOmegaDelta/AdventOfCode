namespace AdventOfCode2023.Day04
{
    public static partial class InputParser
    {
        public static IEnumerable<Scratchcard> ParseInput(this IEnumerable<string> input)
        {
            return input.Select(Parse);

            static Scratchcard Parse(string input)
            {
                var cardIdAndNumbers = input.Split(':');
                var numbers = cardIdAndNumbers[1].Split('|');
                return new Scratchcard(
                    int.Parse(cardIdAndNumbers[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]),
                    numbers[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet(),
                    numbers[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet());
            }
        }
    }
}
