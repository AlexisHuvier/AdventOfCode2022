namespace AdventOfCode2022.Days;

public class Day4: Day
{
    public void Execute()
    {
        var firstElf = new List<int>();
        var secondElf = new List<int>();
        var pairs = 0;

        foreach (var line in File.ReadAllLines("Resources/4-input.txt"))
        {
            firstElf.Clear();
            secondElf.Clear();

            var pair = line.Split(",");
            for(var i = Convert.ToInt32(pair[0].Split("-")[0]); i <= Convert.ToInt32(pair[0].Split("-")[1]); i++)
                firstElf.Add(i);
            for(var i = Convert.ToInt32(pair[1].Split("-")[0]); i <= Convert.ToInt32(pair[1].Split("-")[1]); i++)
                secondElf.Add(i);

            if (firstElf.Count <= secondElf.Count)
            {
                if (firstElf.Where(section => !secondElf.Contains(section)).ToList().Count == 0)
                    pairs++;
            }
            else
            {
                if (secondElf.Where(section => !firstElf.Contains(section)).ToList().Count == 0)
                    pairs++;
            }
        }
        
        Console.WriteLine($"First Answer : {pairs}");
        
        pairs = 0;

        foreach (var line in File.ReadAllLines("Resources/4-input.txt"))
        {
            firstElf.Clear();
            secondElf.Clear();

            var pair = line.Split(",");
            for(var i = Convert.ToInt32(pair[0].Split("-")[0]); i <= Convert.ToInt32(pair[0].Split("-")[1]); i++)
                firstElf.Add(i);
            for(var i = Convert.ToInt32(pair[1].Split("-")[0]); i <= Convert.ToInt32(pair[1].Split("-")[1]); i++)
                secondElf.Add(i);

            if (firstElf.Count <= secondElf.Count)
            {
                if (firstElf.Where(section => secondElf.Contains(section)).ToList().Count > 0)
                    pairs++;
            }
            else
            {
                if (secondElf.Where(section => firstElf.Contains(section)).ToList().Count > 0)
                    pairs++;
            }
        }
        
        Console.WriteLine($"Second Answer : {pairs}");
    }
}
