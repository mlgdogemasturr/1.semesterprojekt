class Level 
{
    private Byte levelCounter;

    public Level(byte levelCounter) 
    {
        this.levelCounter = levelCounter;
    }

    public void NextLevel () 
    {
        levelCounter++;
    }

    public bool CompleteLevel () 
    {
        return monster.MonsterDefeat(); //Hvis monsteret er defeat er level complete
    }

    public void RestartLevel (Player player) 
    {
        player.PlayerSpawn();
        monster.SpawnMonster();
    }
}