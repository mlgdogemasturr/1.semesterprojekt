class Space : Node   // Space arver fra Node, så et rum kan forbindes med andre rum
{
    private Monster? monster;   // Rummets monster (kan være null = intet monster)
    private List<Item> loot = new List<Item>();   // Det der ligger på jorden

    public Space(String name) : base(name) { }   // Sender navnet videre til Node's constructor

    public void SetMonster(Monster m) { monster = m; }        // Placér et monster i rummet
    public Monster? GetMonster() { return monster; }          // Hent rummets monster
    public void AddLoot(Item item) { loot.Add(item); }               // Placér et våben i rummet

    // Er der et monster, som stadig er i live?
    public bool HasLivingMonster()
    {
        return monster != null && !monster.IsDefeated();   // && stopper tidligt, hvis monster er null
    }

    // Loot er kun tilgængeligt, når monsteret er besejret, og der ligger noget
    public bool HasAvailableLoot()
    {
        return !HasLivingMonster() && loot.Count > 0;
    }

    // Giver alt loot til spilleren og tømmer rummet (tom liste, hvis monsteret lever)
    public List<Item> TakeLoot()
    {
        if (HasLivingMonster()) return new List<Item>();
        List<Item> result = new List<Item>(loot);
        loot.Clear();
        return result;
    }
    
    // Sidste rum har ingen udgange
    public bool IsFinal() { return edges.Count == 0; }
    
    public void PrintLoot()
    {
        if (!HasAvailableLoot()) return;
        Console.WriteLine("\nDu ser følgende på jorden:");
        foreach (Item item in loot)
        Console.WriteLine("\n - " + item.GetName());
        Console.WriteLine("\nSkriv 'samleOp' for at samle det op.");
    }
    // Skrives, når spilleren træder ind i rummet
    public void Welcome()
    {
        Console.WriteLine("\nDu er nu i: " + name);
        if (HasLivingMonster())
        {
            Console.WriteLine($"\nDu ser {monster!.GetName()} nærme sig!");   // ! = "jeg ved, den ikke er null her"
            monster.PrintParts(); // Vis monsterets dele
            Console.WriteLine("\nAngrib med: angrib <del-nr> <våben-nr>");
        }

        PrintLoot();
        if (!IsFinal())

        {
        Console.WriteLine("\nUdgange:");
        foreach (string exit in edges.Keys)       // edges.Keys = alle retninger ("door", "north" ...)
            Console.WriteLine(" - " + exit);
        }
    }    

    public void Goodbye() { }   // Plads til noget, der skal ske, når man forlader rummet

    // Overskriver Node's metode, så den returnerer et Space i stedet for en Node
    public override Space? FollowEdge(string direction)
    {
        return (Space?)base.FollowEdge(direction);   // Kald Node's version og cast resultatet til Space
    }
}