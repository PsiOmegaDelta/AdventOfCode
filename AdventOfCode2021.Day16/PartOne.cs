namespace AdventOfCode2021.Day16
{
    public static class PartOne
    {
        public static long CalculatePartOne(this string binaryInput)
        {
            return binaryInput.ParseBinaryInput().VersionNumbers(0);
        }

        private static long VersionNumbers(this IEnumerable<IPackage> packages, long totalVersion)
        {
            var enumeratedPackages = packages.ToList();
            totalVersion += enumeratedPackages.Sum(x => x.Version);

            var children = enumeratedPackages.SelectMany(x => x.Packages).ToList();
            if (children.Count == 0)
            {
                return totalVersion;
            }

            return VersionNumbers(children, totalVersion);
        }
    }
}
