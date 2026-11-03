public class Weapon
{
    private string Weapon;
    private string Material;

    public Weapon(Weapon_name, Weapon_mat){ //construct
        Weapon = Weapon_name;
        Material = Weapon_mat;
    }

    public bool Attack(MonsterPart part){
        return Material == part.Weakness
    }
}