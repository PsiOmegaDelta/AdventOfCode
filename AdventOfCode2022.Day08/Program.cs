using AdventOfCode.Shared;
using AdventOfCode2022.Day08;

const string inputPath = "Day08Input.txt";
Console.WriteLine("2022 - Day 8");
var input = File.ReadLines(inputPath).ToSparsePlane(x => (int)char.GetNumericValue(x));
Console.WriteLine("Part One: " + input.CalculatePartOne());
Console.WriteLine("Part Two: " + input.CalculatePartTwo());
