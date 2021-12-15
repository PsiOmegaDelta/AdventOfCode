using AdventOfCode2015.Day06;

const string inputPath = "Day06Input.txt";
Console.WriteLine("2015 - Day 6");
Console.WriteLine("Part One: " + File.ReadLines(inputPath).BoolParseInput().Aggregate(UseAllTheMemory<bool>(), (x, y) => y(x)).Sum(x => x.Count(y => y)));
Console.WriteLine("Part Two: " + File.ReadLines(inputPath).IntParseInput().Aggregate(UseAllTheMemory<int>(), (x, y) => y(x)).Sum(x => x.Sum()));

static T[][] UseAllTheMemory<T>()
{
    var matrix = new T[1000][];
    for (int i = 0; i < matrix.Length; i++)
    {
        matrix[i] = new T[1000];
    }

    return matrix;
}
