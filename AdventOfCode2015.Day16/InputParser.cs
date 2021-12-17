using System.Text.RegularExpressions;

namespace AdventOfCode2015.Day16
{
    public static class InputParser
    {
        public static IEnumerable<Sue> ParseInput(this IEnumerable<string> inputs)
        {
            var sueRegex = new Regex(@"^Sue (\d+): (.*)$");
            foreach (var input in inputs)
            {
                var sueMatch = sueRegex.Match(input);
                var id = int.Parse(sueMatch.Groups[1].Value);
                var sueSplit = sueMatch.Groups[2].Value.Split(", ");

                int? children = null;
                int? cats = null;
                int? samoyeds = null;
                int? pomeranians = null;
                int? akitas = null;
                int? vizslas = null;
                int? goldfish = null;
                int? trees = null;
                int? cars = null;
                int? perfumes = null;
                foreach (var entry in sueSplit)
                {
                    var split = entry.Split(": ");
                    var amount = int.Parse(split[1]);
                    switch (split[0])
                    {
                        case "children":
                            children = amount;
                            break;

                        case "cats":
                            cats = amount;
                            break;

                        case "samoyeds":
                            samoyeds = amount;
                            break;

                        case "pomeranians":
                            pomeranians = amount;
                            break;

                        case "akitas":
                            akitas = amount;
                            break;

                        case "vizslas":
                            vizslas = amount;
                            break;

                        case "goldfish":
                            goldfish = amount;
                            break;

                        case "trees":
                            trees = amount;
                            break;

                        case "cars":
                            cars = amount;
                            break;

                        case "perfumes":
                            perfumes = amount;
                            break;

                        default:
                            throw new InvalidOperationException();
                    }
                }

                yield return new Sue(
                    id,
                    children,
                    cats,
                    samoyeds,
                    pomeranians,
                    akitas,
                    vizslas,
                    goldfish,
                    trees,
                    cars,
                    perfumes);
            }
        }
    }
}
