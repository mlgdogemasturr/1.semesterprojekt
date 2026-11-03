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
        return monster.MonsterDefeat();
    }

    public void RestartLevel (Player player) 
    {
        if (player.PlayerDeath()) 
        {
            monster.SpawnMonster();
            player.PlayerRespawn();
        }
    }
}