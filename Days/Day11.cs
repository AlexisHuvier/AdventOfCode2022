namespace AdventOfCode2022.Days;

public class Day11: Day
{
    class Monkey
    {
        public int Nb;
        public List<int> Items;
        public string Operation;
        public int Test;
        public int TrueMonkey;
        public int FalseMonkey;
        public int Inspect = 0;

        public Monkey(int nb, List<int> items, string operation, int test, int trueMonkey, int falseMonkey)
        {
            Nb = nb;
            Items = items;
            Operation = operation;
            Test = test;
            TrueMonkey = trueMonkey;
            FalseMonkey = falseMonkey;
        }
        
        public int ApplyOperation(int nb)
        {
            if (Operation[4] == '+')
            {
                if (Operation.Split(" + ")[1] == "old")
                    return (int)Math.Floor(nb + nb / 3d);
                return (int)Math.Floor((nb + Convert.ToInt32(Operation.Split(" + ")[1])) / 3d);
            }
            if (Operation.Split(" * ")[1] == "old")
                return (int)Math.Floor(nb * nb / 3d);
            return (int)Math.Floor(nb * Convert.ToInt32(Operation.Split(" * ")[1]) / 3d);
        }

        public static Monkey FromString(IReadOnlyList<string> monkeyLines)
        {
            var nb = Convert.ToInt32(monkeyLines[0][^2].ToString());
            var list = monkeyLines[1].Split(": ")[1].Split(", ").Select(x => Convert.ToInt32(x)).ToList();
            var operation = monkeyLines[2].Split(" = ")[1];
            var test = Convert.ToInt32(monkeyLines[3].Split("by ")[1]);
            var trueMonkey = Convert.ToInt32(monkeyLines[4][^1].ToString());
            var falseMonkey = Convert.ToInt32(monkeyLines[5][^1].ToString());
            return new Monkey(nb, list, operation, test, trueMonkey, falseMonkey);
        }
    }


    public void Execute()
    {
        var monkeysLines = File.ReadAllText("Resources/11-input.txt").Replace("\r", "").Split("\n\n");
        var monkeys = monkeysLines.Select(monkeyLine => Monkey.FromString(monkeyLine.Split("\n"))).ToList();
        
        for (var i = 0; i < 20; i++)
        {
            foreach (var monkey in monkeys)
            {
                var nb = monkey.Items.Count;
                while (nb > 0)
                {
                    monkey.Inspect++;
                    var item = monkey.Items[0];
                    item = monkey.ApplyOperation(item);
                    if(item % monkey.Test == 0)
                        monkeys[monkey.TrueMonkey].Items.Add(item);
                    else
                        monkeys[monkey.FalseMonkey].Items.Add(item);
                    monkey.Items.RemoveAt(0);
                    nb--;
                }
            }
        }
        
        monkeys.Sort((m1, m2) => m1.Inspect.CompareTo(m2.Inspect));
        Console.WriteLine($"First Answer : {monkeys[^1].Inspect * monkeys[^2].Inspect} ({monkeys[^1].Inspect} * {monkeys[^2].Inspect})");
    }
}
