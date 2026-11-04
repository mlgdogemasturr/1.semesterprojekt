public class Weapon
{
    private string Name; 
    private string Material; 

    public Weapon(string Weapon_name, string Weapon_mat){ //construct
        this.Name = Weapon_name;
        this.Material = Weapon_mat;
    }

    public bool HasMaterial(string Material_type){ //Metode kaldes fra MonsterPart.cs
        if (Material == Material_type) //Er begge materialer ens så return true
        {
            return true; //
        }
        else
        {
            return false;
        }
    }
    
    public bool Attack(MonsterPart part){
        return part.Defeat(this); // bruger nuværende våben objekt til at tjekke materialet
        }
    }
}
