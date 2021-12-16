using System.Collections.Immutable;

namespace AdventOfCode.Shared.Extensions
{
    public static class DictionaryExtensions
    {
        public static IEnumerable<IReadOnlyList<T>> AllPaths<T>(this IReadOnlyDictionary<T, IReadOnlyDictionary<T, int>> graph, T start, T end)
        {
            return graph.AllPaths(ImmutableList<T>.Empty, start, end).ToList();
        }

        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> add)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }

            return dictionary[key] = add(key);
        }

        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> getDefault)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }

            return getDefault(key);
        }

        public static IReadOnlyList<T> ReconstructPath<T>(this IDictionary<T, T> parentMap, T start, T end)
            where T : notnull
        {
            var path = new List<T>();
            T current = end;

            while (!Equals(current, start))
            {
                path.Add(current);
                current = parentMap[current];
            }

            path.Add(start);

            path.Reverse();
            return path;
        }

        private static IEnumerable<IReadOnlyList<T>> AllPaths<T>(
            this IReadOnlyDictionary<T, IReadOnlyDictionary<T, int>> graph,
            IImmutableList<T> visitedNodes,
            T currentNode,
            T endNode)
        {
            visitedNodes = visitedNodes.Add(currentNode);
            var neighbours = graph[currentNode].Keys.Except(visitedNodes).ToList();
            if (visitedNodes.Count == graph.Count - 1 && neighbours.Count == 1 && Equals(neighbours[0], endNode))
            {
                yield return visitedNodes.Add(endNode);
            }
            else
            {
                foreach (var node in neighbours.Except(endNode))
                {
                    foreach (var path in AllPaths(graph, visitedNodes, node, endNode))
                    {
                        yield return path;
                    }
                }
            }
        }
    }
}
