namespace AdventOfCode2022.Day07
{
    public class File
    {
        public File(Directory directory, string name, long size)
        {
            Directory = directory;
            Name = name;
            Size = size;
        }

        public Directory Directory { get; }

        public string Name { get; }

        public long Size { get; }
    }
}
