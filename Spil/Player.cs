public class Player
{
    private byte HealthPoints; // shorthand = HP
    private int DeathCounter; // shorthand = DC

    public Player(byte HealthPoints_val, int DeathCounter_val )
    {
        this.HealthPoints = HealthPoints_val;
        this.DeathCounter = DeathCounter_val;
    }
    
    public void LoseLife()
    {
        HealthPoints--;
        if (HealthPoints==0)
        {
            PlayerDeath();
        }
            
        // Maybe more functionality should be put in this method
    }
    
    public void PlayerDeath()
    {
        
    }
    
    public void PlayerRespawn()
    {
        
    }
    
    
    public void ChooseMonsterPart()
    {
        Monster.PrintMonsterparts();
        Console.WriteLine($"Choose Monsterpart 1-{MonsterParts.Length}:");
        return Console.ReadLine();
    }
    
    public ChooseWeapon()
    {
        Inventory.PrintInventory();
        Console.WriteLine($"Choose weapon 1 - {Inventory.Length}:");
        return Console.ReadLine();
    }
    
    public SetFullHP()
    {
        HealthPoints=3;
    }

    public PickUpHP()
    {
        if (HealthPoints < 3)
        {
            HealthPoints=HealthPoints+1;
        }
    }
}