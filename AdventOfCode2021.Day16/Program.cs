using AdventOfCode2021.Day16;

const string inputPath = "Day16Input.txt";
Console.WriteLine("2021 - Day 16");
Console.WriteLine("Part One: " + File.ReadAllText(inputPath).FromHexToBinary().CalculatePartOne());
Console.WriteLine("Part Two: " + File.ReadAllText(inputPath).FromHexToBinary().CalculatePartTwo());
