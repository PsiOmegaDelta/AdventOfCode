using System.Collections.Immutable;
using System.Numerics;
using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2021.Day16
{
    public class OperatorPackage : IPackage
    {
        public OperatorPackage(int version, int typeId, IEnumerable<IPackage> packages)
        {
            Version = version;
            TypeId = typeId;
            Packages = packages.ToImmutableList();
        }

        public IReadOnlyList<IPackage> Packages { get; }

        public int TypeId { get; }

        public BigInteger Value => Calculate();

        public int Version { get; }

        private BigInteger Calculate()
        {
            return TypeId switch
            {
                0 => Packages.Sum(x => x.Value),
                1 => Packages.Product(x => x.Value),
                2 => Packages.Min(x => x.Value),
                3 => Packages.Max(x => x.Value),
                5 => Packages[0].Value > Packages[1].Value ? BigInteger.One : BigInteger.Zero,
                6 => Packages[0].Value < Packages[1].Value ? BigInteger.One : BigInteger.Zero,
                7 => Packages[0].Value == Packages[1].Value ? BigInteger.One : BigInteger.Zero,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
