class MonsterPart
{
    private string Name;
    private string MaterialType;
    private bool IsDefeated;
    
    public MonsterPart(string name_val, string materialType_val)
    {
        this.Name = name_val;
        this.MaterialType = materialType_val; 
        this.IsDefeated = false;
    }
    public bool Defeat(Weapon weapon)
    {
    if(!IsDefated && HasMaterial(MaterialType))
    }
        
    
}


