using AdventOfCode2015.Day09;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2015.Test.Unit
{
    [TestClass]
    public class Day09Tests
    {
        private const string InputPath = "Day09Demo.txt";

        [TestMethod]
        public void InputParserShallBuildExpectedGraph()
        {
            const int expectedCount = 3;
            var distances = new List<(string, string, int)>
            {
                ("London", "Dublin", 464),
                ("London", "Belfast", 518),
                ("Dublin", "Belfast", 141)
            };

            var actual = File.ReadLines(InputPath).ParseInput();
            Assert.AreEqual(expectedCount, actual.Count);
            foreach (var (one, two, distance) in distances)
            {
                Assert.AreEqual(distance, actual[one][two]);
                Assert.AreEqual(distance, actual[two][one]);
            }
        }

        [TestMethod]
        public void PartOneDemoCalculationsShallReturnExpectedResults()
        {
            const int expected = 605;
            var actual = File.ReadLines(InputPath).CalculatePartOne();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationsShallReturnExpectedResults()
        {
            const int expected = 982;
            var actual = File.ReadLines(InputPath).CalculatePartTwo();

            Assert.AreEqual(expected, actual);
        }
    }
}
