using AdventOfCode2021.Day13;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day13Tests
    {
        private const string InputPath = "Day13Demo.txt";

        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 17;
            var actual = InputParser.ParseInput(InputPath).Calculate().First().Entries.Count();

            Assert.AreEqual(expected, actual);
        }
    }
}
