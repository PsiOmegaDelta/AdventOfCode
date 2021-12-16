using AdventOfCode2015.Day11;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode2015.Test.Unit
{
    [TestClass]
    public class Day11Tests
    {
        [TestMethod]
        public void PartOneDemoCalculationsShallReturnExpectedResults()
        {
            var expectations = new Dictionary<string, string>
            {
                { "abcdefgh", "abcdffaa" },
                { "ghijklmn", "ghjaabcc" }
            };

            foreach (var (input, expected) in expectations)
            {
                Assert.AreEqual(expected, input.CalculatePartOne());
            }
        }
    }
}
