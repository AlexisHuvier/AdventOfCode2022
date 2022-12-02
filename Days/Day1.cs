namespace AdventOfCode2022.Days;

public class Day1 : Day
{
    public void Execute()
    {
        const string file = "Resources/1-input.txt";
        var gobelins = new List<int>();

        foreach (var line in File.ReadAllLines(file))
        {
            if(line == "" || gobelins.Count == 0)
                gobelins.Add(0);
            else
                gobelins[^1] += Convert.ToInt32(line);
        }
        
        Console.WriteLine($"First Anwser : {gobelins.Max()}");

        var total = gobelins.Max();
        gobelins.Remove(gobelins.Max());
        total += gobelins.Max();
        gobelins.Remove(gobelins.Max());
        total += gobelins.Max();
        
        Console.WriteLine($"Second Anwser : {total}");
    }
}
