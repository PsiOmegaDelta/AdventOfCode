using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day02
{
    public static partial class InputParser
    {
        public static IEnumerable<GameInfo> ParseInput(this IEnumerable<string> input)
        {
            foreach (var entry in input)
            {
                int maxRed = 0;
                int maxGreen = 0;
                int maxBlue = 0;
                int maxTotalDraw = 0;
                var idAndReveals = entry.Split(':');
                var gameId = int.Parse(idAndReveals[0].Split(' ')[1]);

                foreach (var reveal in idAndReveals[1].Split(';'))
                {
                    int totalDraw = 0;
                    foreach (Match match in MatchCubes().Matches(reveal).Cast<Match>())
                    {
                        var amount = int.Parse(match.Groups[1].Value);
                        totalDraw += amount;
                        switch (match.Groups[2].Value)
                        {
                            case "red":
                                if (amount > maxRed)
                                {
                                    maxRed = amount;
                                }
                                break;

                            case "green":
                                if (amount > maxGreen)
                                {
                                    maxGreen = amount;
                                }
                                break;

                            case "blue":
                                if (amount > maxBlue)
                                {
                                    maxBlue = amount;
                                }
                                break;
                        }
                    }

                    if (totalDraw > maxTotalDraw)
                    {
                        maxTotalDraw = totalDraw;
                    }
                }

                yield return new GameInfo(gameId, maxRed, maxGreen, maxBlue, maxTotalDraw);
            }
        }

        [GeneratedRegex(@"(\d+?) (blue|red|green)")]
        private static partial Regex MatchCubes();
    }
}
