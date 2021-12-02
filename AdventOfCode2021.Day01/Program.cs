using MoreLinq;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day01
{
    public static class Program
    {
        public static async Task Main()
        {
            var input = (await File.ReadAllLinesAsync("DayOneInput.txt")).Select(x => int.Parse(x)).ToList();
            Console.WriteLine("Part One: " + input.GetIncrementations());
            Console.WriteLine("Part Two: " + input.Window(3).Select(x => x.Sum()).GetIncrementations());
        }
    }
}
