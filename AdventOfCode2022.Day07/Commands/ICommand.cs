namespace AdventOfCode2022.Day07.Commands
{
    internal interface ICommand
    {
        string Name { get; }

        Directory Process(Directory root, Directory currentDirectory, string argument, IEnumerable<string> outputs);
    }
}
