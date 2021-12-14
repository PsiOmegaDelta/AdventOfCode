namespace AdventOfCode2021.Day14
{
    public static class InputParser
    {
        public static (string, IReadOnlyDictionary<string, char> inserts) ParseInput(string inputPath)
        {
            using var asds = File.ReadLines(inputPath).GetEnumerator();
            asds.MoveNext();
            var template = asds.Current;
            asds.MoveNext();

            var inserts = new Dictionary<string, char>();
            while (asds.MoveNext())
            {
                var split = asds.Current.Split(" -> ");
                inserts.Add(split[0], split[1][0]);
            }

            return (template, inserts);
        }
    }
}
