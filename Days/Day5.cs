namespace AdventOfCode2022.Days;

public class Day5: Day
{
    public List<Stack<string>> GetTab(string texte)
    {
        var piles = new List<Stack<string>>();
        var lines = texte.Split("\n").ToList();
        var nbPile = Convert.ToInt32(lines[^1][^2].ToString());
        for (var i = 0; i < nbPile; i++)
            piles.Add(new Stack<string>());
        lines.Reverse();
        lines.RemoveAt(0);
        foreach (var line in lines )
        {
            for (var i = 0; i < nbPile; i++)
            {
                if(line[1 + i * 4] != ' ')
                    piles[i].Push(line[1 + i * 4].ToString());
            }
        }
        return piles;
    }

    public void Execute()
    {
        var piles = new List<Stack<string>>();

        var isInTab = true;
        var tab = "";
        foreach (var line in File.ReadAllLines("Resources/5-input.txt"))
        {
            
            if (line == "")
            {
                isInTab = false;
                tab = tab[..^1];
                piles = GetTab(tab);
            }
            
            if(isInTab)
                tab += line + "\n";
            else if(line != "")
            {
                var nb = Convert.ToInt32(line.Split(" ")[1]);
                var from = Convert.ToInt32(line.Split(" ")[3]);
                var to = Convert.ToInt32(line.Split(" ")[5]);
                for (var i = 0; i < nb; i++)
                {
                    var poped = piles[from-1].Pop();
                    piles[to-1].Push(poped);
                }
            }
        }
        
        Console.Write("First answer : ");
        foreach(var pile in piles)
            Console.Write(pile.Pop());
        Console.WriteLine();
        
        piles = new List<Stack<string>>();

        isInTab = true;
        tab = "";
        foreach (var line in File.ReadAllLines("Resources/5-input.txt"))
        {
            
            if (line == "")
            {
                isInTab = false;
                tab = tab[..^1];
                piles = GetTab(tab);
            }
            
            if(isInTab)
                tab += line + "\n";
            else if(line != "")
            {
                var nb = Convert.ToInt32(line.Split(" ")[1]);
                var from = Convert.ToInt32(line.Split(" ")[3]);
                var to = Convert.ToInt32(line.Split(" ")[5]);
                var liste = new List<string>();
                for (var i = 0; i < nb; i++)
                    liste.Add(piles[from-1].Pop());
                for(var i = liste.Count - 1; i > -1; i--)
                    piles[to-1].Push(liste[i]);
            }
        }
        
        Console.Write("First answer : ");
        foreach(var pile in piles)
            Console.Write(pile.Pop());
        Console.WriteLine();
    }
}
