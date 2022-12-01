using AdventOfCode2022.Days;

namespace AdventOfCode2022;

internal class Program
{
    static void Main()
    {
        Console.Write("Enter day : ");
        try
        {
            var day = Convert.ToInt32(Console.ReadLine());
            switch (day)
            {
                case 1:
                    Day1.Execute();
                    return;
                default:
                    Console.WriteLine("This day doesn't exist");
                    return;
            }
        }
        catch (Exception ex)            
        {
            if (ex is not (FormatException or OverflowException)) throw;
                
            Console.WriteLine("Give a valid number for day.");
            return;

        }
    }
}

