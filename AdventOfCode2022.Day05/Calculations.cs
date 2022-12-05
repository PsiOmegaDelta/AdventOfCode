using AdventOfCode.Shared;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode2022.Day05
{
    public static class Calculations
    {
        public static string CalculatePartOne(this IReadOnlyDictionary<int, IImmutableStack<char>> crateStacks, Sequence<RelocationOrder> relocationOrders)
        {
            return MoveCrates(crateStacks, relocationOrders, RelocateCrates);

            static (IImmutableStack<char>, IImmutableStack<char>) RelocateCrates(IImmutableStack<char> sourceStack, IImmutableStack<char> targetStack, int amount)
            {
                for (int i = 0; i < amount; i++)
                {
                    var movedCrate = sourceStack.Peek();
                    sourceStack = sourceStack.Pop();
                    targetStack = targetStack.Push(movedCrate);
                }

                return (sourceStack, targetStack);
            }
        }

        public static string CalculatePartTwo(this IReadOnlyDictionary<int, IImmutableStack<char>> crateStacks, Sequence<RelocationOrder> relocationOrders)
        {
            return MoveCrates(crateStacks, relocationOrders, RelocateCrates);

            static (IImmutableStack<char>, IImmutableStack<char>) RelocateCrates(IImmutableStack<char> sourceStack, IImmutableStack<char> targetStack, int amount)
            {
                var crates = new char[amount];
                for (int i = 0; i < amount; i++)
                {
                    crates[i] = sourceStack.Peek();
                    sourceStack = sourceStack.Pop();
                }

                for (int i = crates.Length - 1; i >= 0; i--)
                {
                    targetStack = targetStack.Push(crates[i]);
                }

                return (sourceStack, targetStack);
            }
        }

        private static string MoveCrates(
            IReadOnlyDictionary<int, IImmutableStack<char>> crateStacks,
            Sequence<RelocationOrder> relocationOrders,
            Func<IImmutableStack<char>, IImmutableStack<char>, int, (IImmutableStack<char> SourceStack, IImmutableStack<char> TargetStack)> relocateCrates)
        {
            var scopedCrateStacks = crateStacks.ToDictionary(x => x.Key, x => x.Value);
            foreach (var relocationOrder in relocationOrders)
            {
                var sourceStack = scopedCrateStacks[relocationOrder.SourceStack];
                var targetStack = scopedCrateStacks[relocationOrder.TargetStack];

                (sourceStack, targetStack) = relocateCrates(sourceStack, targetStack, relocationOrder.Amount);
                scopedCrateStacks[relocationOrder.SourceStack] = sourceStack;
                scopedCrateStacks[relocationOrder.TargetStack] = targetStack;
            }

            var topCrateOfEachStack = scopedCrateStacks.OrderBy(x => x.Key).Select(x => x.Value.Peek()).ToArray();
            return new string(topCrateOfEachStack);
        }
    }
}
