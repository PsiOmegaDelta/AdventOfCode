using System.Numerics;

namespace AdventOfCode2021.Day16
{
    public interface IPackage
    {
        IReadOnlyList<IPackage> Packages { get; }

        int TypeId { get; }

        BigInteger Value { get; }

        int Version { get; }
    }
}
