using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2021.Day21
{
    public static class PartTwo
    {
        private static readonly IReadOnlyList<(int, long)> dieRollDistributions = new List<(int, long)>
        {
            { (3, 1) },
            { (4, 3) },
            { (5, 6) },
            { (6, 7) },
            { (7, 6) },
            { (8, 3) },
            { (9, 1) },
        };

        public static long CalculatePartTwo(this IEnumerable<Player> players)
        {
            var enumeratedPlayers = players.ToSequence();
            var victoriesPerPlayer = enumeratedPlayers.ToDictionary(x => x.Name, _ => 0L);
            DiracGame((enumeratedPlayers[0], 1), (enumeratedPlayers[1], 1), true, victoriesPerPlayer);
            return victoriesPerPlayer.Values.Max();
        }

        private static void DiracGame(
            (Player Player, long Instances) playersOne,
            (Player Player, long Instances) playersTwo,
            bool currentlyPlayerOne,
            IDictionary<string, long> victoriesPerPlayer)
        {
            var currentEntry = currentlyPlayerOne ? playersOne : playersTwo;
            foreach (var (dieTotal, instances) in dieRollDistributions)
            {
                var newPosition = ((currentEntry.Player.Position + dieTotal - 1) % 10) + 1;
                var newPlayer = currentEntry.Player with { Position = newPosition, Score = currentEntry.Player.Score + newPosition };
                if (newPlayer.Score >= 21)
                {
                    victoriesPerPlayer[newPlayer.Name] += currentEntry.Instances * instances;
                }
                else
                {
                    var newEntry = (newPlayer, currentEntry.Instances * instances);
                    DiracGame(
                        currentlyPlayerOne ? newEntry : playersOne,
                        currentlyPlayerOne ? playersTwo : newEntry,
                        !currentlyPlayerOne,
                        victoriesPerPlayer);
                }
            }
        }
    }
}
