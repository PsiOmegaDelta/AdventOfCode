using AdventOfCode.Shared;
using AdventOfCode2021.Day09;

const string inputPath = "Day09Input.txt";
Console.WriteLine("Part One: " + PartOne.CalculateResult(File.ReadLines(inputPath).ToIntArrays()));
Console.WriteLine("Part Two: " + PartTwo.CalculateResult(File.ReadLines(inputPath).ToIntArrays()));
