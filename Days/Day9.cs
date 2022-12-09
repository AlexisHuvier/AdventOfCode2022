namespace AdventOfCode2022.Days;

public class Day9: Day
{
    public int[] GetNextPosition(int headPosX, int headPosY, int tailPosX, int tailPosY)
    {
        if (headPosX - tailPosX >= 2 && headPosY - tailPosY == 0)
            tailPosX++;
        else if (headPosX - tailPosX <= -2 && headPosY - tailPosY == 0)
            tailPosX--;
        else if (headPosX - tailPosX == 0 && headPosY - tailPosY >= 2)
            tailPosY++;
        else if (headPosX - tailPosX == 0 && headPosY - tailPosY <= -2)
            tailPosY--;
        else if (headPosX - tailPosX >= 2 && headPosY - tailPosY == 1 ||
                 headPosX - tailPosX == 1 && headPosY - tailPosY >= 2 ||
                 headPosX - tailPosX >= 2 && headPosY - tailPosY >= 2)
        {
            tailPosX++;
            tailPosY++;
        }
        else if (headPosX - tailPosX <= -2 && headPosY - tailPosY == 1 ||
                 headPosX - tailPosX == -1 && headPosY - tailPosY >= 2||
                 headPosX - tailPosX <= -2 && headPosY - tailPosY >= 2)
        {
            tailPosX--;
            tailPosY++;
        }
        else if (headPosX - tailPosX <= -2 && headPosY - tailPosY == -1 ||
                 headPosX - tailPosX == -1 && headPosY - tailPosY <= -2 ||
                 headPosX - tailPosX <= -2 && headPosY - tailPosY <= -2)
        {
            tailPosX--;
            tailPosY--;
        }
        else if (headPosX - tailPosX >= 2 && headPosY - tailPosY == -1 ||
                 headPosX - tailPosX == 1 && headPosY - tailPosY <= -2||
                 headPosX - tailPosX >= 2 && headPosY - tailPosY <= -2)
        {
            tailPosX++;
            tailPosY--;
        }

        return new[] { tailPosX, tailPosY };
    }
    
    public void Execute()
    {
        var tailPosX = 100;
        var tailPosY = 100;
        var headPosX = 100;
        var headPosY = 100;
        var viewPos = new List<int[]> { new[] {100, 100} };

        foreach (var line in File.ReadAllLines("Resources/9-input.txt"))
        {
            var direction = line.Split(" ")[0];
            var length = Convert.ToInt32(line.Split(" ")[1]);
            for (var i = 0; i < length; i++)
            {
                switch (direction)
                {
                    case "U":
                        headPosY++;
                        break;
                    case "D":
                        headPosY--;
                        break;
                    case "L":
                        headPosX--;
                        break;
                    default:
                        headPosX++;
                        break;
                }

                var temp = GetNextPosition(headPosX, headPosY, tailPosX, tailPosY);
                tailPosX = temp[0];
                tailPosY = temp[1];
                
                if(viewPos.Where(x => x[0] == tailPosX && x[1] == tailPosY).ToList().Count == 0)
                    viewPos.Add(new []{tailPosX, tailPosY});
            }
        }
        
        Console.WriteLine($"First Answer : {viewPos.Count}");
        
        tailPosX = 100;
        tailPosY = 100;
        headPosX = 100;
        headPosY = 100;
        viewPos = new List<int[]> { new[] {100, 100} };
        var n1PosX = 100;
        var n1PosY = 100;
        var n2PosX = 100;
        var n2PosY = 100;
        var n3PosX = 100;
        var n3PosY = 100;
        var n4PosX = 100;
        var n4PosY = 100;
        var n5PosX = 100;
        var n5PosY = 100;
        var n6PosX = 100;
        var n6PosY = 100;
        var n7PosX = 100;
        var n7PosY = 100;
        var n8PosX = 100;
        var n8PosY = 100;

        foreach (var line in File.ReadAllLines("Resources/9-input.txt"))
        {
            var direction = line.Split(" ")[0];
            var length = Convert.ToInt32(line.Split(" ")[1]);
            for (var i = 0; i < length; i++)
            {
                switch (direction)
                {
                    case "U":
                        headPosY++;
                        break;
                    case "D":
                        headPosY--;
                        break;
                    case "L":
                        headPosX--;
                        break;
                    default:
                        headPosX++;
                        break;
                }

                var temp = GetNextPosition(headPosX, headPosY, n1PosX, n1PosY);
                n1PosX = temp[0];
                n1PosY = temp[1];
                var temp2 = GetNextPosition(n1PosX, n1PosY, n2PosX, n2PosY);
                n2PosX = temp2[0];
                n2PosY = temp2[1];
                var temp3 = GetNextPosition(n2PosX, n2PosY, n3PosX, n3PosY);
                n3PosX = temp3[0];
                n3PosY = temp3[1];
                var temp4 = GetNextPosition(n3PosX, n3PosY, n4PosX, n4PosY);
                n4PosX = temp4[0];
                n4PosY = temp4[1];
                var temp5 = GetNextPosition(n4PosX, n4PosY, n5PosX, n5PosY);
                n5PosX = temp5[0];
                n5PosY = temp5[1];
                var temp6 = GetNextPosition(n5PosX, n5PosY, n6PosX, n6PosY);
                n6PosX = temp6[0];
                n6PosY = temp6[1];
                var temp7 = GetNextPosition(n6PosX, n6PosY, n7PosX, n7PosY);
                n7PosX = temp7[0];
                n7PosY = temp7[1];
                var temp8 = GetNextPosition(n7PosX, n7PosY, n8PosX, n8PosY);
                n8PosX = temp8[0];
                n8PosY = temp8[1];
                var temp9 = GetNextPosition(n8PosX, n8PosY, tailPosX, tailPosY);
                tailPosX = temp9[0];
                tailPosY = temp9[1];

                if(viewPos.Where(x => x[0] == tailPosX && x[1] == tailPosY).ToList().Count == 0)
                    viewPos.Add(new []{tailPosX, tailPosY});
            }
        }
        
        Console.WriteLine($"Second Answer : {viewPos.Count}");
    }
}
