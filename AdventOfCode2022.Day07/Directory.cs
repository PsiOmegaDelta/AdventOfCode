using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2022.Day07
{
    public class Directory
    {
        private readonly Dictionary<string, Directory> directories = new();
        private readonly Dictionary<string, File> files = new();

        public Directory(Directory parent, string name)
        {
            Parent = parent;
            Name = name;
        }

        private Directory(string name)
        {
            Parent = this;
            Name = name;
        }

        public IEnumerable<Directory> Directories => directories.Values;

        public IEnumerable<File> Files => files.Values;

        public string Name { get; }

        public Directory Parent { get; }

        public static Directory CreateRoot() => new("/");

        public Directory AddDirectory(string name)
        {
            return directories.GetOrAdd(name, x => new Directory(this, x));
        }

        public void AddFile(string name, int size)
        {
            if (files.TryGetValue(name, out var file))
            {
                if (file.Size != size)
                {
                    throw new Exception("Something went terribly wrong");
                }
            }
            else
            {
                files.Add(name, new File(this, name, size));
            }
        }
    }
}
