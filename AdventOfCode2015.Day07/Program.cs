using AdventOfCode2015.Day07;
using System.Collections.Immutable;

const string inputPath = "Day07Input.txt";
Console.WriteLine("2015 - Day 7");
var wireSetups = File.ReadLines(inputPath).ParseInput().ToImmutableDictionary(x => x.Name);
var partOneSolution = wireSetups["a"].Resolve(wireSetups);

Console.WriteLine("Part One: " + partOneSolution);
Console.WriteLine("Part Two: " + (wireSetups = wireSetups.SetItem("b", new WireSetup("b", partOneSolution.ToString())))["a"].Resolve(wireSetups));
