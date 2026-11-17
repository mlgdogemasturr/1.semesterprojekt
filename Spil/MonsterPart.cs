class MonsterPart
{
    private string name;          // Delens navn, fx "Låg"
    private string materialType;  // Hvilket materiale der skal til for at besejre den, fx "metal"
    private bool isDefeated;      // Er delen besejret? (delens tilstand)

    // Constructor: kaldes, når vi skriver "new MonsterPart(...)"
    public MonsterPart(string name, string materialType)
    {
        this.name = name;                  // Gem navnet i objektets felt (this. skelner felt fra parameter)
        this.materialType = materialType;  // Gem materialet
        this.isDefeated = false;           // Delen starter som ikke-besejret
    }

    public string GetName() { return name; }           // Getter: lader andre klasser læse navnet
    public bool IsDefeated() { return isDefeated; }    // Getter: er delen besejret?
    public void Reset() { isDefeated = false; }        // Gør delen "levende" igen (bruges ved genstart af level)

    // Forsøger at besejre delen med et våben. Returnerer true hvis det lykkedes
    public bool Defeat(Weapon weapon)
    {
        // Kun hvis delen ikke allerede er besejret OG våbnet har det rigtige materiale
        if (!isDefeated && weapon.HasMaterial(materialType))
        {
            isDefeated = true;                                      // Markér delen som besejret
            Console.WriteLine($"\n{name} er blevet besejret!");       // $"..." indsætter variablen {name} i teksten
            return true;                                            // Fortæl kalderen, at det lykkedes
        }
        return false;   // Forkert materiale eller allerede besejret
    }

    // Overskriver ToString, så Console.WriteLine(part) skriver noget læsbart
    public override string ToString()
    {
        // ? : er en kort if/else: tilføj " [besejret]" kun hvis isDefeated er true
        return $"{name} ({materialType})" + (isDefeated ? " [besejret]" : "");
    }
}