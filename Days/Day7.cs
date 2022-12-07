namespace AdventOfCode2022.Days;

public class Day7 : Day
{
    public struct Entry
    {
        public string Name;
        public int Weight;
        public List<int> Childs;
        public int Parent;
        public bool IsDir;
    }
    
    public void Execute()
    {
        var dirs = new List<Entry> {
        new() {
            Name = "/",
            Weight = 0,
            Childs = new List<int>(),
            Parent = -1,
            IsDir = true
        }};

        var current = -1;
        var iLine = 0;
        var lines = File.ReadAllLines("Resources/7-input.txt");
        while (iLine < lines.Length)
        {
            if (lines[iLine].StartsWith("$ cd "))
            {
                var dir = lines[iLine].Split(" ")[2];
                current = dir == ".." ? dirs[current].Parent : dirs.IndexOf(dirs.Where(x => x.Parent == current && x.Name == dir).ToList()[0]);
                iLine++;
            }
            else if (lines[iLine].StartsWith("$ ls"))
            {
                iLine++;
                while (iLine < lines.Length && !lines[iLine].StartsWith("$"))
                {
                    dirs[current].Childs.Add(dirs.Count);
                    dirs.Add(CreateEntry(lines[iLine], current));
                    iLine++;
                }
            }
        }

        for (var i = 0; i < dirs.Count; i++)
        {
            dirs[i] = new Entry
            {
                Name = dirs[i].Name,
                Weight = GetWeight(dirs, dirs[i]),
                Childs = dirs[i].Childs,
                Parent = dirs[i].Parent,
                IsDir = dirs[i].IsDir
            };
        }

        var result = dirs.Where(entry => entry.IsDir && entry.Weight <= 100000).Sum(entry => entry.Weight);
        Console.WriteLine($"First Answer : {result}");
        var mustFree = 30000000 - (70000000 - dirs[0].Weight);
        var dirList = dirs.Where(entry => entry.IsDir && entry.Weight >= mustFree).ToList();
        dirList.Sort((e1, e2) => e1.Weight.CompareTo(e2.Weight));
        Console.WriteLine($"Second Answer : {dirList[0].Weight}");
    }

    public static int GetWeight(List<Entry> dirs, Entry dir) =>
        !dir.IsDir ? dir.Weight : dir.Childs.Sum(child => GetWeight(dirs, dirs[child]));

    public static void PrintDir(List<Entry> dirs, Entry dir, int spacing)
    {
        Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", spacing))} - {dir.Name} - {(dir.IsDir ? "dir": "file")} ({dir.Weight})");
        foreach (var child in dir.Childs)
            PrintDir(dirs, dirs[child], spacing + 2);
    }

    public static Entry CreateEntry(string line, int current)
    {
        var infos = line.Split(" ");
        if (infos[0] == "dir")
        {
            return new Entry()
            {
                Name = infos[1],
                Weight = 0,
                Childs = new List<int>(),
                Parent = current,
                IsDir = true
            };
        }
        
        return new Entry()
        {
            Name = infos[1],
            Weight = Convert.ToInt32(infos[0]),
            Childs = new List<int>(),
            Parent = current,
            IsDir = false
        };
    }
}

