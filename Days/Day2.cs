namespace AdventOfCode2022.Days;

public class Day2: Day
{
    public void Execute()
    {
        const string file = "Resources/2-input.txt";

        var total = 0;
        
        foreach (var line in File.ReadAllLines(file))
        {
            var opponent = line[0];
            var self = line[2];

            switch (self)
            {
                case 'X':
                    total += 1;
                    break;
                case 'Y':
                    total += 2;
                    break;
                case 'Z':
                    total += 3;
                    break;
            }

            if (opponent == 'A' && self == 'X' || opponent == 'B' && self == 'Y' || opponent == 'C' && self == 'Z')
                total += 3;
            else if (opponent == 'A' && self == 'Y' || opponent == 'B' && self == 'Z' || opponent == 'C' && self == 'X')
                total += 6;
        }
        
        Console.WriteLine($"First Answer : {total}");

        total = 0;
        
        foreach (var line in File.ReadAllLines(file))
        {
            var opponent = line[0];
            var result = line[2];

            switch (result)
            {
                case 'Y':
                    total += 3;
                    break;
                case 'Z':
                    total += 6;
                    break;
            }

            if (opponent == 'A' && result == 'Y' || opponent == 'B' && result == 'X' || opponent == 'C' && result == 'Z')
                total += 1;
            else if (opponent == 'A' && result == 'Z' || opponent == 'B' && result == 'Y' ||
                     opponent == 'C' && result == 'X')
                total += 2;
            else
                total += 3;
        }
        
        Console.WriteLine($"Second Answer : {total}");
    }
}
