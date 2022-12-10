namespace AdventOfCode2022.Days;

public class Day10: Day
{
    int _x = 1;
    int _cycle;
    int _result;
    
    public void Execute()
    {

        foreach (var line in File.ReadAllLines("Resources/10-input.txt"))
        {
            if (line.StartsWith("noop"))
            {
                _cycle++;
                VerifCycle();
            }
            else if (line.StartsWith("addx"))
            {
                _cycle++;
                VerifCycle();
                _cycle++;
                VerifCycle();
                _x += Convert.ToInt32(line.Split(" ")[1]);
            }
        }
        
        Console.WriteLine($"First Answer : {_result}");

        var ctr = "";
        _x = 1;
        _cycle = 0;
        foreach (var line in File.ReadAllLines("Resources/10-input.txt"))
        {
            if (line.StartsWith("noop"))
            {
                _cycle++;
                ctr += _x == ctr.Length % 40 || _x - 1 == ctr.Length % 40 || _x + 1 == ctr.Length % 40 ? "#" : ".";
            }
            else if (line.StartsWith("addx"))
            {
                _cycle++;
                ctr += _x == ctr.Length % 40 || _x - 1 == ctr.Length % 40 || _x + 1 == ctr.Length % 40 ? "#" : ".";
                _cycle++;
                ctr += _x == ctr.Length % 40 || _x - 1 == ctr.Length % 40 || _x + 1 == ctr.Length % 40 ? "#" : ".";
                _x += Convert.ToInt32(line.Split(" ")[1]);
            }
        }
        
        Console.WriteLine("Second Answer :");
        for(var i = 40; i <= ctr.Length; i+=40)
            Console.WriteLine(ctr.Substring(i-40, 40));
    }

    public void VerifCycle()
    {
        if (_cycle is 20 or 60 or 100 or 140 or 180 or 220)
            _result += _x * _cycle;
    }
}
