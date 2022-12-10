using AdventOfCode.Shared;

namespace AdventOfCode2022.Day08
{
    public static class Calculations
    {
        public static long CalculatePartOne(this SparsePlane<int?> trees)
        {
            var visibleTrees = trees.Where(CanBeSeen).ToList();
            return visibleTrees.LongCount();

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
            return 0;
        }
    }
}
