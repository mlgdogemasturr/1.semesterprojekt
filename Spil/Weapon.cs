public class Weapon
{
    public string Weapon;
    public string Material;

    public Weapon(Weapon_name, Weapon_mat){ //construct
        Weapon = Weapon_name;
        Material = Weapon_mat;
    }

    public bool Attack(MonsterPart part){
        return Material == part.Weakness
    }
}