using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2021.Day21
{
    public static class PartOne
    {
        public static long CalculatePartOne(this IEnumerable<Player> players, IEnumerable<int> dieRolls)
        {
            using var dieRollsEnumerator = dieRolls.GetEnumerator();
            var enumeratedPlayers = players.ToList();
            var playerIndex = 0;
            for (var totalRolls = 3L; ; totalRolls += 3)
            {
                var currentPlayer = enumeratedPlayers[playerIndex];
                var rollsValue = dieRollsEnumerator.Take(3).Sum();
                var position = ((currentPlayer.Position + rollsValue - 1) % 10) + 1;
                enumeratedPlayers[playerIndex] = currentPlayer with { Position = position, Score = currentPlayer.Score + position };

                if (enumeratedPlayers[playerIndex].Score >= 1000)
                {
                    return enumeratedPlayers[playerIndex == 1 ? 0 : 1].Score * totalRolls;
                }

                playerIndex = (playerIndex + 1) % enumeratedPlayers.Count;
            }
        }
    }
}
