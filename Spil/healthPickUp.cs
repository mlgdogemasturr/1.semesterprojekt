class HealthPickup : Item
{
    public HealthPickup() : base("Ekstra liv") { }

    public override void PickUp(Player player, Inventory inventory)
    {
        player.PickUpHP();   // +1 liv, hvis spilleren ikke har fuldt liv
        Console.WriteLine($"Du har nu {player.GetHealthPoints()} liv.");
    }
}