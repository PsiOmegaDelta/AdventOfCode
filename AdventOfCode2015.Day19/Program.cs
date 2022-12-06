using AdventOfCode2015.Day19;

const string inputPath = "Day19Input.txt";
Console.WriteLine("2015 - Day 19");

var (transformations, input) = File.ReadLines(inputPath).ParseInput();
Console.WriteLine("Part One: " + Calculations.CalculatePartOne(transformations, input).Single());
Console.WriteLine("Part Two: " + Calculations.CalculatePartTwo(transformations, input).Single());
