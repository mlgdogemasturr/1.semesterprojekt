namespace Classes;
using System.Collections;

public class Inventory
{
    // attributes
    private List <Weapon> weapons = new(); 

    /*
    //construct
    public Weapon(Weapon_name)  
    {
        weapon = Weapon_name; //Name
    }
    */      //should not be relevant, the add function should be doing what this constructor is trying to do
    
    //methods
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