using AdventOfCode2015.Day10;

Console.WriteLine("2015 - Day 10");
Console.WriteLine("Part One: " + Enumerable.Range(0, 40).Aggregate("3113322113", (x, _) => x.LookAndSay()).Length);
Console.WriteLine("Part Two: " + Enumerable.Range(0, 50).Aggregate("3113322113", (x, _) => x.LookAndSay()).Length);
