using AdventOfCode.Shared;

namespace AdventOfCode2015.Day16
{
    public static class PartOne
    {
        public static int CalculatePartOne(this Sequence<Sue> inputs, Sue desiredSue)
        {
            return inputs.Single(sue => IsMatch(sue, desiredSue)).Id;

            static bool IsMatch(Sue first, Sue second)
            {
                if (first.Akitas.HasValue && first.Akitas != second.Akitas)
                {
                    return false;
                }

                if (first.Cars.HasValue && first.Cars != second.Cars)
                {
                    return false;
                }

                if (first.Cats.HasValue && first.Cats != second.Cats)
                {
                    return false;
                }

                if (first.Children.HasValue && first.Children != second.Children)
                {
                    return false;
                }
                if (first.Goldfish.HasValue && first.Goldfish != second.Goldfish)
                {
                    return false;
                }

                if (first.Perfumes.HasValue && first.Perfumes != second.Perfumes)
                {
                    return false;
                }

                if (first.Pomeranians.HasValue && first.Pomeranians != second.Pomeranians)
                {
                    return false;
                }

                if (first.Samoyeds.HasValue && first.Samoyeds != second.Samoyeds)
                {
                    return false;
                }

                if (first.Trees.HasValue && first.Trees != second.Trees)
                {
                    return false;
                }

                if (first.Vizslas.HasValue && first.Vizslas != second.Vizslas)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
