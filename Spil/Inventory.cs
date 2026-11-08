class Inventory
{
    private List<Weapon> weapons = new List<Weapon>();   // Spillerens våben (starter tom)

    public void AddWeapon(Weapon w) { weapons.Add(w); }  // Tilføj et våben til listen

    // Henter et våben ud fra spillerens nummer (1-baseret)
    public Weapon? GetWeapon(int index)
    {
        if (index < 1 || index > weapons.Count) return null;   // Ugyldigt nummer
        return weapons[index - 1];                             // -1 fordi listen starter ved 0
    }

    // Skriver inventory ud som nummereret liste
    public void PrintInventory()
    {
        if (weapons.Count == 0) { Console.WriteLine(" (tomt)"); return; }   // Hvis tomt: skriv det og stop
        for (int i = 0; i < weapons.Count; i++)
            Console.WriteLine($" {i + 1}. {weapons[i]}");
    }
}