namespace AdventOfCode2022.Day07.Commands
{
    public class ChangeDirectory : ICommand
    {
        public string Name => "cd";

        public Directory Process(
            Directory root,
            Directory currentDirectory,
            string argument,
            IEnumerable<string> outputs)
        {
            if (argument == "/")
            {
                return root;
            }
            else if (argument == "..")
            {
                return currentDirectory.Parent;
            }
            else
            {
                return currentDirectory.AddDirectory(argument);
            }

            throw new Exception("Unhandled input");
        }
    }
}
