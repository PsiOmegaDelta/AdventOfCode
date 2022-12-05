using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day05
{
    public static partial class InputParser
    {
        private static readonly Regex relocationOrderRegex = RelocationOrderRegex();

        private enum ParseMode
        {
            Stacks,
            RelocationOrders,
        }

        public static (IReadOnlyDictionary<int, IImmutableStack<char>> CrateStacks, Sequence<RelocationOrder> RelocationOrders) ParseInput(
            this IEnumerable<string> input)
        {
            var inputEnumerator = input.GetEnumerator();
            var stacks = new Dictionary<int, List<char>>();
            while (inputEnumerator.MoveNext())
            {
                var line = inputEnumerator.Current;
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                line.Chunk(4)
                    .Select((x, index) => (Char: x[1], Index: index + 1))
                    .Where(x => x.Char != ' ' && !char.IsDigit(x.Char))
                    .ForEach(x => stacks.GetOrAdd(x.Index, _ => new List<char>()).Insert(0, x.Char));
            }

            return (
                stacks.ToDictionary(x => x.Key, x => (IImmutableStack<char>)ImmutableStack.Create<char>(x.Value.ToArray())).AsReadOnly(),
                new Sequence<RelocationOrder>(EnumerateRemainingInput()));

            IEnumerable<RelocationOrder> EnumerateRemainingInput()
            {
                while (inputEnumerator.MoveNext())
                {
                    var match = relocationOrderRegex.Match(inputEnumerator.Current);
                    var source = int.Parse(match.Groups[2].Value);
                    var target = int.Parse(match.Groups[3].Value);
                    var amount = int.Parse(match.Groups[1].Value);
                    yield return new RelocationOrder(
                        source,
                        target,
                        amount);
                }

                inputEnumerator.Dispose();
            }
        }

        [GeneratedRegex("^move (\\d+?) from (\\d+?) to (\\d+?)$", RegexOptions.Compiled)]
        private static partial Regex RelocationOrderRegex();
    }
}
