using AdventOfCode2021.Day13;

const string inputPath = "Day13Input.txt";
Console.WriteLine("Part One: " + InputParser.ParseInput(inputPath).Calculate().First().Entries.Count());
Console.WriteLine("Part Two: " + Environment.NewLine + InputParser.ParseInput(inputPath).Calculate().Last());
