using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2015.Day19
{
    public static class Calculations
    {
        public static IEnumerable<long> CalculatePartOne(IReadOnlyList<(string, string)> transformations, IReadOnlyList<string> molecules)
        {
            foreach (var molecule in molecules)
            {
                yield return GetVariations(transformations, molecule, int.MaxValue).Count;
            }
        }

        public static IEnumerable<long> CalculatePartTwo(IReadOnlyList<(string Source, string Target)> transformations, IReadOnlyList<string> molecules)
        {
            foreach (var targetMolecule in molecules)
            {
                yield return IterationsUntilMatch("e", targetMolecule, 0, new HashSet<string>()).Min();
            }

            IEnumerable<long> IterationsUntilMatch(
                string currentMolecule,
                string targetMolecule,
                long iterations,
                HashSet<string> checkedMolecules)
            {
                // We don't have any transformations which result in a shorter molecule
                if (currentMolecule.Length > targetMolecule.Length)
                {
                    yield break;
                }

                if (currentMolecule.Equals(targetMolecule))
                {
                    yield return iterations;
                    yield break;
                }

                checkedMolecules.Add(currentMolecule);
                foreach (var variation in GetVariations(transformations, currentMolecule, targetMolecule.Length))
                {
                    if (checkedMolecules.Contains(variation))
                    {
                        continue;
                    }

                    checkedMolecules.Add(variation);
                    foreach (var iter in IterationsUntilMatch(variation, targetMolecule, iterations + 1, checkedMolecules))
                    {
                        yield return iter;
                    }
                }
            }
        }

        private static HashSet<string> GetVariations(IReadOnlyList<(string, string)> transformations, string molecule, int maxLength)
        {
            var variations = new HashSet<string>();
            foreach (var (source, target) in transformations)
            {
                if (molecule.Length + target.Length - source.Length > maxLength)
                {
                    continue;
                }

                for (int i = 0; i + source.Length - 1 < molecule.Length; i++)
                {
                    // String operations like these are too slow at scale
                    var subset = molecule.Substring(i, source.Length);
                    if (subset == source)
                    {
                        variations.Add(molecule.Remove(i, source.Length).Insert(i, target));
                    }
                }
            }

            return variations;
        }
    }
}
