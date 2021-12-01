using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2021.DayOne
{
    public static class Program
    {
        public static async Task Main()
        {
            var input = (await File.ReadAllLinesAsync("DayOneInput.txt")).Select(x => int.Parse(x)).ToList();
            Console.WriteLine("Part One: " + input.GetNumberOfIncrements());
            Console.WriteLine("Part Two: " + input.SumGroups(3).GetNumberOfIncrements());
        }
    }
}
