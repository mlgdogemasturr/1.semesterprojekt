namespace Classes;
public class Inventory
{
    // attributes
    private List <Weapon> weapons = new(); 
    
    //methods
    public Weapon(Weapon_name)  //construct
    {
        weapon = Weapon_name; //Name
    }

    public void AddWeapon(Weapon a)
    {
        weapons.Add(a); //Requires weapon class
    }

    public void PrintInventory()
    {
        foreach (Weapon weapon in weapons)
        Console.WriteLine(item.ToString());
    }
}