class Monster
{
    private string name;                                        // Monsterets navn
    private List<MonsterPart> parts = new List<MonsterPart>();  // Listen af monsterets dele (starter tom)

    public Monster(string name)
    {
        this.name = name;   // Gem navnet
    }

    public string GetName() { return name; }   // Getter til navnet

    // Tilføjer en del til monsteret (bruges i World.cs, når monsteret bygges)
    public void AddMonsterPart(MonsterPart part) { parts.Add(part); }

    // Monsteret er besejret, når ALLE dele er besejret
    public bool IsDefeated()
    {
        return parts.All(p => p.IsDefeated());   // All(...) giver true, hvis betingelsen gælder for hver del
    }

    // Henter en del ud fra spillerens nummer (1, 2, 3 ...). ? efter typen betyder "kan være null"
    public MonsterPart? GetPart(int index)
    {
        if (index < 1 || index > parts.Count) return null;   // Ugyldigt nummer: returnér null
        return parts[index - 1];                             // Lister starter ved 0, spillere tæller fra 1, derfor -1
    }

    // Skriver alle dele ud som en nummereret liste
    public void PrintParts()
    {
        for (int i = 0; i < parts.Count; i++)
            Console.WriteLine($" {i + 1}. {parts[i]}");   // i+1, så listen starter ved 1
    }

    // Gør alle dele levende igen (genstart af level)
    public void Reset()
    {
        foreach (MonsterPart part in parts) part.Reset();   // Gennemløb hver del og nulstil den
    }
}