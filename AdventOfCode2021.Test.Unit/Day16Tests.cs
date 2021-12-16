using AdventOfCode2021.Day16;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Test.Unit
{
    [TestClass]
    public class Day16Tests
    {
        [TestMethod]
        public void HexExamplesShallConvertToExpectedBinary()
        {
            var expectations = new Dictionary<string, string>
            {
                {"D2FE28", "110100101111111000101000" },
                {"38006F45291200", "00111000000000000110111101000101001010010001001000000000" },
                {"EE00D40C823060", "11101110000000001101010000001100100000100011000001100000" },
            };

            foreach (var (input, expected) in expectations)
            {
                Assert.AreEqual(expected, input.FromHexToBinary());
            }
        }

        [TestMethod]
        public void ParsingOfLengthType0OperatorExampleShallReturnExpectedResult()
        {
            const string? input = "00111000000000000110111101000101001010010001001000000000";
            const int expectedVersion = 1;
            const int expectedType = 6;
            const int expectedPackages = 2;

            var actual = input.ParseBinaryInput().Single();
            Assert.AreEqual(expectedVersion, actual.Version);
            Assert.AreEqual(expectedType, actual.TypeId);
            Assert.AreEqual(expectedPackages, actual.Packages.Count);
            Assert.AreEqual(10, actual.Packages[0].Value);
            Assert.AreEqual(20, actual.Packages[1].Value);
        }

        [TestMethod]
        public void ParsingOfLengthType1OperatorExampleShallReturnExpectedResult()
        {
            const string? input = "11101110000000001101010000001100100000100011000001100000";
            const int expectedVersion = 7;
            const int expectedType = 3;
            const int expectedPackages = 3;

            var actual = input.ParseBinaryInput().Single();
            Assert.AreEqual(expectedVersion, actual.Version);
            Assert.AreEqual(expectedType, actual.TypeId);
            Assert.AreEqual(expectedPackages, actual.Packages.Count);
            Assert.AreEqual(1, actual.Packages[0].Value);
            Assert.AreEqual(2, actual.Packages[1].Value);
            Assert.AreEqual(3, actual.Packages[2].Value);
        }

        [TestMethod]
        public void ParsingOfLiteralExampleShallReturnExpectedResult()
        {
            const string? input = "110100101111111000101000";
            const int expectedVersion = 6;
            const int expectedType = 4;
            const int expectedValue = 2021;
            const int expectedPackages = 0;

            var actual = input.ParseBinaryInput().Single();
            Assert.AreEqual(expectedVersion, actual.Version);
            Assert.AreEqual(expectedType, actual.TypeId);
            Assert.AreEqual(expectedValue, actual.Value);
            Assert.AreEqual(expectedPackages, actual.Packages.Count);
        }

        [TestMethod]
        public void PartOneDemoCalculationShallReturnExpectedResult()
        {
            var expectations = new Dictionary<string, int>
            {
                {"8A004A801A8002F478", 16 },
                {"620080001611562C8802118E34", 12 },
                {"C0015000016115A2E0802F182340", 23 },
                {"A0016C880162017C3686B18A3D4780", 31 },
            };

            foreach (var (input, expected) in expectations)
            {
                Assert.AreEqual(expected, input.FromHexToBinary().CalculatePartOne());
            }
        }

        [TestMethod]
        public void PartTwoDemoCalculationShallReturnExpectedResult()
        {
            var expectations = new Dictionary<string, int>
            {
                {"C200B40A82", 3 },
                {"04005AC33890", 54 },
                {"880086C3E88112", 7 },
                {"CE00C43D881120", 9 },
                {"D8005AC2A8F0", 1 },
                {"F600BC2D8F", 0 },
                {"9C005AC2F8F0", 0 },
                {"9C0141080250320F1802104A08", 1 },
            };

            foreach (var (input, expected) in expectations)
            {
                Assert.AreEqual(expected, input.FromHexToBinary().CalculatePartTwo());
            }
        }
    }
}
