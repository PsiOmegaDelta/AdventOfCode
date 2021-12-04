using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Day04
{
    public static class Program
    {
        public static int CalculatePartOne(string inputPath)
        {
            var (calledNumbers, boards) = AcquireInputs(inputPath);
            foreach (var calledNumber in calledNumbers)
            {
                var boardWon = false;
                foreach (var board in boards)
                {
                    boardWon = board.MarkNumber(calledNumber) || boardWon;
                }

                if (boardWon)
                {
                    var winningBoard = boards.Single(x => x.HasCompleteRowOrColumn);
                    return winningBoard.UnmarkedNumbers.Sum() * calledNumber;
                }
            }

            throw new Exception("No board won!");
        }

        public static int CalculatePartTwo(string inputPath)
        {
            var (calledNumbers, boards) = AcquireInputs(inputPath);
            foreach (var calledNumber in calledNumbers)
            {
                foreach (var board in boards)
                {
                    if (board.MarkNumber(calledNumber))
                    {
                        if (boards.Count == 1)
                        {
                            return boards[0].UnmarkedNumbers.Sum() * calledNumber;
                        }
                        else
                        {
                            boards = boards.Remove(board);
                        }
                    }
                }
            }

            throw new Exception("No board won!");
        }

        public static void Main()
        {
            // Based on how the task if phrased we assume that no more than 1 board wins for a given called number
            const string inputPath = "Day04Input.txt";
            Console.WriteLine("Part One: " + CalculatePartOne(inputPath));
            Console.WriteLine("Part Two: " + CalculatePartTwo(inputPath));
        }

        private static (IReadOnlyList<int> calledNumbers, IImmutableList<Board> boards) AcquireInputs(string input)
        {
            var inputLines = File.ReadLines(input);
            var calledNumbers = inputLines.Take(1).Single().Split(',').Select(x => int.Parse(x)).ToImmutableList();

            var boards = new List<Board>();
            IList<IEnumerable<NumberMarking>> rowsOfNumbers = new List<IEnumerable<NumberMarking>>();
            foreach (var inputLine in inputLines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    if (rowsOfNumbers.Count > 0)
                    {
                        boards.Add(new Board(rowsOfNumbers));
                        rowsOfNumbers.Clear();
                    }

                    continue;
                }

                rowsOfNumbers.Add(inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).Select(x => new NumberMarking(x)));
            }

            if (rowsOfNumbers.Count > 0)
            {
                boards.Add(new Board(rowsOfNumbers));
            }

            return (calledNumbers, boards.ToImmutableList());
        }
    }
}
