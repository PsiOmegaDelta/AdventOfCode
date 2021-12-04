using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day04
{
    public class Board
    {
        private readonly NumberMarking[][] numbers;

        public Board(IEnumerable<IEnumerable<NumberMarking>> numbers)
        {
            this.numbers = numbers.Select(x => x.ToArray()).ToArray();
        }

        public bool HasCompleteRowOrColumn { get; private set; }

        public IEnumerable<int> UnmarkedNumbers => numbers.SelectMany(x => x).Where(x => !x.Marked).Select(x => x.Number);

        // Returns true if marking this cell resulted in a complete row or column
        public bool MarkNumber(int number)
        {
            for (var rowIndex = 0; rowIndex < numbers.Length; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < numbers[rowIndex].Length; columnIndex++)
                {
                    if (numbers[rowIndex][columnIndex].Number == number)
                    {
                        numbers[rowIndex][columnIndex].Marked = true;
                        return HasCompleteRowOrColumn = CheckCompletion(rowIndex, columnIndex);
                    }
                }
            }

            return false;
        }

        private bool CheckCompletion(int row, int column)
        {
            for (var rowIndex = 0; rowIndex < numbers.Length; rowIndex++)
            {
                if (!numbers[rowIndex][column].Marked)
                {
                    for (var columnIndex = 0; columnIndex < numbers[row].Length; columnIndex++)
                    {
                        if (!numbers[row][columnIndex].Marked)
                        {
                            return false;
                        }
                    }

                    break;
                }
            }

            return true;
        }
    }
}
