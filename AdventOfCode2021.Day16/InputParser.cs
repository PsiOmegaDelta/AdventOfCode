using AdventOfCode.Shared.Extensions;
using System.Text;

namespace AdventOfCode2021.Day16
{
    public static class InputParser
    {
        public static IEnumerable<IPackage> ParseBinaryInput(this string input, int packagesToResolve = int.MaxValue)
        {
            var enumerator = input.GetEnumerator();
            // We yield return each individual package instead of returning the whole thing, otherwise the enumerator is dispose before we can even begin
            foreach (var package in ParseBinaryInput(enumerator, packagesToResolve))
            {
                yield return package;
            }
        }

        private static IEnumerable<IPackage> ParseBinaryInput(this CharEnumerator enumerator, int packagesToResolve)
        {
            for (var resolvedPackages = 0; resolvedPackages < packagesToResolve; resolvedPackages++)
            {
                if (!enumerator.TryTake(3, out var versionChars) || !enumerator.TryTake(3, out var typeChars))
                {
                    break;
                }

                var version = versionChars.FromBinaryToInt();
                var typeId = typeChars.FromBinaryToInt();

                if (typeId == 4)
                {
                    char[] group;
                    var stringBuilder = new StringBuilder();
                    do
                    {
                        if (enumerator.TryTake(5, out var groupBinary))
                        {
                            group = groupBinary.ToArray();
                            stringBuilder.Append(group[1..]);
                        }
                        else
                        {
                            yield break;
                        }
                    } while (group[0] == '1');

                    var stringNumber = stringBuilder.ToString();
                    yield return new LiteralPackage(version, Convert.ToInt64(stringNumber, 2));
                }
                else
                {
                    var lengthTypeId = enumerator.Take(1).FromBinaryToInt();
                    if (lengthTypeId == 0)
                    {
                        if (enumerator.TryTake(15, out var subPackageBinary))
                        {
                            var subpackageLength = subPackageBinary.FromBinaryToInt();
                            var subpackageString = new string(enumerator.Take(subpackageLength).ToArray());
                            var subpackages = ParseBinaryInput(subpackageString);
                            yield return new OperatorPackage(version, typeId, subpackages);
                        }
                        else
                        {
                            yield break;
                        }
                    }
                    else
                    {
                        if (enumerator.TryTake(11, out var subPackageBinary))
                        {
                            var subpackageCount = subPackageBinary.FromBinaryToInt();
                            var subpackages = ParseBinaryInput(enumerator, subpackageCount);
                            yield return new OperatorPackage(version, typeId, subpackages);
                        }
                        else
                        {
                            yield break;
                        }
                    }
                }
            }
        }
    }
}
