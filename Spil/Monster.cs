public class Monster 
{
    private string Name; 
    private List<MonsterPart> parts;
   private byte Monster_level;

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
    public void RemoveMonsterPart(MonsterPart part)
    {
        parts.Remove(part);
    }
}