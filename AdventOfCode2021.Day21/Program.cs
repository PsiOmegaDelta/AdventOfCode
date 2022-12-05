using AdventOfCode.Shared.Enumerations;
using AdventOfCode2021.Day21;

const string inputPath = "Day21Input.txt";
Console.WriteLine("2021 - Day 21");
Console.WriteLine("Part One: " + File.ReadLines(inputPath).ParseInput().CalculatePartOne(Dice.DeterministicD100()));
Console.WriteLine("Part Two: " + File.ReadLines(inputPath).ParseInput().CalculatePartTwo());
