using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2022.Day08
{
    public static class Calculations
    {
        public static long CalculatePartOneIncorrectly(this SparsePlane<int> trees)
        {
            var visibleTrees = trees.Entries
                .Where(x => x.Coordinate.X == trees.MinX || x.Coordinate.X == trees.MaxX || x.Coordinate.Y == trees.MinY || x.Coordinate.Y == trees.MaxY)
                .ToHashSet();
            var checkedTrees = visibleTrees.ToHashSet();
            var candidateTrees = trees.ExplicitCardinalNeighbours(checkedTrees).Except(checkedTrees).ToHashSet();

            while (candidateTrees.Count > 0)
            {
                var newCandidates = new HashSet<Point2D<int>>();
                foreach (var candidate in candidateTrees)
                {
                    checkedTrees.Add(candidate);
                    var neighbours = trees.ExplicitCardinalNeighbours(candidate);
                    if (visibleTrees.Intersect(neighbours).Any(x => x.Entry < candidate.Entry))
                    {
                        visibleTrees.Add(candidate);
                        newCandidates.AddRange(neighbours.Except(checkedTrees));
                    }
                }

                candidateTrees = newCandidates;
            }

            return visibleTrees.Count;
        }

        public static long CalculatePartTwo(this SparsePlane<int> trees)
        {
            return 0;
        }
    }
}
