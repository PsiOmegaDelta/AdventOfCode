using AdventOfCode2015.Day07;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2015.Test.Unit
{
    [TestClass]
    public class Day07Tests
    {
        private const string InputPath = "Day07Demo.txt";

        [TestMethod]
        public void PartOneDemoCalculationsShallReturnExpectedResults()
        {
            var expectations = new Dictionary<string, int>
            {
                { "d", 72 },
                { "e", 507 },
                { "f", 492 },
                { "g", 114 },
                { "h", 65412 },
                { "i", 65079 },
                { "x", 123 },
                { "y", 456 },
            };

            var setup = File.ReadLines(InputPath).ParseInput().ToDictionary(x => x.Name);
            var actual = setup.ToDictionary(x => x.Key, x => x.Value.Resolve(setup));

            Assert.AreEqual(expectations.Count, actual.Count);
            foreach (var (key, expected) in expectations)
            {
                Assert.AreEqual(expected, actual[key]);
            }
        }
    }
}
