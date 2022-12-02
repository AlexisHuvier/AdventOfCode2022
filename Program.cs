﻿using AdventOfCode2022.Days;

namespace AdventOfCode2022;

internal class Program
{
    static readonly List<Day> Days = new()
    {
        new Day1(),
    };

    static void Main()
    {
        while (true)
        {
            Console.Write("Enter day (or 0 to quit): ");
            try
            {
                var day = Convert.ToInt32(Console.ReadLine());
                if (day == 0)
                    return;
                
                if (day > Days.Count)
                    Console.WriteLine("This day doesn't exist");
                else
                    Days[day - 1].Execute();
            }
            catch (Exception ex)
            {
                if (ex is not (FormatException or OverflowException)) throw;

                Console.WriteLine("Give a valid number for day.");
            }
        }
    }
}

