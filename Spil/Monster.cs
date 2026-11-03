public class Monster 
{
    string Name; 
    private List<MonsterPart> parts;
    byte Monster_level;

    public Monster(string Name_val, byte Monster_level_val)
    {
       this.Name = Name_val;
       this.Monster_level = Monster_level_val;
       parts = new List<MonsterPart>();
    }
    public void MonsterDefeat()
    {
        
    }
    public void SpawnMonster()
    {
        
    }
    public void AddMonsterPart(MonsterPart part)
    {
        parts.Add(part);
    }
}