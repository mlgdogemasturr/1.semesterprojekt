public class Weapon
{
    public string Name;
    public string Material;

    public Weapon(Weapon_name, Weapon_mat){ //construct
        this.Name = Weapon_name;
        Material = Weapon_mat;
    }

    public bool Attack(MonsterPart part){
        return Material == part.Weakness
    }
    public void SpawnWeapon()
    {
        
    }
}