using AdventOfCode2021.Day09;
using AdventOfCode2021.Shared;

const string inputPath = "Day09Input.txt";
Console.WriteLine("Part One: " + PartOne.CalculateResult(InputParsers.ToIntArrays(File.ReadLines(inputPath))));
Console.WriteLine("Part Two: " + PartTwo.CalculateResult(InputParsers.ToIntArrays(File.ReadLines(inputPath))));
