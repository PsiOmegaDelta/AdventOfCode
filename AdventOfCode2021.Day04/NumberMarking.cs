namespace AdventOfCode2021.Day04
{
    public struct NumberMarking
    {
        public NumberMarking(int number)
        {
            Marked = false;
            Number = number;
        }

        public bool Marked { get; set; }

        public int Number { get; }
    }
}
