using System.Data;

namespace AdventOfCode2022.Days;

public class Day8: Day
{
    public struct Pos
    {
        public int X;
        public int Y;
    }
    
    public void Execute()
    {
        var gridTrees = File.ReadAllLines("Resources/8-input.txt").Select(line => line.Select(x => Convert.ToInt32(x.ToString())).ToList()).ToList();

        var result = 0;
        for (var y = 0; y < gridTrees.Count; y++)
            for (var x = 0; x < gridTrees.Count; x++)
                result += IsVisibleTree(gridTrees, new Pos { X = x, Y = y });
        
        Console.WriteLine($"First Answer : {result}");

        result = 0;

        for (var y = 0; y < gridTrees.Count; y++)
        {
            for (var x = 0; x < gridTrees.Count; x++)
            {
                var temp = GetTreeScenicScore(gridTrees, new Pos { X = x, Y = y });
                if (temp > result)
                    result = temp;
            }
        }
        
        Console.WriteLine($"Second Answer : {result}");
    }

    public int GetTreeScenicScore(List<List<int>> grid, Pos tree)
    {
        var result = 1;
        var temp = 1;
        for (var x = tree.X - 1; x > -1; x--)
        {
            if (grid[tree.Y][tree.X] <= grid[tree.Y][x] || x == 0) break;
            temp++;
        }

        result *= temp;
        temp = 1;

        for (var x = tree.X + 1; x < grid[0].Count; x++)
        {
            if (grid[tree.Y][tree.X] <= grid[tree.Y][x] || x == grid[0].Count - 1) break;
            temp++;
        }

        result *= temp;
        temp = 1;
        
        for (var y = tree.Y - 1; y > -1; y--)
        {
            if (grid[tree.Y][tree.X] <= grid[y][tree.X] || y == 0) break;
            temp++;
        }
        
        result *= temp;
        temp = 1;
        
        for(var y = tree.Y + 1; y < grid.Count; y++)
        {
            if (grid[tree.Y][tree.X] <= grid[y][tree.X] || y == grid.Count - 1) break;
            temp++;
        }
        
        result *= temp;
        return result;
    }

    public int IsVisibleTree(List<List<int>> grid, Pos tree)
    {
        if (tree.X == 0 || tree.X == grid[0].Count - 1 || tree.Y == 0 || tree.Y == grid.Count - 1)
            return 1;

        for (var x = tree.X - 1; x > -1; x--)
        {
            if (grid[tree.Y][tree.X] <= grid[tree.Y][x]) break;
            if (x == 0)
                return 1;
        }

        for (var x = tree.X + 1; x < grid[0].Count; x++)
        {
            if (grid[tree.Y][tree.X] <= grid[tree.Y][x]) break;
            if (x == grid[0].Count-1)
                return 1;
        }
        
        for (var y = tree.Y - 1; y > -1; y--)
        {
            if (grid[tree.Y][tree.X] <= grid[y][tree.X]) break;
            if (y == 0)
                return 1;
        }
        
        for(var y = tree.Y + 1; y < grid.Count; y++)
        {
            if (grid[tree.Y][tree.X] <= grid[y][tree.X]) break;
            if (y == grid.Count-1)
                return 1;
        }
        
        return 0;
    }
}
