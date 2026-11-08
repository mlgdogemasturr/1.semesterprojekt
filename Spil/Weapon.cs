class Weapon : Item
{
    private string material;

    public Weapon(string name, string material) : base(name)
    {
        this.material = material;
    }

    // Tjekker om våbnets materiale er det samme som det materiale, der efterspørges
    public bool HasMaterial(string type) { return material == type; }

    // Angriber en monsterdel med DETTE våben (this sendes videre til Defeat)
    public bool Attack(MonsterPart part) { return part.Defeat(this); }

    // override: Item har en abstract PickUp uden indhold. Weapon giver den her sit eget indhold
    // Parametrene: player (spilleren) og inventory (spillerens våbenliste). Weapon bruger kun inventory
    public override void PickUp(Player player, Inventory inventory)
    {
        // "this" = det Weapon-objekt, vi står i lige nu (fx Metalbatten).
        // Vi sender sig selv ind i inventory-listen, så våbnet bliver en del af spillerens ting
        inventory.AddWeapon(this);
        Console.WriteLine($"Våben tilføjet: {name} ({material})");
    }
    
    // Læsbar tekst, når våbnet printes
    public override string ToString() { return $"{name} ({material})"; }
}