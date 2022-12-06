namespace AdventOfCode2022.Days;

public class Day6: Day
{
    public void Execute()
    {
        var line = File.ReadAllLines("Resources/6-input.txt")[0];
        for (var i = 0; i < line.Length - 4; i++)
        {
            var letters = line.Substring(i, 4).ToList();
            if (letters.Distinct().Count() == 4)
            {
                Console.WriteLine($"First Anwser : {i+4} - {string.Join(" ",letters)}");
                break;
            }
        }
        for (var i = 0; i < line.Length - 14; i++)
        {
            var letters = line.Substring(i, 14).ToList();
            if (letters.Distinct().Count() == 14)
            {
                Console.WriteLine($"Second Anwser : {i+14} - {string.Join(" ",letters)}");
                break;
            }
        }
    }
}
