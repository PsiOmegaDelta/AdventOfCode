using System.Text.RegularExpressions;

namespace AdventOfCode2015.Day07
{
    public class WireSetup
    {
        private static readonly IReadOnlyDictionary<string, Func<ushort, ushort, ushort>> operands = new Dictionary<string, Func<ushort, ushort, ushort>>
        {
            { "AND", (l, r) => (ushort)(l & r) },
            { "OR", (l, r) => (ushort)(l | r) },
            { "LSHIFT", (l, r) => (ushort)(l << r) },
            { "RSHIFT", (l, r) => (ushort)(l >> r) },
        };

        private static readonly Regex patternRegex = new("^(.+) (.+) (.+)", RegexOptions.Compiled);
        private readonly string setup;

        public WireSetup(string name, string setup)
        {
            Name = name;
            this.setup = setup;
        }

        public string Name { get; }

        public ushort Resolve(IReadOnlyDictionary<string, WireSetup> setups)
        {
            return Resolve(setups, new Dictionary<WireSetup, ushort>());
        }

        private ushort Resolve(IReadOnlyDictionary<string, WireSetup> setups, IDictionary<WireSetup, ushort> resolutions)
        {
            if (resolutions.TryGetValue(this, out var resolution))
            {
                return resolution;
            }

            if (ushort.TryParse(setup, out var constant))
            {
                resolution = constant;
            }
            else if (setup.StartsWith("NOT "))
            {
                var wire = setup[4..];
                resolution = (ushort)~setups[wire].Resolve(setups, resolutions);
            }
            else if (setups.ContainsKey(setup))
            {
                resolution = setups[setup].Resolve(setups, resolutions);
            }
            else
            {
                var match = patternRegex.Match(setup);
                var operand = operands[match.Groups[2].Value];

                var leftEntry = match.Groups[1].Value;
                if (!ushort.TryParse(leftEntry, out var left))
                {
                    left = setups[leftEntry].Resolve(setups, resolutions);
                }

                var rightEntry = match.Groups[3].Value;
                if (!ushort.TryParse(rightEntry, out var right))
                {
                    right = setups[rightEntry].Resolve(setups, resolutions);
                }

                resolution = operand(left, right);
            }

            resolutions.Add(this, resolution);
            return resolution;
        }
    }
}
