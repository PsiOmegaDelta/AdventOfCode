using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2022.Day07
{
    public static class Calculations
    {
        public static long CalculatePartOne(this Directory root, long maxSize)
        {
            var directorySizes = new Dictionary<Directory, long>();
            root.CalculateDirectorySizes(directorySizes);

            return directorySizes.Where(x => x.Value <= maxSize).Sum(x => x.Value);
        }

        public static long CalculatePartTwo(this Directory root, long maxSpace, long desiredSpace)
        {
            var directorySizes = new Dictionary<Directory, long>();
            root.CalculateDirectorySizes(directorySizes);

            var availableSpace = maxSpace - directorySizes[root];

            return directorySizes.Where(x => availableSpace + x.Value > desiredSpace).Min(x => x.Value);
        }

        private static void CalculateDirectorySizes(this Directory directory, IDictionary<Directory, long> directorySizes)
        {
            directorySizes.Add(directory, directory.Files.Sum(x => x.Size));
            foreach (var subdirectory in directory.Directories)
            {
                CalculateDirectorySizes(subdirectory, directorySizes);
                directorySizes[directory] += directorySizes[subdirectory];
            }
        }
    }
}
