class MonsterPart
{
    private string Name;
    private string MaterialType;
    private bool PartIsDefeated;//Dens tilstand

    // constructor
    public MonsterPart(string name_val, string materialType_val)
    {
        this.Name = name_val;
        this.MaterialType = materialType_val; 
        this.PartIsDefeated = false;//Starter med at være false dvs monsteret er ikke besejret endnu
    }

    // method
    public bool Defeat(Weapon weapon)//Bruges til at vide hvilket våben som bruges til at Defeat monsterdelen
    {
        if(!PartIsDefeated && weapon.HasMaterial(MaterialType))
        {
            PartIsDefeated = true;//Hvis ikke den findes så kan vi besejre monsterdelen igen og igen
            Console.WriteLine($"{MonsterPart} er blevet besejret!");
            return true;
        }
        else
        {
        return false;
        }
    }
}


