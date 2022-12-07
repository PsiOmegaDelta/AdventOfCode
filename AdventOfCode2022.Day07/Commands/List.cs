namespace AdventOfCode2022.Day07.Commands
{
    public class List : ICommand
    {
        public string Name => "ls";

        public Directory Process(
            Directory root,
            Directory currentDirectory,
            string argument,
            IEnumerable<string> outputs)
        {
            foreach (var input in outputs)
            {
                if (input.StartsWith("dir"))
                {
                    currentDirectory.AddDirectory(input[4..]);
                }
                else
                {
                    var split = input.Split(' ');
                    currentDirectory.AddFile(split[1], int.Parse(split[0]));
                }
            }

            return currentDirectory;
        }
    }
}
