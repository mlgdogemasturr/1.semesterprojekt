abstract class Item                       // Fælles skabelon for ting man kan samle op
{
    protected string name;

    public Item(string name) { this.name = name; }

    public string GetName() { return name; }

    // Hver slags item bestemmer selv, hvad der sker ved opsamling
    public abstract void PickUp(Player player, Inventory inventory);
}