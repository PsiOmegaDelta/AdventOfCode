using AdventOfCode.Shared;

namespace AdventOfCode2022.Day08
{
    public static class Calculations
    {
        public static long CalculatePartOne(this SparsePlane<int?> trees)
        {
            return trees.LongCount(CanBeSeen);

            bool CanBeSeen(Point2D<int?> tree)
            {
                for (var x = tree.Coordinate.X - 1; x >= trees.MinX - 1; x--)
                {
                    var neighbourHeight = trees[x, tree.Coordinate.Y];
                    if (neighbourHeight == null)
                    {
                        return true;
                    }

                    if (neighbourHeight >= tree.Entry)
                    {
                        break;
                    }
                }

                for (var x = tree.Coordinate.X + 1; x <= trees.MaxX + 1; x++)
                {
                    var neighbourHeight = trees[x, tree.Coordinate.Y];
                    if (neighbourHeight == null)
                    {
                        return true;
                    }

                    if (neighbourHeight >= tree.Entry)
                    {
                        break;
                    }
                }

                for (var y = tree.Coordinate.Y - 1; y >= trees.MinY - 1; y--)
                {
                    var neighbourHeight = trees[tree.Coordinate.X, y];
                    if (neighbourHeight == null)
                    {
                        return true;
                    }

                    if (neighbourHeight >= tree.Entry)
                    {
                        break;
                    }
                }

                for (var y = tree.Coordinate.Y + 1; y <= trees.MaxY + 1; y++)
                {
                    var neighbourHeight = trees[tree.Coordinate.X, y];
                    if (neighbourHeight == null)
                    {
                        return true;
                    }

                    if (neighbourHeight >= tree.Entry)
                    {
                        break;
                    }
                }

                return false;
            }
        }

        public static long CalculatePartTwo(this SparsePlane<int?> trees)
        {
            return trees.Max(ScenicScore);

            long ScenicScore(Point2D<int?> tree)
            {
                var scenicScore = 1;

                var directionScore = 0;
                for (var x = tree.Coordinate.X - 1; x >= trees.MinX - 1; x--)
                {
                    var neighbourHeight = trees[x, tree.Coordinate.Y];
                    directionScore = neighbourHeight == null ? directionScore : directionScore + 1;

                    if (neighbourHeight == null || neighbourHeight >= tree.Entry)
                    {
                        scenicScore *= directionScore;
                        break;
                    }
                }

                directionScore = 0;
                for (var x = tree.Coordinate.X + 1; x <= trees.MaxX + 1; x++)
                {
                    var neighbourHeight = trees[x, tree.Coordinate.Y];
                    directionScore = neighbourHeight == null ? directionScore : directionScore + 1;

                    if (neighbourHeight == null || neighbourHeight >= tree.Entry)
                    {
                        scenicScore *= directionScore;
                        break;
                    }
                }

                directionScore = 0;
                for (var y = tree.Coordinate.Y - 1; y >= trees.MinY - 1; y--)
                {
                    var neighbourHeight = trees[tree.Coordinate.X, y];
                    directionScore = neighbourHeight == null ? directionScore : directionScore + 1;

                    if (neighbourHeight == null || neighbourHeight >= tree.Entry)
                    {
                        scenicScore *= directionScore;
                        break;
                    }
                }

                directionScore = 0;
                for (var y = tree.Coordinate.Y + 1; y <= trees.MaxY + 1; y++)
                {
                    var neighbourHeight = trees[tree.Coordinate.X, y];
                    directionScore = neighbourHeight == null ? directionScore : directionScore + 1;

                    if (neighbourHeight == null || neighbourHeight >= tree.Entry)
                    {
                        scenicScore *= directionScore;
                        break;
                    }
                }

                return scenicScore;
            }
        }
    }
}
