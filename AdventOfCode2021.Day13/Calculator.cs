using AdventOfCode2021.Shared;

namespace AdventOfCode2021.Day13
{
    public static class Calculator
    {
        public static IEnumerable<SparsePlane<char>> Calculate(this (SparsePlane<char> Matrix, IEnumerable<(char, int)> Folds) input)
        {
            foreach ((char axis, int line) in input.Folds)
            {
                var newPlane = new SparsePlane<char>(input.Matrix.DefaultWhenUnset);

                if (axis == 'x')
                {
                    foreach (var entry in input.Matrix.Entries)
                    {
                        if (entry.Coordinate.X < line)
                        {
                            newPlane[entry.Coordinate] = '#';
                        }
                        else if (entry.Coordinate.X > line)
                        {
                            newPlane[entry.Coordinate with { X = entry.Coordinate.X - (2 * (entry.Coordinate.X - line)) }] = '#';
                        }
                    }
                }
                else
                {
                    foreach (var entry in input.Matrix.Entries)
                    {
                        if (entry.Coordinate.Y < line)
                        {
                            newPlane[entry.Coordinate] = '#';
                        }
                        else if (entry.Coordinate.Y > line)
                        {
                            var newCoordinate = entry.Coordinate with { Y = entry.Coordinate.Y - (2 * (entry.Coordinate.Y - line)) };
                            newPlane[newCoordinate] = '#';
                        }
                    }
                }

                input.Matrix = newPlane;
                yield return newPlane;
            }
        }
    }
}
