using AdventOfCode2022.Day07.Commands;

namespace AdventOfCode2022.Day07
{
    public static class InputParser
    {
        private static readonly Lazy<IDictionary<string, ICommand>> commandsByName = new(() =>
        {
            var commands = new ICommand[] { new ChangeDirectory(), new List() };
            return commands.ToDictionary(x => x.Name);
        });

        public static Directory ParseInput(this IEnumerable<string> inputs)
        {
            var root = Directory.CreateRoot();
            var currentDirectory = root;

            var argument = string.Empty;
            var currentCommand = string.Empty;
            var outputs = new List<string>();

            using var inputEnumerator = inputs.GetEnumerator();
            while (inputEnumerator.MoveNext())
            {
                var input = inputEnumerator.Current;
                if (input.StartsWith("$"))
                {
                    if (!string.IsNullOrEmpty(currentCommand))
                    {
                        var command = commandsByName.Value[currentCommand];
                        currentDirectory = command.Process(root, currentDirectory, argument, outputs);
                        outputs.Clear();
                    }

                    var split = input[2..].Split(' ');
                    currentCommand = split[0];
                    argument = split.Length == 2 ? split[1] : string.Empty;
                }
                else
                {
                    outputs.Add(input);
                }
            }

            var finalCommand = commandsByName.Value[currentCommand];
            finalCommand.Process(root, currentDirectory, argument, outputs);

            return root;
        }
    }
}
