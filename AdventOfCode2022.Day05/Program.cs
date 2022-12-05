using AdventOfCode.Shared;
using AdventOfCode2022.Day05;

const string inputPath = "Day05Input.txt";
Console.WriteLine("2022 - Day 5");
var (crateStacks, relocationOrders) = File.ReadLines(inputPath).ParseInput();
Console.WriteLine("Part One: " + crateStacks.CalculatePartOne(relocationOrders));
Console.WriteLine("Part Two: " + crateStacks.CalculatePartTwo(relocationOrders));
