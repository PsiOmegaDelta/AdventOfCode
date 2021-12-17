using AdventOfCode.Shared;
using AdventOfCode2021.Day09;

const string inputPath = "Day09Input.txt";
Console.WriteLine("Part One: " + PartOne.CalculatePartOne(File.ReadLines(inputPath).ToIntArrays()));
Console.WriteLine("Part Two: " + PartTwo.CalculatePartTwo(File.ReadLines(inputPath).ToIntArrays()));
