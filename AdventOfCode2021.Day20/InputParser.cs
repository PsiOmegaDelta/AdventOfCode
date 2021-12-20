using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2021.Day20
{
    public static class InputParser
    {
        public static (IReadOnlySet<int> ImageEnhancementAlgoritm, SparsePlane<char> Image) ParseInput(this IEnumerable<string> input)
        {
            using var fileEnumerator = input.GetEnumerator();
            fileEnumerator.MoveNext();
            var imageEnhancementAlgoritm = fileEnumerator.Current.SelectIndex().Where(x => x.Element == '#').Select(x => x.Index).ToHashSet();

            fileEnumerator.MoveNext();

            var image = new SparsePlane<char>('.');
            for (var row = 0; fileEnumerator.MoveNext(); row++)
            {
                foreach (var (light, index) in fileEnumerator.Current.SelectIndex().Where(x => x.Element == '#'))
                {
                    image[index, row] = light;
                }
            }

            return (imageEnhancementAlgoritm, image);
        }
    }
}
