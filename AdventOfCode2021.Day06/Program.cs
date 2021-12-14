using AdventOfCode2021.Day06;

const string inputPath = "Day06Input.txt";
Console.WriteLine("Part One: " + await PartOne.CalculateResult(inputPath, 80).ConfigureAwait(false));
Console.WriteLine("Part Two: " + await PartTwo.CalculateResult(inputPath, 256).ConfigureAwait(false));
