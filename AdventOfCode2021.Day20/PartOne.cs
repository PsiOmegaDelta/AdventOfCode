using AdventOfCode.Shared;
using System.Text;

namespace AdventOfCode2021.Day20
{
    public static class PartOne
    {
        public static int CalculatePartOne(this (IReadOnlySet<int> Algorithm, SparsePlane<char> Image) input, int steps)
        {
            var considerTheVoid = input.Algorithm.Contains(0);
            for (int step = 0; step < steps; step++)
            {
                var careAboutTheVoid = considerTheVoid && ((step & 1) == 1);
                var newInput = new SparsePlane<char>(input.Image.DefaultWhenUnset);
                for (var x = (input.Image.MinX ?? 0) - 1; x <= input.Image.MaxX + 1; x++)
                {
                    for (var y = (input.Image.MinY ?? 0) - 1; y <= input.Image.MaxY + 1; y++)
                    {
                        var enhancementIndex = input.Image.EnhanceIndex(x, y, careAboutTheVoid);
                        if (input.Algorithm.Contains(enhancementIndex))
                        {
                            newInput[x, y] = '#';
                        }
                    }
                }

                input.Image = newInput;
            }

            return input.Image.ExplicitEntries.Count();
        }

        private static IEnumerable<T?> Block<T>(this SparsePlane<T> input, int x, int y, bool checkForVoid, T voidValue)
        {
            for (int outy = y - 1; outy <= y + 1; outy++)
            {
                for (int outx = x - 1; outx <= x + 1; outx++)
                {
                    if (checkForVoid && !(outy >= input.MinY && outy <= input.MaxY && outx >= input.MinX && outx <= input.MaxX))
                    {
                        yield return voidValue;
                    }
                    else
                    {
                        yield return input[outx, outy];
                    }
                }
            }
        }

        private static int EnhanceIndex(this SparsePlane<char> input, int x, int y, bool careAboutTheVoid)
        {
            var stringBuilder = new StringBuilder();
            foreach (var neighour in input.Block(x, y, careAboutTheVoid, '#'))
            {
                stringBuilder.Append(neighour == '#' ? 1 : 0);
            }

            var binaryString = stringBuilder.ToString();
            return Convert.ToInt32(binaryString, 2);
        }
    }
}
