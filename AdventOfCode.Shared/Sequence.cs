using System.Collections;
using System.Collections.Immutable;

namespace AdventOfCode.Shared
{
    public class Sequence<T> : IReadOnlyList<T>
    {
        private readonly IEnumerable<T> input;
        private IImmutableList<T>? enumeration;

        public Sequence(IEnumerable<T> input)
        {
            this.input = input;
        }

        public int Count => Enumeration.Count;

        private IImmutableList<T> Enumeration => enumeration ??= input.ToImmutableList();

        public T this[int index] => Enumeration[index];

        public IEnumerator<T> GetEnumerator()
        {
            return Enumeration.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Enumeration.GetEnumerator();
        }
    }
}
