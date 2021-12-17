using AdventOfCode.Shared.Extensions;
using System.Collections.Immutable;

namespace AdventOfCode2015.Day15
{
    public static class PartOne
    {
        // Playing around with separation of data and logic
        public static long CalculatePartOne(this IReadOnlyList<Ingredient> ingredients, int? caloryLimit = null)
        {
            var bestScore = 0L;
            foreach (var distribution in GenerateDistributions(ingredients.Count, 100))
            {
                var capacity = 0L;
                var durability = 0L;
                var flavor = 0L;
                var texture = 0L;
                var calories = 0L;
                foreach (var (ingredient, index) in ingredients.SelectIndex())
                {
                    var teaspoons = distribution[index];
                    capacity += teaspoons * ingredient.Capacity;
                    durability += teaspoons * ingredient.Durability;
                    flavor += teaspoons * ingredient.Flavor;
                    texture += teaspoons * ingredient.Texture;
                    calories += teaspoons * ingredient.Calories;
                }

                var score = Math.Max(capacity, 0) * Math.Max(durability, 0) * Math.Max(flavor, 0) * Math.Max(texture, 0);
                if (score > bestScore && (!caloryLimit.HasValue || calories == caloryLimit))
                {
                    bestScore = score;
                }
            }

            return bestScore;
        }

        private static IEnumerable<IReadOnlyList<long>> GenerateDistributions(int amount, long total)
        {
            if (amount > 1)
            {
                for (var i = 0L; i <= total; i++)
                {
                    var entries = ImmutableList.Create(i);
                    entries.Add(i);
                    foreach (var sublist in GenerateDistributions(amount - 1, total - i))
                    {
                        yield return entries.AddRange(sublist);
                    }
                }
            }
            else
            {
                yield return ImmutableList.Create(total);
            }
        }
    }
}
