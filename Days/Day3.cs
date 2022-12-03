namespace AdventOfCode2022.Days;

public class Day3: Day
{
    public void Execute()
    {
        const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var total = 0;
        
        foreach (var line in File.ReadLines("Resources/3-input.txt"))
        {
            var firstPart = line[..(line.Length / 2)];
            var secondPart = line[(line.Length / 2)..];
            var same = "";
            foreach(var letter in secondPart)
                if (firstPart.Contains(letter))
                {
                    same = letter.ToString();
                    break;
                }
            total += letters.IndexOf(same) + 1;
        }
        
        Console.WriteLine($"First Answer : {total}");
        
        total = 0;

        var lines = File.ReadLines("Resources/3-input.txt").ToList();
        for (var i = 0; i < lines.Count; i+=3)
        {
            var same = "";
            foreach (var letter in lines[i])
            {
                if (lines[i + 1].Contains(letter) && lines[i + 2].Contains(letter))
                {
                    same = letter.ToString();
                    break;
                }
            }
            total += letters.IndexOf(same) + 1;
        }
        
        Console.WriteLine($"Second Answer : {total}");
    }
}
