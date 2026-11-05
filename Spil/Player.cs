public class Player
{
    private byte HealthPoints; // shorthand = HP
    private int DeathCounter; // shorthand = DC

    public Player(byte HealthPoints, int DeathCounter)
    {
        this.HealthPoints = HealthPoints;
        this.DeathCounter = DeathCounter;
    }
    
    public void LoseLife() 
    {
        HealthPoints--;

        if (HealthPoints <= 0)
        {
            PlayerDeath();
        }   // Maybe more functionality should be put in this method
    }
    public bool IsDead()
    {
        return HealthPoints <= 0;
    }
    
    public void PlayerDeath()
    {
        DeathCounter++;
        RestartLevel();
    }
    
    public void PlayerSpawn()
    {
        HealthPoints = 3;
        Print.HealthPoints();
    }
    
    public string ChooseMonsterPart()
    {
        Monster.PrintMonsterparts();
        
        Console.WriteLine($"Choose Monsterpart 1-{MonsterParts.Length}:");
        return Console.ReadLine();
    }
    
    public string ChooseWeapon()
    {
        Inventory.PrintInventory();

        Console.WriteLine($"Choose weapon 1 - {Inventory.Length}:");
        return Console.ReadLine();
    }
    
    public PickUpHP()
    {
        if (HealthPoints < 3)
        {
            HealthPoints++;
        }
        else Console.WriteLine("Du har ikke mistet et liv. Godt arbejde!");
    }

    public byte GetHealthPoints()
    {
        return HealthPoints;
    }

    public int GetDeathCounter()
    {
        return DeathCounter;
    }
}