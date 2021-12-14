using AdventOfCode2021.Day04;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day04Tests
    {
        [TestMethod]
        public void BoardShallReturnTrueWhenMarkingFullColumn()
        {
            var cells = new List<IList<NumberMarking>>
            {
                new List<NumberMarking>
                {
                    new NumberMarking(1), new NumberMarking(2)
                },
                new List<NumberMarking>
                {
                    new NumberMarking(3), new NumberMarking(4)
                }
            };

            var board = new Board(cells);

            Assert.IsFalse(board.MarkNumber(2));
            Assert.IsTrue(board.MarkNumber(4));
        }

        [TestMethod]
        public void BoardShallReturnTrueWhenMarkingFullRow()
        {
            var cells = new List<IList<NumberMarking>>
            {
                new List<NumberMarking>
                {
                    new NumberMarking(1), new NumberMarking(2)
                },
                new List<NumberMarking>
                {
                    new NumberMarking(3), new NumberMarking(4)
                }
            };
            var board = new Board(cells);

            Assert.IsFalse(board.MarkNumber(3));
            Assert.IsTrue(board.MarkNumber(4));
        }

        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 4512;
            var actual = Program.CalculatePartOne("Day04Demo.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResult()
        {
            const int expected = 1924;
            var actual = Program.CalculatePartTwo("Day04Demo.txt");

            Assert.AreEqual(expected, actual);
        }
    }
}
