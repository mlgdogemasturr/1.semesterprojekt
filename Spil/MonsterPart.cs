class MonsterPart
{
    private string Name;
    private string MaterialType;
    private bool IsDefeated;//Dens tilstand
    
    public MonsterPart(string name_val, string materialType_val)
    {
        this.Name = name_val;
        this.MaterialType = materialType_val; 
        this.PartIsDefeated = false;//Starter med at være false dvs monsteret er ikke besejret endnu
    }
    public bool Defeat(Weapon weapon)//Bruges til at vide hvilket våben som bruges til at Defeat monsterdelen
    {
        if(!PartIsDefeated && weapon.HasMaterial(MaterialType))
        {
            IsDefeated = true;//Hvis ikke den findes så kan vi besejre monsterdelen igen og igen
            return true;
        }
        else
        {
        return false;
        }
    }
        
    
}


