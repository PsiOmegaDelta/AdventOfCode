using System.Collections.Immutable;
using System.Numerics;

namespace AdventOfCode2021.Day16
{
    public class LiteralPackage : IPackage
    {
        public LiteralPackage(int version, BigInteger value)
        {
            Version = version;
            Value = value;
        }

        public IReadOnlyList<IPackage> Packages => ImmutableList<IPackage>.Empty;

        public int TypeId => 4;

        public BigInteger Value { get; }

        public int Version { get; }
    }
}
