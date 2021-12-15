using AdventOfCode.Shared.Extensions;
using AdventOfCode2015.Day05;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode2015.Test.Unit
{
    [TestClass]
    public class Day05Tests
    {
        [TestMethod]
        public void DemoExamplesShallReturnExpectedResults()
        {
            var examples = new Dictionary<string, long>
            {
                { "qjhvhtzxzqqjkmpb", 1 },
                { "xxyxx", 1 },
                { "uurcxstgmygtbstg", 0 },
                { "ieodomkazucvgmuy", 0 }
            };

            foreach (var (example, expected) in examples)
            {
                Assert.AreEqual(expected, example.ToEnumerable().CalculatePartTwo());
            }
        }
    }
}
